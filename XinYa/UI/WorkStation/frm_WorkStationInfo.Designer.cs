namespace XinYa.UI.WorkStation
{
    partial class frm_WorkStationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WorkStationInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Confirm = new System.Windows.Forms.ToolStripButton();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Outport = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MainCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_IsUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
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
            this.btn_Refresh,
            this.toolStripSeparator2,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(776, 25);
            this.tool_Main.TabIndex = 13;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(60, 22);
            this.btn_Confirm.Text = "确定保存";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
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
            // btn_Refresh
            // 
            this.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(60, 22);
            this.btn_Refresh.Text = "数据刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
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
            this.status_Main.Location = new System.Drawing.Point(0, 450);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(776, 22);
            this.status_Main.TabIndex = 14;
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
            // p_Main
            // 
            this.p_Main.Controls.Add(this.dgv_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(776, 425);
            this.p_Main.TabIndex = 15;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_SecondWorkStationName,
            this.c_No,
            this.c_Code,
            this.c_MainCode,
            this.c_IsUse,
            this.c_Remark});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.Size = new System.Drawing.Size(776, 425);
            this.dgv_Main.TabIndex = 0;
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            // 
            // c_SecondWorkStationName
            // 
            this.c_SecondWorkStationName.DataPropertyName = "SecondWorkStationName";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.c_SecondWorkStationName.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_SecondWorkStationName.HeaderText = "工位名";
            this.c_SecondWorkStationName.Name = "c_SecondWorkStationName";
            // 
            // c_No
            // 
            this.c_No.DataPropertyName = "No";
            this.c_No.HeaderText = "序号";
            this.c_No.Name = "c_No";
            this.c_No.ReadOnly = true;
            // 
            // c_Code
            // 
            this.c_Code.DataPropertyName = "SecondWorkStationCode";
            this.c_Code.HeaderText = "工位编码";
            this.c_Code.Name = "c_Code";
            this.c_Code.ReadOnly = true;
            // 
            // c_MainCode
            // 
            this.c_MainCode.DataPropertyName = "WorkStationCode";
            this.c_MainCode.HeaderText = "工序编码";
            this.c_MainCode.Name = "c_MainCode";
            this.c_MainCode.ReadOnly = true;
            // 
            // c_IsUse
            // 
            this.c_IsUse.DataPropertyName = "IsUse";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.NullValue = false;
            this.c_IsUse.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_IsUse.FalseValue = "false";
            this.c_IsUse.HeaderText = "是否启用";
            this.c_IsUse.Name = "c_IsUse";
            this.c_IsUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_IsUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_IsUse.TrueValue = "true";
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.c_Remark.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            // 
            // frm_WorkStationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 472);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_WorkStationInfo";
            this.Text = "工位信息管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Outport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MainCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
    }
}