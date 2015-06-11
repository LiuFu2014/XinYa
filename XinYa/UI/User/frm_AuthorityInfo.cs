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

namespace XinYa.UI.User
{
    public partial class frm_AuthorityInfo : Form
    {

        #region 字段属性

        List<TB_User> list_User;
        TB_User User;

        #endregion

        public frm_AuthorityInfo(TB_User user)
        {
            InitializeComponent();
            User = user;
            this.dgv_User.AutoGenerateColumns = false;
            this.dgv_UserRight.AutoGenerateColumns = false;
            UserInfoInit();
        }

        /// <summary>
        /// 设置进度条可见度
        /// </summary>
        /// <param name="flag"></param>
        //public void SetPrograssbar(bool flag)
        //{
        //    probar_Working.Value = 5;
        //    if (flag)
        //    {
        //        lab_Working.Visible = true;
        //        probar_Working.Visible = true;
        //    }
        //    else
        //    {
        //        lab_Working.Visible = false;
        //        probar_Working.Visible = false;
        //    }
        //}

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
        /// 用户信息初始化
        /// </summary>
        public void UserInfoInit()
        {
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_User = db.TB_User.Where(p=>p.UserLevel!="ERP").ToList();
                    dgv_User.DataSource = new List<TB_User>(list_User);
                }
                catch (Exception)
                {
                    MessageBox.Show("用户信息初始化失败");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 用户信息初始化（用户名加载）
        /// </summary>
        /// <param name="userName"></param>
        public void UserInfoInit(string userName)
        {
            Changeprobar(true);
            Application.DoEvents();
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_User = db.TB_User.Where(p => p.UserName.Contains(userName)).ToList();
                    dgv_User.DataSource = list_User;
                }
                catch (Exception)
                {
                    MessageBox.Show("系统没有当前用户数据！");
                }
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            UserInfoInit();
        }

        /// <summary>
        /// 指定用户名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            UserInfoInit(txt_UserName.Text);
        }

        /// <summary>
        /// dgv_User单击加载右侧权限列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_User.CurrentRow != null && !string.IsNullOrEmpty(dgv_User.CurrentRow.Cells["c_ID"].Value.ToString()))
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //先根据用户ID找用户
                    TB_User u;
                    try
                    {
                        int id = (int)dgv_User.CurrentRow.Cells["c_ID"].Value;
                        u = db.TB_User.Single(p => p.ID == id);
                    }
                    catch (Exception)
                    {
                        u = null;
                        MessageBox.Show("系统异常，请关闭当前窗体并重试！");
                        db.Dispose();
                        return;
                    }
                    if (u.TB_UserLoginRight.Count != 0)
                    {
                        List<TB_UserLoginRight> a = u.TB_UserLoginRight.ToList();
                        foreach (var item in a)
                        {
                            item.TB_SecondWorkStationInfoReference.Load();
                        }
                        dgv_UserRight.DataSource = new List<TB_UserLoginRight>(a);
                    }
                    else//如果当前用户还没有权限信息则加载原始权限信息
                    {
                        try
                        {
                            var a = db.TB_UserLoginRight.Where(p => p.Type == "0").ToList();
                            foreach (var item in a)
                            {
                                item.TB_SecondWorkStationInfoReference.Load();
                            }
                            dgv_UserRight.DataSource = new List<TB_UserLoginRight>(a);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("加载原始权限数据出错！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// dgv_UserRight加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_UserRight_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_UserRight.Rows[e.RowIndex].DataBoundItem != null) && (dgv_UserRight.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_UserRight.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_UserRight.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            //先判断权限表和用户表有无选择数据
            if (dgv_User.CurrentRow != null && !string.IsNullOrEmpty(dgv_User.CurrentRow.Cells["c_ID"].Value.ToString()) && dgv_UserRight.DataSource != null)
            {
                //用户ID
                int userID = (int)dgv_User.CurrentRow.Cells["c_ID"].Value;
                //用户类
                TB_User user;
                //权限Source
                List<TB_UserLoginRight> userRights = (List<TB_UserLoginRight>)dgv_UserRight.DataSource;

                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        user = db.TB_User.Single(p => p.ID == userID);
                    }
                    catch (Exception)
                    {
                        user = null;
                        MessageBox.Show("系统异常，请关闭当前窗体并重试！");
                    }
                    //判断当前用户的权限是否为空，为空则是新增。不为空则是更新
                    if (user != null && user.TB_UserLoginRight.Count == 0)
                    {
                        //新增
                        foreach (var item in userRights)
                        {
                            TB_UserLoginRight userright = new TB_UserLoginRight();
                            userright.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == item.SecondWorkStationID);
                            userright.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                            userright.IsUse = item.IsUse;
                            userright.Type = "";
                            db.TB_UserLoginRight.AddObject(userright);
                            db.SaveChanges();
                        }
                        MessageBox.Show("新增成功！");
                        SystemLogHelper.WriteSysLogHelper("新增了用户权限。用户工号：" + user.UserID, User.ID, "用户权限管理");
                    }
                    else if (user != null && user.TB_UserLoginRight.Count != 0)
                    {
                        //更新 没有解决数据源与dgv同步更新的问题，这里就逐行扫描吧！
                        //for (int i = 0; i < dgv_UserRight.Rows.Count; i++)
                        //{
                        //    int id = (int)dgv_UserRight.Rows[i].Cells["c_ID2"].Value;
                        //    TB_UserLoginRight userright = db.TB_UserLoginRight.Single(p => p.ID == id);
                        //    int SecondWorkStationID = (int)(int)dgv_UserRight.Rows[i].Cells["c_SecondWorkStationID"].Value;
                        //    userright.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == SecondWorkStationID);
                        //    userright.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                        //    user.IsUse = (bool)dgv_UserRight.Rows[i].Cells["c_IsUse"].Value; ;
                        //    userright.Type = "";
                        //    db.SaveChanges();
                        //}

                        foreach (var item in userRights)
                        {                          
                            TB_UserLoginRight userright = db.TB_UserLoginRight.Single(p => p.ID == item.ID);
                            userright.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == item.SecondWorkStationID);
                            userright.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                            userright.IsUse = item.IsUse;
                            userright.Type = "";
                            db.SaveChanges();
                        }
                        MessageBox.Show("更新成功！");
                        SystemLogHelper.WriteSysLogHelper("更新了用户权限。用户工号：" + user.UserID, User.ID, "用户权限管理");
                    }
                }
            }
            else
            {
                MessageBox.Show("当前没有可用于保存的数据！");
            }
            Changeprobar(false);
        }       

    }
}
