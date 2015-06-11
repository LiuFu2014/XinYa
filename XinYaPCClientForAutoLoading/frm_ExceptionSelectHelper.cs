using System;
using System.Linq;
using System.Windows.Forms;

namespace XinYaPCClientForAutoLoading
{
    public partial class frm_ExceptionSelectHelper : Form
    {
        int flag = 0;

        /// <summary>
        /// 1.QC主程序的异常录入；2，调试录入异常信息使用
        /// </summary>
        /// <param name="flag"></param>
        public frm_ExceptionSelectHelper(int flag)
        {
            InitializeComponent();
            this.dgv_ExceptionInfo.AutoGenerateColumns = false;
            DataInit();
            this.flag = flag;
        }

        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //刷新异常数据
                    var exception = db.TB_Exception.ToList();
                    foreach (var item in exception)
                    {
                        item.TB_UserReference.Load();
                    }
                    dgv_ExceptionInfo.DataSource = exception;
                }
                catch { }
            }
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectLike_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ExceptionCode.Text))
            {
                MessageBox.Show("请输入物料编码！");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = from b in db.TB_Exception
                                where b.ExceptionCode.Contains(txt_ExceptionCode.Text)
                                select b;
                        dgv_ExceptionInfo.DataSource = a.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("没有查找到可用数据！");
                    }
                }
            }
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            #region 验证
            if (dgv_ExceptionInfo.DataSource==null||dgv_ExceptionInfo.CurrentRow==null)
            {
                MessageBox.Show("当前没有可用于确认的数据。");
                return;
            }
            #endregion
            if (flag==1)
            {
                frm_Main exc = (frm_Main)this.Tag;
                //循环遍历，追加文本
                //循环遍历
                if (dgv_ExceptionInfo.Rows.Count != 0 && dgv_ExceptionInfo.DataSource != null)
                {
                    //更改前清空原有异常编码
                    exc.txt_buhegebianma.Clear();
                    //for (int i = 0; i < dgv_ExceptionInfo.Rows.Count; i++)
                    //{
                        //if ((dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        //{
                        //    exc.txt_buhegebianma.AppendText(dgv_ExceptionInfo.Rows[i].Cells["c_ExceptionCode"].Value.ToString());
                        //    //这里只加载一条异常信息
                        //    break;
                        //}
                        exc.txt_buhegebianma.AppendText(dgv_ExceptionInfo.CurrentRow.Cells["c_ExceptionCode"].Value.ToString());
                    //}
                }
            }
            else if(flag==2)
            {
                frm_Exception exc = (frm_Exception)this.Tag;
                //循环遍历，追加文本
                //循环遍历
                if (dgv_ExceptionInfo.Rows.Count != 0 && dgv_ExceptionInfo.DataSource != null)
                {
                    //更改前清空原有异常编码
                    exc.txt_ExceptionCode.Clear();
                    //for (int i = 0; i < dgv_ExceptionInfo.Rows.Count; i++)
                    //{
                        //if ((dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        //{
                        //    exc.txt_ExceptionCode.AppendText(dgv_ExceptionInfo.Rows[i].Cells["c_ExceptionCode"].Value.ToString());
                        //    //这里只加载一条异常信息
                        //    break;
                        //}
                        exc.txt_ExceptionCode.AppendText(dgv_ExceptionInfo.CurrentRow.Cells["c_ExceptionCode"].Value.ToString());
                    //}
                }
            }
            
            this.Close();
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
    }
}