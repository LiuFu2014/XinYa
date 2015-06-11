namespace XinYaECS
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.p_Main = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_Part = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.pb_UserLogo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.p_Main.SuspendLayout();
            this.p_Part.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Main
            // 
            this.p_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(126)))), ((int)(((byte)(71)))), ((int)(((byte)(177)))));
            this.p_Main.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_Main.BackgroundImage")));
            this.p_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_Main.Controls.Add(this.label4);
            this.p_Main.Controls.Add(this.label1);
            this.p_Main.Controls.Add(this.p_Part);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(824, 450);
            this.p_Main.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(272, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Designed By LiuFu SunEast-版权所有";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 76);
            this.label1.TabIndex = 8;
            this.label1.Text = "山东鑫亚-调试输送线软控系统 V1.0\r\n                    ——ECS监控系统V1.0";
            // 
            // p_Part
            // 
            this.p_Part.Controls.Add(this.txt_Password);
            this.p_Part.Controls.Add(this.txt_UserID);
            this.p_Part.Controls.Add(this.pb_UserLogo);
            this.p_Part.Controls.Add(this.label2);
            this.p_Part.Controls.Add(this.btnNo);
            this.p_Part.Controls.Add(this.label3);
            this.p_Part.Controls.Add(this.btnYes);
            this.p_Part.Location = new System.Drawing.Point(216, 180);
            this.p_Part.Name = "p_Part";
            this.p_Part.Size = new System.Drawing.Size(416, 172);
            this.p_Part.TabIndex = 7;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(233, 59);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(143, 21);
            this.txt_Password.TabIndex = 7;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_UserID
            // 
            this.txt_UserID.Location = new System.Drawing.Point(233, 28);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Size = new System.Drawing.Size(143, 21);
            this.txt_UserID.TabIndex = 7;
            // 
            // pb_UserLogo
            // 
            this.pb_UserLogo.BackColor = System.Drawing.Color.Transparent;
            this.pb_UserLogo.Image = ((System.Drawing.Image)(resources.GetObject("pb_UserLogo.Image")));
            this.pb_UserLogo.Location = new System.Drawing.Point(21, 29);
            this.pb_UserLogo.Name = "pb_UserLogo";
            this.pb_UserLogo.Size = new System.Drawing.Size(101, 95);
            this.pb_UserLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_UserLogo.TabIndex = 6;
            this.pb_UserLogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(158, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户工号：";
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNo.ForeColor = System.Drawing.SystemColors.Info;
            this.btnNo.Location = new System.Drawing.Point(276, 104);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 34);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "退  出(&C)";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(158, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录密码：";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(104)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYes.ForeColor = System.Drawing.Color.Lime;
            this.btnYes.Location = new System.Drawing.Point(161, 104);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 34);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "登  录(&S)";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.p_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.p_Main.ResumeLayout(false);
            this.p_Main.PerformLayout();
            this.p_Part.ResumeLayout(false);
            this.p_Part.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_UserLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel p_Part;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.PictureBox pb_UserLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label4;
    }
}