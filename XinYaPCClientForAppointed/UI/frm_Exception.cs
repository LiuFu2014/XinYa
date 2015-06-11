using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYaPCClientForAppointed.DAL;

namespace XinYaPCClientForAppointed.UI
{
    public partial class frm_Exception : Form
    {
        TB_User user;
        TB_WorkDtl workDtl;
        List<TB_Exception> exceptions = new List<TB_Exception>();
        int secondWorkStationID;

        public frm_Exception(TB_WorkDtl workDtl, List<TB_Exception> exceptions, TB_User user, int secondWorkStationID)
        {
            InitializeComponent();
            this.workDtl = workDtl;
            this.exceptions = exceptions;
            this.user = user;
            this.secondWorkStationID = secondWorkStationID;
            //this.cbx_ExceptionSelect.DataSource = exceptions;
            //this.cbx_ExceptionSelect.DisplayMember = "ExceptionCode";
            //this.cbx_ExceptionSelect.ValueMember = "ID";
            lab_workDtlID.Text = workDtl.ID.ToString();
            lab_PalletCode.Text = workDtl.PalletCode;
            lab_MaterialCode.Text = workDtl.MaterialCode;
            lab_EditTime.Text = workDtl.EditTime.ToString();
        }

        /// <summary>
        /// 加载异常描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_ExceptionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //txt_ExceptionShow.Text = exceptions.First(p => p.ID == Convert.ToInt32(cbx_ExceptionSelect.SelectedValue.ToString())).ExceptionText.ToString();
                txt_ExceptionShow.Text = exceptions.First(p => p.ExceptionCode == txt_ExceptionCode.Text).ExceptionText.ToString();

            }
            catch (Exception)
            {

            }
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
        /// 保存更改(同时保存进workException表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                TB_WorkDtl wm;
                //int id = Convert.ToInt32(cbx_ExceptionSelect.SelectedValue.ToString());
                string exceptionCode = txt_ExceptionCode.Text;
                try
                {
                    //先找出这条任务
                    wm = db.TB_WorkDtl.First(p => p.ID == workDtl.ID);
                    //给这条任务加载外键                 
                    wm.TB_Exception = db.TB_Exception.First(p => p.ExceptionCode==exceptionCode);
                    wm.EditTime = System.DateTime.Now;
                    wm.TB_User = db.TB_User.First(p => p.ID == user.ID);
                    wm.IsException = true;
                    //11月4日加入对异常产生的工位记录
                    wm.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p=>p.ID==secondWorkStationID);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("给子任务加载异常信息失败！如果异常依旧，请联系管理员！");
                    db.Dispose();
                    return;
                }
               
                //==============================================
                //往workexception表中加入数据
                //先判断当前子任务是否有对应的工作异常记录
                //产生异常就需要下线维修，而维修后重新上线的泵又会分配另一条新子任务，所以这里的子任务号不会重复
                try
                {
                    var a = db.TB_WorkException.First(p => p.WorkDtlID == wm.ID);
                    //有则更新
                    a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                    a.TB_Exception = db.TB_Exception.First(p=>p.ExceptionCode==exceptionCode);
                    a.TB_User = db.TB_User.First(p => p.ID == user.ID);
                    a.Date = System.DateTime.Now;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    //没有则插入
                    try
                    {
                        TB_WorkException workException = new TB_WorkException();
                        workException.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        workException.TB_WorkDtl = db.TB_WorkDtl.First(p => p.ID == workDtl.ID);
                        workException.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                        workException.TB_Exception = db.TB_Exception.First(p => p.ExceptionCode == exceptionCode);
                        workException.Date = System.DateTime.Now;
                        db.TB_WorkException.AddObject(workException);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("保存异常信息失败！请联系管理员！");
                        db.Dispose();
                        return;
                    }               
                }
                //MessageBox.Show("保存成功！");
                //成功后不再提示，直接关闭本窗口，提高效率
                this.Close();
            }
        }

        /// <summary>
        /// 异常选择助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectExceptionCode_Click(object sender, EventArgs e)
        {
            frm_ExceptionSelectHelper exchelper = new frm_ExceptionSelectHelper(2);
            exchelper.Tag = this;
            exchelper.ShowDialog();
        }

        /// <summary>
        /// 当异常文本框中有异常代码的时候，对详细信息进行一个加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_ExceptionCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ExceptionCode.Text))
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var exception = db.TB_Exception.First(p => p.ExceptionCode == txt_ExceptionCode.Text);
                        txt_ExceptionShow.Text = exception.ExceptionText;
                    }
                    catch (Exception ex)
                    {
                        txt_ExceptionShow.Text = "";
                        MessageBox.Show("加载异常描述的时候出现异常，具体请查看本地日志");
                        LogExecute.WriteExceptionLog("加载异常描述", ex);
                    }
                } 
            }
        }
    }
}
