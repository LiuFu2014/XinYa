using System;
using System.Linq;
using System.Windows.Forms;
using XinYa.DAL;
using XinYa.UI.InfoSearch;
using XinYa.UI.WorkManagement;

namespace XinYa.BLL
{
    public partial class frm_UserSelectHelper : Form
    {
        /// <summary>
        /// 回传值控制，1为工时统计，2为合格率统计—调试,3为合格率中的返修,4为工时辅助,5为员工工作记录查询
        /// </summary>
        int flag = 0;

        /// <summary>
        /// 新增回传值控制
        /// </summary>
        /// <param name="flag">1为工时统计，2为合格率统计—调试,3为合格率中的返修，4为工时辅助,5为员工工作记录查询</param>
        public frm_UserSelectHelper(int flag)
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;
            this.flag = flag;
            DateInit();
        }

        public void DateInit()
        {
            using (XinYaDBEntities db = new DAL.XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                    dgv_Main.DataSource = a;
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 确认回传值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (dgv_Main.Rows.Count > 0)
            {
                if (flag == 1)
                {
                    frm_WorkTimeStatistics worktime = (frm_WorkTimeStatistics)this.Tag;
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            worktime.txt_Select.AppendText(dgv_Main.Rows[i].Cells["c_UserID"].Value.ToString() + ";");
                        }
                    }
                    //this.Close();
                }
                if (flag==2)
                {
                    frm_QualifiedRateStatistics QCRate = (frm_QualifiedRateStatistics)this.Tag;
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            QCRate.txt_TiaoshiWorkerMan.AppendText(dgv_Main.Rows[i].Cells["c_UserID"].Value.ToString() + ";");
                        }
                    }
                }
                if (flag==3)
                {
                    frm_QualifiedRateStatistics QCRate = (frm_QualifiedRateStatistics)this.Tag;
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            QCRate.txt_FanxiuWorkerman.AppendText(dgv_Main.Rows[i].Cells["c_UserID"].Value.ToString() + ";");
                        }
                    }
                }
                if (flag==4)
                {
                    frm_WorkTimeBandingInfo wtbi = (frm_WorkTimeBandingInfo)this.Tag;
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            wtbi.txt_Worker.AppendText(dgv_Main.Rows[i].Cells["c_UserID"].Value.ToString() + ";");
                        }
                    }
                }
                if (flag == 5)
                {
                    frm_HistoryWorkRecordSer worker = (frm_HistoryWorkRecordSer)this.Tag;
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            worker.txt_Workerman.AppendText(dgv_Main.Rows[i].Cells["c_UserID"].Value.ToString() + ";");
                        }
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}