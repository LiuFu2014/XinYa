namespace XinYa.UI.WorkManagement
{
    partial class frm_LEDTestSender
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_LEDBaowen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_LEDTextNow = new System.Windows.Forms.TextBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Refresh);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btn_Clear);
            this.groupBox4.Controls.Add(this.btn_Send);
            this.groupBox4.Controls.Add(this.txt_LEDTextNow);
            this.groupBox4.Controls.Add(this.txt_LEDBaowen);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(739, 317);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LED报文发送";
            // 
            // btn_Clear
            // 
            this.btn_Clear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Clear.Location = new System.Drawing.Point(634, 269);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_Send.Location = new System.Drawing.Point(553, 269);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_LEDBaowen
            // 
            this.txt_LEDBaowen.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_LEDBaowen.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LEDBaowen.ForeColor = System.Drawing.Color.Red;
            this.txt_LEDBaowen.Location = new System.Drawing.Point(6, 186);
            this.txt_LEDBaowen.Multiline = true;
            this.txt_LEDBaowen.Name = "txt_LEDBaowen";
            this.txt_LEDBaowen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_LEDBaowen.Size = new System.Drawing.Size(705, 77);
            this.txt_LEDBaowen.TabIndex = 0;
            this.txt_LEDBaowen.Text = "要发送请修改本文档并点击发送.清空后LED通知栏自动清空.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(7, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "待发送报文：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "LED当前显示报文：";
            // 
            // txt_LEDTextNow
            // 
            this.txt_LEDTextNow.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_LEDTextNow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LEDTextNow.ForeColor = System.Drawing.Color.Red;
            this.txt_LEDTextNow.Location = new System.Drawing.Point(6, 36);
            this.txt_LEDTextNow.Multiline = true;
            this.txt_LEDTextNow.Name = "txt_LEDTextNow";
            this.txt_LEDTextNow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_LEDTextNow.Size = new System.Drawing.Size(705, 77);
            this.txt_LEDTextNow.TabIndex = 0;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(633, 120);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 5;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // frm_LEDTestSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 317);
            this.Controls.Add(this.groupBox4);
            this.Name = "frm_LEDTestSender";
            this.Text = "LED通知报文发送";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_LEDBaowen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_LEDTextNow;
        private System.Windows.Forms.Button btn_Refresh;

    }
}