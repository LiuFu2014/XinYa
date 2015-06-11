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
    public partial class frm_KeyComponentsBanding : Form
    {
        TB_User user;
        public frm_KeyComponentsBanding(TB_User user)
        {
            InitializeComponent();
            dgv_MatCode.AutoGenerateColumns = false;
            dgv_KeyComInfo.AutoGenerateColumns = false;
            DataInit(null);
            this.user = user;
        }

        /// <summary>
        /// 筛选泵体条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    List<TB_WorkDtl> list_bengs = new List<TB_WorkDtl>();
                    List<TB_WorkDtl> list_bengsForChange = new List<TB_WorkDtl>();
                    //是否指定了时间
                    if (check_Time.Checked)
                    {
                        //指定了时间
                        list_bengs = db.TB_WorkDtl.Where(p => p.CreateDate > dtp_BeginTime.Value && p.CreateDate < dtp_EndTime.Value && p.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SA").ToList();
                    }
                    else
                    {
                        //没有指定
                        list_bengs = db.TB_WorkDtl.Where(p => p.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SA").ToList();
                    }
                    //是否指定了号段
                    if (check_Haoduan.Checked)
                    {
                        //这里不检查起始号段是否晚于结束字段
                        //如果出现这种问题，dgv为空即可，考虑等于情况
                        foreach (var item in list_bengs)
                        {
                            if (item.MaterialCode.Substring(13, 10).CompareTo(txt_BeginCodeNum.Text) >= 0 && item.MaterialCode.Substring(13, 10).CompareTo(txt_EndCodeNum.Text) <= 0)
                            {
                                list_bengsForChange.Add(item);
                            }
                        }
                        list_bengs = list_bengsForChange;
                    }
                    //是否指定了型号
                    if (check_MatType.Checked)
                    {
                        list_bengsForChange.Clear();
                        string[] matarray = txt_MatType.Text.Trim().TrimEnd(';').Split(';');
                        foreach (var item in list_bengs)
                        {
                            //如果包含
                            if (matarray.Contains(item.MaterialCode.Substring(0, 12)))
                            {
                                list_bengsForChange.Add(item);
                            }
                        }
                        list_bengs = list_bengsForChange;
                    }
                    //筛选完成后将这个泵加载完全，然后赋值给dgv
                    foreach (var item in list_bengs)
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
                    //显示总数
                    lab_BengsAmount.Text = list_bengs.Count.ToString();
                    dgv_MatCode.DataSource = list_bengs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("筛选出现异常！详情请查看日志！");
                    SystemLogHelper.WriteSysLogHelper("筛选出现异常！详情:" + ex.ToString(), user.ID, "关键零部件信息绑定");
                }
            }
        }

        /// <summary>
        /// 关键零部件信息数据初始化,参数为空则加载全部
        /// </summary>
        /// <param name="keyComponentsName"></param>
        public void DataInit(string keyComponentsName)
        {
            if (keyComponentsName == null)
            {
                //加载全部
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        if (db.TB_KeyComponentsInfo.Count() == 0)
                        {
                            MessageBox.Show("当前没有可用的数据");
                        }
                        else
                        {
                            var a = db.TB_KeyComponentsInfo.ToList();
                            foreach (var item in a)
                            {
                                item.TB_UserReference.Load();
                            }
                            dgv_KeyComInfo.DataSource = a;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载数据出现异常，详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("加载数据出现异常,详情" + ex.ToString(), user.ID, "关键部件信息绑定");
                    }
                }
            }
            else
            {
                //模糊查询
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_KeyComponentsInfo.ToList();
                        List<TB_KeyComponentsInfo> list_keyComponents = new List<TB_KeyComponentsInfo>();
                        foreach (var item in a)
                        {
                            if (item.KeyComponentsName.Contains(keyComponentsName))
                            {
                                list_keyComponents.Add(item);
                            }
                        }
                        foreach (var item in list_keyComponents)
                        {
                            item.TB_UserReference.Load();
                        }
                        dgv_KeyComInfo.DataSource = list_keyComponents;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载数据出现异常，详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("加载数据出现异常,详情" + ex.ToString(), user.ID, "关键部件信息绑定");
                    }
                }
            }
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

        private void dgv_KeyComInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_KeyComInfo.Rows[e.RowIndex].DataBoundItem != null) && (dgv_KeyComInfo.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_KeyComInfo.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_KeyComInfo.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 只能输入数字（需要修改）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_BeginCodeNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
            //    e.Handled = true;
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        /// <summary>
        /// 只能输入数字（需要修改）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_EndCodeNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
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
        /// 物料型号选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectMat_Click(object sender, EventArgs e)
        {
            frm_MaterialSelectHelper materialSelectHelper = new frm_MaterialSelectHelper(2);
            materialSelectHelper.Tag = this;
            materialSelectHelper.ShowDialog();
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
        /// 泵体全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAllMat_Click(object sender, EventArgs e)
        {
            if (dgv_MatCode.DataSource != null && dgv_MatCode.RowCount > 1)
            {
                foreach (DataGridViewRow item in dgv_MatCode.Rows)
                {
                    if (item.Cells["c_MatCodeID"].Value != null)
                    {
                        item.Cells["c_MatSelect"].Value = true;
                    }
                }
            }
        }

        /// <summary>
        /// 关键零部件全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAllKeyCom_Click(object sender, EventArgs e)
        {
            if (dgv_KeyComInfo.DataSource != null && dgv_KeyComInfo.RowCount > 1)
            {
                foreach (DataGridViewRow item in dgv_KeyComInfo.Rows)
                {
                    if (item.Cells["c_ID"].Value != null)
                    {
                        item.Cells["c_KeyComSelect"].Value = true;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Banding_Click(object sender, EventArgs e)
        {
            //循环遍历mat，然后匹配KeyCom，存入关联表
            //先要判断一次mat是否符合规范
            if (dgv_MatCode.DataSource != null && dgv_KeyComInfo.DataSource != null)
            {
                Changeprobar(true);
                Application.DoEvents();
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {               
                        //循环mat表
                        foreach (DataGridViewRow item in dgv_MatCode.Rows)
                        {
                            if (item.Cells["c_MatCodeID"].Value != null && item.Cells["c_MatSelect"].Value != null && (bool)item.Cells["c_MatSelect"].Value)
                            //bool temp = (bool)item.Cells["c_MatSelect"].Value;
                            //if (temp)
                            {
                                //满足条件，循环KeyCOM
                                //先记录下泵体条码
                                string bengCode = item.Cells["c_MatCode"].Value.ToString();
                                foreach (DataGridViewRow item2 in dgv_KeyComInfo.Rows)
                                {
                                    //必须满足的条件
                                    if (item2.Cells["c_ID"].Value != null && item2.Cells["c_KeyComSelect"].Value != null && (bool)item2.Cells["c_KeyComSelect"].Value)
                                    {
                                        //记录下当前keycomID
                                        int keyComID = (int)item2.Cells["c_ID"].Value;
                                        //存在即更新
                                        if (db.TB_MatCodeKeyComLink.Count(p => p.MatCode == bengCode && p.TB_KeyComponentsInfo.ID == keyComID) > 0)
                                        {
                                            //理论上没有数据异常这里应该等于1
                                            //更新
                                            //找出这条记录，更新关联人和时间
                                            var a = db.TB_MatCodeKeyComLink.Single(p => p.MatCode == bengCode && p.TB_KeyComponentsInfo.ID == keyComID);
                                            a.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                            a.BandingDate = DateTime.Now;
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            //不存在即新增
                                            TB_MatCodeKeyComLink matKeyComLink = new TB_MatCodeKeyComLink();
                                            matKeyComLink.MatCode = bengCode;
                                            matKeyComLink.TB_KeyComponentsInfo = db.TB_KeyComponentsInfo.Single(p => p.ID == keyComID);
                                            matKeyComLink.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                            matKeyComLink.BandingDate = DateTime.Now;
                                            db.TB_MatCodeKeyComLink.AddObject(matKeyComLink);
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                        MessageBox.Show("绑定成功!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("泵体条码关联关键部件出现异常，程序在异常处中断，详情请查看日志！");
                        SystemLogHelper.WriteSysLogHelper("泵体条码关联关键部件出现异常，程序在异常处中断,详情" + ex.ToString(), user.ID, "关键部件信息绑定");
                    }
                }
                Changeprobar(false);
            }
            else
            {
                MessageBox.Show("没有可用于绑定的数据");
            }
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
    }
}
