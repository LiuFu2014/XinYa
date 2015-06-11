/*
							  _ooOoo_
							 o8888888o
							 88" . "88
							 (| -_- |)
							 O\  =  /O
						  ____/`---'\____
						.'  \\|     |//  `.
					   /  \\|||  :  |||//  \
					  /  _||||| -:- |||||-  \
					  |   | \\\  -  /// |   |
					  | \_|  ''\---/''  |   |
					  \  .-\__  `-`  ___/-. /
					___`. .'  /--.--\  `. . __
				 ."" '<  `.___\_<|>_/___.'  >'"".
				| | :  `- \`.;`\ _ /`;.`/ - ` : | |
				\  \ `-.   \_ __\ /__ _/   .-` /  /
		   ======`-.____`-.___\_____/___.-`____.-'======
							  `=---='
		   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
					  佛祖镇楼       BUG易除
			   佛曰:
				   写字楼里写字间，写字间里程序员；
				   程序人员写程序，又拿程序换酒钱。
				   酒醒只在网上坐，酒醉还来网下眠；
				   酒醉酒醒日复日，网上网下年复年。
				   但愿老死电脑间，不愿鞠躬老板前；
				   奔驰宝马贵者趣，公交自行程序员。
				   别人笑我忒疯癫，我笑自己命太贱；
				   不见满街漂亮妹，哪个归得程序员？
* */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACTETHERLib;
using XinYaProcessManageSystem.BLL;
using System.Threading;

namespace XinYaProcessManageSystem
{
	public partial class frm_Main : Form
	{
		#region PLCAdressAndOtherInfo

		//string PLCAdress;
		//专有通信模块(公开，供向外提供接口时被引用)
		public ACTETHERLib.ActQJ71E71TCP MasterPLC1 = new ActQJ71E71TCP();

		/// <summary>
		/// 基础地址
		/// </summary>
		private List<TB_PLCBaseAdressInfo> list_plcAdress;

		/// <summary>
		/// 详细工位信息(初始化加载到内存)
		/// </summary>
		private List<TB_SecondWorkStationInfo> list_secStation;

		/// <summary>
		/// 详细阻挡器信息（初始化加载到内存）
		/// </summary>
		private List<TB_PLCAdressWithStopper> list_stopper;

		/// <summary>
		/// 物料信号信息
		/// </summary>
		private List<TB_MaterialInfo> list_materialInfo;

		/// <summary>
		/// 操作员
		/// </summary>
		private TB_User user;

		/// <summary>
		/// 磨合装后盖地址分配变量
		/// </summary>
		private bool bool_moheZhuanghougai = true;

		/// <summary>
		/// 包装段地址分配控制变量
		/// </summary>
		private bool[] bool_baozhuang = { true, true, true, true, true, true, true, true, true, true };

		/// <summary>
		/// 包装段阻挡器信息
		/// </summary>
		private List<TB_PLCAdressWithStopper> list_Baozhuangduanstopper = new List<TB_PLCAdressWithStopper>();

		/// <summary>
		/// 调试段A处理工位
		/// </summary>
		List<TB_SecondWorkStationInfo> list_TiaoshiForA = new List<TB_SecondWorkStationInfo>();

		/// <summary>
		/// 调试段B处理工位
		/// </summary>
		List<TB_SecondWorkStationInfo> list_TiaoshiForB = new List<TB_SecondWorkStationInfo>();

		#endregion PLCAdressAndOtherInfo

		public frm_Main(TB_User user)
		{
			InitializeComponent();
			//开启服务
			WcfServiceOpen();

			//阻挡器初始信息加载
			StopperInit();
			//型号物料初始（这里主要考虑到新增型号无法定位去向地址问题）
			MaterialInfoInit();
			//这里主要是考虑到如果有工位被禁用要及时响应的问题
			SecondWorkStationInit();
			//主控时钟刷新频率
			timer_PLC.Interval = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Timer"]);
			this.断开PLCToolStripMenuItem.Enabled = false;
			this.tool_PLCClose.Enabled = false;
			this.p_Main.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
			this.status_Main.BackColor = Color.FromArgb(0x41, 0x41, 0x52);
			//PLC IP地址
			MasterPLC1.ActHostAddress = System.Configuration.ConfigurationSettings.AppSettings["PLCAdress"];
			this.user = user;
			lab_User.Text = "操作员：" + user.UserName;
			lab_LoginTime.Text = "登陆时间：" + DateTime.Now.ToLongTimeString();
		}

		#region 停靠与最小化、关闭

		//获取当前鼠标下可视化控件的句柄
		[DllImport("user32.dll")]
		public static extern int WindowFromPoint(int xPoint, int yPoint);

		//获取指定句柄的父级句柄
		[DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
		public static extern IntPtr GetParent(IntPtr hWnd);

		/// <summary>
		/// 获取当前鼠标下可视化控件的句柄
		/// </summary>
		/// <param x="int">当前鼠标的X坐标</param>
		/// <param y="int">当前鼠标的Y坐标</param>
		public IntPtr FormNameAt(int x, int y)
		{
			IntPtr Tem_hWnd;//设置存储句柄的变量
			IntPtr Tem_Handle = (IntPtr)(WindowFromPoint(x, y));//获取当前鼠标下可视化控件的句柄
			Tem_hWnd = Tem_Handle;//记录原始句柄
			while (Tem_hWnd != ((IntPtr)0))//遍历该句柄的父级句柄
			{
				Tem_Handle = Tem_hWnd;//记录当前句柄
				Tem_hWnd = GetParent(Tem_hWnd);//获取父级句柄
			}
			return Tem_Handle;//返回最底层的父级句柄
		}

		private void timer_Dock_Tick(object sender, EventArgs e)
		{
			//Application.DoEvents();
			if (this.Top < 3)
			{
				if (this.Handle == FormNameAt(Cursor.Position.X, Cursor.Position.Y))//当鼠标移致到该窗体上
				// if (Control.MousePosition.X >= Location.X-1 && Control.MousePosition.X<(Location.X+Width)&&Control.MousePosition.Y>Location.Y&&Control.MousePosition.Y<(Location.Y+Height))
				{
					this.Top = -1;//使窗体致顶
				}
				else
				{
					this.Top = -(this.Height - 2);
				}
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
		}

		private void frm_Main_Deactivate(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
			}
		}

		private void tool_Resume_Click(object sender, EventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
		}

		private void tool_Exit_Click(object sender, EventArgs e)
		{
			this.notifyIcon1.Visible = false;
			Application.Exit();
		}

		private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Application.Exit();
		}

		private void pingPLCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Application.Exit();
			this.Close();
		}

		/// <summary>
		/// 登出记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			//服务端登出记录
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				try
				{
					TB_LoginRecord loginRecord = new TB_LoginRecord();
					loginRecord.TB_User = db.TB_User.Single(p => p.ID == user.ID);
					loginRecord.ServicePosition = "鑫亚服务端PLC主控程序";
					loginRecord.LoginOutTime = DateTime.Now;
					db.TB_LoginRecord.AddObject(loginRecord);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					LogExecute.WriteInfoLog("服务端登出失败，详情" + ex.ToString(), false); ;
				}
			}
			Application.Exit();
		}

		#endregion 停靠与最小化、关闭

		#region PLC连接与断开事件

		/// <summary>
		/// 连接PLC
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 连接PLCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int a = MasterPLC1.Open();

			if (a == 0)
			{
				MessageBox.Show("连接成功！");
				this.断开PLCToolStripMenuItem.Enabled = true;
				this.tool_PLCClose.Enabled = true;
				this.连接PLCToolStripMenuItem.Enabled = false;
				this.tool_PLCConnect.Enabled = false;
				timer_PLC.Enabled = true;
				timer_PLC.Start();
			}
			else
			{
				txt_test.AppendText(DateTime.Now.ToShortTimeString() + "连接失败！返回值：" + a.ToString() + "\n");
				MessageBox.Show("连接失败！");
			}
		}

		/// <summary>
		/// 关闭PLC连接
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void 断开PLCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer_PLC.Stop();
			if (MasterPLC1.Close() == 0)
			{
				MessageBox.Show("关闭成功！");
				this.断开PLCToolStripMenuItem.Enabled = false;
				this.tool_PLCClose.Enabled = false;
				this.连接PLCToolStripMenuItem.Enabled = true;
				this.tool_PLCConnect.Enabled = true;
				timer_PLC.Enabled = false;
				timer_PLC.Stop();
			}
			else
			{
				MessageBox.Show("关闭失败！");
			}
		}

		/// <summary>
		/// ping PLC 地址
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pingPLCToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Ping p = new Ping();
			PingReply pr = p.Send(MasterPLC1.ActHostAddress);
			if (pr.Status == IPStatus.Success)
			{
				MessageBox.Show("Ping PLC 成功！");
			}
			else
			{
				MessageBox.Show("Ping PLC 失败！");
			}
		}

		/// <summary>
		/// 连接PLC
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tool_PLCConnect_Click(object sender, EventArgs e)
		{
			int a = MasterPLC1.Open();

			if (a == 0)
			{
				MessageBox.Show("连接成功！");
				this.断开PLCToolStripMenuItem.Enabled = true;
				this.tool_PLCClose.Enabled = true;
				this.连接PLCToolStripMenuItem.Enabled = false;
				this.tool_PLCConnect.Enabled = false;
				timer_PLC.Enabled = true;
				timer_PLC.Start();
			}
			else
			{
				txt_test.AppendText(DateTime.Now.ToShortTimeString() + "连接失败！返回值：" + a.ToString() + "\n");
				MessageBox.Show("连接失败！");
			}
		}

		/// <summary>
		/// 关闭PLC
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tool_PLCClose_Click(object sender, EventArgs e)
		{
			timer_PLC.Stop();
			if (MasterPLC1.Close() == 0)
			{
				MessageBox.Show("关闭成功！");
				this.断开PLCToolStripMenuItem.Enabled = false;
				this.tool_PLCClose.Enabled = false;
				this.连接PLCToolStripMenuItem.Enabled = true;
				this.tool_PLCConnect.Enabled = true;
				timer_PLC.Enabled = false;
				timer_PLC.Stop();
			}
			else
			{
				MessageBox.Show("关闭失败！");
			}
		}

		#endregion PLC连接与断开事件

		#region 调度

		/// <summary>
		/// 调度主控时钟（测试需要1.2S左右的时间运行完，后期应考虑优化）
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_PLC_Tick(object sender, EventArgs e)
		{
			//计时
			DateTime begin = DateTime.Now;

			#region PLC地址值及物料信息更新（后期数据录入了之后，如果时间过长则需要考虑优化问题）

			//固定扫码头进制转换与写入
			//PLCASCLLHelper();
			//地址初始
			PLCAdressInit();
			//PLC读取计时
			DateTime endplc = DateTime.Now;
			TimeSpan c = endplc - begin;
			label6.Text = c.ToString();
			//一下两个方法考虑到最新数据的问题，诺对执行效率影响过大，可考虑优化
			//型号物料初始（这里主要考虑到新增型号无法定位去向地址问题）
			MaterialInfoInit();
			//这里主要是考虑到如果有工位被禁用要及时响应的问题
			SecondWorkStationInit();

			//用于记录当前处理完进制转换后的托盘号，可用于记录任务的工艺路线记录
			string palletCode1;
			string palletCode2;
			string palletCode3;

			#endregion PLC地址值及物料信息更新（后期数据录入了之后，如果时间过长则需要考虑优化问题）

			#region 连接实体以及当前任务（暂未集中处理）

			//是否统一连接实体?
			//XinYaDBEntities dbbeifeng = new XinYaDBEntities();
			//是否统一当前任务？
			//现在没有出问题，暂时不统一，将来如果处理速度达不到要求或者其他什么问题，再进行更改。

			#endregion 连接实体以及当前任务（暂未集中处理）

			//如果没有取到地址值则直接return掉
			if (list_plcAdress == null || list_materialInfo == null || list_stopper == null || list_secStation == null || list_Baozhuangduanstopper == null)
			{
				txt_Exception.AppendText("\n" + DateTime.Now + "出现基于数据访问、或网络故障的异常！系统未进入主控逻辑处理段！系统将在3s后继续。如果问题依旧，请先断开PLC连接，再进行故障处理。");
				timer_PLC.Enabled = false;
				//等待3s，需测试
				Thread.Sleep(3000);
				timer_PLC.Enabled = true;
				return;
			}

			#region 磨合段

			#region 磨合区调度

			//磨合区因减去PC端所以不考虑缓冲功能
			//考虑到磨合是所有泵的必由之路，故这里不加载工艺路线，提高效率
			//1.检测磨合前扫描托盘的请求信号（请求进板阶段），写入去向地址
			//取值，1#请求进板信号
			int D300 = (int)list_plcAdress.First(p => p.Adress == "D300").Data;
			//获取磨合12个工位的基础信息
			List<TB_SecondWorkStationInfo> mohe12 = (from a in list_secStation
													 where a.SecondWorkStationCode == "SB"
													 select a).ToList();
			//如果等于1则表示请求进版，说明固定扫码头扫到了托盘条码；没有则不管
			if (D300 == 1)
			{
				//将固定扫码头扫描的ASCLL码写入D301
				PLCASCLLHelper(out palletCode1, out palletCode2, out palletCode3);

				int palletCode_1 = (int)list_plcAdress.First(P => P.Adress == "D301").Data;
				int toPosition_1 = (int)list_plcAdress.First(P => P.Adress == "D302").Data;
				if (palletCode_1 != 0 && toPosition_1 == 0)
				{
					//循环遍历12个磨合台的请求，需排除工作台锁定的工位
					foreach (var item in mohe12)
					{
						//有请求且没有被锁定
						int require = Convert.ToInt32((list_plcAdress.First(P => P.Adress == item.TB_PLCAdressWithWorkStationInfo.RequirePallet)).Data);
						int clock = Convert.ToInt32(list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PositCodeLock).Data);
						if (require == 1 && clock == 0)
						{
							//将该工位地址写入1#去向地址D302
							if (MasterPLC1.WriteDeviceRandom2("D302", 1, Convert.ToInt16(item.AdressCode)) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + "磨合段请求失败");
								LogExecute.WriteInfoLog("磨合段请求", false);
							}
							else
							{
								//将这个工位锁定（一旦该工位被分配了则锁定，其他解锁情况由电控控制）
								if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock, 1, 1) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + "磨合段请求失败");
									LogExecute.WriteInfoLog("磨合段锁定", false);
								}
								//工艺路线记录(这里是否要放入else中？)
								WorkRouteRecord(palletCode1, item.ID, null);

								//一次请求只分配一次，避免重复分配地址
								break;
							}
						}
					}
				}
			}

			//2.磨合工位上有条码存在的处理（非缓存，没有上位机，在电控条码数据存入相应地址后，随即写入去向地址）
			//通过条码查找与这个条码绑定的泵条码，
			//通过泵条码，查找型号信息，再查找工艺路线，加载去向地址
			//需要装后盖的赋予装后盖的地址，不需要的置0
			foreach (var item in mohe12)
			{
				//首先获取托盘条码
				int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
				int toPosition = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
				//判断这个条码是否存在,如果等于“0”则表示不存在,而且去向地址中没有写入地址,写入了则表示已经赋予了去向地址
				if (palletCode != 0 && toPosition == 0)
				{
					//获取当前任务
					using (XinYaDBEntities db = new XinYaDBEntities())
					{
						//筛选当前托盘所在任务
						//int转4位string
						string palletcode2 = IntToStringfor4Length(palletCode);
						try
						{
							var works = db.TB_WorkMain.First(p => p.PalletCode == palletcode2 && p.Finished == "0");

							#region 磨合包装到达跟新任务在此工位上的开始时间

							//当这里写入地址的时候，随机在任务工艺路线记录表中写入了下一个工位与此任务的绑定数据
							//所以这个时间在没有更新前既是当前工位任务开始时间也是后一个工位任务的开始时间
							//所以这里更新任务到达这个工位的时间作为这个任务在这个工位上的开始时间，而不是采用上一个工位的开始时间
							//开始时间的更新诺出异常，不应该影响到去向地址的赋值，所以try
							try
							{
								//取出这条记录
								TB_WorkDtlForEachStation a = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == works.WorkID && p.SecondWorkStationID == item.ID).OrderByDescending(p => p.ID).First();
								//更新时间
								a.WorkBeginTime = DateTime.Now;
								db.SaveChanges();
							}
							catch (Exception ex)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + "任务" + works.WorkID + " 托盘：" + works.PalletCode + "更新工位" + item.SecondWorkStationName + "到达时间失败！");
								LogExecute.WriteDBExceptionLog(ex);
							}

							#endregion 磨合包装到达跟新任务在此工位上的开始时间

							//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
							//可替代的写法
							//string modelCode = works.TB_WorkDtl.ToList()[0].MaterialCode.Substring(0, 12);
							string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
							//根据型号代码加载工艺路线
							TB_MaterialInfo matertialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
							//matrtialInfo.TB_ProcessRouteMReference.Load();
							//获取当前工艺路线
							//可替代写法
							//List<TB_ProcessRouteP> routePs = matertialInfo.TB_ProcessRouteM.TB_ProcessRouteP.ToList();

							List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
															  where a.ProcessRouteM == matertialInfo.TB_ProcessRouteM.ProcessRouteP
															  select a).ToList();
							//查找当前所在工序No
							int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
							//检查得到下一个工位No
							//no=from a in routeP
							//   where a.IsUse==true && a.No>no
							//   orderby a.No
							//查找下一个工艺
							TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
							//检查下一个工位是否为装后盖
							if (routeP.TB_WorkStationInfo.WorkStationCode == "C")
							{
								//先获取可用的工位信息
								List<TB_SecondWorkStationInfo> zhuanghougai = list_secStation.Where(p => p.WorkStationCode == "C").ToList();
								//两个工位都被禁用掉了，则跳过这个工序（不管路线如何）
								if (zhuanghougai.Count == 0)
								{
									//不去后盖的话写1(应电控要求)
									short k = 1;
									if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, k) != 0)
									{
										txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
										LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
									}
									//这里因为在2#处会重新扫描分配，所以记录任务工艺路线
								}
								else if (zhuanghougai.Count == 1)  //只禁用了一个(原本就只有2个，别想太多，想太多就玩不了了)
								{
									short k = Convert.ToInt16(zhuanghougai[0].AdressCode);
									if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, k) != 0)
									{
										txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
										LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
									}
									else
									{
										//写入成功后记录任务工艺路线
										WorkRouteRecord(palletcode2, zhuanghougai[0].ID, db);
									}
								}
								else  //两个都有的话就随机分配咯
								{
									#region 随机写法

									/*
									//随机分配地址
									Random ran = new Random();
									//12随即数
									int i = ran.Next(1, 3);
									if (i == 1)
									{
										//写入SC1地址
										short j = 6701;
										if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
											LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
										}
										else
										{
											//写入成功后记录任务工艺路线,这里ID手动写一下算了，怕出错...
											WorkRouteRecork(palletcode2, 17, db);
										}
									}
									else
									{
										//写入SC2地址
										short k = 6702;
										if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, k) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
											LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
										}
										else
										{
											//写入成功后记录任务工艺路线,这里手动写一下算了，怕出错...
											WorkRouteRecork(palletcode2, 18, db);
										}
									}
									 * */

									#endregion 随机写法

									#region 0/1写法(14.11.11需要测试)

									if (bool_moheZhuanghougai == true)
									{
										bool_moheZhuanghougai = false;
										//写入SC1地址
										short j = 6701;
										if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
											LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
										}
										else
										{
											//写入成功后记录任务工艺路线,这里ID手动写一下算了，怕出错...
											WorkRouteRecord(palletcode2, 17, db);
										}
									}
									else
									{
										bool_moheZhuanghougai = true;
										//写入SC2地址
										short k = 6702;
										if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, k) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
											LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
										}
										else
										{
											//写入成功后记录任务工艺路线,这里手动写一下算了，怕出错...
											WorkRouteRecord(palletcode2, 18, db);
										}
									}

									#endregion 0/1写法(14.11.11需要测试)
								}
							}
							else
							{
								//不去后盖的话写1(应电控要求)
								short k = 1;
								if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, k) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址写入失败！");
									LogExecute.WriteInfoLog("磨合段" + item.SecondWorkStationName + "去向地址", false);
								}
								//这里因为在2#处会重新扫描分配，所以记录任务工艺路线
							}
						}
						catch (Exception ex)
						{
							txt_Exception.AppendText("\n" + DateTime.Now + "磨合段去向地址处理异常");
							LogExecute.WriteDBExceptionLog(ex);
						}
					}
				}
				else if (palletCode == 0 && toPosition != 0)
				{
					//11.12测试，发现磨合段同样出现扫描周期问题，这里做一个修正
					//如果去向地址不为0而托盘号为0，说明有异常。
					//清掉去向地址数据
					if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, 0) != 0)
					{
						txt_Exception.AppendText(DateTime.Now + "清理" + item.SecondWorkStationName + "去向地址失败！");
						LogExecute.WriteInfoLog("0地址写入到" + item.SecondWorkStationName + "去向地址", false);
					}
					else
					{
						txt_Exception.AppendText(DateTime.Now + "清理" + item.SecondWorkStationName + "去向地址成功！");
					}
				}
			}

			#endregion 磨合区调度

			#region 装后盖板调度(2#处会重新扫描，是否没必要进行地址写入？)

			//2015.1.6,装后盖出来应该写1
			//如果两个工位都被禁用掉了则不做处理
			if (list_secStation.Count(p => p.SecondWorkStationCode == "SC") > 0)
			{
				//首先获取这两个工位
				List<TB_SecondWorkStationInfo> scs = list_secStation.Where(p => p.SecondWorkStationCode == "SC").ToList();
				//遍历
				foreach (var item in scs)
				{
					int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
					int toPosition = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
					if (palletCode != 0 && toPosition == 0)
					{
						MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, 1);
					}
				}
			}

			/***
			//这里为了支持信息化，上位机将信息写入任务明细表2，此处去向地址不通过上位机写入
			//这里如果不需要磨合和QC，则写入1，其他情况
			//首先获取这两个工位
			List<TB_SecondWorkStationInfo> scs = list_secStation.Where(p => p.SecondWorkStationCode == "SC").ToList();
			//遍历
			foreach (var item in scs)
			{
				//加载托盘条码
				//首先获取托盘条码
				int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
				//判断这个条码是否存在,如果等于“0”则表示不存在
				if (palletCode != 0)
				{
					//获取当前任务
					using (XinYaDBEntities db = new XinYaDBEntities())
					{
						//筛选当前托盘所在任务
						string palletCode2 = IntToStringfor4Length(palletCode);
						var works = db.TB_WorkMain.First(p =>p.PalletCode == palletCode2 && p.Finished == "0");
						//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
						string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
						//根据型号代码加载工艺路线
						TB_MaterialInfo matrtialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
						//matrtialInfo.TB_ProcessRouteMReference.Load();
						//获取当前工艺路线
						List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
														  where a.ProcessRouteM == matrtialInfo.TB_ProcessRouteM.ProcessRouteP
														  select a).ToList();
						//查找当前所在工序No
						int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
						//检查得到下一个工位No
						//no=from a in routeP
						//   where a.IsUse==true && a.No>no
						//   orderby a.No
						//查找下一个工艺
						TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
						//判定下一个工艺是否为试验台，如果不是，则将去向地址置1，即在试验台不参与队列排序
						if (routeP.TB_WorkStationInfo.WorkStationCode != "E")
						{
							short j = 1;
							MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j);
						}
					}
				}
			}
			 *
			 **/

			#endregion 装后盖板调度(2#处会重新扫描，是否没必要进行地址写入？)

			#region 磨合装后盖同样存在和包装段一样的空闲等待问题（时间问题，14.12.3已优化，需要测试）

			//未完成...
			//实现方法与包装段相同
			//当2个工位都启用的时候才进行这段优化处理
			//找到这个阻挡器,ID为14.
			var zhuanghougaiqianzhidang = list_stopper.Single(p => p.ID == 14);
			int palletCode_zhuanghougai = (int)list_plcAdress.First(p => p.Adress == zhuanghougaiqianzhidang.PalletCode).Data;
			int toPosition_zhuanghougai = (int)list_plcAdress.First(p => p.Adress == zhuanghougaiqianzhidang.ToPositCode).Data;
			//是否有值
			if (palletCode_zhuanghougai != 0 && toPosition_zhuanghougai != 0)
			{
				//两个工位是否都启用
				if (list_secStation.Count(p => p.WorkStationCode == "C") == 2)
				{
					var sec_zhuanggougai = list_secStation.Where(p => p.WorkStationCode == "C").ToList();
					//要去
					if (Convert.ToInt32(sec_zhuanggougai[0].AdressCode) == toPosition_zhuanghougai || Convert.ToInt32(sec_zhuanggougai[1].AdressCode) == toPosition_zhuanghougai)
					{
						//获取这两个工位上的托盘地址和去向地址
						//条码1
						int sec0_palletCode = (int)list_plcAdress.First(p => p.Adress == sec_zhuanggougai[0].TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
						int sec0_toPosition = (int)list_plcAdress.First(p => p.Adress == sec_zhuanggougai[0].TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
						//条码2
						int sec1_palletCode = (int)list_plcAdress.First(p => p.Adress == sec_zhuanggougai[1].TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
						int sec1_toPosition = (int)list_plcAdress.First(p => p.Adress == sec_zhuanggougai[1].TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
						//判断两个工位的空闲状态
						if (sec0_palletCode != 0 && sec1_palletCode != 0)
						{
							//均不为0，都忙，则跳过
							//continue;
						}
						else if (sec0_palletCode == 0 && sec1_palletCode == 0)
						{
							//都空闲，跳过
							//continue;
						}
						else if (sec0_palletCode == 0)
						{
							//第一个空闲
							//判断这个空闲工位是否是要去的工位
							if (toPosition_zhuanghougai.ToString() == sec_zhuanggougai[0].AdressCode)
							{
								//是则不做更改
								//continue;
							}
							else
							{
								//不是
								//更新地址
								if (MasterPLC1.WriteDeviceRandom2(zhuanghougaiqianzhidang.ToPositCode, 1, Convert.ToInt16(sec_zhuanggougai[0].AdressCode)) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + sec_zhuanggougai[0].SecondWorkStationName + "地址写入到" + zhuanghougaiqianzhidang.StopperName + "去向地址中失败！");
									LogExecute.WriteInfoLog(sec_zhuanggougai[0].SecondWorkStationName + "地址写入到" + zhuanghougaiqianzhidang.StopperName + "去向地址", false);
								}
								else
								{
									//地址更新成功后
									//更新记录,到第一个工位
									using (XinYaDBEntities db = new XinYaDBEntities())
									{
										try
										{
											//找出这条记录，原本是去1
											string palletCode_For4 = IntToStringfor4Length(palletCode_zhuanghougai);
											//2015.1.7,这里应该是1，也就是说原本是要找出对应1的工艺路线，然后更改
											int b = sec_zhuanggougai[1].ID;
											var a = db.TB_WorkDtlForEachStation.Where(p => p.TB_WorkMain.PalletCode == palletCode_For4 && p.TB_SecondWorkStationInfo.ID == b).OrderByDescending(p => p.ID).First();
											//将这条记录的去向工位加载到第一个
											int temp = sec_zhuanggougai[0].ID;
											a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == temp);
											//时间没必要改，反正到达工位后还会更新
											db.SaveChanges();
										}
										catch (Exception ex)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "托盘" + palletCode_zhuanghougai + "到" + sec_zhuanggougai[0].SecondWorkStationName + "更新任务工艺路线记录");
											LogExecute.WriteInfoLog("托盘" + palletCode_zhuanghougai + "到" + sec_zhuanggougai[0].SecondWorkStationName + "更新任务工艺路线记录,详情：" + ex.ToString(), false);
										}
									}
								}
							}
						}
						else if (sec1_palletCode == 0)
						{
							//第二个空闲
							//判断这个空闲工位是否是要去的工位
							if (toPosition_zhuanghougai.ToString() == sec_zhuanggougai[1].AdressCode)
							{
								//是则不做更改
								//continue;
							}
							else
							{
								//不是
								//更新地址
								if (MasterPLC1.WriteDeviceRandom2(zhuanghougaiqianzhidang.ToPositCode, 1, Convert.ToInt16(sec_zhuanggougai[1].AdressCode)) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + sec_zhuanggougai[1].SecondWorkStationName + "地址写入到" + zhuanghougaiqianzhidang.StopperName + "去向地址中失败！");
									LogExecute.WriteInfoLog(sec_zhuanggougai[1].SecondWorkStationName + "地址写入到" + zhuanghougaiqianzhidang.StopperName + "去向地址", false);
								}
								else
								{
									//地址更新成功后
									//更新记录,到第二个工位w
									using (XinYaDBEntities db = new XinYaDBEntities())
									{
										try
										{
											//找出这条记录，原本是去0
											string palletCode_For4 = IntToStringfor4Length(palletCode_zhuanghougai);
											//LINQ to Entities 不识别方法“XinYaProcessManageSystem.TB_SecondWorkStationInfo get_Item(Int32)”，因此该方法无法转换为存储表达式。
											int b = sec_zhuanggougai[0].ID;
											var a = db.TB_WorkDtlForEachStation.Where(p => p.TB_WorkMain.PalletCode == palletCode_For4 && p.TB_SecondWorkStationInfo.ID == b).OrderByDescending(p => p.ID).First();
											//将这条记录的去向工位更新
											int temp = sec_zhuanggougai[1].ID;
											a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == temp);
											//时间没必要改，反正到达工位后还会更新
											db.SaveChanges();
										}
										catch (Exception ex)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + "托盘" + palletCode_zhuanghougai + "到" + sec_zhuanggougai[1].SecondWorkStationName + "更新任务工艺路线记录");
											LogExecute.WriteInfoLog("托盘" + palletCode_zhuanghougai + "到" + sec_zhuanggougai[1].SecondWorkStationName + "更新任务工艺路线记录,详情：" + ex.ToString(), false);
										}
									}
								}
							}
						}
					}
				}
			}

			#endregion 磨合装后盖同样存在和包装段一样的空闲等待问题（时间问题，14.12.3已优化，需要测试）

			#region 返修工位调度

			//此工位在重新上线的时候PLC是不知道条码数据的（此处没有固定扫码头）
			//在2#处会重新扫描，所以在这里不写入去向地址
			//这里需要在PC端写入任务(这里没有扫码头)
			//这里PC端调用wcf服务写入托盘条码到其地址

			#endregion 返修工位调度

			#endregion 磨合段

			#region 调试段

			#region 2#

			//12月20日：客户端PC和电气程序已经写成必须经过调试和QC，所以这段处理程序不再启用。

			//这里主要是对一个不需要调试和QC的处理
			//判断进板请求（先有请求，后有进制处理与托盘条码写入）
			int D400 = (int)list_plcAdress.First(p => p.Adress == "D400").Data;
			if (D400 == 1)
			{
				//固定扫码头进制转换与写入
				PLCASCLLHelper(out palletCode1, out palletCode2, out palletCode3);
			}
			/*
			//实际上这里存在逻辑误区，即if代码段的代码永远不会执行（未修改）！！！！！！
			//这里之所以还未修改是故意的，考虑到泵体都会从调试段经过，这里没必要判断。
			//后期测试诺对处理速度影响不大，可以考虑修改
			//这里是判断是否会经过调试和QC，3#处会重新扫描，所以不加任务路线记录

			//先判断此处是否有托盘存在
			int pallet2 = (int)list_plcAdress.First(p => p.Adress == "D401").Data;
			int toPosition2 = (int)list_plcAdress.First(p => p.Adress == "D402").Data;
			//有托盘条码且没有写入去向地址
			if (pallet2 != 0 && toPosition2 == 0)
			{
				//获取当前任务
				using (XinYaDBEntities db = new XinYaDBEntities())
				{
					//筛选当前托盘所在任务
					string palletcode2 = IntToStringfor4Length(pallet2);
					var works = db.TB_WorkMain.First(p => p.PalletCode == palletcode2 && p.Finished == "0");
					//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
					//可替代的写法
					//string modelCode = works.TB_WorkDtl.ToList()[0].MaterialCode.Substring(0, 12);
					string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
					//根据型号代码加载工艺路线
					TB_MaterialInfo matertialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
					//matertialInfo.TB_ProcessRouteMReference.Load();
					//获取当前工艺路线
					//可替代写法
					//List<TB_ProcessRouteP> routePs = matertialInfo.TB_ProcessRouteM.TB_ProcessRouteP.ToList();
					List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
													  where a.ProcessRouteM == matertialInfo.TB_ProcessRouteM.ProcessRouteP
													  select a).ToList();
					//2#的工序在试验台前，置4
					int no = 4;
					//检查得到下一个工位No
					//no=from a in routeP
					//   where a.IsUse==true && a.No>no
					//   orderby a.No
					//查找下一个工艺
					TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
					//判定下一个工艺
					if (routeP.TB_WorkStationInfo.WorkStationCode != "E" && routeP.TB_WorkStationInfo.WorkStationCode != "F")
					{
						//两个都不去，算合格处理，去向地址置2
						short j = 2;
						if (MasterPLC1.WriteDeviceRandom2("D402", 1, j) != 0)
						{
							txt_Exception.AppendText("\n" + DateTime.Now + "2#处去向地址2写入失败");
							LogExecute.WriteInfoLog("2#去向地址2写入", false);
						}
					}
					else if (routeP.TB_WorkStationInfo.WorkStationCode != "E" && routeP.TB_WorkStationInfo.WorkStationCode == "F")
					{
						//不去试验,去QC，置1，当做已经经过试验台处理
						short j = 1;
						if (MasterPLC1.WriteDeviceRandom2("D402", 1, j) != 0)
						{
							txt_Exception.AppendText("\n" + DateTime.Now + "2#处去向地址1写入失败");
							LogExecute.WriteInfoLog("2#去向地址1写入", false);
						}
					}
					//是否是去试验台而不去QC台留给PC端处理
				}
			}
			*/
			#endregion 2#

			///
			//Test
			///
			//txt_test.AppendText("再一次进入调试QC段处理过程！！！！！！！！！" + "\n");
			//LogExecute.WriteInfoLog("再一次进入调试QC段处理过程！！！！！！！！！" + "\n");
			///
			///

			#region 关于调试QC段，软件扫描周期与电气地址传送周期冲突问题

			/*
			 *
			 * 关于调试QC段，软件扫描周期与电气地址传送周期冲突问题
			 * 方案
			 * 1.获取离该工位最近的一个阻挡器上的托盘和去向地址数据
			 * 2.如果这个阻挡器符合要求，进入第3步
			 * 3.判断前一个阻挡器的托盘编码和去向地址
			 * 4.如果托盘编码为0而去向地址不为0，说明这是电气正在下传数据，而且没有完成。
			 *   进入第5步；
			 *   如果托盘编码为0而且去向地址为0，说明这个时候电气的地址传递已经完成，进入第6步；
			 *   如果托盘编码不为0，说明当前地址还没开始往下传递，执行第6步；
			 * 5.跳出这次处理过程（continue），返回第1步
			 * 6.进行写入去向地址处理，返回第1步
			 *
			 * 经测试方案不可行，改为先行判断地址
			 * */

			#endregion 关于调试QC段，软件扫描周期与电气地址传送周期冲突问题

			#region 调试区调度

			/*
			//这里的托盘去向地址（“1”）由PC端调用WCF服务实现，这里做请求响应
			//这个地方实现请求调度,每个工位的请求对象为该工位以前的一个最近的阻挡器上的托盘
			//首先要获取这些调试工位（这里比最开始的计划少了2个试验台，筛选为true的台子）
			List<TB_SecondWorkStationInfo> list_tiaoshitai = list_secStation.Where(p => p.SecondWorkStationCode == "SE" && p.IsUse == true).ToList();
			//获取这个调试区的阻挡器信息
			List<TB_PLCAdressWithStopper> list_zudangqi;
			//循环遍历这些工位的请求信号，匹配最近的去向地址为0的阻挡器上的托盘
			foreach (var item in list_tiaoshitai)
			{
				//先判断是否有请求和锁定状态
				int require = Convert.ToInt32(list_plcAdress.First(P => P.Adress == item.TB_PLCAdressWithWorkStationInfo.RequirePallet).Data);
				int clock = Convert.ToInt32(list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PositCodeLock).Data);
				if (require == 1 && clock == 0)
				{
					//获取该工位之前的阻挡器信息(降序排列，以便获取满足条件的最近的一个)
					list_zudangqi = list_stopper.Where(p => p.StopperCode == "E" && p.No < item.NoInStopper).OrderByDescending(a => a.ID).ToList();
					//循环遍历
					for (int i = 0; i < list_zudangqi.Count; i++)
					{
						#region 访问控制，如果该阻挡器正准备向下传递地址，则不处理

						int stopperLockForNextStopper = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].StopperLockForNextStopper).Data;
						if (stopperLockForNextStopper == 1)
						{
							//锁定则跳过
							continue;
						}

						#endregion

						#region 访问控制，如果该阻挡器正在向工位中传递地址，则不处理
						//这里新增一个对于板式阻挡器的锁定控制（止档位）
						//如果对2取余等于0，说明他是止档位
						if (list_zudangqi[i].No % 2 == 0)
						{
							//对于止挡位需要判断它是否为锁定状态，如果为锁定状态则表示他正在向工位地址传递数据，则跳过不做处理
							int stopperClockForWorkStation = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].StopperLockForWorkStation).Data;
							//等于1表示锁定
							if (stopperClockForWorkStation == 1)
							{
								continue;
							}
						}
						#endregion

						//条件为该阻挡器上有托盘条码且地址去向为0
						int palletCode = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].PalletCode).Data;
						int toPosition = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].ToPositCode).Data;
						//这里有个问题，这里的去向地址虽然写入了PLC但是没有更新内存中的地址。这里会导致这个托盘被重复写入地址，所以要更新内存地址
						if (palletCode != 0 && toPosition == 0)
						{
							//
							//测试写法
							//第一种方案逻辑上对这个值进行判定是否是电气传递完成了的
							//
							//获取下一个工位的托盘编码和去向地址
							//排除第一个
							//if (list_zudangqi[i].No != 1)
							//{
							//    int id = list_zudangqi[i].ID - 1;
							//    TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
							//    int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
							//    int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
							//    //条件为上一个阻挡器上没有托盘编码，有去向地址--表示电气正在传递数据
							//    if (next_palletCode == 0 && next_toPosition != 0)
							//    {
							//        //为工作效率考虑，使用continue
							//        continue;
							//    }
							//}
							//第二种方案，考虑地址先传
							//获取前一个
							//排除最后一个
							//2014.11.7测试可行
							if (list_zudangqi[i].No != 58)
							{
								//前一个阻挡器
								int id = list_zudangqi[i].ID + 1;
								TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
								int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
								int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
								//条件为这个上面托盘编码为0且地址去向不为0--表示电气正在传递数据
								if (next_palletCode == 0 && next_toPosition != 0)
								{
									//为工作效率考虑，使用continue
									continue;
								}
							}
							//test_End
							//
							//将工位地址写入到该阻挡器上的
							if (MasterPLC1.WriteDeviceRandom2(list_zudangqi[i].ToPositCode, 1, Convert.ToInt16(item.AdressCode)) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "请求" + palletCode.ToString() + "失败");
								LogExecute.WriteInfoLog(item.SecondWorkStationName + "请求" + palletCode.ToString(), false);
							}
							else
							{
								//更新内存地址防止重复写入地址
								//list_plcAdress.First(p => p.Adress == list_zudangqi[i].ToPositCode).Data = Convert.ToInt16(item.AdressCode);
								foreach (var a in list_plcAdress)
								{
									if (a.Adress == list_zudangqi[i].ToPositCode)
									{
										a.Data = Convert.ToInt16(item.AdressCode);
										break;
									}
								}
								//
								//Test!!在写入前记录托盘号，阻挡器托盘地址与去向地址
								//
								txt_test.AppendText("调试" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_zudangqi[i].PalletCode + "," + list_zudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
								LogExecute.WriteInfoLog("调试" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_zudangqi[i].PalletCode + "," + list_zudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
								//
								//
								//将该工位的锁定状态置1
								if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock, 1, 1) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "锁定失败");
									LogExecute.WriteInfoLog(item.SecondWorkStationName + "锁定失败", false);
								}
								//
								//任务工艺路线记录（11月7日，调试QC区传递地址不稳定，暂时注释）
								WorkRouteRecord(IntToStringfor4Length(palletCode), item.ID, null);
								//break掉，防止重复锁定
								break;
							}
						}
					}
				}
			}
			*/
			#endregion 调试区调度

			#region 新的调试区调度算法20150125

			/*
			 * 考虑到磨合产能不足的问题，必然导致调试区的后面的等待问题。
			 * 这里可以考虑用list集合做一个响应队列已达到先按先得。
			 * 算法：
			 * 数据准备：
			 * list A存储呼叫工位，初始空
			 * list B存储响应后剩余的工位，初始空
			 * 1. list A 清空，将list B中的值赋值给list A；list B 清空
			 * 2. 遍历存储所有有请求且未锁定的调试台，如果A中已经包含，则跳过，如果没有，则新增
			 * 3. 遍历list A集合中的项，扫描之前的阻挡器对象，符合条件则响应；不符合条件则存入list B中。
			 * 4. 返回第1步。
			 * */

			////首先要获取这些调试工位（这里比最开始的计划少了2个试验台，筛选为true的台子）
			List<TB_SecondWorkStationInfo> list_tiaoshitai = list_secStation.Where(p => p.SecondWorkStationCode == "SE" && p.IsUse == true).ToList();
			//txt_Exception.AppendText(list_tiaoshitai.Count.ToString());
			////获取这个调试区的阻挡器信息
			List<TB_PLCAdressWithStopper> list_zudangqi;
			list_TiaoshiForA.Clear();
			if (list_TiaoshiForB.Count>0)
			{
				foreach (var item in list_TiaoshiForB)
				{
					//先判断是否有请求和锁定状态
					int require = Convert.ToInt32(list_plcAdress.First(P => P.Adress == item.TB_PLCAdressWithWorkStationInfo.RequirePallet).Data);
					int clock = Convert.ToInt32(list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PositCodeLock).Data);
					if (require == 1 && clock == 0)
					{
						TB_SecondWorkStationInfo temp = list_tiaoshitai.Single(p => p.ID == item.ID);
						list_TiaoshiForA.Add(temp);
					}
				}
			}
			list_TiaoshiForB.Clear();
			foreach (TB_SecondWorkStationInfo item in list_tiaoshitai)
			{
				//先判断是否有请求和锁定状态
				int require = Convert.ToInt32(list_plcAdress.First(P => P.Adress == item.TB_PLCAdressWithWorkStationInfo.RequirePallet).Data);
				int clock = Convert.ToInt32(list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PositCodeLock).Data);
				//符合条件
				if (require == 1 && clock == 0)
				{
					if (list_TiaoshiForA.Count(p => p.ID == item.ID) == 0)
					{
						//不存在则加入
						list_TiaoshiForA.Add(item);
					}
				}
			}
			//txt_Exception.AppendText(list_tiaoshitai.Count.ToString());
			//txt_test.AppendText(list_TiaoshiForA.Count.ToString());
			//遍历当前请求
			foreach (TB_SecondWorkStationInfo item in list_TiaoshiForA)
			{
				txt_test.AppendText("当前呼叫："+list_TiaoshiForA.Count.ToString() + "\n");
				//是否响应标志位
				int flag = 0;
				//获取该工位之前的阻挡器信息(降序排列，以便获取满足条件的最近的一个)
				list_zudangqi = list_stopper.Where(p => p.StopperCode == "E" && p.No < item.NoInStopper).OrderByDescending(a => a.ID).ToList();
				//循环遍历
				for (int i = 0; i < list_zudangqi.Count; i++)
				{
					#region 访问控制，如果该阻挡器正准备向下传递地址，则不处理

					int stopperLockForNextStopper = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].StopperLockForNextStopper).Data;
					if (stopperLockForNextStopper == 1)
					{
						//锁定则跳过
						continue;
					}

					#endregion

					#region 访问控制，如果该阻挡器正在向工位中传递地址，则不处理
					//这里新增一个对于板式阻挡器的锁定控制（止档位）
					//如果对2取余等于0，说明他是止档位
					if (list_zudangqi[i].No % 2 == 0)
					{
						//对于止挡位需要判断它是否为锁定状态，如果为锁定状态则表示他正在向工位地址传递数据，则跳过不做处理
						int stopperClockForWorkStation = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].StopperLockForWorkStation).Data;
						//等于1表示锁定
						if (stopperClockForWorkStation == 1)
						{
							continue;
						}
					}
					#endregion

					//条件为该阻挡器上有托盘条码且地址去向为0
					int palletCode = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].PalletCode).Data;
					int toPosition = (int)list_plcAdress.First(p => p.Adress == list_zudangqi[i].ToPositCode).Data;
					//这里有个问题，这里的去向地址虽然写入了PLC但是没有更新内存中的地址。这里会导致这个托盘被重复写入地址，所以要更新内存地址
					if (palletCode != 0 && toPosition == 0)
					{
						//第二种方案，考虑地址先传
						//获取前一个
						//排除最后一个
						//2014.11.7测试可行
						if (list_zudangqi[i].No != 58)
						{
							//前一个阻挡器
							int id = list_zudangqi[i].ID + 1;
							TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
							int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
							int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
							//条件为这个上面托盘编码为0且地址去向不为0--表示电气正在传递数据
							if (next_palletCode == 0 && next_toPosition != 0)
							{
								//为工作效率考虑，使用continue
								continue;
							}
						}
						//test_End
						//
						//将工位地址写入到该阻挡器上的
						if (MasterPLC1.WriteDeviceRandom2(list_zudangqi[i].ToPositCode, 1, Convert.ToInt16(item.AdressCode)) != 0)
						{
							txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "请求" + palletCode.ToString() + "失败");
							LogExecute.WriteInfoLog(item.SecondWorkStationName + "请求" + palletCode.ToString(), false);
						}
						else
						{
							//更新内存地址防止重复写入地址
							//list_plcAdress.First(p => p.Adress == list_zudangqi[i].ToPositCode).Data = Convert.ToInt16(item.AdressCode);
							foreach (var a in list_plcAdress)
							{
								if (a.Adress == list_zudangqi[i].ToPositCode)
								{
									a.Data = Convert.ToInt16(item.AdressCode);
									break;
								}
							}
							//
							//Test!!在写入前记录托盘号，阻挡器托盘地址与去向地址
							//
							txt_test.AppendText("调试" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_zudangqi[i].PalletCode + "," + list_zudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
							LogExecute.WriteInfoLog("调试" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_zudangqi[i].PalletCode + "," + list_zudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
							//
							//
							//将该工位的锁定状态置1
							if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock, 1, 1) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "锁定失败");
								LogExecute.WriteInfoLog(item.SecondWorkStationName + "锁定失败", false);
							}
							//
							//任务工艺路线记录（11月7日，调试QC区传递地址不稳定，暂时注释）
							WorkRouteRecord(IntToStringfor4Length(palletCode), item.ID, null);
							//表示已经被响应了
							flag = 1;
							//break掉，防止重复锁定
							break;
						}
					}
				}
				if (flag == 0)
				{
					//TB_SecondWorkStationInfo temp = new TB_SecondWorkStationInfo();
					//temp = list_tiaoshitai.First(p => p.ID == item.ID);
					//为0表示没有被响应，没有被响应则加入到集合B中
					list_TiaoshiForB.Add(item);
				}
				//txt_test.AppendText(list_TiaoshiForA.Count.ToString() + "\n");
			}

			#endregion

			#region QC调度

			//锁定标志位,初始0.
			//150120改为累加请求值
			int flagForClock = 0;

			#region 普通调度

			//
			//这里有QC台重复锁定问题未解决！！！
			//
			//这里PC端调用wcf服务进行写入地址，全部合格写入2，有不合格的写入3；这里做请求响应
			//这个地方实现请求调度,每个工位的请求对象为该工位以前的一个最近的阻挡器上的托盘
			List<TB_SecondWorkStationInfo> list_QC = list_secStation.Where(p => p.SecondWorkStationCode == "SF" && p.IsUse == true).ToList();
			//获取这个调试区+QC区的阻挡器信息
			List<TB_PLCAdressWithStopper> list_QCzudangqi;
			//循环遍历这些工位的请求信号，匹配最近的去向地址为0的阻挡器上的托盘
			foreach (var item in list_QC)
			{
				//先判断是否有请求和锁定状态
				int require = Convert.ToInt32((list_plcAdress.First(P => P.Adress == item.TB_PLCAdressWithWorkStationInfo.RequirePallet)).Data);
				int clock = Convert.ToInt32(list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PositCodeLock).Data);
				//--------------------------------
				//锁定累计,不等于0表示锁定（弃用）

				//if (clock != 0)
				//{
				//    flagForClock++;
				//}
				//改为请求累加
				if (require == 1)
				{
					//累加请求值
					flagForClock++;
				}


				//--------------------------------
				if (require == 1 && clock == 0)
				{
					//获取该工位之前的阻挡器信息(降序排列，以便获取满足条件的最近的一个)
					list_QCzudangqi = list_stopper.Where(p => (p.StopperCode == "E" || p.StopperCode == "F") && p.No < item.NoInStopper).OrderByDescending(a => a.ID).ToList();
					//循环遍历
					for (int i = 0; i < list_QCzudangqi.Count; i++)
					{

						#region 20150114访问控制，如果该阻挡器正准备向下传递地址，则不处理

						int stopperLockForNextStopper = (int)list_plcAdress.First(p => p.Adress == list_QCzudangqi[i].StopperLockForNextStopper).Data;
						if (stopperLockForNextStopper == 1)
						{
							//锁定则跳过
							continue;
						}

						#endregion

						#region 访问控制，如果该阻挡器正在向工位中传递地址，则不处理
						//这里新增一个对于板式阻挡器的锁定控制（止档位）
						//如果对2取余等于0，说明他是止档位
						if (list_QCzudangqi[i].No % 2 == 0)
						{
							//对于止挡位需要判断它是否为锁定状态，如果为锁定状态则表示他正在向工位地址传递数据，则跳过不做处理
							int stopperClock = (int)list_plcAdress.First(p => p.Adress == list_QCzudangqi[i].StopperLockForWorkStation).Data;
							//等于1表示锁定
							if (stopperClock == 1)
							{
								continue;
							}
						}
						#endregion

						//条件为该阻挡器上有托盘条码且地址去向为1
						int palletCode = (int)list_plcAdress.First(p => p.Adress == list_QCzudangqi[i].PalletCode).Data;
						int toPosition = (int)list_plcAdress.First(p => p.Adress == list_QCzudangqi[i].ToPositCode).Data;
						//这里有个问题，这里的去向地址虽然写入了PLC但是没有更新内存中的地址。这里会导致这个托盘被重复写入地址，所以要更新内存地址
						if (palletCode != 0 && toPosition == 1)
						{
							//---------------------------------
							//增加写入控制14.11.8，解决周期冲突问题（地址先传）
							//150113在地址不为0的情况下，实际上这段代码是不需要的，考虑最新的上锁方案，当检测到托盘不为0去向为1的时候，托盘一定是在等待状态
							//这个时候无需再考虑这个传递问题
							//---------------------------------
							//if (list_QCzudangqi[i].No != 58)
							//{
							//    //前一个阻挡器(表中是按前后顺序来的)
							//    int id = list_QCzudangqi[i].ID + 1;
							//    TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
							//    int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
							//    int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
							//    //条件为这个上面托盘编码为0且地址去向不为0--表示电气正在传递数据
							//    if (next_palletCode == 0 && next_toPosition != 0)
							//    {
							//        //为工作效率考虑，使用continue
							//        continue;
							//    }
							//}
							//
							//----------托盘先传-----------------------
							//

							//if (list_QCzudangqi[i].No != 1)
							//{
							//    int id = list_QCzudangqi[i].ID - 1;
							//    TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
							//    int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
							//    int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
							//    //条件为上一个阻挡器上没有托盘编码，有去向地址--表示电气正在传递数据
							//    if (next_palletCode == 0 && next_toPosition != 0)
							//    {
							//        //为工作效率考虑，使用continue
							//        continue;
							//    }
							//}

							//
							//---------------------------------
							//

							//将工位地址写入到该阻挡器上的
							if (MasterPLC1.WriteDeviceRandom2(list_QCzudangqi[i].ToPositCode, 1, Convert.ToInt16(item.AdressCode)) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "请求" + palletCode.ToString() + "失败");
								LogExecute.WriteInfoLog(item.SecondWorkStationName + "请求" + palletCode.ToString(), false);
							}
							else
							{
								//更新内存地址防止重复写入地址
								//list_plcAdress.First(p => p.Adress == list_zudangqi[i].ToPositCode).Data = Convert.ToInt16(item.AdressCode);
								foreach (var a in list_plcAdress)
								{
									if (a.Adress == list_QCzudangqi[i].ToPositCode)
									{
										a.Data = Convert.ToInt16(item.AdressCode);
										break;
									}
								}

								//
								//Test!!在写入前记录托盘号，阻挡器托盘地址与去向地址
								//
								txt_test.AppendText("QC" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_QCzudangqi[i].PalletCode + "," + list_QCzudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
								LogExecute.WriteInfoLog("QC" + DateTime.Now.ToLongTimeString() + ":" + palletCode.ToString() + "," + toPosition.ToString() + "," + list_QCzudangqi[i].PalletCode + "," + list_QCzudangqi[i].ToPositCode + "," + item.SecondWorkStationName + "," + item.AdressCode + "。" + "\n");
								//
								//

								//将该工位的锁定状态置1
								if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.PositCodeLock, 1, 1) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "锁定失败");
									LogExecute.WriteInfoLog(item.SecondWorkStationName + "锁定失败", false);
								}
								//
								//任务工艺路线记录（（11月7日，调试QC区传递地址不稳定，暂时注释））
								//12.13；如果加入地址变换后，请注释掉这一段，路线记录留给PC端，
								//12.18，为配合虚拟QC台的实现，这里不再记录，QC工序路线记录全部由PC端完成
								//WorkRouteRecord(IntToStringfor4Length(palletCode), item.ID, null);
								//break掉，防止重复锁定
								break;
							}
						}
					}
				}
			}

			#endregion 普通调度

			#region 14.12.10补充程序

			/*
			 *     所有的托盘都必须经过QC段，已经要求电气将没有QC台响应的调试过的托盘全部阻挡在QC第一工位的前阻挡位。
			 * 这里有一个问题：
			 *     如果6个QC台全部要盘，而此时6个工位全部被满足，全部锁定，
			 *     而在第一个响应托盘之前又有托盘从调试放出，则会出现阻塞情况。
			 * 算法方案：
			 *     普通调度中，不在记录路线，路线记录留给PC端完成。
			 *     时钟程序扫描到时：
			 *     1.当第一QC位前阻有托盘数据的时候，判断：
			 *       1）托盘地址有数据，托盘去向地址数据为1
			 *       2）6个QC台全部锁定
			 *       满足上述两个条件，进行第2步，跳过这段处理程序。
			 *     2.判断剩余QC端阻挡器上是否有托盘编号和去向地址（需要进行地址传递判定），如果有托盘数据，去向地址都为2或3，进行第3步，如果
			 *       没有进行第4步。
			 *     3.不作处理，可以等待调试到达QC后，重新分配请求到第一QC前阻。
			 *     4.由于电气的请求信号在锁定后清除，这里我做地址传递处理。
			 *       单独做一个个例处理：
			 *           获取第一个可用的QC台去向地址，循环匹配（需要进行地址传递判定），（如果判定下一个阻挡器地址，然后赋值，那这样存在等待情况，效率不高）
			 *           匹配到去向地址相同，更新这个去向地址为1；然后将这个QC台的地址赋值给第一QC前阻。
			 * 问题说明：
			 *     这里有一个锁定值更新滞后的问题，前面普通调度的时候是在处理请求之前累加的锁定值，请求处理之后，锁定值可能会重新更新到PLC，
			 * 这个时候，得出的flagForClock可能不是最新的。但是，当第二次处理过程中，如果全部锁定，则不会进入普通调度逻辑，进入本调度。
			 * 也就是说，出现全部锁定的处理会在第二次处理逻辑中进行。
			 *     评估结果是对系统未造成影响。
			 * 问题说明2：
			 *     测试中发现并不是每一个台子都会去用，在不用的时候也并不是每一个台子都会被及时锁定，所以这里单单依靠锁定值来判断则可能出现死锁。
			 *     应该按照呼叫动态的赋值。
			 * 
			 * */

			//...未完成...

			//* 已写完，未测试，未启用
			//1.获取这个特定的阻挡器对象(第一QC位前挡);剩余QC位阻挡器对象,排除第一个和最后一个；
			//所有调试台阻挡器对象,ID升序排列，从前往后，变换地址为最远一个，可减少变换量，但是更改了响应顺序。如果客户要求更改，这里做一个降序排序即可
			TB_PLCAdressWithStopper zhudangqi_51 = list_stopper.Single(p => p.ID == 72);
			//List<TB_PLCAdressWithStopper> list_zhudangqiForQCRemain = list_stopper.Where(p => p.StopperCode == "F" && p.ID != 70 && p.ID != 77).ToList();
			//List<TB_PLCAdressWithStopper> list_zhudangqiForTiaoshi = list_stopper.Where(p => p.StopperCode == "E").OrderBy(p => p.ID).ToList();
			//2.判断地址数据,有托盘数据和去向地址为1则满足条件。
			int stopper_palletCode = (int)list_plcAdress.First(p => p.Adress == zhudangqi_51.PalletCode).Data;
			int stopper_toPosition = (int)list_plcAdress.First(p => p.Adress == zhudangqi_51.ToPositCode).Data;
			if (stopper_palletCode != 0 && stopper_toPosition == 1)
			{
				List<TB_PLCAdressWithStopper> list_zhudangqiForQCRemain = list_stopper.Where(p => p.StopperCode == "F" && p.ID != 72 && p.ID != 77).ToList();
				List<TB_PLCAdressWithStopper> list_zhudangqiForTiaoshi = list_stopper.Where(p => p.StopperCode == "E").OrderBy(p => p.ID).ToList();
				//3.检查6个QC位是否全部锁住,list_QC在普通调度中定义。当累加的锁定值等于QC工位总数，说明这些可用的QC台都已经锁定
				//存在禁用情况，这里的锁定数量不一定为6。
				//计算调试阻挡器中响应的数量
				int flagForXiangying = 0;
				foreach (var item in list_zhudangqiForTiaoshi)
				{
					//地址开头70表示被QC台响应
					string temp = list_plcAdress.First(p => p.Adress == item.ToPositCode).Data.ToString();
					if (temp.Length > 2)
					{
						if (temp.Substring(0, 2) == "70")
						{
							flagForXiangying++;
						}
					}
				}
				//如果响应的数量等于呼叫的数量，说明要做一个变换
				if (flagForClock == flagForXiangying)
				{
					//4.检查剩余阻挡器上是否有去向地址不为0，2，3的。（即为响应了QC请求，但还未到达QC台的托盘）
					//实际上这段代码永远得不到执行。
					//标志位
					int flagFor4 = 0;
					//遍历剩余阻挡器对应地址数据
					foreach (var item in list_zhudangqiForQCRemain)
					{
						//这里获取去向地址即可
						int item_toPosition = (int)list_plcAdress.First(p => p.Adress == item.ToPositCode).Data;
						//虽然没必要，但考虑在测试阶段，还是对1做一个处理。
						if (item_toPosition != 0 && item_toPosition != 2 && item_toPosition != 3 && item_toPosition != 1)
						{
							flagFor4++;
						}
						//一旦不等于0便不符合条件，跳出
						if (flagFor4 != 0)
						{
							break;
						}
					}
					//这里对标志位做判断，如果不等于0，说明有响应过第一QC而未到达指定QC，跳出处理程序
					if (flagFor4 == 0)
					{
						//5.等于0说明响应托盘都在调试区。需要做地址变换。
						foreach (var item in list_zhudangqiForTiaoshi)
						{
							#region 20150114访问控制，如果该阻挡器正准备向下传递地址，则不处理

							int stopperLockForNextStopper = (int)list_plcAdress.First(p => p.Adress == item.StopperLockForNextStopper).Data;
							if (stopperLockForNextStopper == 1)
							{
								//锁定则跳过
								continue;
							}

							#endregion
							//条件为该阻挡器上有托盘条码且地址去向不为1或0（已经被响应）
							//20150109这里有个问题，如果托盘被调试台响应，地址也是不为1或0
							//这里的条件应该是判定是否是QC台的地址，如果是才做处理
							int palletCode = (int)list_plcAdress.First(p => p.Adress == item.PalletCode).Data;
							int toPosition = (int)list_plcAdress.First(p => p.Adress == item.ToPositCode).Data;
							string temp_toPosition = toPosition.ToString();
							//大于2表示这个去向地址一定是被QC工位响应的地址
							if (palletCode != 0 && temp_toPosition.Length > 2)
							{
								//如果地址开头是70，则表示他是被QC台响应的
								if (temp_toPosition.Substring(0, 2) == "70")
								{
									//if (palletCode != 0 && toPosition != 1 && toPosition != 0)
									//{
									//是否正在传递判断,正在传递的数据不作考虑
									//20150109这段代码实际上是用不到了，先注释掉，然后
									//if (item.No != 58)
									//{
									//    //前一个阻挡器
									//    int id = item.ID + 1;
									//    TB_PLCAdressWithStopper _zudangqi = list_stopper.Single(p => p.ID == id);
									//    int next_palletCode = (int)list_plcAdress.First(p => p.Adress == _zudangqi.PalletCode).Data;
									//    int next_toPosition = (int)list_plcAdress.First(p => p.Adress == _zudangqi.ToPositCode).Data;
									//    //条件为这个上面托盘编码为0且地址去向不为0--表示电气正在传递数据
									//    if (next_palletCode == 0 && next_toPosition != 0)
									//    {
									//        //为工作效率考虑，使用continue
									//        continue;
									//    }
									//}
									//通过判断，则变换地址后结束这个处理程序段，因为后续程序中没有处理到调试和QC端的地址数据，所以这里可以不对内存中的地址做一个修改
									//清空这个阻挡器上的地址，还原为1.
									if (MasterPLC1.WriteDeviceRandom2(item.ToPositCode, 1, 1) != 0)
									{
										txt_Exception.AppendText("\n" + DateTime.Now + item.StopperName + "还原地址数据1失败");
										LogExecute.WriteInfoLog(item.StopperName + "还原地址数据1失败", false);
									}
									else
									{
										//成功清空后才进行变换写入
										//将新地址写入第一QC前阻
										if (MasterPLC1.WriteDeviceRandom2(zhudangqi_51.ToPositCode, 1, (Int16)toPosition) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + item.StopperName + "变换地址写入到第一QC前阻失败");
											LogExecute.WriteInfoLog(item.StopperName + "变换地址写入到第一QC前阻失败", false);
										}
										else
										{
											//废弃的处理段2015.1.5；
											//QC台在普通调度中不在记录工艺路线，这里不需要对路线进行更新
											////更新工艺路线记录
											////删除原有
											//int workID;
											//int secondWorkStationID;
											//DeletFirstRouteRecord(IntToStringfor4Length(palletCode),out workID,out secondWorkStationID);
											////string toPosition
											////新增更新,如果前面的删除工艺路线失败，这边不作新增。
											//if (secondWorkStationID!=0)
											//{
											//    WorkRouteRecord(IntToStringfor4Length(stopper_palletCode), secondWorkStationID, null);
											//}
											//这两个都写完后，本次地址变换结束
											break;
										}
										//}
									}
								}
							}
						}
					}
				}
			}

			#endregion 14.12.10补充程序

			#endregion QC调度

			#endregion 调试段

			#region 包装段

			#region 3#固定扫描头处

			//扫描托盘条码，查找工艺路线
			//取值，3#请求进板信号
			int D800 = Convert.ToInt32(list_plcAdress.First(p => p.Adress == "D800").Data);
			//判断,等于1表示有进板请求（其实我觉得这里有点没必要）
			if (D800 == 1)
			{
				//固定扫码头进制转换与写入
				PLCASCLLHelper(out palletCode1, out palletCode2, out palletCode3);

				//这里这个问题，当我写入托盘条码的时候内存地址D801里面还没有取到最新值，即为0；
				//所以第一次这里是进不了if段代码的。而后写入D801托盘条码后，电控将D800请求位置0；
				//处理程序第二次处理到这个阶段的时候，D800==0，也不会进入这个程序段，但实际情况是上位机能将下一个地址写入到去向地址中。
				//这里做更改。

				#region MyRegion

				/*
				//获取条码
				int palletCode = (int)list_plcAdress.First(p => p.Adress == "D801").Data;
				int toPosition = (int)list_plcAdress.First(p => p.Adress == "D802").Data;
				if (palletCode != 0 && toPosition == 0)
				{
					//匹配下一个工艺路线
					using (XinYaDBEntities db = new XinYaDBEntities())
					{
						//筛选当前托盘所在任务
						string palletcode2 = IntToStringfor4Length(palletCode);
						TB_WorkMain works = new TB_WorkMain();
						try
						{
							works = db.TB_WorkMain.First(p => p.PalletCode == palletcode2 && p.Finished == "0");
						}
						catch
						{
							timer_PLC.Enabled = false;
							MessageBox.Show(palletCode2);
							timer_PLC.Enabled = true;
							return;
						}
						//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
						//可替代的写法
						//string modelCode = works.TB_WorkDtl.ToList()[0].MaterialCode.Substring(0, 12);
						string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
						//根据型号代码加载工艺路线
						TB_MaterialInfo matertialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
						//matrtialInfo.TB_ProcessRouteMReference.Load();
						//获取当前工艺路线
						//可替代写法
						//List<TB_ProcessRouteP> routePs = matertialInfo.TB_ProcessRouteM.TB_ProcessRouteP.ToList();
						List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
														  where a.ProcessRouteM == matertialInfo.TB_ProcessRouteM.ProcessRouteP
														  select a).ToList();
						//查找当前所在工序No,3#提升机处的地址
						//int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
						//3#提升机系统里面没有给予逻辑地址，故将no定位到输油泵前一个工位地址
						int no = 6;
						//查找下一个工艺
						TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
						//随机写入下一个工位地址
						//先找出来下一个工位
						List<TB_SecondWorkStationInfo> sec = list_secStation.Where(p => p.WorkStationCode == routeP.TB_WorkStationInfo.WorkStationCode).ToList();
						//如果只有一个在使用，那么去向地址就写入这个里面(那么如果两个都禁用呢？理论上无法写入去向地址，托盘不动)
						if (sec.Count == 1)
						{
							MasterPLC1.WriteDeviceRandom2("D802", 1, Convert.ToInt16(sec[0].AdressCode));
						}
						else if (sec.Count == 2)//不存在禁用情况，则随机写入
						{
							//随机找出下一个工位，从包装段开始的每个工序均只有两个工位
							Random random = new Random();
							int r = random.Next(1, 3);
							//取到1放第一个
							if (r == 1)
							{
								short j = Convert.ToInt16(sec.First(p => p.No == 1).AdressCode);
								MasterPLC1.WriteDeviceRandom2("D802", 1, j);
							}
							else if (r == 2)//取第二个工位
							{
								short j = Convert.ToInt16(sec.First(p => p.No == 2).AdressCode);
								MasterPLC1.WriteDeviceRandom2("D802", 1, j);
							}
						}
						//下个工位都被禁用了则会卡在阻挡器上
					}
				}
				 * */

				#endregion MyRegion
			}
			//获取条码
			int palletcode = (int)list_plcAdress.First(p => p.Adress == "D801").Data;
			int toposition = (int)list_plcAdress.First(p => p.Adress == "D802").Data;
			if (palletcode != 0 && toposition == 0)
			{
				//匹配下一个工艺路线
				using (XinYaDBEntities db = new XinYaDBEntities())
				{
					//筛选当前托盘所在任务
					string palletcode3 = IntToStringfor4Length(palletcode);
					TB_WorkMain works = new TB_WorkMain();
					try
					{
						works = db.TB_WorkMain.First(p => p.PalletCode == palletcode3 && p.Finished == "0");
						//}
						//catch
						//{
						//    timer_PLC.Enabled = false;
						//    MessageBox.Show(palletcode2);
						//    timer_PLC.Enabled = true;
						//    return;
						//}
						//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
						//可替代的写法
						//string modelCode = works.TB_WorkDtl.ToList()[0].MaterialCode.Substring(0, 12);
						string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
						//根据型号代码加载工艺路线
						TB_MaterialInfo matertialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
						//matrtialInfo.TB_ProcessRouteMReference.Load();
						//获取当前工艺路线
						//可替代写法
						//List<TB_ProcessRouteP> routePs = matertialInfo.TB_ProcessRouteM.TB_ProcessRouteP.ToList();
						List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
														  where a.ProcessRouteM == matertialInfo.TB_ProcessRouteM.ProcessRouteP
														  select a).ToList();
						//查找当前所在工序No,3#提升机处的地址
						//int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
						//3#提升机系统里面没有给予逻辑地址，故将no定位到输油泵前一个工位地址
						int no = 6;
						//查找下一个工艺
						TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
						//随机写入下一个工位地址
						//先找出来下一个工位
						List<TB_SecondWorkStationInfo> sec = list_secStation.Where(p => p.WorkStationCode == routeP.TB_WorkStationInfo.WorkStationCode).ToList();
						//如果只有一个在使用，那么去向地址就写入这个里面(那么如果两个都禁用呢？理论上无法写入去向地址，托盘不动)
						if (sec.Count == 1)
						{
							if (MasterPLC1.WriteDeviceRandom2("D802", 1, Convert.ToInt16(sec[0].AdressCode)) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + "3#去向地址写入失败");
								LogExecute.WriteInfoLog("3#去向地址写入", false);
							}
							else
							{
								//记录任务路线
								WorkRouteRecord(palletcode3, sec[0].ID, db);
							}
						}
						else if (sec.Count == 2)//不存在禁用情况，则随机写入
						{
							#region 随机写法

							/*
							//随机找出下一个工位，从包装段开始的每个工序均只有两个工位
							Random random = new Random();
							int r = random.Next(1, 3);
							//取到1放第一个
							//if (r == 1)
							//{
							short j = Convert.ToInt16(sec.First(p => p.No == r).AdressCode);
							if (MasterPLC1.WriteDeviceRandom2("D802", 1, j) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + "3#去向地址写入失败");
								LogExecute.WriteInfoLog("3#去向地址写入", false);
							}
							else
							{
								//记录任务路线
								WorkRouteRecork(palletcode3, sec.First(p => p.No == r).ID, db);
							}
							 *
							 * * */

							#endregion 随机写法

							#region 0/1写法（需测试）

							int r = 1;//标志位
							if (bool_baozhuang[(int)routeP.No - 7] == true)
							{
								//为true赋值给第一个
								r = 1;
								bool_baozhuang[(int)routeP.No - 7] = false;
							}
							else
							{
								//false赋值给第二个
								r = 2;
								bool_baozhuang[(int)routeP.No - 7] = true;
							}

							short j = Convert.ToInt16(sec.First(p => p.No == r).AdressCode);
							if (MasterPLC1.WriteDeviceRandom2("D802", 1, j) != 0)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + sec[0].SecondWorkStationName + "地址写入到3#提升机去向地址中失败！");
								LogExecute.WriteInfoLog(sec[0].SecondWorkStationName + "地址写入到3#提升机去向地址", false);
							}
							else
							{
								//任务路线记录
								WorkRouteRecord(palletcode3, sec.First(p => p.No == r).ID, db);
							}

							#endregion 0/1写法（需测试）
						}
						//下个工位都被禁用了则会卡在阻挡器上
					}
					catch (Exception ex)
					{
						txt_Exception.AppendText("\n" + DateTime.Now + "3#去向地址处理异常,可能原因为该托盘所对应的任务已经完成或者该条任务将要去的工位均被禁用，托盘无法到达。");
						LogExecute.WriteDBExceptionLog(ex);
					}
				}
			}

			#endregion 3#固定扫描头处

			#region 输油泵装配调度

			/**
			//扫描托盘条码，查找工艺路线
			//获取输油泵工位
			List<TB_SecondWorkStationInfo> shuyoubengs = list_secStation.Where(p => p.SecondWorkStationCode == "SG").ToList();
			//循环遍历
			foreach (var item in shuyoubengs)
			{
				//条码
				int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
				//等于零表示没有托盘条码
				if (palletCode != 0)
				{
					using (XinYaDBEntities db = new XinYaDBEntities())
					{
						//筛选当前托盘所在任务s
						var works = db.TB_WorkMain.First(p => Convert.ToInt32(p.PalletCode) == palletCode && p.Finished == "0");
						//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
						string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
						//根据型号代码加载工艺路线
						TB_MaterialInfo matrtialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
						matrtialInfo.TB_ProcessRouteMReference.Load();
						//获取当前工艺路线
						List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
														  where a.ProcessRouteM == matrtialInfo.TB_ProcessRouteM.ProcessRouteP
														  select a).ToList();
						//查找当前所在工序No
						int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
						//检查得到下一个工位No
						//no=from a in routeP
						//   where a.IsUse==true && a.No>no
						//   orderby a.No
						//查找下一个工艺路线
						TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1);
						//获取
						//随机写入下一个工位地址
						//先找出来下一个工位
						List<TB_SecondWorkStationInfo> sec = list_secStation.Where(p => p.WorkStationCode == routeP.TB_WorkStationInfo.WorkStationCode).ToList();
						//随机找出下一个工位，从包装段开始的每个工序均只有两个工位
						Random random = new Random();
						int r = random.Next(1, 3);
						//取到1放第一个
						if (r == 1)
						{
							short j = Convert.ToInt16(sec.First(p => p.No == 1).AdressCode);
							MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j);
						}
						else if (r == 2)//取第二个工位
						{
							short j = Convert.ToInt16(sec.First(p => p.No == 2).AdressCode);
							MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j);
						}
					}
				}
			}
			 *
			 * */

			WorkStationManageWithPLCAdress("SG");

			#endregion 输油泵装配调度

			#region 分流检测调度

			//这里用作异常泵重新上线，此处有手持扫码枪

			//这里没有固定扫码头，不知道怎么弄了...

			//初步打算在这里起WCF服务，供客户端调用，然后写入托盘条码

			//这里的条码写入在调用wcf服务的时候实现,去向地址在此处写入
			WorkStationManageWithPLCAdress("SH");

			#endregion 分流检测调度

			#region 装齿杆罩帽调度

			WorkStationManageWithPLCAdress("SI");

			#endregion 装齿杆罩帽调度

			#region 试高压调度

			WorkStationManageWithPLCAdress("SJ");

			#endregion 试高压调度

			#region 装底/后盖板/支架调度

			WorkStationManageWithPLCAdress("SK");

			#endregion 装底/后盖板/支架调度

			#region 试低压调度

			WorkStationManageWithPLCAdress("SL");

			#endregion 试低压调度

			#region 装附件

			WorkStationManageWithPLCAdress("SM");

			#endregion 装附件

			#region VE泵装附件

			WorkStationManageWithPLCAdress("SN");

			#endregion VE泵装附件

			#region 外观检查/铅封调度

			//托盘在此处下线，不在往下流，所以这里不需要再赋值去向地址
			//WorkStationManageWithPLCAdress("SO");

			#endregion 外观检查/铅封调度

			#region 装塑料袋/打码/贴码调度

			//任务完成已由wcf服务实现

			////这里结束时托盘到了这个地方就制动结束
			////获取工位信息
			//List<TB_SecondWorkStationInfo> zhuangshuoliaodais = list_secStation.Where(p => p.SecondWorkStationCode == "SP").ToList();
			////循环遍历
			//foreach (var item in zhuangshuoliaodais)
			//{
			//    //条码
			//    int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
			//    //等于零表示没有托盘条码
			//    if (palletCode != 0)
			//    {
			//        using (XinYaDBEntities db = new XinYaDBEntities())
			//        {
			//            try
			//            {
			//                //筛选当前托盘所在任务
			//                var works = db.TB_WorkMain.First(p => Convert.ToInt32(p.PalletCode) == palletCode && p.Finished == "0");
			//                //这是最后一个工位，没有再写入去向地址而是将这个主任务结束掉
			//                works.Finished = "1";
			//                //任务结束类型为自动
			//                works.FinishedType = "自动";
			//                db.SaveChanges();
			//            }
			//            catch (Exception ex)
			//            {
			//                txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "处自动结束任务异常！");
			//                LogExecute.WriteDBExceptionLog(ex);
			//            }
			//        }
			//    }
			//}

			#endregion 装塑料袋/打码/贴码调度

			#region 包装段流程优化代码（14.12.3需要重新测试）

			//11月12号发现包装段即使是采用了0/1算法，由于员工工作时间有长短
			//改动记录和算法描述请参见设计笔记11月13号的内容。
			//-------------------------------------------------------------
			//获取包装段阻挡器信息
			//发现一个问题，在禁用了其中一个或两个工位的情况下，现行分配方式会直接选取下一个工位，如果下一个工位被禁用，两个结果，1.报错，2.这种修补分配方式会导致托盘走向被禁用的工位
			//（已修改）
			//解决方案
			//1.对于阻挡器上的信息而言，它所带托盘信息和去向地址肯定是针对于可用的，当前处理逻辑已经加载了的工位信息
			//2.如果托盘要去的（不去的会跳过）工位有禁用情况
			//3.如果全部禁用，这种情况下不会赋予去向地址
			//4.如果禁用了一个，那么这个托盘带的去向地址就不需要修改，作为禁用工位，地址都为0.
			//5.2个都启用，按照现行方案处理。
			//综上，在执行这段程序前加一个判定，如果启用工位为2个才进行处理。
			foreach (var item in list_Baozhuangduanstopper)
			{
				if (item.No % 2 == 1 && item.No != 21)//对2取余等于1表示是奇数位，奇数位为前止位,排除最后一个
				{
					//去去向地址和托盘地址
					//条码
					int palletCode = (int)list_plcAdress.First(p => p.Adress == item.PalletCode).Data;
					int toPosition = (int)list_plcAdress.First(p => p.Adress == item.ToPositCode).Data;
					//有数据
					if (palletCode != 0 && toPosition != 0)
					{
						//12月3号加入判定，当启用工位为2个的时候才进行处理
						if (list_secStation.Count(p => p.NoInStopper == item.No + 58) == 2)
						{
							//取出下两个个工位
							List<TB_SecondWorkStationInfo> sec2 = list_secStation.Where(p => p.NoInStopper == item.No + 58).ToList();
							//if (sec2.Count <= 2)
							//{
							//循环匹配去向地址与下一个工位是否对应
							if (Convert.ToInt32(sec2[0].AdressCode) == toPosition || Convert.ToInt32(sec2[1].AdressCode) == toPosition)
							{
								//表示这个工位正是托盘要去的工位
								//获取这两个工位上的托盘地址和去向地址
								//条码1
								int sec0_palletCode = (int)list_plcAdress.First(p => p.Adress == sec2[0].TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
								int sec0_toPosition = (int)list_plcAdress.First(p => p.Adress == sec2[0].TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
								//条码2
								int sec1_palletCode = (int)list_plcAdress.First(p => p.Adress == sec2[1].TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
								int sec1_toPosition = (int)list_plcAdress.First(p => p.Adress == sec2[1].TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
								//判断两个工位的空闲状态
								if (sec0_palletCode != 0 && sec1_palletCode != 0)
								{
									//均不为0，都忙，则跳过
									continue;
								}
								else if (sec0_palletCode == 0 && sec1_palletCode == 0)
								{
									//都空闲，跳过
									continue;
								}
								else if (sec0_palletCode == 0)
								{
									//第一个空闲
									//判断这个空闲工位是否是要去的工位
									if (toPosition.ToString() == sec2[0].AdressCode)
									{
										//是则不做更改
										continue;
									}
									else
									{
										//不是
										//更新地址
										if (MasterPLC1.WriteDeviceRandom2(item.ToPositCode, 1, Convert.ToInt16(sec2[0].AdressCode)) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + sec2[0].SecondWorkStationName + "地址写入到" + item.StopperName + "去向地址中失败！");
											LogExecute.WriteInfoLog(sec2[0].SecondWorkStationName + "地址写入到" + item.StopperName + "去向地址", false);
										}
										else
										{
											//地址更新成功后
											//更新记录,到第二个工位w
											using (XinYaDBEntities db = new XinYaDBEntities())
											{
												try
												{
													//找出这条记录，原本是去1
													string palletCode_For4 = IntToStringfor4Length(palletCode);
													int b = sec2[1].ID;
													var a = db.TB_WorkDtlForEachStation.Where(p => p.TB_WorkMain.PalletCode == palletCode_For4 && p.TB_SecondWorkStationInfo.ID == b).OrderByDescending(p => p.ID).First();
													//将这条记录的去向工位加载到第一个
													int temp = sec2[0].ID;
													a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == temp);
													//时间没必要改，反正到达工位后还会更新
													db.SaveChanges();
												}
												catch (Exception ex)
												{
													txt_Exception.AppendText("\n" + DateTime.Now + "托盘" + palletCode + "到" + sec2[0].SecondWorkStationName + "更新任务工艺路线记录");
													LogExecute.WriteInfoLog("托盘" + palletCode + "到" + sec2[0].SecondWorkStationName + "更新任务工艺路线记录", false);
												}
											}
										}
									}
								}
								else if (sec1_palletCode == 0)
								{
									//第二个空闲
									//判断这个空闲工位是否是要去的工位
									if (toPosition.ToString() == sec2[1].AdressCode)
									{
										//是则不做更改
										continue;
									}
									else
									{
										//不是
										//更新地址
										if (MasterPLC1.WriteDeviceRandom2(item.ToPositCode, 1, Convert.ToInt16(sec2[1].AdressCode)) != 0)
										{
											txt_Exception.AppendText("\n" + DateTime.Now + sec2[1].SecondWorkStationName + "地址写入到" + item.StopperName + "去向地址中失败！");
											LogExecute.WriteInfoLog(sec2[1].SecondWorkStationName + "地址写入到" + item.StopperName + "去向地址", false);
										}
										else
										{
											//地址更新成功后
											//更新记录,到第二个工位w
											using (XinYaDBEntities db = new XinYaDBEntities())
											{
												try
												{
													//找出这条记录，原本是去0
													string palletCode_For4 = IntToStringfor4Length(palletCode);
													//LINQ to Entities 不识别方法“XinYaProcessManageSystem.TB_SecondWorkStationInfo get_Item(Int32)”，因此该方法无法转换为存储表达式。
													int b = sec2[0].ID;
													var a = db.TB_WorkDtlForEachStation.Where(p => p.TB_WorkMain.PalletCode == palletCode_For4 && p.TB_SecondWorkStationInfo.ID == b).OrderByDescending(p => p.ID).First();
													//将这条记录的去向工位更新
													int temp = sec2[1].ID;
													a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == temp);
													//时间没必要改，反正到达工位后还会更新
													db.SaveChanges();
												}
												catch (Exception ex)
												{
													txt_Exception.AppendText("\n" + DateTime.Now + "托盘" + palletCode + "到" + sec2[1].SecondWorkStationName + "更新任务工艺路线记录");
													LogExecute.WriteInfoLog("托盘" + palletCode + "到" + sec2[1].SecondWorkStationName + "更新任务工艺路线记录", false);
												}
											}
										}
										//}
									}
								}
							}
						}
					}
				}
			}

			#endregion 包装段流程优化代码（14.12.3需要重新测试）

			#endregion 包装段

			////人为加长处理过程1s
			//timer_PLC.Enabled = false;
			////等待1s，需测试
			//Thread.Sleep(1000);
			//timer_PLC.Enabled = true;

			DateTime end = DateTime.Now;
			TimeSpan dt1 = end - begin;
			label2.Text = dt1.ToString();
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

		/// <summary>
		/// PLC地址值读取(暂放内存)（这里将data由short转成了int）
		/// </summary>
		public void PLCAdressInit()
		{
			//DateTime begin = DateTime.Now;
			//DateTime end1;
			//DateTime end2;
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				string strAddress = "";
				label1.Text = "";
				try
				{
					DateTime begin = DateTime.Now;
					list_plcAdress = (from a in db.TB_PLCBaseAdressInfo
									  select a).ToList();
					DateTime end = DateTime.Now;
					TimeSpan during = end - begin;
					label7.Text = during.ToString();
				}
				catch (Exception ex)
				{
					txt_Exception.AppendText("\n" + DateTime.Now + "PLC地址信息加载失败！");
					LogExecute.WriteDBExceptionLog(ex);
				}
				for (int i = 0; i < list_plcAdress.Count; i++)
				{
					//list_plcAdress[i].TB_PLCAdressWithStopperReference.Load();
					//list_plcAdress[i].TB_SecondWorkStationInfoReference.Load();
					//short a;
					//int b=MasterPLC1.ReadDeviceRandom2(item.Adress, 1, out a);
					//item.Data = a.ToString();
					strAddress = string.Format("{0}\n{1}", strAddress, list_plcAdress[i].Adress);
				}
				//移除最开头的‘\n’
				strAddress = strAddress.Trim('\n');
				short[] plcValue = new short[list_plcAdress.Count];
				//用\n分割地址，count为读取地址数，out short为起始数组地址
				if (MasterPLC1.ReadDeviceRandom2(strAddress, list_plcAdress.Count, out plcValue[0]) == 0)
				{
					for (int i = 0; i < list_plcAdress.Count; i++)
					{
						list_plcAdress[i].Data = plcValue[i];
						//label1.Text += plcValue[i].ToString();
					}
					if (this.p_Main.BackColor != Color.FromArgb(0xEE, 0x4C, 0x56, 0x68))
					{
						this.p_Main.BackColor = Color.FromArgb(0xEE, 0x4C, 0x56, 0x68);
					}
				}
				else
				{
					list_plcAdress = null;
					LogExecute.WriteInfoLog("PLC地址读取", false);
					if (this.p_Main.BackColor != Color.Red)
					{
						this.p_Main.BackColor = Color.Red;
					}
					txt_Exception.AppendText("\n" + DateTime.Now + "PLC地址读取失败！");
				}
				//end1 = DateTime.Now;
				//暂不对PLC地址值进行保存，经测试需要2到3s
				//for (int i = 0; i < list_plcAdress.Count; i++)
				//{
				//    //db.UpdatePLCAdress(list_plcAdress[i].ID, plcValue[i].ToString());
				//    SqlParameter[] parm = new SqlParameter[2];
				//    parm[0] = new SqlParameter("@ID",list_plcAdress[i].ID);
				//    parm[1] = new SqlParameter("@Data", "3");//list_plcAdress[i].Data);
				//    int a = db.ExecuteStoreCommand("exec pro_UpdateTB_PLCBaseAdressInfo @ID,@Data", parm);
				//}
				//db.SaveChanges();
				//end2 = DateTime.Now;
			}
			//DateTime end3 = DateTime.Now;
			//TimeSpan dt1 = end1 - begin;
			//TimeSpan dt2 = end2 - end1;
			//label1.Text = dt1.ToString();
			// label2.Text = dt2.ToString();
		}

		/// <summary>
		/// 阻挡器信息（考虑到上位机可以禁用工位，这里需要迁移详细工位信息初始化）
		/// </summary>
		public void StopperInit()
		{
			string baozhuangduanzudangqi = "GHIJKLMNOP";
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				//list_secStation = (from a in db.TB_SecondWorkStationInfo
				//                   select a).ToList();
				try
				{
					list_stopper = (from b in db.TB_PLCAdressWithStopper
									select b).ToList();
					foreach (var item in list_stopper)
					{
						if (baozhuangduanzudangqi.Contains(item.StopperCode))
						{
							list_Baozhuangduanstopper.Add(item);
						}
					}
				}
				catch (Exception ex)
				{
					list_stopper = null;
					txt_Exception.AppendText("\n" + "信息加载异常，原因可能为网络故障。");
					LogExecute.WriteDBExceptionLog(ex);
				}

				//foreach (var item in list_secStation)
				//{
				//    item.TB_PLCAdressWithWorkStationInfoReference.Load();
				//}
			}
		}

		/// <summary>
		/// 详细工位信息初始化(加载为true的)(注意，这里不是加载所有的，如果访问了没有被加载也就是禁用了的工位，则会报错。)
		/// </summary>
		public void SecondWorkStationInit()
		{
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				try
				{
					list_secStation = (from a in db.TB_SecondWorkStationInfo
									   where a.IsUse == true
									   select a).ToList();

					foreach (var item in list_secStation)
					{
						item.TB_PLCAdressWithWorkStationInfoReference.Load();
					}
				}
				catch (Exception ex)
				{
					list_secStation = null;
					txt_Exception.AppendText("\n" + DateTime.Now + "详细工位信息加载失败！");
					LogExecute.WriteDBExceptionLog(ex);
				}
			}
		}

		/// <summary>
		/// 物料信息初始化
		/// </summary>
		public void MaterialInfoInit()
		{
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				try
				{
					list_materialInfo = (from c in db.TB_MaterialInfo
										 select c).ToList();
					foreach (var item in list_materialInfo)
					{
						item.TB_ProcessRouteMReference.Load();
						item.TB_ProcessRouteM.TB_UserReference.Load();
						//item.TB_ProcessRouteM.TB_ProcessRouteP.Load();
					}
				}
				catch (Exception ex)
				{
					list_materialInfo = null;
					txt_Exception.AppendText("\n" + DateTime.Now + "物料信息加载失败！");
					LogExecute.WriteDBExceptionLog(ex);
				}
			}
		}

		/// <summary>
		/// 包装段每个工位的工序处理，条码扫描，去向(输油泵装配、装齿杆罩帽调度、试高压调度、装底/后盖板/支架调度、试低压调度、装附件、VE泵装附件、外观检查/铅封调度)
		/// 服务端公开方法接口
		/// </summary>
		/// <param name="secondWorkStationCode"></param>
		public void WorkStationManageWithPLCAdress(string secondWorkStationCode)
		{
			//如果两个工位都被禁用了则不会进行这个处理
			if (list_secStation.Count(p => p.SecondWorkStationCode == secondWorkStationCode) > 0)
			{
				//扫描托盘条码，查找工艺路线
				//获取XX工位
				List<TB_SecondWorkStationInfo> baozhuanggongweis = list_secStation.Where(p => p.SecondWorkStationCode == secondWorkStationCode).ToList();
				//循环遍历
				foreach (var item in baozhuanggongweis)
				{
					//条码
					int palletCode = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.PalletCode).Data;
					int toPosition = (int)list_plcAdress.First(p => p.Adress == item.TB_PLCAdressWithWorkStationInfo.ToPositCode).Data;
					//等于零表示没有托盘条码,去向地址==0表示还没有写入
					if (palletCode != 0 && toPosition == 0)
					{
						using (XinYaDBEntities db = new XinYaDBEntities())
						{
							try
							{
								//筛选当前托盘所在任务
								string palletcode = IntToStringfor4Length(palletCode);
								var works = db.TB_WorkMain.First(p => p.PalletCode == palletcode && p.Finished == "0");

								#region 磨合包装到达跟新任务在此工位上的开始时间

								//当这里写入地址的时候，随机在任务工艺路线记录表中写入了下一个工位与此任务的绑定数据
								//所以这个时间在没有更新前既是当前工位任务开始时间也是后一个工位任务的开始时间
								//所以这里更新任务到达这个工位的时间作为这个任务在这个工位上的开始时间，而不是采用上一个工位的开始时间
								//开始时间的更新诺出异常，不应该影响到去向地址的赋值，所以try
								try
								{
									//取出这条记录
									TB_WorkDtlForEachStation a = db.TB_WorkDtlForEachStation.Where(p => p.WorkMainID == works.WorkID && p.SecondWorkStationID == item.ID).OrderByDescending(p => p.ID).First();
									//更新时间
									a.WorkBeginTime = DateTime.Now;
									db.SaveChanges();
								}
								catch (Exception ex)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + "任务" + works.WorkID + " 托盘：" + works.PalletCode + "更新工位" + item.SecondWorkStationName + "到达时间失败！");
									LogExecute.WriteDBExceptionLog(ex);
								}

								#endregion 磨合包装到达跟新任务在此工位上的开始时间

								//是否空盘处理
								//如果他没有子任务或者子任务全部为异常。
								//if (true)
								//{
								//}
								//根据当前任务筛选任务明细表中任务明细，获取物料型号代码
								//可替代的写法
								string modelCode = works.TB_WorkDtl.ToList()[0].MaterialCode.Substring(0, 12);
								//string modelCode = db.TB_WorkDtl.First(m => m.WorkMainID == works.WorkID).MaterialCode.Substring(0, 12);
								//根据型号代码加载工艺路线
								TB_MaterialInfo matertialInfo = list_materialInfo.Single(n => n.TypeCode == modelCode);
								//matrtialInfo.TB_ProcessRouteMReference.Load();
								//获取当前工艺路线
								//可替代写法
								//List<TB_ProcessRouteP> routePs = matertialInfo.TB_ProcessRouteM.TB_ProcessRouteP.ToList();
								List<TB_ProcessRouteP> routePs = (from a in db.TB_ProcessRouteP
																  where a.ProcessRouteM == matertialInfo.TB_ProcessRouteM.ProcessRouteP
																  select a).ToList();
								//查找当前所在工序No
								int no = (int)routePs.Single(p => p.TB_WorkStationInfo.WorkStationCode == item.WorkStationCode).No;
								//检查得到下一个工位No
								//no=from a in routeP
								//   where a.IsUse==true && a.No>no
								//   orderby a.No
								//查找下一个工艺路线
								//现在默认最后一个工序为外观检查 ，这里如果没有去外观价差的则会已发异常
								TB_ProcessRouteP routeP = (TB_ProcessRouteP)routePs.Where(p => p.IsUse == true && p.No > no).OrderBy(p => p.No).Take(1).ToList()[0];
								//获取
								//随机写入下一个工位地址
								//先找出来下一个工位
								List<TB_SecondWorkStationInfo> sec = list_secStation.Where(p => p.WorkStationCode == routeP.TB_WorkStationInfo.WorkStationCode).ToList();
								//随机找出下一个工位，从包装段开始的每个工序均只有两个工位
								//如果只有一个在使用，那么去向地址就写入这个里面(两个都禁用了，则不会写入去向地址。)
								if (sec.Count == 1)
								{
									if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, Convert.ToInt16(sec[0].AdressCode)) != 0)
									{
										txt_Exception.AppendText("\n" + DateTime.Now + sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址中失败！");
										LogExecute.WriteInfoLog(sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址", false);
									}
									else
									{
										//任务路线记录
										WorkRouteRecord(palletcode, sec[0].ID, db);
									}
								}
								else if (sec.Count == 2)//不存在禁用情况，则随机写入
								{
									#region 随机写法

									/*
								//随机找出下一个工位，从包装段开始的每个工序均只有两个工位
								Random random = new Random();
								int r = random.Next(1, 3);
								//取到1放第一个
								//if (r == 1)
								//{
								short j = Convert.ToInt16(sec.First(p => p.No == r).AdressCode);
								if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j) != 0)
								{
									txt_Exception.AppendText("\n" + DateTime.Now + sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址中失败！");
									LogExecute.WriteInfoLog(sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址", false);
								}
								else
								{
									//任务路线记录
									WorkRouteRecork(palletcode, sec.First(p => p.No == r).ID, db);
								}
								//}
								//else if (r == 2)//取第二个工位
								//{
								//    short j = Convert.ToInt16(sec.First(p => p.No == r).AdressCode);
								//    MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j);
								//}
								 * */

									#endregion 随机写法

									#region 0/1写法（需测试）

									int r = 1;//标志位
									if (bool_baozhuang[(int)routeP.No - 7] == true)
									{
										//为true赋值给第一个
										r = 1;
										bool_baozhuang[(int)routeP.No - 7] = false;
									}
									else
									{
										//false赋值给第二个
										r = 2;
										bool_baozhuang[(int)routeP.No - 7] = true;
									}

									short j = Convert.ToInt16(sec.First(p => p.No == r).AdressCode);
									if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, j) != 0)
									{
										txt_Exception.AppendText("\n" + DateTime.Now + sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址中失败！");
										LogExecute.WriteInfoLog(sec[0].SecondWorkStationName + "地址写入到" + item.SecondWorkStationName + "去向地址", false);
									}
									else
									{
										//任务路线记录
										WorkRouteRecord(palletcode, sec.First(p => p.No == r).ID, db);
									}

									#endregion 0/1写法（需测试）
								}
								//如果都被禁用了这里是不能写入地址的，导致的结果就是托盘出不了版
							}
							catch (Exception ex)
							{
								txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "去向地址写入异常！可能原因为该托盘所对应的任务已经完成或者该条任务将要去的工位均被禁用，托盘无法到达。");
								LogExecute.WriteDBExceptionLog(ex);
							}
						}
					}
					else if (palletCode == 0 && toPosition != 0)
					{
						//11.12测试，发现包装段同样出现扫描周期问题，这里做一个修正
						//如果去向地址不为0而托盘号为0，说明有异常。
						//清掉去向地址数据
						if (MasterPLC1.WriteDeviceRandom2(item.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, 0) != 0)
						{
							txt_Exception.AppendText(DateTime.Now + "清理" + item.SecondWorkStationName + "去向地址失败！");
							LogExecute.WriteInfoLog("0地址写入到" + item.SecondWorkStationName + "去向地址", false);
						}
						else
						{
							txt_Exception.AppendText(DateTime.Now + "清理" + item.SecondWorkStationName + "去向地址成功！");
						}
					}
				}
			}
		}

		/// <summary>
		/// 转换扫描头10进制到ASCLL码再到string再到short(经过测试)（未加载系统日志类）
		/// </summary>
		public void PLCASCLLHelper(out string palletCode1, out string palletCode2, out string palletCode3)
		{
			//MessageBox.Show(Convert.ToString(12336, 16));
			//string jinzhigaowei = Convert.ToString(12336, 16);
			//string a = jinzhigaowei.Substring(0, 2);
			//string b = jinzhigaowei.Substring(2, 2);

			#region MyRegion

			string scanAdress = "D920\nD921\nD930\nD931\nD940\nD941";
			string[] scanAdresses = new string[6];
			//short[] plcValue = new short[6]{12336,12336,12336,12336,12336,12336};
			short[] plcValue = new short[6];
			//用\n分割地址，count为读取地址数，out short为起始数组地址
			int c = MasterPLC1.ReadDeviceRandom2(scanAdress, 6, out plcValue[0]);

			for (int i = 0; i < plcValue.Length; i++)
			{
				//转成16进制并以string类型返回
				scanAdresses[i] = Convert.ToString(plcValue[i], 16);
				if (scanAdresses[i] != "0")
				{
					try
					{
						//高低换位
						scanAdresses[i] = GetAscll(scanAdresses[i].Substring(2, 2)) + GetAscll(scanAdresses[i].Substring(0, 2));
					}
					catch (Exception ex)
					{
						//测试阶段，弹窗提示
						//MessageBox.Show("进制转换出现异常！");
						txt_Exception.AppendText("\n" + DateTime.Now + "进制转换出现异常！");
						LogExecute.WriteExceptionLog("进制转换", ex);
					}
				}
			}
			//不等于0表示这个地方固定扫码头一定扫到了托盘条码，存在即写入
			//如果为0则返回0，不作写入
			if (plcValue[0] != 0)
			{
				palletCode1 = scanAdresses[0] + scanAdresses[1];
				MasterPLC1.WriteDeviceRandom2("D301", 1, Convert.ToInt16(palletCode1));
			}
			else
			{
				palletCode1 = "0";
			}
			if (plcValue[2] != 0)
			{
				palletCode2 = scanAdresses[2] + scanAdresses[3];
				int a = MasterPLC1.WriteDeviceRandom2("D401", 1, Convert.ToInt16(palletCode2));
			}
			else
			{
				palletCode2 = "0";
			}
			if (plcValue[4] != 0)
			{
				palletCode3 = scanAdresses[4] + scanAdresses[5];
				MasterPLC1.WriteDeviceRandom2("D801", 1, Convert.ToInt16(palletCode3));
			}
			else
			{
				palletCode3 = "0";
			}

			#endregion MyRegion
		}

		/// <summary>
		/// 16进制转ASCLL码
		/// </summary>
		/// <param name="a"></param>
		/// <returns></returns>
		public string GetAscll(string a)
		{
			switch (a)
			{
				case "30":
					return "0";
				case "31":
					return "1";
				case "32":
					return "2";
				case "33":
					return "3";
				case "34":
					return "4";
				case "35":
					return "5";
				case "36":
					return "6";
				case "37":
					return "7";
				case "38":
					return "8";
				case "39":
					return "9";
				default:
					//不在0-9则抛出异常
					Exception ex = new Exception();
					throw ex;
			}
		}

		/// <summary>
		/// 任务工艺路线记录（未测试）（已测试14.11.8）
		/// </summary>
		/// <param name="palletCode">托盘编码</param>
		/// <param name="secondWorkStaionID">第二工位ID</param>
		/// <param name="db">数据访问上下文</param>
		/// <returns></returns>
		public void WorkRouteRecord(string palletCode, int secondWorkStaionID, XinYaDBEntities db)
		{
			if (db == null)
			{
				using (XinYaDBEntities dbs = new XinYaDBEntities())
				{
					try
					{
						TB_WorkDtlForEachStation a = new TB_WorkDtlForEachStation();
						a.TB_WorkMain = dbs.TB_WorkMain.Single(p => p.PalletCode == palletCode && p.Finished == "0");
						a.TB_SecondWorkStationInfo = dbs.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStaionID);
						a.WorkBeginTime = DateTime.Now;
						dbs.TB_WorkDtlForEachStation.AddObject(a);
						dbs.SaveChanges();
					}
					catch (Exception ex)
					{
						txt_Exception.AppendText("\n" + DateTime.Now + "任务路线记录失败！");
						LogExecute.WriteDBExceptionLog(ex);
					}
				}
			}
			else
			{
				try
				{
					TB_WorkDtlForEachStation a = new TB_WorkDtlForEachStation();
					a.TB_WorkMain = db.TB_WorkMain.Single(p => p.PalletCode == palletCode && p.Finished == "0");
					a.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStaionID);
					a.WorkBeginTime = DateTime.Now;
					db.TB_WorkDtlForEachStation.AddObject(a);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					txt_Exception.AppendText("\n" + DateTime.Now + "任务路线记录失败！");
					LogExecute.WriteDBExceptionLog(ex);
				}
			}
		}

		/// <summary>
		/// 删除托盘对应的第一条工艺路线记录
		/// </summary>
		/// <param name="palletCode"></param>
		/// <param name="db"></param>
		public void DeletFirstRouteRecord(string palletCode, out int workID, out int secondWorkStationID)
		{
			workID = 0;
			secondWorkStationID = 0;
			using (XinYaDBEntities db = new XinYaDBEntities())
			{
				try
				{
					//找到
					var a = db.TB_WorkDtlForEachStation.Where(p => p.TB_WorkMain.PalletCode == palletCode).OrderByDescending(p => p.ID).First();
					//记录下任务号和去向工位ID
					workID = a.TB_WorkMain.WorkID;
					secondWorkStationID = a.TB_SecondWorkStationInfo.ID;
					//删除
					db.TB_WorkDtlForEachStation.DeleteObject(a);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					txt_Exception.AppendText("\n" + DateTime.Now + "删除托盘：" + palletCode + " 任务号：" + workID.ToString() + "对应的工艺路线记录失败。");
					LogExecute.WriteDBExceptionLog(ex);
				}
			}
		}

		#endregion 调度

		#region WCF服务开启与关闭

		/// <summary>
		/// 已由其他程序寄宿
		/// </summary>
		public void WcfServiceOpen()
		{
			//System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(XinYaWcfServiceForPLCAndWorks.Service1));
			//host.Open();
		}

		#endregion WCF服务开启与关闭

		#region 杂项

		private void button1_Click(object sender, EventArgs e)
		{
			PLCAdressInit();
			label1.Text = "";
			foreach (var item in list_plcAdress)
			{
				label1.Text += item.Data;
			}
		}

		/// <summary>
		/// 保存地址值(测试用)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_Save_Tick(object sender, EventArgs e)
		{
			try
			{
				//测试用
				backgroundWorker1.RunWorkerAsync();
			}
			catch { }
		}

		/// <summary>
		/// 测试用
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			DateTime dt1 = DateTime.Now;
			if (list_plcAdress != null)
			{
				using (XinYaDBEntities db = new XinYaDBEntities())
				{
					//foreach (var item in list_plcAdress)
					//{
					//    TB_PLCBaseAdressInfo plc = db.TB_PLCBaseAdressInfo.First(p => p.ID == item.ID);
					//    plc.Data = item.Data;
					//}
					//db.SaveChanges();
					for (int i = 0; i < list_plcAdress.Count; i++)
					{
						if (list_plcAdress[i].Adress.StartsWith("D"))
						{
							//db.UpdatePLCAdress(list_plcAdress[i].ID, plcValue[i].ToString());
							SqlParameter[] parm = new SqlParameter[2];
							parm[0] = new SqlParameter("@ID", list_plcAdress[i].ID);
							parm[1] = new SqlParameter("@Data", list_plcAdress[i].Data);//list_plcAdress[i].Data);
							int a = db.ExecuteStoreCommand("exec pro_UpdateTB_PLCBaseAdressInfo @ID,@Data", parm);
						}
					}
				}
			}
			DateTime dt2 = DateTime.Now;
			TimeSpan s = dt2 - dt1;
			s.ToString();
			Application.DoEvents();
		}

		#endregion 杂项
	}
}