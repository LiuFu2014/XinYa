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
    public partial class frm_ProductionPlan : Form
    {
        TB_User user;

        public frm_ProductionPlan(TB_User user)
        {
            InitializeComponent();
            this.dgv_Main.AutoGenerateColumns = false;
            //默认显示相0
            cb_LineNum.SelectedIndex = 0;
            this.user = user;
        }

        /// <summary>
        /// 弹框选择物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectMat_Click(object sender, EventArgs e)
        {
            frm_MaterialSelectHelper mathelper = new frm_MaterialSelectHelper(3);
            mathelper.Tag = this;
            mathelper.ShowDialog();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (string.IsNullOrEmpty(txt_MatSelect.Text))
            {
                MessageBox.Show("当前没有选中任何物料型号");
            }
            else
            {
                //选取控件值
                DateTime dt = dtp_PlanDate.Value;
                int num = (int)num_Amount.Value;
                string line = cb_LineNum.SelectedItem.ToString();
                string[] matArray = txt_MatSelect.Text.Trim().TrimEnd(';').Split(';');
                string exception = "";
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var mats = db.TB_MaterialInfo.ToList();
                        var plans = db.TB_ProductionPlan.ToList();
                        //循环遍历物料数组，赋值保存
                        //foreach (var item in matArray)
                        //{

                        ////先检查这个物料是否存在
                        //var a = db.TB_MaterialInfo.Single(p => p.TypeCode == item);
                        //所有导入的月计划
                        var list_TB_ProductionPlanFromERP = db.TB_ProductionPlanFromERP.ToList();

                        #region MyRegion
                        /*
                        foreach (var item in mats)
                        {
                            if (matArray.Contains(item.TypeCode))
                            {
                                #region 加入验证，该物料型号的日计划不能超过对应的月计划

                                //首先验证，指定日期的日计划是否存在对应的月计划,这里加入=号，也就是说月计划制订在11号，我的日计划也可以制订11号的。这里在ERP导入阶段控制一种型号在某一天只有一个对应的月计划。
                                if (db.TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && dt.CompareTo(p.PlanBeginTime) >= 0 && dt.CompareTo(p.PlanEndTime) <= 0) == 0)
                                {
                                    //MessageBox.Show("该物料还没有指定的月计划");
                                    txt_PlanResult.AppendText("类别：录入日计划。时间：" + DateTime.Now.ToString() + "，型号" + item.TypeCode + "没有指定日期的月计划。录入失败。" + "\n");
                                }
                                else
                                {
                                    //再验证总数是否超过月计划
                                    //取出这条月计划
                                    var monthPlan = db.TB_ProductionPlanFromERP.First(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && dt.CompareTo(p.PlanBeginTime) >= 0 && dt.CompareTo(p.PlanEndTime) <= 0);
                                    //找出这段时间内的日计划总和
                                    var list_DayPlan = db.TB_ProductionPlan.Where(p => p.TB_MaterialInfo.TypeCode == item.TypeCode);
                                    //筛选求和
                                    int sum = 0;
                                    foreach (var item2 in list_DayPlan)
                                    {
                                        if (item2.Date.CompareTo(monthPlan.PlanBeginTime) >= 0 && item2.Date.CompareTo(monthPlan.PlanEndTime) <= 0)
                                        {
                                            //满足条件
                                            sum += item2.Amount;
                                        }
                                    }
                                    //验证
                                    if ((sum + num) > monthPlan.PlanAmount)
                                    {
                                        int overAmount = sum + num - monthPlan.PlanAmount;
                                        txt_PlanResult.AppendText("类别：录入日计划。时间：" + DateTime.Now.ToString() + "，型号" + item.TypeCode + "超出月计划指定数量:" + overAmount.ToString() + "。录入失败。\n");
                                    }
                                    else
                                    {
                                        //通过验证
                                        try
                                        {
                                            //判断一下是否在计划表中已经存在，同时也要判断一下装配线号。不同的装配线号可以有同一个typecode的计划
                                            int count = plans.Count(p => p.Date == dt.Date && p.TB_MaterialInfo.TypeCode == item.TypeCode && p.LineNumber == line);
                                            if (count == 0)
                                            {
                                                //-----新增---------------
                                                TB_ProductionPlan productionPlan = new TB_ProductionPlan();
                                                productionPlan.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == item.TypeCode);
                                                productionPlan.Amount = num;
                                                productionPlan.Date = dt;
                                                productionPlan.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                                productionPlan.PlanTime = DateTime.Now;
                                                productionPlan.LineNumber = line;
                                                db.TB_ProductionPlan.AddObject(productionPlan);
                                                db.SaveChanges();
                                            }
                                            else
                                            {
                                                //-----更新---------------
                                                var productionPlan = db.TB_ProductionPlan.Single(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && p.Date == dt.Date && p.LineNumber == line);
                                                productionPlan.Amount = num;
                                                productionPlan.Date = dt;
                                                productionPlan.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                                productionPlan.PlanTime = DateTime.Now;
                                                productionPlan.LineNumber = line;
                                                db.SaveChanges();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            exception += ". " + item.TypeCode;
                                            continue;
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                         * */

                        #endregion

                        #region 新版

                        foreach (var item in mats)
                        {
                            if (matArray.Contains(item.TypeCode))
                            {
                                #region 加入验证，该物料型号的日计划不能超过对应的月计划

                                //首先验证，指定日期的日计划是否存在对应的月计划,这里加入=号，也就是说月计划制订在11号，我的日计划也可以制订11号的。这里在ERP导入阶段控制一种型号在某一天只有一个对应的月计划。
                                if (list_TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && dt.Date.CompareTo(p.PlanBeginTime.Date) >= 0 && dt.Date.CompareTo(p.PlanEndTime.Date) <= 0) == 0)
                                {
                                    //MessageBox.Show("该物料还没有指定的月计划");
                                    txt_PlanResult.AppendText("类别：录入日计划。时间：" + DateTime.Now.ToString() + "，型号" + item.TypeCode + "没有指定日期的月计划。录入失败。" + "\n");
                                }
                                else
                                {
                                    //再验证总数是否超过月计划
                                    //取出这条月计划
                                    var monthPlan = list_TB_ProductionPlanFromERP.First(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && dt.Date.CompareTo(p.PlanBeginTime.Date) >= 0 && dt.Date.CompareTo(p.PlanEndTime.Date) <= 0);
                                    //找出这段时间内的日计划总和
                                    var list_DayPlan = db.TB_ProductionPlan.Where(p => p.TB_MaterialInfo.TypeCode == item.TypeCode);
                                    //筛选求和
                                    int sum = 0;
                                    foreach (var item2 in list_DayPlan)
                                    {
                                        if (item2.Date.CompareTo(monthPlan.PlanBeginTime.Date) >= 0 && item2.Date.CompareTo(monthPlan.PlanEndTime.Date) <= 0)
                                        {
                                            //满足条件
                                            sum += item2.Amount;
                                        }
                                    }
                                    //验证
                                    if ((sum + num) > monthPlan.PlanAmount)
                                    {
                                        int overAmount = sum + num - monthPlan.PlanAmount;
                                        txt_PlanResult.AppendText("类别：录入日计划。时间：" + DateTime.Now.ToString() + "，型号" + item.TypeCode + "超出月计划指定数量:" + overAmount.ToString() + "。录入失败。\n");
                                    }
                                    else
                                    {
                                        //通过验证
                                        try
                                        {
                                            //判断一下是否在计划表中已经存在，同时也要判断一下装配线号。不同的装配线号可以有同一个typecode的计划
                                            int count = plans.Count(p => p.Date == dt.Date && p.TB_MaterialInfo.TypeCode == item.TypeCode && p.LineNumber == line);
                                            if (count == 0)
                                            {
                                                //-----新增---------------
                                                TB_ProductionPlan productionPlan = new TB_ProductionPlan();
                                                productionPlan.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == item.TypeCode);
                                                productionPlan.Amount = num;
                                                productionPlan.Date = dt;
                                                productionPlan.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                                productionPlan.PlanTime = DateTime.Now;
                                                productionPlan.LineNumber = line;
                                                db.TB_ProductionPlan.AddObject(productionPlan);
                                                db.SaveChanges();
                                            }
                                            else
                                            {
                                                //-----更新---------------
                                                var productionPlan = db.TB_ProductionPlan.Single(p => p.TB_MaterialInfo.TypeCode == item.TypeCode && p.Date == dt.Date && p.LineNumber == line);
                                                productionPlan.Amount = num;
                                                productionPlan.Date = dt;
                                                productionPlan.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                                productionPlan.PlanTime = DateTime.Now;
                                                productionPlan.LineNumber = line;
                                                db.SaveChanges();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            exception += ". " + item.TypeCode;
                                            continue;
                                        }
                                    }
                                }
                                #endregion
                            }
                        }

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("新增出现异常！请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("新增日生产计划出现异常，详情：" + ex.ToString(), user.ID, "生产计划");
                        return;
                    }
                }
                if (exception != "")
                {
                    MessageBox.Show("操作成功！但有异常：" + exception + "物料编号在系统中并不存在！请检查输入！");
                }
                else
                {
                    MessageBox.Show("操作成功！请查看输出。");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (check_IsAll.Checked)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_ProductionPlan.ToList();
                        foreach (var item in a)
                        {
                            item.TB_MaterialInfoReference.Load();
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = a;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现特定于网络或数据的异常。原因可能为网络断开或当前没有数据。");
                        SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "生产计划");
                    }
                }
            }
            else if (check_IsToday.Checked)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_ProductionPlan.ToList();
                        List<TB_ProductionPlan> list_pro = new List<TB_ProductionPlan>();
                        foreach (var item in a)
                        {
                            if (item.Date.Date == DateTime.Today)
                            {
                                item.TB_MaterialInfoReference.Load();
                                item.TB_UserReference.Load();
                                list_pro.Add(item);
                            }
                        }
                        dgv_Main.DataSource = list_pro;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现特定于网络或数据的异常。原因可能为网络断开或当前没有数据。");
                        SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "生产计划");
                    }
                }

            }
            else
            {
                DateTime begintime = dtp_BeginTime.Value;
                DateTime endtime = dtp_EndTime.Value;
                if (begintime.CompareTo(endtime) > 0)
                {
                    MessageBox.Show("开始时间不应该晚于结束时间！");
                }
                else
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            var a = db.TB_ProductionPlan.ToList();
                            List<TB_ProductionPlan> list_pro = new List<TB_ProductionPlan>();
                            foreach (var item in a)
                            {
                                //包括开始和结束日期在内
                                if (begintime.CompareTo(item.Date.Date) <= 0 && endtime.CompareTo(item.Date.Date) >= 0)
                                {
                                    item.TB_MaterialInfoReference.Load();
                                    item.TB_UserReference.Load();
                                    list_pro.Add(item);
                                }
                            }
                            dgv_Main.DataSource = list_pro;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("查询出现特定于网络或数据的异常。原因可能为网络断开或当前没有数据。");
                            SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "生产计划");
                        }
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 删除选定项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.Rows.Count == 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("当前没有可用于删除的数据！");
            }
            else
            {
                string exception = "";
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        if ((dgv_Main.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_Main.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            int id = (int)dgv_Main.Rows[i].Cells["c_ID"].Value;
                            try
                            {
                                var a = db.TB_ProductionPlan.Single(p => p.ID == id);
                                db.TB_ProductionPlan.DeleteObject(a);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                exception += "," + id.ToString();
                                SystemLogHelper.WriteSysLogHelper("删除序号为" + id + "的数据失败！", user.ID, "生产计划");
                            }
                        }
                    }
                }
                if (exception == "")
                {
                    MessageBox.Show("操作成功！");
                }
                else
                {
                    MessageBox.Show("操作成功！但是" + exception + "删除失败");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveDgv_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.Rows.Count == 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("当前没有可用于更新的数据！");
            }
            else
            {
                string exception = "";
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    for (int i = 0; i < dgv_Main.Rows.Count; i++)
                    {
                        //ID值
                        int id = (int)dgv_Main.Rows[i].Cells["c_ID"].Value;
                        //日期
                        DateTime dt = (DateTime)dgv_Main.Rows[i].Cells["c_Date"].Value;
                        //数量
                        int amount = (int)dgv_Main.Rows[i].Cells["c_Amount"].Value;
                        //型号
                        string typeCode = dgv_Main.Rows[i].Cells["c_MaterialCode"].FormattedValue.ToString();
                        //同样需要验证，验证不通过终止更改（continue）
                        #region

                        //首先验证，指定日期的日计划是否存在对应的月计划
                        if (db.TB_ProductionPlanFromERP.Count(p => p.TB_MaterialInfo.TypeCode == typeCode && dt.CompareTo(p.PlanBeginTime) > 0 && dt.CompareTo(p.PlanEndTime) < 0) == 0)
                        {
                            //MessageBox.Show("该物料还没有指定的月计划");
                            txt_PlanResult.AppendText("类别：更新日计划数量。时间：" + DateTime.Now.ToString() + "，型号" + typeCode + "没有指定日期的月计划。" + "更新失败。\n");
                        }
                        else
                        {
                            //再验证总数是否超过月计划
                            //取出这条月计划
                            var monthPlan = db.TB_ProductionPlanFromERP.First(p => p.TB_MaterialInfo.TypeCode == typeCode && dt.CompareTo(p.PlanBeginTime) > 0 && dt.CompareTo(p.PlanEndTime) < 0);
                            //找出这段时间内的日计划总和
                            var list_DayPlan = db.TB_ProductionPlan.Where(p => p.TB_MaterialInfo.TypeCode == typeCode);
                            //筛选求和
                            int sum = 0;
                            foreach (var item2 in list_DayPlan)
                            {
                                //排除当前计划
                                if (item2.Date.CompareTo(monthPlan.PlanBeginTime) > 0 && item2.Date.CompareTo(monthPlan.PlanEndTime) < 0 && item2.Date.Date != dt.Date)
                                {
                                    //满足条件
                                    sum += item2.Amount;
                                }
                            }
                            //验证
                            if ((sum + amount) > monthPlan.PlanAmount)
                            {
                                int overAmount = sum + amount - monthPlan.PlanAmount;
                                txt_PlanResult.AppendText("类别：更新日计划数量。时间：" + DateTime.Now.ToString() + "，型号" + typeCode + "超出月计划指定数量:" + overAmount.ToString() + "。更新日计划数量失败。\n");
                            }
                            else
                            {
                                try
                                {
                                    var a = db.TB_ProductionPlan.Single(p => p.ID == id);
                                    a.Amount = (int)dgv_Main.Rows[i].Cells["c_Amount"].Value;
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    exception += "," + id.ToString();
                                    SystemLogHelper.WriteSysLogHelper("更新序号为" + id + "的数据失败！", user.ID, "生产计划");
                                }
                            }
                        }
                        #endregion
                    }
                }
                if (exception == "")
                {
                    MessageBox.Show("操作成功！请查看输出。重新查询可以刷新报表显示。");
                }
                else
                {
                    MessageBox.Show("操作成功！但是" + exception + "更新失败。请查看输出。");
                }
            }
            Changeprobar(false);
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
        /// 限制物料输入只输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_MatSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportData_Click(object sender, EventArgs e)
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
        /// 清空输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearResult_Click(object sender, EventArgs e)
        {
            txt_PlanResult.Clear();
        }
    }
}
