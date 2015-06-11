using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.NetworkInformation;
using ACTETHERLib;

namespace XinYaECS
{
    public partial class frm_ECSMain : Form
    {
        #region 属性字段

        /// <summary>
        /// 服务客户端
        /// </summary>
        ServiceReference1.Service1Client sclient = new ServiceReference1.Service1Client();

        TB_User user;

        /// <summary>
        /// 定时器的时间间隔
        /// </summary>
        int timecount = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["timer"]);

        /// <summary>
        /// 工位信息
        /// </summary>
        List<TB_SecondWorkStationInfo> list_secondWorkStation;

        /// <summary>
        /// 阻挡器
        /// </summary>
        List<TB_PLCAdressWithStopper> list_stopper;

        /// <summary>
        /// 从服务端加载的实时地址
        /// </summary>
        List<TB_PLCBaseAdressInfo> plcAdress;

        string baozhuangduan = "SGSHSISJSKSLSMSNSOSP";

        /// <summary>
        /// 监控标志位，为true开启
        /// </summary>
        bool ECSFlag = true;

        /// <summary>
        /// LED标志位，为true开启
        /// </summary>
        bool LEDFlag = true;

        //专有通信模块(公开，供向外提供接口时被引用)
        /// <summary>
        /// 12月15号，监控数据不再从WCF服务端返回，本地直接调用（服务端传输量太大）
        /// </summary>
        public ACTETHERLib.ActQJ71E71TCP MasterPLC = new ActQJ71E71TCP();

        #endregion

        public frm_ECSMain(TB_User user)
        {
            InitializeComponent();
            //test();
            this.user = user;
            this.time_Dowork.Interval = timecount;
            this.dgv_MonthPlan.AutoGenerateColumns = false;
            //时间间隔加载
            this.time_Dowork.Interval = timecount;
            //底部状态栏
            toolStripStatusLabel1.Text = "操作员：" + user.UserName;
            toolStripStatusLabel2.Text = "日期：" + System.DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = "登录时间：" + System.DateTime.Now.ToLongTimeString();
            //PLC
            MasterPLC.ActHostAddress = System.Configuration.ConfigurationSettings.AppSettings["PLCAdress"];
            ECSFlag = false;
            lab_ECSIsUse.Text = "关闭";
            //将工位与阻挡器信息加载到内存
            DataInit();
        }

        /// <summary>
        /// 从服务端获取PLC地址信息
        /// </summary>
        public void GetPLCAdress()
        {
            //try
            //{
            //plcAdress = sclient.GetAllPLCAdressData();
            List<TB_PLCBaseAdressInfo> list_plcAdress = new List<TB_PLCBaseAdressInfo>();

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                string strAddress = "";
                try
                {
                    list_plcAdress = (from a in db.TB_PLCBaseAdressInfo
                                      select a).ToList();
                    for (int i = 0; i < list_plcAdress.Count; i++)
                    {
                        strAddress = string.Format("{0}\n{1}", strAddress, list_plcAdress[i].Adress);
                    }

                    //移除最开头的‘\n’
                    strAddress = strAddress.Trim('\n');
                    short[] plcValue = new short[list_plcAdress.Count];
                    //用\n分割地址，count为读取地址数，out short为起始数组地址
                    int b = MasterPLC.ReadDeviceRandom2(strAddress, list_plcAdress.Count, out plcValue[0]);
                    for (int i = 0; i < list_plcAdress.Count; i++)
                    {
                        list_plcAdress[i].Data = plcValue[i];
                        try//有些可能没有阻挡外键或工位外键
                        {
                            //加载完全
                            list_plcAdress[i].TB_PLCAdressWithStopperReference.Load();
                            list_plcAdress[i].TB_SecondWorkStationInfoReference.Load();
                            //10.17新加入
                            list_plcAdress[i].TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfoReference.Load();
                            //测试
                            //list_plcAdress.Remove(list_plcAdress[list_plcAdress.Count - i]);
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    list_plcAdress = null;
                    db.Dispose();
                }
            }
            plcAdress = list_plcAdress;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                list_secondWorkStation = db.TB_SecondWorkStationInfo.ToList();
                list_stopper = db.TB_PLCAdressWithStopper.ToList();
                foreach (var item in list_secondWorkStation)
                {
                    item.TB_PLCAdressWithWorkStationInfoReference.Load();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPLCAdress();
        }

        #region LED

        /// <summary>
        /// 报文发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LEDText.Text))
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
                        a.LEDText = txt_LEDText.Text;
                        db.SaveChanges();
                        MessageBox.Show("发送成功！");
                        LogExecute.WriteInfoLog(DateTime.Now.ToString() + " 员工：" + user.UserName + "清空了LED通知。", true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 清空报文
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
                catch (Exception)
                {
                    MessageBox.Show("清空失败！");
                }
            }
        }

        #endregion

        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Dowork_Tick(object sender, EventArgs e)
        {
            DateTime dt_begin = DateTime.Now;
            DateTime dt_begin1 = DateTime.Now;

            #region ECS
            if (ECSFlag)
            {
                dt_begin = DateTime.Now;
                //服务调用
                GetPLCAdress();
                dt_begin1 = DateTime.Now;
                if (plcAdress == null)
                {
                    //lab_StatusMohe.Text = "无数据返回，请确认服务端程序是否开启。";
                    //lab_StatusBaozhuang.Text = "无数据返回，请确认服务端程序是否开启。";
                    lab_StatusMohe.Text = "无数据返回，请确认是否打开了PLC连接。";
                    lab_StatusBaozhuang.Text = "无数据返回，请确认是否打开了PLC连接。";
                }
                else
                {
                    lab_StatusMohe.Text = "正常运行中...";
                    lab_StatusBaozhuang.Text = "正常运行中...";
                    int flag = 0;
                    foreach (var item in plcAdress)
                    {
                        if (item.TB_PLCAdressWithStopper == null && item.TB_SecondWorkStationInfo == null)
                        {
                            //既无对应工位信息或阻挡器信息
                            continue;
                        }

                        else if (item.TB_SecondWorkStationInfo == null)  //表示有阻挡器信息
                        {
                            #region 阻挡器

                            //先判断这个阻挡器所在的位置
                            //磨合段
                            if (item.TB_PLCAdressWithStopper.StopperCode == "B" || item.TB_PLCAdressWithStopper.StopperCode == "C" || item.TB_PLCAdressWithStopper.StopperCode == "D" || item.TB_PLCAdressWithStopper.StopperCode == "Z1")
                            {
                                //遍历磨合段的所有阻挡器
                                foreach (Control item2 in tlp_Mohe.Controls)
                                {
                                    //这里在基本PLC地址中，这个单位的所有地址都会指向这个单位，而实际上我们自要求按照托盘编码判断。
                                    //所以这个做个盘点，判定当前需要处理的数据是不是存储的托盘编码
                                    if (item.Adress == item.TB_PLCAdressWithStopper.PalletCode)
                                    {
                                        if (item2.Name == "lab_Z" + item.StopperID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (item.Data == 0)
                                            {
                                                if (ul.Backcolor == Color.Silver)
                                                {
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;//只会匹配一次，所以后续匹配是多余的
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Silver;
                                                    ul.ChangeColor(Color.Silver);
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (ul.Backcolor == Color.Green)
                                                {
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Green;
                                                    ul.ChangeColor(Color.Green);
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (item.TB_PLCAdressWithStopper.StopperCode == "Z2" || item.TB_PLCAdressWithStopper.StopperCode == "E" || item.TB_PLCAdressWithStopper.StopperCode == "F")
                            {
                                //遍历调试段的所有阻挡器
                                foreach (Control item2 in tlp_TiaoshiQC.Controls)
                                {
                                    if (item.Adress == item.TB_PLCAdressWithStopper.PalletCode)
                                    {
                                        if (item2.Name == "lab_Z" + item.StopperID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (item.Data == 0)
                                            {
                                                if (ul.Backcolor == Color.Silver)
                                                {
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;//只会匹配一次，所以后续匹配是多余的
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Silver;
                                                    ul.ChangeColor(Color.Silver);
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (ul.Backcolor == Color.Green)
                                                {
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Green;
                                                    ul.ChangeColor(Color.Green);
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            string baozhuang = "Z3GHIJKLMNOP";
                            if (baozhuang.Contains(item.TB_PLCAdressWithStopper.StopperCode))
                            {
                                //遍历安装段的所有阻挡器
                                foreach (Control item2 in tlp_Baozhuangduan.Controls)
                                {
                                    if (item.Adress == item.TB_PLCAdressWithStopper.PalletCode)
                                    {
                                        if (item2.Name == "lab_Z" + item.StopperID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (item.Data == 0)
                                            {
                                                if (ul.Backcolor == Color.Silver)
                                                {
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;//只会匹配一次，所以后续匹配是多余的
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Silver;
                                                    ul.ChangeColor(Color.Silver);
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (ul.Backcolor == Color.Green)
                                                {
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Green;
                                                    ul.ChangeColor(Color.Green);
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else  //表示有工位信息
                        {
                            #region  工位
                            //磨合
                            if (item.TB_SecondWorkStationInfo.WorkStationCode == "B" || item.TB_SecondWorkStationInfo.WorkStationCode == "C" || item.TB_SecondWorkStationInfo.WorkStationCode == "D")
                            {
                                //磨合段
                                //遍历磨合段的所有阻挡器
                                foreach (Control item2 in tlp_Mohe.Controls)
                                {
                                    //排除非托盘地址的干扰，磨合段只有一个地址存储托盘编码
                                    if (item.Adress == item.TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode)
                                    {
                                        if (item2.Name == "lab_G" + item.SecondStationID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (item.Data == 0)
                                            {
                                                if (ul.Backcolor == Color.SteelBlue)
                                                {
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;//只会匹配一次，所以后续匹配是多余的
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Silver;
                                                    ul.ChangeColor(Color.SteelBlue);
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (ul.Backcolor == Color.Green)
                                                {
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Green;
                                                    ul.ChangeColor(Color.Green);
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            #region 调试QC监控迁移

                            //调试QC
                            //if (item.TB_SecondWorkStationInfo.WorkStationCode == "E" || item.TB_SecondWorkStationInfo.WorkStationCode == "F")
                            //{
                            //    foreach (Control item2 in tlp_TiaoshiQC.Controls)
                            //    {
                            //        if (item2.Name == "lab_G" + item.SecondStationID)
                            //        {
                            //            user_Label ul = (user_Label)item2;
                            //            //试验台与QC台有两个存储托盘地址
                            //            //当其中一个有地址的时候，说明有盘，变绿色
                            //            if ((item.Adress == item.TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode && item.Data != 0) || (item.Adress == item.TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode2 && item.Data != 0))
                            //            {
                            //                flag++;//盘的数量
                            //                if (ul.Backcolor == Color.Green)
                            //                {
                            //                    //将这个托盘号记录到当前控件中
                            //                    ul.Tag = item.Data;
                            //                    break;
                            //                }
                            //                else
                            //                {
                            //                    //ul.Backcolor = Color.Green;
                            //                    ul.ChangeColor(Color.Green);
                            //                    //将这个托盘号记录到当前控件中
                            //                    ul.Tag = item.Data;
                            //                    break;
                            //                }
                            //            }
                            //            else//两个都没有
                            //            {
                            //                if (flag==0)//说明该工位没有盘
                            //                {
                            //                    if (ul.Backcolor == Color.SteelBlue)
                            //                    {
                            //                        //没有托盘数据就清空他
                            //                        ul.Tag = null;
                            //                        break;//只会匹配一次，所以后续匹配是多余的
                            //                    }
                            //                    else
                            //                    {
                            //                        //ul.Backcolor = Color.Silver;
                            //                        ul.ChangeColor(Color.SteelBlue);
                            //                        //没有托盘数据就清空他
                            //                        ul.Tag = null;
                            //                        break;
                            //                    }
                            //                }
                            //            }
                            //        }
                            //    }
                            //}

                            #endregion

                            string baozhuang = "GHIJKLMNOP";
                            if (baozhuang.Contains(item.TB_SecondWorkStationInfo.WorkStationCode))
                            {
                                foreach (Control item2 in tlp_Baozhuangduan.Controls)
                                {
                                    //包装段只有一个地址存储托盘编码
                                    if (item.Adress == item.TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode)
                                    {
                                        if (item2.Name == "lab_G" + item.SecondStationID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (item.Data == 0)
                                            {
                                                if (ul.Backcolor == Color.SteelBlue)
                                                {
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;//只会匹配一次，所以后续匹配是多余的
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Silver;
                                                    ul.ChangeColor(Color.SteelBlue);
                                                    //没有托盘数据就清空他
                                                    ul.Tag = null;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (ul.Backcolor == Color.Green)
                                                {
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                                else
                                                {
                                                    //ul.Backcolor = Color.Green;
                                                    ul.ChangeColor(Color.Green);
                                                    //将这个托盘号记录到当前控件中
                                                    ul.Tag = item.Data;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    #region 调试QCECS

                    foreach (var item in list_secondWorkStation)
                    {
                        if (item.WorkStationCode == "E" || item.WorkStationCode == "F")
                        {
                            //取对应地址
                            //List<ServiceReference1.TB_PLCBaseAdressInfo> plcadress = plcAdress.Where(p => p.SecondStationID == item.ID&&(p.Adress==item.TB_PLCAdressWithWorkStationInfo.PalletCode||p.Adress==item.TB_PLCAdressWithWorkStationInfo.PalletCode2)).ToList();
                            List<TB_PLCBaseAdressInfo> plcadress = plcAdress.Where(p => (p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode || p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode2)).ToList();
                            if (plcadress.Count > 2)
                            {
                                continue;
                            }
                            else
                            {
                                if (plcadress[0].Data != 0 || plcadress[1].Data != 0)//只要其中一个有盘
                                {
                                    foreach (Control item2 in tlp_TiaoshiQC.Controls)//找到这个标签
                                    {
                                        if (item2.Name == "lab_G" + item.ID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (ul.Backcolor == Color.Green)
                                            {
                                                //将这个托盘号记录到当前控件中
                                                if (plcadress[0].Data != 0)
                                                {
                                                    ul.Tag = plcadress[0].Data;
                                                }
                                                else
                                                {
                                                    ul.Tag = plcadress[1].Data;
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                ul.ChangeColor(Color.Green);
                                                //将这个托盘号记录到当前控件中
                                                if (plcadress[0].Data != 0)
                                                {
                                                    ul.Tag = plcadress[0].Data;
                                                }
                                                else
                                                {
                                                    ul.Tag = plcadress[1].Data;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }
                                else//表示两个没有盘
                                {
                                    foreach (Control item2 in tlp_TiaoshiQC.Controls)//找到这个标签
                                    {
                                        if (item2.Name == "lab_G" + item.ID)
                                        {
                                            user_Label ul = (user_Label)item2;
                                            if (ul.Backcolor == Color.SteelBlue)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                ul.ChangeColor(Color.SteelBlue);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                }
            }

            #endregion

            #region LED

            if (LEDFlag)
            {
                #region 原有月计划手动输入时的处理逻辑，已弃用（14.12.4）
                /*
                //实时统计产量信息
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //最外层循环为对计划表的遍历,条件为本月的计划
                    var monthplan = db.TB_MonthPlanForLED.ToList();
                    List<TB_MonthPlanForLED> list_monthplan = new List<TB_MonthPlanForLED>();
                    foreach (var item in monthplan)
                    {
                        if (item.Month.Month == DateTime.Now.Month)
                        {
                            list_monthplan.Add(item);
                        }
                    }
                    //获取所有任务数
                    var works = db.TB_WorkMain.ToList();
                    //遍历这些月计划
                    foreach (var plan in list_monthplan)
                    {
                        //今日投入数
                        int todayTotal = 0;
                        //今日包装总数
                        int todayCasingCount = 0;
                        //月度包装总数
                        int monthCasingCount = 0;
                        //加载完全
                        plan.TB_MaterialInfoReference.Load();
                        plan.TB_UserReference.Load();
                        //今日投入数也就是今日从悬挂链A处提交的任务的子任务数

                        //暂存
                        //List<TB_WorkMain> list_works = new List<TB_WorkMain>();
                        //筛选
                        foreach (var item in works)
                        {
                            //今日，提交了的
                            if (item.CreateDate.Date == DateTime.Today && item.IsCommit == true)// && item.TB_SecondWorkStationInfo.WorkStationCode == "A")
                            {
                                //该类型的今日总数
                                //todayTotal += item.TB_WorkDtl.Count(p => p.MaterialCode.Substring(0, 12) == plan.MaterialID);
                                //遍历这条任务的所有子任务
                                foreach (var item2 in item.TB_WorkDtl)
                                {
                                    //该种类型的没有异常的或则有异常但是是在包装段发生的
                                    if ((item2.TB_MaterialInfo.TypeCode == plan.MaterialID) && ((item2.IsException == false || (item2.IsException == true || baozhuangduan.Contains(item2.TB_SecondWorkStationInfo.SecondWorkStationCode)))))
                                    {
                                        todayTotal++;
                                    }
                                }
                            }

                            //今日，完成了的
                            if (item.CreateDate.Date == DateTime.Today && item.Finished == "1")
                            {
                                //加载这条主任务中无异常的且为该种类型的子任务
                                todayCasingCount += item.TB_WorkDtl.Count(p => p.IsException == false && p.MaterialCode.Substring(0, 12) == plan.MaterialID);
                            }

                            //本月，提交了的,完成了的，A工位的
                            if (item.CreateDate.Month == DateTime.Now.Month && item.Finished == "1" && item.IsCommit == true && item.TB_SecondWorkStationInfo.WorkStationCode == "A")
                            {
                                //加载这条主任务中无异常的且为该种类型的子任务
                                monthCasingCount += item.TB_WorkDtl.Count(p => p.IsException == false && p.MaterialCode.Substring(0, 12) == plan.MaterialID);
                            }
                        }

                        plan.TodayTotalCount = todayCasingCount;
                        plan.TodayCasingCount = todayCasingCount;
                        plan.MonthCasingCount = monthCasingCount;
                        db.SaveChanges();
                    }
                    //赋值完毕后，刷新预览表
                    dgv_MonthPlan.DataSource = list_monthplan;
                } 
                 * */
                #endregion

                #region ERP月计划统计

                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        List<TB_ProductionPlanFromERP> list_ProductionPlanERP = new List<TB_ProductionPlanFromERP>();
                        if (db.TB_ProductionPlanFromERP.Count() == 0)
                        {
                            lab_LEDPlanStatus.Text = "当前没有月度计划";
                        }
                        else
                        {
                            //加载所有的导入计划
                            var productionPlans = db.TB_ProductionPlanFromERP.ToList();
                            //遍历
                            foreach (var item in productionPlans)
                            {
                                //if (DateTime.Now.Month == item.PlanBeginTime.Month || DateTime.Now.Year == item.PlanBeginTime.Year || DateTime.Now.Year == item.PlanEndTime.Year || DateTime.Now.Month == item.PlanEndTime.Month)
                                if (DateTime.Now.Date.CompareTo(item.PlanBeginTime.Date) >= 0 && DateTime.Now.Date.CompareTo(item.PlanEndTime.Date) <= 0)
                                {
                                    //满足条件
                                    list_ProductionPlanERP.Add(item);
                                }
                            }
                        }
                        //先加载所有的LED中间显示表计划
                        var monthPlanForLEDs = db.TB_MonthPlanForLED.ToList();
                        //将筛选后的ERP计划新增加入到LED显示表中相同的则跳过
                        foreach (var item in list_ProductionPlanERP)
                        {
                            //如果有这个月计划的记录，而且是今日录入的,数量==0，则新增
                            if (monthPlanForLEDs.Count(p => p.TB_ProductionPlanFromERP.ID == item.ID && p.CreateDate.Date == DateTime.Now.Date) == 0)
                            {
                                TB_MonthPlanForLED monthPlanForLED = new TB_MonthPlanForLED();
                                monthPlanForLED.TB_ProductionPlanFromERP = db.TB_ProductionPlanFromERP.Single(p => p.ID == item.ID);
                                monthPlanForLED.MonthCasingCount = 0;
                                monthPlanForLED.Remark = "";
                                monthPlanForLED.TodayCasingCount = 0;
                                monthPlanForLED.TodayTotalCount = 0;
                                monthPlanForLED.CreateDate = DateTime.Now;
                                db.TB_MonthPlanForLED.AddObject(monthPlanForLED);
                                db.SaveChanges();
                            }
                        }
                        //LED统计显示
                        //筛选今日的需要统计的型号
                        List<TB_MonthPlanForLED> list_MonthPlanForLED = new List<TB_MonthPlanForLED>();
                        if (db.TB_MonthPlanForLED.Count() == 0)
                        {
                            lab_LEDPlanStatus.Text = "当前没有可供统计的计划";
                        }
                        else
                        {
                            //var monthPlanForLED = db.TB_MonthPlanForLED.ToList();
                            foreach (var item in monthPlanForLEDs)
                            {
                                if (item.CreateDate.Date == DateTime.Now.Date)
                                {
                                    list_MonthPlanForLED.Add(item);
                                }
                            }
                        }
                        //如果今日有需要统计的计划
                        if (list_MonthPlanForLED.Count > 0)
                        {
                            //提前获取主任务数，防止多次重复访问
                            List<TB_WorkMain> list_WorkMain_ForTodayTotal = new List<TB_WorkMain>();
                            List<TB_WorkMain> list_WorkMain_ForTodayCasingCount = new List<TB_WorkMain>();
                            List<TB_WorkMain> list_WorkMain_ForMonthCasingCout = new List<TB_WorkMain>();
                            var workMains = db.TB_WorkMain.ToList();
                            foreach (var item in workMains)
                            {
                                //今天的A工位上线的（装配）
                                if (item.CreateDate.Date == DateTime.Now.Date && item.TB_SecondWorkStationInfo.WorkStationCode == "A")
                                {
                                    list_WorkMain_ForTodayTotal.Add(item);
                                }
                                //今天的，完成了的
                                if (item.CreateDate.Date == DateTime.Now.Date && item.Finished == "1")
                                {
                                    list_WorkMain_ForTodayCasingCount.Add(item);
                                }
                                //本月的，完成了的
                                //if (item.CreateDate.Month == DateTime.Now.Month && item.CreateDate.Year == DateTime.Now.Year && item.Finished == "1")
                                //{
                                //    list_WorkMain_ForMonthCasingCout.Add(item);
                                //}
                                //上月26号到本月25号，均包含
                                if (DateTime.Now.Month - 1 != 0)
                                {
                                    if ((item.CreateDate.Year == DateTime.Now.Year && item.CreateDate.Month == DateTime.Now.Month - 1 && item.CreateDate.Day >= 26) || (item.CreateDate.Year == DateTime.Now.Year && item.CreateDate.Month == DateTime.Now.Month && item.CreateDate.Day <= 25))
                                    {
                                        list_WorkMain_ForMonthCasingCout.Add(item);
                                    }
                                }
                                else
                                {
                                    //==0表示是今年的1月
                                    if ((item.CreateDate.Year == DateTime.Now.Year - 1 && item.CreateDate.Month == 12 && item.CreateDate.Day >= 26) || (item.CreateDate.Year == DateTime.Now.Year && item.CreateDate.Month == DateTime.Now.Month && item.CreateDate.Day <= 25))
                                    {
                                        list_WorkMain_ForMonthCasingCout.Add(item);
                                    }
                                }
                            }

                            //有可被统计的数据
                            //对每一个进行统计分析，并更新进数据库
                            foreach (var item in list_MonthPlanForLED)
                            {
                                //今日投入数，定义为装配段完成数
                                int todayTotal = 0;
                                //今日包装总数，定义为今日完成的数
                                int todayCasingCount = 0;
                                //月度包装总数，这个月的包装完成了的
                                int monthCasingCount = 0;
                                //日投入
                                foreach (var item2 in list_WorkMain_ForTodayTotal)
                                {
                                    if (item2.TB_WorkDtl.Count > 0)
                                    {
                                        //找出这种类型的任务
                                        if (item2.TB_WorkDtl.ToList()[0].MaterialID == item.TB_ProductionPlanFromERP.TB_MaterialInfo.TypeCode)
                                        {
                                            //加载
                                            //todayTotal += item2.TB_WorkDtl.Count(p => p.IsException == false);
                                            //日投应包括出现了异常的
                                            todayTotal += item2.TB_WorkDtl.Count();
                                        }
                                    }
                                }
                                //今日包装数
                                foreach (var item2 in list_WorkMain_ForTodayCasingCount)
                                {
                                    if (item2.TB_WorkDtl.Count > 0)
                                    {
                                        //找出这种类型的任务
                                        if (item2.TB_WorkDtl.ToList()[0].MaterialID == item.TB_ProductionPlanFromERP.TB_MaterialInfo.TypeCode)
                                        {
                                            //加载
                                            todayCasingCount += item2.TB_WorkDtl.Count(p => p.IsException == false);
                                        }
                                    }
                                }
                                //月统计
                                foreach (var item2 in list_WorkMain_ForMonthCasingCout)
                                {
                                    if (item2.TB_WorkDtl.Count > 0)
                                    {
                                        //找出这种类型的任务
                                        if (item2.TB_WorkDtl.ToList()[0].MaterialID == item.TB_ProductionPlanFromERP.TB_MaterialInfo.TypeCode)
                                        {
                                            //加载
                                            monthCasingCount += item2.TB_WorkDtl.Count(p => p.IsException == false);
                                        }
                                    }
                                }
                                item.TodayCasingCount = todayCasingCount;
                                item.TodayTotalCount = todayTotal;
                                item.MonthCasingCount = monthCasingCount;
                                db.SaveChanges();
                            }
                        }

                        //不管怎样，加载到dgv显示
                        //先加载完全
                        foreach (var item in list_MonthPlanForLED)
                        {
                            item.TB_ProductionPlanFromERPReference.Load();
                            item.TB_ProductionPlanFromERP.TB_MaterialInfoReference.Load();
                            item.TB_ProductionPlanFromERP.TB_UserReference.Load();
                        }
                        dgv_MonthPlan.DataSource = list_MonthPlanForLED;
                    }
                    catch (Exception ex)
                    {
                        LogExecute.WriteDBExceptionLog(ex);
                    }
                }

                #endregion
            }

            #endregion

            DateTime dt_end = DateTime.Now;

            TimeSpan a = dt_begin1 - dt_begin;
            TimeSpan b = dt_end - dt_begin;

            lab_DealTime1.Text = b.ToString();
        }

        /// <summary>
        /// 月度计划表加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MonthPlan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_MonthPlan.Rows[e.RowIndex].DataBoundItem != null) && (dgv_MonthPlan.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_MonthPlan.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_MonthPlan.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_ECSMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void ping服务器ToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 关闭或开启监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu301_Click(object sender, EventArgs e)
        {
            if (ECSFlag)
            {
                ECSFlag = false;
                lab_ECSIsUse.Text = "关闭";
            }
            else
            {
                ECSFlag = true;
                lab_ECSIsUse.Text = "开启";
            }
        }

        /// <summary>
        /// 关闭或开启LED处理逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu401_Click(object sender, EventArgs e)
        {
            if (LEDFlag)
            {
                LEDFlag = false;
                lab_LEDIsUse.Text = "已停止";
            }
            else
            {
                LEDFlag = true;
                lab_LEDIsUse.Text = "正在运行";
            }
        }

        /// <summary>
        /// 关闭事件，记录登出信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_ECSMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region 记录登出信息

            try
            {
                int flag = sclient.LoginHelpForLoginOut(user.ID, 0, "ECS监控");
                switch (flag)
                {
                    case 1:
                    case 4:
                    case 5:
                        LogExecute.WriteInfoLog("登出记录失败", false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog("退出记录失败,详情" + ex.ToString(), false);
            }

            #endregion
            Application.Exit();
        }

        /// <summary>
        /// 打开PLC连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_OpenPLCLink_Click(object sender, EventArgs e)
        {
            //打开
            if (MasterPLC.Open() != 0)
            {
                MessageBox.Show("打开PLC连接失败！请检查网络配置！");
                lab_PLCStatus.Text = "PLC连接失败！请检查网络配置！";
                ECSFlag = false;
                lab_ECSIsUse.Text = "关闭";
            }
            else
            {
                MessageBox.Show("打开PLC连接成功！");
                lab_PLCStatus.Text = "打开PLC连接成功！";
                ECSFlag = true;
                lab_ECSIsUse.Text = "开启";
            }
        }

        /// <summary>
        /// 关闭PLC连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_ClosePLCLink_Click(object sender, EventArgs e)
        {
            //关闭
            if (MasterPLC.Close() != 0)
            {
                MessageBox.Show("PLC关闭失败！请检查网络配置！");
                lab_PLCStatus.Text = "PLC关闭失败！请检查网络配置！";
                ECSFlag = true;
                lab_ECSIsUse.Text = "开启";
            }
            else
            {
                MessageBox.Show("关闭PLC连接成功");
                lab_PLCStatus.Text = "关闭PLC连接成功！";
                ECSFlag = false;
                lab_ECSIsUse.Text = "关闭";
            }
        }

    }
}
