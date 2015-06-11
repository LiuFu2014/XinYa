using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace XinYaWorkTimeHelper
{
    public partial class frm_Login : Form
    {
        #region 字段属性

        ServiceReference1.Service1Client serverClient = new ServiceReference1.Service1Client();

        #endregion

        public frm_Login()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (txt_UserID.Text == null || txt_UserID.Text == "" || txt_Password.Text == null || txt_Password.Text == "")
            {
                MessageBox.Show("请输入用户名和密码！");
                txt_UserID.Focus();
            }
            else
            {
                #region 原版
                //using (XinYaDBEntities db = new XinYaDBEntities())
                //{
                //    try
                //    {
                //        TB_User user = db.TB_User.Single(p => p.UserID == txt_UserID.Text && p.Password == txt_Password.Text);
                //        //检查是否被禁用
                //        if (user.IsUse != true)
                //        {
                //            MessageBox.Show("该账户已经被禁用！请联系管理员进行解锁操作！");
                //        }
                //        else
                //        {
                //            //对于上位程序，必须是管理员才有权限
                //            //此为上位程序
                //            if (user.UserLevel != "管理员" && user.UserLevel != "班组长")
                //            {
                //                MessageBox.Show("该账户权限不足！");
                //            }
                //            else
                //            {
                //                this.Hide();
                //                frm_Main frmMain = new frm_Main(user);
                //                frmMain.Show();
                //            }
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        MessageBox.Show("登录失败！请检查用户名或密码是否输入正确！");
                //    }
                //} 
                #endregion

                #region 新版

                try
                {
                    int flag = serverClient.LoginHelpForWorkTimeHelp(txt_UserID.Text, txt_Password.Text);
                    switch (flag)
                    {
                        case 0:
                            MessageBox.Show("当前账户被禁用。");
                            break;
                        case 1:
                            MessageBox.Show("当前账户权限不足。");
                            break;
                        case 2:
                            using (XinYaDBEntities db = new XinYaDBEntities())
                            {
                                try
                                {
                                    TB_User user = db.TB_User.Single(p => p.UserID == txt_UserID.Text && p.Password == txt_Password.Text);
                                    this.Hide();
                                    frm_Main frmMain = new frm_Main(user);
                                    frmMain.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("登录失败！详情请查看本地日志。");
                                    LogExecute.WriteInfoLog("用户" + txt_UserID.Text + "登录失败，详情：" + ex.ToString(), false);
                                }
                            }
                            break;
                        case 3:
                            MessageBox.Show("员工账号或密码不正确。");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("与服务器通讯失败，服务器或没有开启服务。");
                    LogExecute.WriteExceptionLog("与服务器通讯", ex);
                }

                #endregion
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
