namespace XinYaBarCodeForAppointedFactory
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Mini = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.txt_BarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb_Preview = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Settings);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Mini);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Preview);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Print);
            this.splitContainer1.Panel1.Controls.Add(this.txt_BarCode);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(703, 394);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Settings
            // 
            this.btn_Settings.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Settings.Location = new System.Drawing.Point(575, 103);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(114, 62);
            this.btn_Settings.TabIndex = 4;
            this.btn_Settings.Text = "打印配置";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Mini
            // 
            this.btn_Mini.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Mini.Location = new System.Drawing.Point(441, 103);
            this.btn_Mini.Name = "btn_Mini";
            this.btn_Mini.Size = new System.Drawing.Size(127, 62);
            this.btn_Mini.TabIndex = 3;
            this.btn_Mini.Text = "最小化";
            this.btn_Mini.UseVisualStyleBackColor = true;
            this.btn_Mini.Click += new System.EventHandler(this.btn_Mini_Click);
            // 
            // btn_Preview
            // 
            this.btn_Preview.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Preview.Location = new System.Drawing.Point(308, 103);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(127, 62);
            this.btn_Preview.TabIndex = 3;
            this.btn_Preview.Text = "预览";
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Print.Location = new System.Drawing.Point(171, 103);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(131, 62);
            this.btn_Print.TabIndex = 2;
            this.btn_Print.Text = "打印(回车)";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // txt_BarCode
            // 
            this.txt_BarCode.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BarCode.Location = new System.Drawing.Point(32, 52);
            this.txt_BarCode.Name = "txt_BarCode";
            this.txt_BarCode.Size = new System.Drawing.Size(660, 35);
            this.txt_BarCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫描条码：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_Preview);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // pb_Preview
            // 
            this.pb_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Preview.Location = new System.Drawing.Point(3, 17);
            this.pb_Preview.Name = "pb_Preview";
            this.pb_Preview.Size = new System.Drawing.Size(673, 181);
            this.pb_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Preview.TabIndex = 0;
            this.pb_Preview.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 394);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Main";
            this.Text = "鑫亚条码打印与转换程序";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Main_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.TextBox txt_BarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pb_Preview;
        private System.Windows.Forms.Button btn_Mini;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btn_Settings;
    }
}