namespace XinYaBarCodePrinter
{
    partial class frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_CurrentWorkStation = new System.Windows.Forms.ToolStripStatusLabel();
            this.split_Main = new System.Windows.Forms.SplitContainer();
            this.lab_StatusOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_View = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_LoginTime = new System.Windows.Forms.Label();
            this.lab_WorkNum = new System.Windows.Forms.Label();
            this.lab_WorkerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Comfirm = new System.Windows.Forms.Button();
            this.txt_BarCodeString = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).BeginInit();
            this.split_Main.Panel1.SuspendLayout();
            this.split_Main.Panel2.SuspendLayout();
            this.split_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.tool_Main.Size = new System.Drawing.Size(1272, 25);
            this.tool_Main.TabIndex = 11;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 22);
            this.btn_Cancel.Text = "取消退出";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
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
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lab_CurrentWorkStation});
            this.status_Main.Location = new System.Drawing.Point(0, 720);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(1272, 22);
            this.status_Main.TabIndex = 12;
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
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "当前工位：";
            // 
            // lab_CurrentWorkStation
            // 
            this.lab_CurrentWorkStation.ForeColor = System.Drawing.SystemColors.Control;
            this.lab_CurrentWorkStation.Name = "lab_CurrentWorkStation";
            this.lab_CurrentWorkStation.Size = new System.Drawing.Size(56, 17);
            this.lab_CurrentWorkStation.Text = "当前工位";
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
            this.split_Main.Panel1.Controls.Add(this.lab_StatusOutput);
            this.split_Main.Panel1.Controls.Add(this.label4);
            this.split_Main.Panel1.Controls.Add(this.btn_View);
            this.split_Main.Panel1.Controls.Add(this.pictureBox1);
            this.split_Main.Panel1.Controls.Add(this.label3);
            this.split_Main.Panel1.Controls.Add(this.lab_LoginTime);
            this.split_Main.Panel1.Controls.Add(this.lab_WorkNum);
            this.split_Main.Panel1.Controls.Add(this.lab_WorkerName);
            this.split_Main.Panel1.Controls.Add(this.label2);
            this.split_Main.Panel1.Controls.Add(this.btn_Exit);
            this.split_Main.Panel1.Controls.Add(this.btn_Clear);
            this.split_Main.Panel1.Controls.Add(this.label1);
            this.split_Main.Panel1.Controls.Add(this.btn_Comfirm);
            this.split_Main.Panel1.Controls.Add(this.txt_BarCodeString);
            // 
            // split_Main.Panel2
            // 
            this.split_Main.Panel2.Controls.Add(this.reportViewer1);
            this.split_Main.Size = new System.Drawing.Size(1272, 695);
            this.split_Main.SplitterDistance = 284;
            this.split_Main.TabIndex = 13;
            // 
            // lab_StatusOutput
            // 
            this.lab_StatusOutput.AutoSize = true;
            this.lab_StatusOutput.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_StatusOutput.ForeColor = System.Drawing.Color.Red;
            this.lab_StatusOutput.Location = new System.Drawing.Point(176, 210);
            this.lab_StatusOutput.Name = "lab_StatusOutput";
            this.lab_StatusOutput.Size = new System.Drawing.Size(88, 16);
            this.lab_StatusOutput.TabIndex = 15;
            this.lab_StatusOutput.Text = "状态输出。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(112, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "输出：";
            // 
            // btn_View
            // 
            this.btn_View.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_View.Location = new System.Drawing.Point(796, 129);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(75, 61);
            this.btn_View.TabIndex = 13;
            this.btn_View.Text = "预览";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(49, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(616, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "如果有提示框信息，请在打印前比对一下文本框中的条码数据与实际产生的条码数据。";
            // 
            // lab_LoginTime
            // 
            this.lab_LoginTime.AutoSize = true;
            this.lab_LoginTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_LoginTime.Location = new System.Drawing.Point(774, 80);
            this.lab_LoginTime.Name = "lab_LoginTime";
            this.lab_LoginTime.Size = new System.Drawing.Size(46, 21);
            this.lab_LoginTime.TabIndex = 10;
            this.lab_LoginTime.Text = "时间:";
            // 
            // lab_WorkNum
            // 
            this.lab_WorkNum.AutoSize = true;
            this.lab_WorkNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_WorkNum.Location = new System.Drawing.Point(594, 80);
            this.lab_WorkNum.Name = "lab_WorkNum";
            this.lab_WorkNum.Size = new System.Drawing.Size(46, 21);
            this.lab_WorkNum.TabIndex = 9;
            this.lab_WorkNum.Text = "工号:";
            // 
            // lab_WorkerName
            // 
            this.lab_WorkerName.AutoSize = true;
            this.lab_WorkerName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_WorkerName.Location = new System.Drawing.Point(383, 80);
            this.lab_WorkerName.Name = "lab_WorkerName";
            this.lab_WorkerName.Size = new System.Drawing.Size(78, 21);
            this.lab_WorkerName.TabIndex = 8;
            this.lab_WorkerName.Text = "登录员工:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(380, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 42);
            this.label2.TabIndex = 7;
            this.label2.Text = "鑫  亚  软  控-条  码  打  印  系  统";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Chocolate;
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.Location = new System.Drawing.Point(1107, 129);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 61);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "退出系统";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clear.Location = new System.Drawing.Point(1001, 129);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(100, 61);
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "清空文本";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码数据：";
            // 
            // btn_Comfirm
            // 
            this.btn_Comfirm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Comfirm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Comfirm.Location = new System.Drawing.Point(877, 129);
            this.btn_Comfirm.Name = "btn_Comfirm";
            this.btn_Comfirm.Size = new System.Drawing.Size(118, 61);
            this.btn_Comfirm.TabIndex = 2;
            this.btn_Comfirm.Text = "确认打印\r\n(回车)";
            this.btn_Comfirm.UseVisualStyleBackColor = false;
            this.btn_Comfirm.Click += new System.EventHandler(this.btn_Comfirm_Click);
            // 
            // txt_BarCodeString
            // 
            this.txt_BarCodeString.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BarCodeString.Location = new System.Drawing.Point(246, 151);
            this.txt_BarCodeString.Name = "txt_BarCodeString";
            this.txt_BarCodeString.Size = new System.Drawing.Size(544, 39);
            this.txt_BarCodeString.TabIndex = 1;
            this.txt_BarCodeString.TextChanged += new System.EventHandler(this.txt_BarCodeString_TextChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "XinYaBarCodePrinter.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1272, 407);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 742);
            this.Controls.Add(this.split_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Main";
            this.Text = "鑫亚打码系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Main_KeyDown);
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.split_Main.Panel1.ResumeLayout(false);
            this.split_Main.Panel1.PerformLayout();
            this.split_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Main)).EndInit();
            this.split_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer split_Main;
        private System.Windows.Forms.TextBox txt_BarCodeString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Comfirm;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_WorkNum;
        private System.Windows.Forms.Label lab_WorkerName;
        private System.Windows.Forms.Label lab_LoginTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lab_CurrentWorkStation;
        private System.Windows.Forms.Label lab_StatusOutput;
        private System.Windows.Forms.Label label4;
    }
}

