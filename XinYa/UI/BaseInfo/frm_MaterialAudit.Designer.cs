namespace XinYa.UI.BaseInfo
{
    partial class frm_MaterialAudit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MaterialAudit));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.txt_MaterialCode = new System.Windows.Forms.TextBox();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.btn_ShowAll = new System.Windows.Forms.Button();
            this.btn_ShowUnAudit = new System.Windows.Forms.Button();
            this.btn_Audit = new System.Windows.Forms.Button();
            this.btn_ShowAudit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CancelAudit = new System.Windows.Forms.Button();
            this.btn_Chakan = new System.Windows.Forms.Button();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Audit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_AuditEditot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
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
            this.tool_Main.Size = new System.Drawing.Size(971, 25);
            this.tool_Main.TabIndex = 12;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(36, 22);
            this.btn_Cancel.Text = "退出";
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
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Chakan);
            this.splitContainer1.Panel1.Controls.Add(this.btn_CancelAudit);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Ser);
            this.splitContainer1.Panel1.Controls.Add(this.txt_MaterialCode);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.btn_ShowAll);
            this.splitContainer1.Panel1.Controls.Add(this.btn_ShowUnAudit);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Audit);
            this.splitContainer1.Panel1.Controls.Add(this.btn_ShowAudit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Main);
            this.splitContainer1.Size = new System.Drawing.Size(971, 377);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 14;
            // 
            // btn_Ser
            // 
            this.btn_Ser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ser.Location = new System.Drawing.Point(315, 72);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(101, 29);
            this.btn_Ser.TabIndex = 6;
            this.btn_Ser.Text = "模糊查询";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.Location = new System.Drawing.Point(148, 34);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(268, 29);
            this.txt_MaterialCode.TabIndex = 5;
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectAll.Location = new System.Drawing.Point(448, 30);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(87, 34);
            this.btn_SelectAll.TabIndex = 4;
            this.btn_SelectAll.Text = "全选";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // btn_ShowAll
            // 
            this.btn_ShowAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowAll.Location = new System.Drawing.Point(448, 65);
            this.btn_ShowAll.Name = "btn_ShowAll";
            this.btn_ShowAll.Size = new System.Drawing.Size(87, 34);
            this.btn_ShowAll.TabIndex = 3;
            this.btn_ShowAll.Text = "列出所有";
            this.btn_ShowAll.UseVisualStyleBackColor = true;
            this.btn_ShowAll.Click += new System.EventHandler(this.btn_ShowAll_Click);
            // 
            // btn_ShowUnAudit
            // 
            this.btn_ShowUnAudit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowUnAudit.Location = new System.Drawing.Point(541, 30);
            this.btn_ShowUnAudit.Name = "btn_ShowUnAudit";
            this.btn_ShowUnAudit.Size = new System.Drawing.Size(102, 34);
            this.btn_ShowUnAudit.TabIndex = 2;
            this.btn_ShowUnAudit.Text = "列出未审核";
            this.btn_ShowUnAudit.UseVisualStyleBackColor = true;
            this.btn_ShowUnAudit.Click += new System.EventHandler(this.btn_ShowUnAudit_Click);
            // 
            // btn_Audit
            // 
            this.btn_Audit.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_Audit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Audit.Location = new System.Drawing.Point(748, 29);
            this.btn_Audit.Name = "btn_Audit";
            this.btn_Audit.Size = new System.Drawing.Size(81, 70);
            this.btn_Audit.TabIndex = 1;
            this.btn_Audit.Text = "审核";
            this.btn_Audit.UseVisualStyleBackColor = false;
            this.btn_Audit.Click += new System.EventHandler(this.btn_Audit_Click);
            // 
            // btn_ShowAudit
            // 
            this.btn_ShowAudit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ShowAudit.Location = new System.Drawing.Point(542, 65);
            this.btn_ShowAudit.Name = "btn_ShowAudit";
            this.btn_ShowAudit.Size = new System.Drawing.Size(101, 34);
            this.btn_ShowAudit.TabIndex = 0;
            this.btn_ShowAudit.Text = "列出已审核";
            this.btn_ShowAudit.UseVisualStyleBackColor = true;
            this.btn_ShowAudit.Click += new System.EventHandler(this.btn_ShowAudit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "按型号查询：";
            // 
            // btn_CancelAudit
            // 
            this.btn_CancelAudit.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_CancelAudit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelAudit.Location = new System.Drawing.Point(830, 29);
            this.btn_CancelAudit.Name = "btn_CancelAudit";
            this.btn_CancelAudit.Size = new System.Drawing.Size(81, 70);
            this.btn_CancelAudit.TabIndex = 8;
            this.btn_CancelAudit.Text = "取消审核";
            this.btn_CancelAudit.UseVisualStyleBackColor = false;
            this.btn_CancelAudit.Click += new System.EventHandler(this.btn_CancelAudit_Click);
            // 
            // btn_Chakan
            // 
            this.btn_Chakan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Chakan.Location = new System.Drawing.Point(650, 29);
            this.btn_Chakan.Name = "btn_Chakan";
            this.btn_Chakan.Size = new System.Drawing.Size(81, 70);
            this.btn_Chakan.TabIndex = 9;
            this.btn_Chakan.Text = "查看";
            this.btn_Chakan.UseVisualStyleBackColor = true;
            this.btn_Chakan.Click += new System.EventHandler(this.btn_Chakan_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Select,
            this.c_TypeCode,
            this.c_Audit,
            this.c_AuditEditot,
            this.c_Route,
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
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 0);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(971, 253);
            this.dgv_Main.TabIndex = 1;
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            // 
            // c_Select
            // 
            this.c_Select.FalseValue = "False";
            this.c_Select.HeaderText = "选择";
            this.c_Select.IndeterminateValue = "False";
            this.c_Select.Name = "c_Select";
            this.c_Select.TrueValue = "True";
            // 
            // c_TypeCode
            // 
            this.c_TypeCode.DataPropertyName = "TypeCode";
            this.c_TypeCode.HeaderText = "产品编码（型号）";
            this.c_TypeCode.Name = "c_TypeCode";
            this.c_TypeCode.ReadOnly = true;
            // 
            // c_Audit
            // 
            this.c_Audit.DataPropertyName = "Audit";
            this.c_Audit.FalseValue = "false";
            this.c_Audit.HeaderText = "审核";
            this.c_Audit.IndeterminateValue = "false";
            this.c_Audit.Name = "c_Audit";
            this.c_Audit.ReadOnly = true;
            this.c_Audit.TrueValue = "true";
            // 
            // c_AuditEditot
            // 
            this.c_AuditEditot.DataPropertyName = "TB_User1.UserName";
            this.c_AuditEditot.HeaderText = "审核人";
            this.c_AuditEditot.Name = "c_AuditEditot";
            this.c_AuditEditot.ReadOnly = true;
            // 
            // c_Route
            // 
            this.c_Route.DataPropertyName = "TB_ProcessRouteM.ProcessRouteMCode";
            this.c_Route.HeaderText = "工艺路线编码";
            this.c_Route.Name = "c_Route";
            this.c_Route.ReadOnly = true;
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
            // frm_MaterialAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 424);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_MaterialAudit";
            this.Text = "物料审核";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_ShowAll;
        private System.Windows.Forms.Button btn_ShowUnAudit;
        private System.Windows.Forms.Button btn_Audit;
        private System.Windows.Forms.Button btn_ShowAudit;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.TextBox txt_MaterialCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CancelAudit;
        private System.Windows.Forms.Button btn_Chakan;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_TypeCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Audit;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_AuditEditot;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Route;
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
    }
}