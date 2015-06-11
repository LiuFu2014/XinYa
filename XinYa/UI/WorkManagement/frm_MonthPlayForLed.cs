using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.WorkManagement
{
    public partial class frm_MonthPlayForLed : Form
    {

        TB_User user;

        public frm_MonthPlayForLed(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_Main.AutoGenerateColumns = false;
            this.dgv_MonthPlan.AutoGenerateColumns = false;
            MaterialDataInit();
        }

        /// <summary>
        /// 物料初始化绑定
        /// </summary>
        public void MaterialDataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                var a = db.TB_MaterialInfo.ToList();
                foreach (var item in a)
                {
                    item.TB_ProcessRouteMReference.Load();
                    item.TB_UserReference.Load();
                    //item.TB_MonthPlanForLED.Load();
                }
                dgv_Main.DataSource = a;
            }
        }

        /// <summary>
        /// 通过主表的单击事件加载月度计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Main.CurrentRow != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    string id = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                    var a = db.TB_MaterialInfo.Single(p => p.TypeCode == id);
                    var b = a.TB_MonthPlanForLED.ToList();
                    foreach (var item in b)
                    {
                        item.TB_MaterialInfoReference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_MonthPlan.DataSource = b;
                }
            }
        }

        /// <summary>
        /// dgv_MonthPlan加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MonthPlan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_MonthPlan.Rows[e.RowIndex].DataBoundItem != null) && (dgv_MonthPlan.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_MonthPlan.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_MonthPlan.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_Main加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 保存月度计划数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //判断当前有无物料选定
            if (dgv_Main.CurrentRow != null)
            {
                //首先获取月份，与计划表中做一一比对，有则更新，没有则新建
                DateTime dt = dtp_MonthSelect.Value;
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //获取所有数据
                        string matcode = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                        var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matcode);
                        var list_month = mat.TB_MonthPlanForLED.ToList();
                        foreach (var item in list_month)
                        {
                            DateTime month = (DateTime)item.Month;
                            //存在
                            if (month.Year==dt.Year && month.Month == dt.Month)
                            {
                                item.MonthPlan = (int)num_Select.Value;
                                item.Remark = txt_Remark.Text;
                                db.SaveChanges();
                                MessageBox.Show("更新成功！");
                                return;
                            }
                        }
                        //没有匹配到，插入
                        TB_MonthPlanForLED monthplan = new TB_MonthPlanForLED();
                        monthplan.Month = dt;
                        monthplan.MonthPlan = (int)num_Select.Value;
                        monthplan.TB_MaterialInfo = db.TB_MaterialInfo.Single(p=>p.TypeCode==matcode);
                        monthplan.TB_User = db.TB_User.Single(p=>p.ID==user.ID);
                        monthplan.CreateTime = DateTime.Now;
                        monthplan.Remark = txt_Remark.Text;
                        db.TB_MonthPlanForLED.AddObject(monthplan);
                        db.SaveChanges();
                        MessageBox.Show("新建成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("与数据库交互出现特定于网络或数据的异常！详情请查看日志文件！");
                    }
                }
            }
            else
            {
                MessageBox.Show("没有泵体数据可供选择！");
            }

        }

        /// <summary>
        /// 发送报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LEDBaowen.Text))
            {
                MessageBox.Show("当前报文为空。");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //这里报文我始终只用一条数据来存所以这里只是牵涉到更新问题
                        var a = db.TB_LEDText.Single(p => p.ID == 1);
                        a.LEDText = txt_LEDBaowen.Text;
                        db.SaveChanges();
                        MessageBox.Show("发送成功！");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 清空报文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //这里报文我始终只用一条数据来存所以这里只是牵涉到更新问题
                    var a = db.TB_LEDText.Single(p => p.ID == 1);
                    a.LEDText = "";
                    db.SaveChanges();
                    MessageBox.Show("清空成功！");
                }
                catch (Exception)
                {
                    MessageBox.Show("清空失败！");
                }
            }
        }

        /// <summary>
        /// 物料表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MatRefresh_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            MaterialDataInit();
            Changeprobar(false);
        }

        /// <summary>
        /// 月度表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MonthPlanRefresh_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            if (dgv_Main.CurrentRow != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    string id = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                    var a = db.TB_MaterialInfo.Single(p => p.TypeCode == id);
                    var b = a.TB_MonthPlanForLED.ToList();
                    foreach (var item in b)
                    {
                        item.TB_MaterialInfoReference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_MonthPlan.DataSource = b;
                }
            }
            else
            {
                MessageBox.Show("请先选中物料信息。");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 月度表保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveMonthTable_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_MonthPlan.DataSource==null||dgv_MonthPlan.Rows.Count==0)
            {
                MessageBox.Show("当前没有可用于保存的数据！");
            }
            else
            {
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    for (int i = 0; i < dgv_MonthPlan.Rows.Count; i++)
                    {
                        int id = (int)dgv_MonthPlan.Rows[i].Cells["c_ID"].Value;
                        int monthplan = (int)dgv_MonthPlan.Rows[i].Cells["c_MonthPlan"].Value;
                        string remark = dgv_MonthPlan.Rows[i].Cells["c_Remark"].Value.ToString();
                        var a = db.TB_MonthPlanForLED.Single(p=>p.ID==id);
                        a.MonthPlan = monthplan;
                        a.Remark = remark;
                        db.SaveChanges();
                    }
                    MessageBox.Show("保存成功！");
                }
            }
            Changeprobar(false);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
