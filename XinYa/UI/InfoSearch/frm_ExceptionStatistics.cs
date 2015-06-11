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
    public partial class frm_ExceptionStatistics : Form
    {
        TB_User user;
        public frm_ExceptionStatistics(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_ExceptionEachType.AutoGenerateColumns = false;
            this.dgv_ExceptionEachDay.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            frm_ExceptionSelectHelper helper = new frm_ExceptionSelectHelper();
            helper.Tag = this;
            helper.ShowDialog();
        }

        /// <summary>
        /// 按类型查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            //用于统计的model
            List<ExceptionStaByType> exceptionSta = new List<ExceptionStaByType>();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //加载说有异常信息
                    var workExceptions = db.TB_Exception.ToList();
                    //将这个东西加载完全
                    foreach (var item in workExceptions)
                    {
                        item.TB_WorkException.Load();
                    }
                    //加载异常选择信息
                    string[] selectexception = txt_ExceptionSelect.Text.Trim().TrimEnd(';').Split(';');
                    //
                    //...
                    //
                    if (check_All.Checked)//全部
                    {
                        if (check_SelectExceptionCode.Checked)//是否指定
                        {
                            if (string.IsNullOrEmpty(txt_ExceptionSelect.Text))
                            {
                                MessageBox.Show("请先输入异常编码数据！");
                            }
                            else
                            {
                                //筛选
                                foreach (var item in workExceptions)
                                {
                                    if (selectexception.Contains(item.ExceptionCode))//符合条件
                                    {
                                        ExceptionStaByType a = new ExceptionStaByType();
                                        a.ExceptionCode = item.ExceptionCode;
                                        a.ExceptionText = item.ExceptionText;
                                        a.Count = item.TB_WorkException.Count();
                                        exceptionSta.Add(a);
                                    }
                                }
                            }
                        }
                        else//不指定
                        {
                            foreach (var item in workExceptions)
                            {
                                ExceptionStaByType a = new ExceptionStaByType();
                                a.ExceptionCode = item.ExceptionCode;
                                a.ExceptionText = item.ExceptionText;
                                a.Count = item.TB_WorkException.Count();
                                exceptionSta.Add(a);
                            }
                        }
                    }
                    else if (check_Today.Checked)//今天
                    {
                        if (check_SelectExceptionCode.Checked)
                        {
                            if (string.IsNullOrEmpty(txt_ExceptionSelect.Text))
                            {
                                MessageBox.Show("请先输入异常编码数据！");
                            }
                            else
                            {
                                //筛选
                                foreach (var item in workExceptions)
                                {
                                    if (selectexception.Contains(item.ExceptionCode))//符合条件
                                    {
                                        ExceptionStaByType a = new ExceptionStaByType();
                                        a.ExceptionCode = item.ExceptionCode;
                                        a.ExceptionText = item.ExceptionText;
                                        a.Count = item.TB_WorkException.Where(p => p.Date.Value.Date == DateTime.Now.Date).Count();
                                        exceptionSta.Add(a);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //筛选
                            foreach (var item in workExceptions)
                            {
                                ExceptionStaByType a = new ExceptionStaByType();
                                a.ExceptionCode = item.ExceptionCode;
                                a.ExceptionText = item.ExceptionText;
                                a.Count = item.TB_WorkException.Where(p => p.Date.Value.Date == DateTime.Now.Date).Count();
                                exceptionSta.Add(a);
                            }
                        }
                    }
                    else
                    {
                        if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value) > 0)//指定日期
                        {
                            MessageBox.Show("开始时间不应该晚于结束时间！");
                        }
                        else
                        {
                            if (check_SelectExceptionCode.Checked)
                            {
                                if (string.IsNullOrEmpty(txt_ExceptionSelect.Text))
                                {
                                    MessageBox.Show("请先输入异常编码数据！");
                                }
                                else
                                {
                                    //筛选
                                    foreach (var item in workExceptions)
                                    {
                                        if (selectexception.Contains(item.ExceptionCode))//符合条件
                                        {
                                            ExceptionStaByType a = new ExceptionStaByType();
                                            a.ExceptionCode = item.ExceptionCode;
                                            a.ExceptionText = item.ExceptionText;
                                            a.Count = item.TB_WorkException.Where(p => p.Date.Value.Date.CompareTo(dtp_BeginTime.Value) > 0 && p.Date.Value.CompareTo(dtp_EndTime.Value) < 0).Count();
                                            exceptionSta.Add(a);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //筛选
                                foreach (var item in workExceptions)
                                {
                                    ExceptionStaByType a = new ExceptionStaByType();
                                    a.ExceptionCode = item.ExceptionCode;
                                    a.ExceptionText = item.ExceptionText;
                                    a.Count = item.TB_WorkException.Where(p => p.Date.Value.Date.CompareTo(dtp_BeginTime.Value) > 0 && p.Date.Value.CompareTo(dtp_EndTime.Value) < 0).Count();
                                    exceptionSta.Add(a);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败！详情请查看日志！");
                    SystemLogHelper.WriteSysLogHelper("异常表无数据返回：" + ex.ToString(), user.ID, "异常统计");
                }
            }
            dgv_ExceptionEachType.DataSource = exceptionSta;
            Changeprobar(false);
        }

        /// <summary>
        /// 按天查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser2_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            DateTime begin = dtp_BeginTime2.Value;
            DateTime end = dtp_EndTime2.Value;
            List<ExceptionStaByDate> exceptionStaByDate = new List<ExceptionStaByDate>();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var workExceptions = db.TB_WorkException.ToList();
                    if (check_Today2.Checked)
                    {
                        ExceptionStaByDate a = new ExceptionStaByDate();
                        a.Date = DateTime.Now.Date;
                        a.Count = workExceptions.Count(p => p.Date.Value.Date == DateTime.Now.Date&&p.ExceptionID!=null);
                        exceptionStaByDate.Add(a);
                    }
                    else
                    {
                        if (begin.CompareTo(end) > 0)
                        {
                            MessageBox.Show("开始时间不应晚于结束时间");
                        }
                        else
                        {
                            while (begin.CompareTo(end) < 0)
                            {
                                ExceptionStaByDate a = new ExceptionStaByDate();
                                a.Date = begin.Date;
                                a.Count = workExceptions.Count(p => p.Date.Value.Date == begin.Date&&p.ExceptionID!=null);
                                exceptionStaByDate.Add(a);
                                begin = begin.AddDays(1);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("可能由于数据或网络的异常，本次查询数据未能加载完全。");
                    SystemLogHelper.WriteSysLogHelper("按天统计异常数据出现异常", user.ID, "异常统计");
                }
            }
            dgv_ExceptionEachDay.DataSource = exceptionStaByDate;
            Changeprobar(false);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 按故障编码统计导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outprot1_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_ExceptionEachType.RowCount <= 0 || dgv_ExceptionEachType.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_ExceptionEachType) == 0)
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
        /// 按天故障统计导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outport2_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_ExceptionEachDay.RowCount <= 0 || dgv_ExceptionEachDay.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_ExceptionEachDay) == 0)
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
    }
}