namespace XinYa.UI.WorkStation
{
    partial class frm_WorkStationView
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
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.p_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_SecondWorkStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MainCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_IsUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.p_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_StatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lab_Status
            // 
            this.lab_Status.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(68, 17);
            this.lab_Status.Text = "当前状态：";
            // 
            // lab_StatusText
            // 
            this.lab_StatusText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_StatusText.Name = "lab_StatusText";
            this.lab_StatusText.Size = new System.Drawing.Size(32, 17);
            this.lab_StatusText.Text = "就绪";
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.dgv_Main);
            this.p_Main.Controls.Add(this.p_Title);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(854, 429);
            this.p_Main.TabIndex = 12;
            // 
            // dgv_Main
            // 
            this.dgv_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_SecondWorkStationName,
            this.c_No,
            this.c_Code,
            this.c_MainCode,
            this.c_IsUse,
            this.c_Remark});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 68);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.Size = new System.Drawing.Size(854, 361);
            this.dgv_Main.TabIndex = 1;
            // 
            // p_Title
            // 
            this.p_Title.Controls.Add(this.label1);
            this.p_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Title.Location = new System.Drawing.Point(0, 0);
            this.p_Title.Name = "p_Title";
            this.p_Title.Size = new System.Drawing.Size(854, 68);
            this.p_Title.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(854, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "工   位   信   息   总   览";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            // 
            // c_SecondWorkStationName
            // 
            this.c_SecondWorkStationName.DataPropertyName = "SecondWorkStationName";
            this.c_SecondWorkStationName.HeaderText = "工位名";
            this.c_SecondWorkStationName.Name = "c_SecondWorkStationName";
            this.c_SecondWorkStationName.ReadOnly = true;
            // 
            // c_No
            // 
            this.c_No.DataPropertyName = "No";
            this.c_No.HeaderText = "序号";
            this.c_No.Name = "c_No";
            this.c_No.ReadOnly = true;
            // 
            // c_Code
            // 
            this.c_Code.DataPropertyName = "SecondWorkStationCode";
            this.c_Code.HeaderText = "工位编码";
            this.c_Code.Name = "c_Code";
            this.c_Code.ReadOnly = true;
            // 
            // c_MainCode
            // 
            this.c_MainCode.DataPropertyName = "WorkStationCode";
            this.c_MainCode.HeaderText = "工序编码";
            this.c_MainCode.Name = "c_MainCode";
            this.c_MainCode.ReadOnly = true;
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
            // c_Remark
            // 
            this.c_Remark.DataPropertyName = "Remark";
            this.c_Remark.HeaderText = "备注";
            this.c_Remark.Name = "c_Remark";
            // 
            // frm_WorkStationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 451);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frm_WorkStationView";
            this.Text = "工位信息浏览";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.p_Title.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.ToolStripStatusLabel lab_StatusText;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.Panel p_Title;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_SecondWorkStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MainCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_IsUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Remark;
    }
}