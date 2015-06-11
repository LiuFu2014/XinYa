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
    public partial class frm_WorkTimeBandingInfo : Form
    {
        TB_User user;
        ServiceReference1.Service1Client serClient = new ServiceReference1.Service1Client();

        public frm_WorkTimeBandingInfo(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_BaozhuangBanding.AutoGenerateColumns = false;
            this.dgv_HistoryBaozhuang.AutoGenerateColumns = false;
            this.dgv_HistoryInfoShow.AutoGenerateColumns = false;
            this.dgv_HistoryMohe.AutoGenerateColumns = false;
            this.dgv_MoheBanding.AutoGenerateColumns = false;
            DataInit();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region 磨合包装数据初始

        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    dgv_BaozhuangBanding.DataSource = db.TB_SecondWorkStationInfo.Where(p => p.WorkStationCode == "G" 
                        || p.WorkStationCode == "H" || p.WorkStationCode == "I" 
                        || p.WorkStationCode == "J" || p.WorkStationCode == "K" 
                        || p.WorkStationCode == "L" || p.WorkStationCode == "M" 
                        || p.WorkStationCode == "N" || p.WorkStationCode == "O" 
                        || p.WorkStationCode == "P").ToList();
                    dgv_MoheBanding.DataSource = db.TB_SecondWorkStationInfo.Where(p => p.WorkStationCode == "B").ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据初始化异常。详情请查看本地日志。");
                    SystemLogHelper.WriteSysLogHelper("数据初始化异常。详情:" + ex.ToString(), user.ID, "工时辅助程序磨合包装工时重新绑定");
                }
            }
        }

        #endregion

        #region 查询

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Worker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        /// <summary>
        /// 员工选择助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            frm_UserSelectHelper helper = new frm_UserSelectHelper(4);
            helper.Tag = this;
            helper.ShowDialog();
        }

        /// <summary>
        /// 历史信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            //检查是否勾选了日期
            if (check_Time.Checked)
            {
                if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value) > 0)
                {
                    MessageBox.Show("开始时间不应晚于结束时间！");
                    return;
                }
            }
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    List<TB_WorkTimeBandingInfo> list_workTimeBandingInfo = new List<TB_WorkTimeBandingInfo>();
                    //时间
                    if (check_Time.Checked)
                    {
                        list_workTimeBandingInfo = db.TB_WorkTimeBandingInfo.Where(p => p.Date > dtp_BeginTime.Value && p.Date < dtp_EndTime.Value).ToList();
                    }
                    else
                    {
                        list_workTimeBandingInfo = db.TB_WorkTimeBandingInfo.ToList();
                    }
                    //指定员工
                    if (check_Worker.Checked)
                    {
                        List<TB_WorkTimeBandingInfo> temp = new List<TB_WorkTimeBandingInfo>();
                        string[] workers = txt_Worker.Text.Trim().TrimEnd(';').Split(';');
                        if (workers.Length!=0)
                        {
                            foreach (var item in list_workTimeBandingInfo)
                            {
                                if (workers.Contains(item.TB_User.UserID))
                                {
                                    temp.Add(item);
                                }
                            }
                            list_workTimeBandingInfo = temp;
                        }
                    }
                    //加载完全
                    foreach (var item in list_workTimeBandingInfo)
                    {
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_User1Reference.Load();
                    }
                    //dgv赋值
                    dgv_HistoryInfoShow.DataSource = list_workTimeBandingInfo;
                    dgv_HistoryMohe.DataSource = list_workTimeBandingInfo.Where(p => p.TB_SecondWorkStationInfo.WorkStationCode == "B").ToList();
                    dgv_HistoryBaozhuang.DataSource = list_workTimeBandingInfo.Where(p => p.TB_SecondWorkStationInfo.WorkStationCode == "G"
                        || p.TB_SecondWorkStationInfo.WorkStationCode == "H" || p.TB_SecondWorkStationInfo.WorkStationCode == "I" 
                        || p.TB_SecondWorkStationInfo.WorkStationCode == "J" || p.TB_SecondWorkStationInfo.WorkStationCode == "K"
                        || p.TB_SecondWorkStationInfo.WorkStationCode == "L" || p.TB_SecondWorkStationInfo.WorkStationCode == "M" 
                        || p.TB_SecondWorkStationInfo.WorkStationCode == "N" || p.TB_SecondWorkStationInfo.WorkStationCode == "O" 
                        || p.TB_SecondWorkStationInfo.WorkStationCode == "P").ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询出现异常！详情请查看系统日志！");
                    SystemLogHelper.WriteSysLogHelper("查询工时绑定历史记录出现异常。详情：" + ex.ToString(), user.ID, "工时辅助-查询");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 导出全部历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportAll_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_HistoryInfoShow);
            Changeprobar(false);
        }

        /// <summary>
        /// 导出磨合历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportMohe_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_HistoryMohe);
            Changeprobar(false);
        }

        /// <summary>
        /// 导出包装历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportBaozhuang_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_HistoryBaozhuang);
            Changeprobar(false);
        }

        /// <summary>
        /// dgv_HistoryMohe加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HistoryMohe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_HistoryMohe.Rows[e.RowIndex].DataBoundItem != null) && (dgv_HistoryMohe.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_HistoryMohe.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_HistoryMohe.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_HistoryBaozhuang加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HistoryBaozhuang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_HistoryBaozhuang.Rows[e.RowIndex].DataBoundItem != null) && (dgv_HistoryBaozhuang.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_HistoryBaozhuang.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_HistoryBaozhuang.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_HistoryInfoShow加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HistoryInfoShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_HistoryInfoShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_HistoryInfoShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_HistoryInfoShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_HistoryInfoShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        #region 磨合绑定

        /// <summary>
        /// 磨合绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MoheBanding_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确保数据输入无误后再进行操作。是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Changeprobar(true);
                Application.DoEvents();
                if (dgv_MoheBanding.DataSource == null || dgv_MoheBanding.RowCount <= 1)
                {
                    MessageBox.Show("没有可以用来绑定的数据！");
                }
                else
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        //循环遍历每一行
                        foreach (DataGridViewRow item in dgv_MoheBanding.Rows)
                        {
                            try
                            {
                                if (item.Cells[2].Value != null)
                                {
                                    string a = item.Cells[2].Value.ToString();
                                    var b = db.TB_User.Single(p => p.UserID == a);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("未找到工号为" + item.Cells[2].Value.ToString() + "的员工");
                                Changeprobar(false);
                                return;
                            }
                        }
                        //时间
                        DateTime dt = dtp_Mohe.Value;
                        //循环遍历每一行
                        foreach (DataGridViewRow item in dgv_MoheBanding.Rows)
                        {
                            try
                            {
                                if (item.Cells[2].Value != null)
                                {
                                    int secondWorkStationID = (int)item.Cells[0].Value;
                                    string userID = item.Cells[2].Value.ToString();
                                    #region 处理段

                                    //先筛选这个工位上的任务工艺记录
                                    var works = db.TB_WorkDtlForEachStation.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID);
                                    foreach (var item2 in works)
                                    {
                                        if (item2.WorkBeginTime != null && item2.WorkBeginTime.Value.Date == dt.Date)
                                        {
                                            //如果是指定的,则将其与该员工绑定
                                            item2.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        }
                                    }
                                    db.SaveChanges();
                                    //这里记录下绑定信息
                                    //首先确认指定日期，这个工位有没有此类信息
                                    var list_WorkTimeBandingInfo = db.TB_WorkTimeBandingInfo.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID).ToList();
                                    if (list_WorkTimeBandingInfo.Count(p => p.Date.Date == dt.Date) == 0)
                                    {
                                        //等于0表示指定还没有绑定信息，新增
                                        TB_WorkTimeBandingInfo workTimeBandingInfo = new TB_WorkTimeBandingInfo();
                                        workTimeBandingInfo.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                        workTimeBandingInfo.Date = dt;
                                        db.AddToTB_WorkTimeBandingInfo(workTimeBandingInfo);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        //不等于0表示指定已经有过绑定信息，更新
                                        TB_WorkTimeBandingInfo workTimeBandingInfo = list_WorkTimeBandingInfo.Single(p => p.Date.Date == DateTime.Now.Date);
                                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                        workTimeBandingInfo.Date = dt;
                                        db.SaveChanges();
                                    }

                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLogHelper.WriteSysLogHelper("绑定出现异常，详情：" + ex.ToString(), user.ID, "ISM信息主程序磨合段工时重新绑定");
                                MessageBox.Show("绑定出现异常！详情请查看系统日志！");
                                Changeprobar(false);
                                return;
                            }
                        }
                        MessageBox.Show("操作完成");
                        //SystemLogHelper.WriteSysLogHelper("操作完成，成功" + i + "失败" + j + "失败原因可能为当前系统中没有该工号的员工，或绑定了没有工作数据的工位", user.ID, "ISM信息主程序磨合段工时重新绑定");
                    }
                }
                Changeprobar(false);
            }
        }

        #endregion      

        #region 包装绑定

        /// <summary>
        /// 包装绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BaozhuangBanding_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确保数据输入无误后再进行操作。是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Changeprobar(true);
                Application.DoEvents();
                if (dgv_MoheBanding.DataSource == null || dgv_MoheBanding.RowCount <= 1)
                {
                    MessageBox.Show("没有可以用来绑定的数据！");
                }
                else
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        //循环遍历每一行
                        foreach (DataGridViewRow item in dgv_MoheBanding.Rows)
                        {
                            try
                            {
                                if (item.Cells[2].Value != null)
                                {
                                    string a = item.Cells[2].Value.ToString();
                                    var b = db.TB_User.Single(p => p.UserID == a);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("未找到工号为" + item.Cells[2].Value.ToString() + "的员工");
                                Changeprobar(false);
                                return;
                            }
                        }
                        //时间
                        DateTime dt = dtp_Baozhuang.Value;
                        //循环遍历每一行
                        foreach (DataGridViewRow item in dgv_BaozhuangBanding.Rows)
                        {
                            try
                            {
                                if (item.Cells[2].Value != null)
                                {
                                    int secondWorkStationID = (int)item.Cells[0].Value;
                                    string userID = item.Cells[2].Value.ToString();
                                    #region 处理段

                                    //先筛选这个工位上的任务工艺记录
                                    var works = db.TB_WorkDtlForEachStation.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID);
                                    foreach (var item2 in works)
                                    {
                                        if (item2.WorkBeginTime != null && item2.WorkBeginTime.Value.Date == dt.Date)
                                        {
                                            //如果是指定的,则将其与该员工绑定
                                            item2.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        }
                                    }
                                    db.SaveChanges();
                                    //这里记录下绑定信息
                                    //首先确认指定日期，这个工位有没有此类信息
                                    var list_WorkTimeBandingInfo = db.TB_WorkTimeBandingInfo.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID).ToList();
                                    if (list_WorkTimeBandingInfo.Count(p => p.Date.Date == dt.Date) == 0)
                                    {
                                        //等于0表示指定还没有绑定信息，新增
                                        TB_WorkTimeBandingInfo workTimeBandingInfo = new TB_WorkTimeBandingInfo();
                                        workTimeBandingInfo.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                        workTimeBandingInfo.Date = dt;
                                        db.AddToTB_WorkTimeBandingInfo(workTimeBandingInfo);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        //不等于0表示指定已经有过绑定信息，更新
                                        TB_WorkTimeBandingInfo workTimeBandingInfo = list_WorkTimeBandingInfo.Single(p => p.Date.Date == DateTime.Now.Date);
                                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                        workTimeBandingInfo.Date = dt;
                                        db.SaveChanges();
                                    }

                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLogHelper.WriteSysLogHelper("绑定出现异常，详情：" + ex.ToString(), user.ID, "ISM信息主程序磨合段工时重新绑定");
                                MessageBox.Show("绑定出现异常！详情请查看系统日志！");
                                Changeprobar(false);
                                return;
                            }
                        }
                        MessageBox.Show("操作完成");
                        //SystemLogHelper.WriteSysLogHelper("操作完成，成功" + i + "失败" + j + "失败原因可能为当前系统中没有该工号的员工，或绑定了没有工作数据的工位", user.ID, "ISM信息主程序磨合段工时重新绑定");
                    }
                }
                Changeprobar(false);
            }
        }

        #endregion

    }
}
