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
using XinYa.Model;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_HistoryWorkRecordSer : Form
    {
        #region 窗体属性与时间及杂项
        TB_User user;
        public frm_HistoryWorkRecordSer(TB_User user)
        {
            InitializeComponent();
            dgv_Main.AutoGenerateColumns = false;
            //dgv_QCRecord.AutoGenerateColumns = false;
            dgv_ScanRecord.AutoGenerateColumns = false;
            dgv_Fanxiu.AutoGenerateColumns = false;
            dgv_WorkRecord.AutoGenerateColumns = false;

            this.user = user;
        }

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Workerman_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
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

        /// <summary>
        /// 加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Main.Rows[e.RowIndex].DataBoundItem != null) && (dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
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

        /// <summary>
        /// dgv_WorkRecord加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkRecord.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkRecord.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkRecord.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkRecord.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        if (obj == null)
                        {
                            e.Value = "";
                        }
                        else
                        {
                            e.Value = result.ToString();//拿到对应的值
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// dgv_Fanxiu加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Fanxiu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Fanxiu.Rows[e.RowIndex].DataBoundItem != null) && (dgv_Fanxiu.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_Fanxiu.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_Fanxiu.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        if (obj == null)
                        {
                            e.Value = "";
                        }
                        else
                        {
                            e.Value = result.ToString();//拿到对应的值
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// dgv_ScanRecord加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ScanRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_ScanRecord.Rows[e.RowIndex].DataBoundItem != null) && (dgv_ScanRecord.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_ScanRecord.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_ScanRecord.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        if (obj == null)
                        {
                            e.Value = "";
                        }
                        else
                        {
                            e.Value = result.ToString();//拿到对应的值
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        } 
        #endregion

        #region 数据逻辑处理
        /// <summary>
        /// 指定员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectWorker_Click(object sender, EventArgs e)
        {
            frm_UserSelectHelper a = new frm_UserSelectHelper(5);
            a.Tag = this;
            a.ShowDialog();
        }

        /// <summary>
        /// 单击事件,加载对应员工的所有工作记录
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Main.CurrentRow != null && dgv_Main.CurrentRow.Cells["c_ID"].Value != null)
            {
                Changeprobar(true);
                Application.DoEvents();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //一共4张表，任务的工艺路线记录、QC记录、返修记录、扫描贴码记录
                    //通用任务工艺路线，需要建立model类
                    //未完...
                    //处理过程：
                    //首先找到这个人
                    int userid = (int)dgv_Main.CurrentRow.Cells["c_ID"].Value;
                    var worker = db.TB_User.Single(p => p.ID == userid);

                    #region 通用工作记录

                    //通用工作记录
                    //1.通过员工找关联的任务工艺路线记录、找到后筛选QC不合格的，对于没有QC记录的作为QC合格处理（你没QC我也不知道到底何不合格啊！）
                    //2.用模型类承载找出的数据，需要记录工作的工位，关联的工时  
                    //数据承载list
                    List<WorkDtlWithBengsWorkStationWorkTime> list_CommonWorkRecord = new List<WorkDtlWithBengsWorkStationWorkTime>();
                    if (worker.TB_WorkDtlForEachStation.Count > 0)//有记录
                    {
                        var eachWork = worker.TB_WorkDtlForEachStation.ToList();
                        List<TB_WorkDtlForEachStation> workForEachStation = new List<TB_WorkDtlForEachStation>();
                        //筛选合格的
                        foreach (var item in eachWork)
                        {
                            //!(有记录且不合格)
                            if (db.TB_QCRecord.Count(p => p.TB_WorkDtlForEachStation.ID == item.ID && p.IsQualified == false) == 0)
                            {
                                if (check_Time.Checked)
                                {
                                    if ((item.WorkEndTime == null && item.WorkBeginTime == null)
                                        || (item.WorkBeginTime == null && item.WorkEndTime != null && item.WorkEndTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.WorkEndTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                                        || (item.WorkEndTime == null && item.WorkBeginTime != null && item.WorkBeginTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.WorkBeginTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                                        || (item.WorkBeginTime != null && item.WorkEndTime != null && item.WorkBeginTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.WorkEndTime.Value.CompareTo(dtp_EndTime.Value) < 0))
                                    {
                                        workForEachStation.Add(item);
                                    }
                                }
                                else
                                {
                                    workForEachStation.Add(item);
                                }
                            }
                        }
                        //遍历筛选后的结果
                        foreach (var item in workForEachStation)
                        {
                            //是否指定了时间
                            //if (check_Time.Checked)
                            //{
                            #region MyRegion
                            //    if ((item.WorkEndTime == null && item.WorkBeginTime == null)
                            //                                || (item.WorkBeginTime == null && item.WorkEndTime != null && item.WorkEndTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.WorkEndTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                            //                                || (item.WorkEndTime == null && item.WorkBeginTime != null && item.WorkBeginTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.WorkBeginTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                            //                                )
                            //    {
                            //        //遍历子任务
                            //        foreach (var item2 in item.TB_WorkMain.TB_WorkDtl)
                            //        {
                            //            //如果没有异常，或者异常是自己录入的
                            //            if (item2.IsException == false || (item2.IsException == true && item2.TB_User.ID == worker.ID))
                            //            {
                            //                //记录
                            //                WorkDtlWithBengsWorkStationWorkTime record = new WorkDtlWithBengsWorkStationWorkTime();
                            //                //子任务
                            //                record.workDtl = item2;
                            //                //工作工位名
                            //                record.workStation = item.TB_SecondWorkStationInfo.SecondWorkStationName;
                            //                //员工名
                            //                record.userName = worker.UserName;

                            //                if (item.WorkBeginTime != null)
                            //                {
                            //                    record.beginTime = item.WorkBeginTime.Value.ToString();
                            //                }
                            //                else
                            //                {
                            //                    record.beginTime = "";
                            //                }

                            //                if (item.WorkEndTime != null)
                            //                {
                            //                    record.endTime = item.WorkEndTime.Value.ToString();
                            //                }
                            //                else
                            //                {
                            //                    record.endTime = "";
                            //                }

                            //                //工时
                            //                if (item2.IsException == true)
                            //                {
                            //                    //有异常的泵的工时为0
                            //                    record.workTime = "0";
                            //                }
                            //                else
                            //                {
                            //                    try
                            //                    {
                            //                        record.workTime = item2.TB_MaterialInfo.TB_WorkTime.Single(p => p.TB_SecondWorkStationInfo.ID == item.TB_SecondWorkStationInfo.ID).WorkTimePerMaterial.ToString();
                            //                    }
                            //                    catch
                            //                    {
                            //                        //如果没有
                            //                        record.workTime = "无";
                            //                    }
                            //                }
                            //                list_CommonWorkRecord.Add(record);
                            //            }
                            //        }
                            //    }
                            //}
                            //else
                            //{ 
                            #endregion
                            //遍历子任务
                            foreach (var item2 in item.TB_WorkMain.TB_WorkDtl)
                            {
                                //如果没有异常，或者异常是自己录入的
                                if (item2.IsException == false || (item2.IsException == true && item2.TB_User.ID == worker.ID))
                                {
                                    //记录
                                    WorkDtlWithBengsWorkStationWorkTime record = new WorkDtlWithBengsWorkStationWorkTime();
                                    //子任务
                                    record.workDtl = item2;
                                    //工作工位名
                                    record.workStation = item.TB_SecondWorkStationInfo.SecondWorkStationName;
                                    //员工名
                                    record.userName = worker.UserName;

                                    if (item.WorkBeginTime != null)
                                    {
                                        record.beginTime = item.WorkBeginTime.Value.ToString();
                                    }
                                    else
                                    {
                                        record.beginTime = "";
                                    }

                                    if (item.WorkEndTime != null)
                                    {
                                        record.endTime = item.WorkEndTime.Value.ToString();
                                    }
                                    else
                                    {
                                        record.endTime = "";
                                    }

                                    //工时
                                    if (item2.IsException == true)
                                    {
                                        //有异常的泵的工时为0
                                        record.workTime = "0";
                                    }
                                    else
                                    {
                                        try
                                        {
                                            record.workTime = item2.TB_MaterialInfo.TB_WorkTime.Single(p => p.TB_SecondWorkStationInfo.ID == item.TB_SecondWorkStationInfo.ID).WorkTimePerMaterial.ToString();
                                        }
                                        catch
                                        {
                                            //如果没有
                                            record.workTime = "无";
                                        }
                                    }
                                    list_CommonWorkRecord.Add(record);
                                }
                                //}
                            }

                        }
                    }

                    //加载完全
                    foreach (var item in list_CommonWorkRecord)
                    {
                        item.workDtl.TB_ExceptionReference.Load();
                        item.workDtl.TB_MaterialInfoReference.Load();
                    }
                    dgv_WorkRecord.DataSource = list_CommonWorkRecord;

                    #endregion

                    #region QC记录(暂不考虑)



                    #endregion

                    #region 返修区

                    List<WorkDtlWithRepairRecord> list_RepairRecord = new List<WorkDtlWithRepairRecord>();
                    List<TB_RepairRecord> list_repairRecord = new List<TB_RepairRecord>();
                    if (worker.TB_RepairRecord.Count > 0)
                    {
                        //如果有返修记录
                        var a = worker.TB_RepairRecord.ToList();
                        if (check_Time.Checked)
                        {
                            foreach (var item in a)
                            {
                                if ((item.BeginTime == null && item.EndTime == null)
                                    || (item.BeginTime == null && item.EndTime != null && item.EndTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.EndTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                                    || (item.EndTime == null && item.BeginTime != null && item.BeginTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.BeginTime.Value.CompareTo(dtp_EndTime.Value) < 0)
                                    || (item.BeginTime != null && item.EndTime != null && item.BeginTime.Value.CompareTo(dtp_BeginTime.Value) > 0 && item.EndTime.Value.CompareTo(dtp_EndTime.Value) < 0))
                                {
                                    list_repairRecord.Add(item);
                                }
                            }
                        }
                        else
                        {
                            list_repairRecord = a;
                        }
                    }
                    foreach (var item in list_repairRecord)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_UserReference.Load();
                    }
                    foreach (var item in list_repairRecord)
                    {
                        WorkDtlWithRepairRecord repairRecord = new WorkDtlWithRepairRecord();
                        repairRecord.RepairRecord = item;
                        try
                        {
                            string a = item.TB_WorkDtl.MaterialCode.Substring(0, 12);
                            repairRecord.WorkTime = db.TB_MaterialInfo.Single(p => p.TypeCode == a).TB_WorkTime.Single(p => p.TB_SecondWorkStationInfo.ID == 142).WorkTimePerMaterial.ToString();
                        }
                        catch
                        {
                            //如果没有
                            repairRecord.WorkTime = "无";
                        }
                        list_RepairRecord.Add(repairRecord);
                    }
                    dgv_Fanxiu.DataSource = list_RepairRecord;

                    #endregion

                    #region 扫描打码记录

                    List<TB_ScanRecord> list_scanRecord = new List<TB_ScanRecord>();
                    List<WorkDtlWithScanRecord> list_ScanRecord = new List<WorkDtlWithScanRecord>();
                    if (worker.TB_ScanRecord.Count > 0)
                    {
                        if (check_Time.Checked)
                        {
                            list_scanRecord = worker.TB_ScanRecord.Where(p => p.ScanDate.CompareTo(dtp_BeginTime.Value) > 0 && p.ScanDate.CompareTo(dtp_EndTime.Value) < 0).ToList();
                        }
                        else
                        {
                            list_scanRecord = worker.TB_ScanRecord.ToList();
                        }
                    }
                    foreach (var item in list_scanRecord)
                    {
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlReference.Load();
                        item.TB_WorkDtl.TB_MaterialInfoReference.Load();
                    }
                    foreach (var item in list_scanRecord)
                    {
                        WorkDtlWithScanRecord scanRecord = new WorkDtlWithScanRecord();
                        scanRecord.ScanRecord = item;
                        try
                        {
                            scanRecord.WorkTime = item.TB_WorkDtl.TB_MaterialInfo.TB_WorkTime.Single(p => p.TB_SecondWorkStationInfo.ID == item.TB_SecondWorkStationInfo.ID).WorkTimePerMaterial.ToString();
                        }
                        catch
                        {
                            //如果没有
                            scanRecord.WorkTime = "无";
                        }
                        list_ScanRecord.Add(scanRecord);
                    }
                    dgv_ScanRecord.DataSource = list_ScanRecord;

                    #endregion
                }
                Changeprobar(false);
            }
        }

        /// <summary>
        /// 确认查询,加载员工列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                List<TB_User> list_User = new List<TB_User>();
                //判断是否指定了员工
                if (check_Worker.Checked)
                {
                    string[] str_user = txt_Workerman.Text.Trim().TrimEnd(';').Split(';');
                    foreach (var item in str_user)
                    {
                        try
                        {
                            var a = db.TB_User.Single(p => p.UserID == item);
                            list_User.Add(a);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    list_User = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                }
                dgv_Main.DataSource = list_User;
            }

            Changeprobar(false);
        } 
        #endregion      

        #region 数据导出

        /// <summary>
        /// 导出通用工作记录
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btn_OutputCommonRecord_Click(object sender, EventArgs e)
        {
            BllHelp.DataOutport(dgv_WorkRecord);
        }

        /// <summary>
        /// 导出返修记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputRepairRecord_Click(object sender, EventArgs e)
        {
            BllHelp.DataOutport(dgv_Fanxiu);
        }

        /// <summary>
        /// 导出扫码打码记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputScanRecord_Click(object sender, EventArgs e)
        {
            BllHelp.DataOutport(dgv_ScanRecord);
        } 
        #endregion
    }
}
