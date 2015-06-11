namespace XinYa.UI.BaseInfo
{
    partial class frm_MaterialInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MaterialInfo));
            this.tool_Main = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_AddVE = new System.Windows.Forms.ToolStripButton();
            this.btn_AddBQ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_View = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_ImportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.prosbar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.statu_Main = new System.Windows.Forms.StatusStrip();
            this.lab_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab_Statustext = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb_Ser = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ser = new System.Windows.Forms.Button();
            this.txt_MaterialCode = new System.Windows.Forms.TextBox();
            this.gb_Result = new System.Windows.Forms.GroupBox();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.c_TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.statu_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_Ser.SuspendLayout();
            this.gb_Result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // tool_Main
            // 
            this.tool_Main.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tool_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btn_AddVE,
            this.btn_AddBQ,
            this.toolStripSeparator2,
            this.btn_Edit,
            this.toolStripSeparator6,
            this.btn_View,
            this.toolStripSeparator3,
            this.btn_Delete,
            this.toolStripSeparator4,
            this.btn_Refresh,
            this.toolStripSeparator5,
            this.btn_ImportExcel,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.prosbar_Main});
            this.tool_Main.Location = new System.Drawing.Point(0, 0);
            this.tool_Main.Name = "tool_Main";
            this.tool_Main.Size = new System.Drawing.Size(964, 25);
            this.tool_Main.TabIndex = 2;
            this.tool_Main.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_AddVE
            // 
            this.btn_AddVE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddVE.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddVE.Image")));
            this.btn_AddVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddVE.Name = "btn_AddVE";
            this.btn_AddVE.Size = new System.Drawing.Size(51, 22);
            this.btn_AddVE.Text = "新增VE";
            this.btn_AddVE.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_AddBQ
            // 
            this.btn_AddBQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_AddBQ.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddBQ.Image")));
            this.btn_AddBQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_AddBQ.Name = "btn_AddBQ";
            this.btn_AddBQ.Size = new System.Drawing.Size(54, 22);
            this.btn_AddBQ.Text = "新增BQ";
            this.btn_AddBQ.Click += new System.EventHandler(this.btn_AddBQ_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Edit
            // 
            this.btn_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(36, 22);
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_View
            // 
            this.btn_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_View.Image = ((System.Drawing.Image)(resources.GetObject("btn_View.Image")));
            this.btn_View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(36, 22);
            this.btn_View.Text = "查看";
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Delete
            // 
            this.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(36, 22);
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(60, 22);
            this.btn_Refresh.Text = "数据刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_ImportExcel
            // 
            this.btn_ImportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_ImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportExcel.Image")));
            this.btn_ImportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ImportExcel.Name = "btn_ImportExcel";
            this.btn_ImportExcel.Size = new System.Drawing.Size(113, 22);
            this.btn_ImportExcel.Text = "导出数据到Excel表";
            this.btn_ImportExcel.Click += new System.EventHandler(this.btn_ImportExcel_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel1.Text = "系统正在处理：";
            this.toolStripLabel1.Visible = false;
            // 
            // prosbar_Main
            // 
            this.prosbar_Main.Name = "prosbar_Main";
            this.prosbar_Main.Size = new System.Drawing.Size(100, 22);
            this.prosbar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prosbar_Main.Visible = false;
            // 
            // statu_Main
            // 
            this.statu_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(82)))));
            this.statu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab_Status,
            this.lab_Statustext});
            this.statu_Main.Location = new System.Drawing.Point(0, 456);
            this.statu_Main.Name = "statu_Main";
            this.statu_Main.Size = new System.Drawing.Size(964, 22);
            this.statu_Main.TabIndex = 3;
            this.statu_Main.Text = "statusStrip1";
            // 
            // lab_Status
            // 
            this.lab_Status.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_Status.Name = "lab_Status";
            this.lab_Status.Size = new System.Drawing.Size(68, 17);
            this.lab_Status.Text = "当前状态：";
            // 
            // lab_Statustext
            // 
            this.lab_Statustext.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lab_Statustext.Name = "lab_Statustext";
            this.lab_Statustext.Size = new System.Drawing.Size(32, 17);
            this.lab_Statustext.Text = "就绪";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.splitContainer1.Panel1.Controls.Add(this.gb_Ser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gb_Result);
            this.splitContainer1.Size = new System.Drawing.Size(964, 431);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 4;
            // 
            // gb_Ser
            // 
            this.gb_Ser.Controls.Add(this.label1);
            this.gb_Ser.Controls.Add(this.btn_Ser);
            this.gb_Ser.Controls.Add(this.txt_MaterialCode);
            this.gb_Ser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Ser.Location = new System.Drawing.Point(0, 0);
            this.gb_Ser.Name = "gb_Ser";
            this.gb_Ser.Size = new System.Drawing.Size(964, 72);
            this.gb_Ser.TabIndex = 0;
            this.gb_Ser.TabStop = false;
            this.gb_Ser.Text = "查询条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "物料型号编码：";
            // 
            // btn_Ser
            // 
            this.btn_Ser.Location = new System.Drawing.Point(366, 28);
            this.btn_Ser.Name = "btn_Ser";
            this.btn_Ser.Size = new System.Drawing.Size(75, 23);
            this.btn_Ser.TabIndex = 1;
            this.btn_Ser.Text = "确认";
            this.btn_Ser.UseVisualStyleBackColor = true;
            this.btn_Ser.Click += new System.EventHandler(this.btn_Ser_Click);
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.Location = new System.Drawing.Point(146, 22);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(209, 29);
            this.txt_MaterialCode.TabIndex = 0;
            // 
            // gb_Result
            // 
            this.gb_Result.Controls.Add(this.dgv_Main);
            this.gb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Result.Location = new System.Drawing.Point(0, 0);
            this.gb_Result.Name = "gb_Result";
            this.gb_Result.Size = new System.Drawing.Size(964, 355);
            this.gb_Result.TabIndex = 0;
            this.gb_Result.TabStop = false;
            this.gb_Result.Text = "结果显示";
            // 
            // dgv_Main
            // 
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_TypeCode,
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
            this.dgv_Main.Location = new System.Drawing.Point(3, 17);
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(958, 335);
            this.dgv_Main.TabIndex = 0;
            this.dgv_Main.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Main_CellFormatting);
            // 
            // c_TypeCode
            // 
            this.c_TypeCode.DataPropertyName = "TypeCode";
            this.c_TypeCode.HeaderText = "产品编码（型号）";
            this.c_TypeCode.Name = "c_TypeCode";
            this.c_TypeCode.ReadOnly = true;
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
            // frm_MaterialInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(964, 478);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statu_Main);
            this.Controls.Add(this.tool_Main);
            this.Name = "frm_MaterialInfo";
            this.Text = "泵体物料信息管理";
            this.tool_Main.ResumeLayout(false);
            this.tool_Main.PerformLayout();
            this.statu_Main.ResumeLayout(false);
            this.statu_Main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gb_Ser.ResumeLayout(false);
            this.gb_Ser.PerformLayout();
            this.gb_Result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tool_Main;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_AddVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btn_ImportExcel;
        private System.Windows.Forms.StatusStrip statu_Main;
        private System.Windows.Forms.ToolStripStatusLabel lab_Status;
        private System.Windows.Forms.ToolStripStatusLabel lab_Statustext;
        private System.Windows.Forms.ToolStripButton btn_View;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gb_Ser;
        private System.Windows.Forms.GroupBox gb_Result;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Button btn_Ser;
        private System.Windows.Forms.TextBox txt_MaterialCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btn_AddBQ;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar prosbar_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_TypeCode;
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