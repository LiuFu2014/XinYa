using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;

namespace XinYa.UI.WorkManagement
{
    /// <summary>
    /// 编辑或新增工艺路线
    /// </summary>
    public partial class frm_ProcessRouteAddOrEdit : Form
    {
        #region 字段属性
        BllHelp bllHelp = new BllHelp();

        /// <summary>
        /// 主工序
        /// </summary>
        TB_ProcessRouteM routeM;

        /// <summary>
        /// 当前用户
        /// </summary>
        TB_User user;

        /// <summary>
        /// 工艺路线
        /// </summary>
        List<TB_ProcessRouteP> routePSource;

        bool addornot;
        #endregion

        #region 重写构造函数，用于传值

        public frm_ProcessRouteAddOrEdit(TB_User user)
        {
            InitializeComponent();
            this.Text = "新增";
            this.user = user;
            addornot = true;
            this.lab_Status.Text = "新增中..";
            Init();
        }

        public frm_ProcessRouteAddOrEdit(TB_ProcessRouteM routeM, TB_User user)
        {
            this.routeM = routeM;
            InitializeComponent();
            this.Text = "编辑";
            //frm_Main frm =(frm_Main)this.Parent.Parent;
            //user = frm.User;
            this.user = user;
            addornot = false;
            //this.txt_RouteName.ReadOnly = true;
            //工艺路线编码不能更改
            this.txt_RouteCode.ReadOnly = true;
            this.lab_Status.Text = "编辑中..";
            Init();
        }

        #endregion

        #region 事件处理函数

        /// <summary>
        /// 数据初始化
        /// </summary>
        private void Init()
        {
            #region 配色
            this.p_Bottom.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            #endregion

            if (routeM != null)
            {
                this.txt_RouteName.Text = routeM.ProcessRouteMName;
                this.txt_RouteCode.Text = routeM.ProcessRouteP;
                this.txt_Remark.Text = routeM.Remark;
                this.check_IsUse.Checked = routeM.IsUse;
                this.lab_Creator.Text = routeM.TB_User.UserName;
                this.lab_Date.Text = routeM.CreateDate;
                this.dgv_RouteP.AutoGenerateColumns = false;
                routePSource = bllHelp.GetAllWorkFlow(false, routeM.ProcessRouteP);
                this.dgv_RouteP.DataSource = routePSource;
            }
            else
            {
                this.dgv_RouteP.AutoGenerateColumns = false;
                routePSource = bllHelp.GetAllWorkFlow(false, "item0");
                this.dgv_RouteP.DataSource = routePSource;
            }
        }

        /// <summary>
        /// 保存（编辑则更新，新增则插入）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //XinYaDBEntities db = new XinYaDBEntities();
            //工艺路线名和编码不能为空
            if (string.IsNullOrEmpty(txt_RouteCode.Text) || string.IsNullOrEmpty(txt_RouteName.Text))
            {
                MessageBox.Show("工艺路线名或编码不能为空！");
                return;
            }

            //主表
            routeM = new TB_ProcessRouteM();
            routeM.ProcessRouteMName = this.txt_RouteName.Text;
            routeM.ProcessRouteP = this.txt_RouteCode.Text;
            routeM.ProcessRouteMCode = this.txt_RouteCode.Text;
            routeM.Remark = this.txt_Remark.Text;
            routeM.IsUse = this.check_IsUse.Checked;
            //m.TB_User = db.TB_User.First(p=>p.ID==user.ID);
            //创建者和创建时间不提供修改，如果为新增，则在数据更新的时候进行绑定
            //routeM.TB_User.UserName = this.lab_Creator.Text;
            //routeM.CreateDate = this.lab_Date.Text;
            //从表数据加载
            //db.AddToTB_ProcessRouteM(m);
            //db.SaveChanges();

            List<TB_ProcessRouteP> routePs = new List<TB_ProcessRouteP>();
            routePSource = (List<TB_ProcessRouteP>)dgv_RouteP.DataSource;
            //12月20日，新增保存判定，对于磨合、调试、QC和外观检查为必须工序，如果没有选，则提示并终止处理过程
            foreach (var item in routePSource)
            {
                TB_ProcessRouteP routeP = new TB_ProcessRouteP();
                routeP.ProcessRouteM = item.ProcessRouteM;
                routeP.No = item.No;
                routeP.IsUse = item.IsUse;
                routeP.IsLast = item.IsLast;
                routeP.Remark = item.Remark;
                if ((int)item.No==2||(int)item.No==5||(int)item.No==6||(int)item.No==15)
                {
                    if (!item.IsUse)
                    {
                        MessageBox.Show("磨合工序、调试工序、QC工序和外观检查工序是必须的工序。请重新修改后提交！");
                        return;
                    }
                }
            }
            //bllHelp.AddOrRefreshProcessRoute(routeM, routePSource, user);
            switch (bllHelp.AddOrRefreshProcessRoute(routeM, routePSource, user, addornot))
            {
                case 0:
                    MessageBox.Show("操作成功！");
                    break;
                case 1:
                    MessageBox.Show("更新主表数据失败！");
                    break;
                case 2:
                    MessageBox.Show("更新从表数据失败！");
                    break;
                case 3:
                    MessageBox.Show("插入主表数据失败！");
                    break;
                case 4:
                    MessageBox.Show("插入从表数据失败！");
                    break;
                case 5:
                    MessageBox.Show("新增失败！该编码对应的主路线已经存在，如果要编辑请使用编辑功能！");
                    break;
                default:
                    break;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// dgv_RouteP加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_RouteP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_RouteP.Rows[e.RowIndex].DataBoundItem != null) && (dgv_RouteP.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_RouteP.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_RouteP.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        e.Value = result.ToString();//拿到对应的值
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }
        #endregion

    }
}
