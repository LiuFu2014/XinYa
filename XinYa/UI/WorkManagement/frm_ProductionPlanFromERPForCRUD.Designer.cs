namespace XinYa.UI.WorkManagement
{
    partial class frm_ProductionPlanFromERPForCRUD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.gb_Ser = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_SaveChange = new System.Windows.Forms.Button();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.gb_SerShow = new System.Windows.Forms.GroupBox();
            this.split_ResultShow = new System.Windows.Forms.SplitContainer();
            this.dgv_SerShow = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ResultShow = new System.Windows.Forms.TextBox();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_MatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ImportUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.gb_Ser.SuspendLayout();
            this.gb_SerShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_ResultShow)).BeginInit();
            this.split_ResultShow.Panel1.SuspendLayout();
            this.split_ResultShow.Panel2.SuspendLayout();
            this.split_ResultShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SerShow)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.split_Main.Panel1.Controls.Add(this.gb_Ser);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.gb_SerShow);
            this.split_Main.Size = new System.Drawing.Size(825, 488);
            this.split_Main.SplitterDistance = 89;
            this.split_Main.TabIndex = 15;
            // 
            // gb_Ser
            // 
            this.gb_Ser.Controls.Add(this.btn_Delete);
            this.gb_Ser.Controls.Add(this.btn_SaveChange);
            this.gb_Ser.Controls.Add(this.btn_Ser);
            this.gb_Ser.Controls.Add(this.label1);
            this.gb_Ser.Controls.Add(this.label5);
            this.gb_Ser.Controls.Add(this.label4);
            this.gb_Ser.Controls.Add(this.dtp_EndTime);
            this.gb_Ser.Controls.Add(this.dtp_BeginTime);
            this.gb_Ser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Ser.Location = new System.Drawing.Point(0, 0);
            this.gb_Ser.Name = "gb_Ser";
            this.gb_Ser.Size = new System.Drawing.Size(825, 89);
            this.gb_Ser.TabIndex = 0;
            this.gb_Ser.TabStop = false;
            this.gb_Ser.Text = "筛选条件";
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(642, 51);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 22;
            this.btn_Delete.Text = "删除选定项";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_SaveChange
            // 
            this.btn_SaveChange.Location = new System.Drawing.Point(560, 51);
            this.btn_SaveChange.Name = "btn_SaveChange";
            this.btn_SaveChange.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveChange.TabIndex = 21;
            this.btn_SaveChange.Text = "保存更改";
            this.btn_SaveChange.UseVisualStyleBackColor = true;
            this.btn_SaveChange.Click += new System.EventHandler(this.btn_SaveChange_Click);
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(478, 51);
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
            this.gb_SerShow.Controls.Add(this.split_ResultShow);
            this.gb_SerShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_SerShow.Location = new System.Drawing.Point(0, 0);
            this.gb_SerShow.Name = "gb_SerShow";
            this.gb_SerShow.Size = new System.Drawing.Size(825, 395);
            this.gb_SerShow.TabIndex = 0;
            this.gb_SerShow.TabStop = false;
            this.gb_SerShow.Text = "查询结果";
            // 
            // split_ResultShow
            // 
            this.split_ResultShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_ResultShow.Location = new System.Drawing.Point(3, 17);
            this.split_ResultShow.Name = "split_ResultShow";
            this.split_ResultShow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_ResultShow.Panel1
            // 
            this.split_ResultShow.Panel1.Controls.Add(this.dgv_SerShow);
            // 
            // split_ResultShow.Panel2
            // 
            this.split_ResultShow.Panel2.Controls.Add(this.groupBox1);
            this.split_ResultShow.Size = new System.Drawing.Size(819, 375);
            this.split_ResultShow.SplitterDistance = 246;
            this.split_ResultShow.TabIndex = 1;
            // 
            // dgv_SerShow
            // 
            this.dgv_SerShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SerShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_Select,
            this.c_MatType,
            this.c_PlanAmount,
            this.c_PlanBeginTime,
            this.c_PlanEndTime,
            this.c_PlanDepartment,
            this.c_ImportUser,
            this.c_ImportDate});
            this.dgv_SerShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SerShow.Location = new System.Drawing.Point(0, 0);
            this.dgv_SerShow.Name = "dgv_SerShow";
            this.dgv_SerShow.RowTemplate.Height = 23;
            this.dgv_SerShow.Size = new System.Drawing.Size(819, 246);
            this.dgv_SerShow.TabIndex = 0;
            this.dgv_SerShow.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_SerShow_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ResultShow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台输出：";
            // 
            // txt_ResultShow
            // 
            this.txt_ResultShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ResultShow.Location = new System.Drawing.Point(3, 17);
            this.txt_ResultShow.Multiline = true;
            this.txt_ResultShow.Name = "txt_ResultShow";
            this.txt_ResultShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ResultShow.Size = new System.Drawing.Size(813, 105);
            this.txt_ResultShow.TabIndex = 0;
            this.txt_ResultShow.Text = "查询结果输出：";
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_Select
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.NullValue = false;
            this.c_Select.DefaultCellStyle = dataGridViewCellStyle1;
            this.c_Select.FalseValue = "False";
            this.c_Select.HeaderText = "删除选定";
            this.c_Select.IndeterminateValue = "False";
            this.c_Select.Name = "c_Select";
            this.c_Select.TrueValue = "True";
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.c_PlanAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_PlanAmount.HeaderText = "计划数量";
            this.c_PlanAmount.Name = "c_PlanAmount";
            // 
            // c_PlanBeginTime
            // 
            this.c_PlanBeginTime.DataPropertyName = "PlanBeginTime";
            this.c_PlanBeginTime.HeaderText = "计划开始时间";
            this.c_PlanBeginTime.Name = "c_PlanBeginTime";
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
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.c_PlanDepartment.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_PlanDepartment.HeaderText = "制订部门";
            this.c_PlanDepartment.Name = "c_PlanDepartment";
            this.c_PlanDepartment.ReadOnly = true;
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
            // frm_ProductionPlanFromERPForCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.split_Main);
            this.Name = "frm_ProductionPlanFromERPForCRUD";
            this.Text = "计划修改";
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.gb_Ser.ResumeLayout(false);
            this.gb_Ser.PerformLayout();
            this.gb_SerShow.ResumeLayout(false);
            this.split_ResultShow.Panel1.ResumeLayout(false);
            this.split_ResultShow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_ResultShow)).EndInit();
            this.split_ResultShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SerShow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.GroupBox gb_Ser;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.GroupBox gb_SerShow;
        private System.Windows.Forms.DataGridView dgv_SerShow;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_SaveChange;
        private System.Windows.Forms.SplitContainer split_ResultShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_ResultShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ImportUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ImportDate;
    }
}