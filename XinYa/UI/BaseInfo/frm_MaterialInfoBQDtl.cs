using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.DAL;
using System.IO;
using XinYa.BLL;

namespace XinYa.UI.BaseInfo
{
    public partial class frm_MaterialInfoBQDtl : Form
    {

        #region 字段属性

        private TB_User user;

        /// <summary>
        ///  flag为模式选择，1：新增模式，2：编辑模式，3：查看模式
        /// </summary>
        int flag;

        string materialCode;

        /// <summary>
        /// 图片字节数组
        /// </summary>
        byte[] image;
        #endregion

        /// <summary>
        /// flag为模式选择，1：新增模式，2：编辑模式，3：查看模式
        /// </summary>
        /// <param name="user"></param>
        /// <param name="materialCode"></param>
        /// <param name="flag"></param>
        public frm_MaterialInfoBQDtl(TB_User user, string materialCode, int flag)
        {
            InitializeComponent();
            this.user = user;
            this.flag = flag;
            this.materialCode = materialCode;

            Init(flag);
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <param name="flag"></param>
        public void Init(int flag)
        {
            OpenOrCloseProsbar(true);
            Application.DoEvents();

            if (flag == 1)//新增
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    var a = db.TB_ProcessRouteM.ToList();
                    cb_Route.DataSource = a;
                    cb_Route.DisplayMember = "ProcessRouteMCode";
                    cb_Route.ValueMember = "ID";
                    cb_Route.SelectedIndex = 0;
                }
            }
            else if (flag == 2)//编辑
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    TB_MaterialInfo mat;
                    List<TB_ProcessRouteM> list_route;
                    try
                    {
                        mat = db.TB_MaterialInfo.Single(p => p.TypeCode == materialCode);
                        list_route = db.TB_ProcessRouteM.ToList();
                    }
                    catch (Exception)
                    {
                        mat = null;
                        list_route = null;
                        MessageBox.Show("访问数据库失败！");
                    }
                    if (mat != null)
                    {
                        TextInit(mat, list_route);
                        //将物料编码只读
                        txt_Chanpingbianma.ReadOnly = true;
                    }

                }
            }
            else if (flag == 3)//查看
            {
                //确定,导入图片按钮隐藏
                btn_Confirm.Visible = false;
                btn_ImportPicture.Visible = false;
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    TB_MaterialInfo mat;
                    try
                    {
                        mat = db.TB_MaterialInfo.Single(p => p.TypeCode == materialCode);
                        mat.TB_ProcessRouteMReference.Load();
                    }
                    catch (Exception)
                    {
                        mat = null;
                        MessageBox.Show("访问数据库失败！");
                    }
                    if (mat != null)
                    {
                        TextInit(mat, null);
                        //将所有txt设置为只读
                        foreach (Control item in tlp_Main.Controls)
                        {
                            if (item.Name.Contains("txt_"))
                            {
                                TextBox t = (TextBox)item;
                                t.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("系统异常，请关闭当前窗体并重试！");
            }
            OpenOrCloseProsbar(false);
        }

        /// <summary>
        /// 文本框初始化(下拉框初始化)
        /// </summary>
        /// <param name="mat"></param>
        public void TextInit(TB_MaterialInfo mat, List<TB_ProcessRouteM> route)
        {
            if (mat != null)
            {
                #region 工艺路线处理
                if (route == null)
                {
                    //等于空为查看
                    cb_Route.Items.Add(mat.TB_ProcessRouteM.ProcessRouteMCode);
                    cb_Route.SelectedIndex = 0;
                }
                else
                {
                    cb_Route.DataSource = route;
                    cb_Route.DisplayMember = "ProcessRouteMCode";
                    cb_Route.ValueMember = "ID";
                    cb_Route.SelectedIndex = 0;
                }
                #endregion

                #region 通用赋值

                txt_Chanpingbianma.Text = mat.TypeCode;
                txt_MaterialName.Text = mat.MaterialName;
                txt_Peitaochuangjia.Text = mat.Peitaochuangjia;
                txt_Zhusai.Text = mat.Zhusai;
                txt_Dinghuobianhao.Text = mat.Dinghuobianhao;
                txt_Yuxingcheng.Text = mat.Yuxingcheng;
                txt_BQMohehouzhuanggaiban.Text = mat.BQMohehouzhuanggaiban;
                txt_Chuyoufa.Text = mat.Chuyoufa;
                txt_BQShuyoubeng.Text = mat.BQShuyoubeng;
                txt_BQShuyoubengzhijia.Text = mat.BQShuyoubengzhijia;
                txt_BQZhuanghougaiban.Text = mat.BQZhuanghougaiban;
                txt_BQTingchelaxianzhijia.Text = mat.BQTingchelaxianzhijia;
                txt_BQShigaoyajinzuohumao.Text = mat.BQShigaoyajinzuohumao;
                txt_Zhuangfujian.Text = mat.Zhuangfujian;
                txt_Remark.Text = mat.Remark;

                //图片
                try
                {
                    image = mat.Photo;
                    MemoryStream mStream = new MemoryStream();
                    mStream.Write(image, 0, image.Length);
                    mStream.Flush();
                    Bitmap img = new Bitmap(mStream);
                    pb_BengPicture.Image = img;
                }
                catch (Exception)
                {
                }

                #endregion

                #region 转速

                txt_Zhuangsu1.Text = mat.Zhuangsu1;
                txt_Zhuangsu2.Text = mat.Zhuangsu2;
                txt_Zhuangsu3.Text = mat.Zhuangsu3;
                txt_Zhuangsu4.Text = mat.Zhuangsu4;
                txt_Zhuangsu5.Text = mat.Zhuangsu5;
                txt_Zhuangsu6.Text = mat.Zhuangsu6;
                txt_Zhuangsu7.Text = mat.Zhuangsu7;
                txt_Zhuangsu8.Text = mat.Zhuangsu8;
                txt_Zhuangsu9.Text = mat.Zhuangsu9;
                txt_Zhuangsu10.Text = mat.Zhuangsu10;
                //需要加入校正转速
                txt_Jiaozhengjieshuzhuansu.Text = mat.BQJiaozhengzhuangsu;

                #endregion

                #region 油量

                txt_Pingjunyouliang1.Text = mat.Pingjunyouliang1;
                txt_Pingjunyouliang2.Text = mat.Pingjunyouliang2;
                txt_Pingjunyouliang3.Text = mat.Pingjunyouliang3;
                txt_Pingjunyouliang4.Text = mat.Pingjunyouliang4;
                txt_Pingjunyouliang5.Text = mat.Pingjunyouliang5;
                txt_Pingjunyouliang6.Text = mat.Pingjunyouliang6;
                txt_Pingjunyouliang7.Text = mat.Pingjunyouliang7;

                #endregion

                #region 齿杆行程

                txt_BQCiganxingchen1.Text = mat.BQCiganxingchen1;
                txt_BQCiganxingchen2.Text = mat.BQCiganxingchen2;
                txt_BQCiganxingchen3.Text = mat.BQCiganxingchen3;
                txt_BQCiganxingchen4.Text = mat.BQCiganxingchen4;
                txt_BQCiganxingchen5.Text = mat.BQCiganxingchen5;
                txt_BQCiganxingchen6.Text = mat.BQCiganxingchen6;
                txt_BQCiganxingchen7.Text = mat.BQCiganxingchen7;

                #endregion

                #region 气压

                txt_Qiya1.Text = mat.Qiya1;
                txt_Qiya2.Text = mat.Qiya2;
                txt_Qiya3.Text = mat.Qiya3;
                txt_Qiya4.Text = mat.Qiya4;
                txt_Qiya5.Text = mat.Qiya5;
                txt_Qiya6.Text = mat.Qiya6;
                txt_Qiya7.Text = mat.Qiya7;

                #endregion

                #region 均匀度

                txt_Junyundu1.Text = mat.Junyundu1;
                txt_Junyundu2.Text = mat.Junyundu2;
                txt_Junyundu3.Text = mat.Junyundu3;
                txt_Junyundu4.Text = mat.Junyundu4;
                txt_Junyundu5.Text = mat.Junyundu5;
                txt_Junyundu6.Text = mat.Junyundu6;
                txt_Junyundu7.Text = mat.Junyundu7;

                #endregion

                #region 工况备注

                txt_BQRemark1.Text = mat.BQRemark1;
                txt_BQRemark2.Text = mat.BQRemark2;
                txt_BQRemark3.Text = mat.BQRemark3;
                txt_BQRemark4.Text = mat.BQRemark4;
                txt_BQRemark5.Text = mat.BQRemark5;
                txt_BQRemark6.Text = mat.BQRemark6;
                txt_BQRemark7.Text = mat.BQRemark7;

                #endregion

            }
        }

        /// <summary>
        /// 图片导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PicImport_Click(object sender, EventArgs e)
        {
            OpenOrCloseProsbar(true);
            Application.DoEvents();
            //--------------------
            openfile_ImporPic.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (openfile_ImporPic.ShowDialog() == DialogResult.OK)
            {
                string fileName = this.openfile_ImporPic.FileName;
                BinaryReader reader = null;
                FileStream myfilestream = new FileStream(fileName, FileMode.Open);
                try
                {
                    //DateTime dt1 = System.DateTime.Now;
                    reader = new BinaryReader(myfilestream);
                    image = reader.ReadBytes((int)myfilestream.Length);//存储图片到数组中。
                    //这种方法报内存不足的异常
                    // pb_BengPicture.Image = Image.FromFile(fileName);

                    MemoryStream mStream = new MemoryStream();
                    mStream.Write(image, 0, image.Length);
                    mStream.Flush();
                    Bitmap img = new Bitmap(mStream);
                    pb_BengPicture.Image = img;

                    //DateTime dt2 = DateTime.Now;
                    //TimeSpan s = dt2 - dt1;
                    //label1.Text = s.ToString();

                }
                catch
                {
                    MessageBox.Show("导入图片失败！");
                }
                myfilestream.Dispose();
            }
            OpenOrCloseProsbar(false);
        }

        /// <summary>
        /// true显示当前处理，false则不显示
        /// </summary>
        /// <param name="flag"></param>
        public void OpenOrCloseProsbar(bool flag)
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
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            OpenOrCloseProsbar(true);
            Application.DoEvents();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                if (flag == 1)//新增
                {
                    try
                    {
                        TB_MaterialInfo mat = new TB_MaterialInfo();
                        //赋值
                        if (string.IsNullOrEmpty(mat.TypeCode = txt_Chanpingbianma.Text) || cb_Route.SelectedValue == null)
                        {
                            MessageBox.Show("产品编码（型号）不能为空！工艺路线也不能为空！");
                            db.Dispose();
                            return;
                        }

                        #region 工艺路线赋值

                        mat.TB_ProcessRouteM = db.TB_ProcessRouteM.Single(p => p.ID == (int)cb_Route.SelectedValue);

                        #endregion

                        #region 通用赋值

                        mat.TypeCode = txt_Chanpingbianma.Text;
                        mat.MaterialName = txt_MaterialName.Text;
                        mat.Peitaochuangjia = txt_Peitaochuangjia.Text;
                        mat.Zhusai = txt_Zhusai.Text;
                        mat.Dinghuobianhao = txt_Dinghuobianhao.Text;
                        mat.Yuxingcheng = txt_Yuxingcheng.Text;
                        mat.BQMohehouzhuanggaiban = txt_BQMohehouzhuanggaiban.Text;
                        mat.Chuyoufa = txt_Chuyoufa.Text;
                        mat.BQShuyoubeng = txt_BQShuyoubeng.Text;
                        mat.BQShuyoubengzhijia = txt_BQShuyoubengzhijia.Text;
                        mat.BQZhuanghougaiban = txt_BQZhuanghougaiban.Text;
                        mat.BQTingchelaxianzhijia = txt_BQTingchelaxianzhijia.Text;
                        mat.BQShigaoyajinzuohumao = txt_BQShigaoyajinzuohumao.Text;
                        mat.Zhuangfujian = txt_Zhuangfujian.Text;
                        mat.Remark = txt_Remark.Text;
                        //大类
                        mat.Class = "BQ";
                        //创建者与时间
                        mat.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                        mat.CreateDate = System.DateTime.Now;
                        //图片
                        if (image != null)
                        {
                            mat.Photo = image;
                        }

                        #endregion

                        #region 工况

                        mat.Gongkuang1 = lab_Gongkuang1.Text;
                        mat.Gongkuang2 = lab_Gongkuang2.Text;
                        mat.Gongkuang3 = lab_Gongkuang3.Text;
                        mat.Gongkuang4 = lab_Gongkuang4.Text;
                        mat.Gongkuang5 = lab_Gongkuang5.Text;
                        mat.Gongkuang6 = lab_Gongkuang6.Text;
                        mat.Gongkuang7 = lab_Gongkuang7.Text;
                        mat.Gongkuang8 = lab_Gongkuang8.Text;
                        mat.Gongkuang9 = lab_Gongkuang9.Text;
                        mat.Gongkuang10 = lab_Gongkuang10.Text;

                        #endregion

                        #region 转速

                        mat.Zhuangsu1 = txt_Zhuangsu1.Text;
                        mat.Zhuangsu2 = txt_Zhuangsu2.Text;
                        mat.Zhuangsu3 = txt_Zhuangsu3.Text;
                        mat.Zhuangsu4 = txt_Zhuangsu4.Text;
                        mat.Zhuangsu5 = txt_Zhuangsu5.Text;
                        mat.Zhuangsu6 = txt_Zhuangsu6.Text;
                        mat.Zhuangsu7 = txt_Zhuangsu7.Text;
                        //2015.1.7转速1到10没有录入
                        mat.Zhuangsu8 = txt_Zhuangsu8.Text;
                        mat.Zhuangsu9 = txt_Zhuangsu9.Text;
                        mat.Zhuangsu10 = txt_Zhuangsu10.Text;
                        //需要加入校正转速
                        mat.BQJiaozhengzhuangsu = txt_Jiaozhengjieshuzhuansu.Text;


                        #endregion

                        #region 油量

                        mat.Pingjunyouliang1 = txt_Pingjunyouliang1.Text;
                        mat.Pingjunyouliang2 = txt_Pingjunyouliang2.Text;
                        mat.Pingjunyouliang3 = txt_Pingjunyouliang3.Text;
                        mat.Pingjunyouliang4 = txt_Pingjunyouliang4.Text;
                        mat.Pingjunyouliang5 = txt_Pingjunyouliang5.Text;
                        mat.Pingjunyouliang6 = txt_Pingjunyouliang6.Text;
                        mat.Pingjunyouliang7 = txt_Pingjunyouliang7.Text;

                        #endregion

                        #region 齿杆行程

                        mat.BQCiganxingchen1 = txt_BQCiganxingchen1.Text;
                        mat.BQCiganxingchen2 = txt_BQCiganxingchen2.Text;
                        mat.BQCiganxingchen3 = txt_BQCiganxingchen3.Text;
                        mat.BQCiganxingchen4 = txt_BQCiganxingchen4.Text;
                        mat.BQCiganxingchen5 = txt_BQCiganxingchen5.Text;
                        mat.BQCiganxingchen6 = txt_BQCiganxingchen6.Text;
                        mat.BQCiganxingchen7 = txt_BQCiganxingchen7.Text;

                        #endregion

                        #region 气压

                        mat.Qiya1 = txt_Qiya1.Text;
                        mat.Qiya2 = txt_Qiya2.Text;
                        mat.Qiya3 = txt_Qiya3.Text;
                        mat.Qiya4 = txt_Qiya4.Text;
                        mat.Qiya5 = txt_Qiya5.Text;
                        mat.Qiya6 = txt_Qiya6.Text;
                        mat.Qiya7 = txt_Qiya7.Text;

                        #endregion

                        #region 均匀度

                        mat.Junyundu1 = txt_Junyundu1.Text;
                        mat.Junyundu2 = txt_Junyundu2.Text;
                        mat.Junyundu3 = txt_Junyundu3.Text;
                        mat.Junyundu4 = txt_Junyundu4.Text;
                        mat.Junyundu5 = txt_Junyundu5.Text;
                        mat.Junyundu6 = txt_Junyundu6.Text;
                        mat.Junyundu7 = txt_Junyundu7.Text;

                        #endregion

                        #region 工况备注

                        mat.BQRemark1 = txt_BQRemark1.Text;
                        mat.BQRemark2 = txt_BQRemark2.Text;
                        mat.BQRemark3 = txt_BQRemark3.Text;
                        mat.BQRemark4 = txt_BQRemark4.Text;
                        mat.BQRemark5 = txt_BQRemark5.Text;
                        mat.BQRemark6 = txt_BQRemark6.Text;
                        mat.BQRemark7 = txt_BQRemark7.Text;

                        #endregion

                        db.TB_MaterialInfo.AddObject(mat);
                        db.SaveChanges();
                        MessageBox.Show("新增成功！");
                        SystemLogHelper.WriteSysLogHelper("新增了一条物料信息。型号：" + mat.TypeCode, user.ID, "物料信息管理");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("新增失败！详情请查看本地日志。");
                        LogExecute.WriteInfoLog("新增物料信息失败。操作者：" + user.ID + ",来源：新增物料信息。详情：" + ex.ToString());
                    }
                }
                else if (flag == 2)//更新
                {
                    try
                    {
                        var mat = db.TB_MaterialInfo.Single(p => p.TypeCode == materialCode);
                        //赋值
                        if (string.IsNullOrEmpty(mat.TypeCode = txt_Chanpingbianma.Text) || cb_Route.SelectedValue == null)
                        {
                            MessageBox.Show("产品编码（型号）不能为空！工艺路线也不能为空！");
                            db.Dispose();
                            return;
                        }

                        #region 工艺路线赋值

                        mat.TB_ProcessRouteM = db.TB_ProcessRouteM.Single(p => p.ID == (int)cb_Route.SelectedValue);

                        #endregion
                        #region 通用赋值

                        //mat.TypeCode = txt_Chanpingbianma.Text;
                        mat.MaterialName = txt_MaterialName.Text;
                        mat.Peitaochuangjia = txt_Peitaochuangjia.Text;
                        mat.Zhusai = txt_Zhusai.Text;
                        mat.Dinghuobianhao = txt_Dinghuobianhao.Text;
                        mat.Yuxingcheng = txt_Yuxingcheng.Text;
                        mat.BQMohehouzhuanggaiban = txt_BQMohehouzhuanggaiban.Text;
                        mat.Chuyoufa = txt_Chuyoufa.Text;
                        mat.BQShuyoubeng = txt_BQShuyoubeng.Text;
                        mat.BQShuyoubengzhijia = txt_BQShuyoubengzhijia.Text;
                        mat.BQZhuanghougaiban = txt_BQZhuanghougaiban.Text;
                        mat.BQTingchelaxianzhijia = txt_BQTingchelaxianzhijia.Text;
                        mat.BQShigaoyajinzuohumao = txt_BQShigaoyajinzuohumao.Text;
                        mat.Zhuangfujian = txt_Zhuangfujian.Text;
                        mat.Remark = txt_Remark.Text;
                        //创建者与时间
                        mat.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                        mat.CreateDate = System.DateTime.Now;
                        //图片
                        if (image != null)
                        {
                            mat.Photo = image;
                        }

                        #endregion

                        #region 工况

                        mat.Gongkuang1 = lab_Gongkuang1.Text;
                        mat.Gongkuang2 = lab_Gongkuang2.Text;
                        mat.Gongkuang3 = lab_Gongkuang3.Text;
                        mat.Gongkuang4 = lab_Gongkuang4.Text;
                        mat.Gongkuang5 = lab_Gongkuang5.Text;
                        mat.Gongkuang6 = lab_Gongkuang6.Text;
                        mat.Gongkuang7 = lab_Gongkuang7.Text;
                        mat.Gongkuang8 = lab_Gongkuang8.Text;
                        mat.Gongkuang9 = lab_Gongkuang9.Text;
                        mat.Gongkuang10 = lab_Gongkuang10.Text;

                        #endregion

                        #region 转速

                        mat.Zhuangsu1 = txt_Zhuangsu1.Text;
                        mat.Zhuangsu2 = txt_Zhuangsu2.Text;
                        mat.Zhuangsu3 = txt_Zhuangsu3.Text;
                        mat.Zhuangsu4 = txt_Zhuangsu4.Text;
                        mat.Zhuangsu5 = txt_Zhuangsu5.Text;
                        mat.Zhuangsu6 = txt_Zhuangsu6.Text;
                        mat.Zhuangsu7 = txt_Zhuangsu7.Text;
                        //2015.1.7转速1到10没有录入
                        mat.Zhuangsu8 = txt_Zhuangsu8.Text;
                        mat.Zhuangsu9 = txt_Zhuangsu9.Text;
                        mat.Zhuangsu10 = txt_Zhuangsu10.Text;

                        #endregion

                        #region 油量

                        mat.Pingjunyouliang1 = txt_Pingjunyouliang1.Text;
                        mat.Pingjunyouliang2 = txt_Pingjunyouliang2.Text;
                        mat.Pingjunyouliang3 = txt_Pingjunyouliang3.Text;
                        mat.Pingjunyouliang4 = txt_Pingjunyouliang4.Text;
                        mat.Pingjunyouliang5 = txt_Pingjunyouliang5.Text;
                        mat.Pingjunyouliang6 = txt_Pingjunyouliang6.Text;
                        mat.Pingjunyouliang7 = txt_Pingjunyouliang7.Text;

                        #endregion

                        #region 齿杆行程

                        mat.BQCiganxingchen1 = txt_BQCiganxingchen1.Text;
                        mat.BQCiganxingchen2 = txt_BQCiganxingchen2.Text;
                        mat.BQCiganxingchen3 = txt_BQCiganxingchen3.Text;
                        mat.BQCiganxingchen4 = txt_BQCiganxingchen4.Text;
                        mat.BQCiganxingchen5 = txt_BQCiganxingchen5.Text;
                        mat.BQCiganxingchen6 = txt_BQCiganxingchen6.Text;
                        mat.BQCiganxingchen7 = txt_BQCiganxingchen7.Text;

                        #endregion

                        #region 气压

                        mat.Qiya1 = txt_Qiya1.Text;
                        mat.Qiya2 = txt_Qiya2.Text;
                        mat.Qiya3 = txt_Qiya3.Text;
                        mat.Qiya4 = txt_Qiya4.Text;
                        mat.Qiya5 = txt_Qiya5.Text;
                        mat.Qiya6 = txt_Qiya6.Text;
                        mat.Qiya7 = txt_Qiya7.Text;

                        #endregion

                        #region 均匀度

                        mat.Junyundu1 = txt_Junyundu1.Text;
                        mat.Junyundu2 = txt_Junyundu2.Text;
                        mat.Junyundu3 = txt_Junyundu3.Text;
                        mat.Junyundu4 = txt_Junyundu4.Text;
                        mat.Junyundu5 = txt_Junyundu5.Text;
                        mat.Junyundu6 = txt_Junyundu6.Text;
                        mat.Junyundu7 = txt_Junyundu7.Text;

                        #endregion

                        #region 工况备注

                        mat.BQRemark1 = txt_BQRemark1.Text;
                        mat.BQRemark2 = txt_BQRemark2.Text;
                        mat.BQRemark3 = txt_BQRemark3.Text;
                        mat.BQRemark4 = txt_BQRemark4.Text;
                        mat.BQRemark5 = txt_BQRemark5.Text;
                        mat.BQRemark6 = txt_BQRemark6.Text;
                        mat.BQRemark7 = txt_BQRemark7.Text;

                        #endregion

                        db.SaveChanges();
                        MessageBox.Show("更新成功！");
                        SystemLogHelper.WriteSysLogHelper("更新物料信息。型号：" + mat.TypeCode, user.ID, "更新物料信息");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("编辑更新模式下。请不要修改产品编码（型号）！");
                        LogExecute.WriteInfoLog("编辑出现异常。操作者：" + user.UserName + "，来源：更新物料信息。详情：" + ex.ToString());
                    }
                }
            }
            OpenOrCloseProsbar(false);
        }
    }
}
