namespace XinYa.UI.InfoSearch
{
    partial class frm_ExceptionSelectHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExceptionSelectHelper));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Confirm = new System.Windows.Forms.ToolStripButton();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_ExceptionCode = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Serlike = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_ExceptionInfo = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_ExceptionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ExceptionDtl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Confirm,
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txt_ExceptionCode,
            this.btn_Serlike,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(541, 25);
            this.tool_Main.TabIndex = 12;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(36, 22);
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "取消";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "异常代码：";
            // 
            // txt_ExceptionCode
            // 
            this.txt_ExceptionCode.Name = "txt_ExceptionCode";
            this.txt_ExceptionCode.Size = new System.Drawing.Size(100, 25);
            // 
            // btn_Serlike
            // 
            this.btn_Serlike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Serlike.Image = ((System.Drawing.Image)(resources.GetObject("btn_Serlike.Image")));
            this.btn_Serlike.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Serlike.Name = "btn_Serlike";
            this.btn_Serlike.Size = new System.Drawing.Size(60, 22);
            this.btn_Serlike.Text = "模糊查询";
            this.btn_Serlike.Click += new System.EventHandler(this.btn_Serlike_Click);
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
            this.status_Main.Location = new System.Drawing.Point(0, 472);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(541, 22);
            this.status_Main.TabIndex = 13;
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
            // dgv_ExceptionInfo
            // 
            this.dgv_ExceptionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExceptionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_Select,
            this.c_ExceptionCode,
            this.c_ExceptionDtl,
            this.c_Creator,
            this.c_CreateDate,
            this.c_Remark});
            this.dgv_ExceptionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ExceptionInfo.Location = new System.Drawing.Point(0, 25);
            this.dgv_ExceptionInfo.Name = "dgv_ExceptionInfo";
            this.dgv_ExceptionInfo.RowTemplate.Height = 23;
            this.dgv_ExceptionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ExceptionInfo.Size = new System.Drawing.Size(541, 447);
            this.dgv_ExceptionInfo.TabIndex = 14;
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.Visible = false;
            // 
            // c_Select
            // 
            this.c_Select.FalseValue = "false";
            this.c_Select.HeaderText = "选择";
            this.c_Select.IndeterminateValue = "false";
            this.c_Select.Name = "c_Select";
            this.c_Select.TrueValue = "true";
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
            // frm_ExceptionSelectHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 494);
            this.Controls.Add(this.dgv_ExceptionInfo);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_ExceptionSelectHelper";
            this.Text = "异常选择助手";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dgv_ExceptionInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_ExceptionCode;
        private System.Windows.Forms.ToolStripButton btn_Serlike;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionDtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
    }
}