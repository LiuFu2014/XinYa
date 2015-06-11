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
    public partial class frm_MaterialInfoVEDtl : Form
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
        public frm_MaterialInfoVEDtl(TB_User user, string materialCode, int flag)
        {
            InitializeComponent();

            this.user = user;
            this.flag = flag;
            this.materialCode = materialCode;
            Init(flag);
            prosbar_Main.Value = 5;

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
        /// 文本框初始化
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

                //赋值
                txt_Chanpingbianma.Text = mat.TypeCode;
                txt_Chanpingmingchen.Text = mat.MaterialName;
                txt_Dinghuobianhao.Text = mat.Dinghuobianhao;
                txt_Peitaochangjia.Text = mat.Peitaochuangjia;
                txt_Zhusai.Text = mat.Zhusai;
                txt_Chuyoufa.Text = mat.Chuyoufa;
                txt_Yuxingcheng.Text = mat.Yuxingcheng;
                txt_Mohehouzhuangbenggai.Text = mat.Mohehouzhuangbenggai;
                txt_Shiyantaitiaoshi.Text = mat.Shiyantaitiaoshi;
                txt_Zhuanghuiyoudiancifa.Text = mat.Zhuanghuiyoudiancifa;
                txt_Zhuangfujian.Text = mat.Zhuangfujian;
                txt_Remark.Text = mat.Remark;
                //图片
                image = mat.Photo;
                //图片显示
                try
                {
                    MemoryStream mStream = new MemoryStream();
                    mStream.Write(image, 0, image.Length);
                    mStream.Flush();
                    Bitmap img = new Bitmap(mStream);
                    pb_BengPicture.Image = img;
                }
                catch { }

                //"子表"
                //气压
                txt_Qiya1.Text = mat.Qiya1;
                txt_Qiya2.Text = mat.Qiya2;
                txt_Qiya3.Text = mat.Qiya3;
                txt_Qiya4.Text = mat.Qiya4;
                txt_Qiya5.Text = mat.Qiya5;
                txt_Qiya6.Text = mat.Qiya6;
                txt_Qiya7.Text = mat.Qiya7;
                txt_Qiya8.Text = mat.Qiya8;
                txt_Qiya9.Text = mat.Qiya9;
                txt_Qiya10.Text = mat.Qiya10;
                txt_Qiya11.Text = mat.Qiya11;
                txt_Qiya12.Text = mat.Qiya12;
                txt_Qiya13.Text = mat.Qiya13;
                txt_Qiya14.Text = mat.Qiya14;
                //转速
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
                txt_Zhuangsu11.Text = mat.Zhuangsu11;
                txt_Zhuangsu12.Text = mat.Zhuangsu12;
                txt_Zhuangsu13.Text = mat.Zhuangsu13;
                txt_Zhuangsu14.Text = mat.Zhuangsu14;
                //油量(平均油量)
                txt_Youliang1.Text = mat.Pingjunyouliang1;
                txt_Youliang2.Text = mat.Pingjunyouliang2;
                txt_Youliang3.Text = mat.Pingjunyouliang3;
                txt_Youliang4.Text = mat.Pingjunyouliang4;
                txt_Youliang5.Text = mat.Pingjunyouliang5;
                txt_Youliang6.Text = mat.Pingjunyouliang6;
                txt_Youliang7.Text = mat.Pingjunyouliang7;
                txt_Youliang8.Text = mat.Pingjunyouliang8;
                txt_Youliang9.Text = mat.Pingjunyouliang9;
                txt_Youliang10.Text = mat.Pingjunyouliang10;
                txt_Youliang11.Text = mat.Pingjunyouliang11;
                txt_Youliang12.Text = mat.Pingjunyouliang12;
                txt_Youliang13.Text = mat.Pingjunyouliang13;
                txt_Youliang14.Text = mat.Pingjunyouliang14;
                //均匀度
                txt_Junyundu1.Text = mat.Junyundu1;
                txt_Junyundu2.Text = mat.Junyundu2;
                txt_Junyundu3.Text = mat.Junyundu3;
                txt_Junyundu4.Text = mat.Junyundu4;
                txt_Junyundu5.Text = mat.Junyundu5;
                txt_Junyundu6.Text = mat.Junyundu6;
                txt_Junyundu7.Text = mat.Junyundu7;
                txt_Junyundu8.Text = mat.Junyundu8;
                txt_Junyundu9.Text = mat.Junyundu9;
                txt_Junyundu10.Text = mat.Junyundu10;
                txt_Junyundu11.Text = mat.Junyundu11;
                txt_Junyundu12.Text = mat.Junyundu12;
                txt_Junyundu13.Text = mat.Junyundu13;
                txt_Junyundu14.Text = mat.Junyundu14;
                //内压
                txt_Neiya1.Text = mat.Neiya1;
                txt_Neiya2.Text = mat.Neiya2;
                txt_Neiya3.Text = mat.Neiya3;
                txt_Neiya4.Text = mat.Neiya4;
                txt_Neiya5.Text = mat.Neiya5;
                txt_Neiya6.Text = mat.Neiya6;
                txt_Neiya7.Text = mat.Neiya7;
                txt_Neiya8.Text = mat.Neiya8;
                txt_Neiya9.Text = mat.Neiya9;
                txt_Neiya10.Text = mat.Neiya10;
                txt_Neiya11.Text = mat.Neiya11;
                txt_Neiya12.Text = mat.Neiya12;
                txt_Neiya13.Text = mat.Neiya13;
                txt_Neiya14.Text = mat.Neiya14;
                //提前器行程
                txt_Tiqiangxingcheng1.Text = mat.Tiqianxingcheng1;
                txt_Tiqiangxingcheng2.Text = mat.Tiqianxingcheng2;
                txt_Tiqiangxingcheng3.Text = mat.Tiqianxingcheng3;
                txt_Tiqiangxingcheng4.Text = mat.Tiqianxingcheng4;
                txt_Tiqiangxingcheng5.Text = mat.Tiqianxingcheng5;
                txt_Tiqiangxingcheng6.Text = mat.Tiqianxingcheng6;
                txt_Tiqiangxingcheng7.Text = mat.Tiqianxingcheng7;
                txt_Tiqiangxingcheng8.Text = mat.Tiqianxingcheng8;
                txt_Tiqiangxingcheng9.Text = mat.Tiqianxingcheng9;
                txt_Tiqiangxingcheng10.Text = mat.Tiqianxingcheng10;
                txt_Tiqiangxingcheng11.Text = mat.Tiqianxingcheng11;
                txt_Tiqiangxingcheng12.Text = mat.Tiqianxingcheng12;
                txt_Tiqiangxingcheng13.Text = mat.Tiqianxingcheng13;
                txt_Tiqiangxingcheng14.Text = mat.Tiqianxingcheng14;
                //回油量
                txt_Huiyouliang1.Text = mat.Huiyouliang1;
                txt_Huiyouliang2.Text = mat.Huiyouliang2;
                txt_Huiyouliang3.Text = mat.Huiyouliang3;
                txt_Huiyouliang4.Text = mat.Huiyouliang4;
                txt_Huiyouliang5.Text = mat.Huiyouliang5;
                txt_Huiyouliang6.Text = mat.Huiyouliang6;
                txt_Huiyouliang7.Text = mat.Huiyouliang7;
                txt_Huiyouliang8.Text = mat.Huiyouliang8;
                txt_Huiyouliang9.Text = mat.Huiyouliang9;
                txt_Huiyouliang10.Text = mat.Huiyouliang10;
                txt_Huiyouliang11.Text = mat.Huiyouliang11;
                txt_Huiyouliang12.Text = mat.Huiyouliang12;
                txt_Huiyouliang13.Text = mat.Huiyouliang13;
                txt_Huiyouliang14.Text = mat.Huiyouliang14;

            }
        }

        /// <summary>
        /// 根据不同的flag来初始化
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
                        TextInit(mat,list_route);
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
                        TextInit(mat,null);
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
        /// 确定
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

                        mat.MaterialName = txt_Chanpingmingchen.Text;
                        mat.Dinghuobianhao = txt_Dinghuobianhao.Text;
                        mat.Peitaochuangjia = txt_Peitaochangjia.Text;
                        mat.Zhusai = txt_Zhusai.Text;
                        mat.Chuyoufa = txt_Chuyoufa.Text;
                        mat.Yuxingcheng = txt_Yuxingcheng.Text;
                        mat.Mohehouzhuangbenggai = txt_Mohehouzhuangbenggai.Text;
                        mat.Shiyantaitiaoshi = txt_Shiyantaitiaoshi.Text;
                        mat.Zhuanghuiyoudiancifa = txt_Zhuanghuiyoudiancifa.Text;
                        mat.Zhuangfujian = txt_Zhuangfujian.Text;
                        mat.Remark = txt_Remark.Text;        
               
                        //大类
                        mat.Class = "VE";

                        //图片处理
                        if (image!=null)
                        {
                            mat.Photo = image;
                        }
                        //用户外键处理
                        mat.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        mat.CreateDate = DateTime.Now;

                        //"子表"
                        //气压
                        mat.Qiya1 = txt_Qiya1.Text;
                        mat.Qiya2 = txt_Qiya2.Text;
                        mat.Qiya3 = txt_Qiya3.Text;
                        mat.Qiya4 = txt_Qiya4.Text;
                        mat.Qiya5 = txt_Qiya5.Text;
                        mat.Qiya6 = txt_Qiya6.Text;
                        mat.Qiya7 = txt_Qiya7.Text;
                        mat.Qiya8 = txt_Qiya8.Text;
                        mat.Qiya9 = txt_Qiya9.Text;
                        mat.Qiya10 = txt_Qiya10.Text;
                        mat.Qiya11 = txt_Qiya11.Text;
                        mat.Qiya12 = txt_Qiya12.Text;
                        mat.Qiya13 = txt_Qiya13.Text;
                        mat.Qiya14 = txt_Qiya14.Text;
                        //转速
                        mat.Zhuangsu1 = txt_Zhuangsu1.Text;
                        mat.Zhuangsu2 = txt_Zhuangsu2.Text;
                        mat.Zhuangsu3 = txt_Zhuangsu3.Text;
                        mat.Zhuangsu4 = txt_Zhuangsu4.Text;
                        mat.Zhuangsu5 = txt_Zhuangsu5.Text;
                        mat.Zhuangsu6 = txt_Zhuangsu6.Text;
                        mat.Zhuangsu7 = txt_Zhuangsu7.Text;
                        mat.Zhuangsu8 = txt_Zhuangsu8.Text;
                        mat.Zhuangsu9 = txt_Zhuangsu9.Text;
                        mat.Zhuangsu10 = txt_Zhuangsu10.Text;
                        mat.Zhuangsu11 = txt_Zhuangsu11.Text;
                        mat.Zhuangsu12 = txt_Zhuangsu12.Text;
                        mat.Zhuangsu13 = txt_Zhuangsu13.Text;
                        mat.Zhuangsu14 = txt_Zhuangsu14.Text;
                        //油量(平均油量)
                        mat.Pingjunyouliang1 = txt_Youliang1.Text;
                        mat.Pingjunyouliang2 = txt_Youliang2.Text;
                        mat.Pingjunyouliang3 = txt_Youliang3.Text;
                        mat.Pingjunyouliang4 = txt_Youliang4.Text;
                        mat.Pingjunyouliang5 = txt_Youliang5.Text;
                        mat.Pingjunyouliang6 = txt_Youliang6.Text;
                        mat.Pingjunyouliang7 = txt_Youliang7.Text;
                        mat.Pingjunyouliang8 = txt_Youliang8.Text;
                        mat.Pingjunyouliang9 = txt_Youliang9.Text;
                        mat.Pingjunyouliang10 = txt_Youliang10.Text;
                        mat.Pingjunyouliang11 = txt_Youliang11.Text;
                        mat.Pingjunyouliang12 = txt_Youliang12.Text;
                        mat.Pingjunyouliang13 = txt_Youliang13.Text;
                        mat.Pingjunyouliang14 = txt_Youliang14.Text;

                        //均匀度
                        mat.Junyundu1 = txt_Junyundu1.Text;
                        mat.Junyundu2 = txt_Junyundu2.Text;
                        mat.Junyundu3 = txt_Junyundu3.Text;
                        mat.Junyundu4 = txt_Junyundu4.Text;
                        mat.Junyundu5 = txt_Junyundu5.Text;
                        mat.Junyundu6 = txt_Junyundu6.Text;
                        mat.Junyundu7 = txt_Junyundu7.Text;
                        mat.Junyundu8 = txt_Junyundu8.Text;
                        mat.Junyundu9 = txt_Junyundu9.Text;
                        mat.Junyundu10 = txt_Junyundu10.Text;
                        mat.Junyundu11 = txt_Junyundu11.Text;
                        mat.Junyundu12 = txt_Junyundu12.Text;
                        mat.Junyundu13 = txt_Junyundu13.Text;
                        mat.Junyundu14 = txt_Junyundu14.Text;

                        //内压
                        mat.Neiya1 = txt_Neiya1.Text;
                        mat.Neiya2 = txt_Neiya2.Text;
                        mat.Neiya3 = txt_Neiya3.Text;
                        mat.Neiya4 = txt_Neiya4.Text;
                        mat.Neiya5 = txt_Neiya5.Text;
                        mat.Neiya6 = txt_Neiya6.Text;
                        mat.Neiya7 = txt_Neiya7.Text;
                        mat.Neiya8 = txt_Neiya8.Text;
                        mat.Neiya9 = txt_Neiya9.Text;
                        mat.Neiya10 = txt_Neiya10.Text;
                        mat.Neiya11 = txt_Neiya11.Text;
                        mat.Neiya12 = txt_Neiya12.Text;
                        mat.Neiya13 = txt_Neiya13.Text;
                        mat.Neiya14 = txt_Neiya14.Text;

                        //提前器行程
                        mat.Tiqianxingcheng1 = txt_Tiqiangxingcheng1.Text;
                        mat.Tiqianxingcheng2 = txt_Tiqiangxingcheng2.Text;
                        mat.Tiqianxingcheng3 = txt_Tiqiangxingcheng3.Text;
                        mat.Tiqianxingcheng4 = txt_Tiqiangxingcheng4.Text;
                        mat.Tiqianxingcheng5 = txt_Tiqiangxingcheng5.Text;
                        mat.Tiqianxingcheng6 = txt_Tiqiangxingcheng6.Text;
                        mat.Tiqianxingcheng7 = txt_Tiqiangxingcheng7.Text;
                        mat.Tiqianxingcheng8 = txt_Tiqiangxingcheng8.Text;
                        mat.Tiqianxingcheng9 = txt_Tiqiangxingcheng9.Text;
                        mat.Tiqianxingcheng10 = txt_Tiqiangxingcheng10.Text;
                        mat.Tiqianxingcheng11 = txt_Tiqiangxingcheng11.Text;
                        mat.Tiqianxingcheng12 = txt_Tiqiangxingcheng12.Text;
                        mat.Tiqianxingcheng13 = txt_Tiqiangxingcheng13.Text;
                        mat.Tiqianxingcheng14 = txt_Tiqiangxingcheng14.Text;

                        //回油量
                        mat.Huiyouliang1 = txt_Huiyouliang1.Text;
                        mat.Huiyouliang2 = txt_Huiyouliang2.Text;
                        mat.Huiyouliang3 = txt_Huiyouliang3.Text;
                        mat.Huiyouliang4 = txt_Huiyouliang4.Text;
                        mat.Huiyouliang5 = txt_Huiyouliang5.Text;
                        mat.Huiyouliang6 = txt_Huiyouliang6.Text;
                        mat.Huiyouliang7 = txt_Huiyouliang7.Text;
                        mat.Huiyouliang8 = txt_Huiyouliang8.Text;
                        mat.Huiyouliang9 = txt_Huiyouliang9.Text;
                        mat.Huiyouliang10 = txt_Huiyouliang10.Text;
                        mat.Huiyouliang11 = txt_Huiyouliang11.Text;
                        mat.Huiyouliang12 = txt_Huiyouliang12.Text;
                        mat.Huiyouliang13 = txt_Huiyouliang13.Text;
                        mat.Huiyouliang14 = txt_Huiyouliang14.Text;
                        db.TB_MaterialInfo.AddObject(mat);
                        db.SaveChanges();
                        MessageBox.Show("新增成功！");
                        SystemLogHelper.WriteSysLogHelper("新增物料信息。型号：" + mat.TypeCode, user.ID, "新增物料信息");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("新增失败！");
                        LogExecute.WriteInfoLog("新增出现异常。操作者：" + user.UserName + "，来源：新增物料信息。详情：" + ex.ToString());

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

                        mat.MaterialName = txt_Chanpingmingchen.Text;
                        mat.Dinghuobianhao = txt_Dinghuobianhao.Text;
                        mat.Peitaochuangjia = txt_Peitaochangjia.Text;
                        mat.Zhusai = txt_Zhusai.Text;
                        mat.Chuyoufa = txt_Chuyoufa.Text;
                        mat.Yuxingcheng = txt_Yuxingcheng.Text;
                        mat.Mohehouzhuangbenggai = txt_Mohehouzhuangbenggai.Text;
                        mat.Shiyantaitiaoshi = txt_Shiyantaitiaoshi.Text;
                        mat.Zhuanghuiyoudiancifa = txt_Zhuanghuiyoudiancifa.Text;
                        mat.Zhuangfujian = txt_Zhuangfujian.Text;
                        mat.Remark = txt_Remark.Text;

                        //图片处理
                        if (image != null)
                        {
                            mat.Photo = image;
                        }
                        //用户外键处理
                        mat.TB_User = db.TB_User.First(p => p.ID == user.ID);

                        //"子表"
                        //气压
                        mat.Qiya1 = txt_Qiya1.Text;
                        mat.Qiya2 = txt_Qiya2.Text;
                        mat.Qiya3 = txt_Qiya3.Text;
                        mat.Qiya4 = txt_Qiya4.Text;
                        mat.Qiya5 = txt_Qiya5.Text;
                        mat.Qiya6 = txt_Qiya6.Text;
                        mat.Qiya7 = txt_Qiya7.Text;
                        mat.Qiya8 = txt_Qiya8.Text;
                        mat.Qiya9 = txt_Qiya9.Text;
                        mat.Qiya10 = txt_Qiya10.Text;
                        mat.Qiya11 = txt_Qiya11.Text;
                        mat.Qiya12 = txt_Qiya12.Text;
                        mat.Qiya13 = txt_Qiya13.Text;
                        mat.Qiya14 = txt_Qiya14.Text;
                        //转速
                        mat.Zhuangsu1 = txt_Zhuangsu1.Text;
                        mat.Zhuangsu2 = txt_Zhuangsu2.Text;
                        mat.Zhuangsu3 = txt_Zhuangsu3.Text;
                        mat.Zhuangsu4 = txt_Zhuangsu4.Text;
                        mat.Zhuangsu5 = txt_Zhuangsu5.Text;
                        mat.Zhuangsu6 = txt_Zhuangsu6.Text;
                        mat.Zhuangsu7 = txt_Zhuangsu7.Text;
                        mat.Zhuangsu8 = txt_Zhuangsu8.Text;
                        mat.Zhuangsu9 = txt_Zhuangsu9.Text;
                        mat.Zhuangsu10 = txt_Zhuangsu10.Text;
                        mat.Zhuangsu11 = txt_Zhuangsu11.Text;
                        mat.Zhuangsu12 = txt_Zhuangsu12.Text;
                        mat.Zhuangsu13 = txt_Zhuangsu13.Text;
                        mat.Zhuangsu14 = txt_Zhuangsu14.Text;
                        //油量(平均油量)
                        mat.Pingjunyouliang1 = txt_Youliang1.Text;
                        mat.Pingjunyouliang2 = txt_Youliang2.Text;
                        mat.Pingjunyouliang3 = txt_Youliang3.Text;
                        mat.Pingjunyouliang4 = txt_Youliang4.Text;
                        mat.Pingjunyouliang5 = txt_Youliang5.Text;
                        mat.Pingjunyouliang6 = txt_Youliang6.Text;
                        mat.Pingjunyouliang7 = txt_Youliang7.Text;
                        mat.Pingjunyouliang8 = txt_Youliang8.Text;
                        mat.Pingjunyouliang9 = txt_Youliang9.Text;
                        mat.Pingjunyouliang10 = txt_Youliang10.Text;
                        mat.Pingjunyouliang11 = txt_Youliang11.Text;
                        mat.Pingjunyouliang12 = txt_Youliang12.Text;
                        mat.Pingjunyouliang13 = txt_Youliang13.Text;
                        mat.Pingjunyouliang14 = txt_Youliang14.Text;

                        //均匀度
                        mat.Junyundu1 = txt_Junyundu1.Text;
                        mat.Junyundu2 = txt_Junyundu2.Text;
                        mat.Junyundu3 = txt_Junyundu3.Text;
                        mat.Junyundu4 = txt_Junyundu4.Text;
                        mat.Junyundu5 = txt_Junyundu5.Text;
                        mat.Junyundu6 = txt_Junyundu6.Text;
                        mat.Junyundu7 = txt_Junyundu7.Text;
                        mat.Junyundu8 = txt_Junyundu8.Text;
                        mat.Junyundu9 = txt_Junyundu9.Text;
                        mat.Junyundu10 = txt_Junyundu10.Text;
                        mat.Junyundu11 = txt_Junyundu11.Text;
                        mat.Junyundu12 = txt_Junyundu12.Text;
                        mat.Junyundu13 = txt_Junyundu13.Text;
                        mat.Junyundu14 = txt_Junyundu14.Text;

                        //内压
                        mat.Neiya1 = txt_Neiya1.Text;
                        mat.Neiya2 = txt_Neiya2.Text;
                        mat.Neiya3 = txt_Neiya3.Text;
                        mat.Neiya4 = txt_Neiya4.Text;
                        mat.Neiya5 = txt_Neiya5.Text;
                        mat.Neiya6 = txt_Neiya6.Text;
                        mat.Neiya7 = txt_Neiya7.Text;
                        mat.Neiya8 = txt_Neiya8.Text;
                        mat.Neiya9 = txt_Neiya9.Text;
                        mat.Neiya10 = txt_Neiya10.Text;
                        mat.Neiya11 = txt_Neiya11.Text;
                        mat.Neiya12 = txt_Neiya12.Text;
                        mat.Neiya13 = txt_Neiya13.Text;
                        mat.Neiya14 = txt_Neiya14.Text;

                        //提前器行程
                        mat.Tiqianxingcheng1 = txt_Tiqiangxingcheng1.Text;
                        mat.Tiqianxingcheng2 = txt_Tiqiangxingcheng2.Text;
                        mat.Tiqianxingcheng3 = txt_Tiqiangxingcheng3.Text;
                        mat.Tiqianxingcheng4 = txt_Tiqiangxingcheng4.Text;
                        mat.Tiqianxingcheng5 = txt_Tiqiangxingcheng5.Text;
                        mat.Tiqianxingcheng6 = txt_Tiqiangxingcheng6.Text;
                        mat.Tiqianxingcheng7 = txt_Tiqiangxingcheng7.Text;
                        mat.Tiqianxingcheng8 = txt_Tiqiangxingcheng8.Text;
                        mat.Tiqianxingcheng9 = txt_Tiqiangxingcheng9.Text;
                        mat.Tiqianxingcheng10 = txt_Tiqiangxingcheng10.Text;
                        mat.Tiqianxingcheng11 = txt_Tiqiangxingcheng11.Text;
                        mat.Tiqianxingcheng12 = txt_Tiqiangxingcheng12.Text;
                        mat.Tiqianxingcheng13 = txt_Tiqiangxingcheng13.Text;
                        mat.Tiqianxingcheng14 = txt_Tiqiangxingcheng14.Text;

                        //回油量
                        mat.Huiyouliang1 = txt_Huiyouliang1.Text;
                        mat.Huiyouliang2 = txt_Huiyouliang2.Text;
                        mat.Huiyouliang3 = txt_Huiyouliang3.Text;
                        mat.Huiyouliang4 = txt_Huiyouliang4.Text;
                        mat.Huiyouliang5 = txt_Huiyouliang5.Text;
                        mat.Huiyouliang6 = txt_Huiyouliang6.Text;
                        mat.Huiyouliang7 = txt_Huiyouliang7.Text;
                        mat.Huiyouliang8 = txt_Huiyouliang8.Text;
                        mat.Huiyouliang9 = txt_Huiyouliang9.Text;
                        mat.Huiyouliang10 = txt_Huiyouliang10.Text;
                        mat.Huiyouliang11 = txt_Huiyouliang11.Text;
                        mat.Huiyouliang12 = txt_Huiyouliang12.Text;
                        mat.Huiyouliang13 = txt_Huiyouliang13.Text;
                        mat.Huiyouliang14 = txt_Huiyouliang14.Text;
                        //
                        db.SaveChanges();
                        MessageBox.Show("更新成功！");
                        SystemLogHelper.WriteSysLogHelper("更新物料信息。型号：" + mat.TypeCode, user.ID, "更新物料信息");
                    }
                    catch
                    {
                        MessageBox.Show("编辑更新模式下。请不要修改产品编码（型号）！");
                    }
                }
            }
            OpenOrCloseProsbar(false);
        }

        /// <summary>
        /// 导入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ImportPicture_Click(object sender, EventArgs e)
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
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
