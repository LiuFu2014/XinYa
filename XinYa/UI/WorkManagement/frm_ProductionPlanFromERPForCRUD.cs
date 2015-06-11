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
    public partial class frm_ProductionPlanFromERPForCRUD : Form
    {
        TB_User user;
        public frm_ProductionPlanFromERPForCRUD(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_SerShow.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 查询（根据导入时间）
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
                AddToResultShow("系统正在处理...");
                Application.DoEvents();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var list_erp = db.TB_ProductionPlanFromERP.Where(p => p.ImportDate > dtp_BeginTime.Value && p.ImportDate < dtp_EndTime.Value).ToList();
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
        /// 保存更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveChange_Click(object sender, EventArgs e)
        {
            //先看有没有
            if (dgv_SerShow.DataSource == null || dgv_SerShow.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("当前没有可用于删除的数据！");
            }
            else
            {
                AddToResultShow("系统正在处理...");
                Application.DoEvents();
                StringBuilder result = new StringBuilder();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //获取所有日计划
                        var planForEachDay = db.TB_ProductionPlan.ToList();
                        //List<TB_ProductionPlan> list_dayPlanForEachERPPlan = new List<TB_ProductionPlan>();
                        //遍历
                        foreach (DataGridViewRow item in dgv_SerShow.Rows)
                        {
                            List<TB_ProductionPlan> list_dayPlanForEachERPPlan = new List<TB_ProductionPlan>();
                            //取出这条记录，值，制订部门
                            int id = (int)item.Cells["c_ID"].Value;
                            int planAmount = (int)item.Cells["c_PlanAmount"].Value;
                            string planDepartment = item.Cells["c_PlanDepartment"].Value.ToString();
                            //对应日计划和
                            int sum = 0;
                            //取出这条记录
                            var productionPlanERP = db.TB_ProductionPlanFromERP.Single(p => p.ID == id);
                            //统计这条记录所拥有的日计划的计划数量和。
                            foreach (var item2 in planForEachDay)
                            {
                                if (item2.TB_MaterialInfo.TypeCode == productionPlanERP.TB_MaterialInfo.TypeCode && item2.PlanTime.CompareTo(productionPlanERP.PlanBeginTime) > 0 && item2.PlanTime.CompareTo(productionPlanERP.PlanEndTime) < 0)
                                {
                                    sum += item2.Amount;
                                }
                            }
                            if (planAmount < sum)
                            {
                                //修改的数量小于已经存在的日计划的数量和
                                //result="更新物料编码为"+productionPlanERP.TB_MaterialInfo.TypeCode+""
                                result.AppendFormat("更新物料编码为{0},开始时间为{1}，结束时间为{2}的计划的数量失败。原因为已存在的日计划的数量{4}和大于当前修改的数量{5}.", productionPlanERP.TB_MaterialInfo.TypeCode, productionPlanERP.PlanBeginTime, productionPlanERP.PlanEndTime, sum.ToString(), planAmount.ToString());
                                result.AppendLine();
                            }
                            else
                            {
                                //修改的数量大于已经存在的日计划的数量和，则更新
                                productionPlanERP.PlanAmount = planAmount;
                                productionPlanERP.PlanDepartment = planDepartment;
                                db.SaveChanges();
                                result.AppendFormat("更新物料编码为{0},开始时间为{1}，结束时间为{2}的计划的数量成功。", productionPlanERP.TB_MaterialInfo.TypeCode, productionPlanERP.PlanBeginTime);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("更新出现问题，详情请查看日志");
                        AddToResultShow("更新出现问题，详情请查看日志");
                        SystemLogHelper.WriteSysLogHelper("更新出现问题，详情:" + ex.ToString(), user.ID, "ERP导入计划修改");
                    }
                }
                //加载输出显示
                AddToResultShow(result.ToString());
            }
        }

        /// <summary>
        /// 删除指定项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_SerShow.DataSource == null || dgv_SerShow.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("当前没有可用于删除的数据");
            }
            else
            {
                AddToResultShow("系统正在处理...");
                Application.DoEvents();
                StringBuilder result = new StringBuilder();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //获取所有日计划
                    var planForEachDay = db.TB_ProductionPlan.ToList();
                    try
                    {
                        foreach (DataGridViewRow item in dgv_SerShow.Rows)
                        {
                            if (item.Cells["c_Select"].Value != null && item.Cells["c_Select"].Value.ToString() == "True")
                            {
                                int id = (int)item.Cells["c_ID"].Value;
                                //选定，找到后,检测这段时间内有无日计划，有则不做删除，没有则删除
                                var planFromERP = db.TB_ProductionPlanFromERP.Single(p => p.ID == id);
                                if (planForEachDay.Count(p => p.MaterialID == planFromERP.MatType && p.PlanTime.Date.CompareTo(planFromERP.PlanBeginTime.Date) > 0 && p.PlanTime.CompareTo(planFromERP.PlanEndTime.Date) < 0) == 0)
                                {
                                    db.TB_ProductionPlanFromERP.DeleteObject(planFromERP);
                                    db.SaveChanges();
                                    result.AppendFormat("删除物料编码为{0},开始时间为{1}，结束时间为{2}的导入计划成功。", planFromERP.MatType, planFromERP.PlanBeginTime.ToShortDateString(), planFromERP.PlanEndTime.ToLongDateString());
                                    result.AppendLine();
                                }
                                else
                                {
                                    result.AppendFormat("删除物料编码为{0},开始时间为{1}，结束时间为{2}的导入计划失败。原因为该计划已经存在对应的日计划", planFromERP.MatType, planFromERP.PlanBeginTime.ToShortDateString(), planFromERP.PlanEndTime.ToLongDateString());
                                    result.AppendLine();
                                }
                            }
                        }
                        AddToResultShow(result.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除出现异常，详情请查看日志！");
                        AddToResultShow("删除出现异常，详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("删除出现异常，详情：" + ex.ToString(), user.ID, "");
                    }
                }
            }
        }

        /// <summary>
        /// 用于向输出文本追加文本
        /// </summary>
        /// <param name="s"></param>
        public void AddToResultShow(string s)
        {
            txt_ResultShow.AppendText(DateTime.Now.ToString() + ":" + s + "\n");
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
