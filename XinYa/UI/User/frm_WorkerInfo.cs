using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;

namespace XinYa.UI.User
{
    public partial class frm_WorkerInfo : Form
    {
        BllHelp billHelp = new BllHelp();
        List<TB_User> list_User;
        TB_User user;

        public frm_WorkerInfo(TB_User user)
        {
            InitializeComponent();
            tool_Main.BackColor = Color.WhiteSmoke;
            p_Part2.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            //statu_Main.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.user = user;
            Init();
            //不可用
            txt_UserName.ReadOnly = true;
            txt_WorkerNumber.ReadOnly = true;
            txt_Password.ReadOnly = true;
            txt_Department.ReadOnly = true;
            txt_Phone.ReadOnly = true;
            txt_Address.ReadOnly = true;
            txt_Remark.ReadOnly = true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.dgv_Main.AutoGenerateColumns = false;
            try
            {
                list_User = billHelp.GetAllUser();
                this.dgv_Main.DataSource = list_User;
            }
            catch (Exception)
            {
                MessageBox.Show("加载数据失败！");
            }

        }

        /// <summary>
        /// 初始化，用户名
        /// </summary>
        /// <param name="userName"></param>
        public void Init(string userName)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_User = db.TB_User.Where(p => p.UserID == user.UserID&&user.UserLevel!="ERP").ToList();
                    dgv_Main.DataSource = list_User;
                }
                catch (Exception)
                {
                    MessageBox.Show("加载数据失败！");
                }
            }
        }

        /// <summary>
        /// datagrid加载复杂类
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
        /// 新增模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //新增模式下dgv不可用
            dgv_Main.Enabled = false;

            //将取消新增可见
            //保存可见
            btn_AddCancel.Visible = true;
            btn_Save.Visible = true;
            //其他不可见
            btn_Add.Visible = false;
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            btn_EditCancel.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            btn_Exit.Visible = false;
            //...

            //可用
            //foreach (var item in splitContainer1.Panel2.Controls)
            //{
            //    if (item is System.Windows.Forms.TextBox)
            //    {
            //        TextBox txt = (TextBox)item;
            //        txt.ReadOnly = false;
            //    }
            //}
            txt_UserName.ReadOnly = false;
            txt_WorkerNumber.ReadOnly = false;
            txt_Password.ReadOnly = false;
            txt_Department.ReadOnly = false;
            txt_Phone.ReadOnly = false;
            txt_Address.ReadOnly = false;
            txt_Remark.ReadOnly = false;
            //cb_Gender.Enabled = true;
            //cb_UserCode.Enabled = true;
            //新增模式下下拉框控件值
            cb_UserCode.Items.Clear();
            cb_Gender.Items.Clear();
            cb_Gender.Items.Add("男");
            cb_Gender.Items.Add("女");
            cb_UserCode.Items.Add("管理员");
            cb_UserCode.Items.Add("员工");
            cb_UserCode.Items.Add("班组长");
            cb_UserCode.SelectedIndex = 0;
            cb_Gender.SelectedIndex = 0;

            //清空
            txt_UserName.Text = "";
            txt_WorkerNumber.Text = "";
            txt_Password.Text = "";
            txt_Department.Text = "";
            txt_Phone.Text = "";
            txt_Address.Text = "";
            txt_Remark.Text = "";

            lab_StatusText.Text = "新增模式";
        }

        /// <summary>
        /// 取消新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddCancel_Click(object sender, EventArgs e)
        {
            //取消新增将dgv变得可用
            dgv_Main.Enabled = true;

            //将取消新增不可见
            //保存不可见
            btn_AddCancel.Visible = false;
            btn_Save.Visible = false;
            //其他可见
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_EditCancel.Visible = false;
            btn_ImportExcel.Visible = true;
            btn_Refresh.Visible = true;
            btn_Exit.Visible = true;
            //...
            //不可用
            txt_UserName.ReadOnly = true;
            txt_WorkerNumber.ReadOnly = true;
            txt_Password.ReadOnly = true;
            txt_Department.ReadOnly = true;
            txt_Phone.ReadOnly = true;
            txt_Address.ReadOnly = true;
            txt_Remark.ReadOnly = true;
            //cb_Gender.Enabled = true;
            //cb_UserCode.Enabled = true;

            lab_StatusText.Text = "就绪";

        }

        /// <summary>
        /// 编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //将取消编辑可见
            //保存可见
            btn_EditCancel.Visible = true;
            btn_Save.Visible = true;
            //其他不可见
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Exit.Visible = false;
            btn_AddCancel.Visible = false;
            btn_Add.Visible = false;
            //编辑模式下工号不可改
            txt_WorkerNumber.ReadOnly = true;
            //...
            //可用
            txt_UserName.ReadOnly = false;
            txt_Password.ReadOnly = false;
            txt_Department.ReadOnly = false;
            txt_Phone.ReadOnly = false;
            txt_Address.ReadOnly = false;
            txt_Remark.ReadOnly = false;

            //编辑模式下下拉框控件值
            cb_UserCode.Items.Clear();
            cb_Gender.Items.Clear();
            cb_Gender.Items.Add("男");
            cb_Gender.Items.Add("女");
            cb_UserCode.Items.Add("管理员");
            cb_UserCode.Items.Add("员工");
            cb_UserCode.Items.Add("班组长");
            cb_UserCode.SelectedIndex = 0;
            cb_Gender.SelectedIndex = 0;


            lab_StatusText.Text = "编辑模式";

        }

        /// <summary>
        /// 取消编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditCancel_Click(object sender, EventArgs e)
        {
            //取消编辑
            txt_WorkerNumber.ReadOnly = false;

            //将取消编辑不可见
            //保存不可见
            btn_EditCancel.Visible = false;
            btn_Save.Visible = false;
            btn_AddCancel.Visible = false;
            //其他可见
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_ImportExcel.Visible = true;
            btn_Refresh.Visible = true;
            btn_Add.Visible = true;
            btn_Exit.Visible = true;

            //...
            //不可用
            txt_UserName.ReadOnly = true;
            txt_WorkerNumber.ReadOnly = true;
            txt_Password.ReadOnly = true;
            txt_Department.ReadOnly = true;
            txt_Phone.ReadOnly = true;
            txt_Address.ReadOnly = true;
            txt_Remark.ReadOnly = true;

            lab_StatusText.Text = "就绪";
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //先提示是否要删除
            if (MessageBox.Show("删除将不可恢复！是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (dgv_Main.CurrentRow != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        int id = (int)dgv_Main.CurrentRow.Cells["c_ID"].Value;
                        var a = db.TB_User.Single(p => p.ID == id);
                        string temp=a.UserID;
                        db.TB_User.DeleteObject(a);
                        db.SaveChanges();
                        MessageBox.Show("删除成功！");
                        SystemLogHelper.WriteSysLogHelper("删除了一条员工信息。工号：" + a, user.ID, "员工信息管理");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除失败！删除前请确保此用户在系统中已经没有其他关联数据存在！");
                    }
                }
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
            Init();
            Changeprobar(false);
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存主数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (lab_StatusText.Text != "就绪")
            {
                if (lab_StatusText.Text == "新增模式")
                {
                    if (string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrEmpty(txt_WorkerNumber.Text) || string.IsNullOrEmpty(txt_Password.Text))
                    {
                        MessageBox.Show("用户名，工号，密码不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db = new XinYaDBEntities())
                        {
                            //保证工号唯一
                            if (db.TB_User.Count(p => p.UserID == txt_WorkerNumber.Text) == 1)
                            {
                                MessageBox.Show("已经存在这个工号对应的数据,请保证工号唯一后再继续操作！");
                            }
                            else
                            {
                                try
                                {
                                    TB_User u = new TB_User();
                                    u.UserName = txt_UserName.Text;
                                    u.Password = txt_Password.Text;
                                    u.UserID = txt_WorkerNumber.Text;
                                    u.UserLevel = cb_UserCode.SelectedItem.ToString();
                                    u.Department = txt_Department.Text;
                                    u.PhoneNumber = txt_Phone.Text;
                                    u.Gender = cb_Gender.SelectedItem.ToString();
                                    u.HouseAddress = txt_Address.Text;
                                    u.IsUse = check_IsUse.Checked;
                                    u.Creator = user.UserName;
                                    u.CreateDate = System.DateTime.Now;
                                    u.Remark = txt_Remark.Text;
                                    db.TB_User.AddObject(u);
                                    db.SaveChanges();
                                    MessageBox.Show("新增成功！");
                                    SystemLogHelper.WriteSysLogHelper("新增了一条员工数据。员工工号;" + u.UserID, user.ID, "员工信息管理");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("新增失败！");
                                }
                            }
                        }
                    }
                }
                else if (lab_StatusText.Text == "编辑模式")
                {
                    if (dgv_Main.CurrentRow == null || string.IsNullOrEmpty(txt_UserName.Text) || string.IsNullOrEmpty(txt_WorkerNumber.Text) || string.IsNullOrEmpty(txt_Password.Text))
                    {
                        MessageBox.Show("用户名，工号，密码不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db = new XinYaDBEntities())
                        {
                            try
                            {
                                int id = (int)dgv_Main.CurrentRow.Cells["c_ID"].Value;
                                TB_User u = db.TB_User.Single(p => p.ID == id);
                                u.UserName = txt_UserName.Text;
                                u.Password = txt_Password.Text;
                                u.UserID = txt_WorkerNumber.Text;
                                u.UserLevel = cb_UserCode.SelectedItem.ToString();
                                u.Department = txt_Department.Text;
                                u.PhoneNumber = txt_Phone.Text;
                                u.Gender = cb_Gender.SelectedItem.ToString();
                                u.HouseAddress = txt_Address.Text;
                                u.IsUse = check_IsUse.Checked;
                                u.Creator = user.UserName;
                                u.CreateDate = System.DateTime.Now;
                                u.Remark = txt_Remark.Text;
                                db.SaveChanges();
                                MessageBox.Show("更新成功！");
                                SystemLogHelper.WriteSysLogHelper("更新了一条员工数据。员工工号;" + u.UserID, user.ID, "员工信息管理");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("更新失败！");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("当前处在就绪模式下，保存失效！");
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (lab_StatusText.Text != "就绪")
            {
                MessageBox.Show("查询只能在就绪模式下进行");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_Ser.Text))
                {
                    MessageBox.Show("请指定员工工号后再进行查询！");
                }
                else
                {
                    Init(txt_Ser.Text);
                }
            }
        }

        /// <summary>
        /// 单击事件加载用户详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Main.CurrentRow != null)
            {
                int id = (int)dgv_Main.CurrentRow.Cells["c_ID"].Value;
                TB_User u = list_User.Single(p => p.ID == id);
                txt_UserName.Text = u.UserName;
                txt_Password.Text = u.Password;
                txt_WorkerNumber.Text = u.UserID;
                //移除cb所有的值然后加载最新的值
                cb_UserCode.Items.Clear();
                cb_UserCode.Items.Add(u.UserLevel == null ? "" : u.UserLevel);
                cb_UserCode.SelectedIndex = 0;


                txt_Department.Text = u.Department;
                txt_Phone.Text = u.PhoneNumber;
                //移除cb所有的值然后加载最新的值
                cb_Gender.Items.Clear();
                cb_Gender.Items.Add(u.Gender == null ? "" : u.Gender);
                cb_Gender.SelectedIndex = 0;

                txt_Address.Text = u.HouseAddress;
                check_IsUse.Checked = u.IsUse;
                lab_Creator.Text = u.Creator;
                lab_CreateDate.Text = u.CreateDate.ToString();
                txt_Remark.Text = u.Remark;
            }
        }

        /// <summary>
        /// 员工数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.RowCount <= 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Main) == 0)
                {
                    MessageBox.Show("导出成功！");
                    SystemLogHelper.WriteSysLogHelper("导出了员工数据。员工工号;" + user.UserID, user.ID, "员工信息管理");
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
