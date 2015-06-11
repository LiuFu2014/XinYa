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
    public partial class frm_Settings : Form
    {
        public frm_Settings()
        {
            InitializeComponent();
            txt_PrintName.Text = Properties.Settings.Default.PrintName;
            txt_Heixiancudu.Text = Properties.Settings.Default.黑线粗度;
            txt_Suofangjibie.Text = Properties.Settings.Default.缩放级别;
            txt_BarCodeHeight.Text = Properties.Settings.Default.条码高度;
            txt_X.Text = Properties.Settings.Default.右上角X轴;
            txt_Y.Text = Properties.Settings.Default.右上角Y轴;
            txt_FontSize.Text = Properties.Settings.Default.字体大小;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("打印配置更改可能会导致打印问题，您确定要继续么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Properties.Settings.Default.PrintName = txt_PrintName.Text;
                    Properties.Settings.Default.黑线粗度 = txt_Heixiancudu.Text;
                    Properties.Settings.Default.缩放级别 = txt_Suofangjibie.Text;
                    Properties.Settings.Default.条码高度 = txt_BarCodeHeight.Text;
                    Properties.Settings.Default.右上角X轴 = txt_X.Text;
                    Properties.Settings.Default.右上角Y轴 = txt_Y.Text;
                    Properties.Settings.Default.字体大小 = txt_FontSize.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("保存配置成功，重新启动本程序配置生效！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存配置出现异常，请检查配置文件是否损坏！");
                }
            }
        }

        /// <summary>
        /// 取消退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
