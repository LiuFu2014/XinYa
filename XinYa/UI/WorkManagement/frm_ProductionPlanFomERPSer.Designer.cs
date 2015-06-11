namespace XinYa.UI.WorkManagement
{
    partial class frm_ProductionPlanFomERPSer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProductionPlanFomERPSer));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.gb_Ser = new System.Windows.Forms.GroupBox();
            this.btn_Outport = new System.Windows.Forms.Button();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.gb_SerShow = new System.Windows.Forms.GroupBox();
            this.dgv_SerShow = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CompleteAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CompleteStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ImportUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.gb_Ser.SuspendLayout();
            this.gb_SerShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SerShow)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(797, 25);
            this.tool_Main.TabIndex = 13;
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
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 25);
            this.split_Main.Name = "split_Main";
            this.split_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.gb_Ser);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.gb_SerShow);
            this.split_Main.Size = new System.Drawing.Size(797, 560);
            this.split_Main.SplitterDistance = 103;
            this.split_Main.TabIndex = 14;
            // 
            // gb_Ser
            // 
            this.gb_Ser.Controls.Add(this.btn_Outport);
            this.gb_Ser.Controls.Add(this.btn_Ser);
            this.gb_Ser.Controls.Add(this.label1);
            this.gb_Ser.Controls.Add(this.label5);
            this.gb_Ser.Controls.Add(this.label4);
            this.gb_Ser.Controls.Add(this.dtp_EndTime);
            this.gb_Ser.Controls.Add(this.dtp_BeginTime);
            this.gb_Ser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Ser.Location = new System.Drawing.Point(0, 0);
            this.gb_Ser.Name = "gb_Ser";
            this.gb_Ser.Size = new System.Drawing.Size(797, 103);
            this.gb_Ser.TabIndex = 0;
            this.gb_Ser.TabStop = false;
            this.gb_Ser.Text = "筛选条件";
            // 
            // btn_Outport
            // 
            this.btn_Outport.Location = new System.Drawing.Point(607, 60);
            this.btn_Outport.Name = "btn_Outport";
            this.btn_Outport.Size = new System.Drawing.Size(75, 23);
            this.btn_Outport.TabIndex = 21;
            this.btn_Outport.Text = "导出";
            this.btn_Outport.UseVisualStyleBackColor = true;
            this.btn_Outport.Click += new System.EventHandler(this.btn_Outport_Click);
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(525, 61);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 20;
            this.btn_Ser.Text = "查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "录入时间段:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "结束时间:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "开始时间:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndTime.Location = new System.Drawing.Point(517, 24);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 21);
            this.dtp_EndTime.TabIndex = 16;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_BeginTime.Location = new System.Drawing.Point(224, 27);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(200, 21);
            this.dtp_BeginTime.TabIndex = 15;
            // 
            // gb_SerShow
            // 
            this.gb_SerShow.Controls.Add(this.dgv_SerShow);
            this.gb_SerShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_SerShow.Location = new System.Drawing.Point(0, 0);
            this.gb_SerShow.Name = "gb_SerShow";
            this.gb_SerShow.Size = new System.Drawing.Size(797, 453);
            this.gb_SerShow.TabIndex = 0;
            this.gb_SerShow.TabStop = false;
            this.gb_SerShow.Text = "查询结果";
            // 
            // dgv_SerShow
            // 
            this.dgv_SerShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SerShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_MatType,
            this.c_PlanAmount,
            this.c_PlanBeginTime,
            this.c_PlanEndTime,
            this.c_PlanDepartment,
            this.c_CompleteAmount,
            this.c_CompleteStatus,
            this.c_ImportUser,
            this.c_ImportDate});
            this.dgv_SerShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SerShow.Location = new System.Drawing.Point(3, 17);
            this.dgv_SerShow.Name = "dgv_SerShow";
            this.dgv_SerShow.RowTemplate.Height = 23;
            this.dgv_SerShow.Size = new System.Drawing.Size(791, 433);
            this.dgv_SerShow.TabIndex = 0;
            this.dgv_SerShow.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_SerShow_CellFormatting);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_MatType
            // 
            this.c_MatType.DataPropertyName = "TB_MaterialInfo.TypeCode";
            this.c_MatType.HeaderText = "物料编码";
            this.c_MatType.Name = "c_MatType";
            this.c_MatType.ReadOnly = true;
            // 
            // c_PlanAmount
            // 
            this.c_PlanAmount.DataPropertyName = "PlanAmount";
            this.c_PlanAmount.HeaderText = "计划数量";
            this.c_PlanAmount.Name = "c_PlanAmount";
            this.c_PlanAmount.ReadOnly = true;
            // 
            // c_PlanBeginTime
            // 
            this.c_PlanBeginTime.DataPropertyName = "PlanBeginTime";
            this.c_PlanBeginTime.HeaderText = "计划开始时间";
            this.c_PlanBeginTime.Name = "c_PlanBeginTime";
            this.c_PlanBeginTime.ReadOnly = true;
            // 
            // c_PlanEndTime
            // 
            this.c_PlanEndTime.DataPropertyName = "PlanEndTime";
            this.c_PlanEndTime.HeaderText = "计划结束时间";
            this.c_PlanEndTime.Name = "c_PlanEndTime";
            this.c_PlanEndTime.ReadOnly = true;
            // 
            // c_PlanDepartment
            // 
            this.c_PlanDepartment.DataPropertyName = "PlanDepartment";
            this.c_PlanDepartment.HeaderText = "制订部门";
            this.c_PlanDepartment.Name = "c_PlanDepartment";
            this.c_PlanDepartment.ReadOnly = true;
            // 
            // c_CompleteAmount
            // 
            this.c_CompleteAmount.DataPropertyName = "CompleteAmount";
            this.c_CompleteAmount.HeaderText = "完成数量";
            this.c_CompleteAmount.Name = "c_CompleteAmount";
            this.c_CompleteAmount.ReadOnly = true;
            // 
            // c_CompleteStatus
            // 
            this.c_CompleteStatus.DataPropertyName = "CompleteStatus";
            this.c_CompleteStatus.HeaderText = "完成状态";
            this.c_CompleteStatus.Name = "c_CompleteStatus";
            this.c_CompleteStatus.ReadOnly = true;
            // 
            // c_ImportUser
            // 
            this.c_ImportUser.DataPropertyName = "TB_User.UserName";
            this.c_ImportUser.HeaderText = "计划导入者";
            this.c_ImportUser.Name = "c_ImportUser";
            this.c_ImportUser.ReadOnly = true;
            // 
            // c_ImportDate
            // 
            this.c_ImportDate.DataPropertyName = "ImportDate";
            this.c_ImportDate.HeaderText = "计划导入时间";
            this.c_ImportDate.Name = "c_ImportDate";
            this.c_ImportDate.ReadOnly = true;
            // 
            // frm_ProductionPlanFomERPSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 585);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_ProductionPlanFomERPSer";
            this.Text = "ERP导入数据查询";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.gb_Ser.ResumeLayout(false);
            this.gb_Ser.PerformLayout();
            this.gb_SerShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SerShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.GroupBox gb_Ser;
        private System.Windows.Forms.GroupBox gb_SerShow;
        private System.Windows.Forms.DataGridView dgv_SerShow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Outport;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CompleteAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CompleteStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ImportUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ImportDate;
    }
}