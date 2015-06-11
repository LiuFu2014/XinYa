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
    public partial class frm_ProductionPlanFomERP : Form
    {
        TB_User user;
        public frm_ProductionPlanFomERP(TB_User user)
        {
            InitializeComponent();
            this.user = user;
        }

        /// <summary>
        /// 导入到dataset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Import_Click(object sender, EventArgs e)
        {
            DataSet a = ExportData.ExcelToDataSet("test");
            try
            {
                dgv_Show.DataSource = a.Tables["test"];

                DateTime b = new DateTime();
                b = (DateTime)dgv_Show.Rows[0].Cells[2].Value;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 清理预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Show.DataSource = null;
        }

        /// <summary>
        /// 确认导入到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confrim_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            //现行判断是否有可以到处的数据
            //导入时会产生一行空行，所以没有数据的时候，行数为1
            if (dgv_Show.DataSource == null || dgv_Show.RowCount == 1)
            {
                MessageBox.Show("没有可用的数据！");
            }
            else
            {
                //判断是否符合格式要求
                //判断列是否为5列
                if (dgv_Show.ColumnCount != 5)
                {
                    MessageBox.Show("检测到导入的格式不符合要求，请检查");
                }
                else
                {
                    try
                    {
                        if (dgv_Show.Columns[0].Name != "物料编码" || dgv_Show.Columns[1].Name != "数量" || dgv_Show.Columns[2].Name != "起始时间" || dgv_Show.Columns[3].Name != "结束时间" || dgv_Show.Columns[4].Name != "制订部门")
                        {
                            MessageBox.Show("检测到列名不符合要求，请检查");
                        }
                        else
                        {
                            string info = "";
                            string info2 = "";
                            int totle = dgv_Show.Rows.Count - 1;
                            int chenggong = 0;
                            int shibai = 0;
                            using (XinYaDBEntities db = new XinYaDBEntities())
                            {
                                //检查通过后循环遍历dgv中的行，并记录导入失败的行号
                                //排除最后一行空行
                                for (int i = 0; i < dgv_Show.RowCount - 1; i++)
                                {
                                    try
                                    {
                                        //赋值
                                        string matType = dgv_Show.Rows[i].Cells["物料编码"].Value.ToString();
                                        int planAmount = Convert.ToInt32(dgv_Show.Rows[i].Cells["数量"].Value);
                                        DateTime beginTime = (DateTime)dgv_Show.Rows[i].Cells["起始时间"].Value;
                                        DateTime endTime = (DateTime)dgv_Show.Rows[i].Cells["结束时间"].Value;
                                        string department = dgv_Show.Rows[i].Cells["制订部门"].Value.ToString();
                                        //判断计划时间有无交叉
                                        //同一个物料的开始于结束时间
                                        //int a = db.TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == matType && ((p.PlanBeginTime < endTime && p.PlanBeginTime > beginTime) || (p.PlanEndTime > beginTime && p.PlanEndTime < endTime)));
                                        //var b = db.TB_ProductionPlanFromERP.ToList();
                                        //int c = b.Count(p => p.TB_MaterialInfo.TypeCode == matType && ((beginTime.CompareTo(p.PlanBeginTime)>0&&beginTime.CompareTo(p.PlanEndTime)<0)||(endTime.CompareTo(p.PlanBeginTime)>0&&endTime.CompareTo(p.PlanEndTime)<0)));
                                        //这里真是奇了怪了，艹
                                        if (db.TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == matType && ((beginTime>=p.PlanBeginTime && beginTime <=p.PlanEndTime) || (endTime>=p.PlanBeginTime && endTime<=p.PlanEndTime)) )> 0)
                                        {
                                            info2 += i + ",";
                                            shibai++;
                                            continue;
                                        }
                                        //判断是否有重复项，重复项则更新，不重复则新增
                                        if (db.TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == matType && p.PlanBeginTime == beginTime && p.PlanEndTime == endTime) > 0)
                                        {
                                            //有重复项
                                            var erp = db.TB_ProductionPlanFromERP.First(p => p.TB_MaterialInfo.TypeCode == matType && p.PlanBeginTime == beginTime && p.PlanEndTime == endTime);
                                            erp.PlanAmount = planAmount;
                                            erp.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                            erp.ImportDate = DateTime.Now;
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            //没有
                                            //保存到数据库
                                            TB_ProductionPlanFromERP erp = new TB_ProductionPlanFromERP();
                                            erp.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == matType);
                                            erp.PlanAmount = planAmount;
                                            erp.PlanBeginTime = beginTime;
                                            erp.PlanEndTime = endTime;
                                            erp.PlanDepartment = department;
                                            erp.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                            erp.ImportDate = DateTime.Now;
                                            db.TB_ProductionPlanFromERP.AddObject(erp);
                                            db.SaveChanges();
                                        }
                                        chenggong++;
                                    }
                                    catch (Exception ex)
                                    {
                                        info += i + ",";
                                        shibai++;
                                        SystemLogHelper.WriteSysLogHelper("导入ERP生产计划失败，第" + i + "行,详情" + ex.ToString(), user.ID, "ERP导入");
                                    }
                                }
                            }
                            MessageBox.Show("操作完成！详细结果请查看输出文本！");
                            txt_InfoShow.AppendText(DateTime.Now.ToShortTimeString() + ":" + "共导入" + totle.ToString() + "条数据，成功" + chenggong.ToString() + "条,失败" + shibai.ToString() + "条；其中第" + info + "导入失败；第" + info2 + "条时间段数据与其他记录有冲突。失败可能原因为当前系统中不存在此类型号编码！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生未知系统异常！详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("发生未知系统异常" + ex.ToString(), user.ID, "ERP导入");
                    }
                }
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
