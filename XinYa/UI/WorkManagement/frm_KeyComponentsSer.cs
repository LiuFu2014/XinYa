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

namespace XinYa.UI.WorkManagement
{
    public partial class frm_KeyComponentsSer : Form
    {
        TB_User user;
        public frm_KeyComponentsSer(TB_User user)
        {
            InitializeComponent();
            dgv_BandingShow.AutoGenerateColumns = false;
            dgv_MatCode.AutoGenerateColumns = false;
            this.user = user;
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


        private void dgv_MatCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_MatCode.Rows[e.RowIndex].DataBoundItem != null) && (dgv_MatCode.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_MatCode.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_MatCode.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        private void dgv_BandingShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_BandingShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_BandingShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_BandingShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_BandingShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 物料型号选择助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectMat_Click(object sender, EventArgs e)
        {
            frm_MaterialSelectHelper matSelect = new frm_MaterialSelectHelper(4);
            matSelect.Tag = this;
            matSelect.ShowDialog();
        }

        /// <summary>
        /// 查询(加载指定泵到泵列表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            //首先判断是否指定的泵体条码。如果指定了泵体条码则会屏蔽掉其他所有条件
            if (check_MatCode.Checked)
            {
                //检查输入
                if (string.IsNullOrEmpty(txt_MatCode.Text))
                {
                    MessageBox.Show("请先输入泵体条码后再进行查询操作");
                }
                else
                {
                    //分组
                    string[] str_bengs = txt_MatCode.Text.Trim().TrimEnd(';').Split(';');
                    //List<TB_MatCodeKeyComLink> matCodeKeyComLink = new List<TB_MatCodeKeyComLink>();
                    List<TB_WorkDtl> list_workDtl = new List<TB_WorkDtl>();
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            #region MyRegion
                            //foreach (var item in str_bengs)
                            //{
                            //    if (db.TB_MatCodeKeyComLink.Count(p => p.MatCode == item) > 0)//是否有，防止异常
                            //    {
                            //        var a = db.TB_MatCodeKeyComLink.Where(p => p.MatCode == item).ToList();
                            //        foreach (var item2 in a)
                            //        {
                            //            matCodeKeyComLink.Add(item2);
                            //        }
                            //    }
                            //}
                            ////完成后
                            //if (matCodeKeyComLink.Count > 0)
                            //{
                            //    //如果有,则加载完成
                            //    foreach (var item in matCodeKeyComLink)
                            //    {
                            //        item.TB_KeyComponentsInfoReference.Load();
                            //        item.TB_UserReference.Load();
                            //    }
                            //}
                            ////赋值显示
                            //dgv_BandingInfoShow.DataSource = matCodeKeyComLink; 
                            #endregion

                            foreach (var item in str_bengs)
                            {
                                if (db.TB_WorkDtl.Count(p => p.MaterialCode == item && p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "A") > 0)//如果有
                                {
                                    var a = db.TB_WorkDtl.First(p => p.MaterialCode == item && p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "A");
                                    list_workDtl.Add(a);
                                }
                            }
                            foreach (var item in list_workDtl)
                            {
                                item.TB_ExceptionReference.Load();
                                item.TB_MaterialInfoReference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                                item.TB_WorkException.Load();
                                item.TB_WorkMainReference.Load();
                                item.TB_WorkMain.TB_SecondWorkStationInfoReference.Load();
                                item.TB_WorkMain.TB_SecondWorkStationInfo1Reference.Load();
                                item.TB_WorkMain.TB_User1Reference.Load();
                                item.TB_WorkMain.TB_UserReference.Load();
                                item.TB_UserReference.Load();
                            }
                            dgv_MatCode.DataSource = list_workDtl;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("查询出现问题！详情请查看日志！");
                            SystemLogHelper.WriteSysLogHelper("查询出现问题！详情:" + ex.ToString(), user.ID, "关键零部件信息查询与删除");
                        }
                    }
                }
            }
            else
            {
                List<TB_WorkDtl> list_workDtl = new List<TB_WorkDtl>();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        list_workDtl = db.TB_WorkDtl.Where(p => p.TB_WorkMain.TB_SecondWorkStationInfo.WorkStationCode == "A").ToList();
                        //是否指定了时间
                        if (check_Time.Checked)
                        {
                            //检查时间
                            if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value) > 0)
                            {
                                MessageBox.Show("开始时间不应晚于结束时间");
                            }
                            else
                            {
                                list_workDtl = list_workDtl.Where(p => p.CreateDate > dtp_BeginTime.Value && p.CreateDate < dtp_EndTime.Value).ToList();
                            }
                        }
                        else if (check_Haoduan.Checked)//号段
                        {
                            list_workDtl = list_workDtl.Where(p => p.MaterialCode.Substring(13, 10).CompareTo(txt_BeginCodeNum.Text) >= 0 && p.MaterialCode.Substring(13, 10).CompareTo(txt_EndCodeNum.Text) <= 0).ToList();
                        }
                        else if (check_MatType.Checked)//型号
                        {
                            //获取型号列表
                            string[] str_MatType = txt_MatType.Text.Trim().TrimEnd(';').Split(';');
                            list_workDtl = list_workDtl.Where(p => str_MatType.Contains(p.TB_MaterialInfo.TypeCode) == true).ToList();
                        }
                        //筛选后对其加载完全
                        foreach (var item in list_workDtl)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            item.TB_WorkException.Load();
                            item.TB_WorkMainReference.Load();
                            item.TB_WorkMain.TB_SecondWorkStationInfoReference.Load();
                            item.TB_WorkMain.TB_SecondWorkStationInfo1Reference.Load();
                            item.TB_WorkMain.TB_User1Reference.Load();
                            item.TB_WorkMain.TB_UserReference.Load();
                            item.TB_UserReference.Load();
                        }
                        dgv_MatCode.DataSource = list_workDtl;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现问题！详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("查询出现问题！详情:" + ex.ToString(), user.ID, "关键零部件信息查询");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_MatType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
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

        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_BeginCodeNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_EndCodeNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        /// <summary>
        /// dgv_MatCode单击事件，单击加载关键零部件信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MatCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_MatCode.CurrentRow != null && dgv_MatCode.CurrentRow.Cells["c_MatCode"].Value != null)
            {
                List<TB_MatCodeKeyComLink> matCodeKeyComLink = new List<TB_MatCodeKeyComLink>();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        string matCode = dgv_MatCode.CurrentRow.Cells["c_MatCode"].Value.ToString();
                        if (db.TB_MatCodeKeyComLink.Count(p => p.MatCode == matCode) > 0)//是否有，防止异常
                        {
                            var a = db.TB_MatCodeKeyComLink.Where(p => p.MatCode == matCode).ToList();
                            foreach (var item2 in a)
                            {
                                matCodeKeyComLink.Add(item2);
                            }
                        }
                        //完成后
                        if (matCodeKeyComLink.Count > 0)
                        {
                            //如果有,则加载完成
                            foreach (var item in matCodeKeyComLink)
                            {
                                item.TB_KeyComponentsInfoReference.Load();
                                item.TB_UserReference.Load();
                            }
                        }
                        //赋值显示
                        dgv_BandingShow.DataSource = matCodeKeyComLink;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现问题！详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("查询出现问题！详情:" + ex.ToString(), user.ID, "关键零部件信息查询与删除");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 删除选定的零部件信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_BandingShow.DataSource != null && dgv_BandingShow.Rows[0].Cells[0].Value != null)
            {
                if (MessageBox.Show("是否确定删除选定的关联信息", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        int sum = 0;
                        int succeed=0;
                        foreach (DataGridViewRow item2 in dgv_BandingShow.Rows)
                        {
                            //必须满足的条件
                            if (item2.Cells["c_ID"].Value != null && item2.Cells["c_Select"].Value != null && (bool)item2.Cells["c_Select"].Value == true)
                            {
                                try
                                {
                                    sum++;
                                    //记录下当前keycomID
                                    int bandingID = (int)item2.Cells["c_ID"].Value;
                                    var a = db.TB_MatCodeKeyComLink.First(p => p.ID == bandingID);
                                    db.TB_MatCodeKeyComLink.DeleteObject(a);
                                    db.SaveChanges();
                                    succeed++;
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show("删除出现问题！详情请查看日志！");
                                    SystemLogHelper.WriteSysLogHelper("删除出现问题！详情:" + ex.ToString(), user.ID, "关键零部件信息查询与删除");
                                }
                            }
                        }
                        MessageBox.Show("共删除" + sum.ToString() + "，成功" + succeed.ToString()+"条。失败记录请查看日志");
                    }
                }
            }
        }
    }
}
