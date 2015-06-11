using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XinYaECS
{
    public partial class user_Label : UserControl
    {

        private Color backcolor;

        /// <summary>
        /// 自定义背景属性
        /// </summary>
        public Color Backcolor
        {
            get { return backcolor; }
            set
            {
                backcolor = value;
                lab_Main.BackColor = backcolor;
            }
        }

        private string text;

        /// <summary>
        /// 自定义显示文本属性
        /// </summary>
        public string labText
        {
            get { return text; }
            set { text = value; lab_Main.Text = text; }
        }

        public user_Label()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 改变颜色
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColor(Color color)
        {
            this.Backcolor = color;
        }

        public Color GetColor()
        {
            return Backcolor;
        }

        /// <summary>
        /// 更改显示文本
        /// </summary>
        /// <param name="text"></param>
        public void ChangeText(string text)
        {
            this.lab_Main.Text = text;
        }

        /// <summary>
        /// 单击事件，加载任务信息，托盘号事先存入tag属性中，没有则为null(弃用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void user_Label_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Name);
            //是否为null的一次判断。
            if (this.Tag != null)
            {
                int int_palletCode = Convert.ToInt32(this.Tag);
                string palletCode = IntToStringfor4Length(int_palletCode);
                frm_WorkingDtl workingDtl = new frm_WorkingDtl(palletCode);
                workingDtl.Show();
            }
        }

        /// <summary>
        /// 将电气int型托盘编码转成4个长度的string类型
        /// </summary>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public string IntToStringfor4Length(int palletCode)
        {
            string palletCode2 = palletCode.ToString();
            for (int i = 0; i < 4; i++)
            {
                if (palletCode2.Length < 4)
                {
                    palletCode2 = palletCode2.Insert(0, "0");
                }
                else
                {
                    break;
                }
            }
            return palletCode2;
        }

        /// <summary>
        /// 单击事件，加载任务信息，托盘号事先存入tag属性中，没有则为null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_Main_Click(object sender, EventArgs e)
        {
            try
            {
                string type = this.Name.ToString().Substring(0, 5);
                if (type == "lab_G")
                {
                    int length = this.Name.ToString().Length;
                    //工位
                    int secondWorkStationID = Convert.ToInt32(this.Name.ToString().Substring(5, length - 5));
                    int int_palletCode = Convert.ToInt32(this.Tag);
                    string palletCode = IntToStringfor4Length(int_palletCode);
                    frm_WorkingDtl workingDtl = new frm_WorkingDtl(palletCode, secondWorkStationID);
                    workingDtl.Show();
                }
                else if (type == "lab_Z")
                {
                    //阻挡器
                    int int_palletCode = Convert.ToInt32(this.Tag);
                    string palletCode = IntToStringfor4Length(int_palletCode);
                    frm_WorkingDtl workingDtl = new frm_WorkingDtl(palletCode);
                    workingDtl.Show();
                }
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog("自定义控件单击事件出现异常，详情" + ex.ToString());
            }
        }
    }
}
