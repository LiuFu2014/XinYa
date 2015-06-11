namespace XinYaPCClientForAutoLoading
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SelectLike = new System.Windows.Forms.Button();
            this.txt_ExceptionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Comfirm = new System.Windows.Forms.Button();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(700, 25);
            this.tool_Main.TabIndex = 12;
            this.tool_Main.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.status_Main.Location = new System.Drawing.Point(0, 551);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(700, 22);
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
            this.dgv_ExceptionInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ExceptionInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_ExceptionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExceptionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_Select,
            this.c_ExceptionCode,
            this.c_ExceptionDtl,
            this.c_Remark});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExceptionInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ExceptionInfo.Location = new System.Drawing.Point(0, 25);
            this.dgv_ExceptionInfo.Name = "dgv_ExceptionInfo";
            this.dgv_ExceptionInfo.RowTemplate.Height = 23;
            this.dgv_ExceptionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ExceptionInfo.Size = new System.Drawing.Size(700, 440);
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
            this.c_Select.Visible = false;
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
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SelectLike);
            this.panel1.Controls.Add(this.txt_ExceptionCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Comfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 80);
            this.panel1.TabIndex = 15;
            // 
            // btn_SelectLike
            // 
            this.btn_SelectLike.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectLike.Location = new System.Drawing.Point(287, 14);
            this.btn_SelectLike.Name = "btn_SelectLike";
            this.btn_SelectLike.Size = new System.Drawing.Size(88, 48);
            this.btn_SelectLike.TabIndex = 4;
            this.btn_SelectLike.Text = "模糊查询";
            this.btn_SelectLike.UseVisualStyleBackColor = true;
            this.btn_SelectLike.Click += new System.EventHandler(this.btn_SelectLike_Click);
            // 
            // txt_ExceptionCode
            // 
            this.txt_ExceptionCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ExceptionCode.Location = new System.Drawing.Point(45, 33);
            this.txt_ExceptionCode.Name = "txt_ExceptionCode";
            this.txt_ExceptionCode.Size = new System.Drawing.Size(222, 29);
            this.txt_ExceptionCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "异常代码：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(572, 14);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(93, 48);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Comfirm
            // 
            this.btn_Comfirm.BackColor = System.Drawing.Color.Moccasin;
            this.btn_Comfirm.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Comfirm.Location = new System.Drawing.Point(465, 14);
            this.btn_Comfirm.Name = "btn_Comfirm";
            this.btn_Comfirm.Size = new System.Drawing.Size(88, 48);
            this.btn_Comfirm.TabIndex = 0;
            this.btn_Comfirm.Text = "确认";
            this.btn_Comfirm.UseVisualStyleBackColor = false;
            this.btn_Comfirm.Click += new System.EventHandler(this.btn_Comfirm_Click);
            // 
            // frm_ExceptionSelectHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_ExceptionInfo);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ExceptionSelectHelper";
            this.Text = "异常选择助手";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExceptionInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dgv_ExceptionInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Comfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ExceptionCode;
        private System.Windows.Forms.Button btn_SelectLike;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ExceptionDtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
    }
}