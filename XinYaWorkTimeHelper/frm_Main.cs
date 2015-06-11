using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace XinYaWorkTimeHelper
{
    public partial class frm_Main : Form
    {
        #region 字段属性
        TB_User user;

        List<TB_SecondWorkStationInfo> list_secondWorkStation = new List<TB_SecondWorkStationInfo>();

        ServiceReference1.Service1Client serClient = new ServiceReference1.Service1Client(); 

        /// <summary>
        /// 绑定类别，磨合或包装？
        /// </summary>
        string BandingType = "";//System.Configuration.ConfigurationSettings.AppSettings["绑定线段"];

        /// <summary>
        /// xml配置文件路径
        /// </summary>
        string xmlPath = Properties.Settings.Default.XmlPath;

        #endregion

        public frm_Main(TB_User user)
        {
            InitializeComponent();

            try
            {
                //实际
                BandingType = XMLHelper.ReadXML(xmlPath, "XinYa", "绑定线段");
              
            }
            catch (Exception)
            {
                MessageBox.Show("检测到配置文件出错，程序即将关闭，请联系管理员解决问题。");
                Application.Exit();
            }

            //同步系统时间
            UpdateSystemTime();
            this.user = user;
            this.lab_Xianduan.Text = BandingType;
            this.lab_Time.Text = DateTime.Now.ToLongDateString();
            this.lab_UserName.Text = user.UserName;
            this.dgv_Banding.AutoGenerateColumns = false;
            DataInit();
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        public void UpdateSystemTime()
        {
            try
            {
                UpdateTime.SetSysTime(serClient.GetTimeNow());
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("更新本机时间", ex);
            }
        }

        #region 窗体事件

        /// <summary>
        /// 系统退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu102_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定退出么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int flag = serClient.LoginHelpForLoginOut(user.ID, 0, "工时辅助程序");
                switch (flag)
                {
                    case 1:
                    case 4:
                    case 5:
                        LogExecute.WriteInfoLog("员工" + user.UserID + "登出记录失败", false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog("退出记录失败,详情" + ex.ToString(), false);
            }
            Application.Exit();
        }

        /// <summary>
        /// 通讯测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu101_Click(object sender, EventArgs e)
        {
            try
            {
                Ping p = new Ping();
                PingReply pr = p.Send(System.Configuration.ConfigurationSettings.AppSettings["ServerIP"]);
                if (pr.Status == IPStatus.Success)
                {
                    MessageBox.Show("Ping 服务器 成功！");
                }
                else
                {
                    MessageBox.Show("Ping 服务器 失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，这可能是损坏的配置文件引起的。详情请查看本地日志。");
                LogExecute.WriteExceptionLog("ping服务器", ex);
            }

        }

        /// <summary>
        /// 帮助说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu202_Click(object sender, EventArgs e)
        {
            frm_Helper helper = new frm_Helper();
            helper.ShowDialog();
        }

        #endregion

        #region 数据绑定与加载

        /// <summary>
        /// 表格数据初始
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    if (BandingType == "磨合段")
                    {
                        //如果是绑定的磨合段
                        list_secondWorkStation = db.TB_SecondWorkStationInfo.Where(p => p.WorkStationCode == "B").ToList();
                    }
                    else if (BandingType == "包装段")
                    {
                        //如果是绑定的包装段
                        list_secondWorkStation = db.TB_SecondWorkStationInfo.Where(p => p.WorkStationCode == "G" || p.WorkStationCode == "H" || p.WorkStationCode == "I" || p.WorkStationCode == "J" || p.WorkStationCode == "K" || p.WorkStationCode == "L" || p.WorkStationCode == "M" || p.WorkStationCode == "N" || p.WorkStationCode == "O" || p.WorkStationCode == "P").ToList();
                    }
                    else
                    {
                        MessageBox.Show("系统出现异常，这可能是损坏的配置文件引起的。详情请查看本地日志。");
                        LogExecute.WriteLineDataLog("数据初始化,错误的配置文件");
                    }
                    dgv_Banding.DataSource = list_secondWorkStation;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据初始化异常。详情请查看本地日志。");
                    LogExecute.WriteExceptionLog("数据初始化", ex);
                }
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Banding_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确保数据输入无误后再进行操作。是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgv_Banding.DataSource == null || dgv_Banding.RowCount <= 1)
                {
                    MessageBox.Show("没有可以用来绑定的数据！");
                }
                else
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        //循环遍历每一行
                        foreach (DataGridViewRow item in dgv_Banding.Rows)
                        {
                            try
                            {
                                if (item.Cells[2].Value != null)
                                {
                                    string a = item.Cells[2].Value.ToString();
                                    var b = db.TB_User.Single(p => p.UserID == a);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("未找到工号为" + item.Cells[2].Value.ToString() + "的员工，程序未进行绑定。请确保输入无误后再进行操作。");
                                return;
                            }
                        }
                    }
                    string i = "";
                    string j = "";
                    //循环遍历每一行
                    foreach (DataGridViewRow item in dgv_Banding.Rows)
                    {
                        try
                        {
                            if (item.Cells[2].Value != null)
                            {
                                if (serClient.WorkTimeBanding((int)item.Cells[0].Value, item.Cells[2].Value.ToString(), user.ID))
                                {
                                    i += item.Cells[2].Value.ToString() + ";";
                                }
                                else
                                {
                                    j += item.Cells[2].Value.ToString() + ";";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogExecute.WriteLineDataLog(ex.ToString());
                            MessageBox.Show("网络故障，未能与服务器通讯！");
                            return;
                        }
                    }
                    MessageBox.Show("操作完成，成功" + i + "," + "失败" + j);
                    LogExecute.WriteLineDataLog("操作完成，成功" + i + "失败" + j + "失败原因可能为当前系统中没有该工号的员工，或绑定了没有工作数据的工位");
                }
            }
        }

        #endregion

    }
}
