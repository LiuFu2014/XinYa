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
    public partial class frm_ExceptionInfo : Form
    {

        #region 字段属性

        List<TB_Exception> exception;// = new List<TB_Exception>();

        TB_User user;

        #endregion

        public frm_ExceptionInfo(TB_User user)
        {
            InitializeComponent();

            dgv_ExceptionInfo.AutoGenerateColumns = false;

            #region 配色

            tool_Main.BackColor = Color.WhiteSmoke;
            p_Part2.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            statu_Main.BackColor = Color.FromArgb(0x41, 0x41, 0x52);

            #endregion

            //数据初始化
            this.user = user;
            dgv_ExceptionInfoInit();
            //dgv_ExceptionInfo.Enabled = false;
        }

        /// <summary>
        /// dgv数据Init(包括异常数据加载)
        /// </summary>
        public void dgv_ExceptionInfoInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //刷新异常数据
                    exception = db.TB_Exception.ToList();
                    foreach (var item in exception)
                    {
                        item.TB_UserReference.Load();
                    }
                    dgv_ExceptionInfo.DataSource = exception;
                }
                catch { }
            }
        }

        /// <summary>
        /// 加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ExceptionInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_ExceptionInfo.Rows[e.RowIndex].DataBoundItem != null) && (dgv_ExceptionInfo.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_ExceptionInfo.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_ExceptionInfo.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 单击事件（加载右侧数据）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ExceptionInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txt_ExceptionCode.Text = dgv_ExceptionInfo.CurrentRow.Cells["c_ExceptionCode"].Value.ToString();
            //txt_ExceptionDtl.Text = dgv_ExceptionInfo.CurrentRow.Cells["c_ExceptionDtl"].Value.ToString();
            //lab_Creator.Text = dgv_ExceptionInfo.CurrentRow.Cells["c_Creator"].Value.ToString();
            //lab_CreateTime.Text = dgv_ExceptionInfo.CurrentRow.Cells["c_CreateDate"].Value.ToString();
            //txt_Remark.Text = dgv_ExceptionInfo.CurrentRow.Cells["c_Remark"].Value.ToString();
            if (dgv_ExceptionInfo.CurrentRow!=null)
            {
                TB_Exception ex = exception.First(p => p.ID.ToString() == dgv_ExceptionInfo.CurrentRow.Cells["c_ID"].Value.ToString());
                txt_ExceptionCode.Text = ex.ExceptionCode;
                txt_ExceptionDtl.Text = ex.ExceptionText;
                txt_Remark.Text = ex.Remark;
                lab_Creator.Text = ex.TB_User.UserName;
                lab_CreateTime.Text = ex.CreateDate.ToString();

            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            lab_Statustext.Text = "数据加载中...";
            Application.DoEvents();
            dgv_ExceptionInfoInit();
            lab_Statustext.Text = "就绪";
            Changeprobar(false);
        }

        /// <summary>
        /// 新增模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //将取消新增可见
            btn_AddCancel.Visible = true;
            //其他不可见
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            btn_EditCancel.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            btn_ImportExcel.Visible = false;
            //清空
            txt_ExceptionCode.Text = "";
            txt_ExceptionDtl.Text = "";
            txt_Remark.Text = "";
            lab_Creator.Text = "";
            lab_CreateTime.Text = "";
            //可写
            txt_ExceptionCode.ReadOnly = false;
            txt_ExceptionDtl.ReadOnly = false;
            txt_Remark.ReadOnly = false;
            //将dgv设置为不可用
            dgv_ExceptionInfo.Enabled = false;
            lab_Statustext.Text = "新增模式";

        }

        /// <summary>
        /// 取消新增模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddCancel_Click(object sender, EventArgs e)
        {
            //正常模式
            btn_Add.Visible = true;
            btn_AddCancel.Visible = false;
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_EditCancel.Visible = false;
            btn_Refresh.Visible = true;
            btn_ImportExcel.Visible = true;
            lab_Statustext.Text = "就绪";
            //清空
            txt_ExceptionCode.Text = "";
            txt_ExceptionDtl.Text = "";
            txt_Remark.Text = "";
            lab_Creator.Text = "";
            lab_CreateTime.Text = "";

            //不可写
            txt_ExceptionCode.ReadOnly = true;
            txt_ExceptionDtl.ReadOnly = true;
            txt_Remark.ReadOnly = true;
            //将dgv设置为可用
            dgv_ExceptionInfo.Enabled = true;

        }

        /// <summary>
        /// 编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //将取消新增可见
            btn_EditCancel.Visible = true;
            //其他不可见
            btn_Delete.Visible = false;
            btn_Add.Visible = false;
            btn_AddCancel.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            //可写
            txt_ExceptionCode.ReadOnly = false;
            txt_ExceptionDtl.ReadOnly = false;
            txt_Remark.ReadOnly = false;

            //将dgv设置为不可用
            dgv_ExceptionInfo.Enabled = false;
            lab_Statustext.Text = "编辑模式";
        }

        /// <summary>
        /// 取消编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditCancel_Click(object sender, EventArgs e)
        {
            //正常模式
            btn_Add.Visible = true;
            btn_AddCancel.Visible = false;
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_EditCancel.Visible = false;
            btn_Refresh.Visible = true;
            btn_ImportExcel.Visible = true;
            lab_Statustext.Text = "就绪";
            //不可写
            txt_ExceptionCode.ReadOnly = true;
            txt_ExceptionDtl.ReadOnly = true;
            txt_Remark.ReadOnly = true;
            //dgv可用
            dgv_ExceptionInfo.Enabled = true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            lab_Statustext.Text = "删除模式";
            Application.DoEvents();
            if (MessageBox.Show("当前选中信息删除后无法恢复，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgv_ExceptionInfo.CurrentRow != null)
                {
                    int ID = Convert.ToInt32(dgv_ExceptionInfo.CurrentRow.Cells["c_ID"].Value.ToString());
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        TB_Exception ex = db.TB_Exception.First(p => p.ID == ID);
                        try
                        {
                            string code = ex.ExceptionCode;
                            db.TB_Exception.DeleteObject(ex);
                            db.SaveChanges();
                            MessageBox.Show("删除成功！");
                            SystemLogHelper.WriteSysLogHelper("删除了一条故障代码，编码为" + code, user.ID, "故障代码管理");
                        }
                        catch (Exception)//考虑到外键关联
                        {
                            MessageBox.Show("当前数据被其他数据引用，无法级联删除！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("当前没有选中任何行！");
                }
            }
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 指定代码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (lab_Statustext.Text == "就绪")
            {
                if (txt_Ser.Text != "")
                {
                    if (exception != null)
                    {
                        try
                        {
                            TB_Exception ex = exception.First(p => p.ExceptionCode == txt_Ser.Text);
                            txt_ExceptionCode.Text = ex.ExceptionCode;
                            txt_ExceptionDtl.Text = ex.ExceptionText;
                            txt_Remark.Text = ex.Remark;
                            lab_Creator.Text = ex.TB_User.UserName;
                            lab_CreateTime.Text = ex.CreateDate.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("系统没有找到该故障码对应的数据！");
                        }
                    }
                    else //这个基本上不会命中
                    {
                        using (XinYaDBEntities db=new XinYaDBEntities())
                        {
                            try
                            {
                                TB_Exception ex = db.TB_Exception.First(p => p.ExceptionCode == txt_Ser.Text);
                                txt_ExceptionCode.Text = ex.ExceptionCode;
                                txt_ExceptionDtl.Text = ex.ExceptionText;
                                txt_Remark.Text = ex.Remark;
                                lab_Creator.Text = ex.TB_User.UserName;
                                lab_CreateTime.Text = ex.CreateDate.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("系统没有找到该故障码对应的数据！");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先输入故障代码！");
                }
            }
            else
            {
                MessageBox.Show("请在就绪状态下进行指定代码查询操作。");
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (lab_Statustext.Text!= "就绪")
            {
                if (lab_Statustext.Text=="新增模式")
                {
                    if (string.IsNullOrEmpty(txt_ExceptionCode.Text.Trim()) || string.IsNullOrEmpty(txt_ExceptionDtl.Text.Trim()))
                    {
                        MessageBox.Show("故障代码或者描述不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db=new XinYaDBEntities())
                        {
                            try
                            {
                                var a = db.TB_Exception.Single(p => p.ExceptionCode == txt_ExceptionCode.Text);
                                MessageBox.Show("该故障代码已经存在！");
                                db.Dispose();
                                return;
                            }
                            catch (Exception)
                            {
                              //...
                            }
                            try
                            {
                                TB_Exception ex = new TB_Exception();
                                ex.ExceptionCode = txt_ExceptionCode.Text;
                                ex.ExceptionText = txt_ExceptionDtl.Text;
                                ex.TB_User = db.TB_User.First(p => p.ID == user.ID);
                                ex.CreateDate = System.DateTime.Now;
                                ex.Remark = txt_Remark.Text;
                                db.TB_Exception.AddObject(ex);
                                int i=db.SaveChanges();//这个是返回的影响行数
                                MessageBox.Show("新增成功！");
                                //int j = ex.ID;//直接这样就可以取到保存后的ID值
                                SystemLogHelper.WriteSysLogHelper("新增了一条故障代码，编码为" + ex.ExceptionCode, user.ID, "故障代码管理");
                            }
                            catch
                            {
                                MessageBox.Show("新增故障码数据失败！请检查网络是否畅通！");
                            }
                        }
                    }
                }
                if (lab_Statustext.Text=="编辑模式")
                {
                    if (string.IsNullOrEmpty(txt_ExceptionCode.Text.Trim()) || string.IsNullOrEmpty(txt_ExceptionDtl.Text.Trim()))
                    {
                        MessageBox.Show("故障代码或者描述不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db=new XinYaDBEntities())
                        {
                            try
                            {
                                 var ex = db.TB_Exception.Single(p => p.ExceptionCode == txt_ExceptionCode.Text);
                                 ex.ExceptionCode = txt_ExceptionCode.Text;
                                 ex.ExceptionText = txt_ExceptionDtl.Text;
                                 ex.TB_User = db.TB_User.First(p => p.ID == user.ID);
                                 ex.CreateDate = System.DateTime.Now;
                                 ex.Remark = txt_Remark.Text;
                                 db.SaveChanges();
                                 MessageBox.Show("更新成功！");
                                 SystemLogHelper.WriteSysLogHelper("修改了一条故障代码，编码为" + ex.ExceptionCode, user.ID, "故障代码管理");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("更新故障码数据失败！网络故障或者当前没有可编辑的数据！");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_ExceptionInfo.RowCount <= 0 || dgv_ExceptionInfo.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_ExceptionInfo) == 0)
                {
                    MessageBox.Show("导出成功！");
                    SystemLogHelper.WriteSysLogHelper("导出了故障代码数据", user.ID, "故障代码管理");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

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
    }
}
