namespace XinYa.UI.WorkManagement
{
    partial class frm_ProductionPlanFomERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProductionPlanFomERP));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.btn_Confrim = new System.Windows.Forms.Button();
            this.txt_InfoShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.gb_Show = new System.Windows.Forms.GroupBox();
            this.dgv_Show = new System.Windows.Forms.DataGridView();
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            this.gb_Show.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).BeginInit();
            this.tool_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // split_Main
            // 
            this.split_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Main.Location = new System.Drawing.Point(0, 25);
            this.split_Main.Name = "split_Main";
            this.split_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_Main.Panel1
            // 
            this.split_Main.Panel1.Controls.Add(this.btn_Confrim);
            this.split_Main.Panel1.Controls.Add(this.txt_InfoShow);
            this.split_Main.Panel1.Controls.Add(this.label1);
            this.split_Main.Panel1.Controls.Add(this.btn_Clear);
            this.split_Main.Panel1.Controls.Add(this.btn_Import);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.gb_Show);
            this.split_Main.Size = new System.Drawing.Size(797, 560);
            this.split_Main.SplitterDistance = 93;
            this.split_Main.TabIndex = 1;
            // 
            // btn_Confrim
            // 
            this.btn_Confrim.Location = new System.Drawing.Point(612, 49);
            this.btn_Confrim.Name = "btn_Confrim";
            this.btn_Confrim.Size = new System.Drawing.Size(75, 23);
            this.btn_Confrim.TabIndex = 3;
            this.btn_Confrim.Text = "确认导入";
            this.btn_Confrim.UseVisualStyleBackColor = true;
            this.btn_Confrim.Click += new System.EventHandler(this.btn_Confrim_Click);
            // 
            // txt_InfoShow
            // 
            this.txt_InfoShow.Location = new System.Drawing.Point(101, 16);
            this.txt_InfoShow.Multiline = true;
            this.txt_InfoShow.Name = "txt_InfoShow";
            this.txt_InfoShow.ReadOnly = true;
            this.txt_InfoShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_InfoShow.Size = new System.Drawing.Size(500, 57);
            this.txt_InfoShow.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "导入输出:";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(692, 20);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 0;
            this.btn_Clear.Text = "清空预览";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(611, 20);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(75, 23);
            this.btn_Import.TabIndex = 0;
            this.btn_Import.Text = "选择文件";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // gb_Show
            // 
            this.gb_Show.Controls.Add(this.dgv_Show);
            this.gb_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Show.Location = new System.Drawing.Point(0, 0);
            this.gb_Show.Name = "gb_Show";
            this.gb_Show.Size = new System.Drawing.Size(797, 463);
            this.gb_Show.TabIndex = 0;
            this.gb_Show.TabStop = false;
            this.gb_Show.Text = "预览";
            // 
            // dgv_Show
            // 
            this.dgv_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Show.Location = new System.Drawing.Point(3, 17);
            this.dgv_Show.Name = "dgv_Show";
            this.dgv_Show.ReadOnly = true;
            this.dgv_Show.RowTemplate.Height = 23;
            this.dgv_Show.Size = new System.Drawing.Size(791, 443);
            this.dgv_Show.TabIndex = 0;
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(797, 25);
            this.tool_Main.TabIndex = 12;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "退出";
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
            // frm_ProductionPlanFomERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 585);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_ProductionPlanFomERP";
            this.Text = "ERP数据导入";
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel1.PerformLayout();
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            this.gb_Show.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Show)).EndInit();
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.GroupBox gb_Show;
        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.DataGridView dgv_Show;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.TextBox txt_InfoShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Confrim;
        private System.Windows.Forms.Button btn_Clear;
    }
}