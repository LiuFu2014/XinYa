using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYaPCClientForVisualQCStation.DAL
{
    /// <summary>
    /// SQL数据访问帮助类
    /// </summary>
    class DBHelp
    {
        ///// <summary>
        ///// 数据实体
        ///// </summary>
        //XinYaDBEntities db = new XinYaDBEntities();

        #region 方法

        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>用户实体类</returns>
        public TB_User CheckUserLogin(string userName,string password)
        {
            using ( XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    TB_User user = db.TB_User.Single(p => p.UserName == userName && p.Password == password);
                    //禁用或非管理员不能登录此系统
                    if (user==null||user.IsUse==false||user.UserLevel!= "管理员")
                    {
                        return null;
                    }
                    else
                    {
                        return user;
                    }
                    
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
