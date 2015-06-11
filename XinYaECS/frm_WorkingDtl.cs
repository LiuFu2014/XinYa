using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XinYaECS
{
    public partial class frm_WorkingDtl : Form
    {
        string palletCode;
        int secondWorkStationID = 0;

        /// <summary>
        /// 阻挡器
        /// </summary>
        /// <param name="palletCode"></param>
        public frm_WorkingDtl(string palletCode)
        {
            InitializeComponent();
            this.dgv_WorkDtl.AutoGenerateColumns = false;
            this.dgv_WorkMain.AutoGenerateColumns = false;
            this.dgv_LoginRecordShow.AutoGenerateColumns = false;
            this.palletCode = palletCode;
            DataInit();
        }

        /// <summary>
        /// 工位
        /// </summary>
        /// <param name="palletCode"></param>
        /// <param name="secondWorkStation"></param>
        public frm_WorkingDtl(string palletCode, int secondWorkStationID)
        {
            InitializeComponent();
            this.dgv_WorkDtl.AutoGenerateColumns = false;
            this.dgv_WorkMain.AutoGenerateColumns = false;
            this.dgv_LoginRecordShow.AutoGenerateColumns = false;
            this.palletCode = palletCode;
            this.secondWorkStationID = secondWorkStationID;
            DataInit();
        }

        #region 数据加载

        /// <summary>
        /// 数据初始
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                #region 任务
                if (!string.IsNullOrEmpty(palletCode))
                {
                    try
                    {
                        var workMain = db.TB_WorkMain.Single(p => p.PalletCode == palletCode && p.IsCommit == true && p.Finished == "0");
                        workMain.TB_UserReference.Load();
                        List<TB_WorkDtl> list_workDtl = new List<TB_WorkDtl>();
                        if (workMain.TB_WorkDtl.Count > 0)
                        {
                            list_workDtl = workMain.TB_WorkDtl.ToList();
                        }
                        foreach (var item in list_workDtl)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_SecondWorkStationInfoReference.Load();
                            //item.TB_UserReference.Load();
                        }
                        List<TB_WorkMain> list_WorkMain = new List<TB_WorkMain>();
                        list_WorkMain.Add(workMain);
                        dgv_WorkMain.DataSource = list_WorkMain;
                        dgv_WorkDtl.DataSource = list_workDtl;

                    }
                    catch (Exception ex)
                    {
                        LogExecute.WriteDBExceptionLog(ex);
                    }
                }
                #endregion

                #region 登录记录

                if (secondWorkStationID != 0)
                {
                    try
                    {
                        List<TB_LoginRecord> list_loginRecord = new List<TB_LoginRecord>();
                        var loginRecord = db.TB_LoginRecord.Where(p => p.SecondWorkStationID == secondWorkStationID);
                        foreach (var item in loginRecord)
                        {
                            DateTime dt = item.LoginInTime == null ? item.LoginOutTime.Value : item.LoginInTime.Value;
                            if (dt.Date == DateTime.Now.Date) //今天的
                            {
                                item.TB_SecondWorkStationInfoReference.Load();
                                item.TB_UserReference.Load();
                                list_loginRecord.Add(item);
                            }
                        }
                        dgv_LoginRecordShow.DataSource = list_loginRecord;
                    }
                    catch (Exception ex)
                    {
                        LogExecute.WriteDBExceptionLog(ex);
                    }
                }

                #endregion
            }
        }

        #endregion

        #region Formatting

        private void dgv_WorkMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkMain.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkMain.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkMain.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkMain.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        private void dgv_WorkDtl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkDtl.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkDtl.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkDtl.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkDtl.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        private void dgv_LoginRecordShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_LoginRecordShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_LoginRecordShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_LoginRecordShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_LoginRecordShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
