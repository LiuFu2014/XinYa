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
        #region �Ӵ��嶨��

        //private frm.frmAbout about;
        //private UI.Other.frmSysLog log;
        private UI.Other.frm_Calculator Calc;

        #endregion �Ӵ��嶨��

        private bool fExit = false;
        //private string sendTableName = "tblGrant";
        //private string sendStrSQL;
        private DataSet ds = new DataSet();


        private void frmMain_Load(object sender, EventArgs e)
        {  
            DateTime dt = DateTime.Now;
            statusStrip1.Items[0].Text = "����Ա��"; //+Login.lgUserName;
            statusStrip1.Items[1].Text = "���ڣ�" + dt.ToShortDateString();//ToLongDateString();
            statusStrip1.Items[2].Text = "��¼ʱ�䣺" + dt.ToLongTimeString();
            #region ��ɫ
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
            if (MessageBox.Show("ȷ��Ҫ����WMSϵͳ��", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // ���˳�����֮ǰ�����ȹر��Ѵ򿪵��Ӵ���
            Form[] children = this.MdiChildren;	// ��ȡ��ǰ�򿪵��Ӵ���
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Close();		// �ر��Ӵ���
            }
            Application.Exit();
        }

        /// <summary>
        /// Fu_��Щ���۵�����...
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
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)//test...
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

        //----------------------��ѯMDI�Ӵ����Ƿ����-----------------------------
        /// <summary>
        /// ��ѯMDI�Ӵ����Ƿ����
        /// </summary>
        /// <param name="childFrmName"></param>
        /// <returns></returns>
        private bool checkChildFrmExist(string childFrmName)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == childFrmName) //���Ӵ����Name�����жϣ����������������
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
                MessageBox.Show("Sorry���������������ʹ������Ϊ2100�꣡");
                return;
            }
            Help.ShowHelp(this, @".\WNL.exe");
        }

        private void menu601_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.22_�ۺϲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu602_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// �̿�
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
        /// �������
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
        /// ���ϱ���¼��
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
            if (MessageBox.Show("ȷ��Ҫ����WMSϵͳ��", "��ʾ", MessageBoxButtons.YesNo) == DialogResult.No) return;

            // ���˳�����֮ǰ�����ȹر��Ѵ򿪵��Ӵ���
            Form[] children = this.MdiChildren;	// ��ȡ��ǰ�򿪵��Ӵ���
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Close();		// �ر��Ӵ���
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
        /// Fu_7.22_��λͼ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu505_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.24_��ⵥ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu603_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fu_7.24_���ⵥ
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
            //if (MessageBox.Show("������Ҫ����ERP���������", "����ERP����", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
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
            //        MessageBox.Show("ERP���ݵ�����ɣ�");
            //    }
            //    catch
            //    {
            //        this.Cursor = Cursors.Default;
            //        MessageBox.Show(e.ToString() + "ERP���ݵ��볬ʱ�������µ��룻�绹�����⣬����ϵͳ����Ա��ϵ��");
            //    }
            //}
            //else
            //    return;


        }

        #region ���ָ��
       
        private void MenuItem111_Click(object sender, EventArgs e)
        {


        }

        #endregion

        #region ����ָ��


        private void MenuItem110_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region Fu_7.25_��ʷ��ϸ��ѯ

        private void tsmi_HistorySearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void menu105_Click(object sender, EventArgs e)
        {

        }
    }
}