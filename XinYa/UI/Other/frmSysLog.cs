using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XinYa.UI.Other
{
    public partial class frmSysLog : Form
    {
        DataSet ds;
        LinkDb lnk = new LinkDb();
        BindingSource bs = new BindingSource();
        int PageCount = 0;
        int PageSize = 18;
        int PageIndex = 1;
        int RsCount = 0;

        public frmSysLog()
        {
            InitializeComponent();
        }

        private void frmSysLog_Load(object sender, EventArgs e)
        {

           // this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
           // this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2); //Bounds

            //getV(1);
            if (RsCount < PageSize) btnEnabled(false, false);
            else btnEnabled(false, true);
        }

        void getV(int PageIndex)
        {
            //PageSize = (int)upPageSize.Value;

            ds = Proc.GetPageList("V_SysLogSrh", "", "操作时间", PageSize, PageIndex, 0, "操作员代号<>''", out PageCount, out RsCount);

            txtPageCount.Text = PageCount.ToString();
            txtPageIndex.Text = PageIndex.ToString();
            bs.DataSource = ds.Tables[0];
            bindingNavigator1.BindingSource = bs;
            dv.DataSource = bs;
           // Other.FormatDgv(dv);
        }

        void GoFirstPage()
        {
            PageIndex = 1;
            getV(PageIndex);
            btnEnabled(false, true);
        }

        void GoPreviousPage()
        {
            PageIndex = PageIndex > 1 ? PageIndex - 1 : 1;
            getV(PageIndex);
            if (PageIndex > 1) btnEnabled(true, true);
            else btnEnabled(false, true);
        }

        void GoNextPage()
        {
            PageIndex = (PageIndex > PageCount - 1) ? PageIndex : PageIndex + 1;
            getV(PageIndex);
            if (PageIndex > PageCount - 1) btnEnabled(true, false);
            else btnEnabled(true, true);
        }

        void GoLastPage()
        {
            PageIndex = PageCount;
            getV(PageIndex);
            btnEnabled(true, false);
        }

        void btnEnabled(bool a, bool b)
        {
            btnFirstPage.Enabled = a;
            btnPreviousPage.Enabled = a;
            btnNextPage.Enabled = b;
            btnLastPage.Enabled = b;
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            GoFirstPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            GoPreviousPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            GoNextPage();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            GoLastPage();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dv.RowCount <= 0) return;
            ExportData.DataGridViewToExcel(dv);
        }

        private void btnExportNote_Click(object sender, EventArgs e)
        {
            ExportData.SaveToNotePad(dv);
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            if (dv.RowCount <= 0) return;
            if (Login.lgUserClass != "3")
            {
                MessageBox.Show("只有系统管理员级用户才可允许清除日志操作！");
                return;
            }

            if (MessageBox.Show("这将删除表中所有的日志记录，一旦清除将无法恢复！\r\n              您确定要这样做吗？","警告",MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (lnk.DeleteAll("tblSysLog"))
            {
                Proc.InsLog(Login.lgUserId, "001", 3);
                PageIndex = 1;
                getV(PageIndex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getV(PageIndex);
        }


   
    }
}