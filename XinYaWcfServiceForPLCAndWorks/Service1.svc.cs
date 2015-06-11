using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;

namespace XinYaWcfServiceForPLCAndWorks
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        #region 字段属性
        //int a = 0;
        //专有通信模块(公开，供向外提供接口时被引用)(需测试构造方法10.5)（构造方法测试失败）
        //public ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
        string plcIPAdress = System.Configuration.ConfigurationSettings.AppSettings["PLCAdress"];

        #endregion 字段属性

        /// <summary>
        ///(已过时) 分流检测、返修工位重新上线的时候，这里需要写入条码（去向地址写入留给主控程序）
        /// </summary>
        /// <param name="workMain"></param>
        /// <param name="workDtls"></param>
        /// <param name="workDtlForEachStation"></param>
        public void WritePLCAdressOnSHSDOld(TB_WorkMain workMain, List<TB_WorkDtl> workDtls, TB_WorkDtlForEachStation workDtlForEachStation)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //首先保存这些任务信息
                //外键处理
                workMain.TB_User = db.TB_User.First(p => p.UserName == workMain.TB_User.UserName);
                //这里其实是找出这个任务的ID，方便保存任务明细
                TB_WorkMain work = (TB_WorkMain)(from a in db.TB_WorkMain
                                                 orderby a.WorkID descending
                                                 select a).First();
                workMain.WorkMainID = work.WorkID + 1;
                db.TB_WorkMain.AddObject(workMain);
                //先将这条主任务保存
                db.SaveChanges();
                //任务明细保存
                foreach (var item in workDtls)
                {
                    //外键处理
                    item.TB_Exception = db.TB_Exception.First(p => p.ID == item.TB_Exception.ID);
                    item.TB_User = db.TB_User.First(p => p.UserName == item.TB_User.UserName);
                    //与主任务表的关联
                    item.WorkMainID = (int)workMain.WorkMainID;
                    db.TB_WorkDtl.AddObject(item);
                    db.SaveChanges();
                }
                //工位任务明细保存,外键处理
                workDtlForEachStation.TB_User = db.TB_User.First(p => p.UserName == workDtlForEachStation.TB_User.UserName);
                workDtlForEachStation.TB_WorkMain = db.TB_WorkMain.First(p => p.WorkID == workMain.WorkMainID);
                workDtlForEachStation.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First(p => p.ID == workDtlForEachStation.TB_SecondWorkStationInfo.ID);
                db.TB_WorkDtlForEachStation.AddObject(workDtlForEachStation);
                db.SaveChanges();

                //----------------------------------------------------------
                //PLC条码写入
                //专有通信模块(公开，供向外提供接口时被引用)(需测试构造方法10.5)（构造方法测试失败）
                ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
                if (MasterPLC.Open() == 0)
                {
                    //获取托盘条码
                    short j = Convert.ToInt16(workMain.PalletCode);
                    //写入
                    MasterPLC.WriteDeviceRandom2(workDtlForEachStation.TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, j);
                    //是否需要手动关闭？（10.4）
                    //---
                }
                else
                {
                }
            }
        }

        /// <summary>
        /// 分流检测和返修工位重新上线的时候，提供接口写入托盘条码到指定地址(装配上线请不要调用此方法)
        /// 1：数据库读取失败
        /// 2：PLC打开失败
        /// 3：条码读取失败
        /// 4：条码写入失败
        /// 5：当前工位已经有条码数据占用
        /// 6：正常结束
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public int WritePLCAdressOnSHSD(int secondWorkStationID, short palletCode)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                TB_SecondWorkStationInfo sec;
                TB_PLCAdressWithStopper stopper;
                try
                {
                    //首先查找这个工位信息
                    sec = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                    sec.TB_PLCAdressWithWorkStationInfoReference.Load();
                    //当分流检测的阻挡位上有托盘地址且地址指向扫描工位，则禁止完成任务。
                    stopper = db.TB_PLCAdressWithStopper.First(p => p.ID == 85);
                }
                catch (Exception ex)
                {
                    //返回1表示数据库读取失败
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), secondWorkStationID.ToString());
                    LogExecute.WriteExceptionLog("WritePLCAdressOnSHSD数据库读取失败", ex);
                    return 1;
                }
                if (sec.WorkStationCode=="H")
                {
                    //检查当前工位上是否还存在托盘条码，存在说明电控数据还没有送出去
                    //PLC IP地址
                    ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
                    MasterPLC.ActHostAddress = plcIPAdress;
                    if (MasterPLC.Open() != 0)
                    {
                        //返回2表示PLC打开失败
                        //SystemLogHelper.WriteSysLogHelper("PLC打开失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC打开",false);
                        return 2;
                    }
                    short stopper_palletCode;
                    short stopper_toposition;
                    if (MasterPLC.ReadDeviceRandom2(stopper.PalletCode, 1, out stopper_palletCode) != 0)
                    {
                        //返回3表示条码读取失败
                        //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC读取", false);
                        return 3;
                    }
                    if (MasterPLC.ReadDeviceRandom2(stopper.ToPositCode, 1, out stopper_toposition) != 0)
                    {
                        //返回3表示条码读取失败
                        //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC读取", false);
                        return 3;
                    }
                    //当分流检测的阻挡位上有托盘地址且地址指向扫描工位，则禁止完成任务。
                    string temp=stopper_toposition.ToString();
                    if (stopper_palletCode!=0&&temp==sec.AdressCode)
                    {
                        //返回7表示地址冲突。
                        return 7;
                    }
                    short palleCode1;
                    if (MasterPLC.ReadDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out palleCode1) != 0)
                    {
                        //返回3表示条码读取失败
                        //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC读取", false);
                        return 3;
                    }
                    //如果没有则写入
                    if (palleCode1 == 0)
                    {
                        if (MasterPLC.WriteDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, palletCode) != 0)
                        {
                            //返回4表示条码写入失败
                            //SystemLogHelper.WriteSysLogHelper("PLC读条码写入失败！", secondWorkStationID.ToString());
                            LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC写入", false);
                            return 4;
                        }
                    }
                    else
                    {
                        //如果有
                        //返回5表示当前工位已经有条码数据占用
                        //SystemLogHelper.WriteSysLogHelper("当前工位条码地址被占用。", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSHSDPLC地址占用", false);
                        return 5;
                    }
                    //关闭连接
                    MasterPLC.Close(); 
                }
            }
            //正常结束
            return 6;
        }

        /// <summary>
        /// 试验台和QC台地址写入。
        /// 返回值：
        /// 1表示数据库读取失败；
        /// 2表示PLC打开失败；
        /// 3表示PLC指定数据读取失败；
        /// 4表示输入了当前并不在该工位上的托盘条码；
        /// 5表示试验台写入失败；
        /// 6表示QC台写入失败；
        /// 7表示一切正常；
        /// </summary>
        /// <param name="workStationID">该工位ID</param>
        /// <param name="palletCode">托盘条码</param>
        /// <param name="exception">异常信息</param>
        public int WritePLCAdressOnSESF(int secondWorkStationID, short palletCode, bool exception)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //首先根据工位ID查找这个工位的详细信息
                #region 读取数据库中的对应工位

                TB_SecondWorkStationInfo sec;
                try
                {
                    sec = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                    sec.TB_PLCAdressWithWorkStationInfoReference.Load();
                }
                catch (Exception ex)
                {
                    //返回1表示数据库读取失败
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), secondWorkStationID.ToString());
                    LogExecute.WriteExceptionLog("WritePLCAdressOnSESF数据库读取", ex);
                    return 1;
                }

                #endregion 读取数据库中的对应工位
                //通过PLC读取该工位所有条码数据
                //PLC IP地址
                ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
                MasterPLC.ActHostAddress = plcIPAdress;
                if (MasterPLC.Open() != 0)
                {
                    //返回2表示PLC打开失败
                    //SystemLogHelper.WriteSysLogHelper("PLC打开失败！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESFPLC打开失败", false);
                    return 2;
                }
                short palletCode1;
                int a = MasterPLC.ReadDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out palletCode1);
                short palletCode2;
                int b = MasterPLC.ReadDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode2, 1, out palletCode2);
                if (a != 0 || b != 0)
                {
                    //返回3表示PLC指定数据读取失败
                    //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESFPLC读取失败", false);
                    return 3;
                }

                //通过比对条码编码找到对应条码地址
                string toPosition = "";
                if (palletCode1 == palletCode)
                {
                    toPosition = sec.TB_PLCAdressWithWorkStationInfo.ToPositCode;
                }
                if (palletCode2 == palletCode)
                {
                    toPosition = sec.TB_PLCAdressWithWorkStationInfo.ToPositCode2;
                }
                //没有找到对应条码（严重错误，或，或者员工输入了与实际托盘不匹配的托盘条码）
                if (toPosition == "")
                {
                    //输入了当前并不在该工位上的托盘条码
                    //SystemLogHelper.WriteSysLogHelper("未找到" + palletCode.ToString() + "托盘条码！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESF未找到"+palletCode.ToString()+"托盘条码", false);
                    return 4;
                }
                //修改该条码地址所对应的去向地址（QC台、异常状态）
                //判断是试验台(E)还是QC台(F)
                if (sec.WorkStationCode == "E")
                {
                    //试验台出来的写1
                    if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 1) != 0)
                    {
                        //试验台写入失败则返回5
                        //SystemLogHelper.WriteSysLogHelper("试验台地址写入失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSESFPLC试验台地址写入"+secondWorkStationID.ToString(), false);
                        return 5;
                    }
                }
                else if (sec.WorkStationCode == "F")
                {
                    //判断质检状态
                    if (exception)
                    {
                        //有异常的暂写入3
                        if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 3) != 0)
                        {
                            //QC台写入失败则写入6
                            //SystemLogHelper.WriteSysLogHelper("QC台不合格地址写入失败！", secondWorkStationID.ToString());
                            LogExecute.WriteInfoLog("WritePLCAdressOnSESFPLCQC台不合格地址写入失败！"+secondWorkStationID.ToString(), false);
                            return 6;
                        }
                    }
                    else
                    {
                        //没异常的暂写入2
                        if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 2) != 0)
                        {
                            //QC台写入失败则写入6
                            //SystemLogHelper.WriteSysLogHelper("QC台合格地址写入失败！", secondWorkStationID.ToString());
                            LogExecute.WriteInfoLog("WritePLCAdressOnSESFPLCQC台合格地址写入失败" + secondWorkStationID.ToString(), false);
                            return 6;
                        }
                    }
                }
                //关闭连接
                MasterPLC.Close();
            }
            //一切正常返回7
            return 7;
        }

        /// <summary>
        /// 虚拟QC台去向地址写入支持
        /// 1表示数据库读取失败；
        /// 2表示PLC打开失败；
        /// 3表示PLC指定数据读取失败；
        /// 4表示输入了当前并不在该工位上的托盘条码；
        /// 6表示QC台写入失败；
        /// 7表示一切正常；
        /// </summary>
        /// <param name="secondWorkStationID">实际工位ID</param>
        /// <param name="pallet">托盘号</param>
        /// <param name="exception">是否QC合格</param>
        /// <returns></returns>
        public int WritePLCAdressOnSESFForVisualQCStation(int secondWorkStationID, short palletCode, bool exception)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //首先根据工位ID查找这个工位的详细信息
                #region 读取数据库中的对应工位

                TB_SecondWorkStationInfo sec;
                try
                {
                    sec = db.TB_SecondWorkStationInfo.First(p => p.ID == secondWorkStationID);
                    sec.TB_PLCAdressWithWorkStationInfoReference.Load();
                }
                catch (Exception ex)
                {
                    //返回1表示数据库读取失败
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), secondWorkStationID.ToString());
                    LogExecute.WriteExceptionLog("WritePLCAdressOnSESFForVisualQCStation数据库读取失败", ex);
                    return 1;
                }

                #endregion 读取数据库中的对应工位
                //通过PLC读取该工位所有条码数据
                //PLC IP地址
                ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
                MasterPLC.ActHostAddress = plcIPAdress;
                if (MasterPLC.Open() != 0)
                {
                    //返回2表示PLC打开失败
                    //SystemLogHelper.WriteSysLogHelper("PLC打开失败！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESFForVisualQCStationPLC打开失败"+secondWorkStationID.ToString(), false);
                    return 2;
                }
                short palletCode1;
                int a = MasterPLC.ReadDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out palletCode1);
                short palletCode2;
                int b = MasterPLC.ReadDeviceRandom2(sec.TB_PLCAdressWithWorkStationInfo.PalletCode2, 1, out palletCode2);
                if (a != 0 || b != 0)
                {
                    //返回3表示PLC指定数据读取失败
                    //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESFForVisualQCStationPLC读取失败" + secondWorkStationID.ToString(), false);
                    return 3;
                }

                //通过比对条码编码找到对应条码地址
                string toPosition = "";
                if (palletCode1 == palletCode)
                {
                    toPosition = sec.TB_PLCAdressWithWorkStationInfo.ToPositCode;
                }
                if (palletCode2 == palletCode)
                {
                    toPosition = sec.TB_PLCAdressWithWorkStationInfo.ToPositCode2;
                }
                //没有找到对应条码（严重错误，或，或者员工输入了与实际托盘不匹配的托盘条码）
                if (toPosition == "")
                {
                    //输入了当前并不在该工位上的托盘条码
                    //SystemLogHelper.WriteSysLogHelper("未找到" + palletCode.ToString() + "托盘条码！", secondWorkStationID.ToString());
                    LogExecute.WriteInfoLog("WritePLCAdressOnSESFForVisualQCStationPLC未找到"+palletCode.ToString()+"托盘条码。" + secondWorkStationID.ToString(), false);
                    return 4;
                }
                //对于虚拟QC位，不需要考虑写1的问题
                //修改该条码地址所对应的去向地址（QC台、异常状态）
                //判断是试验台(E)还是QC台(F)
                //if (sec.WorkStationCode == "E")
                //{
                //    //试验台出来的写1
                //    if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 1) != 0)
                //    {
                //        //试验台写入失败则返回5
                //        SystemLogHelper.WriteSysLogHelper("试验台地址写入失败！", secondWorkStationID.ToString());
                //        return 5;
                //    }
                //}
                //else if (sec.WorkStationCode == "F")
                //{
                //判断质检状态
                if (exception)
                {
                    //有异常的暂写入3
                    if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 3) != 0)
                    {
                        //QC台写入失败则写入6
                        //SystemLogHelper.WriteSysLogHelper("QC台不合格地址写入失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSESFForVisualQCStationPLC不合格写入失败" + secondWorkStationID.ToString(), false);
                        return 6;
                    }
                }
                else
                {
                    //没异常的暂写入2
                    if (MasterPLC.WriteDeviceRandom2(toPosition, 1, 2) != 0)
                    {
                        //QC台写入失败则写入6
                        //SystemLogHelper.WriteSysLogHelper("QC台合格地址写入失败！", secondWorkStationID.ToString());
                        LogExecute.WriteInfoLog("WritePLCAdressOnSESFForVisualQCStationPLC合格写入失败" + secondWorkStationID.ToString(), false);
                        return 6;
                    }
                }
                //}
                //关闭连接
                MasterPLC.Close();
            }
            //一切正常返回7
            return 7;
        }

        /// <summary>
        /// 返回所有PLC地址和值，失败返回null
        /// </summary>
        /// <returns></returns>
        public List<TB_PLCBaseAdressInfo> GetAllPLCAdressData()
        {
            List<TB_PLCBaseAdressInfo> list_plcAdress = new List<TB_PLCBaseAdressInfo>();

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                string strAddress = "";
                try
                {
                    list_plcAdress = (from a in db.TB_PLCBaseAdressInfo
                                      select a).ToList();
                }
                catch (Exception ex)
                {
                    db.Dispose();
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), "WCF服务、ECS");
                    LogExecute.WriteExceptionLog("GetAllPLCAdressData数据库访问失败", ex);
                    return null;
                }
                ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
                MasterPLC.ActHostAddress = plcIPAdress;
                //打开
                if (MasterPLC.Open() != 0)
                {
                    db.Dispose();
                    //SystemLogHelper.WriteSysLogHelper("PLC打开失败！", "WCF服务、ECS");
                    LogExecute.WriteInfoLog("GetAllPLCAdressDataPLC打开失败", false);
                    return null;
                }

                for (int i = 0; i < list_plcAdress.Count; i++)
                {
                    strAddress = string.Format("{0}\n{1}", strAddress, list_plcAdress[i].Adress);
                }

                //移除最开头的‘\n’
                strAddress = strAddress.Trim('\n');
                short[] plcValue = new short[list_plcAdress.Count];
                //用\n分割地址，count为读取地址数，out short为起始数组地址
                int b = MasterPLC.ReadDeviceRandom2(strAddress, list_plcAdress.Count, out plcValue[0]);

                //关闭PLC
                MasterPLC.Close();
                //不等于表示读取失败
                if (b != 0)
                {
                    db.Dispose();
                    //SystemLogHelper.WriteSysLogHelper("PLC读取失败！", "WCF服务、ECS");
                    LogExecute.WriteInfoLog("GetAllPLCAdressDataPLC读取失败", false);
                    return null;
                }
                for (int i = 0; i < list_plcAdress.Count; i++)
                {
                    list_plcAdress[i].Data = plcValue[i];
                    try//有些可能没有阻挡外键或工位外键
                    {
                        //加载完全
                        list_plcAdress[i].TB_PLCAdressWithStopperReference.Load();
                        list_plcAdress[i].TB_SecondWorkStationInfoReference.Load();
                        //10.17新加入
                        list_plcAdress[i].TB_SecondWorkStationInfo.TB_PLCAdressWithWorkStationInfoReference.Load();
                        //测试
                        //list_plcAdress.Remove(list_plcAdress[list_plcAdress.Count - i]);
                    }
                    catch { }
                }
            }

            #region MyRegion
            //测试
            //BinaryFormatter bf = new BinaryFormatter();

            //TB_PLCBaseAdressInfo a1 = new TB_PLCBaseAdressInfo();
            //TB_PLCBaseAdressInfo a2 = new TB_PLCBaseAdressInfo();
            //TB_PLCBaseAdressInfo a3 = new TB_PLCBaseAdressInfo();
            //TB_PLCBaseAdressInfo a4 = new TB_PLCBaseAdressInfo();
            //a1.Adress = "1";
            //a1.Data = 2;
            //a2.Adress = "1";
            //a2.Data = 2;
            //a3.Adress = "1";
            //a3.Data = 2;
            //a4.Adress = "1";
            //a4.Data = 2;
            //list_plcAdress.Add(a1);
            //list_plcAdress.Add(a2);
            //list_plcAdress.Add(a3);
            //list_plcAdress.Add(a4);
            //using (XinYaDBEntities db = new XinYaDBEntities())
            //{
            //    for (int i = 0; i <1000; i++)
            //    {
            //        TB_PLCBaseAdressInfo a1 = new TB_PLCBaseAdressInfo();
            //        a1.Adress = i.ToString();
            //        a1.Data = i;

            //        a1.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.First();
            //        a1.TB_SecondWorkStationInfoReference.Load();
            //        list_plcAdress.Add(a1);
            //    }
            //}

            //list_plcAdress = list_plcAdress.Where(p => p.Adress.StartsWith("D")).ToList();

            //list_plcAdress = list_plcAdress.Take(10).ToList();

            #endregion

            return list_plcAdress;
        }

        /// <summary>
        /// 根据特定的第二工位ID，返回正在该工位上的PLC实际地址中的托盘号
        /// 并扩展至4位
        /// 如果当前没有，返回null;读取失败，string[]为0，没有托盘编码为0000
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <returns></returns>
        public string[] GetPalletCodesBySecondWorkStationID(int secondWorkStationID)
        {
            //两个托盘地址
            string[] palletCodes = { "0", "0" };
            //PLC地址
            ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
            MasterPLC.ActHostAddress = plcIPAdress;
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //Thread.Sleep(1000);
                    //首先找到这个工位
                    TB_SecondWorkStationInfo secondWorkStation = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                    secondWorkStation.TB_PLCAdressWithWorkStationInfoReference.Load();
                    //打开连接
                    if (MasterPLC.Open() != 0)
                    {
                        //SystemLogHelper.WriteSysLogHelper("打开PLC失败", "工位ID" + secondWorkStationID.ToString() + "WCF");
                        LogExecute.WriteInfoLog("GetPalletCodesBySecondWorkStationIDPLC打开失败", false);
                        return null;
                    }
                    else//成功
                    {
                        //判断是不是调试QC
                        //调试QC有两个托盘地址
                        if (secondWorkStation.WorkStationCode == "E" || secondWorkStation.WorkStationCode == "F")
                        {
                            short a1;
                            short a2;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out a1) == 0)
                            {
                                if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, out a2) == 0)
                                {
                                    if (a2 == 0)//等于0表示还未完成
                                    {
                                        palletCodes[0] = IntToStringfor4Length(a1);
                                    }
                                    else//去向地址不为0，表示上位机已经写入了去向地址，再次扫描到的时候跳过，即不再做第二次加载
                                    {
                                        palletCodes[0] = "0000";
                                    }
                                }
                            }
                            short b1;
                            short b2;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode2, 1, out b1) == 0)
                            {
                                if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.ToPositCode2, 1, out b2) == 0)
                                {
                                    if (b2 == 0)//等于0表示还未完成
                                    {
                                        palletCodes[1] = IntToStringfor4Length(b1);
                                    }
                                    else//去向地址不为0，表示上位机已经写入了去向地址，再次扫描到的时候跳过，即不再做第二次加载
                                    {
                                        palletCodes[1] = "0000";
                                    }
                                }
                            }
                            MasterPLC.Close();
                            return palletCodes;
                        }
                        else//非调试QC，一个地址.对于非调试QC，托盘到达后随即写入去向地址，所以这里不能按照去向地址返回托盘编码。返回托盘编码，判断交给下位PC端。
                        {
                            short a1;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out a1) == 0)
                            {
                                palletCodes[0] = IntToStringfor4Length(a1);
                            }
                            MasterPLC.Close();
                            return palletCodes;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //palletCodes[0] = (++a).ToString();
                    //return palletCodes;
                    //SystemLogHelper.WriteSysLogHelper("获取工位到达托盘信息失败！详细信息：" + ex.ToString(), "工位ID" + secondWorkStationID.ToString() + "WCF");
                    LogExecute.WriteExceptionLog("GetPalletCodesBySecondWorkStationID获取工位到达托盘信息失败，工位" + secondWorkStationID.ToString(), ex);
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据特定的第二工位ID，返回正在该工位上的PLC实际地址中的托盘号，要求改托盘号对应任务已经完成，即去向地址为1
        /// 并扩展至4位
        /// 如果当前没有，返回null;读取失败，string[]为0，没有托盘编码为0000
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <returns></returns>
        public string[] GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation(int secondWorkStationID)
        {
            //两个托盘地址
            string[] palletCodes = { "0", "0" };
            //PLC地址
            ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
            MasterPLC.ActHostAddress = plcIPAdress;
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //Thread.Sleep(1000);
                    //首先找到这个工位
                    TB_SecondWorkStationInfo secondWorkStation = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                    secondWorkStation.TB_PLCAdressWithWorkStationInfoReference.Load();
                    //打开连接
                    if (MasterPLC.Open() != 0)
                    {
                        //SystemLogHelper.WriteSysLogHelper("打开PLC失败", "工位ID" + secondWorkStationID.ToString() + "WCF");
                        LogExecute.WriteInfoLog("GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation打开PLC失败，工位" + secondWorkStationID.ToString(), false);
                        return null;
                    }
                    else//成功
                    {
                        //判断是不是调试QC
                        //调试QC有两个托盘地址
                        if (secondWorkStation.WorkStationCode == "E" || secondWorkStation.WorkStationCode == "F")
                        {
                            short a1;
                            short a2;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out a1) == 0)
                            {
                                if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, out a2) == 0)
                                {
                                    if (a2 == 1)//等于1表示已经完成
                                    {
                                        palletCodes[0] = IntToStringfor4Length(a1);
                                    }
                                    else//去向地址不为1，表示正在调试或者没有托盘，作没有托盘处理
                                    {
                                        palletCodes[0] = "0000";
                                    }
                                }
                            }
                            short b1;
                            short b2;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode2, 1, out b1) == 0)
                            {
                                if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.ToPositCode2, 1, out b2) == 0)
                                {
                                    if (b2 == 1)//等于1表示已经完成
                                    {
                                        palletCodes[1] = IntToStringfor4Length(b1);
                                    }
                                    else//去向地址不为1，表示正在调试或者没有托盘，作没有托盘处理
                                    {
                                        palletCodes[1] = "0000";
                                    }
                                }
                            }
                            MasterPLC.Close();
                            return palletCodes;
                        }
                        //虚拟QC中，这一段使用不到
                        else//非调试QC，一个地址.对于非调试QC，托盘到达后随即写入去向地址，所以这里不能按照去向地址返回托盘编码。返回托盘编码，判断交给下位PC端。
                        {
                            short a1;
                            if (MasterPLC.ReadDeviceRandom2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, out a1) == 0)
                            {
                                palletCodes[0] = IntToStringfor4Length(a1);
                            }
                            MasterPLC.Close();
                            return palletCodes;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //palletCodes[0] = (++a).ToString();
                    //return palletCodes;
                    //SystemLogHelper.WriteSysLogHelper("获取工位到达托盘信息失败！详细信息：" + ex.ToString(), "工位ID" + secondWorkStationID.ToString() + "WCF");
                    LogExecute.WriteExceptionLog("GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation获取工位到达托盘信息失败，工位" + secondWorkStationID.ToString(), ex);
                    return null;
                }
            }
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
        /// PLC读写测试,true为写
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public int PLCReadAndWriteTest(string address, short value, bool flag)
        {
            ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
            MasterPLC.ActHostAddress = "192.168.1.5";
            if (flag)
            {
                MasterPLC.Open();
                int a = MasterPLC.WriteDeviceRandom2(address, 1, value);
                MasterPLC.Close();
                return a;
            }
            else
            {
                short a;
                MasterPLC.Open();
                int b = MasterPLC.ReadDeviceRandom2(address, 1, out a);
                MasterPLC.Close();
                return a;
            }
        }

        /// <summary>
        /// 完成任务
        /// 0 该工位没有完成任务的权限
        /// 1 成功
        /// 2 失败，PLC写值失败
        /// 3 失败，PLC打开失败
        /// 4 失败，异常引发
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        public int WorkTaskComplete(int secondWorkStationID, string palletCode, int userID)
        {
            //首先得验证下该工位是否有完成任务的权限（是否放到客户端还是？）
            //为统一修改写入服务端
            //ACTETHERLib.ActQJ71E71TCP MasterPLC = new ACTETHERLib.ActQJ71E71TCP();
            //MasterPLC.ActHostAddress = plcIPAdress;
            //打开成功
            //if (MasterPLC.Open() == 0)
            //{
                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //工位完成权限判断
                        var secondWorkStation = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                        secondWorkStation.TB_PLCAdressWithWorkStationInfoReference.Load();
                        //如果为外观检查，则进入完成处理
                        if (secondWorkStation.WorkStationCode == "P")
                        {
                            ////筛选当前托盘所在任务
                            //var works = db.TB_WorkMain.First(p => p.PalletCode == palletCode && p.Finished == "0");
                            ////这是最后一个工位，没有再写入去向地址而是将这个主任务结束掉
                            //works.Finished = "1";
                            //works.TB_User1 = db.TB_User.Single(p => p.ID == userID);
                            ////完成时间
                            //works.FinishedDate = DateTime.Now;
                            ////任务结束类型为自动
                            //works.FinishedType = "下位PC机" + secondWorkStation.SecondWorkStationName;
                            //db.SaveChanges();
                            //同时清理掉这个上面托盘编码和去向地址
                            //if (MasterPLC.WriteDeviceBlock2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.PalletCode, 1, 0) == 0)
                            //{
                            //    if (MasterPLC.WriteDeviceBlock2(secondWorkStation.TB_PLCAdressWithWorkStationInfo.ToPositCode, 1, 0) == 0)
                            //    {
                                    //清掉地址后才进行完成处理
                                    //筛选当前托盘所在任务
                                    var works = db.TB_WorkMain.First(p => p.PalletCode == palletCode && p.Finished == "0");
                                    //这是最后一个工位，没有再写入去向地址而是将这个主任务结束掉
                                    works.Finished = "1";
                                    works.TB_User1 = db.TB_User.Single(p => p.ID == userID);
                                    //完成时间
                                    works.FinishedDate = DateTime.Now;
                                    //任务结束类型为自动
                                    works.FinishedType = "下位PC机" + secondWorkStation.SecondWorkStationName;
                                    db.SaveChanges();
                                    //MasterPLC.Close();
                                    return 1;
                            //    }
                            //    else
                            //    {
                            //        MasterPLC.Close();
                            //        SystemLogHelper.WriteSysLogHelper("PC端完成任务失败！详细信息：PLC地址写入失败", "工位ID" + secondWorkStationID.ToString() + "WCF");
                            //        return 2;
                            //    }
                            //}
                            //else
                            //{
                            //    MasterPLC.Close();
                            //    SystemLogHelper.WriteSysLogHelper("PC端完成任务失败！详细信息：PLC地址写入失败", "工位ID" + secondWorkStationID.ToString() + "WCF");
                            //    return 2;
                            //}
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        //txt_Exception.AppendText("\n" + DateTime.Now + item.SecondWorkStationName + "处自动结束任务异常！");
                        //SystemLogHelper.WriteSysLogHelper("PC端完成任务失败！详细信息：" + ex.ToString(), userID, "工位ID" + secondWorkStationID.ToString() + "WCF");
                        LogExecute.WriteExceptionLog("WorkTaskCompletePC端完成任务失败,工位：" + secondWorkStationID.ToString(), ex);
                        return 4;
                    }
                }
            //}
            //else
            //{
            //    return 3;
            //}
        }

        /// <summary>
        /// 工时绑定，提供给下位机循环调用，班组长只能绑定今日的工时信息
        /// </summary>
        /// <param name="secondWorkStationID">工位ID</param>
        /// <param name="userID">工号</param>
        /// <returns></returns>
        public bool WorkTimeBanding(int secondWorkStationID, string userID, int recorderID)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //先筛选这个工位上的任务工艺记录
                    var works = db.TB_WorkDtlForEachStation.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID);
                    foreach (var item in works)
                    {
                        if (item.WorkBeginTime != null && item.WorkBeginTime.Value.Date == DateTime.Now.Date)
                        {
                            //如果是今天的,则将其与该员工绑定
                            item.TB_User = db.TB_User.Single(p => p.UserID == userID);
                        }
                    }
                    db.SaveChanges();
                    //这里记录下绑定信息
                    //首先确认今天这个工位有没有此类信息
                    var list_WorkTimeBandingInfo = db.TB_WorkTimeBandingInfo.Where(p => p.TB_SecondWorkStationInfo.ID == secondWorkStationID).ToList();
                    if (list_WorkTimeBandingInfo.Count(p => p.Date.Date == DateTime.Now.Date) == 0)
                    {
                        //等于0表示今天还没有绑定信息，新增
                        TB_WorkTimeBandingInfo workTimeBandingInfo = new TB_WorkTimeBandingInfo();
                        workTimeBandingInfo.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == recorderID);
                        workTimeBandingInfo.Date = DateTime.Now;
                        db.AddToTB_WorkTimeBandingInfo(workTimeBandingInfo);
                        db.SaveChanges();
                    }
                    else
                    {
                        //不等于0表示今天已经有过绑定信息，更新
                        TB_WorkTimeBandingInfo workTimeBandingInfo = list_WorkTimeBandingInfo.Single(p => p.Date.Date == DateTime.Now.Date);
                        workTimeBandingInfo.TB_User = db.TB_User.Single(p => p.UserID == userID);
                        workTimeBandingInfo.TB_User1 = db.TB_User.Single(p => p.ID == recorderID);
                        workTimeBandingInfo.Date = DateTime.Now;
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    //SystemLogHelper.WriteSysLogHelper("工时统计绑定员工工作信息！详细信息：" + ex.ToString(), "工时统计PC端,WCF");
                    LogExecute.WriteExceptionLog("WorkTimeBanding工时统计绑定员工工作信息出错", ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 返回系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeNow()
        {
            return DateTime.Now;
        }

        #region 登录支持

        /// <summary>
        /// PC端登录支持,需要传工位ID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>0，账户被禁用；1，管理员权限，班组长权限，正常登录；2，员工账户正常登录；3，员工账户权限不足；4.员工账户或密码不正确，或不存在这个账户；5，该工位已被禁用；6，客户端配置文件出错，传递的参数异常，未找到对应工位</returns>
        public int LoginHelpForPCClient(string userID, string password, int secondWorkStationID)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //检查该工位是否被禁用，如果禁用，禁止登录
                    try
                    {
                        var sec = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                        if (sec.IsUse == false)
                        {
                            return 5;
                        }
                    }
                    catch (Exception ex)
                    {
                        //SystemLogHelper.WriteSysLogHelper(secondWorkStationID.ToString() + ex.ToString(), "服务端");
                        LogExecute.WriteExceptionLog("LoginHelpForPCClient数据访问失败", ex);
                        return 6;
                    }
                    TB_User user = db.TB_User.Single(p => p.UserID == userID && p.Password == password);
                    //检查是否被禁用
                    if (user.IsUse != true)
                    {
                        return 0;
                    }
                    else
                    {
                        //对于上位程序，必须 是管理员才有权限
                        //此为下位机程序
                        //管理员或者班组长可以直接登录
                        if (user.UserLevel == "管理员" || user.UserLevel == "班组长")
                        {
                            #region 登录记录

                            LoginInRecord(user, secondWorkStationID, "");

                            #endregion
                            return 1;
                        }
                        else
                        {
                            //检查登录权限,遍历匹配
                            user.TB_UserLoginRight.Load();
                            if (user.TB_UserLoginRight.Count != 0)
                            {
                                foreach (var item in user.TB_UserLoginRight)
                                {
                                    item.TB_SecondWorkStationInfoReference.Load();
                                    if (item.IsUse != null)
                                    {
                                        //如果有,而且被启用
                                        if (item.TB_SecondWorkStationInfo.ID == secondWorkStationID && (bool)item.IsUse == true)
                                        {
                                            #region 登录记录

                                            LoginInRecord(user, secondWorkStationID, "");

                                            #endregion

                                            return 2;
                                        }
                                    }
                                }
                                return 3;
                            }
                            else
                            {
                                return 3;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogExecute.WriteInfoLog("PC端登录失败，详情" + ex.ToString(), false);
                    //SystemLogHelper.WriteSysLogHelper(ex.ToString(), "服务端");
                    return 4;
                }
            }
        }

        /// <summary>
        /// 服务端登录支持
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>0,账号被禁用；1，非管理员或ERP，权限不足；2，正常通过；3，账号或密码不对，或不存在此账户信息</returns>
        public int LoginHelpForService(string userID, string password, string serviceName)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    TB_User user = db.TB_User.Single(p => p.UserID == userID && p.Password == password);
                    //检查是否被禁用
                    if (user.IsUse != true)
                    {
                        return 0;
                    }
                    else
                    {
                        //对于上位程序，必须是管理员或ERP才有权限
                        //此为上位程序
                        if (!(user.UserLevel == "管理员" || user.UserLevel == "ERP"))
                        {
                            return 1;
                        }
                        else
                        {
                            #region 登录记录

                            LoginInRecord(user, 0, serviceName);


                            #endregion

                            return 2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogExecute.WriteInfoLog("服务端登录失败，详情" + ex.ToString(), false);
                    return 3;
                }
            }
        }

        /// <summary>
        /// 工时辅助程序登录支持，支持班组长和管理员登录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>0,账号被禁用；1，非管理员或班组长，权限不足；2，正常通过；3，账号或密码不对，或不存在此账户信息</returns>
        public int LoginHelpForWorkTimeHelp(string userID, string password)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    TB_User user = db.TB_User.Single(p => p.UserID == userID && p.Password == password);
                    //检查是否被禁用
                    if (user.IsUse != true)
                    {
                        return 0;
                    }
                    else
                    {
                        //对于工时辅助程序，必须是管理员或ERP才有权限
                        //此为上位程序
                        if (!(user.UserLevel == "管理员" || user.UserLevel == "班组长"))
                        {
                            return 1;
                        }
                        else
                        {
                            #region 登录记录
                            LoginInRecord(user, 0, "工时辅助程序");
                            #endregion

                            return 2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogExecute.WriteInfoLog("工时辅助程序登录失败，详情" + ex.ToString(), false);
                    return 3;
                }
            }
        }

        /// <summary>
        /// 供内部调用记录登录in信息,如果是上位机，工位ID请用0代替；如果是PC端，服务端名称请用“”代替.这里不对重复登录进行更新，只记录，登录一次就记录一次。
        /// </summary>
        /// <param name="userForRecord"></param>
        /// <param name="secondWorkStationIDForRecord"></param>
        /// <param name="serviceName"></param>
        public int LoginInRecord(TB_User userForRecord, int secondWorkStationIDForRecord, string serviceName)
        {
            if (secondWorkStationIDForRecord != 0 || serviceName != "")
            {
                if (secondWorkStationIDForRecord == 0)
                {
                    //服务端登录记录
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            TB_LoginRecord loginRecord = new TB_LoginRecord();
                            loginRecord.TB_User = db.TB_User.Single(p => p.ID == userForRecord.ID);
                            loginRecord.ServicePosition = serviceName;
                            loginRecord.LoginInTime = DateTime.Now;
                            db.TB_LoginRecord.AddObject(loginRecord);
                            db.SaveChanges();
                            return 1;
                        }
                        catch (Exception ex)
                        {
                            LogExecute.WriteInfoLog("服务端登录失败，详情" + ex.ToString(), false);
                            return 0;
                        }
                    }
                }
                else if (serviceName == "")
                {
                    //客户端登录记录
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            TB_LoginRecord loginRecord = new TB_LoginRecord();
                            loginRecord.TB_User = db.TB_User.Single(p => p.ID == userForRecord.ID);
                            loginRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationIDForRecord);
                            loginRecord.LoginInTime = DateTime.Now;
                            db.TB_LoginRecord.AddObject(loginRecord);
                            db.SaveChanges();
                            return 1;
                        }
                        catch (Exception ex)
                        {
                            LogExecute.WriteInfoLog("服务端登录失败，详情" + ex.ToString(), false);
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 登录登出支持，服务端，secondWorkStationID=0；客户端，serviceName=""
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="secondWorkStationID"></param>
        /// <param name="serviceName"></param>
        /// <returns>0，服务端登出记录成功；1，服务端登录记录失败；2，客户端登出记录成功；3，客户端登出记录失败；4,5：没有执行登出记录，传递参数出错。</returns>
        public int LoginHelpForLoginOut(int userID, int secondWorkStationID, string serviceName)
        {
            if (secondWorkStationID != 0 || serviceName != "")
            {
                if (secondWorkStationID == 0)
                {
                    //服务端登出记录
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            TB_LoginRecord loginRecord = new TB_LoginRecord();
                            loginRecord.TB_User = db.TB_User.Single(p => p.ID == userID);
                            loginRecord.ServicePosition = serviceName;
                            loginRecord.LoginOutTime = DateTime.Now;
                            db.TB_LoginRecord.AddObject(loginRecord);
                            db.SaveChanges();
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            LogExecute.WriteInfoLog("服务端登出失败，详情" + ex.ToString(), false);
                            return 1;
                        }
                    }
                }
                else if (serviceName == "")
                {
                    //客户端登出记录
                    using (XinYaDBEntities db = new XinYaDBEntities())
                    {
                        try
                        {
                            TB_LoginRecord loginRecord = new TB_LoginRecord();
                            loginRecord.TB_User = db.TB_User.Single(p => p.ID == userID);
                            loginRecord.TB_SecondWorkStationInfo = db.TB_SecondWorkStationInfo.Single(p => p.ID == secondWorkStationID);
                            loginRecord.LoginOutTime = DateTime.Now;
                            db.TB_LoginRecord.AddObject(loginRecord);
                            db.SaveChanges();
                            return 2;
                        }
                        catch (Exception ex)
                        {
                            LogExecute.WriteInfoLog("服务端登出失败，详情" + ex.ToString(), false);
                            return 3;
                        }
                    }
                }
                else
                {
                    return 4;
                }
            }
            else
            {
                return 5;
            }
        }

        #endregion

    }
}