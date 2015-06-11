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
    public partial class frm_ProcessRoute : Form
    {
        BllHelp bllHelp = new BllHelp();
        TB_User user;

        /// <summary>
        /// 主工序
        /// </summary>
        List<TB_ProcessRouteM> routeM;

        public frm_ProcessRoute(TB_User user)
        {
            InitializeComponent();
            this.toolStrip1.BackColor = Color.FromArgb(0xBD, 0xBA, 0xBA);
            this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.lab_Status.Text = "数据加载中...";
            Application.DoEvents();
            Init();
            this.lab_Status.Text = "数据加载完成";
            this.user = user;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始数据加载
        /// </summary>
        private void Init()
        {
            dgv_RouteM.AutoGenerateColumns = false;
            dgv_RouteP.AutoGenerateColumns = false;
            routeM = bllHelp.GetAllMainWorkFlow();
            dgv_RouteM.DataSource = routeM;
            dgv_RouteP.DataSource = null;
        }

        /// <summary>
        /// dgv_RouteM加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_RouteM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_RouteM.Rows[e.RowIndex].DataBoundItem != null) && (dgv_RouteM.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_RouteM.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_RouteM.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        /// <summary>
        /// routeM单击事件，加载routeP数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_RouteM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // dgv_RouteP.DataSource = null;
            if (dgv_RouteM.CurrentRow != null)
            {
                int id = (int)dgv_RouteM.CurrentRow.Cells["ID"].Value;
                //dgv_RouteP.DataSource = bllHelp.GetAllWorkFlow(false, item);
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_ProcessRouteM.Single(p => p.ID == id);
                        dgv_RouteP.DataSource = a.TB_ProcessRouteP.ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("当前主路线没有子路线存在！");
                    }
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 新增工艺路线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frm_ProcessRouteAddOrEdit add = new frm_ProcessRouteAddOrEdit(user);
            //frm_Main frm =(frm_Main) this.Parent;
            //user = frm.User;
            add.ShowDialog();
        }

        /// <summary>
        /// 编辑工艺路线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgv_RouteM.CurrentRow == null || routeM == null)
            {
                MessageBox.Show("未选择数据或当前没有可编辑数据！");
            }
            else
            {
                frm_ProcessRouteAddOrEdit edit = new frm_ProcessRouteAddOrEdit(routeM.Single(p => p.ID == Convert.ToInt32(dgv_RouteM.CurrentRow.Cells["ID"].Value.ToString())), user);
                edit.ShowDialog();
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.lab_Status.Text = "数据加载中...";
            Application.DoEvents();
            Init();
            this.lab_Status.Text = "数据加载完成";
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            //先判断是否有选择数据
            if (dgv_RouteM.CurrentRow == null)
            {
                MessageBox.Show("当前没有选中任何数据！");
                return;
            }
            //再提示
            if (MessageBox.Show("删除后将无法恢复，是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    int id = (int)dgv_RouteM.CurrentRow.Cells["ID"].Value;
                    var routem = db.TB_ProcessRouteM.Single(p => p.ID == id);
                    //item0不能被删除
                    if (routem.ProcessRouteMCode == "Item0")
                    {
                        MessageBox.Show("原始数据不能被删除！");
                        db.Dispose();
                        return;
                    }
                    //判断是否存在外键引用该主路线
                    if (routem.TB_MaterialInfo.Count != 0)
                    {
                        MessageBox.Show("当前路线已经被某些物料所加载，请解除物料加载的工艺路线后再进行删除操作！");
                        db.Dispose();
                        return;
                    }
                    else
                    {
                        //判断是否存在子路线
                        if (routem.TB_ProcessRouteP.Count == 0)
                        {
                            //没有则直接将主路线删除
                            db.DeleteObject(routem);
                            db.SaveChanges();
                        }
                        else
                        {
                            //如果有
                            //先删除子路线
                            List<TB_ProcessRouteP> list_routep = new List<TB_ProcessRouteP>();
                            foreach (var item in routem.TB_ProcessRouteP)
                            {
                                var a = db.TB_ProcessRouteP.Single(p => p.ID == item.ID);
                                list_routep.Add(a);
                            }
                            foreach (var item in list_routep)
                            {
                                db.DeleteObject(item);
                            }
                            //再删除主路线
                            db.DeleteObject(routem);
                            db.SaveChanges();
                            MessageBox.Show("删除成功！");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("出现特定于数据的异常，删除失败！");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 导出主工艺路线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportMain_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_RouteM.RowCount <= 0 || dgv_RouteM.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_RouteM) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 导出明细工艺路线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportDtl_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_RouteP.RowCount <= 0 || dgv_RouteP.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_RouteP) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

        public void Changeprobar(bool flag)
        {
            if (flag)
            {
                lab_Status.Visible = true;
                prosbar_Main.Visible = true;
            }
            else
            {
                lab_Status.Visible = false;
                prosbar_Main.Visible = false;
            }
        }
    }
}
