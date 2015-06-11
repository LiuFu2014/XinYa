using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace XinYaECS
{
    public partial class frm_Login : Form
    {
        #region 字段属性

        ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();

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
                //            if (user.UserLevel != "管理员")
                //            {
                //                MessageBox.Show("该账户权限不足！");
                //            }
                //            else
                //            {
                //                this.Hide();
                //                frm_ECSMain frmMain = new frm_ECSMain(user);
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

                #region 更新版

                try
                {
                    int flag = ser.LoginHelpForService(txt_UserID.Text, txt_Password.Text, "ECS监控");
                    switch (flag)
                    {
                        case 0:
                            MessageBox.Show("该账户已经被禁用，登录失败。");
                            break;
                        case 1:
                            MessageBox.Show("该账户已经权限不足，登录失败。");
                            break;
                        case 2:
                            using (XinYaDBEntities db = new XinYaDBEntities())
                            {
                                try
                                {
                                    TB_User user = db.TB_User.Single(p => p.UserID == txt_UserID.Text && p.Password == txt_Password.Text);
                                    this.Hide();
                                    frm_ECSMain frmMain = new frm_ECSMain(user);
                                    frmMain.Show();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("登录失败，请查看日志！");
                                    LogExecute.WriteInfoLog("登录失败,详情：" + ex.ToString(), false);
                                }
                            }
                            break;
                        case 3:
                            MessageBox.Show("工号或密码不正确，登录失败。");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("与服务器通讯失败，服务器或没有开启服务。");
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