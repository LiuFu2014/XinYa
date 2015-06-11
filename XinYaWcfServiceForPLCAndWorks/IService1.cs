using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XinYaWcfServiceForPLCAndWorks
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// (已过时)分流检测、返修工位重新上线的时候，这里需要写入条码和去向地址
        /// </summary>
        /// <param name="workMain"></param>
        /// <param name="workDtls"></param>
        /// <param name="workDtlForEachStation"></param>
        [OperationContract]
        void WritePLCAdressOnSHSDOld(TB_WorkMain workMain, List<TB_WorkDtl> workDtls, TB_WorkDtlForEachStation workDtlForEachStation);

        /// <summary>
        /// 分流检测和返修工位重新上线的时候，提供接口写入托盘条码到指定地址
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <param name="palletCode"></param>
        [OperationContract]
        int WritePLCAdressOnSHSD(int secondWorkStationID, short palletCode);


        /// <summary>
        /// 试验台和QC台服务端调用,写入去向地址
        /// </summary>
        /// <param name="secondworkStationID"></param>
        /// <param name="palletCode"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        [OperationContract]
        int WritePLCAdressOnSESF(int secondWorkStationID, short palletCode, bool exception);

        /// <summary>
        /// 虚拟QC台去向地址写入支持
        /// </summary>
        /// <param name="secondWorkStationID">实际工位ID</param>
        /// <param name="pallet">托盘号</param>
        /// <param name="exception">是否QC合格</param>
        /// <returns></returns>
        [OperationContract]
        int WritePLCAdressOnSESFForVisualQCStation(int secondWorkStationID, short pallet, bool exception);

        /// <summary>
        /// PLC读写测试,true为写
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        [OperationContract]
        int PLCReadAndWriteTest(string address, short value, bool flag);

        /// <summary>
        /// 返回所有PLC地址和值，失败返回null
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<TB_PLCBaseAdressInfo> GetAllPLCAdressData();

        /// <summary>
        /// 根据特定的第二工位ID，返回正在该工位上的PLC实际地址中的托盘号
        /// 并扩展至4位
        /// 如果当前没有，返回null
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <returns></returns>
        [OperationContract]
        string[] GetPalletCodesBySecondWorkStationID(int secondWorkStationID);

        /// <summary>
        /// 根据特定的第二工位ID，返回正在该工位上的PLC实际地址中的托盘号(虚拟QC使用,加入去向地址判定)
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <returns></returns>
        [OperationContract]
        string[] GetPalletCodesBySecondWorkStationIDForVisualSecondWorkStation(int secondWorkStationID);

        /// <summary>
        /// 完成任务
        /// 1 成功
        /// 2 失败
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <param name="palletCode"></param>
        /// <returns></returns>
        [OperationContract]
        int WorkTaskComplete(int secondWorkStationID, string palletCode, int userID);

        /// <summary>
        /// 返回系统时间
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DateTime GetTimeNow();

        #region 登录支持

        /// <summary>
        /// PC端登录支持
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        int LoginHelpForPCClient(string userID, string password,int secondWorkStationID);

        /// <summary>
        /// 虚拟QC位登录支持
        /// </summary>
        /// <param name="userID">用户工号</param>
        /// <param name="password">密码</param>
        /// <param name="secondWorkStationID">实际工位ID</param>
        /// <param name="visualSecondWorkStationID">虚拟工位ID</param>
        /// <returns></returns>
        //[OperationContract]
        //int LoginHelpForVisualPCClient(string userID, string password, int secondWorkStationID, int visualSecondWorkStationID);

        /// <summary>
        /// 服务端登录支持
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        int LoginHelpForService(string userID, string password,string serviceName);

        /// <summary>
        /// 工时统计辅助程序登录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        int LoginHelpForWorkTimeHelp(string userID, string password);

        /// <summary>
        /// 登出支持，服务端，secondWorkStationID=0；客户端，serviceName=""
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="secondWorkStationID"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        [OperationContract]
        int LoginHelpForLoginOut(int userID, int secondWorkStationID, string serviceName);

        #endregion

        #region 工时绑定相关

        /// <summary>
        /// 工时绑定，提供给下位机循环调用，班组长只能绑定今日的工时信息
        /// </summary>
        /// <param name="secondWorkStationID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        bool WorkTimeBanding(int secondWorkStationID, string userID,int recorderID);

        #endregion

        // TODO: 在此添加您的服务操作
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
