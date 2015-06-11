using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;

namespace XinYa.UI.WorkManagement
{
    public partial class frm_WorkFlowCenter : Form
    {
        BllHelp bllHelp = new BllHelp();

        public frm_WorkFlowCenter()
        {
            InitializeComponent();
            this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.p_Bottom.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            dgv_Main.AutoGenerateColumns = false;
            Init();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            List<TB_ProcessRouteP> p = bllHelp.GetAllWorkFlow(true,"").ToList();
            dgv_Main.DataSource = p;
        }

        /// <summary>
        /// datagrid加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Main.Rows[e.RowIndex].DataBoundItem != null) &&(dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_Main.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
    }
}
