namespace XinYaECS
{
    partial class user_Label
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_Main = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_Main
            // 
            this.lab_Main.BackColor = System.Drawing.Color.Silver;
            this.lab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_Main.Location = new System.Drawing.Point(0, 0);
            this.lab_Main.Margin = new System.Windows.Forms.Padding(0);
            this.lab_Main.Name = "lab_Main";
            this.lab_Main.Size = new System.Drawing.Size(150, 150);
            this.lab_Main.TabIndex = 0;
            this.lab_Main.Text = "NoData";
            this.lab_Main.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lab_Main.Click += new System.EventHandler(this.lab_Main_Click);
            // 
            // user_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "user_Label";
            this.Click += new System.EventHandler(this.user_Label_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_Main;
    }
}
