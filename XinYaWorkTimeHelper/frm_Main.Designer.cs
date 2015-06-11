namespace XinYaWorkTimeHelper
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.lab_StatusBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_StatusTextBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu_Main = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu101 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu102 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助及其他HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu202 = new System.Windows.Forms.ToolStripMenuItem();
            this.p_Main = new System.Windows.Forms.Panel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.btn_Banding = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_UserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lab_Time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_Xianduan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_Banding = new System.Windows.Forms.GroupBox();
            this.p_BandingMain = new System.Windows.Forms.Panel();
            this.dgv_Banding = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_Main.SuspendLayout();
            this.menu_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.gb_Banding.SuspendLayout();
            this.p_BandingMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Banding)).BeginInit();
            this.SuspendLayout();
            // 
            // status_Main
            // 
            this.status_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.status_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_StatusBottom,
            this.lab_StatusTextBottom});
            this.status_Main.Location = new System.Drawing.Point(0, 720);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(1264, 22);
            this.status_Main.TabIndex = 14;
            this.status_Main.Text = "statusStrip1";
            // 
            // lab_StatusBottom
            // 
            this.lab_StatusBottom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_StatusBottom.Name = "lab_StatusBottom";
            this.lab_StatusBottom.Size = new System.Drawing.Size(44, 17);
            this.lab_StatusBottom.Text = "状态：";
            this.lab_StatusBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_StatusTextBottom
            // 
            this.lab_StatusTextBottom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_StatusTextBottom.Name = "lab_StatusTextBottom";
            this.lab_StatusTextBottom.Size = new System.Drawing.Size(32, 17);
            this.lab_StatusTextBottom.Text = "就绪";
            // 
            // menu_Main
            // 
            this.menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助及其他HToolStripMenuItem});
            this.menu_Main.Location = new System.Drawing.Point(0, 0);
            this.menu_Main.Name = "menu_Main";
            this.menu_Main.Size = new System.Drawing.Size(1264, 25);
            this.menu_Main.TabIndex = 15;
            this.menu_Main.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu101,
            this.menu102});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // menu101
            // 
            this.menu101.Name = "menu101";
            this.menu101.Size = new System.Drawing.Size(124, 22);
            this.menu101.Text = "测试通讯";
            this.menu101.Click += new System.EventHandler(this.menu101_Click);
            // 
            // menu102
            // 
            this.menu102.Name = "menu102";
            this.menu102.Size = new System.Drawing.Size(124, 22);
            this.menu102.Text = "退出系统";
            this.menu102.Click += new System.EventHandler(this.menu102_Click);
            // 
            // 帮助及其他HToolStripMenuItem
            // 
            this.帮助及其他HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu202});
            this.帮助及其他HToolStripMenuItem.Name = "帮助及其他HToolStripMenuItem";
            this.帮助及其他HToolStripMenuItem.Size = new System.Drawing.Size(97, 21);
            this.帮助及其他HToolStripMenuItem.Text = "帮助及其他(&H)";
            // 
            // menu202
            // 
            this.menu202.Name = "menu202";
            this.menu202.Size = new System.Drawing.Size(124, 22);
            this.menu202.Text = "帮助说明";
            this.menu202.Click += new System.EventHandler(this.menu202_Click);
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.split_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(1264, 695);
            this.p_Main.TabIndex = 16;
            // 
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 0);
            this.split_Main.Name = "split_Main";
            this.split_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.btn_Banding);
            this.split_Main.Panel1.Controls.Add(this.label8);
            this.split_Main.Panel1.Controls.Add(this.lab_UserName);
            this.split_Main.Panel1.Controls.Add(this.label6);
            this.split_Main.Panel1.Controls.Add(this.lab_Time);
            this.split_Main.Panel1.Controls.Add(this.label4);
            this.split_Main.Panel1.Controls.Add(this.lab_Xianduan);
            this.split_Main.Panel1.Controls.Add(this.label2);
            this.split_Main.Panel1.Controls.Add(this.label1);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.gb_Banding);
            this.split_Main.Size = new System.Drawing.Size(1264, 695);
            this.split_Main.SplitterDistance = 131;
            this.split_Main.TabIndex = 0;
            // 
            // btn_Banding
            // 
            this.btn_Banding.BackColor = System.Drawing.Color.Gold;
            this.btn_Banding.Location = new System.Drawing.Point(795, 92);
            this.btn_Banding.Name = "btn_Banding";
            this.btn_Banding.Size = new System.Drawing.Size(75, 23);
            this.btn_Banding.TabIndex = 8;
            this.btn_Banding.Text = "绑定";
            this.btn_Banding.UseVisualStyleBackColor = false;
            this.btn_Banding.Click += new System.EventHandler(this.btn_Banding_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(394, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(394, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "请在输入完成后且确保无误后，点击绑定今日工作信息";
            // 
            // lab_UserName
            // 
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_UserName.Location = new System.Drawing.Point(669, 56);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(42, 22);
            this.lab_UserName.TabIndex = 6;
            this.lab_UserName.Text = "员工";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(585, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "操作员：";
            // 
            // lab_Time
            // 
            this.lab_Time.AutoSize = true;
            this.lab_Time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Time.Location = new System.Drawing.Point(807, 57);
            this.lab_Time.Name = "lab_Time";
            this.lab_Time.Size = new System.Drawing.Size(42, 22);
            this.lab_Time.TabIndex = 4;
            this.lab_Time.Text = "时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(741, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "时间:";
            // 
            // lab_Xianduan
            // 
            this.lab_Xianduan.AutoSize = true;
            this.lab_Xianduan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Xianduan.Location = new System.Drawing.Point(513, 57);
            this.lab_Xianduan.Name = "lab_Xianduan";
            this.lab_Xianduan.Size = new System.Drawing.Size(42, 22);
            this.lab_Xianduan.TabIndex = 2;
            this.lab_Xianduan.Text = "线段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(417, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前线段：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(496, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "鑫亚软控-工时统计辅助程序";
            // 
            // gb_Banding
            // 
            this.gb_Banding.Controls.Add(this.p_BandingMain);
            this.gb_Banding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Banding.Location = new System.Drawing.Point(0, 0);
            this.gb_Banding.Name = "gb_Banding";
            this.gb_Banding.Size = new System.Drawing.Size(1264, 560);
            this.gb_Banding.TabIndex = 0;
            this.gb_Banding.TabStop = false;
            this.gb_Banding.Text = "绑定列表";
            // 
            // p_BandingMain
            // 
            this.p_BandingMain.Controls.Add(this.dgv_Banding);
            this.p_BandingMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_BandingMain.Location = new System.Drawing.Point(3, 17);
            this.p_BandingMain.Name = "p_BandingMain";
            this.p_BandingMain.Size = new System.Drawing.Size(1258, 540);
            this.p_BandingMain.TabIndex = 0;
            // 
            // dgv_Banding
            // 
            this.dgv_Banding.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Banding.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Banding.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Banding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Banding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_SecondWorkStationName,
            this.c_UserID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Banding.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Banding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Banding.Location = new System.Drawing.Point(0, 0);
            this.dgv_Banding.Name = "dgv_Banding";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Banding.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Banding.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Banding.RowTemplate.Height = 23;
            this.dgv_Banding.Size = new System.Drawing.Size(1258, 540);
            this.dgv_Banding.TabIndex = 0;
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "第二工位ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_SecondWorkStationName
            // 
            this.c_SecondWorkStationName.DataPropertyName = "SecondWorkStationName";
            this.c_SecondWorkStationName.HeaderText = "工位名";
            this.c_SecondWorkStationName.Name = "c_SecondWorkStationName";
            this.c_SecondWorkStationName.ReadOnly = true;
            // 
            // c_UserID
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.c_UserID.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_UserID.HeaderText = "员工工号";
            this.c_UserID.Name = "c_UserID";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 742);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.menu_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_Main;
            this.Name = "frm_Main";
            this.Text = "鑫亚软控-工时辅助程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.menu_Main.ResumeLayout(false);
            this.menu_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel1.PerformLayout();
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.gb_Banding.ResumeLayout(false);
            this.p_BandingMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Banding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_StatusBottom;
        private System.Windows.Forms.ToolStripStatusLabel lab_StatusTextBottom;
        private System.Windows.Forms.MenuStrip menu_Main;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu101;
        private System.Windows.Forms.ToolStripMenuItem menu102;
        private System.Windows.Forms.ToolStripMenuItem 帮助及其他HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu202;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.GroupBox gb_Banding;
        private System.Windows.Forms.Panel p_BandingMain;
        private System.Windows.Forms.DataGridView dgv_Banding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Banding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_UserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lab_Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_Xianduan;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UserID;
    }
}