using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;
using XinYa.Model;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_QualifiedRateStatistics : Form
    {
        private TB_User user;

        public frm_QualifiedRateStatistics(TB_User user)
        {
            InitializeComponent();
            //cbx_LinNum.SelectedIndex = 0;
            this.user = user;
            this.dgv_ZhuangpeiShaixuan.AutoGenerateColumns = false;
            this.dgv_Tiaoshishaixuan.AutoGenerateColumns = false;
            this.dgv_FanxiuExceptionShow.AutoGenerateColumns = false;
            this.dgv_FanxiuShaixuan.AutoGenerateColumns = false;
        }

        #region 数据导出与公共函数

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
        /// 装配合格率数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ZhuangpeiOutportData_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Zhuangpeihegelv.RowCount <= 0 || dgv_Zhuangpeihegelv.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Zhuangpeihegelv) == 0)
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

        /// <summary>
        /// 调试合格率数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TiaoshiOutputData_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Tiaoshihegelv.RowCount <= 0 || dgv_Tiaoshihegelv.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Tiaoshihegelv) == 0)
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

        /// <summary>
        /// 返修合格率数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FanxiuOutputData_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Fanxiuhegelv.RowCount <= 0 || dgv_Fanxiuhegelv.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Fanxiuhegelv) == 0)
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

        #endregion

        #region 装配合格率统计

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Matcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 物料选择帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            frm_MaterialSelectHelper mathelper = new frm_MaterialSelectHelper(1);
            mathelper.Tag = this;
            mathelper.ShowDialog();
        }

        /// <summary>
        /// 装配合格率统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ZhuangpeiStatistics_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            #region 条件及数据定义

            DateTime beginTime = new DateTime();
            DateTime endTime = new DateTime();
            string lineNum = "";
            string matCodes = "";
            string[] matCodess;
            List<TB_WorkDtl> list_bengs = null;

            //装配合格数据（指定型号）
            List<QualifiedRate_Zhuangpei_Mat> list_Zhuangpei_Mat = new List<QualifiedRate_Zhuangpei_Mat>();

            //装配合格数据（指定装配线号）
            List<QualifiedRate_Zhuangpei_LineNum> list_Zhuangpei_LineNum = new List<QualifiedRate_Zhuangpei_LineNum>();

            #endregion 条件及数据定义

            #region 装配线号提供多选,这里做一个处理

            if (check_A.Checked)
            {
                lineNum += "A";
            }
            if (check_B.Checked)
            {
                lineNum += "B";
            }
            if (check_C.Checked)
            {
                lineNum += "C";
            }

            #endregion 装配线号提供多选,这里做一个处理

            #region 统计处理

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //先将所有的从A处扫描了的泵加载到内存
                    var bengs = db.TB_WorkDtl.Where(p => p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "A").ToList();
                    //时间
                    if (check_ZhangpeiTime.Checked)
                    {
                        beginTime = dtp_ZhuangpeiBeginTime.Value;
                        endTime = dtp_ZhuangpeiEndTime.Value;
                        if (list_bengs == null)
                        {
                            list_bengs = new List<TB_WorkDtl>();
                            //筛选
                            foreach (var item in bengs)
                            {
                                if (item.CreateDate.CompareTo(beginTime) >= 0 && item.CreateDate.CompareTo(endTime) <= 0)//在这段时间内
                                {
                                    list_bengs.Add(item);
                                }
                            }
                        }
                    }
                    //线号
                    if (lineNum != "")
                    {
                        //第13位是装配线号
                        if (list_bengs == null)//说明没有经过时间筛选
                        {
                            list_bengs = new List<TB_WorkDtl>();
                            foreach (var item in bengs)
                            {
                                if (lineNum.Contains(item.MaterialCode.Substring(12, 1)))
                                {
                                    list_bengs.Add(item);
                                }
                            }
                        }
                        else
                        {
                            //说明经过了时间筛选，list_bengs存储筛选后的结果
                            bengs.Clear();
                            bengs = list_bengs;
                            list_bengs.Clear();
                            foreach (var item in bengs)
                            {
                                if (lineNum.Contains(item.MaterialCode.Substring(12, 1)))
                                {
                                    list_bengs.Add(item);
                                }
                            }
                        }
                    }
                    //是否指定物料
                    if (check_ZhuangpeiMatCode.Checked)
                    {
                        matCodes = txt_Matcode.Text;
                        matCodess = matCodes.Trim().TrimEnd(';').Split(';');
                        //去重
                        List<string> listString = new List<string>();
                        foreach (string eachString in matCodess)
                        {
                            if (!listString.Contains(eachString))
                                listString.Add(eachString);
                        }
                        matCodess = listString.ToArray();
                        //指定则统计特定物料的合格率
                        if (list_bengs == null)
                        {
                            //为空表示前面时间和线号都没有选择，统计基数为所有的泵bengs
                            list_bengs = bengs;

                            #region MyRegion

                            //for (int i = 0; i < matCodess.Length; i++)
                            //{
                            //    QualifiedRate_Zhuangpei_Mat qzm = new QualifiedRate_Zhuangpei_Mat();
                            //    qzm.物料型号 = matCodess[i];
                            //    qzm.装配总数 = bengs.Count(p => p.TB_MaterialInfo.TypeCode == matCodess[i]);
                            //    qzm.异常数 = bengs.Count(p => p.TB_MaterialInfo.TypeCode == matCodess[i] && p.IsException == true);
                            //    if (qzm.装配总数 == 0)
                            //    {
                            //        qzm.合格率 = "无";
                            //    }
                            //    else
                            //    {
                            //        //保留2位小数
                            //        qzm.合格率 = Math.Round(Math.Round(((decimal)qzm.装配总数 - (decimal)qzm.异常数) / (decimal)qzm.装配总数, 4) * 100, 2) + "%";
                            //    }

                            //    //统计基数
                            //    if (lineNum!="")
                            //    {
                            //        qzm.统计基础 = lineNum+"号装配线";
                            //    }
                            //    else
                            //    {
                            //        qzm.统计基础 = "ABC" + "号装配线";
                            //    }

                            //    //时间
                            //    if (check_Time.Checked)
                            //    {
                            //        qzm.开始时间 = beginTime;
                            //        qzm.结束时间 = endTime;
                            //    }

                            //    list_Zhuangpei_Mat.Add(qzm);
                            //}
                            ////加载筛选结果到dgv
                            //dgv_ZhuangpeiShaixuan.DataSource = bengs;

                            #endregion MyRegion
                        }
                        //不为空则表示已经经历过前面的筛选，统计基数为筛选后的泵list_bengs
                        for (int i = 0; i < matCodess.Length; i++)
                        {
                            QualifiedRate_Zhuangpei_Mat qzm = new QualifiedRate_Zhuangpei_Mat();
                            qzm.物料型号 = matCodess[i];
                            qzm.装配总数 = list_bengs.Count(p => p.TB_MaterialInfo.TypeCode == matCodess[i]);
                            qzm.异常数 = list_bengs.Count(p => p.TB_MaterialInfo.TypeCode == matCodess[i] && p.IsException == true);
                            if (qzm.装配总数 == 0)
                            {
                                qzm.合格率 = "无";
                            }
                            else
                            {
                                //保留2位小数
                                qzm.合格率 = Math.Round(Math.Round(((double)qzm.装配总数 - (double)qzm.异常数) / (double)qzm.装配总数, 4) * 100, 2) + "%";
                            }

                            //统计基数
                            if (lineNum != "")
                            {
                                qzm.统计基础 = lineNum + "号装配线";
                            }
                            else
                            {
                                qzm.统计基础 = "ABC" + "号装配线";
                            }

                            //时间
                            if (check_ZhangpeiTime.Checked)
                            {
                                qzm.开始时间 = beginTime;
                                qzm.结束时间 = endTime;
                            }
                            list_Zhuangpei_Mat.Add(qzm);
                        }
                        //加载筛选结果到dgv
                        //先将这个加载完全
                        foreach (var item in list_bengs)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            item.TB_UserReference.Load();
                            item.TB_WorkMainReference.Load();
                            item.TB_WorkMain.TB_SecondWorkStationInfoReference.Load();
                        }
                        dgv_ZhuangpeiShaixuan.DataSource = list_bengs;

                        //加载统计结果到dgv
                        dgv_Zhuangpeihegelv.DataSource = list_Zhuangpei_Mat;
                    }
                    else
                    {
                        //不指定型号则统计装配线的合格率
                        if (lineNum == "")
                        {
                            lineNum = "ABC";
                        }
                        if (list_bengs == null)
                        {
                            //说明没有经过前面的时间和装配线号筛选，统计基数为bengs
                            list_bengs = bengs;
                        }
                        //统计处理，对象 lineNum，list_bengs
                        List<Char> list_lineNum = lineNum.ToList();
                        foreach (var item in list_lineNum)
                        {
                            QualifiedRate_Zhuangpei_LineNum qzl = new QualifiedRate_Zhuangpei_LineNum();
                            qzl.装配线号 = item.ToString();
                            qzl.装配总数 = list_bengs.Count(p => p.MaterialCode.Substring(12, 1) == item.ToString());
                            qzl.异常总数 = list_bengs.Count(p => p.MaterialCode.Substring(12, 1) == item.ToString() && p.IsException == true);
                            if (qzl.装配总数 == 0)
                            {
                                qzl.合格率 = "无";
                            }
                            else
                            {
                                //保留2位小数
                                qzl.合格率 = Math.Round(Math.Round(((double)qzl.装配总数 - (double)qzl.异常总数) / (double)qzl.装配总数, 4) * 100, 2) + "%";
                            }

                            //时间处理
                            if (check_ZhangpeiTime.Checked)
                            {
                                qzl.开始时间 = beginTime;
                                qzl.结束时间 = endTime;
                            }
                            //加入
                            list_Zhuangpei_LineNum.Add(qzl);
                        }
                        //赋值处理
                        //先将这个加载完全
                        foreach (var item in list_bengs)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            item.TB_UserReference.Load();
                            item.TB_WorkMainReference.Load();
                            item.TB_WorkMain.TB_SecondWorkStationInfoReference.Load();
                        }
                        dgv_ZhuangpeiShaixuan.DataSource = list_bengs;
                        dgv_Zhuangpeihegelv.DataSource = list_Zhuangpei_LineNum;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("统计出现异常！详情请查看日志！");
                    SystemLogHelper.WriteSysLogHelper("装配合格率统计出现异常！详情" + ex.ToString(), user.ID, "装配合格率统计");
                    Changeprobar(false);
                }
            }

            #endregion 统计处理

            Changeprobar(false);
        }

        /// <summary>
        /// 装配筛选加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ZhuangpeiShaixuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_ZhuangpeiShaixuan.Rows[e.RowIndex].DataBoundItem != null) && (dgv_ZhuangpeiShaixuan.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_ZhuangpeiShaixuan.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_ZhuangpeiShaixuan.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        #endregion 装配合格率统计

        #region 调试合格率统计

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_WorkerMan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 调试统计单击事件，用于加载指定员工的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Tiaoshihegelv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Tiaoshihegelv.CurrentRow != null && dgv_Tiaoshihegelv.CurrentRow.Cells[0] != null && dgv_Tiaoshihegelv.CurrentRow.Cells[1] != null)
            {
                Changeprobar(true);
                Application.DoEvents();
                //如果有数据
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //找出这个员工
                        string userID = dgv_Tiaoshihegelv.CurrentRow.Cells[0].Value.ToString();
                        string userName = dgv_Tiaoshihegelv.CurrentRow.Cells[1].Value.ToString();
                        var worker = db.TB_User.Single(p => p.UserID == userID && p.UserName == userName);
                        List<TB_QCRecord> List_QcRecord = new List<TB_QCRecord>();
                        if (dgv_Tiaoshihegelv.CurrentRow.Cells["开始时间"].Value.ToString() != "0001/1/1 0:00:00" && dgv_Tiaoshihegelv.CurrentRow.Cells["结束时间"].Value.ToString() != "0001/1/1 0:00:00")
                        {
                            DateTime begin = (DateTime)dgv_Tiaoshihegelv.CurrentRow.Cells["开始时间"].Value;
                            DateTime end = (DateTime)dgv_Tiaoshihegelv.CurrentRow.Cells["结束时间"].Value;
                            //表示指定了时间
                            List_QcRecord = db.TB_QCRecord.Where(p => p.TB_WorkDtlForEachStation.TB_User.ID == worker.ID && p.TB_WorkDtlForEachStation.WorkEndTime > begin && p.TB_WorkDtlForEachStation.WorkEndTime < end).ToList();
                        }
                        else
                        {
                            //没有指定时间
                            List_QcRecord = db.TB_QCRecord.Where(p => p.TB_WorkDtlForEachStation.TB_User.ID == worker.ID).ToList();
                        }
                        //将数据源加载完全
                        foreach (var item in List_QcRecord)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            item.TB_UserReference.Load();
                            item.TB_WorkDtlForEachStationReference.Load();
                            item.TB_WorkDtlForEachStation.TB_SecondWorkStationInfoReference.Load();
                            item.TB_WorkDtlForEachStation.TB_UserReference.Load();
                            item.TB_WorkDtlForEachStation.TB_WorkMainReference.Load();
                        }
                        dgv_Tiaoshishaixuan.DataSource = List_QcRecord;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载指定员工质检数据出现异常！详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("加载指定员工质检数据出现异常！详情" + ex.ToString(), user.ID, "调试合格率统计");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// dgv_Tiaoshishaixuan加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Tiaoshishaixuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Tiaoshishaixuan.Rows[e.RowIndex].DataBoundItem != null) && (dgv_Tiaoshishaixuan.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_Tiaoshishaixuan.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_Tiaoshishaixuan.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 员工选择助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectWorker_Click(object sender, EventArgs e)
        {
            frm_UserSelectHelper userselecthelper = new frm_UserSelectHelper(2);
            userselecthelper.Tag = this;
            userselecthelper.ShowDialog();
        }

        /// <summary>
        /// 调试合格率处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TiaoshiStatistics_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            #region 统计数据定义

            //记录下筛选后的任务路线记录
            List<TB_WorkDtlForEachStation> list_TB_WorkDtlForEachStation = new List<TB_WorkDtlForEachStation>();

            //记录下员工的合格数据
            List<QualifiedRate_Tiaoshi_Worker> list_Tiaoshi_Worker = new List<QualifiedRate_Tiaoshi_Worker>();

            //用于记录筛选后的员工信息
            List<TB_User> list_Worker = new List<TB_User>();

            //string workers = "";
            //if (check_TiaoshiWorkerMan.Checked)
            //{
            //    workers = txt_WorkerMan.Text;
            //}
            //List<string>  

            #endregion

            #region 统计处理

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //员工加载
                    var worker = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                    //是否指定员工
                    if (check_TiaoshiWorkerMan.Checked)
                    {
                        //如果指定了员工
                        string[] workers = txt_TiaoshiWorkerMan.Text.Trim().TrimEnd(';').Split(';');
                        foreach (var item in worker)
                        {
                            if (workers.Contains(item.UserID))//如果包含了这个工号
                            {
                                list_Worker.Add(item);
                            }
                        }
                    }
                    else
                    {
                        //如果没有指定则加载全部
                        list_Worker = worker;
                    }

                    #region 统计处理，按任务路线记录
                    /*
                    //先查询出任务工艺路线记录在调试台的记录和员工,这条任务必须是做过了的
                    var workMainforEachWorkStation = db.TB_WorkDtlForEachStation.Where(p => p.TB_SecondWorkStationInfo.WorkStationCode == "E" && p.WorkEndTime != null && p.WorkMen != null).ToList();

                    //是否指定了时间
                    if (check_TiaoshiTime.Checked)
                    {
                        foreach (var item in workMainforEachWorkStation)
                        {

                            if (item.WorkEndTime.Value.CompareTo(dtp_TiaoshiBeginTime.Value) >= 0 && item.WorkEndTime.Value.CompareTo(dtp_TiaoshiEndTime.Value) <= 0)//以结束时间为准
                            {
                                list_TB_WorkDtlForEachStation.Add(item);
                            }

                        }
                    }
                    else
                    {
                        list_TB_WorkDtlForEachStation = workMainforEachWorkStation;
                    }
                   
                    //对每一个员工进行统计记录
                    foreach (var item in list_Worker)
                    {
                        QualifiedRate_Tiaoshi_Worker qtw = new QualifiedRate_Tiaoshi_Worker();
                        qtw.员工工号 = item.UserID;
                        qtw.员工姓名 = item.UserName;
                        qtw.QC总数 = 0;
                        qtw.QC不合格数 = 0;
                        //筛选
                        var userworkrecord = list_TB_WorkDtlForEachStation.Where(p => p.TB_User.ID == item.ID).ToList();
                        qtw.QC总数 = userworkrecord.Count;
                        //匹配这些在QC记录中是否有异常
                        //正常情况下一条工艺记录只对应一条QC记录
                        foreach (var item2 in userworkrecord)
                        {
                            if (item2.TB_QCRecord.Count > 0)//如果这条路线记录有QC记录
                            {
                                if (db.TB_QCRecord.First(p => p.TB_WorkDtlForEachStation.ID == item.ID).IsQualified == false)
                                {
                                    qtw.QC不合格数++;
                                }
                            }
                        }
                        if (qtw.QC总数==0)
                        {
                            qtw.调试合格率 = "无";
                        }
                        else
                        {
                            //保留2位小数
                            qtw.调试合格率 = Math.Round(Math.Round(((double)qtw.QC总数 - (double)qtw.QC不合格数) / (double)qtw.QC总数, 4) * 100, 2) + "%";
                        }
                        list_Tiaoshi_Worker.Add(qtw);
                    }
                    //统计完成后加载到dgv
                    dgv_Tiaoshihegelv.DataSource = list_Tiaoshi_Worker;
                    */
                    #endregion

                    #region 统计处理，按QC记录

                    List<TB_QCRecord> qcRecord;
                    //先取出所有记录
                    if (check_TiaoshiTime.Checked)
                    {
                        qcRecord = db.TB_QCRecord.Where(p => p.TB_WorkDtlForEachStation.WorkEndTime > dtp_TiaoshiBeginTime.Value && p.TB_WorkDtlForEachStation.WorkEndTime < dtp_TiaoshiEndTime.Value).ToList();
                    }
                    else
                    {
                        qcRecord = db.TB_QCRecord.ToList();
                    }
                    //对每一个员工进行统计
                    foreach (var item in list_Worker)
                    {
                        QualifiedRate_Tiaoshi_Worker qtw = new QualifiedRate_Tiaoshi_Worker();
                        qtw.员工工号 = item.UserID;
                        qtw.员工姓名 = item.UserName;
                        qtw.QC总数 = qcRecord.Count(p => p.TB_WorkDtlForEachStation.TB_User.ID == item.ID);
                        qtw.QC不合格数 = qcRecord.Count(p => p.TB_WorkDtlForEachStation.TB_User.ID == item.ID && p.IsQualified == true);
                        if (check_TiaoshiTime.Checked)
                        {
                            qtw.开始时间 = dtp_TiaoshiBeginTime.Value;
                            qtw.结束时间 = dtp_TiaoshiEndTime.Value;
                        }
                        if (qtw.QC总数 == 0)
                        {
                            qtw.调试合格率 = "无";
                        }
                        else
                        {
                            //保留2位小数
                            qtw.调试合格率 = Math.Round(Math.Round(((double)qtw.QC总数 - (double)qtw.QC不合格数) / (double)qtw.QC总数, 4) * 100, 2) + "%";

                        }
                        list_Tiaoshi_Worker.Add(qtw);
                    }
                    //显示
                    dgv_Tiaoshihegelv.DataSource = list_Tiaoshi_Worker;
                    foreach (var item in qcRecord)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlForEachStationReference.Load();
                        item.TB_WorkDtlForEachStation.TB_SecondWorkStationInfoReference.Load();
                        item.TB_WorkDtlForEachStation.TB_UserReference.Load();
                        item.TB_WorkDtlForEachStation.TB_WorkMainReference.Load();
                    }
                    dgv_Tiaoshishaixuan.DataSource = qcRecord;

                    #endregion

                }
                catch (Exception ex)
                {
                    MessageBox.Show("统计出现异常！详情请查看日志！");
                    SystemLogHelper.WriteSysLogHelper("调试合格率统计出现异常！详情" + ex.ToString(), user.ID, "调试合格率统计");
                    Changeprobar(false);
                }
            }

            #endregion

            #region 统计处理（按QC记录）

            //using (XinYaDBEntities db=new XinYaDBEntities())
            //{
            //    try
            //    {
            //        List<TB_QCRecord> qcRecord;
            //        //先取出所有记录
            //        if (check_TiaoshiTime.Checked)
            //        {
            //            qcRecord = db.TB_QCRecord.Where(p => p.TB_WorkDtlForEachStation.WorkEndTime > dtp_TiaoshiBeginTime.Value && p.TB_WorkDtlForEachStation.WorkEndTime < dtp_TiaoshiEndTime.Value).ToList();
            //        }
            //        else
            //        {
            //            qcRecord = db.TB_QCRecord.ToList();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("统计出现异常！详情请查看日志！");
            //        SystemLogHelper.WriteSysLogHelper("调试合格率统计出现异常！详情" + ex.ToString(), user.ID, "调试合格率统计");
            //        Changeprobar(false);
            //    }
            //}

            #endregion

            Changeprobar(false);
        }

        #endregion 调试合格率统计

        #region 返修区合格率统计

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_FanxiuWorkerman_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 返修员工选择助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FanxiuSelectWorker_Click(object sender, EventArgs e)
        {
            frm_UserSelectHelper userselecthelper = new frm_UserSelectHelper(3);
            userselecthelper.Tag = this;
            userselecthelper.ShowDialog();
        }

        /// <summary>
        /// 返修统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FanxiuStatistics_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            #region 统计数据定义

            //筛选后的员工信息
            List<TB_User> list_Worker = new List<TB_User>();
            //筛选后的返修记录
            List<TB_RepairRecord> list_RepairRecord = new List<TB_RepairRecord>();
            //记录下员工的合格率信息
            List<QualifiedRate_Fanxiu_Worker> list_QualifiedRate_Fanxiu_Worker = new List<QualifiedRate_Fanxiu_Worker>();

            #endregion

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //员工加载
                    var worker = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                    //是否指定员工
                    if (check_FanxiuWorker.Checked)
                    {
                        //如果指定了员工
                        string[] workers = txt_FanxiuWorkerman.Text.Trim().TrimEnd(';').Split(';');
                        foreach (var item in worker)
                        {
                            if (workers.Contains(item.UserID))//如果包含了这个工号
                            {
                                list_Worker.Add(item);
                            }
                        }
                    }
                    else
                    {
                        //如果没有指定则加载全部
                        list_Worker = worker;
                    }
                    if (check_FanxiuTime.Checked)
                    {
                        //如果指定了时间,这里以返修结束时间为准
                        list_RepairRecord = db.TB_RepairRecord.Where(p => p.EndTime > dtp_FanxiuBeginTime.Value && p.EndTime < dtp_FanxiuEndTime.Value).ToList();
                    }
                    else
                    {
                        list_RepairRecord = db.TB_RepairRecord.ToList();
                    }
                    //统计
                    //对每一个员工进行遍历统计
                    foreach (var item in list_Worker)
                    {
                        QualifiedRate_Fanxiu_Worker qfw = new QualifiedRate_Fanxiu_Worker();
                        qfw.员工工号 = item.UserID;
                        qfw.员工姓名 = item.UserName;
                        //qfw.维修总次数 = list_RepairRecord.Count(p => p.TB_User.ID == item.ID);
                        //改员工的维修次数
                        qfw.维修总次数 = item.TB_RepairRecord.Count;
                        qfw.异常出现次数 = 0;
                        //上线后异常统计
                        if (qfw.维修总次数 == 0)
                        {
                            qfw.返修合格率 = "无";
                        }
                        else
                        {
                            //对该员工的每一个维修的泵的异常累加
                            foreach (var item2 in item.TB_RepairRecord.ToList())
                            {
                                //筛选条件为有过返修记录的、在返修工位重新上线的并且发生了异常的
                                qfw.异常出现次数 += db.TB_WorkDtl.Count(p => p.MaterialCode == item2.TB_WorkDtl.MaterialCode && p.IsException == true && (p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "D" || p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "H"));
                            }
                            //计算合格率
                            //保留2位小数
                            qfw.返修合格率 = Math.Round(Math.Round(((double)qfw.维修总次数 - (double)qfw.异常出现次数) / (double)qfw.维修总次数, 4) * 100, 2) + "%";
                        }
                        if (check_FanxiuTime.Checked)
                        {
                            qfw.开始时间 = dtp_FanxiuBeginTime.Value;
                            qfw.结束时间 = dtp_FanxiuEndTime.Value;
                        }
                        list_QualifiedRate_Fanxiu_Worker.Add(qfw);
                    }
                    //加载dgv
                    dgv_Fanxiuhegelv.DataSource = list_QualifiedRate_Fanxiu_Worker;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("统计出现异常！详情请查看日志！");
                    SystemLogHelper.WriteSysLogHelper("返修合格率统计出现异常！详情" + ex.ToString(), user.ID, "返修合格率统计");
                    Changeprobar(false);
                }

            }

            Changeprobar(false);
        }

        /// <summary>
        /// 返修统计结果单击事件，加载选定人的返修区记录和对应的线上泵体异常情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Fanxiuhegelv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //如果有选定行且该行有数据
            if (dgv_Fanxiuhegelv.CurrentRow != null && dgv_Fanxiuhegelv.CurrentRow.Cells[0] != null && dgv_Fanxiuhegelv.CurrentRow.Cells[1] != null)
            {
                Changeprobar(true);
                Application.DoEvents();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        string userID = dgv_Fanxiuhegelv.CurrentRow.Cells[0].Value.ToString();
                        string userName = dgv_Fanxiuhegelv.CurrentRow.Cells[1].Value.ToString();
                        var worker = db.TB_User.Single(p => p.UserID == userID && p.UserName == userName);
                        List<TB_RepairRecord> list_RepairRecord = new List<TB_RepairRecord>();
                        List<TB_WorkDtl> list_WorkDtl = new List<TB_WorkDtl>();
                        if (dgv_Fanxiuhegelv.CurrentRow.Cells["开始时间"].Value.ToString() != "0001/1/1 0:00:00" && dgv_Fanxiuhegelv.CurrentRow.Cells["结束时间"].Value.ToString() != "0001/1/1 0:00:00")
                        {
                            DateTime begin = (DateTime)dgv_Fanxiuhegelv.CurrentRow.Cells["开始时间"].Value;
                            DateTime end = (DateTime)dgv_Fanxiuhegelv.CurrentRow.Cells["结束时间"].Value;
                            //如果有时间限制
                            list_RepairRecord = db.TB_RepairRecord.Where(p => p.TB_User.ID == worker.ID && p.EndTime > begin && p.EndTime < end).ToList();
                        }
                        else
                        {
                            list_RepairRecord = db.TB_RepairRecord.Where(p => p.TB_User.ID == worker.ID).ToList();
                        }
                        foreach (var item in list_RepairRecord)
                        {
                            var workDtls = db.TB_WorkDtl.Where(p => p.MaterialCode == item.TB_WorkDtl.MaterialCode && p.IsException == true && (p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "D" || p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "H")).ToList();
                            foreach (var item2 in workDtls)
                            {
                                list_WorkDtl.Add(item2);
                            }
                        }
                        //对数据源加载完全
                        foreach (var item in list_RepairRecord)
                        {
                            item.TB_UserReference.Load();
                            item.TB_ExceptionReference.Load();
                        }
                        foreach (var item in list_WorkDtl)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            item.TB_UserReference.Load();
                            item.TB_WorkMainReference.Load();
                            item.TB_WorkMain.TB_SecondWorkStationInfoReference.Load();
                        }
                        //在进行加载到dgv
                        dgv_FanxiuExceptionShow.DataSource = list_WorkDtl;
                        dgv_FanxiuShaixuan.DataSource = list_RepairRecord;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载指定员工统计信息失败！详情请查看日志");
                        SystemLogHelper.WriteSysLogHelper("加载指定员工统计信息失败！详细信息：" + ex.ToString(), user.ID, "返修区合格率统计");
                    }
                }
                Changeprobar(false);
            }
        }

        /// <summary>
        /// dgv_FanxiuShaixuan加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_FanxiuShaixuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_FanxiuShaixuan.Rows[e.RowIndex].DataBoundItem != null) && (dgv_FanxiuShaixuan.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_FanxiuShaixuan.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_FanxiuShaixuan.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_FanxiuExceptionShow加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_FanxiuExceptionShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_FanxiuExceptionShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_FanxiuExceptionShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_FanxiuExceptionShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_FanxiuExceptionShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        #endregion


    }
}