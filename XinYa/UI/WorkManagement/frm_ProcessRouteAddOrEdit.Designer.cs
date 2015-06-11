namespace XinYa.UI.WorkManagement
{
    partial class frm_ProcessRouteAddOrEdit
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.p_Part1 = new System.Windows.Forms.Panel();
            this.tlp_Part1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_RouteName = new System.Windows.Forms.TextBox();
            this.lab_RouteName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_RouteCode = new System.Windows.Forms.TextBox();
            this.lab_RouteCode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.check_IsUse = new System.Windows.Forms.CheckBox();
            this.lab_IsUse = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lab_Date = new System.Windows.Forms.Label();
            this.lab_Creator = new System.Windows.Forms.Label();
            this.lab_Date1 = new System.Windows.Forms.Label();
            this.lab_Creator1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.lab_Remark = new System.Windows.Forms.Label();
            this.p_Part2 = new System.Windows.Forms.Panel();
            this.dgv_RouteP = new System.Windows.Forms.DataGridView();
            this.工序编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工位名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否启用 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.是否最后 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.p_Part1.SuspendLayout();
            this.tlp_Part1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.p_Part2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteP)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lab_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 22);
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
            // p_Bottom
            // 
            this.p_Bottom.Controls.Add(this.btn_Save);
            this.p_Bottom.Controls.Add(this.btn_Cancel);
            this.p_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Bottom.Location = new System.Drawing.Point(0, 412);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(939, 45);
            this.p_Bottom.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(772, 10);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(853, 10);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "取消退出";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
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
            this.split_Main.Panel1.Controls.Add(this.p_Part1);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.p_Part2);
            this.split_Main.Size = new System.Drawing.Size(939, 412);
            this.split_Main.SplitterDistance = 160;
            this.split_Main.TabIndex = 2;
            // 
            // p_Part1
            // 
            this.p_Part1.Controls.Add(this.tlp_Part1);
            this.p_Part1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Part1.Location = new System.Drawing.Point(0, 0);
            this.p_Part1.Margin = new System.Windows.Forms.Padding(0);
            this.p_Part1.Name = "p_Part1";
            this.p_Part1.Size = new System.Drawing.Size(939, 160);
            this.p_Part1.TabIndex = 0;
            // 
            // tlp_Part1
            // 
            this.tlp_Part1.ColumnCount = 2;
            this.tlp_Part1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Part1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Part1.Controls.Add(this.panel1, 0, 0);
            this.tlp_Part1.Controls.Add(this.panel2, 1, 0);
            this.tlp_Part1.Controls.Add(this.panel3, 0, 1);
            this.tlp_Part1.Controls.Add(this.panel4, 1, 1);
            this.tlp_Part1.Controls.Add(this.panel5, 0, 2);
            this.tlp_Part1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Part1.Location = new System.Drawing.Point(0, 0);
            this.tlp_Part1.Name = "tlp_Part1";
            this.tlp_Part1.RowCount = 3;
            this.tlp_Part1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlp_Part1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlp_Part1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlp_Part1.Size = new System.Drawing.Size(939, 160);
            this.tlp_Part1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_RouteName);
            this.panel1.Controls.Add(this.lab_RouteName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 46);
            this.panel1.TabIndex = 0;
            // 
            // txt_RouteName
            // 
            this.txt_RouteName.Location = new System.Drawing.Point(131, 16);
            this.txt_RouteName.Name = "txt_RouteName";
            this.txt_RouteName.Size = new System.Drawing.Size(311, 21);
            this.txt_RouteName.TabIndex = 1;
            // 
            // lab_RouteName
            // 
            this.lab_RouteName.AutoSize = true;
            this.lab_RouteName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_RouteName.Location = new System.Drawing.Point(18, 16);
            this.lab_RouteName.Name = "lab_RouteName";
            this.lab_RouteName.Size = new System.Drawing.Size(106, 21);
            this.lab_RouteName.TabIndex = 0;
            this.lab_RouteName.Text = "工艺路线名：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_RouteCode);
            this.panel2.Controls.Add(this.lab_RouteCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(472, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 46);
            this.panel2.TabIndex = 1;
            // 
            // txt_RouteCode
            // 
            this.txt_RouteCode.Location = new System.Drawing.Point(148, 16);
            this.txt_RouteCode.Name = "txt_RouteCode";
            this.txt_RouteCode.Size = new System.Drawing.Size(257, 21);
            this.txt_RouteCode.TabIndex = 1;
            // 
            // lab_RouteCode
            // 
            this.lab_RouteCode.AutoSize = true;
            this.lab_RouteCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_RouteCode.Location = new System.Drawing.Point(19, 16);
            this.lab_RouteCode.Name = "lab_RouteCode";
            this.lab_RouteCode.Size = new System.Drawing.Size(122, 21);
            this.lab_RouteCode.TabIndex = 0;
            this.lab_RouteCode.Text = "工艺路线编码：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.check_IsUse);
            this.panel3.Controls.Add(this.lab_IsUse);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 46);
            this.panel3.TabIndex = 2;
            // 
            // check_IsUse
            // 
            this.check_IsUse.AutoSize = true;
            this.check_IsUse.Location = new System.Drawing.Point(131, 20);
            this.check_IsUse.Name = "check_IsUse";
            this.check_IsUse.Size = new System.Drawing.Size(15, 14);
            this.check_IsUse.TabIndex = 1;
            this.check_IsUse.UseVisualStyleBackColor = true;
            // 
            // lab_IsUse
            // 
            this.lab_IsUse.AutoSize = true;
            this.lab_IsUse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_IsUse.Location = new System.Drawing.Point(20, 15);
            this.lab_IsUse.Name = "lab_IsUse";
            this.lab_IsUse.Size = new System.Drawing.Size(78, 21);
            this.lab_IsUse.TabIndex = 0;
            this.lab_IsUse.Text = "是否启用:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lab_Date);
            this.panel4.Controls.Add(this.lab_Creator);
            this.panel4.Controls.Add(this.lab_Date1);
            this.panel4.Controls.Add(this.lab_Creator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(472, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 46);
            this.panel4.TabIndex = 3;
            // 
            // lab_Date
            // 
            this.lab_Date.AutoSize = true;
            this.lab_Date.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Date.Location = new System.Drawing.Point(296, 14);
            this.lab_Date.Name = "lab_Date";
            this.lab_Date.Size = new System.Drawing.Size(74, 21);
            this.lab_Date.TabIndex = 2;
            this.lab_Date.Text = "创建日期";
            // 
            // lab_Creator
            // 
            this.lab_Creator.AutoSize = true;
            this.lab_Creator.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Creator.Location = new System.Drawing.Point(111, 14);
            this.lab_Creator.Name = "lab_Creator";
            this.lab_Creator.Size = new System.Drawing.Size(58, 21);
            this.lab_Creator.TabIndex = 1;
            this.lab_Creator.Text = "创建者";
            // 
            // lab_Date1
            // 
            this.lab_Date1.AutoSize = true;
            this.lab_Date1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Date1.Location = new System.Drawing.Point(204, 14);
            this.lab_Date1.Name = "lab_Date1";
            this.lab_Date1.Size = new System.Drawing.Size(90, 21);
            this.lab_Date1.TabIndex = 0;
            this.lab_Date1.Text = "创建日期：";
            // 
            // lab_Creator1
            // 
            this.lab_Creator1.AutoSize = true;
            this.lab_Creator1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Creator1.Location = new System.Drawing.Point(19, 14);
            this.lab_Creator1.Name = "lab_Creator1";
            this.lab_Creator1.Size = new System.Drawing.Size(74, 21);
            this.lab_Creator1.TabIndex = 0;
            this.lab_Creator1.Text = "创建者：";
            // 
            // panel5
            // 
            this.tlp_Part1.SetColumnSpan(this.panel5, 2);
            this.panel5.Controls.Add(this.txt_Remark);
            this.panel5.Controls.Add(this.lab_Remark);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 107);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(933, 50);
            this.panel5.TabIndex = 4;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(84, 3);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Remark.Size = new System.Drawing.Size(840, 44);
            this.txt_Remark.TabIndex = 1;
            // 
            // lab_Remark
            // 
            this.lab_Remark.AutoSize = true;
            this.lab_Remark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Remark.Location = new System.Drawing.Point(20, 15);
            this.lab_Remark.Name = "lab_Remark";
            this.lab_Remark.Size = new System.Drawing.Size(58, 21);
            this.lab_Remark.TabIndex = 0;
            this.lab_Remark.Text = "备注：";
            // 
            // p_Part2
            // 
            this.p_Part2.Controls.Add(this.dgv_RouteP);
            this.p_Part2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Part2.Location = new System.Drawing.Point(0, 0);
            this.p_Part2.Margin = new System.Windows.Forms.Padding(0);
            this.p_Part2.Name = "p_Part2";
            this.p_Part2.Size = new System.Drawing.Size(939, 248);
            this.p_Part2.TabIndex = 0;
            // 
            // dgv_RouteP
            // 
            this.dgv_RouteP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RouteP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_RouteP.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_RouteP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RouteP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.工序编码,
            this.ID,
            this.工序,
            this.工位名称,
            this.是否启用,
            this.是否最后,
            this.备注});
            this.dgv_RouteP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RouteP.Location = new System.Drawing.Point(0, 0);
            this.dgv_RouteP.Name = "dgv_RouteP";
            this.dgv_RouteP.RowTemplate.Height = 23;
            this.dgv_RouteP.Size = new System.Drawing.Size(939, 248);
            this.dgv_RouteP.TabIndex = 1;
            this.dgv_RouteP.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_RouteP_CellFormatting);
            // 
            // 工序编码
            // 
            this.工序编码.DataPropertyName = "ProcessRouteM";
            this.工序编码.HeaderText = "工序编码";
            this.工序编码.Name = "工序编码";
            this.工序编码.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
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
            // 
            // frm_ProcessRouteAddOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(939, 479);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.p_Bottom);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ProcessRouteAddOrEdit";
            this.Text = "工艺路线信息添加或编辑";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.p_Part1.ResumeLayout(false);
            this.tlp_Part1.ResumeLayout(false);
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
            this.p_Part2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RouteP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.Panel p_Part1;
        private System.Windows.Forms.Panel p_Part2;
        private System.Windows.Forms.DataGridView dgv_RouteP;
        private System.Windows.Forms.TableLayoutPanel tlp_Part1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lab_RouteName;
        private System.Windows.Forms.Label lab_RouteCode;
        private System.Windows.Forms.Label lab_IsUse;
        private System.Windows.Forms.Label lab_Creator1;
        private System.Windows.Forms.Label lab_Date1;
        private System.Windows.Forms.Label lab_Remark;
        private System.Windows.Forms.Label lab_Creator;
        private System.Windows.Forms.Label lab_Date;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.TextBox txt_RouteName;
        private System.Windows.Forms.TextBox txt_RouteCode;
        private System.Windows.Forms.CheckBox check_IsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序编码;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工位名称;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否启用;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 是否最后;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
    }
}