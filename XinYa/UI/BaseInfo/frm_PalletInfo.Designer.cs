namespace XinYa.UI.BaseInfo
{
    partial class frm_PalletInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PalletInfo));
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
            this.btn_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_PalletCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_PalletSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Isuse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_PalletCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_PalletSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chck_Isuse = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Ser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.statu_Main = new System.Windows.Forms.StatusStrip();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Statustext = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.tool_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.statu_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
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
            this.btn_Exit,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(857, 25);
            this.tool_Main.TabIndex = 2;
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
            // btn_Exit
            // 
            this.btn_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(36, 22);
            this.btn_Exit.Text = "退出";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
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
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 0);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.dgv_Main);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.tlp_Main);
            this.split_Main.Size = new System.Drawing.Size(857, 473);
            this.split_Main.SplitterDistance = 286;
            this.split_Main.TabIndex = 4;
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_PalletCode,
            this.c_PalletSize,
            this.c_Isuse,
            this.c_Remark});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(286, 473);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            // 
            // c_PalletCode
            // 
            this.c_PalletCode.DataPropertyName = "PalletCode";
            this.c_PalletCode.HeaderText = "托盘编码";
            this.c_PalletCode.Name = "c_PalletCode";
            this.c_PalletCode.ReadOnly = true;
            // 
            // c_PalletSize
            // 
            this.c_PalletSize.DataPropertyName = "PalletSize";
            this.c_PalletSize.HeaderText = "托盘规格";
            this.c_PalletSize.Name = "c_PalletSize";
            this.c_PalletSize.ReadOnly = true;
            // 
            // c_Isuse
            // 
            this.c_Isuse.DataPropertyName = "IsUse";
            this.c_Isuse.FalseValue = "false";
            this.c_Isuse.HeaderText = "是否启用";
            this.c_Isuse.Name = "c_Isuse";
            this.c_Isuse.ReadOnly = true;
            this.c_Isuse.TrueValue = "true";
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            this.c_Remark.ReadOnly = true;
            this.c_Remark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.panel1, 0, 0);
            this.tlp_Main.Controls.Add(this.panel2, 0, 1);
            this.tlp_Main.Controls.Add(this.panel3, 0, 2);
            this.tlp_Main.Controls.Add(this.panel4, 0, 3);
            this.tlp_Main.Controls.Add(this.panel5, 0, 4);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 5;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlp_Main.Size = new System.Drawing.Size(567, 473);
            this.tlp_Main.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_PalletCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 64);
            this.panel1.TabIndex = 0;
            // 
            // txt_PalletCode
            // 
            this.txt_PalletCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PalletCode.Location = new System.Drawing.Point(124, 27);
            this.txt_PalletCode.Name = "txt_PalletCode";
            this.txt_PalletCode.Size = new System.Drawing.Size(186, 29);
            this.txt_PalletCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "托盘编码：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_PalletSize);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 64);
            this.panel2.TabIndex = 1;
            // 
            // txt_PalletSize
            // 
            this.txt_PalletSize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PalletSize.Location = new System.Drawing.Point(124, 16);
            this.txt_PalletSize.Name = "txt_PalletSize";
            this.txt_PalletSize.Size = new System.Drawing.Size(186, 29);
            this.txt_PalletSize.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "托盘规格：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chck_Isuse);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 64);
            this.panel3.TabIndex = 2;
            // 
            // chck_Isuse
            // 
            this.chck_Isuse.AutoSize = true;
            this.chck_Isuse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chck_Isuse.Location = new System.Drawing.Point(124, 18);
            this.chck_Isuse.Name = "chck_Isuse";
            this.chck_Isuse.Size = new System.Drawing.Size(93, 25);
            this.chck_Isuse.TabIndex = 1;
            this.chck_Isuse.Text = "是否启用";
            this.chck_Isuse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chck_Isuse.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txt_Remark);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 213);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(561, 183);
            this.panel4.TabIndex = 3;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Remark.Location = new System.Drawing.Point(87, 3);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Remark.Size = new System.Drawing.Size(465, 167);
            this.txt_Remark.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "备注：";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_Save);
            this.panel5.Controls.Add(this.txt_Ser);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btn_Confirm);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 402);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(561, 68);
            this.panel5.TabIndex = 4;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(457, 24);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Visible = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Ser
            // 
            this.txt_Ser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Ser.Location = new System.Drawing.Point(179, 18);
            this.txt_Ser.Name = "txt_Ser";
            this.txt_Ser.Size = new System.Drawing.Size(131, 29);
            this.txt_Ser.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "指定托盘编码查询：";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(320, 24);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确认";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // statu_Main
            // 
            this.statu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_Statustext});
            this.statu_Main.Location = new System.Drawing.Point(0, 498);
            this.statu_Main.Name = "statu_Main";
            this.statu_Main.Size = new System.Drawing.Size(857, 22);
            this.statu_Main.TabIndex = 5;
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
            this.p_Main.Controls.Add(this.split_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(857, 473);
            this.p_Main.TabIndex = 6;
            // 
            // frm_PalletInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 520);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.statu_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_PalletInfo";
            this.Text = "托盘信息管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.statu_Main.ResumeLayout(false);
            this.statu_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Add;
        private System.Windows.Forms.ToolStripButton btn_AddCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripButton btn_EditCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btn_ImportExcel;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.StatusStrip statu_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.ToolStripStatusLabel lab_Statustext;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_PalletCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_PalletSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chck_Isuse;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PalletCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_PalletSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Isuse;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
        private System.Windows.Forms.TextBox txt_Ser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
    }
}