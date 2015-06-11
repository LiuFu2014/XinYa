using System;
using System.Windows.Forms;
using XinYa.UI.BaseInfo;
using XinYa.UI.InfoSearch;
using XinYa.UI.Other;
using XinYa.UI.Sys;
using XinYa.UI.User;
using XinYa.UI.WorkManagement;
using XinYa.UI.WorkStation;
using XinYa.UI.Helper;
using XinYa.BLL;
using System.Xml;
using XinYa.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.UI
{
    public partial class frm_Main : Form
    {

        #region 字窗体定义

        /// <summary>
        /// 错误码
        /// </summary>
        private frm_ExceptionInfo exc;

        /// <summary>
        /// 物料录入
        /// </summary>
        private frm_MaterialInfoVEDtl matAdd;

        /// <summary>
        /// 物料信息
        /// </summary>
        private frm_MaterialInfo matInfo;

        /// <summary>
        /// 托盘信息
        /// </summary>
        private frm_PalletInfo pal;

        /// <summary>
        /// 工位工作量统计
        /// </summary>
        private frm_CompleteStatistics serInfoWS;

        ///// <summary>
        ///// 关于
        ///// </summary>
        //private frm_About about;

        /// <summary>
        /// 计算器
        /// </summary>
        private frm_Calculator cal;

        /// <summary>
        /// 权限信息（CRUD）
        /// </summary>
        private frm_AuthorityInfo auth;

        /// <summary>
        /// 设置员工登录权限
        /// </summary>
        private frm_SetAuthority setAuth;

        /// <summary>
        /// 员工信息
        /// </summary>
        private frm_WorkerInfo worker;

        /// <summary>
        /// 工艺路线
        /// </summary>
        private frm_ProcessRoute route;

        /// <summary>
        /// 质量追踪
        /// </summary>
        private frm_QCTrack QCTrack;

        /// <summary>
        /// 工序中心
        /// </summary>
        private frm_WorkFlowCenter workFlowCenter;

        /// <summary>
        /// 任务管理
        /// </summary>
        private frm_WorkTast workTask;

        /// <summary>
        /// 工位信息
        /// </summary>
        private frm_WorkStationView wss;

        /// <summary>
        /// 完成统计
        /// </summary>
        private frm_CompleteStatistics completeStatistics;

        /// <summary>
        /// 异常统计
        /// </summary>
        private frm_ExceptionStatistics ExceptionStatistics;

        /// <summary>
        /// 历史任务单
        /// </summary>
        private frm_HistoryWorkTaskSer hisWork;

        /// <summary>
        /// 系统日志
        /// </summary>
        private frm_SystemLog syslog;

        /// <summary>
        /// 工位禁用与启用
        /// </summary>
        private frm_WorkStationInfo wsInfo;

        /// <summary>
        /// 工时设定
        /// </summary>
        private frm_WorkTimeInfo wtInfo;

        /// <summary>
        /// 工时统计
        /// </summary>
        private frm_WorkTimeStatistics wtStatistics;

        /// <summary>
        /// 月度计划设定（LED）
        /// </summary>
        //private frm_MonthPlayForLed monthPlayForLED;

        /// <summary>
        /// 工时设定
        /// </summary>
        private frm_WorkTimeInfo workTimeInfo;

        /// <summary>
        /// 生产计划
        /// </summary>
        private frm_ProductionPlan productionPlan;

        /// <summary>
        /// ERP导入生产计划
        /// </summary>
        private frm_ProductionPlanFomERP productionPlanFromERP;

        /// <summary>
        /// ERP导入计划查询
        /// </summary>
        private frm_ProductionPlanFomERPSer productionPlanERPSer;

        /// <summary>
        /// 关于
        /// </summary>
        private frm_About about;

        /// <summary>
        /// 合格率统计
        /// </summary>
        private frm_QualifiedRateStatistics qualifiedRateStatistics;

        /// <summary>
        /// 员工工作记录
        /// </summary>
        private frm_HistoryWorkRecordSer historyWorkRecordSer;

        /// <summary>
        /// 关键零部件信息管理
        /// </summary>
        private frm_KeyComponentsInfo keyComponentsInfo;

        /// <summary>
        /// 关键零部件信息绑定
        /// </summary>
        private frm_KeyComponentsBanding keyComponentsBanding;

        /// <summary>
        /// 关键零部件绑定信息查询
        /// </summary>
        private frm_KeyComponentsSer keyComponentsSer;

        /// <summary>
        /// 辅助工时
        /// </summary>
        private frm_WorkTimeBandingInfo workTimeBandingInfo;

        /// <summary>
        /// 生产计划修改（ERP）
        /// </summary>
        private frm_ProductionPlanFromERPForCRUD productionPlanFromERPForCRUD;

        /// <summary>
        /// ERP员工信息修改
        /// </summary>
        private frm_ERPUserInfo ERPUserInfo;

        /// <summary>
        /// 员工登录记录
        /// </summary>
        private frm_LoginInOutRecord loginInOutRecord;

        /// <summary>
        /// LED报文发送窗体
        /// </summary>
        private frm_LEDTestSender LEDTestSender;

        /// <summary>
        /// 返修区工作统计
        /// </summary>
        private frm_SQSer SQSer;

        /// <summary>
        /// 工序信息
        /// </summary>
        private frm_WorkFlowInfo workFolwInfo;

        /// <summary>
        /// 物料审核
        /// </summary>
        private frm_MaterialAudit materialAudit;

        #endregion 字窗体定义

        #region 字段属性

        private DAL.TB_User user;

        /// <summary>
        /// 用户实体类
        /// </summary>
        public DAL.TB_User User
        {
            get
            {
                return user;
            }
            set
            {
                if (user == value)
                    return;
                user = value;
            }
        }

        /// <summary>
        /// 服务端代理
        /// </summary>
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();

        #endregion 字段属性

        //        #region 配色
        //this.p_Main.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
        //工具栏，菜单默认
        //this.mnuMain.BackColor = Color.FromArgb(0xBD, 0xBA, 0xBA);
        //this.statusStrip1.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
        //#endregion

        #region 窗体事件

        public frm_Main(DAL.TB_User user)
        {
            // TODO: Complete member initialization
            User = user;
            InitializeComponent();
            //权限控制
            UserRightControl();
        }

        /// <summary>
        /// 在load事件中更改背景颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    MdiClient ctlMDI;
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.Margin = new Padding(0);

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
            statusStrip1.Items[0].Text = "操作员：" + User.UserName;
            statusStrip1.Items[1].Text = "日期：" + System.DateTime.Now.ToShortDateString();//ToLongDateString();
            statusStrip1.Items[2].Text = "登录时间：" + System.DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 关闭之前先关系子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭子窗体
            foreach (var item in MdiChildren)
            {
                item.Close();
            }

            //#region 记录登出信息

            //int flag = serviceClient.LoginHelpForLoginOut(user.ID, 0, "鑫亚信息化主程序");
            //switch (flag)
            //{
            //    case 1:
            //    case 4:
            //    case 5:
            //        SystemLogHelper.WriteSysLogHelper("登出记录失败", user.ID, "鑫亚信息化主程序");
            //        break;
            //    default:
            //        break;
            //}

            //#endregion

            //Application.Exit();
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region 记录登出信息

            try
            {
                int flag = serviceClient.LoginHelpForLoginOut(user.ID, 0, "鑫亚信息化主控程序");
                switch (flag)
                {
                    case 1:
                    case 4:
                    case 5:
                        SystemLogHelper.WriteSysLogHelper("登出记录失败", user.ID, "鑫亚信息化主控程序");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SystemLogHelper.WriteSysLogHelper("退出记录失败,详情" + ex.ToString(), user.ID, "鑫亚信息化主控程序");
            }

            #endregion
            Application.Exit();
        }

        /// <summary>
        /// 更新系统时间
        /// </summary>
        public void UpdateSystemTime()
        {
            try
            {
                UpdateTime.SetSysTime(serviceClient.GetTimeNow());
            }
            catch (Exception ex)
            {
                SystemLogHelper.WriteSysLogHelper("更新本机时间", ex.ToString());
            }
        }

        #endregion 窗体事件

        #region 权限控制

        /// <summary>
        /// 用户权限控制（显示相关）
        /// </summary>
        public void UserRightControl()
        {
            if (user != null)
            {
                string a = "menu1000menu1001menu1002menu102menu100menu103";
                string b = "menu1000menu1001menu1002";
                if (user.UserLevel == "ERP")
                {
                    foreach (ToolStripMenuItem item in menuMain.Items)
                    {
                        if (!a.Contains(item.Name))
                        {
                            item.Visible = false;
                        }
                    }
                }
                else
                {
                    foreach (ToolStripMenuItem item in menuMain.Items)
                    {
                        if (item.Name == "menu1000" || item.Name == "menu1001" || item.Name == "menu1002")
                        {
                            item.Visible = false;
                        }
                    }
                }
            }
        }

        #endregion

        //private void OpenFile(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        //    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = openFileDialog.FileName;
        //    }
        //}

        //private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        //    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = saveFileDialog.FileName;
        //    }
        //}

        //private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    foreach (Form childForm in MdiChildren)
        //    {
        //        childForm.Close();
        //    }
        //}

        #region 窗口

        private void menu901_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menu902_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menu903_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        #endregion 窗口

        #region 工位管理

        /// <summary>
        /// 工位信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu401_Click(object sender, EventArgs e)
        {
            if (wss == null || wss.IsDisposed)
            {
                wss = new frm_WorkStationView();
                wss.MdiParent = this;
            }
            wss.Show();
            if (wss.WindowState == FormWindowState.Minimized)
                wss.WindowState = FormWindowState.Normal;
            wss.Activate();
        }

        /// <summary>
        /// 工位禁用与启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu402_Click(object sender, EventArgs e)
        {
            if (wsInfo == null || wsInfo.IsDisposed)
            {
                wsInfo = new frm_WorkStationInfo();
                wsInfo.MdiParent = this;
            }
            wsInfo.Show();
            if (wsInfo.WindowState == FormWindowState.Minimized)
                wsInfo.WindowState = FormWindowState.Normal;
            wsInfo.Activate();
        }

        #endregion 工位管理

        #region Sys

        private void menu101_Click(object sender, EventArgs e)
        {
            if (syslog == null || syslog.IsDisposed)
            {
                syslog = new frm_SystemLog();
                syslog.MdiParent = this;
            }
            syslog.Show();
            if (syslog.WindowState == FormWindowState.Minimized)
                syslog.WindowState = FormWindowState.Normal;
            syslog.Activate();

            #region MyRegion

            /*
            //关联地址与工位
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                var a = from b in db.TB_PLCBaseAdressInfo
                        select b;
                var c = from d in db.TB_PLCAdressWithStopper
                        select d;
                //foreach (var item in c)
                //{
                //    item.TB_PLCAdressWithWorkStationInfoReference.Load();
                //}
                foreach (var item in a)
                {
                    foreach (var item2 in c)
                    {
                        //if (item2.AdressID!=null)
                        //{
                        //    //string[] str = { item2.TB_PLCAdressWithWorkStationInfo.PalletCode,item2.TB_PLCAdressWithWorkStationInfo.ToPositCode,
                        //    //           item2.TB_PLCAdressWithWorkStationInfo.PositCodeLock,item2.TB_PLCAdressWithWorkStationInfo.PalletCode2,
                        //    //           item2.TB_PLCAdressWithWorkStationInfo.ToPositCode2,item2.TB_PLCAdressWithWorkStationInfo.RequirePallet,
                        //    //           item2.TB_PLCAdressWithWorkStationInfo.ReleasePallet,item2.TB_PLCAdressWithWorkStationInfo.ConfirmPalletArrived};
                        //    foreach (var item3 in str)
                        //    {
                        //        if (item.Adress.ToString() == item3)
                        //        {
                        //            item.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == item2.ID);
                        //        }
                        //    }
                        //}
                        string[] str = { item2.PalletCode, item2.ToPositCode };
                        foreach (var item3 in str)
                        {
                            if (item.Adress.ToString() == item3)
                            {
                                item.TB_PLCAdressWithStopper = db.TB_PLCAdressWithStopper.First(p => p.ID == item2.ID);
                            }
                        }
                    }
                }
                db.SaveChanges();
            }
             * **/

            #endregion MyRegion
        }

        #endregion Sys

        #region User

        /// <summary>
        /// 员工信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu301_Click(object sender, EventArgs e)
        {
            if (worker == null || worker.IsDisposed)
            {
                worker = new frm_WorkerInfo(user);
                worker.MdiParent = this;
            }
            worker.Show();
            if (worker.WindowState == FormWindowState.Minimized)
                worker.WindowState = FormWindowState.Normal;
            worker.Activate();
        }

        /// <summary>
        /// 员工权限编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu303_Click(object sender, EventArgs e)
        {
            if (auth == null || auth.IsDisposed)
            {
                auth = new frm_AuthorityInfo(user);
                auth.MdiParent = this;
            }
            auth.Show();
            if (auth.WindowState == FormWindowState.Minimized)
                auth.WindowState = FormWindowState.Normal;
            auth.Activate();
        }

        /// <summary>
        /// 员工权限设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu304_Click(object sender, EventArgs e)
        {
            if (setAuth == null || setAuth.IsDisposed)
            {
                setAuth = new frm_SetAuthority();
                setAuth.MdiParent = this;
            }
            setAuth.Show();
            if (setAuth.WindowState == FormWindowState.Minimized)
                setAuth.WindowState = FormWindowState.Normal;
            setAuth.Activate();
        }

        /// <summary>
        /// 员工更登录日志查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu302_Click(object sender, EventArgs e)
        {
            if (loginInOutRecord == null || loginInOutRecord.IsDisposed)
            {
                loginInOutRecord = new frm_LoginInOutRecord(user);
                loginInOutRecord.MdiParent = this;
            }
            loginInOutRecord.Show();
            if (loginInOutRecord.WindowState == FormWindowState.Minimized)
                loginInOutRecord.WindowState = FormWindowState.Normal;
            loginInOutRecord.Activate();
        }

        #endregion User

        #region 系统

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu102_Click(object sender, EventArgs e)
        {
            new frm_Login().Show();
            this.Hide();
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu103_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要结束系统吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //关闭子窗体
            foreach (var item in MdiChildren)
            {
                item.Close();
            }

            #region 记录登出信息

            //int flag = serviceClient.LoginHelpForLoginOut(user.ID, 0, "鑫亚信息化主程序");
            //switch (flag)
            //{
            //    case 1:
            //    case 4:
            //    case 5:
            //        SystemLogHelper.WriteSysLogHelper("登出记录失败", user.ID, "鑫亚信息化主程序");
            //        break;
            //    default:
            //        break;
            //}

            #endregion

            this.Close();
            //Application.Exit();
        }

        #endregion 系统

        #region Other

        /// <summary>
        /// 计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu701_Click(object sender, EventArgs e)
        {
            if (cal == null || cal.IsDisposed)
            {
                cal = new frm_Calculator();
                cal.MdiParent = this;
            }
            cal.Show();
            if (cal.WindowState == FormWindowState.Minimized)
                cal.WindowState = FormWindowState.Normal;
            cal.Activate();
        }

        /// <summary>
        /// 记事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu702_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        /// <summary>
        /// 日历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu703_Click(object sender, EventArgs e)
        {
            if (System.DateTime.Today.Year > 2100)
            {
                MessageBox.Show("Sorry！本万年历的最高使用年限为2100年！");
                return;
            }
            Help.ShowHelp(this, @".\WNL.exe");
        }

        #endregion Other

        #region BaseInfo

        /// <summary>
        /// 错误码录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu205_Click(object sender, EventArgs e)
        {
            if (exc == null || exc.IsDisposed)
            {
                exc = new frm_ExceptionInfo(user);
                exc.MdiParent = this;
            }
            exc.Show();
            if (exc.WindowState == FormWindowState.Minimized)
                exc.WindowState = FormWindowState.Normal;
            exc.Activate();
        }

        /// <summary>
        /// 物料类别录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu201_Click(object sender, EventArgs e)
        {
            //if (matAdd == null || matAdd.IsDisposed)
            //{
            //    matAdd = new frm_MaterialInfoDtl(user);
            //    matAdd.MdiParent = this;
            //}
            //matAdd.Show();
            //if (matAdd.WindowState == FormWindowState.Minimized)
            //    matAdd.WindowState = FormWindowState.Normal;
            //matAdd.Activate();
        }

        /// <summary>
        /// 物料信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu202_Click(object sender, EventArgs e)
        {
            if (matInfo == null || matInfo.IsDisposed)
            {
                matInfo = new frm_MaterialInfo(user);
                matInfo.MdiParent = this;
            }
            matInfo.Show();
            if (matInfo.WindowState == FormWindowState.Minimized)
                matInfo.WindowState = FormWindowState.Normal;
            matInfo.Activate();
        }

        /// <summary>
        /// 物料审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu207_Click(object sender, EventArgs e)
        {
            if (materialAudit == null || materialAudit.IsDisposed)
            {
                materialAudit = new frm_MaterialAudit(user);
                materialAudit.MdiParent = this;
            }
            materialAudit.Show();
            if (materialAudit.WindowState == FormWindowState.Minimized)
                materialAudit.WindowState = FormWindowState.Normal;
            materialAudit.Activate();
        }

        /// <summary>
        /// 托盘信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu203_Click(object sender, EventArgs e)
        {
            if (pal == null || pal.IsDisposed)
            {
                pal = new frm_PalletInfo(user);
                pal.MdiParent = this;
            }
            pal.Show();
            if (pal.WindowState == FormWindowState.Minimized)
                pal.WindowState = FormWindowState.Normal;
            pal.Activate();
        }

        /// <summary>
        /// 工时设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu204_Click(object sender, EventArgs e)
        {
            if (workTimeInfo == null || workTimeInfo.IsDisposed)
            {
                workTimeInfo = new frm_WorkTimeInfo(user);
                workTimeInfo.MdiParent = this;
            }
            workTimeInfo.Show();
            if (workTimeInfo.WindowState == FormWindowState.Minimized)
                workTimeInfo.WindowState = FormWindowState.Normal;
            workTimeInfo.Activate();
        }

        /// <summary>
        /// 关键零部件信息管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu206_Click(object sender, EventArgs e)
        {
            if (keyComponentsInfo == null || keyComponentsInfo.IsDisposed)
            {
                keyComponentsInfo = new frm_KeyComponentsInfo(user);
                keyComponentsInfo.MdiParent = this;
            }
            keyComponentsInfo.Show();
            if (keyComponentsInfo.WindowState == FormWindowState.Minimized)
                keyComponentsInfo.WindowState = FormWindowState.Normal;
            keyComponentsInfo.Activate();
        }

        #endregion BaseInfo

        #region 工作管理

        /// <summary>
        /// 工序中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu501_Click(object sender, EventArgs e)
        {
            if (workFlowCenter == null || workFlowCenter.IsDisposed)
            {
                workFlowCenter = new frm_WorkFlowCenter();
                workFlowCenter.MdiParent = this;
            }
            workFlowCenter.Show();
            if (workFlowCenter.WindowState == FormWindowState.Minimized)
                workFlowCenter.WindowState = FormWindowState.Normal;
            workFlowCenter.Activate();
        }

        /// <summary>
        /// 工序信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_507_Click(object sender, EventArgs e)
        {
            if (workFolwInfo == null || workFolwInfo.IsDisposed)
            {
                workFolwInfo = new frm_WorkFlowInfo(user);
                workFolwInfo.MdiParent = this;
            }
            workFolwInfo.Show();
            if (workFolwInfo.WindowState == FormWindowState.Minimized)
                workFolwInfo.WindowState = FormWindowState.Normal;
            workFolwInfo.Activate();
        }

        /// <summary>
        /// 工艺路线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu502_Click(object sender, EventArgs e)
        {
            if (route == null || route.IsDisposed)
            {
                route = new frm_ProcessRoute(User);
                route.MdiParent = this;
            }
            route.Show();
            if (route.WindowState == FormWindowState.Minimized)
                route.WindowState = FormWindowState.Normal;
            route.Activate();
        }

        /// <summary>
        /// 任务管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu503_Click(object sender, EventArgs e)
        {
            if (workTask == null || workTask.IsDisposed)
            {
                workTask = new frm_WorkTast(user);
                workTask.MdiParent = this;
            }
            workTask.Show();
            if (workTask.WindowState == FormWindowState.Minimized)
                workTask.WindowState = FormWindowState.Normal;
            workTask.Activate();
        }

        /// <summary>
        /// 质量追踪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu504_Click(object sender, EventArgs e)
        {
            if (QCTrack == null || QCTrack.IsDisposed)
            {
                QCTrack = new frm_QCTrack(user);
                QCTrack.MdiParent = this;
            }
            QCTrack.Show();
            if (QCTrack.WindowState == FormWindowState.Minimized)
                QCTrack.WindowState = FormWindowState.Normal;
            QCTrack.Activate();
        }

        /// <summary>
        /// 月度计划设定(LED)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu506_Click(object sender, EventArgs e)
        {
            if (LEDTestSender == null || LEDTestSender.IsDisposed)
            {
                LEDTestSender = new frm_LEDTestSender(user);
                LEDTestSender.MdiParent = this;
            }
            LEDTestSender.Show();
            if (LEDTestSender.WindowState == FormWindowState.Minimized)
                LEDTestSender.WindowState = FormWindowState.Normal;
            LEDTestSender.Activate();
        }

        /// <summary>
        /// 生产计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu505_Click(object sender, EventArgs e)
        {
            if (productionPlan == null || productionPlan.IsDisposed)
            {
                productionPlan = new frm_ProductionPlan(user);
                productionPlan.MdiParent = this;
            }
            productionPlan.Show();
            if (productionPlan.WindowState == FormWindowState.Minimized)
                productionPlan.WindowState = FormWindowState.Normal;
            productionPlan.Activate();
        }

        /// <summary>
        /// 生产计划导入(ERP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu50701_Click(object sender, EventArgs e)
        {
            if (productionPlanFromERP == null || productionPlanFromERP.IsDisposed)
            {
                productionPlanFromERP = new frm_ProductionPlanFomERP(user);
                productionPlanFromERP.MdiParent = this;
            }
            productionPlanFromERP.Show();
            if (productionPlanFromERP.WindowState == FormWindowState.Minimized)
                productionPlanFromERP.WindowState = FormWindowState.Normal;
            productionPlanFromERP.Activate();
        }

        /// <summary>
        /// 生产计划查询（ERP）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu50702_Click(object sender, EventArgs e)
        {
            if (productionPlanERPSer == null || productionPlanERPSer.IsDisposed)
            {
                productionPlanERPSer = new frm_ProductionPlanFomERPSer(user);
                productionPlanERPSer.MdiParent = this;
            }
            productionPlanERPSer.Show();
            if (productionPlanERPSer.WindowState == FormWindowState.Minimized)
                productionPlanERPSer.WindowState = FormWindowState.Normal;
            productionPlanERPSer.Activate();
        }

        /// <summary>
        /// 生产计划导入(ERP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu50703_Click(object sender, EventArgs e)
        {
            if (user.UserLevel == "ERP")
            {
                if (productionPlanFromERPForCRUD == null || productionPlanFromERPForCRUD.IsDisposed)
                {
                    productionPlanFromERPForCRUD = new frm_ProductionPlanFromERPForCRUD(user);
                    productionPlanFromERPForCRUD.MdiParent = this;
                }
                productionPlanFromERPForCRUD.Show();
                if (productionPlanFromERPForCRUD.WindowState == FormWindowState.Minimized)
                    productionPlanFromERPForCRUD.WindowState = FormWindowState.Normal;
                productionPlanFromERPForCRUD.Activate();
            }
            else
            {
                MessageBox.Show("当前账户权限不足，请使用ERP专有账号登陆。");
            }
        }

        /// <summary>
        /// 关键零部件信息绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu50801_Click(object sender, EventArgs e)
        {
            if (keyComponentsBanding == null || keyComponentsBanding.IsDisposed)
            {
                keyComponentsBanding = new frm_KeyComponentsBanding(user);
                keyComponentsBanding.MdiParent = this;
            }
            keyComponentsBanding.Show();
            if (keyComponentsBanding.WindowState == FormWindowState.Minimized)
                keyComponentsBanding.WindowState = FormWindowState.Normal;
            keyComponentsBanding.Activate();
        }

        /// <summary>
        /// 关键零部件信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu50802_Click(object sender, EventArgs e)
        {
            if (keyComponentsSer == null || keyComponentsSer.IsDisposed)
            {
                keyComponentsSer = new frm_KeyComponentsSer(user);
                keyComponentsSer.MdiParent = this;
            }
            keyComponentsSer.Show();
            if (keyComponentsSer.WindowState == FormWindowState.Minimized)
                keyComponentsSer.WindowState = FormWindowState.Normal;
            keyComponentsSer.Activate();
        }

        /// <summary>
        /// 工时辅助上位程序（绑定与查询）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu509_Click(object sender, EventArgs e)
        {
            if (workTimeBandingInfo == null || workTimeBandingInfo.IsDisposed)
            {
                workTimeBandingInfo = new frm_WorkTimeBandingInfo(user);
                workTimeBandingInfo.MdiParent = this;
            }
            workTimeBandingInfo.Show();
            if (workTimeBandingInfo.WindowState == FormWindowState.Minimized)
                workTimeBandingInfo.WindowState = FormWindowState.Normal;
            workTimeBandingInfo.Activate();
        }

        #endregion 工作管理

        #region 信息化查询

        /// <summary>
        /// 员工工作记录查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu601_Click(object sender, EventArgs e)
        {
            if (historyWorkRecordSer == null || historyWorkRecordSer.IsDisposed)
            {
                historyWorkRecordSer = new frm_HistoryWorkRecordSer(user);
                historyWorkRecordSer.MdiParent = this;
            }
            historyWorkRecordSer.Show();
            if (historyWorkRecordSer.WindowState == FormWindowState.Minimized)
                historyWorkRecordSer.WindowState = FormWindowState.Normal;
            historyWorkRecordSer.Activate();
        }

        /// <summary>
        /// 历史任务单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu602_Click(object sender, EventArgs e)
        {
            if (hisWork == null || hisWork.IsDisposed)
            {
                hisWork = new frm_HistoryWorkTaskSer();
                hisWork.MdiParent = this;
            }
            hisWork.Show();
            if (hisWork.WindowState == FormWindowState.Minimized)
                hisWork.WindowState = FormWindowState.Normal;
            hisWork.Activate();
        }

        /// <summary>
        /// 完成统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu603_Click(object sender, EventArgs e)
        {
            if (completeStatistics == null || completeStatistics.IsDisposed)
            {
                completeStatistics = new frm_CompleteStatistics(user);
                completeStatistics.MdiParent = this;
            }
            completeStatistics.Show();
            if (completeStatistics.WindowState == FormWindowState.Minimized)
                completeStatistics.WindowState = FormWindowState.Normal;
            completeStatistics.Activate();
        }

        /// <summary>
        /// 异常统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu604_Click(object sender, EventArgs e)
        {
            if (ExceptionStatistics == null || ExceptionStatistics.IsDisposed)
            {
                ExceptionStatistics = new frm_ExceptionStatistics(user);
                ExceptionStatistics.MdiParent = this;
            }
            ExceptionStatistics.Show();
            if (ExceptionStatistics.WindowState == FormWindowState.Minimized)
                ExceptionStatistics.WindowState = FormWindowState.Normal;
            ExceptionStatistics.Activate();
        }

        /// <summary>
        /// 工时统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu605_Click(object sender, EventArgs e)
        {
            if (wtStatistics == null || wtStatistics.IsDisposed)
            {
                wtStatistics = new frm_WorkTimeStatistics(user);
                wtStatistics.MdiParent = this;
            }
            wtStatistics.Show();
            if (wtStatistics.WindowState == FormWindowState.Minimized)
                wtStatistics.WindowState = FormWindowState.Normal;
            wtStatistics.Activate();
        }

        /// <summary>
        /// 合格率统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu606_Click(object sender, EventArgs e)
        {
            if (qualifiedRateStatistics == null || qualifiedRateStatistics.IsDisposed)
            {
                qualifiedRateStatistics = new frm_QualifiedRateStatistics(user);
                qualifiedRateStatistics.MdiParent = this;
            }
            qualifiedRateStatistics.Show();
            if (qualifiedRateStatistics.WindowState == FormWindowState.Minimized)
                qualifiedRateStatistics.WindowState = FormWindowState.Normal;
            qualifiedRateStatistics.Activate();
        }

        /// <summary>
        /// 返修区工作记录统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_607_Click(object sender, EventArgs e)
        {
            if (SQSer == null || SQSer.IsDisposed)
            {
                SQSer = new frm_SQSer();
                SQSer.MdiParent = this;
            }
            SQSer.Show();
            if (SQSer.WindowState == FormWindowState.Minimized)
                SQSer.WindowState = FormWindowState.Normal;
            SQSer.Activate();
        }

        #endregion 信息化查询

        #region 帮助

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu802_Click(object sender, EventArgs e)
        {
            if (about == null || about.IsDisposed)
            {
                about = new frm_About();
                about.MdiParent = this;
            }
            about.Show();
            if (about.WindowState == FormWindowState.Minimized)
                about.WindowState = FormWindowState.Normal;
            about.Activate();
        }

        #endregion

        #region ERP

        /// <summary>
        /// ERP本账户修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu1002_Click(object sender, EventArgs e)
        {
            if (ERPUserInfo == null || ERPUserInfo.IsDisposed)
            {
                ERPUserInfo = new frm_ERPUserInfo(user);
                ERPUserInfo.MdiParent = this;
            }
            ERPUserInfo.Show();
            if (ERPUserInfo.WindowState == FormWindowState.Minimized)
                ERPUserInfo.WindowState = FormWindowState.Normal;
            ERPUserInfo.Activate();
        }

        /// <summary>
        /// 导入ERP计划的修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu1001_Click(object sender, EventArgs e)
        {
            if (productionPlanFromERPForCRUD == null || productionPlanFromERPForCRUD.IsDisposed)
            {
                productionPlanFromERPForCRUD = new frm_ProductionPlanFromERPForCRUD(user);
                productionPlanFromERPForCRUD.MdiParent = this;
            }
            productionPlanFromERPForCRUD.Show();
            if (productionPlanFromERPForCRUD.WindowState == FormWindowState.Minimized)
                productionPlanFromERPForCRUD.WindowState = FormWindowState.Normal;
            productionPlanFromERPForCRUD.Activate();
        }

        #endregion

        #region 测试
        private void menu801_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //XmlDocument xmldoc = new XmlDocument();

            //xmldoc.Load(Application.StartupPath + "\\Test\\test.xml");
            //XmlNodeList nodelist = xmldoc.SelectSingleNode("XinYa").ChildNodes;//获取set节点的所有子节点
            //foreach (XmlNode xn in nodelist)
            //{
            //    if (xn.Name.ToLower() == "id")
            //    {
            //        //XmlNodeList partCldnodelist = xn.ChildNodes;
            //        //foreach (XmlNode xnd in partCldnodelist)
            //        //{
            //        //    XmlElement xe = (XmlElement)xnd;
            //        //    string s = xe.GetAttribute("1");
            //        //    MessageBox.Show(s);
            //        //    //if (xe.GetAttribute("Name") == strname)
            //        //    //{
            //        //    //    value = xe.InnerText;
            //        //    //}
            //        //}
            //        XmlElement xe = (XmlElement)xn;
            //        MessageBox.Show(xe.InnerText);

            //        //MessageBox.Show(Properties.Settings.Default.test);
            //        //if (MessageBox.Show("", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        //{
            //        //    Properties.Settings.Default.test = "123";
            //        //}
            //    }
            //} 
            #endregion

            #region 测试数据录入
            //using (XinYaDBEntities db = new XinYaDBEntities())
            //{
            //    try
            //    {
            //        for (int i = 1; i <= 350; i++)
            //        {
            //            TB_WorkMain wm = new TB_WorkMain();
            //            wm.PalletCode = IntToStringfor4Length(i);
            //            wm.IsCommit = true;
            //            wm.TB_User = db.TB_User.Single(p => p.ID == 1);
            //            wm.CreateDate = DateTime.Now;
            //            wm.Finished = "0";
            //            wm.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == 2);
            //            db.TB_WorkMain.AddObject(wm);
            //            db.SaveChanges();
            //            int wm_ID = wm.WorkID;
            //            TB_WorkDtl wd = new TB_WorkDtl();
            //            wd.TB_WorkMain = db.TB_WorkMain.Single(p => p.WorkID == wm_ID);
            //            wd.MaterialCode = "137012104299" + "A" + "1501" + IntToStringXLength(6, i);
            //            //Random random = new Random();
            //            //int flag = random.Next(3);
            //            //switch (flag)
            //            //{
            //            //    case 0:
            //            //        wd.MaterialCode = "137012104299" + "A" + "1501" + IntToStringXLength(6, i);
            //            //        break;
            //            //    case 1:
            //            //        wd.MaterialCode = "137012104299" + "B" + "1501" + IntToStringXLength(6, i);
            //            //        break;
            //            //    case 2:
            //            //        wd.MaterialCode = "137012104299" + "C" + "1501" + IntToStringXLength(6, i);
            //            //        break;

            //            //}
            //            wd.MaterialID = "137012104299";
            //            wd.CreateDate = DateTime.Now;
            //            wd.IsException = false;
            //            db.TB_WorkDtl.AddObject(wd);
            //            db.SaveChanges();

            //        }
            //    }
            //    catch (Exception)
            //    { }
            //}
            #endregion

            #region 与电气地址更改

            //using (XinYaDBEntities db=new XinYaDBEntities())
            //{
            //    try
            //    {
            //        ////工位地址
            //        //var a = db.TB_PLCAdressWithWorkStationInfo.ToList();
            //        //foreach (var item in a)
            //        //{
            //        //    if (!string.IsNullOrEmpty(item.RequirePallet))
            //        //    {
            //        //        item.RequirePallet = item.RequirePallet.Replace('M', 'L');
            //        //    }
            //        //    if (!string.IsNullOrEmpty(item.ReleasePallet))
            //        //    {
            //        //        item.ReleasePallet = item.ReleasePallet.Replace('M', 'L');
            //        //    }
            //        //    if (!string.IsNullOrEmpty(item.ConfirmPalletArrived))
            //        //    {
            //        //        item.ConfirmPalletArrived = item.ConfirmPalletArrived.Replace('M', 'L');
            //        //    }
            //        //    db.SaveChanges();
            //        //}
            //        //PLC地址更新
            //        //var b = db.TB_PLCBaseAdressInfo.ToList();
            //        //foreach (var item in b)
            //        //{
            //        //    if (!string.IsNullOrEmpty(item.Adress))
            //        //    {
            //        //        item.Adress = item.Adress.Replace('M', 'L');
            //        //    }
            //        //    db.SaveChanges();
            //        //}
            //        //PLC地址新增
            //        //for (int i = 201; i < 258; i++)
            //        //{

            //        //    TB_PLCBaseAdressInfo c = new TB_PLCBaseAdressInfo();
            //        //    c.Adress = "D" + i.ToString();
            //        //    c.Data = 0;
            //        //    c.MDType = "D";
            //        //    c.Remark = "20150114新增阻挡器锁定";
            //        //    db.TB_PLCBaseAdressInfo.AddObject(c);
            //        //    db.SaveChanges();
            //        //}
            //        //MessageBox.Show("成功");


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("更新地址数据出现异常！"+ex.ToString());
            //    }
            //}

            #endregion

            #region 地址重新排序

            //using (XinYaDBEntities db = new XinYaDBEntities())
            //{
            //    try
            //    {

            //        //三个提升机进版请求
            //        var tishengji = db.TB_PLCAdressWithWorkStationInfo.Where(p => p.PositCode == 1 || p.PositCode == 2 || p.PositCode == 3).ToList();
            //        foreach (var item in tishengji)
            //        {
            //            //TB_PLCBaseAdressInfo temp1 = new TB_PLCBaseAdressInfo();
            //            //temp1.Adress = item.ScanPalletCode;
            //            //temp1.Data = 0;
            //            //db.TB_PLCBaseAdressInfo.AddObject(temp1);
            //            //TB_PLCBaseAdressInfo temp2 = new TB_PLCBaseAdressInfo();
            //            //temp2.Adress = item.PalletCode;
            //            //temp2.Data = 0;
            //            //db.TB_PLCBaseAdressInfo.AddObject(temp2);
            //            TB_PLCBaseAdressInfo temp3 = new TB_PLCBaseAdressInfo();
            //            temp3.Adress = item.ScanPalletCode;
            //            temp3.Data = 0;
            //            db.TB_PLCBaseAdressInfo.AddObject(temp3);
            //            db.SaveChanges();
            //        }
            //        //获取所有阻挡器和工位数据
            //        var workStation = db.TB_SecondWorkStationInfo.ToList();
            //        foreach (var item in workStation)
            //        {
            //            item.TB_PLCAdressWithWorkStationInfoReference.Load();
            //            if (item.TB_PLCAdressWithWorkStationInfo == null)
            //            {
            //                continue;
            //            }
            //            //锁定
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.PositCodeLock;
            //                temp.Data = 0;
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                db.SaveChanges();
            //            }
            //            //请求
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.RequirePallet))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.RequirePallet;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //放版
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.ReleasePallet))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.ReleasePallet;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //到板
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.ConfirmPalletArrived))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.ConfirmPalletArrived;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //第一托盘位
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.PalletCode))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.PalletCode;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //第一去向位
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.ToPositCode))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.ToPositCode;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //第二托盘位
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.PalletCode2))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.PalletCode2;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //            //第二去向位
            //            if (!string.IsNullOrEmpty(item.TB_PLCAdressWithWorkStationInfo.ToPositCode2))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.TB_PLCAdressWithWorkStationInfo.ToPositCode2;
            //                temp.Data = 0;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                temp.TB_SecondWorkStationInfo = item;
            //                db.SaveChanges();
            //            }
            //        }

            //        //阻挡器
            //        var zudangqi = db.TB_PLCAdressWithStopper.ToList();
            //        foreach (var item in zudangqi)
            //        {
            //            //锁定传递
            //            if (!string.IsNullOrEmpty(item.StopperLockForNextStopper))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.StopperLockForNextStopper;
            //                temp.Data = 0;
            //                temp.TB_PLCAdressWithStopper = item;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                db.SaveChanges();
            //            }
            //            //锁定进工位
            //            if (!string.IsNullOrEmpty(item.StopperLockForWorkStation))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.StopperLockForWorkStation;
            //                temp.Data = 0;
            //                temp.TB_PLCAdressWithStopper = item;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                db.SaveChanges();
            //            }
            //            //托盘编码
            //            if (!string.IsNullOrEmpty(item.PalletCode))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.PalletCode;
            //                temp.Data = 0;
            //                temp.TB_PLCAdressWithStopper = item;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                db.SaveChanges();
            //            }
            //            //去向地址
            //            if (!string.IsNullOrEmpty(item.ToPositCode))
            //            {
            //                TB_PLCBaseAdressInfo temp = new TB_PLCBaseAdressInfo();
            //                temp.Adress = item.ToPositCode;
            //                temp.Data = 0;
            //                temp.TB_PLCAdressWithStopper = item;
            //                db.TB_PLCBaseAdressInfo.AddObject(temp);
            //                db.SaveChanges();
            //            }

            //        }
            //        MessageBox.Show("保存成功");

            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("保存失败");
            //    }
            //}

            #endregion

            #region 清理地址

            //using (XinYaDBEntities db = new XinYaDBEntities())
            //{
            //    ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();
            //    //var a = db.TB_PLCBaseAdressInfo.Where(p=>p.TB_SecondWorkStationInfo.WorkStationCode=="E").ToList();
            //    //foreach (var item in a)
            //    //{
            //    //    ser.PLCReadAndWriteTest(item.Adress, 0, true);
            //    //}
            //    //var b = db.TB_SecondWorkStationInfo.ToList();
            //    //foreach (var item in b)
            //    //{
            //    //    if (item.TB_PLCAdressWithWorkStationInfo != null && item.TB_PLCAdressWithWorkStationInfo.PositCodeLock != null&&item.ID<120)
            //    //    {
            //    //        ser.PLCReadAndWriteTest(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock, 0, true);
            //    //    }
            //    //}

            //    MessageBox.Show("成功！");
            //}

            #endregion

            #region 磨合段故障排除

            //ServiceReference1.Service1Client ser = new ServiceReference1.Service1Client();
            //if (ser.PLCReadAndWriteTest("D301", 0, true) == 0)
            //{
            //    MessageBox.Show("磨合段故障排除成功！");
            //}
            //else
            //{
            //    MessageBox.Show("磨合段故障排除失败！");
            //}

            #endregion

        }

        /// <summary>
        /// 将电气int型托盘编码转成4个长度的string类型
        /// </summary>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public string IntToStringfor4Length(int palletCode)
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

        public string IntToStringXLength(int x, int y)
        {
            string palletCode2 = y.ToString();
            for (int i = 0; i < x; i++)
            {
                if (palletCode2.Length < x)
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

    }
}