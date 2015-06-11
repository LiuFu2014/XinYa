using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XinYaPCClientForAutoLoading
{
    public partial class frm_Login : Form
    {
        #region 字段属性

        int secID =0;//Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationID"]);
        ServiceReference1.Service1Client serverClient = new ServiceReference1.Service1Client();
        string xmlPath = Properties.Settings.Default.XmlPath;

        #endregion

        public frm_Login()
        {
            InitializeComponent();
            try
            {
                secID = Convert.ToInt32(XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationID"));
            }
            catch (Exception)
            {
                MessageBox.Show("检测到配置文件出错，程序即将关闭，请联系管理员解决问题。");
                Application.Exit();
            }
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
                p_probar.Visible = true;
                Application.DoEvents();

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
                //            //此为下位机程序
                //            //管理员可以直接登录
                //            if (user.UserLevel == "管理员")
                //            {
                //                this.Hide();
                //                frm_Main frmMain = new frm_Main(user);
                //                frmMain.Show();
                //            }
                //            else
                //            {
                //                //检查登录权限,遍历匹配
                //                user.TB_UserLoginRight.Load();
                //                int flag = 0;
                //                foreach (var item in user.TB_UserLoginRight)
                //                {
                //                    //如果有,而且被启用
                //                    if (item.TB_SecondWorkStationInfo.ID == secID && item.IsUse == true)
                //                    {
                //                        flag = 1;
                //                        frm_Main frmMain = new frm_Main(user);
                //                        frmMain.Show();
                //                        this.Hide();
                //                    }
                //                }
                //                if (flag == 0)
                //                {
                //                    MessageBox.Show("您没有登录这个工位的权限。请联系管理员授予登录权限！");
                //                }
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
                    int flag = serverClient.LoginHelpForPCClient(txt_UserID.Text, txt_Password.Text, secID);
                    switch (flag)
                    {
                        case 0:
                            MessageBox.Show("当前账户被禁用。");
                            break;
                        case 1:
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
                            MessageBox.Show("员工权限不足");
                            break;
                        case 4:
                            MessageBox.Show("员工账号或密码不正确。");
                            break;
                        case 5:
                            MessageBox.Show("该工位已被禁用。");
                            break;
                        case 6:
                            MessageBox.Show("检测到客户端的配置文件出错，请联系管理员检查配置文件。");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("与服务器通讯失败，服务器或没有开启服务。");
                    LogExecute.WriteExceptionLog("与服务器通讯", ex);
                }

                #endregion

                p_probar.Visible = false;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
