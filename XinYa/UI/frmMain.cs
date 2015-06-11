using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XinYa.UI.Other;

namespace XinYa.UI
{
    public partial class frmMain : Form
    {
        #region 子窗体定义

        //private frm.frmAbout about;
        //private UI.Other.frmSysLog log;
        private UI.Other.frm_Calculator Calc;

        #endregion 子窗体定义

        private bool fExit = false;
        //private string sendTableName = "tblGrant";
        //private string sendStrSQL;
        private DataSet ds = new DataSet();


        private void frmMain_Load(object sender, EventArgs e)
        {  
            DateTime dt = DateTime.Now;
            statusStrip1.Items[0].Text = "操作员："; //+Login.lgUserName;
            statusStrip1.Items[1].Text = "日期：" + dt.ToShortDateString();//ToLongDateString();
            statusStrip1.Items[2].Text = "登录时间：" + dt.ToLongTimeString();
            #region 配色
            this.p_Main.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            this.mnuMain.BackColor = Color.FromArgb(0xBD, 0xBA, 0xBA);
            this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            #endregion

        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要结束WMS系统吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // 在退出程序之前，首先关闭已打开的子窗体
            Form[] children = this.MdiChildren;	// 获取当前打开的子窗体
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Close();		// 关闭子窗体
            }
            Application.Exit();
        }

        /// <summary>
        /// Fu_这些蛋疼的命名...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem106_Click(object sender, EventArgs e)
        {
            //Login.reLog = true;
            //this.Hide();
            //new frm.frmLogin().Show();
        }


        private void ToolBarStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = ToolBarStripMenuItem.Checked;
        }

        private void StatusBarStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip1.Visible = StatusBarStripMenuItem.Checked;
        }

        //private int childFormNumber = 0;
        private void 操作帮助ToolStripMenuItem_Click(object sender, EventArgs e)//test...
        {

        }

        private void ToolStripMenuItem207_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem104_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem903_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical); 

        }

        //----------------------查询MDI子窗体是否存在-----------------------------
        /// <summary>
        /// 查询MDI子窗体是否存在
        /// </summary>
        /// <param name="childFrmName"></param>
        /// <returns></returns>
        private bool checkChildFrmExist(string childFrmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == childFrmName) //用子窗体的Name进行判断，如果存在则将他激活
                {
                    if (childFrm.WindowState == FormWindowState.Minimized)
                        childFrm.WindowState = FormWindowState.Normal;
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void menu702_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void menu701_Click(object sender, EventArgs e)
        {
            if (Calc == null || Calc.IsDisposed)
            {
                Calc = new frm_Calculator();
                Calc.MdiParent = this;
            }
            Calc.Show();
            if (Calc.WindowState == FormWindowState.Minimized)
                Calc.WindowState = FormWindowState.Normal;
            Calc.Activate();
        }

        private void menu703_Click(object sender, EventArgs e)
        {
            if (System.DateTime.Today.Year > 2100)
            {
                MessageBox.Show("Sorry！本万年历的最高使用年限为2100年！");
                return;
            }
            Help.ShowHelp(this, @".\WNL.exe");
        }

        private void menu601_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.22_综合查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu602_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 盘库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu501_Click(object sender, EventArgs e)
        {

        }

        private void menu502_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 任务管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu504_Click(object sender, EventArgs e)
        {
        }

        private void menu506_Click(object sender, EventArgs e)
        {

        }

        private void menu401_Click(object sender, EventArgs e)
        {
        }

        private void menu402_Click(object sender, EventArgs e)
        {
        }

        private void menu303_Click(object sender, EventArgs e)
        {

        }

        private void menu203_Click(object sender, EventArgs e)
        {
        }

        private void menu201_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 物料编码录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu206_Click(object sender, EventArgs e)
        {

        }

        private void menu207_Click(object sender, EventArgs e)
        {

        }

        private void menu208_Click(object sender, EventArgs e)
        {

        }

        private void menu101_Click(object sender, EventArgs e)
        {
            //if (checkChildFrmExist("frmSysLog")) return;

            //if (log == null || log.IsDisposed)
            //{
            //    log = new frmSysLog();
            //    log.MdiParent = this;
            //}
            //log.Show();
        }

        private void menu104_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @".\Backup.exe");
            //if (bak == null || bak.IsDisposed)
            //{
            //    bak = new WMS.frm.frmBackup();
            //    bak.MdiParent = this;
            //}
            //bak.Show();
            //if (bak.WindowState == FormWindowState.Minimized)
            //    bak.WindowState = FormWindowState.Normal;
            //bak.Activate();
        }

        private void menu106_Click(object sender, EventArgs e)
        {
            //Login.reLog = true;
            //this.Hide();
            //new frm.frmLogin().Show();
        }

        private void menu107_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要结束WMS系统吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // 在退出程序之前，首先关闭已打开的子窗体
            Form[] children = this.MdiChildren;	// 获取当前打开的子窗体
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Close();		// 关闭子窗体
            }

            //if (!Login.reLog) 
                Application.Exit();
        }

        private void menu901_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade); 
        }

        private void menu902_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal); 
        }

        private void menu903_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal); 
        }

        private void menu204_Click(object sender, EventArgs e)
        {

        }

        private void menu202_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.22_仓位图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu505_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.24_入库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu603_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.24_出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu604_Click(object sender, EventArgs e)
        {

        }

        private void menu605_Click(object sender, EventArgs e)
        {

        }

        private void menu606_Click(object sender, EventArgs e)
        {
        }

        private void menu607_Click(object sender, EventArgs e)
        {

        }

        private void menu801_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @".\wms.pdf");
        }

        private void menu102_Click(object sender, EventArgs e)
        {
        }

        private void menu103_Click(object sender, EventArgs e)
        {

        }

        private void menu210_Click(object sender, EventArgs e)
        {

        }

        private void menu301_Click(object sender, EventArgs e)
        {
            //if (workerInfo == null || workerInfo.IsDisposed)
            //{
            //    workerInfo = new frm_WorkerInfo();
            //    workerInfo.MdiParent = this;
            //    workerInfo.StartPosition = FormStartPosition.CenterScreen;
            //}
            //workerInfo.WindowState = FormWindowState.Normal;
            //workerInfo.Show();
            //workerInfo.Activate();
        }

        private void menu302_Click(object sender, EventArgs e)
        {

        }

        private void menu403_Click(object sender, EventArgs e)
        {

        }

        private void menu608_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {

        }

     

        private void menu209_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("您现在要导入ERP相关数据吗！", "导入ERP数据", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            //{
            //    SqlConnection Conn = new SqlConnection();
            //    Conn = Login.Cn();
            //    SqlCommand cmd = new SqlCommand("Proc_GetErpBaseData", Conn);
            //    //cmd.CommandTimeout = 50;
            //    cmd.Connection = Conn;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    try
            //    {
            //        this.Cursor = Cursors.WaitCursor;
            //        cmd.ExecuteNonQuery();
            //        Conn.Close();
            //        this.Cursor = Cursors.Default;
            //        MessageBox.Show("ERP数据导入完成！");
            //    }
            //    catch
            //    {
            //        this.Cursor = Cursors.Default;
            //        MessageBox.Show(e.ToString() + "ERP数据导入超时，请重新导入；如还有问题，请与系统管理员联系！");
            //    }
            //}
            //else
            //    return;


        }

        #region 入库指令
       
        private void MenuItem111_Click(object sender, EventArgs e)
        {


        }

        #endregion

        #region 出库指令


        private void MenuItem110_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region Fu_7.25_历史明细查询

        private void tsmi_HistorySearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void menu105_Click(object sender, EventArgs e)
        {

        }
    }
}