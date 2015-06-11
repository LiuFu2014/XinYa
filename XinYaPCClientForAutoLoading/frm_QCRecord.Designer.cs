namespace XinYaPCClientForAutoLoading
{
    partial class frm_QCRecord
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
            this.sta_Main = new System.Windows.Forms.StatusStrip();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // sta_Main
            // 
            this.sta_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.sta_Main.Location = new System.Drawing.Point(0, 455);
            this.sta_Main.Name = "sta_Main";
            this.sta_Main.Size = new System.Drawing.Size(716, 22);
            this.sta_Main.TabIndex = 2;
            this.sta_Main.Text = "statusStrip1";
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(716, 455);
            this.tlp_Main.TabIndex = 3;
            // 
            // frm_QCRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 477);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.sta_Main);
            this.Name = "frm_QCRecord";
            this.Text = "frm_QCRecord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sta_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
    }
}