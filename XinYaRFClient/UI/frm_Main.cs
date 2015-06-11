using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYaRFClient.DAL;
using System.Net.NetworkInformation;

namespace XinYaRFClient.UI
{
    public partial class frm_Main : Form
    {

        #region 字段属性

        TB_User user;

        /// <summary>
        /// 手动自动开关，默认TRUE,表示自动
        /// </summary>
        bool flag = true;

        /// <summary>
        /// 主任务
        /// </summary>
        TB_WorkMain wm;

        /// <summary>
        /// 主工位编码
        /// </summary>
        string workStationCode = "";//System.Configuration.ConfigurationSettings.AppSettings["WorkStationCode"];

        /// <summary>
        /// 第二工位编码
        /// </summary>
        string secondWorkStationCode = "";// System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationCode"];

        /// <summary>
        /// 第二工位ID
        /// </summary>
        int secondWorkStationID =0;// Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationID"].ToString());

        /// <summary>
        /// 第二工位名
        /// </summary>
        string secondWorkStationName = "";

        /// <summary>
        /// 当前工位信息
        /// </summary>
        TB_SecondWorkStationInfo secondWorkStationInfo;

        /// <summary>
        /// 分页显示标志位
        /// </summary>
        string tabflag ="";// System.Configuration.ConfigurationSettings.AppSettings["ExceptionShow"];

        /// <summary>
        /// xml配置文件路径
        /// </summary>
        string xmlPath = Properties.Settings.Default.XmlPath;

        /// <summary>
        /// 客户端服务
        /// </summary>
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();

        /// <summary>
        /// 异常信息
        /// </summary>
        List<TB_Exception> list_Exception = new List<TB_Exception>();

        /// <summary>
        /// 用于承载异常表中的一行记录，全局变量
        /// </summary>
        TB_WorkException workException =null;

        #endregion

        #region 事件

        public frm_Main(TB_User user)
        {
            InitializeComponent();

            #region 读取配置文件

            try
            {
                secondWorkStationID = Convert.ToInt32(XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationID"));
                //secondWorkStationName = XMLHelper.ReadXML(xmlPath, "XinYa", "Source");
                //workStationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "WorkStationCode");
                secondWorkStationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationCode");
                tabflag = XMLHelper.ReadXML(xmlPath, "XinYa", "ExceptionShow");
            }
            catch (Exception)
            {
                MessageBox.Show("检测到配置文件出错，程序即将关闭，请联系管理员解决问题。");
                Application.Exit();
            }

            #endregion

            //当前工位信息
            SecondWorkStationInit(secondWorkStationID);

            lab_CurrentWorkStation.Text = secondWorkStationInfo.SecondWorkStationName;

            //更新本地时间
            UpdateSystemTime();

            this.user = user;
            //this.p_Main.BackColor = Color.FromArgb(0x4C, 0x56, 0x68);
            //this.mnuMain.BackColor = Color.FromArgb(0xBD, 0xBA, 0xBA);
            //this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.BackColor = Color.FromArgb(0x4C, 0x56, 0x68);
            this.status_Main.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            this.dgv_WorkDtl.AutoGenerateColumns = false;
            this.dgv_WorkMain.AutoGenerateColumns = false;
            if (flag)
            {
                btn_Confirm.Visible = false;
                lab_Model.Text = "当前模式：自动。";
            }
            toolStripStatusLabel1.Text = "操作员：" + user.UserName;
            toolStripStatusLabel2.Text = "登陆时间：" + DateTime.Now.ToLongTimeString();
            //if (MessageBox.Show("弹出框测试", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    MessageBox.Show("OK");
            //}

            if (tabflag == "0")
            {

            }
            else if (tabflag == "1")
            {
                tab_Main.TabPages.Remove(tabPage_ExceptionShow);
                this.Text = "鑫亚软控-RF扫描上线程序";
            }
            else
            {
                tab_Main.TabPages.Remove(tabPage_WorkCreate);
                this.Text = "鑫亚软控-返修区客户端";
            }
            //异常加载
            ExceptionDataInit();
            this.cbx_ExceptionSelect.DataSource = list_Exception;
            this.cbx_ExceptionSelect.DisplayMember = "ExceptionCode";
            this.cbx_ExceptionSelect.ValueMember = "ID";

        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//回车 - 完成
            {
                object a = new object();
                EventArgs b = new EventArgs();
                btn_Save_Click(a, b);
            }
            e.Handled = true;
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        /// <summary>
        /// 窗体关闭完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int flag = sc.LoginHelpForLoginOut(user.ID, secondWorkStationID, "");
                switch (flag)
                {
                    case 1:
                    case 4:
                    case 5:
                        LogExecute.WriteInfoLog("员工" + user.UserID + "登出记录失败", false);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogExecute.WriteInfoLog("退出记录失败,详情" + ex.ToString(), false);
            }
            Application.Exit();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        /// <summary>
        /// 文本框输入事件(自动模式)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Code_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("test");
            //先判断字符串是否是以0开头，以0开头的为托盘条码   
            if (flag)
            {
                string text = txt_Code.Text.ToString();
                if (text != "")
                {
                    string a;
                    a = text.Substring(0, 1);
                    if (a == "0")
                    {
                        if (text.Length == 4)
                        {
                            int exceptionInfo = AddWorkMain(text);
                            switch (exceptionInfo)
                            {
                                case 0:
                                    MessageBox.Show("检测到托盘条码不正确！请核对！");
                                    txt_Code.Focus();
                                    break;
                                case 1:
                                    MessageBox.Show("当前托盘编码已经录入，请误重复录入");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 2:
                                    MessageBox.Show("系统异常，托盘数据录入失败！请联系管理员！");
                                    txt_Code.Focus();
                                    break;
                                case 3:
                                    //自动模式下正常结束不提示
                                    //MessageBox.Show("托盘数据录入成功！");
                                    //录入成功后刷新dgv
                                    dgv_WorkMainInit();
                                    dgv_WorkDtlInit();
                                    //清空txt
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 4:
                                    MessageBox.Show("托盘号为" + text + "的任务已经提交，RF端无权再次编辑");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (text.Length == 23)//14.11.10 泵体条码长度改为23位
                        {
                            int exceptionInfo = AddWorkDtl(text);
                            switch (exceptionInfo)
                            {
                                case 0:
                                    MessageBox.Show("检测到物料条码不正确！请核对！");
                                    txt_Code.Focus();
                                    break;
                                case 1:
                                    MessageBox.Show("当前托盘编码未录入，请先录入托盘条码再录入泵体条码！");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 2:
                                    MessageBox.Show("系统异常，主任务读取失败！请联系管理员！");
                                    txt_Code.Focus();
                                    break;
                                case 3:
                                    MessageBox.Show("该泵体条码已经录入，请勿重复录入！");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 4:
                                    MessageBox.Show("系统异常，子任务保存失败！请联系管理员！");
                                    break;
                                case 5:
                                    //自动模式下正常结束不提示
                                    //MessageBox.Show("当前子任务录入成功！");
                                    //录入成功后刷新dgv
                                    dgv_WorkDtlInit();
                                    //清空txt
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 6:
                                    MessageBox.Show("当前系统中并不存在" + text.Substring(0, 12) + "型号的泵体！或者该型号未通过审核！请查证输入是否有误。");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                                case 7:
                                    MessageBox.Show("托盘号为" + text + "的任务已经提交，RF端无权再次编辑");
                                    txt_Code.Text = "";
                                    txt_Code.Focus();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 手动自动模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Switch_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                btn_Confirm.Visible = true;
                lab_Model.Text = "当前模式：手动。";
                txt_Code.Focus();
            }
            else
            {
                flag = true;
                btn_Confirm.Visible = false;
                lab_Model.Text = "当前模式：自动。";
                txt_Code.Focus();
            }
        }

        /// <summary>
        /// 手动模式下确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            string text = txt_Code.Text.ToString();
            if (text != "")
            {
                string a;
                a = text.Substring(0, 1);
                //"0"开头表示托盘
                if (a == "0")
                {
                    if (text.Length == 4)
                    {
                        int exceptionInfo = AddWorkMain(text);
                        switch (exceptionInfo)
                        {
                            case 0:
                                MessageBox.Show("检测到托盘条码不正确！请核对！");
                                txt_Code.Focus();
                                break;
                            case 1:
                                MessageBox.Show("当前托盘编码已经录入，请误重复录入");
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                            case 2:
                                MessageBox.Show("系统异常，托盘数据录入失败！请联系管理员！");
                                break;
                            case 3:
                                //录入成功后不再提示，提高效率，只有录入失败才提示
                                //MessageBox.Show("托盘数据录入成功！");
                                //录入成功后刷新dgv
                                dgv_WorkMainInit();
                                dgv_WorkDtlInit();
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                            case 4:
                                MessageBox.Show("托盘号为" + text + "的任务已经提交，RF端无权再次编辑");
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入托盘条码有误！请检查！");
                    }
                }
                else
                {
                    if (text.Length == 23) //14.11.10 泵体条码长度改为23位
                    {
                        int exceptionInfo = AddWorkDtl(text);
                        switch (exceptionInfo)
                        {
                            case 0:
                                MessageBox.Show("检测到物料条码不正确！请核对！");
                                txt_Code.Focus();
                                break;
                            case 1:
                                MessageBox.Show("当前托盘编码未录入，请先录入托盘条码再录入泵体条码！");
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                            case 2:
                                MessageBox.Show("系统异常，主任务读取失败！请联系管理员！");
                                break;
                            case 3:
                                MessageBox.Show("该泵体条码已经录入，请勿重复录入！");
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                            case 4:
                                MessageBox.Show("系统异常，子任务保存失败！请联系管理员！");
                                break;
                            case 5:
                                //录入成功后不再提示，提高效率，只有录入失败才提示
                                //MessageBox.Show("当前子任务录入成功！");
                                //录入成功后刷新dgv
                                dgv_WorkDtlInit();
                                txt_Code.Text = "";
                                break;
                            case 6:
                                MessageBox.Show("当前系统中并不存在" + text.Substring(0, 12) + "型号的泵体！或者该型号未通过审核！请查证输入是否有误。");
                                txt_Code.Focus();
                                break;
                            case 7:
                                MessageBox.Show("托盘号为" + text + "的任务已经提交，RF端无权再次编辑");
                                txt_Code.Text = "";
                                txt_Code.Focus();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入泵体条码有误！请检查！");
                    }
                }
            }
            else
            {
                MessageBox.Show("没有输入任何条码！");
            }
        }

        /// <summary>
        /// 删除当前全部任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            //先检测主任务是否存在
            if (wm == null)
            {
                MessageBox.Show("当前不存在任何主任务！");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //如果存在先删除它所对应的子任务
                    try
                    {
                        //重新加载主任务防止出错
                        wm = db.TB_WorkMain.First(p => p.PalletCode == wm.PalletCode && p.Finished == "0");
                        wm.TB_WorkDtl.Load();
                        //是否提交判断
                        if (wm.IsCommit == true)
                        {
                            MessageBox.Show("该任务已经提交，RF无法删除。");
                            return;
                        }
                        List<TB_WorkDtl> workDtls = wm.TB_WorkDtl.ToList();
                        foreach (var item in workDtls)
                        {
                            var a = db.TB_WorkDtl.First(p => p.ID == item.ID);

                            //如果是重新上线还要级联删除TB_WorkException表中的数据
                            //实际上这里只有1条数据
                            var copy = a.TB_WorkException.ToList();
                            for (int i = 0; i < a.TB_WorkException.Count; i++)
                            {
                                db.TB_WorkException.DeleteObject(copy[i]);
                            }

                            db.TB_WorkDtl.DeleteObject(a);
                            db.SaveChanges();
                            //这里对主任务表做一次刷新
                            wm = db.TB_WorkMain.Single(p => p.WorkID == wm.WorkID);

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除子任务失败！");
                        return;
                    }
                    try
                    {
                        var a = db.TB_WorkMain.First(p => p.WorkID == wm.WorkID);
                        db.TB_WorkMain.DeleteObject(a);
                        db.SaveChanges();
                        //主任务删除后，残留在系统的置空
                        wm = null;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("没有此主任务或删除主任务失败！");
                        return;
                    }
                }
                MessageBox.Show("操作成功！");
                //刷新
                dgv_WorkMainInit();
                dgv_WorkDtlInit();
            }
        }

        /// <summary>
        /// 删除当前主任务所对应的全部子任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearAllWorkDtl_Click(object sender, EventArgs e)
        {
            //先检测主任务是否存在
            if (wm == null)
            {
                MessageBox.Show("当前不存在任何主任务！");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //如果存在先删除它所对应的子任务
                    try
                    {
                        //重新加载主任务防止出错
                        wm = db.TB_WorkMain.First(p => p.PalletCode == wm.PalletCode && p.Finished == "0");
                        wm.TB_WorkDtl.Load();
                        //是否提交判断
                        if (wm.IsCommit == true)
                        {
                            MessageBox.Show("该任务已经提交，RF无法删除。");
                            return;
                        }
                        List<TB_WorkDtl> workDtls = wm.TB_WorkDtl.ToList();
                        foreach (var item in workDtls)
                        {
                            var a = db.TB_WorkDtl.First(p => p.ID == item.ID);

                            //如果是重新上线还要级联删除TB_WorkException表中的数据
                            //实际上这里只有1条数据
                            var copy = a.TB_WorkException.ToList();
                            for (int i = 0; i < a.TB_WorkException.Count; i++)
                            {
                                db.TB_WorkException.DeleteObject(copy[i]);
                            }

                            db.TB_WorkDtl.DeleteObject(a);
                            db.SaveChanges();
                            //这里对主任务表做一次刷新
                            wm = db.TB_WorkMain.Single(p => p.WorkID == wm.WorkID);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除子任务失败！");
                        return;
                    }
                }
                MessageBox.Show("操作成功！");
                //刷新
                dgv_WorkMainInit();
                dgv_WorkDtlInit();
            }
        }

        /// <summary>
        /// 删除当前主任务，如果有子任务会被级联删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearMainWork_Click(object sender, EventArgs e)
        {
            //先检测主任务是否存在
            if (wm == null)
            {
                MessageBox.Show("当前不存在任何主任务！");
                return;
            }
            if (MessageBox.Show("如果当前主任务包含其他子任务，则子任务也回被删除。确定这么操作么？", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //如果存在先删除它所对应的子任务
                    try
                    {
                        //重新加载主任务防止出错
                        wm = db.TB_WorkMain.First(p => p.PalletCode == wm.PalletCode && p.Finished == "0");
                        wm.TB_WorkDtl.Load();
                        //是否提交判断
                        if (wm.IsCommit == true)
                        {
                            MessageBox.Show("该任务已经提交，RF无法删除。");
                            return;
                        }
                        List<TB_WorkDtl> workDtls = wm.TB_WorkDtl.ToList();
                        foreach (var item in workDtls)
                        {
                            var a = db.TB_WorkDtl.First(p => p.ID == item.ID);

                            //如果是重新上线还要级联删除TB_WorkException表中的数据
                            //实际上这里只有1条数据
                            var copy = a.TB_WorkException.ToList();
                            for (int i = 0; i < a.TB_WorkException.Count; i++)
                            {
                                db.TB_WorkException.DeleteObject(copy[i]);
                            }

                            db.TB_WorkDtl.DeleteObject(a);
                            db.SaveChanges();
                            //这里对主任务表做一次刷新
                            wm = db.TB_WorkMain.Single(p => p.WorkID == wm.WorkID);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除子任务失败！");
                        return;
                    }
                    try
                    {
                        var a = db.TB_WorkMain.First(p => p.WorkID == wm.WorkID);
                        db.TB_WorkMain.DeleteObject(a);
                        db.SaveChanges();
                        //主任务删除后，残留在系统的置空
                        wm = null;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("没有此主任务或删除主任务失败！");
                        return;
                    }
                }
                MessageBox.Show("操作成功！");
                //刷新
                dgv_WorkMainInit();
                dgv_WorkDtlInit();
            }
        }

        /// <summary>
        /// 删除选定的子任务（暂定单行删除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearSelectedWorkDtl_Click(object sender, EventArgs e)
        {
            //判断当前是否有选中行
            if (dgv_WorkDtl.CurrentRow != null)
            {
                //获取该子任务的ID
                int id = Convert.ToInt32(dgv_WorkDtl.CurrentRow.Cells["Column6"].Value.ToString());
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //找出后删除
                        var a = db.TB_WorkDtl.First(p => p.ID == id);
                        //是否已经提交？
                        a.TB_WorkMainReference.Load();
                        if (a.TB_WorkMain.IsCommit == true)
                        {
                            MessageBox.Show("该任务已经提交，RF端无法删除！");
                            db.Dispose();
                            return;
                        }
                        //如果是重新上线还要级联删除TB_WorkException表中的数据
                        //实际上这里只有1条数据
                        var copy = a.TB_WorkException.ToList();
                        for (int i = 0; i < a.TB_WorkException.Count; i++)
                        {
                            db.TB_WorkException.DeleteObject(copy[i]);
                        }

                        db.TB_WorkDtl.DeleteObject(a);
                        db.SaveChanges();
                        //这里对主任务表做一次刷新
                        wm = db.TB_WorkMain.Single(p => p.WorkID == wm.WorkID);
                        //刷新
                        dgv_WorkMainInit();
                        dgv_WorkDtlInit();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("系统异常，删除失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("当前任务没有子任务或子任务没选中，请选中子任务再进行操作！");
            }
        }

        /// <summary>
        /// 任务提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //是否有主任务？
            if (wm == null)
            {
                MessageBox.Show("当前没有主任务数据！");
                return;
            }
            //判定，当没有子任务时阻止提交
            if (dgv_WorkDtl.Rows[0].Cells[0].Value == null || dgv_WorkDtl.Rows[0].Cells[0].Value.ToString()=="")
            {
                MessageBox.Show("系统不允许空任务运行，请至少给当前主任务增加一条子任务");
                return;
            }
            //先提示客户是否要提交
            if (MessageBox.Show("是否要提交？", "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //先判断这个工位是否是返修或分流
                    if (secondWorkStationInfo.WorkStationCode == "H" || secondWorkStationInfo.WorkStationCode == "D")
                    {
                        //先进行服务调用
                        try
                        {
                            int flag = sc.WritePLCAdressOnSHSD(secondWorkStationID, Convert.ToInt16(wm.PalletCode));
                            switch (flag)
                            {
                                case 1:
                                    MessageBox.Show("上位服务读取数据库失败！请联系管理员！");
                                    break;
                                case 2:
                                    MessageBox.Show("上位服务PLC打开失败！请联系管理员！");
                                    break;
                                case 3:
                                    MessageBox.Show("上位机服务指定PLC地址条码数据读取失败！请联系管理员！");
                                    break;
                                case 4:
                                    MessageBox.Show("上位机服务指定PLC地址写入失败！请联系管理员！");
                                    break;
                                case 5:
                                    MessageBox.Show("检测到当前工位上还存在未返板而占用工位的托盘，请先将该托盘返板后再进行提交工作！");
                                    break;
                                case 7:
                                    MessageBox.Show("检测到当前工位的阻挡位上有尚未进入工位的托盘，请先关闭旋钮开关，再完成即将到达工位的托盘任务，然后执行本次操作");
                                    break;
                                default:
                                    //任务提交操作
                                    try
                                    {
                                        //提交
                                        //将iscommit置true
                                        var a = db.TB_WorkMain.First(p => p.WorkID == wm.WorkID);
                                        a.IsCommit = true;
                                        db.SaveChanges();
                                        //刷新
                                        wm = null;
                                        dgv_WorkDtlInit();
                                        dgv_WorkMainInit();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("提交失败！");
                                    }
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("调用服务接口失败！请联系管理员！");
                            db.Dispose();
                            return;
                        }
                    }
                    else if (secondWorkStationInfo.WorkStationCode == "A")
                    {
                        try
                        {
                            //提交
                            //将iscommit置true
                            var a = db.TB_WorkMain.First(p => p.WorkID == wm.WorkID);
                            a.IsCommit = true;
                            db.SaveChanges();
                            //刷新
                            wm = null;
                            dgv_WorkDtlInit();
                            dgv_WorkMainInit();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("提交失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("检测到配置文件出错！请联系管理员！");
                    }
                }

            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 主表dgv数据加载(请在确保wm不为空的地方调用)
        /// </summary>
        public void dgv_WorkMainInit()
        {
            if (wm == null)
            {
                dgv_WorkMain.DataSource = null;
                return;
            }
            List<TB_WorkMain> workMain = new List<TB_WorkMain>();
            workMain.Add(wm);
            dgv_WorkMain.DataSource = workMain;
        }

        /// <summary>
        /// 子表dgv数据加载(请在确保wm不为空的地方调用)
        /// </summary>
        public void dgv_WorkDtlInit()
        {
            List<TB_WorkDtl> dtls;
            try
            {
                dtls = wm.TB_WorkDtl.ToList();
            }
            catch (Exception e)
            {
                //抛异常说明当前没有子任务存在
                dtls = null;
            }
            dgv_WorkDtl.DataSource = dtls;
        }

        #endregion

        #region 数据访问

        /// <summary>
        /// 添加主任务表数据
        /// 返回值
        /// 0：表示托盘条码不正确
        /// 1：表示主表数据已经存在
        /// 2：表示主任务数据保存失败
        /// 3：无异常结束
        /// 4：该任务已经提交，RF端无权编辑
        /// </summary>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public int AddWorkMain(string palletCode)
        {
            if (palletCode.Length != 4)
            {
                //MessageBox.Show("检测到托盘条码不正确，请核对！");
                return 0;
            }
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //首先判断这条主任务是否已经存在
                try
                {
                    wm = db.TB_WorkMain.First(p => p.PalletCode == palletCode && p.Finished == "0");
                    wm.TB_WorkDtl.Load();
                    //是否提交判断
                    if (wm.IsCommit == true)
                    {
                        return 4;
                    }
                }
                catch (Exception)
                {
                    wm = null;
                }
                if (wm != null)
                {
                    //返回1表示主表数据已经存在
                    //这里对当前任务表做一次刷新
                    dgv_WorkMainInit();
                    dgv_WorkDtlInit();
                    return 1;
                }
                else
                {
                    try
                    {
                        wm = new TB_WorkMain();
                        wm.PalletCode = palletCode;
                        wm.Finished = "0";
                        wm.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        wm.CreateDate = System.DateTime.Now;
                        //这里记录任务创建的来源工位
                        wm.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                        db.TB_WorkMain.AddObject(wm);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        //返回2表示主任务数据保存失败
                        return 2;
                    }
                }
            }
            //无异常结束返回3
            return 3;
        }

        /// <summary>
        /// 添加子任务表数据
        /// 返回值：
        /// 0：表示物料条码不正确
        /// 1：表示当前主任务不存在
        /// 2：表示主任务获取失败
        /// 3：表示该物料条码所对应的子任务已经存在
        /// 4：表示子任务存入数据库失败
        /// 5：表示正常结束
        /// 6：表示当前系统中不存在此种型号的泵体
        /// 7：该任务已经提交，RF端无权编辑
        /// 8: 记录异常泵信息失败
        /// </summary>
        /// <param name="materialCode"></param>
        /// <returns></returns>
        public int AddWorkDtl(string materialCode)
        {
            if (materialCode.Length != 23)
            {
                //返回0表示物料条码不正确
                return 0;
            }
            if (wm == null)
            {
                //返回1表示当前主任务不存在
                return 1;
            }
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                #region 当前系统中是否存在此型号判定

                string model = materialCode.Substring(0, 12);
                try
                {
                    var a = db.TB_MaterialInfo.First(p => p.TypeCode == model&&p.Audit==true);
                }
                catch (Exception)
                {
                    //返回6表示当前系统中不存在此种型号的泵体
                    return 6;
                }

                #endregion
                //首先获取该条主任务
                try
                {
                    wm = db.TB_WorkMain.First(p => p.PalletCode == wm.PalletCode && p.Finished == "0"&&p.WorkID==wm.WorkID);
                    wm.TB_WorkDtl.Load();
                    //是否提交判断
                    if (wm.IsCommit == true)
                    {
                        return 7;
                    }
                }
                catch (Exception e)
                {
                    //返回2表示主任务获取失败
                    return 2;
                }

                try
                {
                    //获取该主任务的所有子任务
                    List<TB_WorkDtl> dtls = wm.TB_WorkDtl.ToList();
                    //逐条匹配，检测是否已经存在该条物料条码信息
                    foreach (var item in dtls)
                    {
                        if (materialCode == item.MaterialCode)
                        {
                            //返回3表示该物料条码所对应的子任务已经存在
                            //这里对子任务表做一次刷新操作
                            dgv_WorkDtlInit();
                            return 3;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //表示当前主任务还没有子任务
                }
                try
                {
                    //如果没有则新建
                    TB_WorkDtl workDtl = new TB_WorkDtl();
                    workDtl.TB_WorkMain = db.TB_WorkMain.First(p => p.WorkID == wm.WorkID);
                    workDtl.PalletCode = wm.PalletCode;
                    workDtl.MaterialCode = materialCode;
                    workDtl.CreateDate = System.DateTime.Now;
                    //上线的时候默认没有异常
                    workDtl.IsException = false;
                    //10.30；加入子任务与物料的外键约束
                    workDtl.TB_MaterialInfo = db.TB_MaterialInfo.Single(p => p.TypeCode == model);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    //返回4表示子任务存入数据库失败
                    return 4;
                }
                //查看是否是在返修区上线，如果是则插入一条数据
                if (secondWorkStationInfo.WorkStationCode == "H" || secondWorkStationInfo.WorkStationCode == "D")
                {
                    try
                    {
                        //返修上线还需要记录上线信息（这里上线默认是已经返修好了的泵,所以不写入异常信息）
                        TB_WorkException workEception = new TB_WorkException();
                        wm.TB_WorkDtl.Load();
                        workEception.TB_WorkDtl = wm.TB_WorkDtl.First(p => p.MaterialCode == materialCode);
                        workEception.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                        //这里上线默认是已经返修好了的泵,所以不写入异常信息
                        workEception.ExceptionID = null;
                        workEception.TB_Exception = null;

                        workEception.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        workEception.Date = System.DateTime.Now;

                        //对这条记录进行区分
                        workEception.Remark = "重新上线";
                        db.TB_WorkException.AddObject(workEception);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return 8;
                    }
                }


            }
            //返回5表示正常结束
            return 5;
        }

        /// <summary>
        /// 工位信息初始化
        /// </summary>
        /// <param name="id"></param>
        private void SecondWorkStationInit(int id)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    secondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == id);
                    secondWorkStationInfo.TB_WorkStationInfoReference.Load();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败，请报告管理员");
                }
            }
        }


        #endregion

        #region 异常显示

        /// <summary>
        /// 完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Complete_Click(object sender, EventArgs e)
        {
            if (workException==null)
            {
                MessageBox.Show("未检测到可用于完成的数据，请核对后重试");
            }
            else
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //首先要找到这条记录
                        var repairRecord = db.TB_RepairRecord.Single(p => p.TB_WorkDtl.ID == workException.TB_WorkDtl.ID);
                        //有异常则更新异常参数
                        if (chk_IsScrap.Checked)
                        {
                            repairRecord.IsScrap = true;
                            //int id = Convert.ToInt32(cbx_ExceptionSelect.SelectedValue.ToString());
                            //150113这里不应该使用废弃的下拉框
                            string exceptionCode = txt_ExceptionCode.Text;
                            repairRecord.TB_Exception = db.TB_Exception.First(p => p.ExceptionCode == exceptionCode);
                        }
                        repairRecord.EndTime = DateTime.Now;
                        repairRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                        repairRecord.Remark = txt_Remark.Text;
                        db.SaveChanges();
                        MessageBox.Show("完成成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("完成出现异常！");
                        LogExecute.WriteDBExceptionLog(ex);
                    }
                }
            }
        }

        /// <summary>
        /// 异常数据加载
        /// </summary>
        public void ExceptionDataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    list_Exception = db.TB_Exception.ToList();
                }
                catch (Exception ex)
                {
                    LogExecute.WriteDBExceptionLog(ex);
                }
            }
        }

        /// <summary>
        /// 原定22位触发函数，现客户更改为23位，这里还是默认22位，后期统一改回来(已改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_ExceptionMaterialCode_TextChanged(object sender, EventArgs e)
        {
            if (txt_ExceptionMaterialCode.Text.Length == 23)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    //从workexception表中查找
                    //条件为泵体条码和异常信息，两者都没有则不符合要求，要么没异常，要么就是已经上线了
                    //先看它有没有重新上线
                    //考虑到泵体可能二次返修，这里始终取最新的一个
                    try
                    {
                        //加载最近的一条工作异常记录
                        workException = db.TB_WorkException.Where(p => p.TB_WorkDtl.MaterialCode == txt_ExceptionMaterialCode.Text).OrderByDescending(p => p.ID).First();
                        if (workException.Remark == "重新上线")
                        {
                            MessageBox.Show("条码为：" + txt_ExceptionMaterialCode.Text + "的泵已经重新上线！");
                            db.Dispose();
                            return;
                        }
                        else if (workException.ExceptionID != null)
                        {
                            //加载异常显示
                            txt_ExceptionShow.Text = workException.TB_Exception.ExceptionText;
                            //比对，返修记录表中是否有相对应的记录,有则跳过，没有则新增（不提供对开始时间的更新）
                            if (db.TB_RepairRecord.Count(p => p.TB_WorkDtl.ID == workException.TB_WorkDtl.ID) == 0)
                            {
                                TB_RepairRecord repairRecord = new TB_RepairRecord();
                                repairRecord.TB_WorkDtl = db.TB_WorkDtl.Single(p => p.ID == workException.TB_WorkDtl.ID);
                                repairRecord.BeginTime = DateTime.Now;
                                //用户数据加载在“完成”的时候加载
                                //repairRecord.TB_User = db.TB_User.First(p => p.ID == user.ID);
                                repairRecord.IsScrap = false;
                                db.TB_RepairRecord.AddObject(repairRecord);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            MessageBox.Show("针对编号为" + txt_ExceptionMaterialCode.Text + "的泵出现数据异常！可能是录入此异常员工删除了此异常！");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("未检索到针对于编码为" + txt_ExceptionMaterialCode.Text + "泵的数据！");
                    }
                }
            }
        }

        /// <summary>
        /// 确认,提供任意位数触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //从workexception表中查找
                //条件为泵体条码和异常信息，两者都没有则不符合要求，要么没异常，要么就是已经上线了
                //先看它有没有重新上线
                //考虑到泵体可能二次返修，这里始终取最新的一个
                try
                {
                    //加载最近的一条工作异常记录
                    workException = db.TB_WorkException.Where(p => p.TB_WorkDtl.MaterialCode == txt_ExceptionMaterialCode.Text).OrderByDescending(p => p.ID).First();
                    if (workException.Remark == "重新上线")
                    {
                        MessageBox.Show("条码为：" + txt_ExceptionMaterialCode.Text + "的泵已经重新上线！");
                        db.Dispose();
                        return;
                    }
                    else if (workException.ExceptionID != null)
                    {
                        //加载异常显示
                        txt_ExceptionShow.Text = workException.TB_Exception.ExceptionText;
                        //比对，返修记录表中是否有相对应的记录,有则跳过，没有则新增（不提供对开始时间的更新）
                        if (db.TB_RepairRecord.Count(p => p.TB_WorkDtl.ID == workException.TB_WorkDtl.ID) == 0)
                        {
                            TB_RepairRecord repairRecord = new TB_RepairRecord();
                            repairRecord.TB_WorkDtl = db.TB_WorkDtl.Single(p => p.ID == workException.TB_WorkDtl.ID);
                            repairRecord.BeginTime = DateTime.Now;
                            //用户数据加载在“完成”的时候加载
                            //repairRecord.TB_User = db.TB_User.First(p => p.ID == user.ID);
                            repairRecord.IsScrap = false;
                            db.TB_RepairRecord.AddObject(repairRecord);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        MessageBox.Show("针对编号为" + txt_ExceptionMaterialCode.Text + "的泵出现数据异常！可能是录入此异常员工删除了此异常！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("未检索到针对于编码为" + txt_ExceptionMaterialCode.Text + "泵的数据！");
                }
            }
        }

        /// <summary>
        /// 清空异常信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExceptionClearTxt_Click(object sender, EventArgs e)
        {
            txt_ExceptionShow.Text = "";
            txt_ExceptionMaterialCode.Text = "";
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
                txt_ExceptionSelectShow.Text = list_Exception.First(p => p.ID == Convert.ToInt32(cbx_ExceptionSelect.SelectedValue.ToString())).ExceptionText.ToString();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 选择故障码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectExceptionCode_Click(object sender, EventArgs e)
        {
            frm_ExceptionSelectHelper exchelper = new frm_ExceptionSelectHelper(1);
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
                        txt_ExceptionSelectShow.Text = exception.ExceptionText;
                    }
                    catch (Exception ex)
                    {
                        txt_ExceptionSelectShow.Text = "";
                        MessageBox.Show("加载异常描述的时候出现异常，具体请查看本地日志");
                        LogExecute.WriteExceptionLog("加载异常描述", ex);
                    }
                }
            }
        }

        #endregion

        #region 维护

        private void ping服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping p = new Ping();
            PingReply pr = p.Send(System.Configuration.ConfigurationSettings.AppSettings["ServerIP"]);
            if (pr.Status == IPStatus.Success)
            {
                MessageBox.Show("Ping 服务器 成功！");
            }
            else
            {
                MessageBox.Show("Ping 服务器 失败！");
            }
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        public void UpdateSystemTime()
        {
            try
            {
                UpdateTime.SetSysTime(sc.GetTimeNow());
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("更新本机时间",ex);
            }
        }

        #endregion

    }
}
