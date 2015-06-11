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
using System.IO;

namespace XinYa.UI.BaseInfo
{
    public partial class frm_MaterialInfo : Form
    {
        TB_User user;
        List<TB_MaterialInfo> list_MaterialInfo;

        public frm_MaterialInfo(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_Main.AutoGenerateColumns = false;
            DataInit();
        }

        /// <summary>
        /// 数据和dgv显示初始化
        /// </summary>
        public void DataInit()
        {
            lab_Statustext.Text = "刷新中...";
            Application.DoEvents();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_MaterialInfo = db.TB_MaterialInfo.ToList();
                    foreach (var item in list_MaterialInfo)
                    {
                        item.TB_UserReference.Load();
                        item.TB_ProcessRouteMReference.Load();
                    }
                    dgv_Main.DataSource = list_MaterialInfo;
                }
                catch (Exception)
                {

                    MessageBox.Show("当前系统中没有泵体信息！");
                }

            }
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 数据和dgv显示初始化(重载)
        /// </summary>
        public void DataInit(string materialCode)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_MaterialInfo = db.TB_MaterialInfo.Where(p => p.TypeCode == materialCode).ToList();
                    dgv_Main.DataSource = list_MaterialInfo;
                }
                catch (Exception)
                {
                    MessageBox.Show("没有找到指定型号的信息！");
                }

            }
        }

        /// <summary>
        /// 新增VE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            lab_Statustext.Text = "新增模式";
            Application.DoEvents();
            frm_MaterialInfoVEDtl matdtl = new frm_MaterialInfoVEDtl(user, "", 1);
            matdtl.ShowDialog();
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 新增BQ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddBQ_Click(object sender, EventArgs e)
        {
            lab_Statustext.Text = "新增模式";
            Application.DoEvents();
            frm_MaterialInfoBQDtl matdtl = new frm_MaterialInfoBQDtl(user, "", 1);
            matdtl.ShowDialog();
            lab_Statustext.Text = "就绪";
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            //先判断有没有选中行
            if (dgv_Main.CurrentRow == null)
            {
                MessageBox.Show("当前没有选中任何数据！请重新选择数据所在行，再进行操作！");
                return;
            }
            //判断类别
            //string matclass=dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString();
            if (dgv_Main.CurrentRow.Cells["c_Class"].Value == null)
            {
                MessageBox.Show("该物料没有大类区别，无法编辑！");
                return;
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "VE")
            {
                lab_Statustext.Text = "编辑模式";
                Application.DoEvents();
                frm_MaterialInfoVEDtl matdtl = new frm_MaterialInfoVEDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 2);
                matdtl.ShowDialog();
                lab_Statustext.Text = "就绪";
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "BQ")
            {
                lab_Statustext.Text = "编辑模式";
                Application.DoEvents();
                frm_MaterialInfoBQDtl matdtl = new frm_MaterialInfoBQDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 2);
                matdtl.ShowDialog();
                lab_Statustext.Text = "就绪";
            }

        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_View_Click(object sender, EventArgs e)
        {
            //先判断有没有选中行
            if (dgv_Main.CurrentRow == null)
            {
                MessageBox.Show("当前没有选中任何数据！请重新选择数据所在行，再进行操作！");
                return;
            }
            //string matclass=dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString();
            if (dgv_Main.CurrentRow.Cells["c_Class"].Value == null)
            {
                MessageBox.Show("该物料没有大类区别，无法查看！");
                return;
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "VE")
            {
                lab_Statustext.Text = "查看模式";
                Application.DoEvents();
                frm_MaterialInfoVEDtl matdtl = new frm_MaterialInfoVEDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 3);
                matdtl.ShowDialog();
                lab_Statustext.Text = "就绪";
            }
            else if (dgv_Main.CurrentRow.Cells["c_Class"].Value.ToString() == "BQ")
            {
                lab_Statustext.Text = "查看模式";
                Application.DoEvents();
                frm_MaterialInfoBQDtl matdtl = new frm_MaterialInfoBQDtl(user, dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString(), 3);
                matdtl.ShowDialog();
                lab_Statustext.Text = "就绪";
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //先判断有没有选中行
            if (dgv_Main.CurrentRow == null)
            {
                MessageBox.Show("当前没有选中任何数据！请重新选择数据所在行，再进行操作！");
                return;
            }
            if (MessageBox.Show("确认删除？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    string c_TypeCode = dgv_Main.CurrentRow.Cells["c_TypeCode"].Value.ToString();
                    TB_MaterialInfo mat = db.TB_MaterialInfo.Single(p => p.TypeCode == c_TypeCode);
                    string temp=mat.TypeCode;
                    db.TB_MaterialInfo.DeleteObject(mat);
                    db.SaveChanges();
                    MessageBox.Show("删除成功！");
                    SystemLogHelper.WriteSysLogHelper("删除了一条物料型号数据。物料编码：" + temp, user.ID, "物料信息管理");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！该型号在系统中存在多条数据记录关联，无法删除！");
                    LogExecute.WriteInfoLog("删除数据失败！操作者：" + user.UserName + ",来源：物料信息管理。详情：" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            DataInit();
            Changeprobar(false);
        }

        /// <summary>
        /// 指定产品编码查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaterialCode.Text))
            {
                MessageBox.Show("未输入产品编码");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        var a = db.TB_MaterialInfo.Where(p => p.TypeCode.Contains(txt_MaterialCode.Text)).ToList();
                        dgv_Main.DataSource = a;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("系统没有找到指定信息");
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
        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_Main.RowCount <= 0 || dgv_Main.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_Main) == 0)
                {
                    MessageBox.Show("导出成功！");
                    SystemLogHelper.WriteSysLogHelper("导出物料信息数据。",user.ID,"物料信息管理");
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

        /*
        /// <summary>
        /// 测试,存入image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string fileName = this.openFileDialog1.FileName;
                BinaryReader reader = null;
                FileStream myfilestream = new FileStream(fileName, FileMode.Open);
                try
                {
                    DateTime dt1 = System.DateTime.Now;
                    reader = new BinaryReader(myfilestream); 
                    byte[] image = reader.ReadBytes((int)myfilestream.Length);//存储图片到数组中。
                    using (XinYaDBEntities db=new XinYaDBEntities())
                    {
                        TB_MaterialInfo m=db.TB_MaterialInfo.First();
                        m.Photo = image;
                        db.SaveChanges();
                    }
                    DateTime dt2 = DateTime.Now;
                    TimeSpan s = dt2 - dt1;
                    label1.Text = s.ToString();

                }
                catch
                {
                    MessageBox.Show("失败！");
                }
                myfilestream.Dispose();
            }
        }

        /// <summary>
        /// 测试，读取image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt1 = System.DateTime.Now;
            using (XinYaDBEntities db=new XinYaDBEntities())
            {
                var a = db.TB_MaterialInfo.First();
                MemoryStream mStream = new MemoryStream();
                mStream.Write(a.Photo, 0, a.Photo.Length);
                mStream.Flush();
                Bitmap img = new Bitmap(mStream);
                pictureBox1.Image = img;  
            }
            DateTime dt2 = DateTime.Now;
            TimeSpan s = dt2 - dt1;
            label1.Text = s.ToString();
        }
         * */

    }
}
