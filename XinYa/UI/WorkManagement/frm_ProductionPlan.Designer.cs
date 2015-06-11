namespace XinYa.UI.WorkManagement
{
    partial class frm_ProductionPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProductionPlan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OutportData = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.check_IsToday = new System.Windows.Forms.CheckBox();
            this.check_IsAll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.db_Add = new System.Windows.Forms.GroupBox();
            this.btn_ClearResult = new System.Windows.Forms.Button();
            this.txt_PlanResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_SelectMat = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_MatSelect = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_LineNum = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.num_Amount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_PlanDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_SaveDgv = new System.Windows.Forms.Button();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Dinghuobianhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Zhuangpeixianhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Planer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PlanTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.db_Add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Amount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_OutportData,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(1015, 25);
            this.tool_Main.TabIndex = 13;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 22);
            this.btn_Cancel.Text = "取消退出";
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
            this.status_Main.Location = new System.Drawing.Point(0, 617);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(1015, 22);
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
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 25);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.groupBox1);
            this.split_Main.Panel1.Controls.Add(this.db_Add);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.groupBox2);
            this.split_Main.Size = new System.Drawing.Size(1015, 592);
            this.split_Main.SplitterDistance = 356;
            this.split_Main.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.btn_Ser);
            this.groupBox1.Controls.Add(this.check_IsToday);
            this.groupBox1.Controls.Add(this.check_IsAll);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtp_EndTime);
            this.groupBox1.Controls.Add(this.dtp_BeginTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 435);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(217, 110);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 6;
            this.btn_Ser.Text = "查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // check_IsToday
            // 
            this.check_IsToday.AutoSize = true;
            this.check_IsToday.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_IsToday.Location = new System.Drawing.Point(92, 113);
            this.check_IsToday.Name = "check_IsToday";
            this.check_IsToday.Size = new System.Drawing.Size(91, 20);
            this.check_IsToday.TabIndex = 5;
            this.check_IsToday.Text = "加载今日";
            this.check_IsToday.UseVisualStyleBackColor = true;
            // 
            // check_IsAll
            // 
            this.check_IsAll.AutoSize = true;
            this.check_IsAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_IsAll.Location = new System.Drawing.Point(92, 90);
            this.check_IsAll.Name = "check_IsAll";
            this.check_IsAll.Size = new System.Drawing.Size(91, 20);
            this.check_IsAll.TabIndex = 4;
            this.check_IsAll.Text = "加载全部";
            this.check_IsAll.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "结束日期:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "开始日期:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Location = new System.Drawing.Point(92, 47);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 26);
            this.dtp_EndTime.TabIndex = 1;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime.Location = new System.Drawing.Point(92, 14);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(200, 26);
            this.dtp_BeginTime.TabIndex = 0;
            // 
            // db_Add
            // 
            this.db_Add.BackColor = System.Drawing.Color.DarkGray;
            this.db_Add.Controls.Add(this.btn_ClearResult);
            this.db_Add.Controls.Add(this.txt_PlanResult);
            this.db_Add.Controls.Add(this.label7);
            this.db_Add.Controls.Add(this.btn_SelectMat);
            this.db_Add.Controls.Add(this.btn_Save);
            this.db_Add.Controls.Add(this.txt_MatSelect);
            this.db_Add.Controls.Add(this.label4);
            this.db_Add.Controls.Add(this.cb_LineNum);
            this.db_Add.Controls.Add(this.label3);
            this.db_Add.Controls.Add(this.num_Amount);
            this.db_Add.Controls.Add(this.label2);
            this.db_Add.Controls.Add(this.label1);
            this.db_Add.Controls.Add(this.dtp_PlanDate);
            this.db_Add.Location = new System.Drawing.Point(12, 14);
            this.db_Add.Name = "db_Add";
            this.db_Add.Size = new System.Drawing.Size(332, 415);
            this.db_Add.TabIndex = 0;
            this.db_Add.TabStop = false;
            this.db_Add.Text = "新增生产计划";
            // 
            // btn_ClearResult
            // 
            this.btn_ClearResult.Location = new System.Drawing.Point(233, 283);
            this.btn_ClearResult.Name = "btn_ClearResult";
            this.btn_ClearResult.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearResult.TabIndex = 12;
            this.btn_ClearResult.Text = "清空输出";
            this.btn_ClearResult.UseVisualStyleBackColor = true;
            this.btn_ClearResult.Click += new System.EventHandler(this.btn_ClearResult_Click);
            // 
            // txt_PlanResult
            // 
            this.txt_PlanResult.Location = new System.Drawing.Point(27, 313);
            this.txt_PlanResult.Multiline = true;
            this.txt_PlanResult.Name = "txt_PlanResult";
            this.txt_PlanResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_PlanResult.Size = new System.Drawing.Size(280, 91);
            this.txt_PlanResult.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(25, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "结果输出：";
            // 
            // btn_SelectMat
            // 
            this.btn_SelectMat.Location = new System.Drawing.Point(152, 253);
            this.btn_SelectMat.Name = "btn_SelectMat";
            this.btn_SelectMat.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectMat.TabIndex = 9;
            this.btn_SelectMat.Text = "选择...";
            this.btn_SelectMat.UseVisualStyleBackColor = true;
            this.btn_SelectMat.Click += new System.EventHandler(this.btn_SelectMat_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(233, 253);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "确认保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_MatSelect
            // 
            this.txt_MatSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MatSelect.Location = new System.Drawing.Point(107, 149);
            this.txt_MatSelect.Multiline = true;
            this.txt_MatSelect.Name = "txt_MatSelect";
            this.txt_MatSelect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_MatSelect.Size = new System.Drawing.Size(200, 98);
            this.txt_MatSelect.TabIndex = 7;
            this.txt_MatSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatSelect_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "泵型号编码:";
            // 
            // cb_LineNum
            // 
            this.cb_LineNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LineNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_LineNum.FormattingEnabled = true;
            this.cb_LineNum.Items.AddRange(new object[] {
            "1号装配线",
            "2号装配线",
            "3号装配线"});
            this.cb_LineNum.Location = new System.Drawing.Point(107, 109);
            this.cb_LineNum.Name = "cb_LineNum";
            this.cb_LineNum.Size = new System.Drawing.Size(200, 24);
            this.cb_LineNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "装配线号:";
            // 
            // num_Amount
            // 
            this.num_Amount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Amount.Location = new System.Drawing.Point(107, 71);
            this.num_Amount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Amount.Name = "num_Amount";
            this.num_Amount.Size = new System.Drawing.Size(200, 26);
            this.num_Amount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "计划投入数:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "计划日期:";
            // 
            // dtp_PlanDate
            // 
            this.dtp_PlanDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_PlanDate.Location = new System.Drawing.Point(107, 31);
            this.dtp_PlanDate.Name = "dtp_PlanDate";
            this.dtp_PlanDate.Size = new System.Drawing.Size(200, 26);
            this.dtp_PlanDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            this.groupBox2.Controls.Add(this.btn_Delete);
            this.groupBox2.Controls.Add(this.btn_SaveDgv);
            this.groupBox2.Controls.Add(this.dgv_Main);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(655, 592);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果显示";
            // 
            // btn_Delete
            // 
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Delete.Location = new System.Drawing.Point(476, 553);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "删除选定项";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_SaveDgv
            // 
            this.btn_SaveDgv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_SaveDgv.Location = new System.Drawing.Point(557, 553);
            this.btn_SaveDgv.Name = "btn_SaveDgv";
            this.btn_SaveDgv.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveDgv.TabIndex = 1;
            this.btn_SaveDgv.Text = "保存更改";
            this.btn_SaveDgv.UseVisualStyleBackColor = true;
            this.btn_SaveDgv.Click += new System.EventHandler(this.btn_SaveDgv_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Select,
            this.c_ID,
            this.c_MaterialCode,
            this.c_Amount,
            this.c_Dinghuobianhao,
            this.c_Zhuangpeixianhao,
            this.c_Date,
            this.c_Planer,
            this.c_PlanTime});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Main.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Main.Location = new System.Drawing.Point(6, 14);
            this.dgv_Main.Name = "dgv_Main";
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgv_Main.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.Size = new System.Drawing.Size(643, 533);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            // 
            // c_Select
            // 
            this.c_Select.FalseValue = "false";
            this.c_Select.HeaderText = "选定";
            this.c_Select.IndeterminateValue = "false";
            this.c_Select.Name = "c_Select";
            this.c_Select.TrueValue = "true";
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "唯一序号";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            // 
            // c_MaterialCode
            // 
            this.c_MaterialCode.DataPropertyName = "TB_MaterialInfo.TypeCode";
            this.c_MaterialCode.HeaderText = "泵体型号编码";
            this.c_MaterialCode.Name = "c_MaterialCode";
            this.c_MaterialCode.ReadOnly = true;
            // 
            // c_Amount
            // 
            this.c_Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.c_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_Amount.HeaderText = "数量";
            this.c_Amount.Name = "c_Amount";
            // 
            // c_Dinghuobianhao
            // 
            this.c_Dinghuobianhao.DataPropertyName = "TB_MaterialInfo.Dinghuobianhao";
            this.c_Dinghuobianhao.HeaderText = "订货编号";
            this.c_Dinghuobianhao.Name = "c_Dinghuobianhao";
            this.c_Dinghuobianhao.ReadOnly = true;
            // 
            // c_Zhuangpeixianhao
            // 
            this.c_Zhuangpeixianhao.DataPropertyName = "LineNumber";
            this.c_Zhuangpeixianhao.HeaderText = "装配线号";
            this.c_Zhuangpeixianhao.Name = "c_Zhuangpeixianhao";
            this.c_Zhuangpeixianhao.ReadOnly = true;
            // 
            // c_Date
            // 
            this.c_Date.DataPropertyName = "Date";
            this.c_Date.HeaderText = "日期";
            this.c_Date.Name = "c_Date";
            this.c_Date.ReadOnly = true;
            // 
            // c_Planer
            // 
            this.c_Planer.DataPropertyName = "TB_User.UserName";
            this.c_Planer.HeaderText = "计划制定人";
            this.c_Planer.Name = "c_Planer";
            this.c_Planer.ReadOnly = true;
            // 
            // c_PlanTime
            // 
            this.c_PlanTime.DataPropertyName = "PlanTime";
            this.c_PlanTime.HeaderText = "计划制定时间";
            this.c_PlanTime.Name = "c_PlanTime";
            this.c_PlanTime.ReadOnly = true;
            // 
            // frm_ProductionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 639);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ProductionPlan";
            this.Text = "生产计划";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.db_Add.ResumeLayout(false);
            this.db_Add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Amount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox db_Add;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.CheckBox check_IsToday;
        private System.Windows.Forms.CheckBox check_IsAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_LineNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_PlanDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_SelectMat;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Button btn_SaveDgv;
        public System.Windows.Forms.TextBox txt_MatSelect;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ToolStripButton btn_OutportData;
        private System.Windows.Forms.TextBox txt_PlanResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_ClearResult;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Dinghuobianhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Zhuangpeixianhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Planer;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PlanTime;
    }
}