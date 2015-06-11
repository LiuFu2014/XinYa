namespace XinYa.UI.InfoSearch
{
    partial class frm_WorkTimeStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WorkTimeStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Confirm = new System.Windows.Forms.ToolStripButton();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Outport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Satistics = new System.Windows.Forms.Button();
            this.txt_Select = new System.Windows.Forms.TextBox();
            this.check_IsSelectWorker = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_workNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_workName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_workTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_beginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Confirm,
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_Outport,
            this.toolStripSeparator2,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(904, 25);
            this.tool_Main.TabIndex = 12;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(36, 22);
            this.btn_Confirm.Text = "确定";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Outport
            // 
            this.btn_Outport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Outport.Image = ((System.Drawing.Image)(resources.GetObject("btn_Outport.Image")));
            this.btn_Outport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Outport.Name = "btn_Outport";
            this.btn_Outport.Size = new System.Drawing.Size(60, 22);
            this.btn_Outport.Text = "数据导出";
            this.btn_Outport.Click += new System.EventHandler(this.btn_Outport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // status_Main
            // 
            this.status_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.status_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.status_Main.Location = new System.Drawing.Point(0, 480);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(904, 22);
            this.status_Main.TabIndex = 13;
            this.status_Main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态：";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel2.Text = "就绪";
            // 
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 25);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.groupBox2);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.groupBox1);
            this.split_Main.Size = new System.Drawing.Size(904, 455);
            this.split_Main.SplitterDistance = 337;
            this.split_Main.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Select);
            this.groupBox2.Controls.Add(this.btn_Satistics);
            this.groupBox2.Controls.Add(this.txt_Select);
            this.groupBox2.Controls.Add(this.check_IsSelectWorker);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_EndTime);
            this.groupBox2.Controls.Add(this.dtp_BeginTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 455);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选条件";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(234, 352);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 12;
            this.btn_Select.Text = "选择";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Satistics
            // 
            this.btn_Satistics.Location = new System.Drawing.Point(234, 381);
            this.btn_Satistics.Name = "btn_Satistics";
            this.btn_Satistics.Size = new System.Drawing.Size(75, 23);
            this.btn_Satistics.TabIndex = 11;
            this.btn_Satistics.Text = "统计";
            this.btn_Satistics.UseVisualStyleBackColor = true;
            this.btn_Satistics.Click += new System.EventHandler(this.btn_Satistics_Click);
            // 
            // txt_Select
            // 
            this.txt_Select.Location = new System.Drawing.Point(30, 211);
            this.txt_Select.Multiline = true;
            this.txt_Select.Name = "txt_Select";
            this.txt_Select.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Select.Size = new System.Drawing.Size(279, 135);
            this.txt_Select.TabIndex = 10;
            this.txt_Select.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Select_KeyPress);
            // 
            // check_IsSelectWorker
            // 
            this.check_IsSelectWorker.AutoSize = true;
            this.check_IsSelectWorker.Location = new System.Drawing.Point(30, 186);
            this.check_IsSelectWorker.Name = "check_IsSelectWorker";
            this.check_IsSelectWorker.Size = new System.Drawing.Size(96, 16);
            this.check_IsSelectWorker.TabIndex = 9;
            this.check_IsSelectWorker.Text = "是否指定员工";
            this.check_IsSelectWorker.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "结束时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "开始时间:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndTime.Location = new System.Drawing.Point(110, 113);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_EndTime.TabIndex = 6;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_BeginTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_BeginTime.Location = new System.Drawing.Point(110, 56);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(199, 29);
            this.dtp_BeginTime.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Main);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 455);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细信息";
            // 
            // dgv_Main
            // 
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_workNumber,
            this.c_workName,
            this.c_workTime,
            this.c_beginTime,
            this.c_endTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(3, 17);
            this.dgv_Main.Name = "dgv_Main";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.Size = new System.Drawing.Size(557, 435);
            this.dgv_Main.TabIndex = 0;
            // 
            // c_workNumber
            // 
            this.c_workNumber.DataPropertyName = "workNumber";
            this.c_workNumber.HeaderText = "工号";
            this.c_workNumber.Name = "c_workNumber";
            this.c_workNumber.ReadOnly = true;
            // 
            // c_workName
            // 
            this.c_workName.DataPropertyName = "workName";
            this.c_workName.HeaderText = "姓名";
            this.c_workName.Name = "c_workName";
            this.c_workName.ReadOnly = true;
            // 
            // c_workTime
            // 
            this.c_workTime.DataPropertyName = "workTime";
            this.c_workTime.HeaderText = "工时统计";
            this.c_workTime.Name = "c_workTime";
            this.c_workTime.ReadOnly = true;
            // 
            // c_beginTime
            // 
            this.c_beginTime.DataPropertyName = "beginTime";
            this.c_beginTime.HeaderText = "起始时间";
            this.c_beginTime.Name = "c_beginTime";
            this.c_beginTime.ReadOnly = true;
            // 
            // c_endTime
            // 
            this.c_endTime.DataPropertyName = "endTime";
            this.c_endTime.HeaderText = "结束时间";
            this.c_endTime.Name = "c_endTime";
            this.c_endTime.ReadOnly = true;
            // 
            // frm_WorkTimeStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 502);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_WorkTimeStatistics";
            this.Text = "工时信息统计";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.ToolStripButton btn_Outport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.CheckBox check_IsSelectWorker;
        private System.Windows.Forms.Button btn_Satistics;
        private System.Windows.Forms.Button btn_Select;
        public System.Windows.Forms.TextBox txt_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_workNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_workName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_workTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_beginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_endTime;
    }
}