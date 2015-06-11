using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.WorkStation
{
    public partial class frm_WorkStationInfo : Form
    {
        public frm_WorkStationInfo()
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;
            DataInit();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            DataInit();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                dgv_Main.DataSource = db.TB_SecondWorkStationInfo.ToList();
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.DataSource!=null&&dgv_Main.Rows.Count!=0)
            {
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    try
                    {
                        for (int i = 0; i < dgv_Main.Rows.Count; i++)
                        {
                            int id = (int)dgv_Main.Rows[i].Cells["c_ID"].Value;
                            var sws = db.TB_SecondWorkStationInfo.Single(p => p.ID == id);
                            sws.SecondWorkStationName = dgv_Main.Rows[i].Cells["c_SecondWorkStationName"].Value.ToString();
                            sws.IsUse = (bool)dgv_Main.Rows[i].Cells["c_IsUse"].Value;
                            sws.Remark = dgv_Main.Rows[i].Cells["c_Remark"].Value == null ? "" : dgv_Main.Rows[i].Cells["c_Remark"].Value.ToString();
                            db.SaveChanges();
                        }
                        MessageBox.Show("保存成功！");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("或由于网络原因，保存当前失败。");
                    }                 
                }
            }
            else
            {
                MessageBox.Show("当前没有可以用于保存的数据。");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outport_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.RowCount <= 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Main) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

        public void Changeprobar(bool flag)
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

    }
}
