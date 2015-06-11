using System.Linq;

namespace XinYaWcfServiceForPLCAndWorks
{
    class SystemLogHelper
    {
        public static void WriteSysLogHelper(string logText, int userID, string source)
        {
            using (XinYaDBEntities dblog = new XinYaDBEntities())
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

        public static void WriteSysLogHelper(string logText, string source)
        {
            using (XinYaDBEntities dblog = new XinYaDBEntities())
            {
                TB_SystemLog syslog = new TB_SystemLog();
                syslog.SysLog = logText;
                //syslog.TB_User = dblog.TB_User.First(p => p.ID == userID);
                syslog.Time = System.DateTime.Now;
                syslog.Source = source;
                dblog.TB_SystemLog.AddObject(syslog);
                dblog.SaveChanges();
            }
        }
    }
}