namespace XinYa.UI.WorkManagement
{
    partial class frm_ProcessRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProcessRoute));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_OutportMain = new System.Windows.Forms.ToolStripButton();
            this.btn_OutportDtl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_RouteM = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_RouteP = new System.Windows.Forms.DataGridView();
            this.工序编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工位名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否启用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.是否最后 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteP)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lab_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(901, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前状态：";
            // 
            // lab_Status
            // 
            this.lab_Status.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(53, 17);
            this.lab_Status.Text = "加载中...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.btn_OutportMain,
            this.btn_OutportDtl,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripLabel1,
            this.prosbar_Main});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(901, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "新增";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton2.Text = "编辑";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton5.Text = "刷新";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_OutportMain
            // 
            this.btn_OutportMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_OutportMain.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutportMain.Image")));
            this.btn_OutportMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OutportMain.Name = "btn_OutportMain";
            this.btn_OutportMain.Size = new System.Drawing.Size(96, 22);
            this.btn_OutportMain.Text = "导出主工艺路线";
            this.btn_OutportMain.Click += new System.EventHandler(this.btn_OutportMain_Click);
            // 
            // btn_OutportDtl
            // 
            this.btn_OutportDtl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_OutportDtl.Image = ((System.Drawing.Image)(resources.GetObject("btn_OutportDtl.Image")));
            this.btn_OutportDtl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_OutportDtl.Name = "btn_OutportDtl";
            this.btn_OutportDtl.Size = new System.Drawing.Size(108, 22);
            this.btn_OutportDtl.Text = "导出工艺路线明细";
            this.btn_OutportDtl.Click += new System.EventHandler(this.btn_OutportDtl_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton4.Text = "退出";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_RouteM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_RouteP);
            this.splitContainer1.Size = new System.Drawing.Size(901, 391);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgv_RouteM
            // 
            this.dgv_RouteM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RouteM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_RouteM.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_RouteM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RouteM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ID,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgv_RouteM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RouteM.Location = new System.Drawing.Point(0, 0);
            this.dgv_RouteM.Name = "dgv_RouteM";
            this.dgv_RouteM.ReadOnly = true;
            this.dgv_RouteM.RowTemplate.Height = 23;
            this.dgv_RouteM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RouteM.Size = new System.Drawing.Size(901, 109);
            this.dgv_RouteM.TabIndex = 0;
            this.dgv_RouteM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RouteM_CellClick);
            this.dgv_RouteM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_RouteM_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProcessRouteMName";
            this.Column1.HeaderText = "工艺路线名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProcessRouteP";
            this.Column2.HeaderText = "工艺路线编码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "IsUse";
            this.Column3.HeaderText = "是否启用";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TB_User.UserName";
            this.Column4.HeaderText = "创建者";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CreateDate";
            this.Column5.HeaderText = "创建日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Remark";
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // dgv_RouteP
            // 
            this.dgv_RouteP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RouteP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_RouteP.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_RouteP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RouteP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.工序编码,
            this.工序,
            this.工位名称,
            this.是否启用,
            this.是否最后,
            this.备注});
            this.dgv_RouteP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RouteP.Location = new System.Drawing.Point(0, 0);
            this.dgv_RouteP.Name = "dgv_RouteP";
            this.dgv_RouteP.ReadOnly = true;
            this.dgv_RouteP.RowTemplate.Height = 23;
            this.dgv_RouteP.Size = new System.Drawing.Size(901, 278);
            this.dgv_RouteP.TabIndex = 0;
            this.dgv_RouteP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_RouteP_CellFormatting);
            // 
            // 工序编码
            // 
            this.工序编码.DataPropertyName = "ProcessRouteM";
            this.工序编码.HeaderText = "工艺路线编码";
            this.工序编码.Name = "工序编码";
            this.工序编码.ReadOnly = true;
            // 
            // 工序
            // 
            this.工序.DataPropertyName = "No";
            this.工序.HeaderText = "工序";
            this.工序.Name = "工序";
            this.工序.ReadOnly = true;
            // 
            // 工位名称
            // 
            this.工位名称.DataPropertyName = "TB_WorkStationInfo.WorkStationName";
            this.工位名称.HeaderText = "工位名称";
            this.工位名称.Name = "工位名称";
            this.工位名称.ReadOnly = true;
            // 
            // 是否启用
            // 
            this.是否启用.DataPropertyName = "IsUse";
            this.是否启用.HeaderText = "是否启用";
            this.是否启用.Name = "是否启用";
            this.是否启用.ReadOnly = true;
            // 
            // 是否最后
            // 
            this.是否最后.DataPropertyName = "IsLast";
            this.是否最后.HeaderText = "是否最后";
            this.是否最后.Name = "是否最后";
            this.是否最后.ReadOnly = true;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "Remark";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            // 
            // frm_ProcessRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(901, 438);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frm_ProcessRoute";
            this.Text = "工艺路线管理";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_RouteM;
        private System.Windows.Forms.DataGridView dgv_RouteP;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_OutportMain;
        private System.Windows.Forms.ToolStripButton btn_OutportDtl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工位名称;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否启用;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否最后;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
    }
}