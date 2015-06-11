using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYaProcessManageSystem.BLL;

namespace XinYaProcessManageSystem
{
    public partial class frm_Login : Form
    {
        #region 字段属性



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
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        TB_User user = db.TB_User.Single(p => p.UserID == txt_UserID.Text && p.Password == txt_Password.Text);
                        //检查是否被禁用
                        if (user.IsUse != true)
                        {
                            MessageBox.Show("该账户已经被禁用！请联系管理员进行解锁操作！");
                        }
                        else
                        {
                            //对于上位程序，必须是管理员才有权限
                            //此为上位程序
                            if (user.UserLevel != "管理员")
                            {
                                MessageBox.Show("该账户权限不足！");
                            }
                            else
                            {
                                #region 登录记录

                                //服务端登录记录
                                try
                                {
                                    TB_LoginRecord loginRecord = new TB_LoginRecord();
                                    loginRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                    loginRecord.ServicePosition = "鑫亚服务端PLC主控程序";
                                    loginRecord.LoginInTime = DateTime.Now;
                                    db.TB_LoginRecord.AddObject(loginRecord);
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    LogExecute.WriteInfoLog("服务端登录失败，详情" + ex.ToString(), false);
                                }

                                #endregion
                                this.Hide();
                                frm_Main frmMain = new frm_Main(user);
                                frmMain.Show();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("登录失败！请检查用户名或密码是否输入正确！");
                    }

                }
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
