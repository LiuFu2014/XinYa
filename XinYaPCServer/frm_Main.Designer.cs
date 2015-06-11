namespace XinYaPCServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.btn_OpenPCServer = new System.Windows.Forms.Button();
            this.btn_ClosePCServer = new System.Windows.Forms.Button();
            this.lab_PCServerStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gb_PCServer = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gb_WCFServer = new System.Windows.Forms.GroupBox();
            this.btn_CloseWCFServer = new System.Windows.Forms.Button();
            this.btn_OpenWCFServer = new System.Windows.Forms.Button();
            this.lab_WCFServerStatus = new System.Windows.Forms.Label();
            this.gb_PCServer.SuspendLayout();
            this.gb_WCFServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OpenPCServer
            // 
            this.btn_OpenPCServer.Location = new System.Drawing.Point(42, 20);
            this.btn_OpenPCServer.Name = "btn_OpenPCServer";
            this.btn_OpenPCServer.Size = new System.Drawing.Size(138, 61);
            this.btn_OpenPCServer.TabIndex = 0;
            this.btn_OpenPCServer.Text = "开启PC端服务";
            this.btn_OpenPCServer.UseVisualStyleBackColor = true;
            this.btn_OpenPCServer.Click += new System.EventHandler(this.btn_OpenPCServer_Click);
            // 
            // btn_ClosePCServer
            // 
            this.btn_ClosePCServer.Location = new System.Drawing.Point(216, 20);
            this.btn_ClosePCServer.Name = "btn_ClosePCServer";
            this.btn_ClosePCServer.Size = new System.Drawing.Size(138, 61);
            this.btn_ClosePCServer.TabIndex = 1;
            this.btn_ClosePCServer.Text = "关闭PC端服务";
            this.btn_ClosePCServer.UseVisualStyleBackColor = true;
            this.btn_ClosePCServer.Click += new System.EventHandler(this.btn_ClosePCServer_Click);
            // 
            // lab_PCServerStatus
            // 
            this.lab_PCServerStatus.AutoSize = true;
            this.lab_PCServerStatus.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_PCServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lab_PCServerStatus.Location = new System.Drawing.Point(38, 99);
            this.lab_PCServerStatus.Name = "lab_PCServerStatus";
            this.lab_PCServerStatus.Size = new System.Drawing.Size(47, 19);
            this.lab_PCServerStatus.TabIndex = 2;
            this.lab_PCServerStatus.Text = "状态";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gb_PCServer
            // 
            this.gb_PCServer.BackColor = System.Drawing.SystemColors.Control;
            this.gb_PCServer.Controls.Add(this.btn_OpenPCServer);
            this.gb_PCServer.Controls.Add(this.btn_ClosePCServer);
            this.gb_PCServer.Controls.Add(this.lab_PCServerStatus);
            this.gb_PCServer.Location = new System.Drawing.Point(12, 12);
            this.gb_PCServer.Name = "gb_PCServer";
            this.gb_PCServer.Size = new System.Drawing.Size(394, 186);
            this.gb_PCServer.TabIndex = 3;
            this.gb_PCServer.TabStop = false;
            this.gb_PCServer.Text = "PC端服务支持";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(418, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gb_WCFServer
            // 
            this.gb_WCFServer.Controls.Add(this.btn_CloseWCFServer);
            this.gb_WCFServer.Controls.Add(this.btn_OpenWCFServer);
            this.gb_WCFServer.Controls.Add(this.lab_WCFServerStatus);
            this.gb_WCFServer.Location = new System.Drawing.Point(13, 205);
            this.gb_WCFServer.Name = "gb_WCFServer";
            this.gb_WCFServer.Size = new System.Drawing.Size(393, 176);
            this.gb_WCFServer.TabIndex = 5;
            this.gb_WCFServer.TabStop = false;
            this.gb_WCFServer.Text = "WCF远程服务";
            // 
            // btn_CloseWCFServer
            // 
            this.btn_CloseWCFServer.Location = new System.Drawing.Point(215, 21);
            this.btn_CloseWCFServer.Name = "btn_CloseWCFServer";
            this.btn_CloseWCFServer.Size = new System.Drawing.Size(138, 61);
            this.btn_CloseWCFServer.TabIndex = 1;
            this.btn_CloseWCFServer.Text = "关闭WCF远程服务支持";
            this.btn_CloseWCFServer.UseVisualStyleBackColor = true;
            this.btn_CloseWCFServer.Click += new System.EventHandler(this.btn_CloseWCFServer_Click);
            // 
            // btn_OpenWCFServer
            // 
            this.btn_OpenWCFServer.Location = new System.Drawing.Point(41, 21);
            this.btn_OpenWCFServer.Name = "btn_OpenWCFServer";
            this.btn_OpenWCFServer.Size = new System.Drawing.Size(138, 61);
            this.btn_OpenWCFServer.TabIndex = 0;
            this.btn_OpenWCFServer.Text = "开启WCF远程服务支持";
            this.btn_OpenWCFServer.UseVisualStyleBackColor = true;
            this.btn_OpenWCFServer.Click += new System.EventHandler(this.btn_OpenWCFServer_Click);
            // 
            // lab_WCFServerStatus
            // 
            this.lab_WCFServerStatus.AutoSize = true;
            this.lab_WCFServerStatus.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_WCFServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lab_WCFServerStatus.Location = new System.Drawing.Point(37, 98);
            this.lab_WCFServerStatus.Name = "lab_WCFServerStatus";
            this.lab_WCFServerStatus.Size = new System.Drawing.Size(47, 19);
            this.lab_WCFServerStatus.TabIndex = 2;
            this.lab_WCFServerStatus.Text = "状态";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 406);
            this.Controls.Add(this.gb_WCFServer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_PCServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.Text = "远程服务程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gb_PCServer.ResumeLayout(false);
            this.gb_PCServer.PerformLayout();
            this.gb_WCFServer.ResumeLayout(false);
            this.gb_WCFServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenPCServer;
        private System.Windows.Forms.Button btn_ClosePCServer;
        private System.Windows.Forms.Label lab_PCServerStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gb_PCServer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox gb_WCFServer;
        private System.Windows.Forms.Button btn_CloseWCFServer;
        private System.Windows.Forms.Button btn_OpenWCFServer;
        private System.Windows.Forms.Label lab_WCFServerStatus;
    }
}

