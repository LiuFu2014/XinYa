namespace XinYa.UI.BaseInfo
{
    partial class frm_KeyComponentsInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KeyComponentsInfo));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OutportData = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_AddNew = new System.Windows.Forms.ToolStripButton();
            this.btn_AddNewCancel = new System.Windows.Forms.ToolStripButton();
            this.btn_Edit = new System.Windows.Forms.ToolStripButton();
            this.btn_EditCancel = new System.Windows.Forms.ToolStripButton();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.lab_StatusBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_StatusTextBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_KeyComponentsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_AssistManufacturers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Recorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_RecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.split_Right = new System.Windows.Forms.SplitContainer();
            this.lab_RecordDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lab_Recorder = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_ID = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_AssiteName = new System.Windows.Forms.TextBox();
            this.txt_KeyComName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_KeyNameSer = new System.Windows.Forms.TextBox();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_Right)).BeginInit();
            this.split_Right.Panel1.SuspendLayout();
            this.split_Right.Panel2.SuspendLayout();
            this.split_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_OutportData,
            this.btn_Refresh,
            this.toolStripSeparator3,
            this.btn_AddNew,
            this.btn_AddNewCancel,
            this.btn_Edit,
            this.btn_EditCancel,
            this.btn_Delete,
            this.toolStripSeparator2,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(897, 25);
            this.tool_Main.TabIndex = 14;
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
            // btn_Refresh
            // 
            this.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(36, 22);
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_AddNew
            // 
            this.btn_AddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddNew.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNew.Image")));
            this.btn_AddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(36, 22);
            this.btn_AddNew.Text = "新增";
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
            // 
            // btn_AddNewCancel
            // 
            this.btn_AddNewCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddNewCancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddNewCancel.Image")));
            this.btn_AddNewCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddNewCancel.Name = "btn_AddNewCancel";
            this.btn_AddNewCancel.Size = new System.Drawing.Size(60, 22);
            this.btn_AddNewCancel.Text = "取消新增";
            this.btn_AddNewCancel.Visible = false;
            this.btn_AddNewCancel.Click += new System.EventHandler(this.btn_AddNewCancel_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(36, 22);
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_EditCancel
            // 
            this.btn_EditCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_EditCancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditCancel.Image")));
            this.btn_EditCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_EditCancel.Name = "btn_EditCancel";
            this.btn_EditCancel.Size = new System.Drawing.Size(60, 22);
            this.btn_EditCancel.Text = "取消编辑";
            this.btn_EditCancel.Visible = false;
            this.btn_EditCancel.Click += new System.EventHandler(this.btn_EditCancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(36, 22);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.lab_StatusBottom,
            this.lab_StatusTextBottom});
            this.status_Main.Location = new System.Drawing.Point(0, 465);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(897, 22);
            this.status_Main.TabIndex = 15;
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
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 25);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.dgv_Main);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.split_Right);
            this.split_Main.Size = new System.Drawing.Size(897, 440);
            this.split_Main.SplitterDistance = 412;
            this.split_Main.TabIndex = 16;
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_KeyComponentsName,
            this.c_AssistManufacturers,
            this.c_Remark,
            this.c_Recorder,
            this.c_RecordDate});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(412, 440);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_KeyComponentsName
            // 
            this.c_KeyComponentsName.DataPropertyName = "KeyComponentsName";
            this.c_KeyComponentsName.HeaderText = "主要部件名";
            this.c_KeyComponentsName.Name = "c_KeyComponentsName";
            this.c_KeyComponentsName.ReadOnly = true;
            // 
            // c_AssistManufacturers
            // 
            this.c_AssistManufacturers.DataPropertyName = "AssistManufacturers";
            this.c_AssistManufacturers.HeaderText = "外协厂家";
            this.c_AssistManufacturers.Name = "c_AssistManufacturers";
            this.c_AssistManufacturers.ReadOnly = true;
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            this.c_Remark.ReadOnly = true;
            // 
            // c_Recorder
            // 
            this.c_Recorder.DataPropertyName = "TB_User.UserName";
            this.c_Recorder.HeaderText = "录入者";
            this.c_Recorder.Name = "c_Recorder";
            this.c_Recorder.ReadOnly = true;
            // 
            // c_RecordDate
            // 
            this.c_RecordDate.DataPropertyName = "RecordDate";
            this.c_RecordDate.HeaderText = "录入时间";
            this.c_RecordDate.Name = "c_RecordDate";
            this.c_RecordDate.ReadOnly = true;
            // 
            // split_Right
            // 
            this.split_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Right.Location = new System.Drawing.Point(0, 0);
            this.split_Right.Name = "split_Right";
            this.split_Right.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_Right.Panel1
            // 
            this.split_Right.Panel1.Controls.Add(this.lab_RecordDate);
            this.split_Right.Panel1.Controls.Add(this.label7);
            this.split_Right.Panel1.Controls.Add(this.lab_Recorder);
            this.split_Right.Panel1.Controls.Add(this.label5);
            this.split_Right.Panel1.Controls.Add(this.lab_ID);
            this.split_Right.Panel1.Controls.Add(this.txt_Remark);
            this.split_Right.Panel1.Controls.Add(this.txt_AssiteName);
            this.split_Right.Panel1.Controls.Add(this.txt_KeyComName);
            this.split_Right.Panel1.Controls.Add(this.label3);
            this.split_Right.Panel1.Controls.Add(this.label2);
            this.split_Right.Panel1.Controls.Add(this.label1);
            this.split_Right.Panel1.Controls.Add(this.btn_Clear);
            this.split_Right.Panel1.Controls.Add(this.btn_Confirm);
            // 
            // split_Right.Panel2
            // 
            this.split_Right.Panel2.Controls.Add(this.btn_Ser);
            this.split_Right.Panel2.Controls.Add(this.label4);
            this.split_Right.Panel2.Controls.Add(this.txt_KeyNameSer);
            this.split_Right.Size = new System.Drawing.Size(481, 440);
            this.split_Right.SplitterDistance = 342;
            this.split_Right.TabIndex = 0;
            // 
            // lab_RecordDate
            // 
            this.lab_RecordDate.AutoSize = true;
            this.lab_RecordDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_RecordDate.Location = new System.Drawing.Point(167, 273);
            this.lab_RecordDate.Name = "lab_RecordDate";
            this.lab_RecordDate.Size = new System.Drawing.Size(74, 21);
            this.lab_RecordDate.TabIndex = 12;
            this.lab_RecordDate.Text = "录入时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(71, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "录入时间：";
            // 
            // lab_Recorder
            // 
            this.lab_Recorder.AutoSize = true;
            this.lab_Recorder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Recorder.Location = new System.Drawing.Point(167, 240);
            this.lab_Recorder.Name = "lab_Recorder";
            this.lab_Recorder.Size = new System.Drawing.Size(58, 21);
            this.lab_Recorder.TabIndex = 10;
            this.lab_Recorder.Text = "录入者";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(87, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "录入者：";
            // 
            // lab_ID
            // 
            this.lab_ID.AutoSize = true;
            this.lab_ID.Location = new System.Drawing.Point(5, 17);
            this.lab_ID.Name = "lab_ID";
            this.lab_ID.Size = new System.Drawing.Size(41, 12);
            this.lab_ID.TabIndex = 8;
            this.lab_ID.Text = "lab_ID";
            this.lab_ID.Visible = false;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Remark.Location = new System.Drawing.Point(147, 124);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Remark.Size = new System.Drawing.Size(304, 98);
            this.txt_Remark.TabIndex = 7;
            // 
            // txt_AssiteName
            // 
            this.txt_AssiteName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AssiteName.Location = new System.Drawing.Point(147, 73);
            this.txt_AssiteName.Name = "txt_AssiteName";
            this.txt_AssiteName.Size = new System.Drawing.Size(304, 29);
            this.txt_AssiteName.TabIndex = 6;
            // 
            // txt_KeyComName
            // 
            this.txt_KeyComName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_KeyComName.Location = new System.Drawing.Point(147, 38);
            this.txt_KeyComName.Name = "txt_KeyComName";
            this.txt_KeyComName.Size = new System.Drawing.Size(304, 29);
            this.txt_KeyComName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(83, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "备注：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(51, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "外协厂家：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "关键零部件名称：";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(371, 301);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 27);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(290, 301);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 27);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(365, 60);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 7;
            this.btn_Ser.Text = "模糊查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(21, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "按部件名查询:";
            // 
            // txt_KeyNameSer
            // 
            this.txt_KeyNameSer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_KeyNameSer.Location = new System.Drawing.Point(147, 25);
            this.txt_KeyNameSer.Name = "txt_KeyNameSer";
            this.txt_KeyNameSer.Size = new System.Drawing.Size(304, 29);
            this.txt_KeyNameSer.TabIndex = 6;
            // 
            // frm_KeyComponentsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 487);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_KeyComponentsInfo";
            this.Text = "frm_KeyComponentsInfo";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.split_Right.Panel1.ResumeLayout(false);
            this.split_Right.Panel1.PerformLayout();
            this.split_Right.Panel2.ResumeLayout(false);
            this.split_Right.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Right)).EndInit();
            this.split_Right.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_OutportData;
        private System.Windows.Forms.ToolStripButton btn_AddNew;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_StatusBottom;
        private System.Windows.Forms.ToolStripStatusLabel lab_StatusTextBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.SplitContainer split_Right;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.TextBox txt_AssiteName;
        private System.Windows.Forms.TextBox txt_KeyComName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_KeyNameSer;
        private System.Windows.Forms.ToolStripButton btn_AddNewCancel;
        private System.Windows.Forms.ToolStripButton btn_EditCancel;
        private System.Windows.Forms.Label lab_ID;
        private System.Windows.Forms.Label lab_RecordDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lab_Recorder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_KeyComponentsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_AssistManufacturers;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Recorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_RecordDate;
    }
}