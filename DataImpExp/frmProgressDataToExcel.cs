using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Threading;



namespace DataImpExp
{
    public enum IEDataSourceType {dstDataTable=0,dstDataGridView = 1 ,dstDataGrid = 2 };
  
    public partial class frmProgressDataToExcel : Form
    {

        #region 私有变量
        int nRows = 0;
        int nCols = 0;
        int nCurrR = 0;
        int nCurrC = 0;

        private Excel.Application appExcel = null;
        private Excel.Workbook wkBook = null;
        private Excel.Worksheet wkSheet = null;
        private Excel.Range range = null;

        DateTime dBegin;
        DateTime dEnd;
        #endregion

        #region 公共变量
            public delegate void ChangeControlText(Control ctrl,string sText);
            public delegate void ChangleProgressValue(ProgressBar prg, int nValue);
            public delegate void SetProgresMaxMinValue(ProgressBar prg, int nMax,int nMin);
            public delegate void ThrdCloseForm();
        #endregion
        #region 公共属性
        private DataTable _TbData = null;
        public DataTable TbData
        {
            get { return _TbData; }
            set { _TbData = value; }
        }        

        private string _RptTitle = "";
        public string RptTitle
        {
            get { return _RptTitle; }
            set { _RptTitle = value; }
        }

        private DataGridView _GrdData = null;
        public DataGridView GrdData
        {
            get { return _GrdData; }
            set { _GrdData = value; }
        }

        private IEDataSourceType _DataSourceType = IEDataSourceType.dstDataTable;
        public IEDataSourceType DataSourceType
        {
            get { return _DataSourceType; }
            set { _DataSourceType = value; }
        }

        private string _FileName = "";
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        #endregion

        #region 私有方法

            private void ThreadCloseForm()
            {
                if (this.InvokeRequired)
                {
                    ThrdCloseForm d = new ThrdCloseForm(ThreadCloseForm);
                    this.Invoke(d, null);
                }
                else
                {
                    Close();
                }
            }
            private void SetControlText(Control ctrl, string sText)
            {
                if (ctrl.InvokeRequired)
                {
                    ChangeControlText d = new ChangeControlText(SetControlText);
                    this.Invoke(d, new object[] { ctrl, sText });
                }
                else
                {
                    ctrl.Text = sText;
                    Update();
                }
            }

            private void SetProgressValue(ProgressBar prg, int nValue)
            {
                if (prg.InvokeRequired)
                {
                    ChangleProgressValue d = new ChangleProgressValue(SetProgressValue);
                    this.Invoke(d, new object[] { prg, nValue });
                }
                else
                {
                    prg.Value = nValue;
                    Update();
                }
            }

            private void SetProgressMaxMin(ProgressBar prg, int nMax, int nMin)
            {
                if (prg.InvokeRequired)
                {
                    SetProgresMaxMinValue d = new SetProgresMaxMinValue(SetProgressMaxMin);
                    this.Invoke(d, new object[] { prg, nMax,nMin });
                }
                else
                {
                    prg.Maximum = nMax;
                    prg.Minimum = nMin;
                    Update();
                }
            }

            private void DoExportExcel()
            {
                switch (_DataSourceType)
                {
                    case IEDataSourceType.dstDataTable :
                        DataTableToExcel();
                        //Close();
                        break;
                    case IEDataSourceType.dstDataGridView :
                        DataGridViewToExcel();
                        //Close();
                        break;
                    case IEDataSourceType.dstDataGrid :
                        break;
                }
            }

            private void DataTableToExcel()
            {
                if (_TbData == null) return;
                dBegin = DateTime.Now;
                if (appExcel == null)
                {
                    appExcel = new Excel.Application();
                }
                wkBook = appExcel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                wkSheet = (Excel.Worksheet)wkBook.Worksheets[1];
                appExcel.Visible = false;
                dEnd = DateTime.Now;
                nCols = _TbData.Columns.Count;
                nRows = _TbData.Rows.Count;

                nCurrR = 1;
                nCurrC = 1;
                if (_RptTitle != "")
                {
                    SetControlText((Control)lblState, "正在处理表头......");                                                 
                    wkSheet.Cells[nCurrR, nCurrC] = _RptTitle;
                    range = wkSheet.get_Range(wkSheet.Cells[nCurrR, 1], wkSheet.Cells[nCurrR, nCols]);
                    range.MergeCells = true;
                    range.Font.Bold = true;
                    range.Font.Size = 18;
                    range.Font.Name = "宋体";
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //range.EntireColumn.AutoFit();//自动调整列宽
                    range.EntireRow.AutoFit();//自动调整行高
                    nRows++;
                    nCurrR ++;
                }
                nRows++;//列头
                SetProgressMaxMin(prgMain, nRows, 0);
                SetProgressValue(prgMain, nCurrR);
                //列头
                SetControlText((Control)lblState, "正在处理列头......");
                for (nCurrC = 1; nCurrC <= nCols; nCurrC++)
                {
                    wkSheet.Cells[nCurrR, nCurrC] = _TbData.Columns[nCurrC - 1].ColumnName;
                }
                nCurrR++;
                SetProgressValue(prgMain, nCurrR);
                //数据
                foreach(DataRow dr in _TbData.Rows)
                {
                    for(nCurrC = 0;nCurrC < nCols;nCurrC ++)
                    {
                        if (dr[nCurrC] != null)
                        {
                            string sX = dr[nCurrC].ToString().Trim();
                            if (sX.StartsWith("="))
                            {
                                sX = "'" + sX;
                            }
                            wkSheet.Cells[nCurrR, nCurrC + 1] = sX;
                        }
                        else
                        {
                            wkSheet.Cells[nCurrR, nCurrC + 1] = "";
                        }
                    }
                    
                    SetControlText((Control)lblState, "正在处理数据......("+ nCurrR.ToString() + "/" + nRows.ToString()+")");
                    SetProgressValue(prgMain, nCurrR);
                    nCurrR++;
                }
                range = null;
                range = wkSheet.get_Range(wkSheet.Cells[1, 1], wkSheet.Cells[nRows, nCols]);
                //加表格线
                range.Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = Excel.XlBorderWeight.xlThin;
               //外框加粗
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;

                if (_FileName.Trim() == "")
                {
                    _FileName = System.IO.Path.Combine(Application.StartupPath, _TbData.TableName + ".xls");                
                }
                if (_FileName.ToLower().IndexOf(".xls") <= 0)
                {
                    _FileName += ".xls";
                }
                //wkBook.SaveCopyAs(_FileName);
                wkBook.SaveAs(_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                appExcel.Workbooks.Close();
                appExcel.Quit();
                DataIE.KillProgress((IntPtr)appExcel.Hwnd);
                appExcel = null;
                
                //DataIE.KillProgress("EXCEL", dBegin, dEnd);
                MessageBox.Show("已经成功导出：" + _FileName);
                //appExcel.Application.Quit(); 
                //ThreadCloseForm();
                Close();
                
                          
            }

            private void DataGridViewToExcel()
            {
                bool bOK = false;
                string sExeName = "";
                if (_GrdData == null) return;
                dBegin = DateTime.Now;
                if (appExcel == null)
                {
                    appExcel = new Excel.Application();                    
                }
                wkBook = appExcel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                wkSheet = (Excel.Worksheet)wkBook.Worksheets[1];
                appExcel.Visible = false;
                dEnd = DateTime.Now;

                nCols = _GrdData.ColumnCount;
                nRows = _GrdData.Rows.Count;

                nCurrR = 1;
                nCurrC = 1;
                if (_RptTitle != "")
                {
                    SetControlText((Control)lblState, "正在处理报表头......");
                    wkSheet.Cells[nCurrR, nCurrC] = _RptTitle;
                    range = wkSheet.get_Range(wkSheet.Cells[nCurrR, 1], wkSheet.Cells[nCurrR, nCols]);
                    range.MergeCells = true;
                    range.Font.Bold = true;
                    range.Font.Size = 18;
                    range.Font.Name = "宋体";
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //range.EntireColumn.AutoFit();//自动调整列宽
                    range.EntireRow.AutoFit();//自动调整行高
                    nRows++;
                    nCurrR++;
                }
                nRows++;//列头
                SetProgressMaxMin(prgMain, nRows, 0);
                SetProgressValue(prgMain, nCurrR);
                //列头
                SetControlText((Control)lblState, "正在处理列头......");
                for (nCurrC = 1; nCurrC <= nCols; nCurrC++)
                {
                    wkSheet.Cells[nCurrR, nCurrC] = _GrdData.Columns[nCurrC - 1].HeaderText;
                }
                nCurrR++;
                //数据
                try
                {
                    foreach (DataGridViewRow dr in _GrdData.Rows)
                    {
                        for (nCurrC = 0; nCurrC < nCols; nCurrC++)
                        {
                            if (dr.Cells[nCurrC].Value != null)
                            {
                                try
                                {
                                    string sX = dr.Cells[nCurrC].Value.ToString().Trim();
                                    if (sX.StartsWith("="))
                                    {
                                        sX = "'" + sX ;
                                    }
                                    wkSheet.Cells[nCurrR, nCurrC + 1] = sX;
                                }
                                catch (Exception ex)
                                {
                                    string s = wkSheet.Cells[nCurrR, nCurrC + 1].ToString();
                                    string s2 = dr.Cells[nCurrC].Value.ToString();
                                    MessageBox.Show(string.Format("在：nCurrC=[{3}]   nCurrR=[{4}]==[{0}]=:=[{1}]=:=[{2}]  nCols=[{5}]", s, ex.Message, s2, nCurrC, nCurrR, nCols));
                                }
                            }
                            else
                            {
                                try
                                {
                                    wkSheet.Cells[nCurrR, nCurrC + 1] = "";
                                }
                                catch (Exception ex)
                                {
                                    string s = wkSheet.Cells[nCurrR, nCurrC + 1].ToString();                                  
                                    //MessageBox.Show(string.Format("{0}:{1} ", s, ex.Message ));
                                }
                            }
                        }

                        SetControlText((Control)lblState, "正在处理数据......(" + nCurrR.ToString() + "/" + nRows.ToString() + ")");
                        SetProgressValue(prgMain, nCurrR);
                        nCurrR++;
                    }
                }
                catch (Exception err)
                {
                    string sX = err.Source + "\r\n" + err.Message + err.StackTrace + "\r\n"+ err.TargetSite.ToString() ;
                    MessageBox.Show(sX);                    
                }
                range = null;
                range = wkSheet.get_Range(wkSheet.Cells[1, 1], wkSheet.Cells[nRows, nCols]);
                //加表格线
                range.Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = Excel.XlBorderWeight.xlThin;
                //外框加粗
                range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium;
                range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium;
                if (_FileName.Trim() == "")
                {
                    _FileName = System.IO.Path.Combine(Application.StartupPath, "datagrid.xls");
                }
                if (_FileName.ToLower().IndexOf(".xls") <= 0)
                {
                    _FileName += ".xls";
                }
               
                //wkBook.SaveCopyAs(_FileName);
                if (File.Exists(_FileName))
                {
                    try
                    {
                        File.Delete(_FileName);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                try
                {                    
                    wkBook.SaveAs(_FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    bOK = true;
                }
                catch (Exception err)
                {
                    bOK = false;
                    MessageBox.Show(err.Message);
                }
                //wkBook.Close();
                //wkBook.Close(null, null, null);

                //appExcel.Visible = true;
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(appExcel);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(wkSheet);
                //wkSheet = null;
                
                //wkBook = null;
                
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(wkBook);
                
                //wkBook.Close(null, null, null);
                //wkBook = null;
                try
                {
                    appExcel.Workbooks.Close();
                    appExcel.Quit();
                    DataIE.KillProgress((IntPtr)appExcel.Hwnd);
                    appExcel = null;
                }
                catch (Exception err)
                {
                    bOK = false;
                    MessageBox.Show(err.Message);
                }
                //GC.Collect();
                //DataIE.KillProgress("EXCEL", dBegin, dEnd);
                if (bOK)
                    MessageBox.Show("已经成功导出：" + _FileName);
                //appExcel.Application.Quit(); 
                //ThreadCloseForm();
                Close();
            }

            private void DoData()
            {
                if (_FileName.Trim() == "")
                {
                    if (dlgSave.ShowDialog() == DialogResult.OK)
                    {
                        _FileName = dlgSave.FileName;
                    }
                }
                Thread thrdX = new Thread(new ThreadStart(DoExportExcel));
                thrdX.Start();
            }

        #endregion
        public frmProgressDataToExcel()
        {
            InitializeComponent();
        }

        private void frmProgressDataToExcel_Load(object sender, EventArgs e)
        {
            //DoData();
            trmMain.Enabled = true;
        }

        private void trmMain_Tick(object sender, EventArgs e)
        {
            trmMain.Enabled = false;
            DoExportExcel();

        }

        
    }
}