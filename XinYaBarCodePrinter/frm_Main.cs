using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
//using ZebraBarcodePrinter;

namespace XinYaBarCodePrinter
{
    public partial class frm_Main : Form
    {
        #region 字段属性

        TB_User user;
        int secondWorkStationID = 0;// = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationID"]);
        string source = "";// System.Configuration.ConfigurationSettings.AppSettings["Source"];
        string workStationCode = "";// System.Configuration.ConfigurationSettings.AppSettings["WorkStationCode"];
        string secondWorkStationCode = "";// System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationCode"];
        ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();

        /// <summary>
        /// 配置文件路径
        /// </summary>
        string xmlPath = Properties.Settings.Default.XmlPath;

        /// <summary>
        /// 打印机名
        /// </summary>
        string printName = "";//System.Configuration.ConfigurationSettings.AppSettings["PrintName"];

        /// <summary>
        /// 条码打印
        /// </summary>
        //ZebraBcPrint zebraBcPrint = new ZebraBcPrint();

        /// <summary>
        /// 当前工位信息
        /// </summary>
        TB_SecondWorkStationInfo secondWorkStationInfo;

        #endregion

        public frm_Main(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            lab_WorkerName.Text = "登录员工：" + user.UserName;
            lab_WorkNum.Text = "工号：" + user.UserID;
            lab_LoginTime.Text = "登录时间：" + DateTime.Now.ToString();
            UpdateSystemTime();
            #region 读取配置文件

            try
            {
                secondWorkStationID = Convert.ToInt32(XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationID"));
                source = XMLHelper.ReadXML(xmlPath, "XinYa", "Source");
                workStationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "WorkStationCode");
                secondWorkStationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationCode");
                printName = XMLHelper.ReadXML(xmlPath, "XinYa", "PrintName");
            }
            catch (Exception)
            {
                MessageBox.Show("检测到配置文件出错，程序即将关闭，请联系管理员解决问题。");
                Application.Exit();
            }
            SecondWorkStationInit(secondWorkStationID);
            lab_CurrentWorkStation.Text = secondWorkStationInfo.SecondWorkStationName;

            #endregion
        }

        /// <summary>
        /// 工位信息初始化
        /// </summary>
        /// <param name="id"></param>
        private void SecondWorkStationInit(int id)
        {
            using (XinYaDBEntities1 db=new XinYaDBEntities1())
            {
                try
                {
                    secondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == id);
                    secondWorkStationInfo.TB_WorkStationInfoReference.Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败，请报告管理员");
                }
            }
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        public void UpdateSystemTime()
        {
            try
            {
                UpdateTime.SetSysTime(service1Client.GetTimeNow());
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("更新本机时间", ex);
            }
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            //#region 扫描记录

            //int flag = 0;//是否打印标志位
            //if (string.IsNullOrEmpty(txt_BarCodeString.Text))
            //{
            //    MessageBox.Show("没有可用于打印的条码数据！");
            //}
            //else
            //{
            //    string matCode = txt_BarCodeString.Text;//当前扫描条码
            //    using (XinYaDBEntities db = new XinYaDBEntities())
            //    {
            //        try
            //        {
            //            TB_WorkDtl workDtl;
            //            try
            //            {
            //                //首先查找这个泵对应的子任务，必须是没有异常的
            //                workDtl = db.TB_WorkDtl.First(p => p.MaterialCode == matCode && p.IsException == false);
            //            }
            //            catch (Exception ex)
            //            {
            //                workDtl = null;
            //                //MessageBox.Show("当前系统中未找到泵体：" + matCode + "的上线记录，或者它已经被标记为异常泵。");
            //                LogExecute.WriteExceptionLog("当前系统中未找到泵体：" + matCode + "的上线记录，或者它已经被标记为异常泵。", ex);
            //            }
            //            if (workDtl != null)
            //            {
            //                //判断当前扫码表中是否存在相应记录，存在则提示
            //                int count = db.TB_ScanRecord.Count(p => p.TB_WorkDtl.ID == workDtl.ID);
            //                if (count == 0)
            //                {
            //                    try
            //                    {
            //                        //==0说明还没有打码记录，则新增
            //                        TB_ScanRecord scanRecord = new TB_ScanRecord();
            //                        scanRecord.TB_WorkDtl = db.TB_WorkDtl.First(p => p.ID == workDtl.ID);
            //                        scanRecord.TB_User = db.TB_User.First(p => p.ID == user.ID);
            //                        scanRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
            //                        scanRecord.ScanDate = DateTime.Now;
            //                        db.AddToTB_ScanRecord(scanRecord);
            //                        db.SaveChanges();
            //                        flag = 1;
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        //MessageBox.Show("新增扫描失败");
            //                        LogExecute.WriteExceptionLog("新增扫描失败,子任务" + workDtl.ID, ex);
            //                    }
            //                }
            //                else if (count == 1)//等于1表示有一条记录，则更新
            //                {
            //                    if (MessageBox.Show("检测到当前泵体条码已经被打印了一次，如果继续则会更新打印时间", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //                    {
            //                        try
            //                        {
            //                            var scanRecord = db.TB_ScanRecord.First(p => p.TB_WorkDtl.ID == workDtl.ID);
            //                            //更新扫码
            //                            scanRecord.ScanDate = DateTime.Now;
            //                            db.SaveChanges();
            //                            flag = 1;
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            //MessageBox.Show("更新扫码时间出现异常！");
            //                            LogExecute.WriteExceptionLog("更新扫码时间出现异常！", ex);
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    //如果不等于1，则表示记录表中有多条记录，这种情况是不允许出现的,而这种情况一般也不会出现。
            //                    //MessageBox.Show("当前泵体条码数据记录出现异常！");
            //                    LogExecute.WriteInfoLog("当前泵体条码数据记录出现异常!子任务ID" + workDtl.ID);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //MessageBox.Show("出现特定于网络或数据存储的异常！");
            //            LogExecute.WriteExceptionLog("出现特定于网络或数据存储的异常!", ex);
            //        }
            //    }
            //}

            //#endregion

            #region  测试

            //ZebraGesigner zb = new ZebraGesigner();
            ////string mycommanglines = System.IO.File.ReadAllText("print.txt");//print.txt里写了条码机的命令   
            //StringBuilder builder = new StringBuilder();
            //builder.AppendLine("^XA");
            //builder.AppendLine("^MD30");
            //builder.AppendLine("^LH60,10");
            //builder.AppendLine("^FO20,10");
            //builder.AppendLine("^ACN,18,10");
            //builder.AppendLine("^BY1.4,3,50");
            //builder.AppendLine("^BCN,,Y,N");
            //builder.AppendLine("^FD01008D004Q-0^FS");
            //builder.AppendLine("^XZ"); 
            //zb.Open();
            //zb.Write(builder.ToString());
            //zb.Close(); 

            //if (zebraBcPrint.PrintBarcode(txt_BarCodeString.Text))
            //{
            //    MessageBox.Show("打印成功！");
            //}
            //else
            //{
            //    MessageBox.Show("打印失败！");
            ////}
            //PrintHelp help = new PrintHelp();
            //help.Run();
            //pictureBox1.Image = BarCodeHelper.Create128Code(txt_BarCodeString.Text, 12, 1, 50, 5, 8);
            //printDocument1.PrinterSettings.PrinterName = "Zebra ZM400 (203 dpi) - ZPL";
            //printDocument1.Print();

            #endregion
            int flag=1;
            if (flag == 1)
            {
                //pictureBox1.Image = BarCodeHelper.Create128Code(txt_BarCodeString.Text, 12, 1, 50, 10, 10);
                //pictureBox1.Image.Save("D://BarCode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                ////ReportParameter params1;
                ////params1 = new ReportParameter("ReportParameter_Image", "file:///D:\\BarCode.jpg");
                ////reportViewer1.LocalReport.SetParameters(new ReportParameter[] { params1 });
                //this.reportViewer1.RefreshReport();
                //重写打印
                pictureBox1.Image = BarCodeHelper.Create128Code(txt_BarCodeString.Text, 12, 1, 50, 5, 8);
                printDocument1.PrinterSettings.PrinterName = @printName;//如果打印机在网络上需要指明路径
                //先判定是否可用
                if (printDocument1.PrinterSettings.IsValid)
                {
                    try
                    {
                        printDocument1.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("未能连接打印机，详情请查看本地日志。");
                        LogExecute.WriteLineDataLog("打印失败" + ex.ToString());
                    }
                }
                else
                {
                    //不可用则做一个说明
                    MessageBox.Show("当前未找到可用的打印机，请确保打印机开启且已经连入了网络在进行操作");
                }
            }
            else
            {
                MessageBox.Show("检测到物料编码有异常，打印未能继续。这通常是由于不存在的或者有异常的物料编码引发的");
                LogExecute.WriteLineDataLog("检测到物料编码有异常，打印未能继续。这通常是由于不存在的或者有异常的物料编码引发的。");
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter params1;
            params1 = new ReportParameter("ReportParameter_Image", "file:///D:\\BarCode.jpg");
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { params1 });
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_BarCodeString.Text = "";
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int flag = service1Client.LoginHelpForLoginOut(user.ID, secondWorkStationID, "");
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
        /// 打印事件测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Changebar(true);
            Application.DoEvents();
            //e代表打印源
            e.Graphics.DrawString("公司：山东鑫亚工业股份有限公司", new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
                                    System.Drawing.Brushes.Black,
                                    8, 35);
            e.Graphics.DrawString("操作员：" + user.UserName, new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
                                    System.Drawing.Brushes.Black, 8, 52);
            e.Graphics.DrawString("打印日期：" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString(), new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
                                    System.Drawing.Brushes.Black, 8, 70);
            e.Graphics.DrawImage(pictureBox1.Image, 0, 85);
            Changebar(false);
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_View_Click(object sender, EventArgs e)
        {
            Changebar(true);
            Application.DoEvents();
            pictureBox1.Image = BarCodeHelper.Create128Code(txt_BarCodeString.Text, 12, 1, 50, 10, 10);
            pictureBox1.Image.Save("D://BarCode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            //ReportParameter params1;
            //params1 = new ReportParameter("ReportParameter_Image", "file:///D:\\BarCode.jpg");
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { params1 });
            this.reportViewer1.RefreshReport();
            Changebar(false);
        }

        /// <summary>
        /// 进度条控制函数
        /// </summary>
        /// <param name="flag"></param>
        public void Changebar(bool flag)
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

        /// <summary>
        /// 快捷键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//回车 - 完成
            {
                object a = new object();
                EventArgs b = new EventArgs();
                btn_Comfirm_Click(a, b);
            }
            e.Handled = true;
        }

        /// <summary>
        /// 条码自动录入系统数据,确认打印只进行打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_BarCodeString_TextChanged(object sender, EventArgs e)
        {
            //if (txt_BarCodeString.Text.Length == 23)
            //{
            //    string matCode = txt_BarCodeString.Text;
            //    using (XinYaDBEntities db = new XinYaDBEntities())
            //    {
            //        try
            //        {
            //            TB_WorkDtl workDtl;
            //            try
            //            {
            //                //首先查找这个泵对应的子任务
            //                workDtl = db.TB_WorkDtl.First(p => p.MaterialCode == matCode && p.IsException == false);
            //            }
            //            catch (Exception ex)
            //            {
            //                workDtl = null;
            //                MessageBox.Show("当前系统中未找到泵体：" + matCode + "的上线记录，或者它已经被标记为异常泵。");
            //                LogExecute.WriteExceptionLog("当前系统中未找到泵体：" + matCode + "的上线记录，或者它已经被标记为异常泵。", ex);
            //                lab_StatusOutput.Text = DateTime.Now + ",编码：" + matCode + "录入系统-失败。";
            //            }
            //            if (workDtl != null)
            //            {
            //                //判断当前扫码表中是否存在相应记录，存在则提示
            //                int count = db.TB_ScanRecord.Count(p => p.TB_WorkDtl.ID == workDtl.ID);
            //                if (count == 0)
            //                {
            //                    try
            //                    {
            //                        //==0说明还没有打码记录，则新增
            //                        TB_ScanRecord scanRecord = new TB_ScanRecord();
            //                        scanRecord.TB_WorkDtl = db.TB_WorkDtl.First(p => p.ID == workDtl.ID);
            //                        scanRecord.TB_User = db.TB_User.First(p => p.ID == user.ID);
            //                        scanRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
            //                        scanRecord.ScanDate = DateTime.Now;
            //                        db.AddToTB_ScanRecord(scanRecord);
            //                        db.SaveChanges();
            //                        lab_StatusOutput.Text = DateTime.Now + ",编码：" + workDtl.MaterialCode + "录入系统-成功。";
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show("新增扫描失败");
            //                        LogExecute.WriteExceptionLog("新增扫描失败,子任务" + workDtl.ID, ex);
            //                        lab_StatusOutput.Text = DateTime.Now + ",编码：" + workDtl.MaterialCode + "录入系统-失败。";
            //                    }
            //                }
            //                else if (count == 1)//等于1表示有一条记录，则更新
            //                {
            //                    //if (MessageBox.Show("检测到当前泵体条码已经被打印了一次，如果继续则会更新打印时间", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //                    //{
            //                    try
            //                    {
            //                        var scanRecord = db.TB_ScanRecord.First(p => p.TB_WorkDtl.ID == workDtl.ID);
            //                        //更新扫码
            //                        scanRecord.ScanDate = DateTime.Now;
            //                        db.SaveChanges();
            //                        lab_StatusOutput.Text = DateTime.Now + ",编码：" + workDtl.MaterialCode + "录入系统-成功。";
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show("更新扫码时间出现异常！");
            //                        LogExecute.WriteExceptionLog("更新扫码时间出现异常！", ex);
            //                        lab_StatusOutput.Text = DateTime.Now + ",编码：" + workDtl.MaterialCode + "录入系统-失败。";
            //                    }
            //                    //}
            //                }
            //                else
            //                {
            //                    //如果不等于1，则表示记录表中有多条记录，这种情况是不允许出现的,而这种情况一般也不会出现。
            //                    MessageBox.Show("当前泵体条码数据记录出现异常！");
            //                    LogExecute.WriteInfoLog("当前泵体条码数据记录出现异常!子任务ID" + workDtl.ID);
            //                    lab_StatusOutput.Text = DateTime.Now + ",编码：" + matCode + "录入系统-失败。";
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("出现特定于网络或数据存储的异常！");
            //            LogExecute.WriteExceptionLog("出现特定于网络或数据存储的异常!", ex);
            //            lab_StatusOutput.Text = DateTime.Now + ",编码：" + matCode + "录入系统-失败。";
            //        }
            //    }
            //}
        }

        //private void btn_Printer_Click(object sender, EventArgs e)
        //{
        //    LocalReport report = new LocalReport();
        //    report.ReportPath = @"D:\项目资料\鑫亚\开发\XinYaBarCodePrinter\XinYaBarCodePrinter\bin\Debug\Report1.rdlc";
        //    ReportDataSource source = new ReportDataSource(,);

        //    report.Refresh();

        //    PrintDocument printDoc = new PrintDocument();
        //    printDoc.PrinterSettings.PrinterName = "Zebra ZM400 (203 dpi) - ZPL";

        //    printDoc.Print();
        //}
    }
}
