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

namespace XinYa.UI.User
{
    public partial class frm_ERPUserInfo : Form
    {
        TB_User user;
        public frm_ERPUserInfo(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            DataInit();
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        public void DataInit()
        {
            if (user != null)
            {
                lab_Name.Text = user.UserName;
                lab_Password.Text = user.Password;
                lab_UserRight.Text = user.UserLevel;
                lab_WorkNum.Text = user.UserID;
            }
        }

        /// <summary>
        /// 保存更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Name.Text)&&!string.IsNullOrEmpty(txt_WorkNum.Text)&&!string.IsNullOrEmpty(txt_WorkNumAgain.Text))
            {
                if (txt_WorkNum.Text==txt_WorkNumAgain.Text)
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            var erp = db.TB_User.First(p => p.UserLevel == "ERP");
                            erp.UserName = txt_Name.Text;
                            erp.Password = txt_WorkNumAgain.Text;
                            db.SaveChanges();
                            //再次刷新一次
                            DataInit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存更新出现问题，详情请查看日志！");
                            SystemLogHelper.WriteSysLogHelper("保存更新出现问题，详情：" + ex.ToString(), user.ID, "更新ERP专有账户信息");
                        }
                    }  
                }
            }
        }

    }
}
