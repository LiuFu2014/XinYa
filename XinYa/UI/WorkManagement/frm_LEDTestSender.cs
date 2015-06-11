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

namespace XinYa.UI.WorkManagement
{
    public partial class frm_LEDTestSender : Form
    {
        TB_User user;
        public frm_LEDTestSender(TB_User user)
        {
            InitializeComponent();
            this.user = user;
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LEDBaowen.Text))
            {
                MessageBox.Show("当前报文为空。");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //这里报文我始终只用一条数据来存所以这里只是牵涉到更新问题
                        var a = db.TB_LEDText.Single(p => p.ID == 1);
                        a.LEDText = txt_LEDBaowen.Text;
                        db.SaveChanges();
                        MessageBox.Show("发送成功！");
                        LogExecute.WriteInfoLog(DateTime.Now.ToString() + " 员工：" + user.UserName + "发送了通知：“" + txt_LEDBaowen.Text.ToString() + "”。", true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //这里报文我始终只用一条数据来存所以这里只是牵涉到更新问题
                    var a = db.TB_LEDText.Single(p => p.ID == 1);
                    a.LEDText = "";
                    db.SaveChanges();
                    MessageBox.Show("清空成功！");
                    LogExecute.WriteInfoLog(DateTime.Now.ToString() + " 员工：" + user.UserName + "清空了LED通知。", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("清空失败！详情请查看系统日志");
                    SystemLogHelper.WriteSysLogHelper("清空失败,详情：" + ex.ToString(), "LED报文发送");
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
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_LEDText.Single(p => p.ID == 1);
                    txt_LEDTextNow.Text = a.LEDText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刷新数据出现基于网络或配置文件的异常。请查看系统日志。");
                    SystemLogHelper.WriteSysLogHelper("刷新数据出现基于网络或配置文件的异常,详情：" + ex.ToString(), "LED报文发送");
                }
            }
        }
    }
}
