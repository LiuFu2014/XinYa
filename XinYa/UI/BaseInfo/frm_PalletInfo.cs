using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;
using XinYa.BLL;

namespace XinYa.UI.BaseInfo
{
    public partial class frm_PalletInfo : Form
    {
        #region 字段属性

        List<TB_PalletInfo> list_PalletInfo;
        TB_User user = new TB_User();

        #endregion

        public frm_PalletInfo(TB_User user)
        {
            InitializeComponent();
            Init();
            this.user = user;
            //不可写
            txt_PalletCode.ReadOnly = true;
            txt_PalletSize.ReadOnly = true;
            //chck_Isuse.Enabled = false;
            txt_Remark.ReadOnly = true;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    list_PalletInfo = db.TB_PalletInfo.ToList();
                    dgv_Main.DataSource = list_PalletInfo;
                }
                catch (Exception)
                {
                    MessageBox.Show("数据初始化失败！") ;
                }
            }
        }

        /// <summary>
        /// 重载，带参初始化
        /// </summary>
        /// <param name="palletCode"></param>
        public void Init(string palletCode)
        {
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                try
                {
                    list_PalletInfo = db.TB_PalletInfo.Where(p => p.PalletCode == palletCode).ToList();
                    dgv_Main.DataSource = list_PalletInfo;
                }
                catch (Exception)
                {
                    MessageBox.Show("数据初始化失败！系统或没有此数据。");
                }
            }
        }

        /// <summary>
        /// 新增模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //将取消新增可见
            //保存可见
            btn_AddCancel.Visible = true;
            btn_Save.Visible = true;
            //其他不可见
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            btn_EditCancel.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Exit.Visible = false;
            

            //清空
            txt_PalletCode.Text = "";
            txt_PalletSize.Text = "";
            chck_Isuse.Checked = true;
            txt_Remark.Text = "";

            //可写
            txt_PalletCode.ReadOnly = false;
            txt_PalletSize.ReadOnly = false;
            //chck_Isuse.Enabled = true;
            txt_Remark.ReadOnly = false;
            //将dgv设置为不可用
            dgv_Main.Enabled = false;
            lab_Statustext.Text = "新增模式";
        }

        /// <summary>
        /// 取消新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddCancel_Click(object sender, EventArgs e)
        {
            //将取消新增不可见
            //保存不可见
            btn_AddCancel.Visible = false;
            btn_Save.Visible = false;
            //其他可见
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_EditCancel.Visible = false;
            btn_ImportExcel.Visible = true;
            btn_Refresh.Visible = true;
            btn_Exit.Visible = true;


            //清空
            txt_PalletCode.Text = "";
            txt_PalletSize.Text = "";
            chck_Isuse.Checked = false;
            txt_Remark.Text = "";

            //不可写
            txt_PalletCode.ReadOnly = true;
            txt_PalletSize.ReadOnly = true;
            //chck_Isuse.Enabled = false;
            txt_Remark.ReadOnly = true;
            //将dgv设置为可用
            dgv_Main.Enabled = true;
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //将取消编辑可见
            //保存可见
            btn_EditCancel.Visible = true;
            btn_Save.Visible = true;
            //其他不可见
            btn_Delete.Visible = false;
            btn_Edit.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Refresh.Visible = false;
            btn_ImportExcel.Visible = false;
            btn_Exit.Visible = false;
            btn_AddCancel.Visible = false;

            //编辑模式下托盘编码只读
            txt_PalletCode.ReadOnly = true;
            //可写
            txt_PalletSize.ReadOnly = false;
            //chck_Isuse.Enabled = true;
            txt_Remark.ReadOnly = false;
            //将dgv设置为不可用
            dgv_Main.Enabled = false;
            lab_Statustext.Text = "编辑模式";
        }

        /// <summary>
        /// 取消编辑模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditCancel_Click(object sender, EventArgs e)
        {
            //将取消编辑不可见
            //保存不可见
            btn_EditCancel.Visible = false;
            btn_Save.Visible = false;
            //其他可见
            btn_Delete.Visible = true;
            btn_Edit.Visible = true;
            btn_ImportExcel.Visible = true;
            btn_Refresh.Visible = true;
            btn_ImportExcel.Visible = true;
            btn_Exit.Visible = true;
            btn_AddCancel.Visible = true;

            //不可写
            txt_PalletCode.ReadOnly = true;
            txt_PalletSize.ReadOnly = true;
            //chck_Isuse.Enabled = false;
            txt_Remark.ReadOnly = true;
            //将dgv设置为可用
            dgv_Main.Enabled = true;
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            Init();
            Changeprobar(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_Main.CurrentRow!=null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities()) 
                {
                    try
                    {
                        string palletCode=dgv_Main.CurrentRow.Cells["c_PalletCode"].Value.ToString();
                        var a = db.TB_PalletInfo.First(p => p.PalletCode == palletCode);
                        string temp=a.PalletCode;
                        db.TB_PalletInfo.DeleteObject(a);
                        db.SaveChanges();
                        MessageBox.Show("删除成功！");
                        SystemLogHelper.WriteSysLogHelper("删除了一条托盘数据。托盘号：" + temp, user.ID, "托盘信息管理");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("或因网络故障，删除失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有选中任何数据！");
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 指定托盘编码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Init(txt_Ser.Text);
        }

        /// <summary>
        /// 新增或编辑保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (lab_Statustext.Text!="就绪")
            {
                if (lab_Statustext.Text=="新增模式")
                {
                    if (string.IsNullOrEmpty(txt_PalletCode.Text))
                    {
                        MessageBox.Show("托盘编码不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db = new XinYaDBEntities())
                        {
                            try
                            {
                                TB_PalletInfo a = new TB_PalletInfo();
                                a.PalletCode = txt_PalletCode.Text;
                                a.PalletSize = txt_PalletSize.Text;
                                a.IsUse = chck_Isuse.Checked;
                                a.Remark = txt_Remark.Text;
                                db.TB_PalletInfo.AddObject(a);
                                db.SaveChanges();
                                MessageBox.Show("新增成功！");
                                SystemLogHelper.WriteSysLogHelper("新增了一条托盘数据。托盘号：" + a.PalletCode, user.ID, "托盘信息管理");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("或因网络原因，新增失败！");
                            }
                          
                        }
                    }
                   
                }
                else if(lab_Statustext.Text=="编辑模式")
                {
                    if (string.IsNullOrEmpty(txt_PalletCode.Text))
                    {
                        MessageBox.Show("托盘编码不能为空！");
                    }
                    else
                    {
                        using (XinYaDBEntities db=new XinYaDBEntities())
                        {
                            try
                            {
                                string palletCode=txt_PalletCode.Text.ToString();
                                var a = db.TB_PalletInfo.First(p=>p.PalletCode==palletCode);
                                a.PalletSize = txt_PalletSize.Text;
                                a.IsUse = chck_Isuse.Checked;
                                a.Remark = txt_Remark.Text;
                                db.SaveChanges();
                                MessageBox.Show("更新成功！");
                                SystemLogHelper.WriteSysLogHelper("更新了一条托盘数据。托盘号：" + a.PalletCode, user.ID, "托盘信息管理");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("或因网络原因，更新失败！");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Main.CurrentRow!=null)
            {
                txt_PalletCode.Text = dgv_Main.CurrentRow.Cells["c_PalletCode"].Value.ToString();
                txt_PalletSize.Text = dgv_Main.CurrentRow.Cells["c_PalletSize"].Value.ToString();
                chck_Isuse.Checked =(bool)dgv_Main.CurrentRow.Cells["c_Isuse"].Value;
                txt_Remark.Text = dgv_Main.CurrentRow.Cells["c_Remark"].Value.ToString();
            }
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.RowCount <= 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Main) == 0)
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
