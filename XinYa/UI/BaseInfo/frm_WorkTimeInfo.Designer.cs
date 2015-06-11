namespace XinYa.UI.BaseInfo
{
    partial class frm_WorkTimeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WorkTimeInfo));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Outport = new System.Windows.Forms.ToolStripButton();
            this.btn_RefreshMaterial = new System.Windows.Forms.ToolStripButton();
            this.btn_RefreshWorkTime = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txt_MatCode = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Ser = new System.Windows.Forms.ToolStripButton();
            this.lab_Status = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.status_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_WorkTime = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_TB_SecondWorkStationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_WorkTimePerMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_WorkTimeRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Editor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_EditTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tool_Main.SuspendLayout();
            this.status_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Save,
            this.btn_Cancel,
            this.toolStripSeparator1,
            this.btn_Outport,
            this.btn_RefreshMaterial,
            this.btn_RefreshWorkTime,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.txt_MatCode,
            this.btn_Ser,
            this.lab_Status,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(849, 25);
            this.tool_Main.TabIndex = 14;
            this.tool_Main.Text = "toolStrip1";
            // 
            // btn_Save
            // 
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 22);
            this.btn_Save.Text = "保存更改";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 22);
            this.btn_Cancel.Text = "取消退出";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Outport
            // 
            this.btn_Outport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Outport.Image = ((System.Drawing.Image)(resources.GetObject("btn_Outport.Image")));
            this.btn_Outport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Outport.Name = "btn_Outport";
            this.btn_Outport.Size = new System.Drawing.Size(84, 22);
            this.btn_Outport.Text = "工时数据导出";
            this.btn_Outport.Click += new System.EventHandler(this.btn_Outport_Click);
            // 
            // btn_RefreshMaterial
            // 
            this.btn_RefreshMaterial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_RefreshMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btn_RefreshMaterial.Image")));
            this.btn_RefreshMaterial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_RefreshMaterial.Name = "btn_RefreshMaterial";
            this.btn_RefreshMaterial.Size = new System.Drawing.Size(72, 22);
            this.btn_RefreshMaterial.Text = "刷新物料表";
            this.btn_RefreshMaterial.Click += new System.EventHandler(this.btn_RefreshMaterial_Click);
            // 
            // btn_RefreshWorkTime
            // 
            this.btn_RefreshWorkTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_RefreshWorkTime.Image = ((System.Drawing.Image)(resources.GetObject("btn_RefreshWorkTime.Image")));
            this.btn_RefreshWorkTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_RefreshWorkTime.Name = "btn_RefreshWorkTime";
            this.btn_RefreshWorkTime.Size = new System.Drawing.Size(96, 22);
            this.btn_RefreshWorkTime.Text = "刷新数据工时表";
            this.btn_RefreshWorkTime.Click += new System.EventHandler(this.btn_RefreshWorkTime_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel1.Text = "指定物料编码：";
            // 
            // txt_MatCode
            // 
            this.txt_MatCode.Name = "txt_MatCode";
            this.txt_MatCode.Size = new System.Drawing.Size(100, 25);
            // 
            // btn_Ser
            // 
            this.btn_Ser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Ser.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ser.Image")));
            this.btn_Ser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(36, 22);
            this.btn_Ser.Text = "查询";
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
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
            // status_Main
            // 
            this.status_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.status_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.status_Main.Location = new System.Drawing.Point(0, 460);
            this.status_Main.Name = "status_Main";
            this.status_Main.Size = new System.Drawing.Size(849, 22);
            this.status_Main.TabIndex = 15;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(849, 435);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Main);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 435);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "物料列表";
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(3, 17);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(340, 415);
            this.dgv_Main.TabIndex = 1;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_WorkTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 435);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工时列表";
            // 
            // dgv_WorkTime
            // 
            this.dgv_WorkTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_WorkTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_TB_SecondWorkStationID,
            this.c_WorkTimePerMaterial,
            this.c_WorkTimeRemark,
            this.c_Editor,
            this.c_EditTime});
            this.dgv_WorkTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_WorkTime.Location = new System.Drawing.Point(3, 17);
            this.dgv_WorkTime.Name = "dgv_WorkTime";
            this.dgv_WorkTime.RowTemplate.Height = 23;
            this.dgv_WorkTime.Size = new System.Drawing.Size(493, 415);
            this.dgv_WorkTime.TabIndex = 0;
            this.dgv_WorkTime.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_WorkTime_CellFormatting);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "ID";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.ReadOnly = true;
            this.c_ID.Visible = false;
            // 
            // c_TB_SecondWorkStationID
            // 
            this.c_TB_SecondWorkStationID.DataPropertyName = "TB_SecondWorkStationInfo.SecondWorkStationName";
            this.c_TB_SecondWorkStationID.HeaderText = "工位名";
            this.c_TB_SecondWorkStationID.Name = "c_TB_SecondWorkStationID";
            this.c_TB_SecondWorkStationID.ReadOnly = true;
            // 
            // c_WorkTimePerMaterial
            // 
            this.c_WorkTimePerMaterial.DataPropertyName = "WorkTimePerMaterial";
            this.c_WorkTimePerMaterial.HeaderText = "工时";
            this.c_WorkTimePerMaterial.Name = "c_WorkTimePerMaterial";
            // 
            // c_WorkTimeRemark
            // 
            this.c_WorkTimeRemark.DataPropertyName = "Remark";
            this.c_WorkTimeRemark.HeaderText = "备注";
            this.c_WorkTimeRemark.Name = "c_WorkTimeRemark";
            // 
            // c_Editor
            // 
            this.c_Editor.DataPropertyName = "TB_User.UserName";
            this.c_Editor.HeaderText = "编辑人";
            this.c_Editor.Name = "c_Editor";
            this.c_Editor.ReadOnly = true;
            // 
            // c_EditTime
            // 
            this.c_EditTime.DataPropertyName = "EditTime";
            this.c_EditTime.HeaderText = "编辑时间";
            this.c_EditTime.Name = "c_EditTime";
            this.c_EditTime.ReadOnly = true;
            // 
            // frm_WorkTimeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 482);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.status_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_WorkTimeInfo";
            this.Text = "工时信息管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.status_Main.ResumeLayout(false);
            this.status_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Outport;
        private System.Windows.Forms.ToolStripButton btn_RefreshWorkTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lab_Status;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.StatusStrip status_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txt_MatCode;
        private System.Windows.Forms.ToolStripButton btn_Ser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_WorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_TB_SecondWorkStationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_WorkTimePerMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_WorkTimeRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Editor;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_EditTime;
        private System.Windows.Forms.DataGridView dgv_Main;
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
        private System.Windows.Forms.ToolStripButton btn_RefreshMaterial;
    }
}