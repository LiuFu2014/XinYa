using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.DAL
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

        #region User

        /// <summary>
        /// 检查用户登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <returns>用户实体类</returns>
        public TB_User CheckUserLogin(string userName, string password)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    TB_User user = db.TB_User.Single(p => p.UserName == userName && p.Password == password);
                    //禁用或非管理员不能登录此系统
                    if (user == null || !user.IsUse || user.UserLevel != "管理员")
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

        /// <summary>
        /// 返回所有用户
        /// </summary>
        /// <returns></returns>
        public List<TB_User> GetAllUser()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //获取查询语句
                IQueryable<TB_User> Queryable = db.TB_User.AsQueryable();
                ////添加条件
                //Queryable = Queryable.Where(P => P.No == 12);
                //tolist才会执行查询
                Queryable = Queryable.Where(p => p.UserLevel != "ERP");
                return Queryable.ToList();
            }

        }

        #endregion

        #region WorkManagement

        /// <summary>
        /// 按条件返回工序路线
        /// </summary>
        /// <param name="flag">为true返回所有工序路线，为false返回指定工序路线</param>
        /// <param name="routeM">返回指定ID工序路线</param>
        /// <returns></returns>
        public List<TB_ProcessRouteP> GetAllWorkFlow(bool flag, string routeM)
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                if (flag)
                {
                    try
                    {
                        ////获取查询语句
                        //IQueryable<TB_ProcessRouteP> Queryable = db.TB_ProcessRouteP.AsQueryable();
                        ////添加条件
                        //Queryable = Queryable.Where(P => P.No ==12);
                        ////tolist才会执行查询
                        //Queryable.ToList();

                        var temp = from a in db.TB_ProcessRouteP
                                   where a.ProcessRouteM == "Item0"
                                   select a;
                        foreach (var item in temp)
                        {
                            item.TB_WorkStationInfoReference.Load();
                        }
                        return temp.ToList();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                else
                {
                    //获取查询语句
                    IQueryable<TB_ProcessRouteP> Queryable = db.TB_ProcessRouteP.AsQueryable();
                    //添加条件
                    Queryable = Queryable.Where(P => P.ProcessRouteM == routeM);
                    foreach (var item in Queryable)
                    {
                        item.TB_WorkStationInfoReference.Load();
                        string a = item.TB_WorkStationInfo.WorkStationName;
                    }
                    //tolist才会执行查询
                    return Queryable.ToList();
                }

            }
        }

        /// <summary>
        /// 返回所有主工序
        /// </summary>
        /// <returns></returns>
        public List<TB_ProcessRouteM> GetAllMainWorkFlow()
        {
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                //获取查询语句
                IQueryable<TB_ProcessRouteM> Queryable = db.TB_ProcessRouteM.AsQueryable();
                ////添加条件
                //Queryable = Queryable.Where(P => P.No == 12);
                foreach (var item in Queryable)
                {
                    item.TB_UserReference.Load();
                }
                //tolist才会执行查询
                return Queryable.ToList();
            }
        }

        /// <summary>
        /// 根据routeM和routeP插入或更新数据,addornot为true表示新增
        /// </summary>
        /// <param name="routeM"></param>
        /// <param name="routeP"></param>
        /// <returns>0-修改成功，1-主表数据跟新失败，2-从表数据更新失败，3-主表数据插入失败，4-从表数据插入失败,5-当前主路线编码已经存在</returns>
        public int AddOrRefreshProcessRoute(TB_ProcessRouteM routeM, List<TB_ProcessRouteP> routePs, TB_User user,bool addornot)
        {
            int flag = 0;
            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                TB_ProcessRouteM m;
                try
                {
                    m = db.TB_ProcessRouteM.First(b => b.ProcessRouteMCode == routeM.ProcessRouteMCode);
                }
                catch (Exception ex)
                {
                    m = null;
                }

                //首先检测是否存在routeM，存在为更新，不存在为插入
                if (m != null)
                {
                    if (addornot)//新增，不应为编辑的
                    {
                        //5-当前主路线编码已经存在
                        return 5;
                    }
                    try
                    {
                        //主表数据保存
                        m.ProcessRouteMName = routeM.ProcessRouteMName;
                        m.ProcessRouteMCode = routeM.ProcessRouteMCode;
                        m.ProcessRouteP = routeM.ProcessRouteP;
                        m.IsUse = routeM.IsUse;
                        m.Remark = routeM.Remark;
                        m.CreateDate = DateTime.Now.ToString();
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        flag = 1;
                        return flag;
                    }
                    try
                    {
                        //从表数据保存
                        foreach (var routeP in routePs)
                        {
                            TB_ProcessRouteP p = db.TB_ProcessRouteP.Single(b => b.ID == routeP.ID);
                            p.ProcessRouteM = routeP.ProcessRouteM;
                            //外键处理
                            p.TB_ProcessRouteM = db.TB_ProcessRouteM.First(a=>a.ProcessRouteMCode==m.ProcessRouteMCode);
                            p.No = routeP.No;
                           // p.TB_WorkStationInfo = db.TB_WorkStationInfo.First(a => a.ID == routeP.WorkStationID);
                            p.IsUse = routeP.IsUse;
                            p.IsLast = routeP.IsLast;
                            p.Remark = routeP.Remark;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 2;
                        return flag;
                    }
                }
                else
                {
                    try
                    {
                        //新增的时候重新绑定当前用户
                        routeM.TB_User = db.TB_User.First(p => p.ID == user.ID);
                        routeM.CreateDate = DateTime.Now.ToLongDateString();
                        //TB_ProcessRouteM rm = new TB_ProcessRouteM();
                        //rm.ProcessRouteMName = routeM.ProcessRouteMName;
                        //rm.ProcessRouteMCode = routeM.ProcessRouteMCode;
                        //rm.ProcessRouteP = routeM.ProcessRouteP;
                        //rm.IsUse = routeM.IsUse;
                        //rm.TB_User = db.TB_User.First(p => p.ID == user.ID);

                        //主表数据插入
                        //db.AddToTB_ProcessRouteM(routeM);
                        db.TB_ProcessRouteM.AddObject(routeM);
                        //db.Attach(routeM);
                        //db.ObjectStateManager.ChangeObjectState(routeM, System.Data.EntityState.Modified);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        flag = 3;
                        return flag;
                    }
                    try
                    {
                        //从表数据插入
                        foreach (var item in routePs)
                        {
                            TB_ProcessRouteP routeP = new TB_ProcessRouteP();
                            routeP.ProcessRouteM = routeM.ProcessRouteMCode;
                            //外键处理
                            routeP.TB_ProcessRouteM = db.TB_ProcessRouteM.First(p => p.ProcessRouteMCode == routeM.ProcessRouteMCode);
                            routeP.No = item.No;
                            routeP.IsUse = item.IsUse;
                            routeP.IsLast = item.IsLast;
                            routeP.Remark = item.Remark;
                            routeP.TB_WorkStationInfo = db.TB_WorkStationInfo.First(p => p.ID == item.WorkStationID);
                            db.AddToTB_ProcessRouteP(routeP);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = 4;
                        return flag;
                    }
                    //    }
                }
                return flag;
            }
        #endregion
        }
    }
}
