using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;
using XinYa.BLL;

namespace XinYa.UI.WorkManagement
{
    public partial class frm_ProductionPlanFomERPSer : Form
    {
        TB_User user;
        public frm_ProductionPlanFomERPSer(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_SerShow.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            //时间判断
            if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value) > 0)
            {
                MessageBox.Show("开始时间不应晚于结束时间");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var list_erp = db.TB_ProductionPlanFromERP.Where(p => p.ImportDate > dtp_BeginTime.Value && p.ImportDate < dtp_EndTime.Value).ToList();
                        //...
                        //...未完待续...
                        //11月29日
                        //对每一个计划的执行情况进行一个加载
                        //完成的数量来源，定义为任务完成数量。
                        //var mainWorks = db.TB_WorkMain.Where(p => p.Finished == "1").ToList();
                        foreach (var item in list_erp)
                        {
                            var a = db.TB_WorkDtl.Where(p => p.TB_MaterialInfo.TypeCode == item.TB_MaterialInfo.TypeCode && p.IsException == false && p.TB_WorkMain.Finished == "1").ToList();
                            //完成量以任务完成为准
                            item.CompleteAmount = a.Count(p => p.TB_WorkMain.FinishedDate.Value.Date.CompareTo(item.PlanBeginTime) >= 0 && p.TB_WorkMain.FinishedDate.Value.Date.CompareTo(item.PlanEndTime) <= 0);
                            if (item.CompleteAmount > item.PlanAmount)
                            {
                                item.CompleteStatus = "超过计划";
                            }
                            if (item.CompleteAmount == item.PlanAmount)
                            {
                                item.CompleteStatus = "完成计划";
                            }
                            if (item.CompleteAmount < item.PlanAmount)
                            {
                                item.CompleteStatus = "未达到计划";
                            }
                        }
                        //加载完全
                        foreach (var item in list_erp)
                        {
                            item.TB_MaterialInfoReference.Load();
                            item.TB_UserReference.Load();
                        }
                        dgv_SerShow.DataSource = list_erp;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常！请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "ERP查询");
                    }
                }
            }
        }

        /// <summary>
        /// 导出数据到Excel表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outport_Click(object sender, EventArgs e)
        {
            BllHelp.DataOutport(dgv_SerShow);
        }

        /// <summary>
        /// dgv_SerShow加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_SerShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_SerShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_SerShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_SerShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_SerShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
