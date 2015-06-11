namespace DataImpExp
{
    partial class frmProgressDataToExcel
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
            this.components = new System.ComponentModel.Container();
            this.prgMain = new System.Windows.Forms.ProgressBar();
            this.lblState = new System.Windows.Forms.Label();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.trmMain = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prgMain
            // 
            this.prgMain.Location = new System.Drawing.Point(8, 39);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(609, 23);
            this.prgMain.TabIndex = 0;
            // 
            // lblState
            // 
            this.lblState.ForeColor = System.Drawing.Color.Blue;
            this.lblState.Location = new System.Drawing.Point(8, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(605, 23);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "稍候...";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "xls";
            this.dlgSave.Filter = "(*.xls)|*.xls";
            this.dlgSave.Title = "导出Excel...";
            // 
            // trmMain
            // 
            this.trmMain.Interval = 200;
            this.trmMain.Tick += new System.EventHandler(this.trmMain_Tick);
            // 
            // frmProgressDataToExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 79);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.prgMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgressDataToExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导出EXCEL";
            this.Load += new System.EventHandler(this.frmProgressDataToExcel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgMain;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.Timer trmMain;
    }
}