using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYaPCClientForVisualQCStation.DAL;
using System.IO;

namespace XinYaPCClientForVisualQCStation.UI
{
    public partial class frm_Main : Form
    {
        #region 字段属性

        /// <summary>
        /// 当前登录用户
        /// </summary>
        TB_User user;

        /// <summary>
        /// 异常列表
        /// </summary>
        List<TB_Exception> exceptions;

        /// <summary>
        /// 主任务
        /// </summary>
        TB_WorkMain workMain;

        /// <summary>
        /// 子任务
        /// </summary>
        List<TB_WorkDtl> workDtl;

        /// <summary>
        /// 客户端服务
        /// </summary>
        ServiceReference1.Service1Client service1Client = new ServiceReference1.Service1Client();

        /// <summary>
        /// 当前实际工位类别
        /// </summary>
        string stationCode = "";//System.Configuration.ConfigurationSettings.AppSettings["WorkStationCode"];

        /// <summary>
        /// 当前实际工位ID
        /// </summary>
        int secondWorkStationId =0;// Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["SecondWorkStationID"]);

        /// <summary>
        /// 当前实际工位名
        /// </summary>
        private string secondWorkStationName = "";// System.Configuration.ConfigurationSettings.AppSettings["Source"];

        /// <summary>
        /// 当前实际工位对象
        /// </summary>
        TB_SecondWorkStationInfo secondWorkStationInfo;

        /// <summary>
        /// 当前虚拟的工位类别
        /// </summary>
        string visual_stationCode ="";// System.Configuration.ConfigurationSettings.AppSettings["VisualWorkStationCode"];

        /// <summary>
        /// 当前虚拟的工位ID
        /// </summary>
        int visual_SecondWorkStationId =0;// Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["VisualSecondWorkStationID"]);

        /// <summary>
        /// 当前虚拟的工位名
        /// </summary>
        private string visual_SecondWorkStationName ="";// System.Configuration.ConfigurationSettings.AppSettings["VisualSource"];

        /// <summary>
        /// 当前虚拟工位名
        /// </summary>
        TB_SecondWorkStationInfo visual_SecondWorkStationInfo;

        /// <summary>
        /// 是否开启验证模式
        /// </summary>
        string verifyModel = "";//System.Configuration.ConfigurationSettings.AppSettings["VerifyModel"];

        /// <summary>
        /// xml配置文件路径
        /// </summary>
        string xmlPath = Properties.Settings.Default.XmlPath;

        /// <summary>
        /// QC 台使用，默认合格,true为有异常
        /// </summary>
        bool exception = false;

        /// <summary>
        /// 日志类
        /// </summary>
        LogExecute log = new LogExecute();

        /// <summary>
        /// 12.18号，增加任务到达开始时间记录
        /// </summary>
        DateTime workBeginTime = DateTime.Now;

        /// <summary>
        /// 将要被QC质检的调试台路线记录ID
        /// </summary>
        int workDtlForEachStationIDForQCRecord = 0;

        #endregion

        #region 窗体与事件
        public frm_Main(TB_User user)
        {
            this.user = user;

            InitializeComponent();

            #region 读取配置文件

            try
            {
                //实际
                secondWorkStationId = Convert.ToInt32(XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationID"));
                //secondWorkStationName = XMLHelper.ReadXML(xmlPath, "XinYa", "Source");
                //stationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "WorkStationCode");
                //secondWorkStationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "SecondWorkStationCode");
                //printName = XMLHelper.ReadXML(xmlPath, "XinYa", "PrintName");
                verifyModel = XMLHelper.ReadXML(xmlPath, "XinYa", "VerifyModel");
                //虚拟
                //visual_stationCode = XMLHelper.ReadXML(xmlPath, "XinYa", "VisualWorkStationCode");
                visual_SecondWorkStationId =Convert.ToInt32(XMLHelper.ReadXML(xmlPath, "XinYa", "VisualSecondWorkStationID"));
                //visual_SecondWorkStationName = XMLHelper.ReadXML(xmlPath, "XinYa", "VisualSource");
            }
            catch (Exception)
            {
                MessageBox.Show("检测到配置文件出错，程序即将关闭，请联系管理员解决问题。");
                Application.Exit();
            }

            #endregion

            //更新系统时间
            UpdateSystemTime();
            //工位对象初始化
            DataInit();

            DateTime dt = DateTime.Now;
            sta_Main.Items[0].Text = "操作员：" + user.UserName;
            sta_Main.Items[1].Text = "日期：" + dt.ToShortDateString();//ToLongDateString();
            sta_Main.Items[2].Text = "登录时间：" + dt.ToLongTimeString();
            lab_CurrentWorkStation.Text = secondWorkStationInfo.SecondWorkStationName;
            //this.p_Main.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
            //this.mnuMain.BackColor = Color.FromArgb(0xBD, 0xBA, 0xBA);
            //this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
            //设置不自动生成列
            this.dgv_WorkDtl.AutoGenerateColumns = false;
            this.dgv_WorkMain.AutoGenerateColumns = false;
            tabControl1.SelectedTab = tabControl1.TabPages[1];

            //验证模式
            if (verifyModel == "true")
            {
                lab_Moshi.Text = "当前模式:验证模式";
            }
            else
            {
                lab_Moshi.Text = "当前模式：非验证模式";
            }


            //文本框只读
            TextReadOnly();

            //是否QC台？
            //这里验证虚拟工位类别，始终启用QC模式
            if (visual_SecondWorkStationInfo.WorkStationCode == "F")
            {
                btn_AddException.Visible = false;
                btn_ClearException.Visible = false;
                chk_IsException.Visible = true;
                lab_buhegebianma.Visible = true;
                lab_Ishege.Visible = true;
                txt_buhegebianma.Visible = true;
                btn_AddQCExceptionInfo.Visible = true;
            }
            else
            {
                btn_ClearException.Visible = true;
                btn_AddException.Visible = true;
                chk_IsException.Visible = false;
                lab_buhegebianma.Visible = false;
                lab_Ishege.Visible = false;
                txt_buhegebianma.Visible = false;
                btn_AddQCExceptionInfo.Visible = false;
            }
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        public void UpdateSystemTime()
        {
            try
            {
                UpdateTime.SetSysTime(service1Client.GetTimeNow());
            }
            catch (Exception ex)
            {
                LogExecute.WriteExceptionLog("更新本机时间", ex);
            }
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu101_Click(object sender, EventArgs e)
        {
            new frm_Login().Show();
            this.Hide();
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu102_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int flag = service1Client.LoginHelpForLoginOut(user.ID, secondWorkStationId, "");
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

        /// <summary>
        /// dgv_WorkMain加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkMain.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkMain.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkMain.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkMain.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// dgv_WorkDtl加载复杂类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_WorkDtl_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_WorkDtl.Rows[e.RowIndex].DataBoundItem != null) && (dgv_WorkDtl.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_WorkDtl.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_WorkDtl.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 快捷键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("您按下了" + e.KeyCode.ToString() + e.KeyData.ToString() + e.KeyValue.ToString());
            if (e.KeyValue == 39)//右箭头 - 向右翻页
            {
                if (tabControl1.SelectedIndex == 2)
                {
                    return;
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[2];
                }
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
            }
            if (e.KeyValue == 37)//左箭头 - 向左翻页
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    return;
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                }
                if (tabControl1.SelectedIndex == 2)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
            }
            if (e.KeyValue == 13)//回车 - 完成
            {
                object a = new object();
                EventArgs b = new EventArgs();
                btn_Save_Click(a, b);
            }
            //if (e.KeyValue == 65)//A - 工作台1
            //{
            //    if (btn_Station1.Enabled == true)
            //    {
            //        object a = new object();
            //        EventArgs b = new EventArgs();
            //        btn_Station1_Click(a, b);
            //    }
            //}
            //if (e.KeyValue == 83)//s - 工作台2
            //{
            //    if (btn_Station2.Enabled == true)
            //    {
            //        object a = new object();
            //        EventArgs b = new EventArgs();
            //        btn_Station2_Click(a, b);
            //    }
            //}
            //if (e.KeyValue == 83) //s - 确认
            //{
            //    object a = new object();
            //    EventArgs b = new EventArgs();
            //    btn_Confirm_Click(a, b);
            //}
            //分页控件有自己默认写好的翻页事件，这里屏蔽掉自带的防止连带翻页
            e.Handled = true;
        }

        #endregion

        #region 杂项
        //test
        private void button1_Click(object sender, EventArgs e)
        {
            lab_CurrentStatus.Text = service1Client.PLCReadAndWriteTest(txt_PalletCodeTest.Text.ToString(), Convert.ToInt16(txt_PalletCodeValueTest.Text), true).ToString();
        }

        //test
        private void button2_Click(object sender, EventArgs e)
        {
            #region 任务完成处理

            //不是每一个工位都有权限完成任务的，现在为外观检测。
            switch (service1Client.WorkTaskComplete(138, "0001", user.ID))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    MessageBox.Show("完成任务失败！");
                    break;
            }

            #endregion
            lab_CurrentStatus.Text = service1Client.PLCReadAndWriteTest(txt_PalletCodeTest.Text.ToString(), 123, false).ToString();
        }
        #endregion

        #region 任务相关

        /// <summary>
        /// 任务完成提交（该函数未写完10.6）（H和D工位的需要迁移）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 开始前的验证
            //判断当前是否有主任务存在
            if (workMain == null)
            {
                MessageBox.Show("当前没有任何数据可用于提交！");
                return;
            }
            //再次提醒员工比对任务托盘信息
            if (MessageBox.Show("当前托盘号为" + workMain.PalletCode + ",是否确认完成该托盘所在的任务？", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //QC是否合格
            exception = chk_IsException.Checked;
            //选择了不合格则他必须有一个不合格的异常
            if (exception)
            {
                if (string.IsNullOrEmpty(txt_buhegebianma.Text))
                {
                    MessageBox.Show("如果勾选了不合格，则必须要有一个不合格编码");
                    return;
                }
            } 
            #endregion

            //完成标志位，只有所有的读取操作都成功后，才进行地址写入
            //初始为0，有异常记录则自增
            int flagForComplete = 0;
            //记录下当前任务路线的ID值(这个不是调试台的记录ID)
            int workDtlForEachStationID = 0;

            #region 当前工位workDtlForEachStation处理(完成)、QC记录处理

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                #region 2015.1.11增加对托盘地址的判定，当存在一个托盘有去向地址时，阻止另一个托盘的去向地址的写入，以防止无法放出托盘
                if (secondWorkStationInfo.SecondWorkStationCode == "SE" || secondWorkStationInfo.SecondWorkStationCode == "SF")
                {
                    //获取2个工作区的托盘地址和去向地址
                    int palletCode1 = (int)db.TB_PLCBaseAdressInfo.Single(p => p.Adress == secondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
                    int palletCode2 = (int)db.TB_PLCBaseAdressInfo.Single(p => p.Adress == secondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode2).Data;
                    int toPosition1 = (int)db.TB_PLCBaseAdressInfo.Single(p => p.Adress == secondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
                    int toPosition2 = (int)db.TB_PLCBaseAdressInfo.Single(p => p.Adress == secondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.ToPositCode2).Data;
                    //只要满足有一个工作区的去向地址和对应托盘地址均不为0，说明已经完成了一个，这个时候不允许第二个放出来
                    //if ((palletCode1 != 0 && toPosition1 != 0) || (palletCode2 != 0 && toPosition2 != 0))
                    //{
                    //    MessageBox.Show("系统检测到您已经完成了一个托盘，在您继续完成时请将先前完成的托盘放出后再进行本次操作。");
                    //    db.Dispose();
                    //    return;
                    //}
                    //对于在线质检，这个条件不成立，在线质检的条件应该为只要有一个托盘编码不为0，地址不为0或者1，则阻止写入
                    if ((palletCode1 != 0 && toPosition1 != 0&&toPosition1!=1)||(palletCode2 != 0 && toPosition2 != 0&&toPosition2!=1) )
                    {
                        MessageBox.Show("系统检测到您已经质检了一个托盘，在您继续完成时请将先前完成的托盘放出后再进行本次操作。");
                        db.Dispose();
                        return;
                    }
                }

                #endregion

                #region 当前工位workDtlForEachStation处理(完成)(对于虚拟的QC台，工艺路线记录需要记录到虚拟工位，否则工时数据会出错,这里新增并插入一条数据)

                //考虑到重复提交完成，先检查该工位是否存在记录，存在的话更新workendtime,不存在新建一条记录，时间写入workendtime
                TB_WorkDtlForEachStation a;
                try
                {
                    //a = db.TB_WorkDtlForEachStation.First(p => p.WorkMainID == workMain.WorkID&&p.SecondWorkStationID==secondWorkStationId);
                    //这里始终加载最新的一条，在上位机PLC主控程序中，始终写入一行，这样就能一一对应
                    //a = (TB_WorkDtlForEachStation)db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == workMain.WorkID && p.SecondWorkStationID == secondWorkStationId).OrderByDescending(p => p.ID).First();
                    //查找对应的虚拟工位的记录
                    a = (TB_WorkDtlForEachStation)db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == workMain.WorkID && p.SecondWorkStationID == visual_SecondWorkStationId).OrderByDescending(p => p.ID).First();
                }
                catch (Exception)
                {
                    a = null;
                }
                if (a != null)
                {
                    try
                    {
                        a.WorkEndTime = System.DateTime.Now;
                        //记录下当前的操作员
                        a.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                        db.SaveChanges();
                        //记录下ID值
                        workDtlForEachStationID = a.ID;
                    }
                    catch (Exception)
                    {
                        flagForComplete++;
                        MessageBox.Show("更新工位工作任务完成时间失败");
                    }
                }
                else
                {
                    //初次为新增
                    try
                    {
                        TB_WorkDtlForEachStation workDtlForEachStation = new TB_WorkDtlForEachStation();
                        workDtlForEachStation.TB_WorkMain = db.TB_WorkMain.First(p => p.WorkID == workMain.WorkID);
                        //workDtlForEachStation.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationId);
                        //bug修改对于在线QC来说，工艺路线记录在虚拟的第一QC位。
                        workDtlForEachStation.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == visual_SecondWorkStationId);
                        workDtlForEachStation.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        //这里记录下开始时间
                        workDtlForEachStation.WorkBeginTime = workBeginTime;
                        workDtlForEachStation.WorkEndTime = System.DateTime.Now;
                        db.TB_WorkDtlForEachStation.AddObject(workDtlForEachStation);
                        db.SaveChanges();
                        //记录下返回的ID值
                        workDtlForEachStationID = workDtlForEachStation.ID;
                    }
                    catch (Exception)
                    {
                        flagForComplete++;
                        MessageBox.Show("保存工位工作数据失败！请联系管理员！");
                    }
                }

                #endregion 当前工位workDtlForEachStation处理(完成)

                #region QC记录

                //当前如果为QC台
                //这里可以注释掉也可以改为虚拟
                if (visual_SecondWorkStationInfo.WorkStationCode == "F")
                {
                    //考虑到可以重复提交这里需要对QC记录是否需要更新做一个判断
                    if (db.TB_QCRecord.Count(p=>p.WorkDtlForEachStationID==workDtlForEachStationIDForQCRecord&&p.QCSecondWorkStationID==visual_SecondWorkStationId)>0)
                    {
                        try
                        {
                            //大于0表示有，则更新
                            //找到这条记录
                            var qcRecord = db.TB_QCRecord.First(p => p.WorkDtlForEachStationID == workDtlForEachStationIDForQCRecord && p.QCSecondWorkStationID == visual_SecondWorkStationId);
                            if (chk_IsException.Checked)
                            {
                                //不合格
                                qcRecord.IsQualified = true;
                                //这里需要保证异常编码唯一
                                string exceptionCode = txt_buhegebianma.Text;
                                qcRecord.TB_Exception = db.TB_Exception.Single(p => p.ExceptionCode == exceptionCode);
                                qcRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                qcRecord.QCDate = DateTime.Now;
                            }
                            else
                            {
                                //合格
                                //不合格
                                qcRecord.IsQualified = false;
                                //这里需要保证异常编码唯一
                                //string exceptionCode = txt_buhegebianma.Text;
                                qcRecord.ExceptionID = null;
                                qcRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                qcRecord.QCDate = DateTime.Now;
                            }
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            flagForComplete++;
                            MessageBox.Show("更新QC记录出现异常。");
                            LogExecute.WriteExceptionLog("更新QC记录出现异常。",ex);
                        }
                    }
                    else
                    {
                        //==0则表示没有，则新增
                        //QC是否合格
                        if (chk_IsException.Checked)
                        {
                            try
                            {
                                //不合格
                                //新增一条记录
                                TB_QCRecord qcRecord = new TB_QCRecord();
                                //这里记录的应该是任务到达调试台的记录
                                //qcRecord.TB_WorkDtlForEachStation = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == workMain.WorkID && p.TB_SecondWorkStationInfo.WorkStationCode == "E").OrderByDescending(p => p.ID).First();
                                qcRecord.TB_WorkDtlForEachStation = db.TB_WorkDtlForEachStation.Single(p => p.ID == workDtlForEachStationIDForQCRecord);
                                qcRecord.IsQualified = true;
                                //这里需要保证异常编码唯一
                                string exceptionCode = txt_buhegebianma.Text;
                                qcRecord.TB_Exception = db.TB_Exception.Single(p => p.ExceptionCode == exceptionCode);
                                qcRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                qcRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationId);
                                qcRecord.QCDate = DateTime.Now;
                                db.TB_QCRecord.AddObject(qcRecord);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                flagForComplete++;
                                MessageBox.Show("录入质检信息的时候出现问题，请联系管理员报告问题。这可能是由于这个托盘未经过调试无法产生质检，具体请查看本地日志！");
                                LogExecute.WriteExceptionLog("录入质检信息的时候出现问题，请联系管理员报告问题。这可能是由于这个托盘未经过调试无法产生质检，具体请查看本地日志！", ex);
                            }
                        }
                        else
                        {
                            try
                            {
                                //合格
                                //新增一条记录
                                TB_QCRecord qcRecord = new TB_QCRecord();
                                //这里记录的应该是任务到达调试台的记录
                                //qcRecord.TB_WorkDtlForEachStation = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == workMain.WorkID && p.TB_SecondWorkStationInfo.WorkStationCode == "E").OrderByDescending(p => p.ID).First();
                                qcRecord.TB_WorkDtlForEachStation = db.TB_WorkDtlForEachStation.Single(p => p.ID == workDtlForEachStationIDForQCRecord);
                                qcRecord.IsQualified = false;
                                //这里需要保证异常编码唯一
                                //string exceptionCode = txt_buhegebianma.Text;
                                //qcRecord.TB_Exception = db.TB_Exception.Single(p => p.ExceptionCode == exceptionCode);
                                qcRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
                                qcRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationId);
                                qcRecord.QCDate = DateTime.Now;
                                db.TB_QCRecord.AddObject(qcRecord);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                flagForComplete++;
                                MessageBox.Show("录入质检信息的时候出现问题，请联系管理员报告问题。这可能是由于这个托盘未经过调试无法产生质检，具体请查看本地日志！");
                                LogExecute.WriteExceptionLog("录入质检信息的时候出现问题，请联系管理员报告问题。这可能是由于这个托盘未经过调试无法产生质检，具体请查看本地日志！", ex);
                            }
                        }
                    }
                }

                #endregion QC记录
            }
            #endregion

            if (flagForComplete==0)
            {
                #region PLC地址处理(对于虚拟的QC台，地址应写入实际的工位中)

                //先判别改工位类别
                switch (secondWorkStationInfo.WorkStationCode)
                {
                    case "F":
                    //QC台需要对一个合不合格的记录
                    case "E":
                        //实验台和QC台调用
                        int flag = 1;
                        try
                        {
                            //这个方法已经不适用
                            //flag = service1Client.WritePLCAdressOnSESF(secondWorkStationId, Convert.ToInt16(workMain.PalletCode), exception);
                            //这里需要将合格与不合格的地址写入到实际地址中
                            flag = service1Client.WritePLCAdressOnSESFForVisualQCStation(secondWorkStationId, Convert.ToInt16(workMain.PalletCode), exception);
                        }
                        catch
                        {
                            MessageBox.Show("服务调用失败！处理中止！请联系管理员！");
                            return;
                        }
                        switch (flag)
                        {
                            case 1:
                                MessageBox.Show("上位机数据库读取失败！处理中止！请联系管理员！");
                                return;
                            case 2:
                                MessageBox.Show("PLC连接失败！处理中止！请联系管理员！");
                                return;
                            case 3:
                                MessageBox.Show("PLC指定条码读取失败！处理中止！请联系管理员！");
                                return;
                            case 4:
                                MessageBox.Show("注意：当前托盘：" + txt_PalletCode.Text + "并不在当前工位存在！处理中止！请再次核实托盘条码是否正确！");
                                return;
                            case 5:
                                MessageBox.Show("PLC试验台地址数据写入失败！处理中止！请联系管理员！");
                                return;
                            case 6:
                                MessageBox.Show("QC台地址数据写入失败！处理中止！请联系管理员！");
                                return;
                            default:
                                //正常
                                //MessageBox.Show("任务提交成功！");
                                lab_CurrentStatus.Text = "无";
                                break;
                        }
                        break;

                    #region MyRegion
                    //case "H":
                    //case "D":
                    //    //返修和分流工位（写入条码，地址由上位机写入）（需要迁移）
                    //    int flag2 = 1;
                    //    try
                    //    {
                    //        flag2 = service1Client.WritePLCAdressOnSHSD(workStationId, Convert.ToInt16(txt_PalletCode.Text));
                    //    }
                    //    catch
                    //    {
                    //        MessageBox.Show("服务调用失败！请联系管理员！");
                    //        return;
                    //    }
                    //    switch (flag2)
                    //    {
                    //        case 1:
                    //            MessageBox.Show("上位机数据库读取失败！请联系管理员！");
                    //            return;
                    //        case 2:
                    //            MessageBox.Show("PLC连接失败！请联系管理员！");
                    //            return;
                    //        case 3:
                    //            MessageBox.Show("PLC指定条码读取失败！请联系管理员！");
                    //            return;
                    //        case 4:
                    //            MessageBox.Show("PLC指定地址条码写入失败！请联系管理员！");
                    //            return;
                    //        case 5:
                    //            MessageBox.Show("注意：请先将工位上的托盘返板，然后再进行本操作！");
                    //            return;
                    //        default:
                    //            //正常情况
                    //            MessageBox.Show("任务提交成功！");
                    //            break;
                    //    }
                    //    break;
                    //default:
                    //    //非试验、QC和重新上线不需要写入地址
                    //    //正常
                    //    MessageBox.Show("任务提交成功！");
                    //    break;
                    #endregion

                }

                #endregion

                #region 完成后数据清空处理

                //提交前，清空对应内存地址中的托盘编码
                //str_PalletCodes[flag] = "0000";
                //清空文本显示和dgv
                Clear();
                //清空主任务和子任务
                workDtl = null;
                workMain = null;

                #endregion

                MessageBox.Show("提交成功！");
            }
            else
            {
                MessageBox.Show("检测到在提交完成期间出现异常，处理中止。请处理完异常后再进行操作！");
            }
        }

        /// <summary>
        /// 输入托盘编码确认后的一些列数据加载操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            string palletCode;
            if (string.IsNullOrEmpty(txt_PalletCode.Text))
            {
                MessageBox.Show("请先输入托盘条码！");
                return;
            }
            else
            {
                palletCode = IntToStringfor4Length(txt_PalletCode.Text);
            }

            #region 对于QC台，在显示参数的时候是否需要验证此泵经过试验台
            //这里启用的是虚拟的QC台
            if (visual_SecondWorkStationInfo.WorkStationCode == "F" && verifyModel == "true")
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //根据托盘条码找任务
                        var wm = db.TB_WorkMain.First(p => p.PalletCode == palletCode && p.Finished == "0");
                        var a = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == wm.WorkID && p.TB_SecondWorkStationInfo.WorkStationCode == "E").OrderByDescending(p => p.ID).First();
                        //通过验证的话记录下这条任务路线的ID。
                        workDtlForEachStationIDForQCRecord = a.ID;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("检测到该托盘未经过调试,或者输入托盘号码有误。无法QC质检，请核对!");
                        LogExecute.WriteExceptionLog("检测到该托盘未经过调试，或者输入托盘号码有误。无法QC质检，请核对!", ex);
                        db.Dispose();
                        txt_PalletCode.Text = "";
                        txt_PalletCode.Focus();
                        return;
                    }
                }
            }

            #endregion

            #region 对于指定工位，不需要这个条件(对于虚拟的QC台，需要这个条件，使用实际工位ID，获取实际地址数据)
            //14.11.8
            //这里对员工输入的托盘做一个匹配，判断是否在当前实际PLC地址中存在这个托盘，以免员工输入错的托盘编码导致出现数据混乱
            //
            string[] palleCodes = service1Client.GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation(secondWorkStationId);
            if (palleCodes == null)
            {
                MessageBox.Show("上位服务调用失败。");
            }
            else
            {
                int flag = 0;
                //遍历
                for (int i = 0; i < palleCodes.Length; i++)
                {
                    //是否存在判断
                    if (palletCode == palleCodes[i])
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    //不存在
                    MessageBox.Show("当前输入的托盘编码并不在该工位上存在，或者还未完成。");
                    txt_PalletCode.Text = "";
                    txt_PalletCode.Focus();
                    return;
                }
            }
            //
            //====================================================================
            // 
            #endregion

            //不加载异常泵
            DataInit(false);

            //记录下任务到达时间，也就是开始处理时间
            workBeginTime = DateTime.Now;

            #region 当前工位workDtlForEachStation处理(完成)（对于QC位和虚拟QC位，路线记录在完成时新增或更新，此处代码在虚拟QCPC端注释，在其他PC端做选择判断）
            /*
            if (workMain != null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {

                    //先检查该工位是否存在记录，存在的话更新workbegintime,不存在新建一条记录，时间写入workbegintime
                    TB_WorkDtlForEachStation a;
                    try
                    {
                        //a = db.TB_WorkDtlForEachStation.First(p => p.WorkMainID == workMain.WorkID&&p.SecondWorkStationID==secondWorkStationId);
                        //这里始终加载最新的一条，在上位机PLC主控程序中，始终写入一行，这样就能一一对应
                        a = (TB_WorkDtlForEachStation)db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == workMain.WorkID && p.SecondWorkStationID == secondWorkStationId).OrderByDescending(p => p.ID).First();
                    }
                    catch (Exception)
                    {
                        a = null;
                    }
                    if (a != null)
                    {
                        try
                        {
                            a.WorkBeginTime = System.DateTime.Now;
                            db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("更新工位工作任务路线记录失败");
                            db.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        //正常情况下这段代码是访问不到的
                        try
                        {
                            TB_WorkDtlForEachStation workDtlForEachStation = new TB_WorkDtlForEachStation();
                            workDtlForEachStation.TB_WorkMain = db.TB_WorkMain.First(p => p.WorkID == workMain.WorkID);
                            workDtlForEachStation.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationId);
                            //完成者的录入赢放入“完成”事件中
                            //workDtlForEachStation.TB_User = db.TB_User.First(p => p.ID == user.ID);
                            workDtlForEachStation.WorkBeginTime = System.DateTime.Now;
                            db.TB_WorkDtlForEachStation.AddObject(workDtlForEachStation);
                            db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("保存工位工作数据失败！请联系管理员！");
                            db.Dispose();
                            return;
                        }
                    }
                }
            }
             * */
            #endregion

            txt_PalletCode.Text = "";
            txt_PalletCode.Focus();
        }

        /// <summary>
        /// 自动响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_PalletCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PalletCode.Text.ToString()) && txt_PalletCode.Text.ToString().Length == 4)
            {
                string palletCode = txt_PalletCode.Text.ToString();

                #region 对于QC台，在显示参数的时候是否需要验证此泵经过试验台
                //这里启用的是虚拟的QC台
                if (visual_SecondWorkStationInfo.WorkStationCode == "F" && verifyModel == "true")
                {
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            //根据托盘条码找任务
                            var wm = db.TB_WorkMain.First(p => p.PalletCode == palletCode && p.Finished == "0");
                            var a = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == wm.WorkID && p.TB_SecondWorkStationInfo.WorkStationCode == "E").OrderByDescending(p => p.ID).First();
                            //通过验证的话记录下这条任务路线的ID。
                            workDtlForEachStationIDForQCRecord = a.ID;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("检测到该托盘未经过调试,或者输入托盘号码有误。无法QC质检，请核对!");
                            LogExecute.WriteExceptionLog("检测到该托盘未经过调试，或者输入托盘号码有误。无法QC质检，请核对!", ex);
                            db.Dispose();
                            txt_PalletCode.Text = "";
                            txt_PalletCode.Focus();
                            return;
                        }
                    }
                }

                #endregion

                #region 对于指定工位，不需要这个条件(对于虚拟的QC台，需要这个条件，使用实际工位ID，获取实际地址数据)
                //14.11.8
                //这里对员工输入的托盘做一个匹配，判断是否在当前实际PLC地址中存在这个托盘，以免员工输入错的托盘编码导致出现数据混乱
                //
                string[] palleCodes = service1Client.GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation(secondWorkStationId);
                if (palleCodes == null)
                {
                    MessageBox.Show("上位服务调用失败。");
                }
                else
                {
                    int flag = 0;
                    //遍历
                    for (int i = 0; i < palleCodes.Length; i++)
                    {
                        //是否存在判断
                        if (palletCode == palleCodes[i])
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        //不存在
                        MessageBox.Show("当前输入的托盘编码并不在该工位上存在，或者还未完成。");
                        txt_PalletCode.Text = "";
                        txt_PalletCode.Focus();
                        return;
                    }
                }
                //
                //====================================================================
                // 
                #endregion

                //不加载异常泵
                DataInit(false);

                //记录下任务到达时间，也就是开始处理时间
                workBeginTime = DateTime.Now;
                txt_PalletCode.Text = "";
                txt_PalletCode.Focus();
            }
        }

        #endregion

        #region 故障相关
        /// <summary>
        /// 录入故障码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddException_Click(object sender, EventArgs e)
        {
            //判断dgv_WorkDtl是否有选中当前列
            if (dgv_WorkDtl.CurrentRow != null&&dgv_WorkDtl.DataSource!=null)
            {
                TB_WorkDtl wd = workDtl.First(p => p.ID == Convert.ToInt32(dgv_WorkDtl.CurrentRow.Cells["Column6"].Value.ToString()));
                frm_Exception frm_excption = new frm_Exception(wd, exceptions, user, secondWorkStationId);
                frm_excption.ShowDialog();
                //刷新,加载异常泵
                DataInit(true);
            }
            else
            {
                MessageBox.Show("当前没有选中任何行，请重新选中第二张表中的行！");
                return;
            }
        }

        /// <summary>
        /// 清除选定行故障信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearException_Click(object sender, EventArgs e)
        {
            //判断dgv_WorkDtl是否有选中当前列
            if (dgv_WorkDtl.CurrentRow != null&&dgv_WorkDtl.DataSource!=null)
            {
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        int id = Convert.ToInt32(dgv_WorkDtl.CurrentRow.Cells["Column6"].Value.ToString());
                        TB_WorkDtl wd = db.TB_WorkDtl.First(p => p.ID == id);
                        wd.TB_Exception = null;
                        wd.WorkStatus = null;
                        wd.IsException = false;
                        wd.TB_WorkException.Load();
                        //录入者信息
                        wd.WorkStatusEditor = null;
                        wd.EditTime = null;
                        //删除异常录入工位
                        wd.ExceptionSecondWorkStationID = null;
                        db.SaveChanges();
                        //判断是否在异常表中有对应的数据
                        if (wd.TB_WorkException.Count != 0)
                        {
                            //删除对应数据
                            var a = db.TB_WorkException.First(p => p.WorkDtlID == wd.ID);
                            db.TB_WorkException.DeleteObject(a);
                            db.SaveChanges();
                        }
                        MessageBox.Show("删除指定行异常信息成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除指定行异常信息失败！");
                    }
                }

                //刷新,这里加载异常泵
                DataInit(true);
            }
            else
            {
                MessageBox.Show("当前没有选中任何行，请重新选中第二张表中的行！");
                return;
            }
        }
        #endregion

        #region 显示和数据加载相关

        /// <summary>
        /// 文本框初始化
        /// </summary>
        /// <param name="mat"></param>
        public void TextInit(TB_MaterialInfo mat)
        {
            if (mat != null)
            {
                if (mat.Class == "VE")
                {
                    lab_CurrentStatus.Text = DateTime.Now.ToString()+"数据加载完成，请转到第一页查看工艺参数!";

                    #region VE

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
                    try
                    {
                        //图片
                        byte[] image = mat.Photo;
                        //图片显示
                        MemoryStream mStream = new MemoryStream();
                        mStream.Write(image, 0, image.Length);
                        mStream.Flush();
                        Bitmap img = new Bitmap(mStream);
                        pb_BengPicture.Image = img;
                    }
                    catch (Exception ex)
                    {
                        pb_BengPicture.Image = null;
                    }
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

                    #endregion
                }
                else if (mat.Class == "BQ")
                {
                    lab_CurrentStatus.Text = DateTime.Now.ToString() + "数据加载完成，请转到第三页查看工艺参数!";

                    #region 通用赋值

                    txt_BQChanpingbianma.Text = mat.TypeCode;
                    txt_BQMaterialName.Text = mat.MaterialName;
                    txt_BQPeitaochuangjia.Text = mat.Peitaochuangjia;
                    txt_BQZhusai.Text = mat.Zhusai;
                    txt_BQDinghuobianhao.Text = mat.Dinghuobianhao;
                    txt_BQYuxingcheng.Text = mat.Yuxingcheng;
                    txt_BQMohehouzhuanggaiban.Text = mat.BQMohehouzhuanggaiban;
                    txt_BQChuyoufa.Text = mat.Chuyoufa;
                    txt_BQShuyoubeng.Text = mat.BQShuyoubeng;
                    txt_BQShuyoubengzhijia.Text = mat.BQShuyoubengzhijia;
                    txt_BQZhuanghougaiban.Text = mat.BQZhuanghougaiban;
                    txt_BQTingchelaxianzhijia.Text = mat.BQTingchelaxianzhijia;
                    txt_BQShigaoyajinzuohumao.Text = mat.BQShigaoyajinzuohumao;
                    txt_BQZhuangfujian.Text = mat.Zhuangfujian;
                    txt_BQRemark.Text = mat.Remark;

                    //图片
                    //image = mat.Photo;
                    try
                    {
                        MemoryStream mStream = new MemoryStream();
                        mStream.Write(mat.Photo, 0, mat.Photo.Length);
                        mStream.Flush();
                        Bitmap img = new Bitmap(mStream);
                        pb_BQPic.Image = img;
                    }
                    catch 
                    {
                        pb_BQPic = null;
                    }

                    #endregion

                    #region 转速

                    txt_BQZhuansu1.Text = mat.Zhuangsu1;
                    txt_BQZhuansu2.Text = mat.Zhuangsu2;
                    txt_BQZhuansu3.Text = mat.Zhuangsu3;
                    txt_BQZhuansu4.Text = mat.Zhuangsu4;
                    txt_BQZhuansu5.Text = mat.Zhuangsu5;
                    txt_BQZhuansu6.Text = mat.Zhuangsu6;
                    txt_BQZhuansu7.Text = mat.Zhuangsu7;
                    txt_BQZhuansu8.Text = mat.Zhuangsu8;
                    txt_BQZhuansu9.Text = mat.Zhuangsu9;
                    txt_BQZhuansu10.Text = mat.Zhuangsu10;
                    //20150125新增
                    txt_BQJiaozhengjiesuzhuansu.Text = mat.BQJiaozhengzhuangsu;

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

                    txt_BQQiya1.Text = mat.Qiya1;
                    txt_BQQiya2.Text = mat.Qiya2;
                    txt_BQQiya3.Text = mat.Qiya3;
                    txt_BQQiya4.Text = mat.Qiya4;
                    txt_BQQiya5.Text = mat.Qiya5;
                    txt_BQQiya6.Text = mat.Qiya6;
                    txt_BQQiya7.Text = mat.Qiya7;

                    #endregion

                    #region 均匀度

                    txt_BQJunyundu1.Text = mat.Junyundu1;
                    txt_BQJunyundu2.Text = mat.Junyundu2;
                    txt_BQJunyundu3.Text = mat.Junyundu3;
                    txt_BQJunyundu4.Text = mat.Junyundu4;
                    txt_BQJunyundu5.Text = mat.Junyundu5;
                    txt_BQJunyundu6.Text = mat.Junyundu6;
                    txt_BQJunyundu7.Text = mat.Junyundu7;

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
                else
                {
                    lab_CurrentStatus.Text = DateTime.Now.ToString() + "可能由于数据录入有误，无法加载该参数信息。请联系管理员解决。";
                }
            }
        }

        /// <summary>
        /// 文本显示和dgv数据清空
        /// </summary>
        public void Clear()
        {
            //文本清空
            foreach (Control item in tlp_Main.Controls)
            {
                if (item.Name.Contains("txt_"))
                {
                    TextBox t = (TextBox)item;
                    t.Text = "";
                }
            }
            foreach (Control item in tlp_VE.Controls)
            {
                if (item.Name.Contains("txt_"))
                {
                    TextBox t = (TextBox)item;
                    t.Text = "";
                }
            }
            //dgv清空
            dgv_WorkDtl.DataSource = null;
            dgv_WorkMain.DataSource = null;
        }

        /// <summary>
        /// 将显示的文本框只读
        /// </summary>
        public void TextReadOnly()
        {
            foreach (Control item in tlp_Main.Controls)
            {
                if (item.Name.Contains("txt_"))
                {
                    TextBox t = (TextBox)item;
                    t.ReadOnly = true;
                }
            }
            foreach (Control item in tlp_VE.Controls)
            {
                if (item.Name.Contains("txt_"))
                {
                    TextBox t = (TextBox)item;
                    t.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 数据加载 flag表示是否要加载出了异常的泵,true表示加载异常泵，false表示不加载
        /// （初次加载不需要加载出异常的泵，录入故障信息后需要加载出异常的泵，方便清除异常）
        /// </summary>
        public void DataInit(bool flag)
        {
            p_probar.Visible = true;
            Application.DoEvents();
            workMain = null;
            workDtl = null;
            exceptions = null;
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                #region 任务加载

                try
                {
                    string temp = IntToStringfor4Length(txt_PalletCode.Text);
                    //根据托盘条码找任务
                    workMain = db.TB_WorkMain.First(p => p.PalletCode == temp && p.Finished == "0");
                    //将这个子任务加载完全
                    workMain.TB_WorkDtl.Load();
                    workMain.TB_UserReference.Load();
                    //找到子任务
                    workDtl = workMain.TB_WorkDtl.Where(p => p.IsException == false || (p.IsException == true && p.TB_User.ID == user.ID)).ToList();

                    //刷新异常信息表(加载整个)
                    exceptions = db.TB_Exception.ToList();
                    //将任务数据显示到grid控件中
                    List<TB_WorkMain> wm = new List<TB_WorkMain>();
                    wm.Add(workMain);
                    dgv_WorkMain.DataSource = wm;
                    dgv_WorkDtl.DataSource = workDtl;
                }
                catch (Exception)
                {
                    workMain = null;
                    LogExecute.WriteLineDataLog("未找到" + txt_PalletCode.Text + "对应的任务！");
                    MessageBox.Show("未找到该托盘编码对应的任务数据！请核对！");
                    p_probar.Visible = false;
                    db.Dispose();
                    return;
                }

                #endregion

                #region 加载型号参数显示
                try
                {
                    string matcode = workDtl[0].MaterialCode.Substring(0, 12);
                    TB_MaterialInfo mat = db.TB_MaterialInfo.Single(p => p.TypeCode == matcode);
                    TextInit(mat);
                }
                catch (Exception ex)
                {
                    lab_CurrentStatus.Text = DateTime.Now.ToString() + "当前主任务没有子任务存在！";
                    LogExecute.WriteLineDataLog("当前主任务" + workMain.WorkID + "没有子任务存在,加载参数数据失败！" + ex.ToString());
                }

                #endregion
            }

            p_probar.Visible = false;
        }

        /// <summary>
        /// 工位对象初始化
        /// </summary>
        public void DataInit()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    secondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationId);
                    secondWorkStationInfo.TB_PLCAdressWithWorkStationInfoReference.Load();
                    secondWorkStationInfo.TB_WorkStationInfoReference.Load();
                    secondWorkStationInfo.TB_WorkTimeBandingInfo.Load();
                    visual_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == visual_SecondWorkStationId);
                    visual_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfoReference.Load();
                    visual_SecondWorkStationInfo.TB_WorkStationInfoReference.Load();
                }
                catch (Exception ex)
                {
                    LogExecute.WriteExceptionLog("工位对象初始化", ex);
                }
            }
        }

        /// <summary>
        /// 将电气int型托盘编码转成4个长度的string类型
        /// </summary>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public string IntToStringfor4Length(string palletCode)
        {
            string palletCode2 = palletCode.ToString();
            for (int i = 0; i < 4; i++)
            {
                if (palletCode2.Length < 4)
                {
                    palletCode2 = palletCode2.Insert(0, "0");
                }
                else
                {
                    break;
                }
            }
            return palletCode2;
        }

        #endregion

        #region 翻页
        /// <summary>
        /// 0下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        /// <summary>
        /// 1上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChangePape0_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        /// <summary>
        /// 1下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChangePape2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        /// <summary>
        /// 2上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Shangyiye_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }
        #endregion

        #region 不合格录入
        private void btn_AddQCExceptionInfo_Click(object sender, EventArgs e)
        {
            frm_ExceptionSelectHelper exchelper = new frm_ExceptionSelectHelper(1);
            exchelper.Tag = this;
            exchelper.ShowDialog();
        }
        #endregion

      

    }
}
