using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;
using XinYa.Model;
using XinYa.BLL;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_WorkTimeStatistics : Form
    {
        /// <summary>
        /// 当前系统用户
        /// </summary>
        TB_User user;

        /// <summary>
        /// 用于记录工人工时统计输出
        /// </summary>
        List<WorkerTime> list_worktime;

        public frm_WorkTimeStatistics(TB_User user)
        {
            InitializeComponent();
            dgv_Main.AutoGenerateColumns = false;
            this.user = user;
        }

        /// <summary>
        /// 统计（未排除管理员，异常泵未算入工时）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Satistics_Click(object sender, EventArgs e)
        {
            //首先获取指定日期值
            DateTime begintime = dtp_BeginTime.Value;
            DateTime endtime = dtp_EndTime.Value;
            if (begintime.CompareTo(endtime) > 0)
            {
                MessageBox.Show("开始时间不应晚于结束时间");
            }
            else
            {
                if (list_worktime != null)
                {
                    if (MessageBox.Show("当前操作会先清除掉前一次的工时统计数据", "注意", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        list_worktime = new List<WorkerTime>();
                    }
                }
                else
                {
                    list_worktime = new List<WorkerTime>();
                }
                Changeprobar(true);
                Application.DoEvents();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //首先获取全部员工信息(这里是否要排除管理员？)
                        var users = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                        List<TB_User> list_user = users;
                        //如果指定了员工，则先筛选
                        if (check_IsSelectWorker.Checked)
                        {
                            string[] str = txt_Select.Text.Trim().TrimEnd(';').Split(';');
                            //对用户进行一次筛选
                            list_user = new List<TB_User>();
                            foreach (var item in users)
                            {
                                if (str.Contains(item.UserID))
                                {
                                    list_user.Add(item);
                                }
                            }
                        }

                        //遍历员工统计工时
                        foreach (var item in list_user)
                        {
                            //新建一个工时类用于记录当前用户数据
                            WorkerTime perworktime = new WorkerTime();
                            perworktime.workName = item.UserName;
                            perworktime.workNumber = item.UserID;
                            perworktime.workTime = 0;
                            //记录下时间
                            perworktime.beginTime = begintime;
                            perworktime.endTime = endtime;

                            #region 工艺路线记录工时统计（这里包含了QC台）（需要对调试的任务QC不合格的一个排除，14.12.3完成）
                            //根据用户查找他的任务工艺路线记录
                            //如果有
                            if (item.TB_WorkDtlForEachStation.Count > 0)
                            {
                                foreach (var item2 in item.TB_WorkDtlForEachStation.ToList())
                                {
                                    //对这个任务工艺路线记录做一个时间上的筛选
                                    //满足开始时间大于选定开始时间，结束时间小于选定结束时间
                                    //可以以结束时间为标准
                                    //这里要对空值做一个处理
                                    if (item2.WorkEndTime == null)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //需要对质检不合格的做一个处理
                                        //先看有没有
                                        if (db.TB_QCRecord.Count(p=>p.TB_WorkDtlForEachStation.ID==item2.ID)>0)
                                        {
                                            //有，判断他是否合格
                                            //正常情况下只有一条这样的数据
                                            try
                                            {
                                                var qcRecordForItem2 = db.TB_QCRecord.Single(p => p.TB_WorkDtlForEachStation.ID == item2.ID);
                                                if (qcRecordForItem2.IsQualified==true)//质检合格则加载工时
                                                {
                                                    if (item2.WorkEndTime.Value.CompareTo(begintime) >= 0 && item2.WorkEndTime.Value.CompareTo(endtime) <= 0)
                                                    {
                                                        if (item2.TB_WorkMain.TB_WorkDtl.Count > 0)
                                                        {
                                                            //查找他所做过的每一条主任务的子任务
                                                            foreach (var item3 in item2.TB_WorkMain.TB_WorkDtl)
                                                            {
                                                                //筛选，这条子任务不能是出异常了的
                                                                if (item3.IsException == true)
                                                                {
                                                                    continue;
                                                                }
                                                                else
                                                                {
                                                                    try
                                                                    {
                                                                        //如果这条子任务没有异常,则找到他所对应的工时表在当前这条主任务路线记录的工位上的工时
                                                                        perworktime.workTime += decimal.Round(decimal.Parse(item3.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == item2.TB_SecondWorkStationInfo.ID).ToList()[0].WorkTimePerMaterial.ToString()), 2);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        //一般情况下不会出异常，如果出异常则可能为新录入的物料没有及时的编辑好工时，导致tolist异常
                                                                        //这种情况下，工时记为0
                                                                        perworktime.workTime += 0;
                                                                        //同时写入系统日志
                                                                        SystemLogHelper.WriteSysLogHelper("物料没有编辑工时数据" + ex.ToString(), user.ID, "工时统计");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                //正常情况下是一条数据
                                                //万一如果这里出异常了，不做工时加载处理
                                            }
                                        }
                                        else //如果没有QC记录则当做合格处理，本身非调试台的就不需要判定是否合格
                                        {
                                            if (item2.WorkEndTime.Value.CompareTo(begintime) >= 0 && item2.WorkEndTime.Value.CompareTo(endtime) <= 0)
                                            {
                                                if (item2.TB_WorkMain.TB_WorkDtl.Count > 0)
                                                {
                                                    //查找他所做过的每一条主任务的子任务
                                                    foreach (var item3 in item2.TB_WorkMain.TB_WorkDtl)
                                                    {
                                                        //筛选，这条子任务不能是出异常了的
                                                        if (item3.IsException == true)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                //如果这条子任务没有异常,则找到他所对应的工时表在当前这条主任务路线记录的工位上的工时
                                                                //perworktime.workTime += (double)item3.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == item2.TB_SecondWorkStationInfo.ID).ToList()[0].WorkTimePerMaterial;
                                                                  perworktime.workTime += decimal.Round(decimal.Parse(item3.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == item2.TB_SecondWorkStationInfo.ID).ToList()[0].WorkTimePerMaterial.ToString()),2);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                //一般情况下不会出异常，如果出异常则可能为新录入的物料没有及时的编辑好工时，导致tolist异常
                                                                //这种情况下，工时记为0
                                                                perworktime.workTime += 0;
                                                                //同时写入系统日志
                                                                SystemLogHelper.WriteSysLogHelper("物料没有编辑工时数据" + ex.ToString(), user.ID, "工时统计");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            } 
                            #endregion

                            #region 14.11.10 新增对扫码打码数据记录工时记录
                            
                            //判断该员工有没有扫码打码处的记录
                            if (item.TB_ScanRecord.Count > 0)
                            {
                                //对每一条记录进行遍历计算工时
                                item.TB_ScanRecord.Load();
                                foreach (var item2 in item.TB_ScanRecord)
                                {
                                    //这里对异常泵做一次判断（有点多余，但还是做吧！）
                                    if (item2.TB_WorkDtl.IsException == true)
                                    {
                                        continue;
                                    }
                                    else if(item2.ScanDate.CompareTo(begintime)>=0&&item2.ScanDate.CompareTo(endtime)<=0) //扫描时间要介于开始和结束时间之内才算是符合条件
                                    {
                                        try
                                        {
                                            //如果这条子任务没有异常,则找到他所对应的工时表在当前这条主任务路线记录的工位上的工时
                                            //perworktime.workTime += (double)item2.TB_WorkDtl.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == item2.TB_SecondWorkStationInfo.ID).ToList()[0].WorkTimePerMaterial;
                                              perworktime.workTime += decimal.Round(decimal.Parse(item2.TB_WorkDtl.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == item2.TB_SecondWorkStationInfo.ID).ToList()[0].WorkTimePerMaterial.ToString()),2);
                                        }
                                        catch (Exception ex)
                                        {
                                            //一般情况下不会出异常，如果出异常则可能为新录入的物料没有及时的编辑好工时，导致tolist异常
                                            //这种情况下，工时记为0
                                            perworktime.workTime += 0;
                                            //同时写入系统日志
                                            SystemLogHelper.WriteSysLogHelper("物料没有编辑工时数据" + ex.ToString(), user.ID, "工时统计");
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region 返修记录工时

                            //是否有返修记录
                            if (item.TB_RepairRecord.Count()>0)
                            {
                                item.TB_RepairRecord.Load();
                                foreach (var item2 in item.TB_RepairRecord)
                                {
                                    //这里对时间的处理以完成时间为准
                                    if (item2.EndTime.Value.CompareTo(begintime)>0&&item2.EndTime.Value.CompareTo(endtime)<0)
                                    {
                                        //这里指定返修区ID142.
                                        //perworktime.workTime += (double)item2.TB_WorkDtl.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID ==142 ).ToList()[0].WorkTimePerMaterial;
                                        perworktime.workTime += decimal.Round(decimal.Parse(item2.TB_WorkDtl.TB_MaterialInfo.TB_WorkTime.Where(p => p.TB_SecondWorkStationInfo.ID == 142).ToList()[0].WorkTimePerMaterial.ToString()),2);
                                    }
                                }
                            }

                            #endregion

                            //统计完一个员工后，将其加入list集合
                            list_worktime.Add(perworktime);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("在统计工时时发生特定于网络或存储数据的异常！");
                        SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "工时统计");
                    }
                }
                //所有员工统计完成后，加载dgv显示
                dgv_Main.DataSource = list_worktime;
                Changeprobar(false);
            }
        }

        /// <summary>
        /// 员工选择，输入工号、半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Select_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 弹框选择员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            frm_UserSelectHelper userselecthelper = new frm_UserSelectHelper(1);
            userselecthelper.Tag = this;
            userselecthelper.ShowDialog();
        }

        /// <summary>
        /// 数据导出测试
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
