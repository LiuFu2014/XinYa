namespace XinYa.UI.InfoSearch
{
    partial class frm_HistoryWorkTaskSer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HistoryWorkTaskSer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OutportMain = new System.Windows.Forms.ToolStripButton();
            this.btn_OutportDtl = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb_WorkM = new System.Windows.Forms.GroupBox();
            this.dgv_WorkM = new System.Windows.Forms.DataGridView();
            this.c_WorkID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PalletCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Finished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_IsCommit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_WorkP = new System.Windows.Forms.GroupBox();
            this.dgv_WorkP = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.check_All = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1.SuspendLayout();
            this.tool_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_WorkM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkM)).BeginInit();
            this.gb_WorkP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(955, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "状态：就绪";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_OutportMain,
            this.btn_OutportDtl,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(955, 25);
            this.tool_Main.TabIndex = 10;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "退出";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_OutportMain
            // 
            this.btn_OutportMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_OutportMain.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutportMain.Image")));
            this.btn_OutportMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OutportMain.Name = "btn_OutportMain";
            this.btn_OutportMain.Size = new System.Drawing.Size(84, 22);
            this.btn_OutportMain.Text = "导出历史任务";
            this.btn_OutportMain.Click += new System.EventHandler(this.btn_OutportMain_Click);
            // 
            // btn_OutportDtl
            // 
            this.btn_OutportDtl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_OutportDtl.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutportDtl.Image")));
            this.btn_OutportDtl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OutportDtl.Name = "btn_OutportDtl";
            this.btn_OutportDtl.Size = new System.Drawing.Size(84, 22);
            this.btn_OutportDtl.Text = "导出任务明细";
            this.btn_OutportDtl.Click += new System.EventHandler(this.btn_OutportDtl_Click);
            // 
            // lab_Status
            // 
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(92, 22);
            this.lab_Status.Text = "系统正在处理：";
            this.lab_Status.Visible = false;
            // 
            // prosbar_Main
            // 
            this.prosbar_Main.Name = "prosbar_Main";
            this.prosbar_Main.Size = new System.Drawing.Size(100, 22);
            this.prosbar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prosbar_Main.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb_WorkM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gb_WorkP);
            this.splitContainer1.Size = new System.Drawing.Size(955, 492);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 11;
            // 
            // gb_WorkM
            // 
            this.gb_WorkM.Controls.Add(this.dgv_WorkM);
            this.gb_WorkM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_WorkM.Location = new System.Drawing.Point(0, 0);
            this.gb_WorkM.Name = "gb_WorkM";
            this.gb_WorkM.Size = new System.Drawing.Size(955, 218);
            this.gb_WorkM.TabIndex = 0;
            this.gb_WorkM.TabStop = false;
            this.gb_WorkM.Text = "历史任务";
            // 
            // dgv_WorkM
            // 
            this.dgv_WorkM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_WorkM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_WorkM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_WorkID,
            this.c_PalletCode,
            this.c_Finished,
            this.c_IsCommit,
            this.c_Creator,
            this.c_CreateDate,
            this.c_SecondWorkStation});
            this.dgv_WorkM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_WorkM.Location = new System.Drawing.Point(3, 17);
            this.dgv_WorkM.Name = "dgv_WorkM";
            this.dgv_WorkM.RowTemplate.Height = 23;
            this.dgv_WorkM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_WorkM.Size = new System.Drawing.Size(949, 198);
            this.dgv_WorkM.TabIndex = 1;
            this.dgv_WorkM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_WorkM_CellClick);
            this.dgv_WorkM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_WorkM_CellFormatting);
            // 
            // c_WorkID
            // 
            this.c_WorkID.DataPropertyName = "WorkID";
            this.c_WorkID.HeaderText = "任务号";
            this.c_WorkID.Name = "c_WorkID";
            this.c_WorkID.ReadOnly = true;
            // 
            // c_PalletCode
            // 
            this.c_PalletCode.DataPropertyName = "PalletCode";
            this.c_PalletCode.HeaderText = "托盘号";
            this.c_PalletCode.Name = "c_PalletCode";
            this.c_PalletCode.ReadOnly = true;
            // 
            // c_Finished
            // 
            this.c_Finished.DataPropertyName = "Finished";
            this.c_Finished.FalseValue = "0";
            this.c_Finished.HeaderText = "是否完成";
            this.c_Finished.Name = "c_Finished";
            this.c_Finished.ReadOnly = true;
            this.c_Finished.TrueValue = "1";
            // 
            // c_IsCommit
            // 
            this.c_IsCommit.DataPropertyName = "IsCommit";
            this.c_IsCommit.FalseValue = "false";
            this.c_IsCommit.HeaderText = "是否提交";
            this.c_IsCommit.Name = "c_IsCommit";
            this.c_IsCommit.ReadOnly = true;
            this.c_IsCommit.TrueValue = "true";
            // 
            // c_Creator
            // 
            this.c_Creator.DataPropertyName = "TB_User.UserName";
            this.c_Creator.HeaderText = "任务创建者";
            this.c_Creator.Name = "c_Creator";
            this.c_Creator.ReadOnly = true;
            this.c_Creator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_Creator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // c_CreateDate
            // 
            this.c_CreateDate.DataPropertyName = "CreateDate";
            this.c_CreateDate.HeaderText = "任务创建时间";
            this.c_CreateDate.Name = "c_CreateDate";
            this.c_CreateDate.ReadOnly = true;
            this.c_CreateDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_CreateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // c_SecondWorkStation
            // 
            this.c_SecondWorkStation.DataPropertyName = "TB_SecondWorkStationInfo.SecondWorkStationName";
            this.c_SecondWorkStation.HeaderText = "任务来源工位";
            this.c_SecondWorkStation.Name = "c_SecondWorkStation";
            this.c_SecondWorkStation.ReadOnly = true;
            // 
            // gb_WorkP
            // 
            this.gb_WorkP.Controls.Add(this.dgv_WorkP);
            this.gb_WorkP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_WorkP.Location = new System.Drawing.Point(0, 0);
            this.gb_WorkP.Name = "gb_WorkP";
            this.gb_WorkP.Size = new System.Drawing.Size(955, 270);
            this.gb_WorkP.TabIndex = 0;
            this.gb_WorkP.TabStop = false;
            this.gb_WorkP.Text = "任务明细";
            // 
            // dgv_WorkP
            // 
            this.dgv_WorkP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_WorkP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_WorkP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_WorkP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_WorkP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_WorkP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_WorkP.Location = new System.Drawing.Point(3, 17);
            this.dgv_WorkP.Name = "dgv_WorkP";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_WorkP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_WorkP.RowTemplate.Height = 23;
            this.dgv_WorkP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_WorkP.Size = new System.Drawing.Size(949, 250);
            this.dgv_WorkP.TabIndex = 1;
            this.dgv_WorkP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_WorkP_CellFormatting);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ID";
            this.Column6.HeaderText = "子任务ID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PalletCode";
            this.Column7.HeaderText = "托盘编码";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "MaterialCode";
            this.Column8.HeaderText = "物料编码";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CreateDate";
            this.Column9.HeaderText = "创建时间";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "TB_Exception.ExceptionText";
            this.Column10.HeaderText = "异常状态";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "TB_User.UserName";
            this.Column11.HeaderText = "异常状态录入者";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "EditTime";
            this.Column12.HeaderText = "异常状态录入时间";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_Ser);
            this.splitContainer2.Panel1.Controls.Add(this.check_All);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dtp_EndTime);
            this.splitContainer2.Panel1.Controls.Add(this.dtp_BeginTime);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(955, 566);
            this.splitContainer2.SplitterDistance = 70;
            this.splitContainer2.TabIndex = 12;
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(798, 30);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 15;
            this.btn_Ser.Text = "查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // check_All
            // 
            this.check_All.AutoSize = true;
            this.check_All.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_All.Location = new System.Drawing.Point(704, 28);
            this.check_All.Name = "check_All";
            this.check_All.Size = new System.Drawing.Size(61, 25);
            this.check_All.TabIndex = 14;
            this.check_All.Text = "全部";
            this.check_All.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(389, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "结束时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(81, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "开始时间:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Location = new System.Drawing.Point(482, 24);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_EndTime.TabIndex = 10;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime.Location = new System.Drawing.Point(174, 24);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_BeginTime.TabIndex = 9;
            // 
            // frm_HistoryWorkTaskSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 613);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.tool_Main);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_HistoryWorkTaskSer";
            this.Text = "历史任务单查询";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gb_WorkM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkM)).EndInit();
            this.gb_WorkP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkP)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gb_WorkM;
        private System.Windows.Forms.GroupBox gb_WorkP;
        private System.Windows.Forms.DataGridView dgv_WorkP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox check_All;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.DataGridView dgv_WorkM;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_WorkID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PalletCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Finished;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStation;
        private System.Windows.Forms.ToolStripButton btn_OutportMain;
        private System.Windows.Forms.ToolStripButton btn_OutportDtl;
    }
}