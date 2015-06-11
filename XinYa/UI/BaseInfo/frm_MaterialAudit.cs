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
    public partial class frm_MaterialAudit : Form
    {
        #region 字段属性

        TB_User user = new TB_User();

        #endregion
        public frm_MaterialAudit(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_Main.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaterialCode.Text))
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_MaterialInfo.ToList();
                        var mat = a.Where(p => p.TypeCode.Contains(txt_MaterialCode.Text)).ToList();
                        foreach (var item in mat)
                        {
                            item.TB_ProcessRouteMReference.Load();
                            item.TB_User1Reference.Load();
                            item.TB_UserReference.Load();
                        }
                        dgv_Main.DataSource = mat;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常。");
                        SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "物料审核");
                    }
                }
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            if (dgv_Main.DataSource != null && dgv_Main.Rows[0].Cells[1].Value != null)
            {
                foreach (DataGridViewRow item in dgv_Main.Rows)
                {
                    if (item.Cells["c_TypeCode"].Value != null)
                    {
                        item.Cells["c_Select"].Value = true;
                    }
                }
            }
        }

        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_MaterialInfo.ToList();
                    //var mat = a.Where(p => p.TypeCode.Contains(txt_MaterialCode.Text)).ToList();
                    foreach (var item in a)
                    {
                        item.TB_ProcessRouteMReference.Load();
                        item.TB_User1Reference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_Main.DataSource = a;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询出现异常。");
                    SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "物料审核");
                }
            }
        }

        /// <summary>
        /// 显示未审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ShowUnAudit_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_MaterialInfo.ToList();
                    var mat = a.Where(p => p.Audit == false).ToList();
                    foreach (var item in mat)
                    {
                        item.TB_ProcessRouteMReference.Load();
                        item.TB_User1Reference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_Main.DataSource = mat;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询出现异常。");
                    SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "物料审核");
                }
            }
        }

        /// <summary>
        /// 显示已审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ShowAudit_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_MaterialInfo.ToList();
                    var mat = a.Where(p => p.Audit == true).ToList();
                    foreach (var item in mat)
                    {
                        item.TB_ProcessRouteMReference.Load();
                        item.TB_User1Reference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_Main.DataSource = mat;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询出现异常。");
                    SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "物料审核");
                }
            }
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Chakan_Click(object sender, EventArgs e)
        {
            //先判断有没有选中行
            if (dgv_Main.CurrentRow == null)
            {
                MessageBox.Show("当前没有选中任何数据！请重新选择数据所在行，再进行操作！");
                return;
            }
            //string matclass=dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString();
            if (dgv_Main.CurrentRow.Cells["c_Class"].Value == null)
            {
                MessageBox.Show("该物料没有大类区别，无法查看！");
                return;
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "VE")
            {
                frm_MaterialInfoVEDtl matdtl = new frm_MaterialInfoVEDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 3);
                matdtl.ShowDialog();
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "BQ")
            {
                frm_MaterialInfoBQDtl matdtl = new frm_MaterialInfoBQDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 3);
                matdtl.ShowDialog();
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Audit_Click(object sender, EventArgs e)
        {
            if (dgv_Main.DataSource != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    Changeprobar(true);
                    Application.DoEvents();
                    try
                    {
                        foreach (DataGridViewRow item in dgv_Main.Rows)
                        {
                            //string temp=item.Cells["c_Select"].Value.ToString();
                            if (item.Cells["c_TypeCode"].Value != null && item.Cells["c_Select"].Value != null && item.Cells["c_Select"].Value.ToString()=="True")
                            {
                                string typeCode = item.Cells["c_TypeCode"].Value.ToString();
                                var a = db.TB_MaterialInfo.Single(p => p.TypeCode == typeCode);
                                a.Audit = true;
                                a.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                db.SaveChanges();
                            }
                        }
                        MessageBox.Show("审核成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("审核出现异常！");
                        SystemLogHelper.WriteSysLogHelper("审核出现异常，详情：" + ex.ToString(),user.ID,"物料审核");
                    }
                    Changeprobar(false);
                }
            }
        }

        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CancelAudit_Click(object sender, EventArgs e)
        {
            if (dgv_Main.DataSource != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    Changeprobar(true);
                    Application.DoEvents();
                    try
                    {
                        foreach (DataGridViewRow item in dgv_Main.Rows)
                        {
                            //string temp = item.Cells["c_Select"].Value.ToString();
                            if (item.Cells["c_TypeCode"].Value != null && item.Cells["c_Select"].Value != null && item.Cells["c_Select"].Value.ToString()=="True")
                            {
                                string typeCode = item.Cells["c_TypeCode"].Value.ToString();
                                var a = db.TB_MaterialInfo.Single(p => p.TypeCode == typeCode);
                                a.Audit = false;
                                a.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                db.SaveChanges();
                            }
                        }
                        MessageBox.Show("取消审核成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("取消审核出现异常！");
                        SystemLogHelper.WriteSysLogHelper("取消审核出现异常，详情：" + ex.ToString(), user.ID, "物料审核");
                    }
                    Changeprobar(false);
                }
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 进度条控制函数
        /// </summary>
        /// <param name="flag"></param>
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

        private void dgv_Main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_Main.Rows[e.RowIndex].DataBoundItem != null) && (dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_Main.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_Main.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

    }
}
