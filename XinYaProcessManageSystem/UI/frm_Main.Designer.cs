namespace XinYaProcessManageSystem
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
            this.conMenu_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool_Resume = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_PLCConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_PLCClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Dock = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_Main = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingPLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于PLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接PLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开PLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingPLCToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.lab_User = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_LoginTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.p_Main = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_test = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_Bottom = new System.Windows.Forms.Panel();
            this.txt_Exception = new System.Windows.Forms.TextBox();
            this.p_Top = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axActQJ71E71TCP1 = new AxACTETHERLib.AxActQJ71E71TCP();
            this.timer_PLC = new System.Windows.Forms.Timer(this.components);
            this.timer_Save = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.conMenu_Main.SuspendLayout();
            this.menu_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            this.p_Main.SuspendLayout();
            this.p_Bottom.SuspendLayout();
            this.p_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActQJ71E71TCP1)).BeginInit();
            this.SuspendLayout();
            // 
            // conMenu_Main
            // 
            this.conMenu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_Resume,
            this.tool_PLCConnect,
            this.tool_PLCClose,
            this.tool_Exit});
            this.conMenu_Main.Name = "conMenu_Main";
            this.conMenu_Main.Size = new System.Drawing.Size(137, 92);
            // 
            // tool_Resume
            // 
            this.tool_Resume.Name = "tool_Resume";
            this.tool_Resume.Size = new System.Drawing.Size(136, 22);
            this.tool_Resume.Text = "恢复主窗体";
            this.tool_Resume.Click += new System.EventHandler(this.tool_Resume_Click);
            // 
            // tool_PLCConnect
            // 
            this.tool_PLCConnect.Name = "tool_PLCConnect";
            this.tool_PLCConnect.Size = new System.Drawing.Size(136, 22);
            this.tool_PLCConnect.Text = "连接PLC";
            this.tool_PLCConnect.Click += new System.EventHandler(this.tool_PLCConnect_Click);
            // 
            // tool_PLCClose
            // 
            this.tool_PLCClose.Name = "tool_PLCClose";
            this.tool_PLCClose.Size = new System.Drawing.Size(136, 22);
            this.tool_PLCClose.Text = "断开PLC";
            this.tool_PLCClose.Click += new System.EventHandler(this.tool_PLCClose_Click);
            // 
            // tool_Exit
            // 
            this.tool_Exit.Name = "tool_Exit";
            this.tool_Exit.Size = new System.Drawing.Size(136, 22);
            this.tool_Exit.Text = "退出";
            this.tool_Exit.Click += new System.EventHandler(this.tool_Exit_Click);
            // 
            // timer_Dock
            // 
            this.timer_Dock.Enabled = true;
            this.timer_Dock.Interval = 500;
            this.timer_Dock.Tick += new System.EventHandler(this.timer_Dock_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.conMenu_Main;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "鑫亚软控";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menu_Main
            // 
            this.menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.关于PLCToolStripMenuItem});
            this.menu_Main.Location = new System.Drawing.Point(0, 0);
            this.menu_Main.Name = "menu_Main";
            this.menu_Main.Size = new System.Drawing.Size(284, 25);
            this.menu_Main.TabIndex = 1;
            this.menu_Main.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.pingPLCToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.关于ToolStripMenuItem.Text = "关于...";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.帮助ToolStripMenuItem.Text = "帮助...";
            // 
            // pingPLCToolStripMenuItem
            // 
            this.pingPLCToolStripMenuItem.Name = "pingPLCToolStripMenuItem";
            this.pingPLCToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.pingPLCToolStripMenuItem.Text = "退出";
            this.pingPLCToolStripMenuItem.Click += new System.EventHandler(this.pingPLCToolStripMenuItem_Click);
            // 
            // 关于PLCToolStripMenuItem
            // 
            this.关于PLCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接PLCToolStripMenuItem,
            this.断开PLCToolStripMenuItem,
            this.pingPLCToolStripMenuItem1});
            this.关于PLCToolStripMenuItem.Name = "关于PLCToolStripMenuItem";
            this.关于PLCToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.关于PLCToolStripMenuItem.Text = "关于PLC";
            // 
            // 连接PLCToolStripMenuItem
            // 
            this.连接PLCToolStripMenuItem.Name = "连接PLCToolStripMenuItem";
            this.连接PLCToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.连接PLCToolStripMenuItem.Text = "连接PLC...";
            this.连接PLCToolStripMenuItem.Click += new System.EventHandler(this.连接PLCToolStripMenuItem_Click);
            // 
            // 断开PLCToolStripMenuItem
            // 
            this.断开PLCToolStripMenuItem.Name = "断开PLCToolStripMenuItem";
            this.断开PLCToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.断开PLCToolStripMenuItem.Text = "断开PLC...";
            this.断开PLCToolStripMenuItem.Click += new System.EventHandler(this.断开PLCToolStripMenuItem_Click);
            // 
            // pingPLCToolStripMenuItem1
            // 
            this.pingPLCToolStripMenuItem1.Name = "pingPLCToolStripMenuItem1";
            this.pingPLCToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.pingPLCToolStripMenuItem1.Text = "Ping PLC...";
            this.pingPLCToolStripMenuItem1.Click += new System.EventHandler(this.pingPLCToolStripMenuItem1_Click);
            // 
            // status_Main
            // 
            this.status_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_User,
            this.lab_LoginTime});
            this.status_Main.Location = new System.Drawing.Point(0, 438);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(284, 22);
            this.status_Main.TabIndex = 2;
            this.status_Main.Text = "statusStrip1";
            // 
            // lab_User
            // 
            this.lab_User.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_User.Name = "lab_User";
            this.lab_User.Size = new System.Drawing.Size(56, 17);
            this.lab_User.Text = "操作员：";
            // 
            // lab_LoginTime
            // 
            this.lab_LoginTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_LoginTime.Name = "lab_LoginTime";
            this.lab_LoginTime.Size = new System.Drawing.Size(68, 17);
            this.lab_LoginTime.Text = "登陆时间：";
            // 
            // p_Main
            // 
            this.p_Main.Controls.Add(this.label5);
            this.p_Main.Controls.Add(this.txt_test);
            this.p_Main.Controls.Add(this.label3);
            this.p_Main.Controls.Add(this.label1);
            this.p_Main.Controls.Add(this.p_Bottom);
            this.p_Main.Controls.Add(this.p_Top);
            this.p_Main.Controls.Add(this.axActQJ71E71TCP1);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 25);
            this.p_Main.Margin = new System.Windows.Forms.Padding(0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(284, 413);
            this.p_Main.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "测试输出";
            // 
            // txt_test
            // 
            this.txt_test.Location = new System.Drawing.Point(12, 99);
            this.txt_test.Multiline = true;
            this.txt_test.Name = "txt_test";
            this.txt_test.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_test.Size = new System.Drawing.Size(260, 62);
            this.txt_test.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "控制台输出：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(32, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // p_Bottom
            // 
            this.p_Bottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p_Bottom.Controls.Add(this.txt_Exception);
            this.p_Bottom.Location = new System.Drawing.Point(12, 179);
            this.p_Bottom.Name = "p_Bottom";
            this.p_Bottom.Size = new System.Drawing.Size(260, 222);
            this.p_Bottom.TabIndex = 2;
            // 
            // txt_Exception
            // 
            this.txt_Exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Exception.ForeColor = System.Drawing.Color.Red;
            this.txt_Exception.Location = new System.Drawing.Point(0, 0);
            this.txt_Exception.Multiline = true;
            this.txt_Exception.Name = "txt_Exception";
            this.txt_Exception.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Exception.Size = new System.Drawing.Size(260, 222);
            this.txt_Exception.TabIndex = 0;
            // 
            // p_Top
            // 
            this.p_Top.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p_Top.Controls.Add(this.label9);
            this.p_Top.Controls.Add(this.label8);
            this.p_Top.Controls.Add(this.label7);
            this.p_Top.Controls.Add(this.label6);
            this.p_Top.Controls.Add(this.label4);
            this.p_Top.Controls.Add(this.label2);
            this.p_Top.Location = new System.Drawing.Point(12, 14);
            this.p_Top.Name = "p_Top";
            this.p_Top.Size = new System.Drawing.Size(260, 67);
            this.p_Top.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "服务处理频率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(101, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // axActQJ71E71TCP1
            // 
            this.axActQJ71E71TCP1.Enabled = true;
            this.axActQJ71E71TCP1.Location = new System.Drawing.Point(0, 0);
            this.axActQJ71E71TCP1.Name = "axActQJ71E71TCP1";
            this.axActQJ71E71TCP1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActQJ71E71TCP1.OcxState")));
            this.axActQJ71E71TCP1.Size = new System.Drawing.Size(0, 0);
            this.axActQJ71E71TCP1.TabIndex = 0;
            // 
            // timer_PLC
            // 
            this.timer_PLC.Tick += new System.EventHandler(this.timer_PLC_Tick);
            // 
            // timer_Save
            // 
            this.timer_Save.Interval = 2000;
            this.timer_Save.Tick += new System.EventHandler(this.timer_Save_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "PLC通讯频率：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "数据读取效率：";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 460);
            this.Controls.Add(this.p_Main);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.menu_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu_Main;
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.Text = "鑫亚PLC主控逻辑";
            this.Deactivate += new System.EventHandler(this.frm_Main_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.conMenu_Main.ResumeLayout(false);
            this.menu_Main.ResumeLayout(false);
            this.menu_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.p_Main.ResumeLayout(false);
            this.p_Main.PerformLayout();
            this.p_Bottom.ResumeLayout(false);
            this.p_Bottom.PerformLayout();
            this.p_Top.ResumeLayout(false);
            this.p_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActQJ71E71TCP1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip conMenu_Main;
        private System.Windows.Forms.ToolStripMenuItem tool_Resume;
        private System.Windows.Forms.ToolStripMenuItem tool_PLCConnect;
        private System.Windows.Forms.ToolStripMenuItem tool_PLCClose;
        private System.Windows.Forms.ToolStripMenuItem tool_Exit;
        private System.Windows.Forms.Timer timer_Dock;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menu_Main;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingPLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于PLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接PLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开PLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingPLCToolStripMenuItem1;
        private System.Windows.Forms.Panel p_Main;
        private AxACTETHERLib.AxActQJ71E71TCP axActQJ71E71TCP1;
        private System.Windows.Forms.Timer timer_PLC;
        private System.Windows.Forms.ToolStripStatusLabel lab_User;
        private System.Windows.Forms.ToolStripStatusLabel lab_LoginTime;
        private System.Windows.Forms.Panel p_Bottom;
        private System.Windows.Forms.Panel p_Top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_Save;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_Exception;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_test;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

