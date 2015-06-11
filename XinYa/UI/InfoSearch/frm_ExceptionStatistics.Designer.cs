namespace XinYa.UI.InfoSearch
{
    partial class frm_ExceptionStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExceptionStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Outprot1 = new System.Windows.Forms.ToolStripButton();
            this.btn_Outport2 = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.tab_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.check_All = new System.Windows.Forms.CheckBox();
            this.check_Today = new System.Windows.Forms.CheckBox();
            this.txt_ExceptionSelect = new System.Windows.Forms.TextBox();
            this.check_SelectExceptionCode = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.dgv_ExceptionEachType = new System.Windows.Forms.DataGridView();
            this.c_ExceptionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.check_Today2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_EndTime2 = new System.Windows.Forms.DateTimePicker();
            this.dtp_BeginTime2 = new System.Windows.Forms.DateTimePicker();
            this.btn_Ser2 = new System.Windows.Forms.Button();
            this.dgv_ExceptionEachDay = new System.Windows.Forms.DataGridView();
            this.c_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
            this.tab_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionEachType)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionEachDay)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_Outprot1,
            this.btn_Outport2,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(926, 25);
            this.tool_Main.TabIndex = 11;
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
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Outprot1
            // 
            this.btn_Outprot1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Outprot1.Image = ((System.Drawing.Image)(resources.GetObject("btn_Outprot1.Image")));
            this.btn_Outprot1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Outprot1.Name = "btn_Outprot1";
            this.btn_Outprot1.Size = new System.Drawing.Size(108, 22);
            this.btn_Outprot1.Text = "导出故障编码统计";
            this.btn_Outprot1.Click += new System.EventHandler(this.btn_Outprot1_Click);
            // 
            // btn_Outport2
            // 
            this.btn_Outport2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Outport2.Image = ((System.Drawing.Image)(resources.GetObject("btn_Outport2.Image")));
            this.btn_Outport2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Outport2.Name = "btn_Outport2";
            this.btn_Outport2.Size = new System.Drawing.Size(108, 22);
            this.btn_Outport2.Text = "导出故障日期统计";
            this.btn_Outport2.Click += new System.EventHandler(this.btn_Outport2_Click);
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
            this.status_Main.Location = new System.Drawing.Point(0, 607);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(926, 22);
            this.status_Main.TabIndex = 12;
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
            this.p_Main.Controls.Add(this.tab_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(926, 582);
            this.p_Main.TabIndex = 13;
            // 
            // tab_Main
            // 
            this.tab_Main.Controls.Add(this.tabPage1);
            this.tab_Main.Controls.Add(this.tabPage2);
            this.tab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Main.Location = new System.Drawing.Point(0, 0);
            this.tab_Main.Name = "tab_Main";
            this.tab_Main.SelectedIndex = 0;
            this.tab_Main.Size = new System.Drawing.Size(926, 582);
            this.tab_Main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(918, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "按故障代码统计";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Select);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.check_All);
            this.splitContainer1.Panel1.Controls.Add(this.check_Today);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ExceptionSelect);
            this.splitContainer1.Panel1.Controls.Add(this.check_SelectExceptionCode);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_BeginTime);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Ser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_ExceptionEachType);
            this.splitContainer1.Size = new System.Drawing.Size(912, 550);
            this.splitContainer1.SplitterDistance = 154;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Select
            // 
            this.btn_Select.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.Location = new System.Drawing.Point(815, 68);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(41, 29);
            this.btn_Select.TabIndex = 10;
            this.btn_Select.Text = "…";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(54, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(600, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "说明:指定故障代码请将故障代码以\";\"分开.如:\"test1;test2\"。或则通过点击按钮选择.";
            // 
            // check_All
            // 
            this.check_All.AutoSize = true;
            this.check_All.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_All.Location = new System.Drawing.Point(748, 23);
            this.check_All.Name = "check_All";
            this.check_All.Size = new System.Drawing.Size(61, 25);
            this.check_All.TabIndex = 8;
            this.check_All.Text = "全部";
            this.check_All.UseVisualStyleBackColor = true;
            // 
            // check_Today
            // 
            this.check_Today.AutoSize = true;
            this.check_Today.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_Today.Location = new System.Drawing.Point(672, 23);
            this.check_Today.Name = "check_Today";
            this.check_Today.Size = new System.Drawing.Size(61, 25);
            this.check_Today.TabIndex = 7;
            this.check_Today.Text = "今日";
            this.check_Today.UseVisualStyleBackColor = true;
            // 
            // txt_ExceptionSelect
            // 
            this.txt_ExceptionSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ExceptionSelect.Location = new System.Drawing.Point(221, 68);
            this.txt_ExceptionSelect.Name = "txt_ExceptionSelect";
            this.txt_ExceptionSelect.Size = new System.Drawing.Size(588, 29);
            this.txt_ExceptionSelect.TabIndex = 6;
            // 
            // check_SelectExceptionCode
            // 
            this.check_SelectExceptionCode.AutoSize = true;
            this.check_SelectExceptionCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_SelectExceptionCode.Location = new System.Drawing.Point(58, 72);
            this.check_SelectExceptionCode.Name = "check_SelectExceptionCode";
            this.check_SelectExceptionCode.Size = new System.Drawing.Size(157, 25);
            this.check_SelectExceptionCode.TabIndex = 5;
            this.check_SelectExceptionCode.Text = "是否指定故障代码";
            this.check_SelectExceptionCode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(364, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始时间:";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.CustomFormat = "yyyy-MM-dd hh-mm-ss";
            this.dtp_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndTime.Location = new System.Drawing.Point(457, 18);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_EndTime.TabIndex = 2;
            // 
            // dtp_BeginTime
            // 
            this.dtp_BeginTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtp_BeginTime.CustomFormat = "yyyy-MM-dd hh-mm-ss";
            this.dtp_BeginTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_BeginTime.Location = new System.Drawing.Point(149, 18);
            this.dtp_BeginTime.Name = "dtp_BeginTime";
            this.dtp_BeginTime.Size = new System.Drawing.Size(200, 29);
            this.dtp_BeginTime.TabIndex = 1;
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(781, 116);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 0;
            this.btn_Ser.Text = "查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // dgv_ExceptionEachType
            // 
            this.dgv_ExceptionEachType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExceptionEachType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ExceptionEachType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExceptionEachType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ExceptionCode,
            this.c_ExceptionText,
            this.c_Count});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExceptionEachType.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ExceptionEachType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExceptionEachType.Location = new System.Drawing.Point(0, 0);
            this.dgv_ExceptionEachType.Name = "dgv_ExceptionEachType";
            this.dgv_ExceptionEachType.RowTemplate.Height = 23;
            this.dgv_ExceptionEachType.Size = new System.Drawing.Size(912, 392);
            this.dgv_ExceptionEachType.TabIndex = 0;
            // 
            // c_ExceptionCode
            // 
            this.c_ExceptionCode.DataPropertyName = "ExceptionCode";
            this.c_ExceptionCode.HeaderText = "故障代码";
            this.c_ExceptionCode.Name = "c_ExceptionCode";
            this.c_ExceptionCode.ReadOnly = true;
            // 
            // c_ExceptionText
            // 
            this.c_ExceptionText.DataPropertyName = "ExceptionText";
            this.c_ExceptionText.HeaderText = "故障描述";
            this.c_ExceptionText.Name = "c_ExceptionText";
            this.c_ExceptionText.ReadOnly = true;
            // 
            // c_Count
            // 
            this.c_Count.DataPropertyName = "Count";
            this.c_Count.HeaderText = "出现次数";
            this.c_Count.Name = "c_Count";
            this.c_Count.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(918, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "按天故障统计";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.check_Today2);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.dtp_EndTime2);
            this.splitContainer2.Panel1.Controls.Add(this.dtp_BeginTime2);
            this.splitContainer2.Panel1.Controls.Add(this.btn_Ser2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_ExceptionEachDay);
            this.splitContainer2.Size = new System.Drawing.Size(912, 550);
            this.splitContainer2.SplitterDistance = 118;
            this.splitContainer2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(57, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(672, 43);
            this.label4.TabIndex = 9;
            this.label4.Text = "说明:结束时间应大于开始时间,选择今日即可查看今日的故障数.选择全部则会按天加载所有的故障数,如果加载所需时间较多,则不建议使用加载\"全部\"";
            // 
            // check_Today2
            // 
            this.check_Today2.AutoSize = true;
            this.check_Today2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check_Today2.Location = new System.Drawing.Point(754, 23);
            this.check_Today2.Name = "check_Today2";
            this.check_Today2.Size = new System.Drawing.Size(61, 25);
            this.check_Today2.TabIndex = 7;
            this.check_Today2.Text = "今日";
            this.check_Today2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(399, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "结束时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(61, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "开始时间:";
            // 
            // dtp_EndTime2
            // 
            this.dtp_EndTime2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_EndTime2.Location = new System.Drawing.Point(507, 23);
            this.dtp_EndTime2.Name = "dtp_EndTime2";
            this.dtp_EndTime2.Size = new System.Drawing.Size(200, 29);
            this.dtp_EndTime2.TabIndex = 2;
            // 
            // dtp_BeginTime2
            // 
            this.dtp_BeginTime2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_BeginTime2.Location = new System.Drawing.Point(169, 23);
            this.dtp_BeginTime2.Name = "dtp_BeginTime2";
            this.dtp_BeginTime2.Size = new System.Drawing.Size(200, 29);
            this.dtp_BeginTime2.TabIndex = 1;
            // 
            // btn_Ser2
            // 
            this.btn_Ser2.Location = new System.Drawing.Point(754, 66);
            this.btn_Ser2.Name = "btn_Ser2";
            this.btn_Ser2.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser2.TabIndex = 0;
            this.btn_Ser2.Text = "查询";
            this.btn_Ser2.UseVisualStyleBackColor = true;
            this.btn_Ser2.Click += new System.EventHandler(this.btn_Ser2_Click);
            // 
            // dgv_ExceptionEachDay
            // 
            this.dgv_ExceptionEachDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExceptionEachDay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ExceptionEachDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExceptionEachDay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Date,
            this.c_ExceptionCount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExceptionEachDay.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ExceptionEachDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExceptionEachDay.Location = new System.Drawing.Point(0, 0);
            this.dgv_ExceptionEachDay.Name = "dgv_ExceptionEachDay";
            this.dgv_ExceptionEachDay.RowTemplate.Height = 23;
            this.dgv_ExceptionEachDay.Size = new System.Drawing.Size(912, 428);
            this.dgv_ExceptionEachDay.TabIndex = 0;
            // 
            // c_Date
            // 
            this.c_Date.DataPropertyName = "Date";
            this.c_Date.HeaderText = "日期";
            this.c_Date.Name = "c_Date";
            this.c_Date.ReadOnly = true;
            // 
            // c_ExceptionCount
            // 
            this.c_ExceptionCount.DataPropertyName = "Count";
            this.c_ExceptionCount.HeaderText = "故障数量";
            this.c_ExceptionCount.Name = "c_ExceptionCount";
            this.c_ExceptionCount.ReadOnly = true;
            // 
            // frm_ExceptionStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 629);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ExceptionStatistics";
            this.Text = "异常统计";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.tab_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionEachType)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionEachDay)).EndInit();
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
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.TabControl tab_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_ExceptionEachType;
        private System.Windows.Forms.CheckBox check_SelectExceptionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.CheckBox check_All;
        private System.Windows.Forms.CheckBox check_Today;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_Today2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_EndTime2;
        private System.Windows.Forms.DateTimePicker dtp_BeginTime2;
        private System.Windows.Forms.Button btn_Ser2;
        private System.Windows.Forms.DataGridView dgv_ExceptionEachDay;
        private System.Windows.Forms.Button btn_Select;
        public System.Windows.Forms.TextBox txt_ExceptionSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionText;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCount;
        private System.Windows.Forms.ToolStripButton btn_Outprot1;
        private System.Windows.Forms.ToolStripButton btn_Outport2;
    }
}