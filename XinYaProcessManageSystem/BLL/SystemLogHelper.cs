using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XinYaProcessManageSystem.BLL
{
    class SystemLogHelper
    {
        public static void WriteSysLogHelper(string logText,int userID,string source)
        {
            using (XinYaDBEntities dblog=new XinYaDBEntities())
            {
                TB_SystemLog syslog = new TB_SystemLog();
                syslog.SysLog = logText;
                syslog.TB_User = dblog.TB_User.First(p => p.ID == userID);
                syslog.Time = System.DateTime.Now;
                syslog.Source = source;
                dblog.TB_SystemLog.AddObject(syslog);
                dblog.SaveChanges();
            }
        }
    }
}
