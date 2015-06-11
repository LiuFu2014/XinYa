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

namespace XinYa.UI.InfoSearch
{
    public partial class frm_SQSer : Form
    {
        public frm_SQSer()
        {
            InitializeComponent();
            dgv_ResultShow.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SerAll_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    List<TB_RepairRecord> a = db.TB_RepairRecord.ToList();
                    List<TB_RepairRecord> b = new List<TB_RepairRecord>();
                    foreach (var item in a)
                    {
                        if (item.BeginTime.Value.CompareTo(dtp_BeginTime.Value)>=0&&item.BeginTime.Value.CompareTo(dtp_EndTime.Value)<=0)
                        {
                            b.Add(item);
                        }
                    }
                    foreach (var item in b)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlReference.Load();
                    }
                    dgv_ResultShow.DataSource = b;
                    lab_Total.Text = b.Count.ToString();
                }
                catch (Exception ex)
                {
                    LogExecute.WriteInfoLog("【报废统计】查询全部返修记录出现异常。" + ex.ToString());
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 查询报废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SerScrap_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    List<TB_RepairRecord> a = db.TB_RepairRecord.Where(p => p.IsScrap == true).ToList();
                    List<TB_RepairRecord> b = new List<TB_RepairRecord>();
                    foreach (var item in a)
                    {
                        if (item.BeginTime.Value.CompareTo(dtp_BeginTime.Value) >= 0 && item.BeginTime.Value.CompareTo(dtp_EndTime.Value) <= 0)
                        {
                            b.Add(item);
                        }
                    }
                    foreach (var item in b)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlReference.Load();
                    }
                    dgv_ResultShow.DataSource = b;
                    lab_Total.Text = b.Count.ToString();
                }
                catch (Exception ex)
                {
                    LogExecute.WriteInfoLog("【报废统计】查询报废记录出现异常。" + ex.ToString());
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

        private void dgv_ResultShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_ResultShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_ResultShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_ResultShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_ResultShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportData_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_ResultShow.RowCount <= 0 || dgv_ResultShow.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_ResultShow) == 0)
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
    }
}
