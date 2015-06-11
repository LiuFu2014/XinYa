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
    public partial class frm_WorkTast : Form
    {

        #region 字段属性

        List<TB_WorkMain> list_workMain;
        TB_User user;

        #endregion

        public frm_WorkTast(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.tool_Main.BackColor = Color.WhiteSmoke;
            this.status_Main.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.dgv_WorkM.AutoGenerateColumns = false;
            this.dgv_WorkP.AutoGenerateColumns = false;
            Init();
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
                    list_workMain = db.TB_WorkMain.Where(p => p.Finished == "0").ToList();
                    foreach (var item in list_workMain)
                    {
                        //创建者
                        item.TB_UserReference.Load();
                        //完成者
                        item.TB_User1Reference.Load();
                        //子任务
                        item.TB_WorkDtl.Load();
                        item.TB_SecondWorkStationInfoReference.Load();
                    }
                    dgv_WorkM.DataSource = list_workMain;
                }
                catch (Exception)
                {
                    MessageBox.Show("当前没有未完成任务数据或获取数据失败！");
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 手动完成任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CompliteTask_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("建议手动完成任务只用在确认为‘未在自动完成任务时’使用，如果不在此种情况下使用，会带来未知的异常。是否继续？", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgv_WorkM.CurrentRow == null)
                {
                    MessageBox.Show("当前没有可用数据！");
                }
                else
                {
                    using (XinYaDBEntities db=new XinYaDBEntities())
                    {
                        try
                        {
                            //获取当前任务
                            int workid = (int)dgv_WorkM.CurrentRow.Cells["c_WorkID"].Value;
                            var a = db.TB_WorkMain.Single(p=>p.WorkID==workid);
                            //判断是否已经自动过账完成
                            if (a.Finished=="1")
                            {
                                MessageBox.Show("该条任务已经完成，请刷新后查看！");
                            }
                            else
                            {
                                //1表示完成
                                a.Finished = "1";
                                a.TB_User1 = db.TB_User.Single(p => p.ID == user.ID);
                                a.FinishedDate = DateTime.Now;
                                a.FinishedType = "手动";
                                db.SaveChanges();
                                MessageBox.Show("手动完成成功！");
                            }                           
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("当前没有找到该条任务。");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 主表单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_WorkM.CurrentRow==null||dgv_WorkM.RowCount==0)
            {
                return;
            }
            else
            {
                try
                {
                    int id = (int)dgv_WorkM.CurrentRow.Cells["c_WorkID"].Value;
                    var workM = list_workMain.Single(p => p.WorkID == id);
                    dgv_WorkP.DataSource = workM.TB_WorkDtl.ToList();
                }
                catch (Exception)
                { }
            }
        }

        /// <summary>
        /// dgv_WorkM加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkM.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkM.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkM.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkM.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_WorkP加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkP.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkP.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkP.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkM.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
