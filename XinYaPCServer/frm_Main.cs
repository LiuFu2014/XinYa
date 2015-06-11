using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACTETHERLib;
using System.Data.SqlClient;

namespace XinYaPCServer
{
    public partial class frm_Main : Form
    {
        #region 字段属性

        /// <summary>
        /// 连接打开是否成功标志
        /// </summary>
        bool flag = false;

        /// <summary>
        /// 运行时标志位，初始为true
        /// </summary>
        bool flagForRunning = true;

        List<TB_SecondWorkStationInfo> secondWorkStation;

        System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(XinYaWcfServiceForPLCAndWorks.Service1));

        /// <summary>
        /// 基础地址
        /// </summary>
        private List<TB_PLCBaseAdressInfo> list_plcAdress = null;

        /// <summary>
        /// 基础地址对应的访问PLC的字符串
        /// </summary>
        string strAddress = "";

        /// <summary>
        /// 基础地质对应的访问PLC的short数组
        /// </summary>
        short[] plcValue;

        //专有通信模块(公开，供向外提供接口时被引用)
        public ACTETHERLib.ActQJ71E71TCP MasterPLC = new ActQJ71E71TCP(); 
        #endregion

        public frm_Main()
        {
            InitializeComponent();
            DataInit();
            //PLC IP地址
            MasterPLC.ActHostAddress = System.Configuration.ConfigurationSettings.AppSettings["PLCAdress"];
            //主控时钟刷新频率
            timer1.Interval = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Timer"]);

        }

        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenPCServer_Click(object sender, EventArgs e)
        {
            if (MasterPLC.Open() != 0)
            {
                MessageBox.Show("打开失败");
                flag = false;
                lab_PCServerStatus.Text = "PC端服务处于关闭状态";
            }
            else
            {
                flag = true;
                lab_PCServerStatus.Text = "PC端服务处于开启状态";
            }

        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClosePCServer_Click(object sender, EventArgs e)
        {
            if (MasterPLC.Close() == 0)
            {
                flag = false;
                lab_PCServerStatus.Text = "PC端服务处于关闭状态";
            }
        }

        /// <summary>
        /// 获取所有工位地址
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    secondWorkStation = db.TB_SecondWorkStationInfo.ToList();
                    foreach (var item in secondWorkStation)
                    {
                        item.TB_PLCAdressWithWorkStationInfoReference.Load();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// 时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                //一旦运行时出现异常则中止服务，待到管理员解决异常后再进行处理
                if (flagForRunning)
                {
                    PLCAdressInit();
                }
                else
                {
                    lab_PCServerStatus.Text = DateTime.Now.ToString()+":与PLC的连接已经断开，服务停止，请解决故障后再重新打开服务";
                }
            }
        }

        /// <summary>
        /// PLC地址值读取(暂放内存)（这里将data由short转成了int）
        /// </summary>
        public void PLCAdressInit()
        {
            DateTime begin = DateTime.Now;
            //DateTime end1;
            //DateTime end2;
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //string strAddress = "";
                try
                {
                    //list_plcAdress = (from a in db.TB_PLCBaseAdressInfo
                    //                  select a).ToList();
                    //数据初始化，偷懒，写这里了。
                    if (list_plcAdress==null)
                    {
                        list_plcAdress = db.TB_PLCBaseAdressInfo.Where(p => p.SecondStationID != null).ToList();
                    }
                    if (strAddress=="")
                    {
                        for (int i = 0; i < list_plcAdress.Count; i++)
                        {
                            strAddress = string.Format("{0}\n{1}", strAddress, list_plcAdress[i].Adress);
                        }
                        //移除最开头的‘\n’
                        strAddress = strAddress.Trim('\n');
                    }
                    if (plcValue==null)
                    {
                        plcValue = new short[list_plcAdress.Count];
                    }
                }
                catch (Exception ex)
                {
                    //txt_Exception.AppendText("\n" + DateTime.Now + "PLC地址信息加载失败！");
                    LogExecute.WriteDBExceptionLog(ex);
                }
                //for (int i = 0; i < list_plcAdress.Count; i++)
                //{
                //    strAddress = string.Format("{0}\n{1}", strAddress, list_plcAdress[i].Adress);
                //}
                ////移除最开头的‘\n’
                //strAddress = strAddress.Trim('\n');
                //short[] plcValue = new short[list_plcAdress.Count];
                //用\n分割地址，count为读取地址数，out short为起始数组地址
                if (MasterPLC.ReadDeviceRandom2(strAddress, list_plcAdress.Count, out plcValue[0]) == 0)
                {
                    //表示运行正常
                    flagForRunning = true;
                    for (int i = 0; i < list_plcAdress.Count; i++)
                    {
                        list_plcAdress[i].Data = plcValue[i];
                        //label1.Text += plcValue[i].ToString();
                    }
                    //暂不对PLC地址值进行保存，经测试需要2到3s
                    SqlParameter[] parm = new SqlParameter[2];
                    for (int i = 0; i < list_plcAdress.Count; i++)
                    {
                        //db.UpdatePLCAdress(list_plcAdress[i].ID, plcValue[i].ToString());
                        parm[0] = new SqlParameter("@ID", list_plcAdress[i].ID);
                        parm[1] = new SqlParameter("@Data", list_plcAdress[i].Data);
                        int a = db.ExecuteStoreCommand("exec pro_UpdateTB_PLCBaseAdressInfo @ID,@Data", parm);
                    }
                    if (gb_PCServer.BackColor == Color.Red)
                    {
                        gb_PCServer.BackColor = Color.White;
                    }
                    DateTime end3 = DateTime.Now;
                    TimeSpan dt1 = end3 - begin;
                    //label1.Text = dt1.ToString();
                    // label2.Text = dt2.ToString();
                    lab_PCServerStatus.Text ="服务处理频率："+ dt1.ToString();
                }
                else
                {
                    //表示运行不正常
                    flagForRunning = false;
                    //list_plcAdress = null;
                    if (gb_PCServer.BackColor == Color.White)
                    {
                        gb_PCServer.BackColor = Color.Red;
                    }
                    lab_PCServerStatus.Text = "检测到与PLC连接断开。/r/n 处理中止。 /r/n 如果重新打开失败，请重启本程序。";
                }
            }
        }

        #region WCF服务开启与关闭

        /// <summary>
        /// 打开wcf服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenWCFServer_Click(object sender, EventArgs e)
        {
            //System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(XinYaWcfServiceForPLCAndWorks.Service1));
            try
            {
                //if (host == null)
                //{
                host = new System.ServiceModel.ServiceHost(typeof(XinYaWcfServiceForPLCAndWorks.Service1));
                //}
                host.Open();
                lab_WCFServerStatus.Text = "WCF服务已开启";
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog(ex.ToString());
            }
        }

        /// <summary>
        /// 关闭wcf服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CloseWCFServer_Click(object sender, EventArgs e)
        {
            //System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(XinYaWcfServiceForPLCAndWorks.Service1));
            try
            {
                host.Close();
                lab_WCFServerStatus.Text = "WCF服已关闭";
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog(ex.ToString());
            }
        }

        #endregion WCF服务开启与关闭

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
