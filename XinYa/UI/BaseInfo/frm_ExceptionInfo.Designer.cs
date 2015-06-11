namespace XinYa.UI.BaseInfo
{
    partial class frm_ExceptionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExceptionInfo));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Add = new System.Windows.Forms.ToolStripButton();
            this.btn_AddCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Edit = new System.Windows.Forms.ToolStripButton();
            this.btn_EditCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_ImportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.statu_Main = new System.Windows.Forms.StatusStrip();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Statustext = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.p_Part1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_ExceptionInfo = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionDtl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp_Dtl = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_ExceptionCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_ExceptionDtl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lab_Creator = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lab_CreateTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.p_Part2 = new System.Windows.Forms.Panel();
            this.txt_Ser = new System.Windows.Forms.TextBox();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tool_Main.SuspendLayout();
            this.statu_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.p_Part1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).BeginInit();
            this.tlp_Dtl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.p_Part2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btn_Add,
            this.btn_AddCancel,
            this.toolStripSeparator2,
            this.btn_Edit,
            this.btn_EditCancel,
            this.toolStripSeparator3,
            this.btn_Delete,
            this.toolStripSeparator4,
            this.btn_Refresh,
            this.toolStripSeparator5,
            this.btn_ImportExcel,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(953, 25);
            this.tool_Main.TabIndex = 1;
            this.tool_Main.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Add
            // 
            this.btn_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(36, 22);
            this.btn_Add.Text = "新增";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_AddCancel
            // 
            this.btn_AddCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddCancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddCancel.Image")));
            this.btn_AddCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddCancel.Name = "btn_AddCancel";
            this.btn_AddCancel.Size = new System.Drawing.Size(60, 22);
            this.btn_AddCancel.Text = "取消新增";
            this.btn_AddCancel.Visible = false;
            this.btn_AddCancel.Click += new System.EventHandler(this.btn_AddCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_ImportExcel
            // 
            this.btn_ImportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_ImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportExcel.Image")));
            this.btn_ImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ImportExcel.Name = "btn_ImportExcel";
            this.btn_ImportExcel.Size = new System.Drawing.Size(113, 22);
            this.btn_ImportExcel.Text = "导出数据到Excel表";
            this.btn_ImportExcel.Click += new System.EventHandler(this.btn_ImportExcel_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel1.Text = "系统正在处理：";
            this.toolStripLabel1.Visible = false;
            // 
            // prosbar_Main
            // 
            this.prosbar_Main.Name = "prosbar_Main";
            this.prosbar_Main.Size = new System.Drawing.Size(100, 22);
            this.prosbar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prosbar_Main.Visible = false;
            // 
            // statu_Main
            // 
            this.statu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_Statustext});
            this.statu_Main.Location = new System.Drawing.Point(0, 514);
            this.statu_Main.Name = "statu_Main";
            this.statu_Main.Size = new System.Drawing.Size(953, 22);
            this.statu_Main.TabIndex = 2;
            this.statu_Main.Text = "statusStrip1";
            // 
            // lab_Status
            // 
            this.lab_Status.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(68, 17);
            this.lab_Status.Text = "当前状态：";
            // 
            // lab_Statustext
            // 
            this.lab_Statustext.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_Statustext.Name = "lab_Statustext";
            this.lab_Statustext.Size = new System.Drawing.Size(32, 17);
            this.lab_Statustext.Text = "就绪";
            // 
            // p_Main
            // 
            this.p_Main.BackColor = System.Drawing.Color.Transparent;
            this.p_Main.Controls.Add(this.tlp_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(953, 489);
            this.p_Main.TabIndex = 3;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.p_Part1, 0, 0);
            this.tlp_Main.Controls.Add(this.p_Part2, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlp_Main.Size = new System.Drawing.Size(953, 489);
            this.tlp_Main.TabIndex = 0;
            // 
            // p_Part1
            // 
            this.p_Part1.Controls.Add(this.splitContainer1);
            this.p_Part1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Part1.Location = new System.Drawing.Point(0, 0);
            this.p_Part1.Margin = new System.Windows.Forms.Padding(0);
            this.p_Part1.Name = "p_Part1";
            this.p_Part1.Size = new System.Drawing.Size(953, 430);
            this.p_Part1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_ExceptionInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tlp_Dtl);
            this.splitContainer1.Size = new System.Drawing.Size(953, 430);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgv_ExceptionInfo
            // 
            this.dgv_ExceptionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExceptionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_ExceptionCode,
            this.c_ExceptionDtl,
            this.c_Creator,
            this.c_CreateDate,
            this.c_Remark});
            this.dgv_ExceptionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExceptionInfo.Location = new System.Drawing.Point(0, 0);
            this.dgv_ExceptionInfo.Name = "dgv_ExceptionInfo";
            this.dgv_ExceptionInfo.RowTemplate.Height = 23;
            this.dgv_ExceptionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ExceptionInfo.Size = new System.Drawing.Size(294, 428);
            this.dgv_ExceptionInfo.TabIndex = 0;
            this.dgv_ExceptionInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExceptionInfo_CellClick);
            this.dgv_ExceptionInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_ExceptionInfo_CellFormatting);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.Visible = false;
            // 
            // c_ExceptionCode
            // 
            this.c_ExceptionCode.DataPropertyName = "ExceptionCode";
            this.c_ExceptionCode.HeaderText = "错误代码";
            this.c_ExceptionCode.Name = "c_ExceptionCode";
            // 
            // c_ExceptionDtl
            // 
            this.c_ExceptionDtl.DataPropertyName = "ExceptionText";
            this.c_ExceptionDtl.HeaderText = "错误描述";
            this.c_ExceptionDtl.Name = "c_ExceptionDtl";
            // 
            // c_Creator
            // 
            this.c_Creator.DataPropertyName = "TB_User.UserName";
            this.c_Creator.HeaderText = "录入者";
            this.c_Creator.Name = "c_Creator";
            // 
            // c_CreateDate
            // 
            this.c_CreateDate.DataPropertyName = "CreateDate";
            this.c_CreateDate.HeaderText = "录入时间";
            this.c_CreateDate.Name = "c_CreateDate";
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            // 
            // tlp_Dtl
            // 
            this.tlp_Dtl.ColumnCount = 1;
            this.tlp_Dtl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Dtl.Controls.Add(this.panel1, 0, 0);
            this.tlp_Dtl.Controls.Add(this.panel2, 0, 1);
            this.tlp_Dtl.Controls.Add(this.panel3, 0, 2);
            this.tlp_Dtl.Controls.Add(this.panel4, 0, 3);
            this.tlp_Dtl.Controls.Add(this.panel6, 0, 5);
            this.tlp_Dtl.Controls.Add(this.panel5, 0, 4);
            this.tlp_Dtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Dtl.Location = new System.Drawing.Point(0, 0);
            this.tlp_Dtl.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Dtl.Name = "tlp_Dtl";
            this.tlp_Dtl.RowCount = 6;
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlp_Dtl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Dtl.Size = new System.Drawing.Size(651, 428);
            this.tlp_Dtl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_ExceptionCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 71);
            this.panel1.TabIndex = 0;
            // 
            // txt_ExceptionCode
            // 
            this.txt_ExceptionCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ExceptionCode.Location = new System.Drawing.Point(123, 20);
            this.txt_ExceptionCode.Name = "txt_ExceptionCode";
            this.txt_ExceptionCode.ReadOnly = true;
            this.txt_ExceptionCode.Size = new System.Drawing.Size(151, 29);
            this.txt_ExceptionCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "错误代码：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_ExceptionDtl);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 71);
            this.panel2.TabIndex = 1;
            // 
            // txt_ExceptionDtl
            // 
            this.txt_ExceptionDtl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ExceptionDtl.Location = new System.Drawing.Point(123, 3);
            this.txt_ExceptionDtl.Multiline = true;
            this.txt_ExceptionDtl.Name = "txt_ExceptionDtl";
            this.txt_ExceptionDtl.ReadOnly = true;
            this.txt_ExceptionDtl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ExceptionDtl.Size = new System.Drawing.Size(493, 65);
            this.txt_ExceptionDtl.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "错误描述：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lab_Creator);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 71);
            this.panel3.TabIndex = 2;
            // 
            // lab_Creator
            // 
            this.lab_Creator.AutoSize = true;
            this.lab_Creator.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Creator.Location = new System.Drawing.Point(119, 17);
            this.lab_Creator.Name = "lab_Creator";
            this.lab_Creator.Size = new System.Drawing.Size(67, 21);
            this.lab_Creator.TabIndex = 1;
            this.lab_Creator.Text = "Creator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "录入者：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lab_CreateTime);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 234);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(645, 71);
            this.panel4.TabIndex = 3;
            // 
            // lab_CreateTime
            // 
            this.lab_CreateTime.AutoSize = true;
            this.lab_CreateTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_CreateTime.Location = new System.Drawing.Point(125, 16);
            this.lab_CreateTime.Name = "lab_CreateTime";
            this.lab_CreateTime.Size = new System.Drawing.Size(103, 21);
            this.lab_CreateTime.TabIndex = 1;
            this.lab_CreateTime.Text = "CreaterTime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(29, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "录入时间：";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_Confirm);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 388);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(645, 37);
            this.panel6.TabIndex = 5;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(543, 8);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txt_Remark);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 311);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(645, 71);
            this.panel5.TabIndex = 6;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Remark.Location = new System.Drawing.Point(129, 3);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ReadOnly = true;
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Remark.Size = new System.Drawing.Size(487, 65);
            this.txt_Remark.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(29, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注：";
            // 
            // p_Part2
            // 
            this.p_Part2.Controls.Add(this.txt_Ser);
            this.p_Part2.Controls.Add(this.btn_Ser);
            this.p_Part2.Controls.Add(this.label1);
            this.p_Part2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Part2.Location = new System.Drawing.Point(0, 430);
            this.p_Part2.Margin = new System.Windows.Forms.Padding(0);
            this.p_Part2.Name = "p_Part2";
            this.p_Part2.Size = new System.Drawing.Size(953, 59);
            this.p_Part2.TabIndex = 0;
            // 
            // txt_Ser
            // 
            this.txt_Ser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Ser.Location = new System.Drawing.Point(164, 13);
            this.txt_Ser.Name = "txt_Ser";
            this.txt_Ser.Size = new System.Drawing.Size(506, 26);
            this.txt_Ser.TabIndex = 4;
            // 
            // btn_Ser
            // 
            this.btn_Ser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ser.Location = new System.Drawing.Point(702, 15);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 3;
            this.btn_Ser.Text = "查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "指定错误代码：";
            // 
            // frm_ExceptionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(953, 536);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.statu_Main);
            this.Controls.Add(this.tool_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ExceptionInfo";
            this.Text = "异常信息管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.statu_Main.ResumeLayout(false);
            this.statu_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.tlp_Main.ResumeLayout(false);
            this.p_Part1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).EndInit();
            this.tlp_Dtl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.p_Part2.ResumeLayout(false);
            this.p_Part2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.StatusStrip statu_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lab_Statustext;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Panel p_Part1;
        private System.Windows.Forms.Panel p_Part2;
        private System.Windows.Forms.TextBox txt_Ser;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_ExceptionInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tlp_Dtl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_ExceptionCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_ExceptionDtl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lab_Creator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lab_CreateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton btn_Add;
        private System.Windows.Forms.ToolStripButton btn_AddCancel;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_EditCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btn_ImportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionDtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;


    }
}