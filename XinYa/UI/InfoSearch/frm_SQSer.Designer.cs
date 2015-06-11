namespace XinYa.UI.InfoSearch
{
    partial class frm_SQSer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SQSer));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OutportData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lab_Total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SerScrap = new System.Windows.Forms.Button();
            this.btn_SerAll = new System.Windows.Forms.Button();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ResultShow = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_IsScrap = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_ExceptionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultShow)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_OutportData,
            this.toolStripSeparator2,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(842, 25);
            this.tool_Main.TabIndex = 12;
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_OutportData
            // 
            this.btn_OutportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_OutportData.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutportData.Image")));
            this.btn_OutportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OutportData.Name = "btn_OutportData";
            this.btn_OutportData.Size = new System.Drawing.Size(60, 22);
            this.btn_OutportData.Text = "数据导出";
            this.btn_OutportData.Click += new System.EventHandler(this.btn_OutportData_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(842, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lab_Total);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SerScrap);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SerAll);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_BeginTime);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_ResultShow);
            this.splitContainer1.Size = new System.Drawing.Size(842, 408);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 14;
            // 
            // lab_Total
            // 
            this.lab_Total.AutoSize = true;
            this.lab_Total.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Total.Location = new System.Drawing.Point(132, 71);
            this.lab_Total.Name = "lab_Total";
            this.lab_Total.Size = new System.Drawing.Size(19, 19);
            this.lab_Total.TabIndex = 20;
            this.lab_Total.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "记录总数：";
            // 
            // btn_SerScrap
            // 
            this.btn_SerScrap.Location = new System.Drawing.Point(652, 51);
            this.btn_SerScrap.Name = "btn_SerScrap";
            this.btn_SerScrap.Size = new System.Drawing.Size(75, 23);
            this.btn_SerScrap.TabIndex = 18;
            this.btn_SerScrap.Text = "查询报废品";
            this.btn_SerScrap.UseVisualStyleBackColor = true;
            this.btn_SerScrap.Click += new System.EventHandler(this.btn_SerScrap_Click);
            // 
            // btn_SerAll
            // 
            this.btn_SerAll.Location = new System.Drawing.Point(652, 22);
            this.btn_SerAll.Name = "btn_SerAll";
            this.btn_SerAll.Size = new System.Drawing.Size(75, 23);
            this.btn_SerAll.TabIndex = 17;
            this.btn_SerAll.Text = "查询全部";
            this.btn_SerAll.UseVisualStyleBackColor = true;
            this.btn_SerAll.Click += new System.EventHandler(this.btn_SerAll_Click);
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndTime.Location = new System.Drawing.Point(428, 22);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_EndTime.TabIndex = 16;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_BeginTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_BeginTime.Location = new System.Drawing.Point(126, 22);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(199, 29);
            this.dtp_BeginTime.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(332, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "开始时间：";
            // 
            // dgv_ResultShow
            // 
            this.dgv_ResultShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ResultShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_MatCode,
            this.c_WorkerName,
            this.c_BeginTime,
            this.c_EndTime,
            this.c_IsScrap,
            this.c_ExceptionCode,
            this.c_ExceptionText,
            this.c_Remark});
            this.dgv_ResultShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ResultShow.Location = new System.Drawing.Point(0, 0);
            this.dgv_ResultShow.Name = "dgv_ResultShow";
            this.dgv_ResultShow.RowTemplate.Height = 23;
            this.dgv_ResultShow.Size = new System.Drawing.Size(842, 305);
            this.dgv_ResultShow.TabIndex = 0;
            this.dgv_ResultShow.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_ResultShow_CellFormatting);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_MatCode
            // 
            this.c_MatCode.DataPropertyName = "TB_WorkDtl.MaterialCode";
            this.c_MatCode.HeaderText = "泵体条码";
            this.c_MatCode.Name = "c_MatCode";
            this.c_MatCode.ReadOnly = true;
            // 
            // c_WorkerName
            // 
            this.c_WorkerName.DataPropertyName = "TB_User.UserName";
            this.c_WorkerName.HeaderText = "操作员工";
            this.c_WorkerName.Name = "c_WorkerName";
            this.c_WorkerName.ReadOnly = true;
            // 
            // c_BeginTime
            // 
            this.c_BeginTime.DataPropertyName = "BeginTime";
            this.c_BeginTime.HeaderText = "开始时间";
            this.c_BeginTime.Name = "c_BeginTime";
            this.c_BeginTime.ReadOnly = true;
            // 
            // c_EndTime
            // 
            this.c_EndTime.DataPropertyName = "EndTime";
            this.c_EndTime.HeaderText = "结束时间";
            this.c_EndTime.Name = "c_EndTime";
            this.c_EndTime.ReadOnly = true;
            // 
            // c_IsScrap
            // 
            this.c_IsScrap.DataPropertyName = "IsScrap";
            this.c_IsScrap.FalseValue = "False";
            this.c_IsScrap.HeaderText = "是否报废";
            this.c_IsScrap.Name = "c_IsScrap";
            this.c_IsScrap.ReadOnly = true;
            this.c_IsScrap.TrueValue = "True";
            // 
            // c_ExceptionCode
            // 
            this.c_ExceptionCode.DataPropertyName = "TB_Exception.ExceptionCode";
            this.c_ExceptionCode.HeaderText = "故障代码";
            this.c_ExceptionCode.Name = "c_ExceptionCode";
            this.c_ExceptionCode.ReadOnly = true;
            // 
            // c_ExceptionText
            // 
            this.c_ExceptionText.DataPropertyName = "TB_Exception.ExceptionText";
            this.c_ExceptionText.HeaderText = "故障描述";
            this.c_ExceptionText.Name = "c_ExceptionText";
            this.c_ExceptionText.ReadOnly = true;
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            this.c_Remark.ReadOnly = true;
            // 
            // frm_SQSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 455);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_SQSer";
            this.Text = "返修区工作情况统计";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ResultShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_OutportData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_SerScrap;
        private System.Windows.Forms.Button btn_SerAll;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ResultShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_EndTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionText;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_Total;
    }
}