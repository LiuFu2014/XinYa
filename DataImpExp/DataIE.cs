using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using Excel;

namespace DataImpExp
{
    public static class DataIE
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        public static void KillProgress(string progressName, DateTime dBegin, DateTime dEnd)
        {
            System.Diagnostics.Process[] myPros = null;
            DateTime dtime;
            myPros = System.Diagnostics.Process.GetProcessesByName(progressName);
            if (myPros.Length == 0)
            {
                myPros = System.Diagnostics.Process.GetProcesses();
            }
            myPros = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process pro in myPros)
            {
                if (!pro.HasExited)
                {
                    dtime = pro.StartTime;

                    if (dtime >= dBegin && dtime <= dEnd)
                    {
                        pro.Kill();
                        return;
                    }
                }
            }
        }

        public static void KillProgress(IntPtr hHwnd)
        {
            int k = 0;
            try
            {
                GetWindowThreadProcessId(hHwnd, out k); //得到本进程唯一标志k             
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k); //得到对进程k的引用 
                p.Kill(); //关闭进程k 
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        public static void DataGridViewToExcel(DataGridView grdX, string sFile, string sTitle)
        {
            frmProgressDataToExcel frmX = new frmProgressDataToExcel();
            frmX.DataSourceType = IEDataSourceType.dstDataGridView;
            frmX.GrdData = grdX;
            frmX.RptTitle = sTitle.Trim();
            frmX.FileName = sFile;
            frmX.ShowDialog();
            frmX.Dispose();
        }

        public static void DataTableToExcel(System.Data.DataTable tbData, string sFile, string sTitle)
        {
            frmProgressDataToExcel frmX = new frmProgressDataToExcel();
            frmX.DataSourceType = IEDataSourceType.dstDataTable;
            frmX.TbData = tbData;
            frmX.RptTitle = sTitle.Trim();
            frmX.FileName = sFile;
            frmX.ShowDialog();
            frmX.Dispose();
        }
    }
}
