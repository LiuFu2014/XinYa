using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XinYa.DAL;
using System.Windows.Forms;

namespace XinYa.BLL
{
    /// <summary>
    /// 业务逻辑层帮助类
    /// </summary>
    class BllHelp
    {
        /// <summary>
        /// 数据帮助类
        /// </summary>
        DBHelp db = new DBHelp();

        #region 通用方法

        /// <summary>
        /// 用于将dgv显示数据导出
        /// </summary>
        /// <param name="dgv">The DGV.</param>
        public static void DataOutport(DataGridView dgv)
        {
            if (dgv.RowCount <= 0 || dgv.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
        }

        #endregion

        #region 数据支持方法

        #region User

        /// <summary>
        /// 用户登录检测
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>返回用户实体类</returns>
        public TB_User CheckUserLogin(string user, string password)
        {
            return db.CheckUserLogin(user, password);
        }

        /// <summary>
        /// 返回所有用户
        /// </summary>
        /// <returns></returns>
        public List<TB_User> GetAllUser()
        {
            return db.GetAllUser();
        }

        #endregion


        #region 工作中心


        /// <summary>
        /// 有条件的返回工序路线
        /// </summary>
        /// <param name="flag">true返回所有</param>
        /// <param name="routeM">指定工序名</param>
        /// <returns></returns>
        public List<TB_ProcessRouteP> GetAllWorkFlow(bool flag, string routeM)
        {
            return db.GetAllWorkFlow(flag, routeM);
        }

        /// <summary>
        /// 返回所有主工序
        /// </summary>
        /// <returns></returns>
        public List<TB_ProcessRouteM> GetAllMainWorkFlow()
        {
            return db.GetAllMainWorkFlow();
        }

        /// <summary>
        /// 根据routeM和routeP插入或更新数据
        /// </summary>
        /// <param name="routeM"></param>
        /// <param name="routeP"></param>
        /// <returns>0-修改成功，1-主表数据跟新失败，2-从表数据更新失败，3-主表数据插入失败，4-从表数据插入失败</returns>
        public int AddOrRefreshProcessRoute(TB_ProcessRouteM routeM, List<TB_ProcessRouteP> routePs, TB_User user,bool addornot)
        {
            return db.AddOrRefreshProcessRoute(routeM, routePs, user,addornot);
        }
        #endregion

        #endregion

    }
}
