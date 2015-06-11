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

namespace XinYa.UI.Sys
{
    public partial class frm_SystemLog : Form
    {
        public frm_SystemLog()
        {
            InitializeComponent();
            dgv_Main.AutoGenerateColumns = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (check_Time.Checked)
            {
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    try
                    {
                        DateTime beginTime = dtp_BeginTime.Value;
                        DateTime endTime = dtp_EndTime.Value;
                        var a = db.TB_SystemLog.OrderByDescending(p => p.Time).ToList();
                        List<TB_SystemLog> list_log = new List<TB_SystemLog>();
                        foreach (var item in a)
                        {
                            if (item.Time.Value.CompareTo(beginTime) > 0 && item.Time.Value.CompareTo(endTime) < 0)
                            {
                                item.TB_UserReference.Load();
                                list_log.Add(item);
                            }
                        }
                        foreach (var item in list_log)
                        {
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = list_log;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常，可能原因为网络通讯断开或系统中还没有日志产生！");
                    }                  
                }
            }
            else if(check_RecordNum.Checked)
            {
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    try
                    {
                        int num = (int)num_RecordNum.Value;
                        var a = db.TB_SystemLog.OrderByDescending(p=>p.Time).Take(num);
                        foreach (var item in a)
                        {
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = a;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常，可能原因为网络通讯断开或系统中还没有日志产生！");
                    }                  
                }
            }
            else
            {
               //都不选则查询全部
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_SystemLog.OrderByDescending(p => p.Time).ToList();
                        foreach (var item in a)
                        {
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = a;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常，可能原因为网络通讯断开或系统中还没有日志产生！");
                    }
                }
            }
            Changeprobar(false);
        }

        private void check_Time_Click(object sender, EventArgs e)
        {
            if (check_Time.Checked)
            {
                check_RecordNum.Checked = false;
            }
        }

        private void check_RecordNum_Click(object sender, EventArgs e)
        {
            if (check_RecordNum.Checked)
            {
                check_Time.Checked = false;
            }
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
    }
}
