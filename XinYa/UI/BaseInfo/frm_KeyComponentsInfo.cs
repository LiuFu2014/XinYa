using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;
using XinYa.BLL;

namespace XinYa.UI.BaseInfo
{
    public partial class frm_KeyComponentsInfo : Form
    {
        TB_User user;
        public frm_KeyComponentsInfo(TB_User user)
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;
            DataInit(null);
            //初始为就绪模式
            TextReadAccess(false);
            btnVisibleForReady();
            this.user = user;
        }

        /// <summary>
        /// dgv_Main加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Main.Rows[e.RowIndex].DataBoundItem != null) && (dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_Main.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        e.Value = result.ToString();//拿到对应的值
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 数据初始化,参数为空则加载全部
        /// </summary>
        /// <param name="keyComponentsName"></param>
        public void DataInit(string keyComponentsName)
        {
            if (keyComponentsName == null)
            {
                //加载全部
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        if (db.TB_KeyComponentsInfo.Count() == 0)
                        {
                            MessageBox.Show("当前没有可用的数据");
                        }
                        else
                        {
                            var a = db.TB_KeyComponentsInfo.ToList();
                            foreach (var item in a)
                            {
                                item.TB_UserReference.Load();
                            }
                            dgv_Main.DataSource = a;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载数据出现异常，详情请查看本地日志！");
                        LogExecute.WriteInfoLog("加载数据出现异常.操作者" + user.UserName + "。来源:" + "关键部件信息管理." + "详情" + ex.ToString());
                    }
                }
            }
            else
            {
                //模糊查询
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_KeyComponentsInfo.ToList();
                        List<TB_KeyComponentsInfo> list_keyComponents = new List<TB_KeyComponentsInfo>();
                        foreach (var item in a)
                        {
                            if (item.KeyComponentsName.Contains(keyComponentsName))
                            {
                                list_keyComponents.Add(item);
                            }
                        }
                        foreach (var item in list_keyComponents)
                        {
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = list_keyComponents;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载数据出现异常，详情请查看本地日志！");
                        LogExecute.WriteInfoLog("查询数据出现异常.操作者" + user.UserName + "。来源:" + "关键部件信息管理." + "详情" + ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            //只能在就绪模式下进行模糊查询
            if (lab_StatusTextBottom.Text != "就绪")
            {
                MessageBox.Show("请在就绪模式下进行查询！");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_KeyNameSer.Text))
                {
                    MessageBox.Show("请输入关键部件名称，然后进行查询！");
                }
                else
                {
                    DataInit(txt_KeyNameSer.Text);
                }
            }
        }

        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="flag"></param>
        public void Changeprobar(bool flag)
        {
            if (flag)
            {
                lab_Status.Visible = true;
                prosbar_Main.Visible = true;
            }
            else
            {
                lab_Status.Visible = false;
                prosbar_Main.Visible = false;
            }
        }

        /// <summary>
        /// txt文本访问控制，true可以写，false不可以写
        /// </summary>
        /// <param name="flag"></param>
        public void TextReadAccess(bool flag)
        {
            if (flag)
            {
                txt_AssiteName.ReadOnly = false;
                txt_KeyComName.ReadOnly = false;
                txt_Remark.ReadOnly = false;
            }
            else
            {
                txt_AssiteName.ReadOnly = true;
                txt_KeyComName.ReadOnly = true;
                txt_Remark.ReadOnly = true;
            }
        }

        /// <summary>
        /// 文本框清空
        /// </summary>
        public void TextClear()
        {
            txt_AssiteName.Text = "";
            txt_KeyComName.Text = "";
            txt_Remark.Text = "";
            lab_Recorder.Text = "";
            lab_RecordDate.Text = "";
        }

        /// <summary>
        /// 就绪状态下的btn可见性
        /// </summary>
        public void btnVisibleForReady()
        {
            btn_Cancel.Visible = true;
            btn_OutportData.Visible = true;
            btn_Refresh.Visible = true;
            btn_AddNew.Visible = true;
            btn_Edit.Visible = true;
            btn_Delete.Visible = true;
            //不可见
            btn_AddNewCancel.Visible = false;
            btn_EditCancel.Visible = false;
            //确认与清空
            btn_Confirm.Visible = false;
            btn_Clear.Visible = false;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            //判断是否是就绪状态，如果不是，拒绝
            if (lab_StatusTextBottom.Text != "就绪")
            {
                MessageBox.Show("请完成或取消未完成的操作，进入就绪模式后再进行此操作！");
            }
            else
            {
                //进入新增模式
                lab_StatusTextBottom.Text = "新增";
                //退出和取消新增可见，其他不可见
                //可见
                btn_Cancel.Visible = true;
                btn_AddNewCancel.Visible = true;
                btn_Clear.Visible = true;
                btn_Confirm.Visible = true;
                //不可见
                btn_OutportData.Visible = false;
                btn_Refresh.Visible = false;
                btn_AddNew.Visible = false;
                btn_Edit.Visible = false;
                btn_EditCancel.Visible = false;
                btn_Delete.Visible = false;
                //文本框可写
                TextReadAccess(true);

                //清空信息框
                TextClear();
                //dgv变得不可用
                dgv_Main.Enabled = false;
            }

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //判断是否处于就绪状态
            if (lab_StatusTextBottom.Text != "就绪")
            {
                MessageBox.Show("请完成或取消未完成的操作，进入就绪模式后再进行此操作！");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_KeyComName.Text))
                {
                    MessageBox.Show("请点击左侧数据行，加载完数据后再进行编辑操作");
                }
                else
                {
                    //进入编辑模式
                    lab_StatusTextBottom.Text = "编辑";
                    //退出和取消编辑可见，其他不可见
                    btn_Cancel.Visible = true;
                    btn_EditCancel.Visible = true;
                    btn_Clear.Visible = true;
                    btn_Confirm.Visible = true;
                    //其他不可见
                    btn_OutportData.Visible = false;
                    btn_Refresh.Visible = false;
                    btn_AddNew.Visible = false;
                    btn_AddNewCancel.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Delete.Visible = false;
                    //文本框可写
                    TextReadAccess(true);
                    //dgv变得不可用
                    dgv_Main.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportData_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_Main);
            Changeprobar(false);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (lab_StatusTextBottom.Text == "就绪")
            {
                DataInit(null);
            }
            else
            {
                MessageBox.Show("请在就绪模式下使用刷新功能");
            }
        }

        /// <summary>
        /// 取消新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNewCancel_Click(object sender, EventArgs e)
        {
            //模式变为就绪
            lab_StatusTextBottom.Text = "就绪";
            //dgv变为可用
            dgv_Main.Enabled = true;
            //文本框不可编辑
            TextReadAccess(false);
            //文本框清空
            TextClear();
            //按钮可见性
            btnVisibleForReady();
        }

        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditCancel_Click(object sender, EventArgs e)
        {
            //模式变为就绪
            lab_StatusTextBottom.Text = "就绪";
            //dgv变为可用
            dgv_Main.Enabled = true;
            //文本框不可编辑
            TextReadAccess(false);
            //文本框清空
            TextClear();
            //按钮可见性
            btnVisibleForReady();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lab_StatusTextBottom.Text != "就绪")
            {
                MessageBox.Show("请完成或取消未完成的操作，进入就绪模式后再进行此操作！");
            }
            else
            {
                //判断是否有可以用于删除的数据
                if (dgv_Main.DataSource == null || dgv_Main.Rows[0].Cells[0].Value == null)
                {
                    MessageBox.Show("当前没有可用于删除的数据！");
                }
                else
                {
                    //获取当前ID和主要部件名称
                    int id = (int)dgv_Main.CurrentRow.Cells[0].Value;
                    string keyComponentsName = dgv_Main.CurrentRow.Cells[1].Value.ToString();
                    //提示
                    if (MessageBox.Show("是否要删除名称为：" + keyComponentsName + "的主要零部件", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Changeprobar(true);
                        Application.DoEvents();
                        using (XinYaDBEntities db = new XinYaDBEntities())
                        {
                            try
                            {
                                var a = db.TB_KeyComponentsInfo.Single(p => p.ID == id);
                                string temp=a.KeyComponentsName;
                                db.TB_KeyComponentsInfo.DeleteObject(a);
                                db.SaveChanges();
                                MessageBox.Show("删除成功！");
                                //删除成功后刷新一次数据
                                DataInit(null);
                                SystemLogHelper.WriteSysLogHelper("删除了一条关键零部件信息。名称:" + temp, user.ID, "关键零部件信息管理");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("删除出现异常，可能原因为待删除的数据在系统中被调用，详情请查看本地日志！");
                                LogExecute.WriteInfoLog("删除出现异常，可能原因为待删除的数据在系统中被调用。操作者："+user.UserName+"来源：关键零部件信息管理。+详情：" + ex.ToString());
                            }
                        }
                        Changeprobar(false);
                    }
                }
            }
        }

        /// <summary>
        /// 确认保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (lab_StatusTextBottom.Text == "就绪")
            {
                MessageBox.Show("仅支持在非就绪模式下进行保存更改功能");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_KeyComName.Text))
                {
                    MessageBox.Show("关键零部件名不能为空！");
                }
                else
                {
                    Changeprobar(true);
                    Application.DoEvents();
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        if (lab_StatusTextBottom.Text == "新增")
                        {
                            //新增
                            try
                            {
                                TB_KeyComponentsInfo a = new TB_KeyComponentsInfo();
                                a.KeyComponentsName = txt_KeyComName.Text;
                                a.AssistManufacturers = string.IsNullOrEmpty(txt_AssiteName.Text) ? "" : txt_AssiteName.Text;
                                a.Remark = string.IsNullOrEmpty(txt_Remark.Text) ? "" : txt_Remark.Text;
                                a.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                a.RecordDate = DateTime.Now;
                                db.TB_KeyComponentsInfo.AddObject(a);
                                db.SaveChanges();
                                MessageBox.Show("新增成功！");
                                SystemLogHelper.WriteSysLogHelper("新增了一条关键零部件信息。名称为：" + a.KeyComponentsName, user.ID, "关键零部件信息管理");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("新增出现异常！详情请查看本地日志！");
                                LogExecute.WriteInfoLog("新增出现异常，可能原因为待删除的数据在系统中被调用。操作者：" + user.UserName + "来源：关键零部件信息管理。+详情：" + ex.ToString());
                            }
                        }
                        else if (lab_StatusTextBottom.Text == "编辑")
                        {
                            try
                            {
                                int id = Convert.ToInt32(lab_ID.Text);
                                var a = db.TB_KeyComponentsInfo.Single(p => p.ID == id);
                                a.KeyComponentsName = txt_KeyComName.Text;
                                a.AssistManufacturers = string.IsNullOrEmpty(txt_AssiteName.Text) ? "" : txt_AssiteName.Text;
                                a.Remark = string.IsNullOrEmpty(txt_Remark.Text) ? "" : txt_Remark.Text;
                                a.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                a.RecordDate = DateTime.Now;
                                db.SaveChanges();
                                MessageBox.Show("编辑成功！");
                                SystemLogHelper.WriteSysLogHelper("编辑了一条关键零部件信息。名称为：" + a.KeyComponentsName, user.ID, "关键零部件信息管理");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("编辑出现异常！详情请查看日志！");
                                LogExecute.WriteInfoLog("编辑出现异常，可能原因为待删除的数据在系统中被调用。操作者：" + user.UserName + "来源：关键零部件信息管理。+详情：" + ex.ToString());
                            }
                        }
                    }
                    Changeprobar(false);
                }
            }
        }

        /// <summary>
        /// 清空文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            if (lab_StatusTextBottom.Text != "就绪")
            {
                TextClear();
            }
        }

        /// <summary>
        /// dgv单击事件，加载右侧详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lab_StatusTextBottom.Text == "就绪")
            {
                if (dgv_Main.CurrentRow != null && dgv_Main.CurrentRow.Cells[0].Value != null)
                {
                    lab_ID.Text = dgv_Main.CurrentRow.Cells[0].Value.ToString();
                    txt_KeyComName.Text = dgv_Main.CurrentRow.Cells[1].Value.ToString();
                    txt_AssiteName.Text = dgv_Main.CurrentRow.Cells[2].Value.ToString();
                    txt_Remark.Text = dgv_Main.CurrentRow.Cells[3].Value.ToString();
                    lab_Recorder.Text = dgv_Main.CurrentRow.Cells[4].FormattedValue.ToString();
                    lab_RecordDate.Text = dgv_Main.CurrentRow.Cells[5].Value.ToString();
                }
            }
        }
    }
}
