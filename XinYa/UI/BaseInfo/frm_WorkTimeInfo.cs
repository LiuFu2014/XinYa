using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;

namespace XinYa.UI.BaseInfo
{
    public partial class frm_WorkTimeInfo : Form
    {
        #region 字段属性

        public TB_User user { get; set; }

        #endregion 字段属性

        public frm_WorkTimeInfo(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            dgv_Main.AutoGenerateColumns = false;
            dgv_WorkTime.AutoGenerateColumns = false;
            MatDataInit();
        }

        /// <summary>
        /// 物料数据刷新
        /// </summary>
        public void MatDataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var a = db.TB_MaterialInfo.ToList();
                    foreach (var item in a)
                    {
                        item.TB_ProcessRouteMReference.Load();
                        item.TB_UserReference.Load();
                    }
                    dgv_Main.DataSource = a;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据初始化出现特定于网络的异常！");
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "设定工时");
                }
            }
        }

        /// <summary>
        /// 物料表单击事件，加载右边工时表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.CurrentRow != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //找出这条物料记录
                        string matID = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                        var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matID);
                        if (mat.TB_WorkTime.Count != 0)
                        {
                            //找出工时设定数据
                            var matworktime = mat.TB_WorkTime.ToList();
                            foreach (var item in matworktime)
                            {
                                item.TB_MaterialInfoReference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                                item.TB_UserReference.Load();
                            }
                            dgv_WorkTime.DataSource = matworktime;
                        }
                        else
                        {
                            var matworktime = db.TB_WorkTime.Where(p => p.Type == "0").ToList();
                            foreach (var item in matworktime)
                            {
                                item.TB_MaterialInfoReference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                                item.TB_UserReference.Load();
                            }
                            dgv_WorkTime.DataSource = matworktime;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载工时数据失败！详情请查看本地日志。");
                        //SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "设定工时");
                        LogExecute.WriteInfoLog("加载工时数据失败。详情：" + ex.ToString());
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 物料表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RefreshMaterial_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            MatDataInit();
            Changeprobar(false);
        }

        /// <summary>
        /// 工时数据表刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RefreshWorkTime_Click(object sender, EventArgs e)
        {
            //Changeprobar(true);
            //Application.DoEvents();
            //if (dgv_Main.CurrentRow != null)
            //{
            //    using (XinYaDBEntities db = new XinYaDBEntities())
            //    {
            //        try
            //        {
            //            //找出这条物料记录
            //            string matID = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
            //            var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matID);
            //            if (mat.TB_WorkTime.Count != 0)
            //            {
            //                //找出工时设定数据
            //                var matworktime = mat.TB_WorkTime.ToList();
            //                foreach (var item in matworktime)
            //                {
            //                    item.TB_MaterialInfoReference.Load();
            //                    item.TB_SecondWorkStationInfoReference.Load();
            //                    item.TB_UserReference.Load();
            //                }
            //                dgv_WorkTime.DataSource = matworktime;
            //            }
            //            else
            //            {
            //                var matworktime = db.TB_WorkTime.Where(p => p.Type == "0").ToList();
            //                foreach (var item in matworktime)
            //                {
            //                    item.TB_MaterialInfoReference.Load();
            //                    item.TB_SecondWorkStationInfoReference.Load();
            //                }
            //                dgv_WorkTime.DataSource = matworktime;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("加载工时数据失败！");
            //            SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "设定工时");
            //        }
            //    }
            //}
            //Changeprobar(false);
            Updatedgv_WorkTime();
        }

        /// <summary>
        /// 刷新工时数据
        /// </summary>
        public void Updatedgv_WorkTime()
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.CurrentRow != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //找出这条物料记录
                        string matID = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                        var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matID);
                        if (mat.TB_WorkTime.Count != 0)
                        {
                            //找出工时设定数据
                            var matworktime = mat.TB_WorkTime.ToList();
                            foreach (var item in matworktime)
                            {
                                item.TB_MaterialInfoReference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                                item.TB_UserReference.Load();
                            }
                            dgv_WorkTime.DataSource = matworktime;
                        }
                        else
                        {
                            var matworktime = db.TB_WorkTime.Where(p => p.Type == "0").ToList();
                            foreach (var item in matworktime)
                            {
                                item.TB_MaterialInfoReference.Load();
                                item.TB_SecondWorkStationInfoReference.Load();
                            }
                            dgv_WorkTime.DataSource = matworktime;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载工时数据失败！");
                        SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "设定工时");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 指定物料编码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (string.IsNullOrEmpty(txt_MatCode.Text))
            {
                MessageBox.Show("未输入产品编码");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_MaterialInfo.Where(p => p.TypeCode.Contains(txt_MatCode.Text)).ToList();//这里改为模糊查询
                        dgv_Main.DataSource = a;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("系统没有找到指定信息");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 保存工时数据更改(未写完)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.CurrentRow != null && dgv_WorkTime.DataSource != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //物料ID
                        string matcode = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                        //工时dgv数据
                        List<TB_WorkTime> list_workTime = (List<TB_WorkTime>)dgv_WorkTime.DataSource;
                        //找出这条记录
                        var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matcode);
                        //判断他有无工时数据
                        if (mat.TB_WorkTime.Count == 0)
                        {
                            try
                            {
                                //为0则表示么有，新增
                                foreach (var item in list_workTime)
                                {
                                    TB_WorkTime workTime = new TB_WorkTime();
                                    workTime.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == mat.TypeCode);
                                    workTime.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == item.TB_SecondWorkStationInfo.ID);
                                    workTime.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                    workTime.WorkTimePerMaterial = item.WorkTimePerMaterial;
                                    workTime.Remark = item.Remark;
                                    workTime.EditTime = DateTime.Now;
                                    db.TB_WorkTime.AddObject(workTime);
                                    db.SaveChanges();
                                }
                                MessageBox.Show("保存新增成功！");
                                //成功后刷新，避免数据异常
                                Updatedgv_WorkTime();
                                SystemLogHelper.WriteSysLogHelper("保存了工时数据。型号：" + matcode, user.ID, "工时数据信息管理");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("保存新增失败！");
                                SystemLogHelper.WriteSysLogHelper("保存更新失败。" + ex.ToString(), user.ID, "设定工时");
                                return;
                            }
                        }
                        else
                        {
                            //不为0则表示有，更新
                            foreach (var item in list_workTime)
                            {
                                try
                                {
                                    var workTime = db.TB_WorkTime.Single(p => p.ID == item.ID);
                                    //workTime.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == item.TB_MaterialInfo.TypeCode);
                                    //workTime.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == item.TB_SecondWorkStationInfo.ID);
                                    workTime.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                    workTime.WorkTimePerMaterial = item.WorkTimePerMaterial;
                                    workTime.Remark = item.Remark;
                                    workTime.EditTime = DateTime.Now;
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("保存更新失败！");
                                    SystemLogHelper.WriteSysLogHelper("保存更新失败。" + ex.ToString(), user.ID, "设定工时");
                                    return;
                                }
                            }
                            MessageBox.Show("保存更新成功！");
                            SystemLogHelper.WriteSysLogHelper("保存了工时数据。型号：" + matcode, user.ID, "工时数据信息管理");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("保存工时数据失败！");
                        //SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "设定工时");
                    }
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 取消退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// dgv加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkTime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkTime.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkTime.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkTime.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkTime.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv加载复杂类
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
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outport_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_WorkTime.RowCount <= 0 || dgv_WorkTime.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_WorkTime) == 0)
                {
                    MessageBox.Show("导出成功！");
                    SystemLogHelper.WriteSysLogHelper("导出了工时数据。", user.ID, "工时数据管理");
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