using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_HistoryWorkTaskSer : Form
    {
        /// <summary>
        /// 主任务
        /// </summary>
        List<TB_WorkMain> list_workMain;

        public frm_HistoryWorkTaskSer()
        {
            InitializeComponent();
            this.dgv_WorkM.AutoGenerateColumns = false;
            this.dgv_WorkP.AutoGenerateColumns = false;
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
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            dgv_WorkP.DataSource = null;
            dgv_WorkM.DataSource = null;
            if (check_All.Checked)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        list_workMain = db.TB_WorkMain.Where(p => p.Finished == "1").ToList();
                        foreach (var item in list_workMain)
                        {
                            //创建者
                            item.TB_UserReference.Load();
                            //完成者
                            item.TB_User1Reference.Load();

                            item.TB_SecondWorkStationInfoReference.Load();

                            //子任务
                            item.TB_WorkDtl.Load();
                            foreach (var item2 in item.TB_WorkDtl)
                            {
                                item2.TB_SecondWorkStationInfoReference.Load();
                                item2.TB_ExceptionReference.Load();
                                item2.TB_UserReference.Load();
                                item2.TB_WorkMainReference.Load();
                                item2.TB_MaterialInfoReference.Load();
                            }
                        }
                        dgv_WorkM.DataSource = list_workMain;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("当前没有未完成任务数据或获取数据失败！");
                    }
                }
            }
            else
            {
                if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value)>0)
                {
                    MessageBox.Show("开始时间不应晚于结束时间！");
                }
                else
                {
                    using (XinYaDBEntities db=new XinYaDBEntities())
                    {
                        try
                        {
                            list_workMain = db.TB_WorkMain.Where(p => p.Finished == "1").ToList();
                            List<TB_WorkMain> a = new List<TB_WorkMain>();
                            foreach (var item in list_workMain)
                            {
                                if (item.CreateDate.CompareTo(dtp_BeginTime.Value)>0&&item.CreateDate.CompareTo(dtp_EndTime.Value)<0)
                                {
                                    a.Add(item);
                                }
                                //创建者
                                item.TB_UserReference.Load();
                                //完成者
                                item.TB_User1Reference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                                //子任务
                                item.TB_WorkDtl.Load();
                                foreach (var item2 in item.TB_WorkDtl)
                                {
                                    item2.TB_SecondWorkStationInfoReference.Load();
                                    item2.TB_ExceptionReference.Load();
                                    item2.TB_UserReference.Load();
                                    item2.TB_WorkMainReference.Load();
                                    item2.TB_MaterialInfoReference.Load();
                                }
                            }
                            dgv_WorkM.DataSource = a;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("当前没有未完成任务数据或获取数据失败！");
                        }
                    }
                }
            }
            Changeprobar(false);
        }

        private void dgv_WorkM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkM.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkM.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkM.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkM.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        private void dgv_WorkP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkP.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkP.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkP.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkP.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 单击加载明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_WorkM.CurrentRow == null||dgv_WorkM.Rows.Count==0)
            {
                return;
            }
            else
            {
                try
                {
                    int id = (int)dgv_WorkM.CurrentRow.Cells["c_WorkID"].Value;
                    var workM = list_workMain.Single(p => p.WorkID == id);
                    dgv_WorkP.DataSource = workM.TB_WorkDtl.ToList();
                }
                catch (Exception)
                {
                   
                }
                
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 导出历史任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportMain_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_WorkM.RowCount <= 0 || dgv_WorkM.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_WorkM) == 0)
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
        /// 导出任务明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportDtl_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_WorkP.RowCount <= 0 || dgv_WorkP.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_WorkP) == 0)
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
