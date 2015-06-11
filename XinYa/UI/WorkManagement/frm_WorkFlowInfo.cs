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
    public partial class frm_WorkFlowInfo : Form
    {
        TB_User user;
        public frm_WorkFlowInfo(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            dgv_Main.AutoGenerateColumns = false;
            DataInit();
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

        /// <summary>
        /// 确定保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        int id = (int)dgv_Main.Rows[i].Cells["c_ID"].Value;
                        var ws = db.TB_WorkStationInfo.Single(p => p.ID == id);
                        ws.WorkStationName = dgv_Main.Rows[i].Cells["c_WorkStationName"].Value.ToString();
                        ws.Remark = dgv_Main.Rows[i].Cells["c_Remark"].Value == null ? null : dgv_Main.Rows[i].Cells["c_Remark"].Value.ToString();
                        db.SaveChanges();
                    }
                    MessageBox.Show("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("可能与服务器失去有效的连接，保存更改失败。");
                    LogExecute.WriteInfoLog("保存工序信息失败，操作员："+user.UserName+",详情：" + ex.ToString());
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 数据刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            DataInit();
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
            BllHelp.DataOutport(dgv_Main);
            Changeprobar(false);
        }

        /// <summary>
        /// 数据初始
        /// </summary>
        private void DataInit()
        {
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    dgv_Main.DataSource = db.TB_WorkStationInfo.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("可能由于网络原因数据加载出错！请检查与与服务器的网络连接情况。");
                }
            }
        }

        /// <summary>
        /// 进度条控制函数
        /// </summary>
        /// <param name="flag"></param>
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
