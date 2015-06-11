using System;
using System.Linq;
using System.Windows.Forms;
using XinYa.DAL;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_MaterialSelectHelper : Form
    {
        private int flag = 0;

        public frm_MaterialSelectHelper(int flag)
        {
            InitializeComponent();
            this.dgv_MatSelect.AutoGenerateColumns = false;
            this.flag = flag;
            DataInit();
        }

        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    var list_MaterialInfo = db.TB_MaterialInfo.ToList();
                    foreach (var item in list_MaterialInfo)
                    {
                        item.TB_UserReference.Load();
                        item.TB_ProcessRouteMReference.Load();
                    }
                    dgv_MatSelect.DataSource = list_MaterialInfo;
                }
                catch (Exception)
                {
                    MessageBox.Show("当前系统中没有泵体信息！");
                }
            }
        }

        /// <summary>
        /// 确认回传值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                frm_QualifiedRateStatistics com = (frm_QualifiedRateStatistics)this.Tag;
                //回传前先清空，以免数据干扰
                //com.txt_MatSelect.Text = "";
                //循环遍历
                if (dgv_MatSelect.Rows.Count != 0 && dgv_MatSelect.DataSource != null)
                {
                    for (int i = 0; i < dgv_MatSelect.Rows.Count; i++)
                    {
                        if ((dgv_MatSelect.Rows[i].Cells["c_Select"].Value == null ? "false" : dgv_MatSelect.Rows[i].Cells["c_Select"].Value.ToString()) == "true")
                        {
                            com.txt_Matcode.AppendText(dgv_MatSelect.Rows[i].Cells["c_TypeCode"].Value.ToString() + ";");
                        }
                    }
                }
            }
            //this.Close();
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

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaterialCode.Text))
            {
                MessageBox.Show("请输入物料编码！");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = from b in db.TB_MaterialInfo
                                where b.TypeCode.Contains(txt_MaterialCode.Text)
                                select b;
                        dgv_MatSelect.DataSource = a.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("没有查找到可用数据！");
                    }
                }
            }
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_MaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }
    }
}