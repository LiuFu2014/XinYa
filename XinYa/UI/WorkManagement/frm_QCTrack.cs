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

namespace XinYa.UI.WorkManagement
{
    public partial class frm_QCTrack : Form
    {
        TB_User user;
        public frm_QCTrack(TB_User user)
        {
            InitializeComponent();
            this.dgv_WorkForEachWorkStation.AutoGenerateColumns = false;
            this.dgv_WorkException.AutoGenerateColumns = false;
            this.dgv_Fanxiu.AutoGenerateColumns = false;
            this.dgv_QCRecord.AutoGenerateColumns = false;
            this.dgv_ScanRecord.AutoGenerateColumns = false;
            this.dgv_KeyComInfo.AutoGenerateColumns = false;

            this.user = user;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaterialCode.Text))
            {
                MessageBox.Show("请先输入泵体编码！");
            }
            else
            {
                Changeprobar(true);
                Application.DoEvents();
                string matcode = txt_MaterialCode.Text;
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    #region 工艺路线记录

                    //加载所有(另一种方法是根据泵号筛选任务号，通过任务号获取工艺路线记录)
                    List<TB_WorkDtlForEachStation> a = db.TB_WorkDtlForEachStation.ToList();
                    List<TB_WorkDtlForEachStation> b = new List<TB_WorkDtlForEachStation>();
                    //加载完全
                    foreach (var item in a)
                    {
                        item.TB_WorkMainReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_SecondWorkStationInfoReference.Load();
                    }
                    //匹配
                    foreach (var item in a)
                    {
                        foreach (var item2 in item.TB_WorkMain.TB_WorkDtl.ToList())
                        {
                            if (item2.MaterialCode==matcode)
                            {
                                b.Add(item);
                                break;
                            }
                        }
                    }
                    dgv_WorkForEachWorkStation.DataSource = b;

                    #endregion

                    #region 异常记录

                    //找出泵体在任务明细表中的记录，这里考虑到返修上线，可能有多条记录
                    List<TB_WorkDtl> list_workDtl = db.TB_WorkDtl.Where(p => p.MaterialCode == matcode).ToList();
                    List<TB_WorkException> list_workException = new List<TB_WorkException>();
                    //对每一条记录进行匹配
                    foreach (var item in list_workDtl)
                    {
                        var c = db.TB_WorkException.Where(p => p.WorkDtlID == item.ID).ToList();
                        foreach (var item2 in c)
                        {
                            list_workException.Add(item2);
                        }
                    }
                    //加载完全
                    foreach (var item in list_workException)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlReference.Load();
                    }
                    dgv_WorkException.DataSource = list_workException;

                    #endregion

                    #region 返修记录

                    //根据指定泵体条码找维修记录
                    //先看有没有
                    List<TB_RepairRecord> list_RepairRecord = new List<TB_RepairRecord>();
                    if (db.TB_RepairRecord.Count(p=>p.TB_WorkDtl.MaterialCode==matcode)>0)
                    {
                        //有则加载
                        list_RepairRecord = db.TB_RepairRecord.Where(p => p.TB_WorkDtl.MaterialCode == matcode).ToList();
                        foreach (var item in list_RepairRecord)
                        {
                            item.TB_UserReference.Load();
                            item.TB_ExceptionReference.Load();
                        }
                    }
                    dgv_Fanxiu.DataSource = list_RepairRecord;

                    #endregion

                    #region QC记录

                    //根据指定泵体条码找QC记录
                    //先看有没有
                    List<TB_QCRecord> list_QCRecord = new List<TB_QCRecord>();
                    List<QCRecordModelForQCTrack> list_QCRecordModelForQCTrack = new List<QCRecordModelForQCTrack>();
                    if (db.TB_QCRecord.Count(p=>p.TB_WorkDtlForEachStation.TB_WorkMain.TB_WorkDtl.Count(m=>m.MaterialCode==matcode&&m.IsException==false)>0)>0)
                    {
                        //获取这些符合包含当前泵体条码条件的QC记录
                        foreach (var item in db.TB_QCRecord.Where(p => p.TB_WorkDtlForEachStation.TB_WorkMain.TB_WorkDtl.Count(m => m.MaterialCode == matcode && m.IsException == false) > 0).ToList())
                        {
                            list_QCRecord.Add(item);
                        }
                    }
                    //组建modellist
                    foreach (var item in list_QCRecord)
                    {
                        QCRecordModelForQCTrack qcRecordModelForQCTrack = new QCRecordModelForQCTrack();
                        qcRecordModelForQCTrack.MatCode = matcode;
                        qcRecordModelForQCTrack.QCRecord = item;
                        qcRecordModelForQCTrack.QCRecord.TB_ExceptionReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_SecondWorkStationInfoReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_UserReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_WorkDtlForEachStationReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_WorkDtlForEachStation.TB_SecondWorkStationInfoReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_WorkDtlForEachStation.TB_UserReference.Load();
                        qcRecordModelForQCTrack.QCRecord.TB_WorkDtlForEachStation.TB_WorkMainReference.Load();
                        list_QCRecordModelForQCTrack.Add(qcRecordModelForQCTrack);
                    }
                    dgv_QCRecord.DataSource = list_QCRecordModelForQCTrack;

                    #endregion

                    #region 扫描打码记录

                    List<TB_ScanRecord> list_ScanRecord = new List<TB_ScanRecord>();
                    //有没有
                    if (db.TB_ScanRecord.Count(p=>p.TB_WorkDtl.MaterialCode==matcode)>0)
                    {
                        list_ScanRecord = db.TB_ScanRecord.Where(p => p.TB_WorkDtl.MaterialCode == matcode).ToList();
                    }
                    foreach (var item in list_ScanRecord)
                    {
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtlReference.Load();
                    }
                    dgv_ScanRecord.DataSource = list_ScanRecord;

                    #endregion

                    #region 关键零部件信息

                    List<TB_MatCodeKeyComLink> list_MatCodeKeyComLink = new List<TB_MatCodeKeyComLink>();
                    //有没有
                    if (db.TB_MatCodeKeyComLink.Count(p=>p.MatCode==matcode)>0)
                    {
                        list_MatCodeKeyComLink = db.TB_MatCodeKeyComLink.Where(p => p.MatCode == matcode).ToList();
                    }
                    foreach (var item in list_MatCodeKeyComLink)
                    {
                        item.TB_KeyComponentsInfoReference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_KeyComInfo.DataSource = list_MatCodeKeyComLink;
                    
                    #endregion

                }
                Changeprobar(false);
            }
        }

        /// <summary>
        /// 按订货编号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_Ser2_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txt_Dinghuobianhao.Text))
        //    {
        //        MessageBox.Show("请先输入要查询的订货编号！");
        //    }
        //    else
        //    {
        //        string dinghuobiahao = txt_Dinghuobianhao.Text;
        //        using (XinYaDBEntities db = new XinYaDBEntities())
        //        {
        //            try
        //            {
        //                #region 工艺路线记录

        //                //加载所有(另一种方法是根据泵号筛选任务号，通过任务号获取工艺路线记录)
        //                List<TB_WorkDtlForEachStation> a = db.TB_WorkDtlForEachStation.ToList();
        //                List<TB_WorkDtlForEachStation> b = new List<TB_WorkDtlForEachStation>();
        //                //加载完全
        //                foreach (var item in a)
        //                {
        //                    item.TB_WorkMainReference.Load();
        //                    item.TB_UserReference.Load();
        //                    item.TB_SecondWorkStationInfoReference.Load();
        //                }
        //                //匹配
        //                foreach (var item in a)
        //                {
        //                    foreach (var item2 in item.TB_WorkMain.TB_WorkDtl.ToList())
        //                    {
        //                        if (item2.TB_MaterialInfo.Dinghuobianhao==dinghuobiahao)
        //                        {
        //                            b.Add(item);
        //                            break;
        //                        }
        //                    }
        //                }
        //                dgv_WorkForEachWorkStation.DataSource = b;

        //                #endregion

        //                #region 异常返修记录

        //                //找出泵体在任务明细表中的记录，这里考虑到返修上线，可能有多条记录
        //                List<TB_WorkDtl> list_workDtl = db.TB_WorkDtl.Where(p => p.TB_MaterialInfo.Dinghuobianhao == dinghuobiahao).ToList();
        //                List<TB_WorkException> list_workException = new List<TB_WorkException>();
        //                //对每一条记录进行匹配
        //                foreach (var item in list_workDtl)
        //                {
        //                    var c = db.TB_WorkException.Where(p => p.WorkDtlID == item.ID).ToList();
        //                    foreach (var item2 in c)
        //                    {
        //                        list_workException.Add(item2);
        //                    }
        //                }
        //                //加载完全
        //                foreach (var item in list_workException)
        //                {
        //                    item.TB_ExceptionReference.Load();
        //                    item.TB_SecondWorkStationInfoReference.Load();
        //                    item.TB_UserReference.Load();
        //                    item.TB_WorkDtlReference.Load();
        //                }
        //                dgv_WorkException.DataSource = list_workException;

        //                #endregion

        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("查询出现异常！");
        //                SystemLogHelper.WriteSysLogHelper("查询出现异常" + ex.ToString(), user.ID, "质量追踪");
        //            }
        //        }
        //    }
        //}
       
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

        #region dgv Formatting事件

        /// <summary>
        /// dgv_WorkForEachWorkStation加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkForEachWorkStation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkForEachWorkStation.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkForEachWorkStation.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkForEachWorkStation.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkForEachWorkStation.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_WorkException加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkException_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkException.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkException.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkException.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkException.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_QCRecord加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_QCRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_QCRecord.Rows[e.RowIndex].DataBoundItem != null) && (dgv_QCRecord.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_QCRecord.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_QCRecord.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        if (result==null)
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
        /// dgv_KeyComInfo加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_KeyComInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_KeyComInfo.Rows[e.RowIndex].DataBoundItem != null) && (dgv_KeyComInfo.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_KeyComInfo.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_KeyComInfo.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        #region 数据导出
        /// <summary>
        /// 导出工艺路线记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportWorkExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_WorkForEachWorkStation.RowCount <= 0 || dgv_WorkForEachWorkStation.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_WorkForEachWorkStation) == 0)
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
        /// 导出异常维修记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImpotExceptionExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_WorkException.RowCount <= 0 || dgv_WorkException.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_WorkException) == 0)
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
        /// 导出返修记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputRepairRecord_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_Fanxiu);
            Changeprobar(false);
        }

        /// <summary>
        /// 导出QC记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputQCRecord_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_QCRecord);
            Changeprobar(false);
        }

        /// <summary>
        /// 导出扫描打码记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputScanRecord_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_ScanRecord);
            Changeprobar(false);
        }

        /// <summary>
        /// 导出关键零部件信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutputKeyComInfo_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            BllHelp.DataOutport(dgv_KeyComInfo);
            Changeprobar(false);
        } 
        #endregion
    }
}
