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

namespace XinYa.UI.User
{
    public partial class frm_LoginInOutRecord : Form
    {
        TB_User user;
        public frm_LoginInOutRecord(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            dgv_LoginRecordShow.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            //先检查时间
            if (dtp_BeginTime.Value.CompareTo(dtp_EndTime.Value)>0)
            {
                MessageBox.Show("开始时间不应晚于结束时间！");
            }
            else
            {
                Changeprobar(true);
                Application.DoEvents();
                using (XinYaDBEntities db=new XinYaDBEntities())
                {
                    try
                    {
                        //首先加载所有
                        List<TB_LoginRecord> list_LoginRecord = new List<TB_LoginRecord>();
                        var logins = db.TB_LoginRecord.ToList();
                        if (check_All.Checked)
                        {
                            foreach (var item in logins)
                            {
                                DateTime dt = item.LoginInTime == null ? item.LoginOutTime.Value : item.LoginInTime.Value;
                                if (dtp_BeginTime.Value.CompareTo(dt) < 0 && dtp_EndTime.Value.CompareTo(dt) > 0)
                                {
                                    item.TB_SecondWorkStationInfoReference.Load();
                                    item.TB_UserReference.Load();
                                    list_LoginRecord.Add(item);
                                }
                            }
                        }
                        else
                        {
                            if (check_PCClient.Checked)
                            {
                                foreach (var item in logins)
                                {
                                    DateTime dt = item.LoginInTime == null ? item.LoginOutTime.Value : item.LoginInTime.Value;
                                    if (dtp_BeginTime.Value.CompareTo(dt) < 0 && dtp_EndTime.Value.CompareTo(dt) > 0 && item.TB_SecondWorkStationInfo != null)
                                    {
                                        item.TB_SecondWorkStationInfoReference.Load();
                                        item.TB_UserReference.Load();
                                        list_LoginRecord.Add(item);
                                    }
                                }
                            }
                            else if (check_ServerClient.Checked)
                            {
                                foreach (var item in logins)
                                {
                                    DateTime dt = item.LoginInTime == null ? item.LoginOutTime.Value : item.LoginInTime.Value;
                                    if (dtp_BeginTime.Value.CompareTo(dt) < 0 && dtp_EndTime.Value.CompareTo(dt) > 0 && item.ServicePosition != null)
                                    {
                                        item.TB_SecondWorkStationInfoReference.Load();
                                        item.TB_UserReference.Load();
                                        list_LoginRecord.Add(item);
                                    }
                                }
                            }
                        }
                       
                        dgv_LoginRecordShow.DataSource = list_LoginRecord;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("查询出现异常，详情请查看日志。");
                        SystemLogHelper.WriteSysLogHelper("查询出现异常,详情：" + ex.ToString(), user.ID, "登录记录查询");
                    }
                }
                Changeprobar(false);
            }
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportData_Click(object sender, EventArgs e)
        {
            BllHelp.DataOutport(dgv_LoginRecordShow);
        }

        /// <summary>
        /// dgv_LoginRecordShow加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
