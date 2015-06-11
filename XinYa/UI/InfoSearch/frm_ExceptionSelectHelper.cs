using System;
using System.Linq;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_ExceptionSelectHelper : Form
    {
        public frm_ExceptionSelectHelper()
        {
            InitializeComponent();
            this.dgv_ExceptionInfo.AutoGenerateColumns = false;
            DataInit();
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

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            frm_ExceptionStatistics exc = (frm_ExceptionStatistics)this.Tag;
            //循环遍历，追加文本
            //循环遍历
            if (dgv_ExceptionInfo.Rows.Count != 0 && dgv_ExceptionInfo.DataSource != null)
            {
                for (int i = 0; i < dgv_ExceptionInfo.Rows.Count; i++)
                {
                    if ((dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_ExceptionInfo.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                    {
                        exc.txt_ExceptionSelect.AppendText(dgv_ExceptionInfo.Rows[i].Cells["c_ExceptionCode"].Value.ToString() + ";");
                    }
                }
            }
            this.Close();
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Serlike_Click(object sender, EventArgs e)
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
    }
}