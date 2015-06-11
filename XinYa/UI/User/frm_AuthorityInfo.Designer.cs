namespace XinYa.UI.User
{
    partial class frm_AuthorityInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AuthorityInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_UserName = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Ser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.statu_Main = new System.Windows.Forms.StatusStrip();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Statustext = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_UserLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_UserRight = new System.Windows.Forms.DataGridView();
            this.c_ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_IsUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tool_Main.SuspendLayout();
            this.statu_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserRight)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Exit,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txt_UserName,
            this.btn_Ser,
            this.toolStripSeparator3,
            this.btn_Refresh,
            this.toolStripSeparator2,
            this.btn_Save,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(898, 25);
            this.tool_Main.TabIndex = 0;
            this.tool_Main.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel1.Text = "指定用户名查询：";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 25);
            // 
            // btn_Ser
            // 
            this.btn_Ser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Ser.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ser.Image")));
            this.btn_Ser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(36, 22);
            this.btn_Ser.Text = "查询";
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(132, 22);
            this.btn_Save.Text = "保存当前用户权限设置";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel2.Text = "系统正在处理：";
            this.toolStripLabel2.Visible = false;
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
            this.statu_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_Statustext});
            this.statu_Main.Location = new System.Drawing.Point(0, 411);
            this.statu_Main.Name = "statu_Main";
            this.statu_Main.Size = new System.Drawing.Size(898, 22);
            this.statu_Main.TabIndex = 4;
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
            this.lab_Statustext.Size = new System.Drawing.Size(44, 17);
            this.lab_Statustext.Text = "可编辑";
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.split_Main);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(898, 386);
            this.p_Main.TabIndex = 5;
            // 
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 0);
            this.split_Main.Name = "split_Main";
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.dgv_User);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.dgv_UserRight);
            this.split_Main.Size = new System.Drawing.Size(898, 386);
            this.split_Main.SplitterDistance = 502;
            this.split_Main.TabIndex = 0;
            // 
            // dgv_User
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_UserID,
            this.c_UserName,
            this.c_UserLevel,
            this.C_Department,
            this.c_Gender});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_User.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_User.Location = new System.Drawing.Point(0, 0);
            this.dgv_User.Name = "dgv_User";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_User.RowTemplate.Height = 23;
            this.dgv_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_User.Size = new System.Drawing.Size(502, 386);
            this.dgv_User.TabIndex = 0;
            this.dgv_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_User_CellClick);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_UserID
            // 
            this.c_UserID.DataPropertyName = "UserID";
            this.c_UserID.HeaderText = "工号";
            this.c_UserID.Name = "c_UserID";
            this.c_UserID.ReadOnly = true;
            // 
            // c_UserName
            // 
            this.c_UserName.DataPropertyName = "UserName";
            this.c_UserName.HeaderText = "用户名";
            this.c_UserName.Name = "c_UserName";
            this.c_UserName.ReadOnly = true;
            // 
            // c_UserLevel
            // 
            this.c_UserLevel.DataPropertyName = "UserLevel";
            this.c_UserLevel.HeaderText = "用户级别";
            this.c_UserLevel.Name = "c_UserLevel";
            this.c_UserLevel.ReadOnly = true;
            // 
            // C_Department
            // 
            this.C_Department.DataPropertyName = "Department";
            this.C_Department.HeaderText = "部门";
            this.C_Department.Name = "C_Department";
            this.C_Department.ReadOnly = true;
            // 
            // c_Gender
            // 
            this.c_Gender.DataPropertyName = "Gender";
            this.c_Gender.HeaderText = "性别";
            this.c_Gender.Name = "c_Gender";
            this.c_Gender.ReadOnly = true;
            // 
            // dgv_UserRight
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserRight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_UserRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID2,
            this.c_SecondWorkStationID,
            this.c_SecondWorkStationName,
            this.c_IsUse});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserRight.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_UserRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_UserRight.Location = new System.Drawing.Point(0, 0);
            this.dgv_UserRight.Name = "dgv_UserRight";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_UserRight.RowTemplate.Height = 23;
            this.dgv_UserRight.Size = new System.Drawing.Size(392, 386);
            this.dgv_UserRight.TabIndex = 0;
            this.dgv_UserRight.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_UserRight_CellFormatting);
            // 
            // c_ID2
            // 
            this.c_ID2.DataPropertyName = "ID";
            this.c_ID2.HeaderText = "ID";
            this.c_ID2.Name = "c_ID2";
            this.c_ID2.ReadOnly = true;
            this.c_ID2.Visible = false;
            // 
            // c_SecondWorkStationID
            // 
            this.c_SecondWorkStationID.DataPropertyName = "SecondWorkStationID";
            this.c_SecondWorkStationID.HeaderText = "SecondWorkStationID";
            this.c_SecondWorkStationID.Name = "c_SecondWorkStationID";
            this.c_SecondWorkStationID.ReadOnly = true;
            this.c_SecondWorkStationID.Visible = false;
            // 
            // c_SecondWorkStationName
            // 
            this.c_SecondWorkStationName.DataPropertyName = "TB_SecondWorkStationInfo.SecondWorkStationName";
            this.c_SecondWorkStationName.HeaderText = "工位名";
            this.c_SecondWorkStationName.Name = "c_SecondWorkStationName";
            // 
            // c_IsUse
            // 
            this.c_IsUse.DataPropertyName = "IsUse";
            this.c_IsUse.FalseValue = "false";
            this.c_IsUse.HeaderText = "是否允许登录";
            this.c_IsUse.Name = "c_IsUse";
            this.c_IsUse.TrueValue = "true";
            // 
            // frm_AuthorityInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 433);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.statu_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_AuthorityInfo";
            this.Text = "员工权限管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.statu_Main.ResumeLayout(false);
            this.statu_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_UserName;
        private System.Windows.Forms.ToolStripButton btn_Ser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.StatusStrip statu_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.ToolStripStatusLabel lab_Statustext;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.DataGridView dgv_User;
        private System.Windows.Forms.DataGridView dgv_UserRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_UserLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Gender;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
    }
}