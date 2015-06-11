using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XinYaBarCodeForAppointedFactory
{
    public partial class frm_Main : Form
    {
        #region 字段属性
        string printName;
        /// <summary>
        /// X轴
        /// </summary>
        string X;
        /// <summary>
        /// Y轴
        /// </summary>
        string Y;
        /// <summary>
        /// 字体大小
        /// </summary>
        string fontSize;
        /// <summary>
        /// 缩放级别
        /// </summary>
        string suofangjibie;
        /// <summary>
        /// 黑线粗度
        /// </summary>
        string heixiancudu;
        /// <summary>
        /// 条码高度
        /// </summary>
        string barCodeHeight;
        #endregion
        
        public frm_Main()
        {
            InitializeComponent();
            printName = Properties.Settings.Default.PrintName;
            X = Properties.Settings.Default.右上角X轴;
            Y = Properties.Settings.Default.右上角Y轴;
            fontSize = Properties.Settings.Default.字体大小;
            suofangjibie = Properties.Settings.Default.缩放级别;
            heixiancudu = Properties.Settings.Default.黑线粗度;
            barCodeHeight = Properties.Settings.Default.条码高度;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txt_BarCode.Text))
            //{
            //    pb_Preview.Image = BarCodeHelper.Create128Code(txt_BarCode.Text, 12, 1, 50, 5, 8);
            //    printDocument1.PrinterSettings.PrinterName = @printName;//如果打印机在网络上需要指明路径
            //    //先判定是否可用
            //    if (printDocument1.PrinterSettings.IsValid)
            //    {
            //        try
            //        {
            //            printDocument1.Print();
            //            txt_BarCode.Text = "";
            //            txt_BarCode.Focus();
            //        }
            //        catch (Exception)
            //        {
            //            MessageBox.Show("未能连接打印机，详情请查看本地日志。");
            //        }
            //    }
            //    else
            //    {
            //        //不可用则做一个说明
            //        MessageBox.Show("当前未找到可用的打印机，请确保打印机开启且已经连入了网络在进行操作");
            //    }
            //}
            var printer = new Printer();
            string cmd =string.Format( "^XA ^MD30^LH60,10^FO{0},{1}^ACN,{2},10^BY{3},{4},{5}^BC,,Y,N^FD{6}^FS ^XZ",X,Y,fontSize,suofangjibie,heixiancudu,barCodeHeight,txt_BarCode.Text);
            //string cmd = "^XA ^MD30^LH60,10^FO10,20^ACN,24,10^BY1.4,1,100^BC,,Y,N^FD"+txt_BarCode.Text.Trim()+"^FS ^XZ";
            if (RemotePrinter.SendStringToPrinter(@printName, cmd) == false)
            {
                MessageBox.Show("打印失败，请检查与打印机的连接！");
            }
            else
            {
                txt_BarCode.Text = "";
                txt_BarCode.Focus();
            }
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e代表打印源
            e.Graphics.DrawString("公司：山东鑫亚工业股份有限公司", new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
                                    System.Drawing.Brushes.Black,
                                    40, 35);
            //e.Graphics.DrawString("操作员：" + user.UserName, new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
            //                        System.Drawing.Brushes.Black, 8, 52);
            //e.Graphics.DrawString("打印日期：" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString(), new Font(new FontFamily("Arial"), 10, FontStyle.Regular),
            //                        System.Drawing.Brushes.Black, 8, 70);
            e.Graphics.DrawImage(pb_Preview.Image, 40, 70, 300, 80);
            //e.Graphics.DrawImage(pb_Preview.Image, 40, 70);
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BarCode.Text))
            {
                pb_Preview.Image = BarCodeHelper.Create128Code(txt_BarCode.Text, 12, 1, 50, 5, 8);
                //pictureBox1.Image = BarCodeHelper.Create128Code(txt_BarCode.Text, 12, 1, 50, 5, 8);
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 打印快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//回车 - 完成
            {
                btn_Print_Click(sender, e);
            }
        }

        /// <summary>
        /// 打印配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("打印配置更改可能会导致打印问题，您确定要继续么？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                frm_Settings settings = new frm_Settings();
                settings.ShowDialog();
            }
        }

    }
}
