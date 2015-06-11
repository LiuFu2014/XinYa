namespace XinYa.UI.WorkManagement
{
    partial class frm_WorkFlowCenter
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
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lab_Title = new System.Windows.Forms.Label();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_WorkStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_IsUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_IsLast = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前状态：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "不可编辑";
            // 
            // p_Bottom
            // 
            this.p_Bottom.Controls.Add(this.btn_Exit);
            this.p_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_Bottom.Location = new System.Drawing.Point(0, 405);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(867, 35);
            this.p_Bottom.TabIndex = 1;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(12, 6);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lab_Title);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Main);
            this.splitContainer1.Size = new System.Drawing.Size(867, 405);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 2;
            // 
            // lab_Title
            // 
            this.lab_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_Title.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Title.Location = new System.Drawing.Point(0, 0);
            this.lab_Title.Name = "lab_Title";
            this.lab_Title.Size = new System.Drawing.Size(867, 58);
            this.lab_Title.TabIndex = 0;
            this.lab_Title.Text = "工  序  中  心";
            this.lab_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Code,
            this.c_WorkStationName,
            this.c_IsUse,
            this.c_IsLast,
            this.c_Remark});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.Size = new System.Drawing.Size(867, 343);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            // 
            // c_Code
            // 
            this.c_Code.DataPropertyName = "TB_WorkStationInfo.WorkStationCode";
            this.c_Code.HeaderText = "工序编码";
            this.c_Code.Name = "c_Code";
            this.c_Code.ReadOnly = true;
            // 
            // c_WorkStationName
            // 
            this.c_WorkStationName.DataPropertyName = "TB_WorkStationInfo.WorkStationName";
            this.c_WorkStationName.HeaderText = "工序名";
            this.c_WorkStationName.Name = "c_WorkStationName";
            this.c_WorkStationName.ReadOnly = true;
            // 
            // c_IsUse
            // 
            this.c_IsUse.DataPropertyName = "IsUse";
            this.c_IsUse.FalseValue = "false";
            this.c_IsUse.HeaderText = "是否启用";
            this.c_IsUse.Name = "c_IsUse";
            this.c_IsUse.ReadOnly = true;
            this.c_IsUse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_IsUse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_IsUse.TrueValue = "true";
            // 
            // c_IsLast
            // 
            this.c_IsLast.DataPropertyName = "IsLast";
            this.c_IsLast.FalseValue = "false";
            this.c_IsLast.HeaderText = "是否最后";
            this.c_IsLast.Name = "c_IsLast";
            this.c_IsLast.ReadOnly = true;
            this.c_IsLast.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_IsLast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_IsLast.TrueValue = "true";
            // 
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            this.c_Remark.ReadOnly = true;
            // 
            // frm_WorkFlowCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(867, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.p_Bottom);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frm_WorkFlowCenter";
            this.Text = "工序中心";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label lab_Title;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_WorkStationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsUse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
    }
}