namespace XinYa.BLL
{
    partial class frm_MaterialSelectHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MaterialSelectHelper));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Confirm = new System.Windows.Forms.ToolStripButton();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_MaterialCode = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Ser = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_MatSelect = new System.Windows.Forms.DataGridView();
            this.c_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Dinghuobianhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Peitaochuangjia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Zhusai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Chuyoufa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Yuxingcheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Mohehouzhuangbenggai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Shiyantaitiaoshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Zhuanghuiyoudiancifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Zhuangfujian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQMohehouzhuanggaiban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQShuyoubeng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQShuyoubengzhijia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQZhuanghougaiban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQTingchelaxianzhijia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_BQShigaoyajinzuohumao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Confirm,
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txt_MaterialCode,
            this.btn_Ser,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(482, 25);
            this.tool_Main.TabIndex = 11;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("btn_Confirm.Image")));
            this.btn_Confirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(36, 22);
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "编号:";
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(100, 25);
            this.txt_MaterialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaterialCode_KeyPress);
            // 
            // btn_Ser
            // 
            this.btn_Ser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Ser.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ser.Image")));
            this.btn_Ser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(60, 22);
            this.btn_Ser.Text = "模糊查询";
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // lab_Status
            // 
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(68, 22);
            this.lab_Status.Text = "正在处理：";
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
            this.toolStripStatusLabel2});
            this.status_Main.Location = new System.Drawing.Point(0, 446);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(482, 22);
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
            // dgv_MatSelect
            // 
            this.dgv_MatSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MatSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Select,
            this.c_TypeCode,
            this.c_MaterialName,
            this.c_Dinghuobianhao,
            this.c_Peitaochuangjia,
            this.c_Creator,
            this.c_CreateDate,
            this.c_Zhusai,
            this.c_Chuyoufa,
            this.c_Yuxingcheng,
            this.c_Mohehouzhuangbenggai,
            this.c_Shiyantaitiaoshi,
            this.c_Zhuanghuiyoudiancifa,
            this.c_Zhuangfujian,
            this.c_BQMohehouzhuanggaiban,
            this.c_BQShuyoubeng,
            this.c_BQShuyoubengzhijia,
            this.c_BQZhuanghougaiban,
            this.c_BQTingchelaxianzhijia,
            this.c_BQShigaoyajinzuohumao,
            this.c_Class});
            this.dgv_MatSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MatSelect.Location = new System.Drawing.Point(0, 25);
            this.dgv_MatSelect.Name = "dgv_MatSelect";
            this.dgv_MatSelect.RowTemplate.Height = 23;
            this.dgv_MatSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MatSelect.Size = new System.Drawing.Size(482, 421);
            this.dgv_MatSelect.TabIndex = 13;
            // 
            // c_Select
            // 
            this.c_Select.FalseValue = "false";
            this.c_Select.HeaderText = "选择";
            this.c_Select.IndeterminateValue = "false";
            this.c_Select.Name = "c_Select";
            this.c_Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_Select.TrueValue = "true";
            // 
            // c_TypeCode
            // 
            this.c_TypeCode.DataPropertyName = "TypeCode";
            this.c_TypeCode.HeaderText = "产品编码（型号）";
            this.c_TypeCode.Name = "c_TypeCode";
            this.c_TypeCode.ReadOnly = true;
            // 
            // c_MaterialName
            // 
            this.c_MaterialName.DataPropertyName = "MaterialName";
            this.c_MaterialName.HeaderText = "产品名称";
            this.c_MaterialName.Name = "c_MaterialName";
            this.c_MaterialName.ReadOnly = true;
            // 
            // c_Dinghuobianhao
            // 
            this.c_Dinghuobianhao.DataPropertyName = "Dinghuobianhao";
            this.c_Dinghuobianhao.HeaderText = "订货编号";
            this.c_Dinghuobianhao.Name = "c_Dinghuobianhao";
            this.c_Dinghuobianhao.ReadOnly = true;
            // 
            // c_Peitaochuangjia
            // 
            this.c_Peitaochuangjia.DataPropertyName = "Peitaochuangjia";
            this.c_Peitaochuangjia.HeaderText = "配套厂家";
            this.c_Peitaochuangjia.Name = "c_Peitaochuangjia";
            this.c_Peitaochuangjia.ReadOnly = true;
            // 
            // c_Creator
            // 
            this.c_Creator.DataPropertyName = "TB_User.UserName";
            this.c_Creator.HeaderText = "录入者";
            this.c_Creator.Name = "c_Creator";
            this.c_Creator.ReadOnly = true;
            // 
            // c_CreateDate
            // 
            this.c_CreateDate.DataPropertyName = "CreateDate";
            this.c_CreateDate.HeaderText = "录入时间";
            this.c_CreateDate.Name = "c_CreateDate";
            this.c_CreateDate.ReadOnly = true;
            // 
            // c_Zhusai
            // 
            this.c_Zhusai.DataPropertyName = "Zhusai";
            this.c_Zhusai.HeaderText = "柱塞";
            this.c_Zhusai.Name = "c_Zhusai";
            this.c_Zhusai.ReadOnly = true;
            // 
            // c_Chuyoufa
            // 
            this.c_Chuyoufa.DataPropertyName = "Chuyoufa";
            this.c_Chuyoufa.HeaderText = "出油阀";
            this.c_Chuyoufa.Name = "c_Chuyoufa";
            this.c_Chuyoufa.ReadOnly = true;
            // 
            // c_Yuxingcheng
            // 
            this.c_Yuxingcheng.DataPropertyName = "Yuxingcheng";
            this.c_Yuxingcheng.HeaderText = "预行程";
            this.c_Yuxingcheng.Name = "c_Yuxingcheng";
            this.c_Yuxingcheng.ReadOnly = true;
            // 
            // c_Mohehouzhuangbenggai
            // 
            this.c_Mohehouzhuangbenggai.DataPropertyName = "Mohehouzhuangbenggai";
            this.c_Mohehouzhuangbenggai.HeaderText = "磨合后装泵盖";
            this.c_Mohehouzhuangbenggai.Name = "c_Mohehouzhuangbenggai";
            this.c_Mohehouzhuangbenggai.ReadOnly = true;
            // 
            // c_Shiyantaitiaoshi
            // 
            this.c_Shiyantaitiaoshi.DataPropertyName = "Shiyantaitiaoshi";
            this.c_Shiyantaitiaoshi.HeaderText = "试验台调试";
            this.c_Shiyantaitiaoshi.Name = "c_Shiyantaitiaoshi";
            this.c_Shiyantaitiaoshi.ReadOnly = true;
            // 
            // c_Zhuanghuiyoudiancifa
            // 
            this.c_Zhuanghuiyoudiancifa.DataPropertyName = "Zhuanghuiyoudiancifa";
            this.c_Zhuanghuiyoudiancifa.HeaderText = "装回油电磁阀";
            this.c_Zhuanghuiyoudiancifa.Name = "c_Zhuanghuiyoudiancifa";
            this.c_Zhuanghuiyoudiancifa.ReadOnly = true;
            // 
            // c_Zhuangfujian
            // 
            this.c_Zhuangfujian.DataPropertyName = "Zhuangfujian";
            this.c_Zhuangfujian.HeaderText = "装附件";
            this.c_Zhuangfujian.Name = "c_Zhuangfujian";
            this.c_Zhuangfujian.ReadOnly = true;
            // 
            // c_BQMohehouzhuanggaiban
            // 
            this.c_BQMohehouzhuanggaiban.DataPropertyName = "BQMohehouzhuanggaiban";
            this.c_BQMohehouzhuanggaiban.HeaderText = "磨合后装盖板";
            this.c_BQMohehouzhuanggaiban.Name = "c_BQMohehouzhuanggaiban";
            this.c_BQMohehouzhuanggaiban.ReadOnly = true;
            // 
            // c_BQShuyoubeng
            // 
            this.c_BQShuyoubeng.DataPropertyName = "BQShuyoubeng";
            this.c_BQShuyoubeng.HeaderText = "输油泵";
            this.c_BQShuyoubeng.Name = "c_BQShuyoubeng";
            this.c_BQShuyoubeng.ReadOnly = true;
            // 
            // c_BQShuyoubengzhijia
            // 
            this.c_BQShuyoubengzhijia.DataPropertyName = "BQShuyoubengzhijia";
            this.c_BQShuyoubengzhijia.HeaderText = "输油泵装支架";
            this.c_BQShuyoubengzhijia.Name = "c_BQShuyoubengzhijia";
            this.c_BQShuyoubengzhijia.ReadOnly = true;
            // 
            // c_BQZhuanghougaiban
            // 
            this.c_BQZhuanghougaiban.DataPropertyName = "BQZhuanghougaiban";
            this.c_BQZhuanghougaiban.HeaderText = "装后盖板";
            this.c_BQZhuanghougaiban.Name = "c_BQZhuanghougaiban";
            this.c_BQZhuanghougaiban.ReadOnly = true;
            // 
            // c_BQTingchelaxianzhijia
            // 
            this.c_BQTingchelaxianzhijia.DataPropertyName = "BQTingchelaxianzhijia";
            this.c_BQTingchelaxianzhijia.HeaderText = "停车拉线支架";
            this.c_BQTingchelaxianzhijia.Name = "c_BQTingchelaxianzhijia";
            this.c_BQTingchelaxianzhijia.ReadOnly = true;
            // 
            // c_BQShigaoyajinzuohumao
            // 
            this.c_BQShigaoyajinzuohumao.DataPropertyName = "BQShigaoyajinzuohumao";
            this.c_BQShigaoyajinzuohumao.HeaderText = "试高压紧座护帽";
            this.c_BQShigaoyajinzuohumao.Name = "c_BQShigaoyajinzuohumao";
            this.c_BQShigaoyajinzuohumao.ReadOnly = true;
            // 
            // c_Class
            // 
            this.c_Class.DataPropertyName = "Class";
            this.c_Class.HeaderText = "大类";
            this.c_Class.Name = "c_Class";
            this.c_Class.ReadOnly = true;
            // 
            // frm_MaterialSelectHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 468);
            this.Controls.Add(this.dgv_MatSelect);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_MaterialSelectHelper";
            this.Text = "泵体物料信息选择助手";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MatSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Confirm;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dgv_MatSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_TypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Dinghuobianhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Peitaochuangjia;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Zhusai;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Chuyoufa;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Yuxingcheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Mohehouzhuangbenggai;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Shiyantaitiaoshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Zhuanghuiyoudiancifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Zhuangfujian;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQMohehouzhuanggaiban;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQShuyoubeng;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQShuyoubengzhijia;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQZhuanghougaiban;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQTingchelaxianzhijia;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_BQShigaoyajinzuohumao;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Class;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_MaterialCode;
        private System.Windows.Forms.ToolStripButton btn_Ser;
    }
}