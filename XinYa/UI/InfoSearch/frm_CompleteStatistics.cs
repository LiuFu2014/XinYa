using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XinYa.BLL;
using XinYa.DAL;

namespace XinYa.UI.InfoSearch
{
    public partial class frm_CompleteStatistics : Form
    {
        private TB_User user;

        public frm_CompleteStatistics(TB_User user)
        {
            InitializeComponent();
            this.user = user;
            this.dgv_MaterialInfoShow.AutoGenerateColumns = false;
            this.dgv_MaterialInfoShow2.AutoGenerateColumns = false;
        }

        private void frm_CompleteStatistics_Load(object sender, EventArgs e)
        {
            //nothing...
        }

        /// <summary>
        /// 弹框选择型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MultiSelect_Click(object sender, EventArgs e)
        {
            txt_matcode.Text = "";
            frm_MaterialSelectHelper helper = new frm_MaterialSelectHelper(1);
            helper.Tag = this;
            helper.ShowDialog();
        }

        /// <summary>
        /// 指定日期查询（这里我是按主任务）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            #region 统计数定义

            //装配投入数是客户的计划数，这里暂定为0
            int zhuangpeitourushu = 0;
            //这里为装配上线数
            int zhuangpeiwanchengshu = 0;
            int zhuangpeiyichangchuxiancishu = 0;
            int zhuangpeiyichangshu = 0;

            int tiaoshitourushu = 0;
            int tiaoshiwanchengshu = 0;
            int tiaoshiyichangchuxiancishu = 0;
            int tiaoshiyichangshu = 0;
            //调试返修上线数
            int tiaoshifanxiushangxianshu = 0;

            int baozhuangtourushu = 0;
            int baozhuangwanchengshu = 0;
            int baozhuangyichangchuxiancishu = 0;
            int baozhuangyichangshu = 0;
            //包装段分流检测上线数
            int baozhuangfanxiushangxianshu = 0;
            //包装段异常总数
            int baozhuangduanyichangzongshu = 0;

            DateTime begintime = dtp_BeginTime.Value;
            DateTime endtime = dtp_EndTime.Value;

            #endregion 统计数定义

            #region 统计处理

            using (XinYaDBEntities db = new XinYaDBEntities())
            {
                try
                {
                    //获取全部主任务(已经提交了的)（这里也可以考虑直接获取子任务，但是通过筛选主任务再来查找子任务，性能较好）
                    var mainworks = db.TB_WorkMain.Where(p => p.IsCommit == true).ToList();
                    List<TB_WorkMain> list_mainworks = new List<TB_WorkMain>();
                    //判断是否选中了今日
                    if (check_Today.Checked)
                    {
                        foreach (var item in mainworks)
                        {
                            if (item.CreateDate.Date == DateTime.Today)
                            {
                                list_mainworks.Add(item);
                            }
                        }
                        //对装配计划投入数做一个统计,这里是对日计划做的一个统计
                        var plan = db.TB_ProductionPlan.ToList();
                        foreach (var item in plan)
                        {
                            if (item.Date == DateTime.Now.Date)
                            {
                                zhuangpeitourushu += item.Amount;
                            }
                        }
                    }
                    else
                    {
                        if (begintime.CompareTo(endtime) > 0)
                        {
                            MessageBox.Show("开始时间不应晚于结束时间!");
                            Changeprobar(false);
                            return;
                        }
                        foreach (var item in mainworks)
                        {
                            if (item.CreateDate.CompareTo(begintime) > 0 && item.CreateDate.CompareTo(endtime) < 0)
                            {
                                list_mainworks.Add(item);
                            }
                        }
                        //对装配计划投入数做一个统计
                        var plan = db.TB_ProductionPlan.ToList();
                        foreach (var item in plan)
                        {
                            if (item.Date.CompareTo(begintime) > 0 && item.Date.CompareTo(endtime) < 0)
                            {
                                zhuangpeitourushu += item.Amount;
                            }
                        }
                    }

                    //不管怎样，先把他加载完全
                    foreach (var item in list_mainworks)
                    {
                        item.TB_SecondWorkStationInfoReference.Load();
                        item.TB_User1Reference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkDtl.ToList();
                        item.TB_WorkDtlForEachStation.ToList();
                    }
                    //定义一个接纳这些主任务子任务的list
                    List<TB_WorkDtl> list_workdtl = new List<TB_WorkDtl>();

                    //遍历这些筛选后的主任务
                    foreach (var item in list_mainworks)
                    {
                        //存储子任务
                        foreach (var a in item.TB_WorkDtl.ToList())
                        {
                            list_workdtl.Add(a);
                        }
                        //这些从A处上线的主任务的子任务相加即为装配完成（线体上线数）
                        if (item.TB_SecondWorkStationInfo.SecondWorkStationCode == "SA")
                        {
                            zhuangpeiwanchengshu += item.TB_WorkDtl.Count;
                        }

                        //-----------------------------------------------

                        #region 调试

                        //调试投入数就是主任务在调试完成后的子任务数，包括异常数
                        //（这里关于异常重复计数问题，应减去在返修工位重新上线的。即使是这个是在包装段产生的异常也应该减去，因为这个泵也是从调试台经过的）
                        //筛选工艺路线记录，获取第二工位编码为“SE”的任务
                        foreach (var item2 in item.TB_WorkDtlForEachStation.ToList())
                        {
                            //这条任务经过调试台
                            if (item2.TB_SecondWorkStationInfo.SecondWorkStationCode == "SE")
                            {
                                //经过则相加获取投入总数(这里的投入总数要减去返修上线数)
                                tiaoshitourushu += item.TB_WorkDtl.Count;
                                //返修上线统计
                                if (item.TB_SecondWorkStationInfo.SecondWorkStationCode == "SD")
                                {
                                    tiaoshifanxiushangxianshu += item.TB_WorkDtl.Count();
                                }
                                //----------------------------------------
                                ////获取调试完成数就等于经过调试台的而且无异常的数，还要加上这个任务在包装段产生的异常数，即这里的判断条件会排除掉的子任务中，可能在调试没有产生异常而在包装产生异常
                                tiaoshiwanchengshu += item.TB_WorkDtl.Count(p => p.IsException == false);
                                //筛选没有出现异常的泵
                                //这里将返修上线的泵记录为完成数里面
                                //循环遍历这条主任务的子任务
                                foreach (var item3 in item.TB_WorkDtl.ToList())
                                {
                                    int flag = 0;//记录有没有在调试台出现过异常
                                    foreach (var item4 in item3.TB_WorkException.ToList())
                                    {
                                        //重新上线的不应当做异常处理（感觉这里虽然没必要，还是加吧）
                                        if (item4.TB_SecondWorkStationInfo.SecondWorkStationCode == "SE" && item4.ExceptionID != null)
                                        {
                                            //说明这条主任务的这条子任务在调试处出现了异常，那么异常++
                                            tiaoshiyichangchuxiancishu++;
                                            flag = 1;
                                        }
                                    }
                                    if (flag == 1)
                                    {
                                        //如果在调试台出现过异常，记录下这条子任务
                                        tiaoshiyichangshu++;
                                    }
                                    ////如果这条主任务的子任务没有出现异常，则相加
                                    //if (item3.IsException == false)
                                    //{
                                    //    tiaoshiwanchengshu++;
                                    //}
                                    //else
                                    //{
                                    //    //如果出现异常
                                    //    tiaoshiyichangchuxiancishu++;
                                    //}
                                }
                                break;
                            }
                        }
                        ////这里获取返修工位上线的
                        //if (item.TB_SecondWorkStationInfo.SecondWorkStationCode == "SD")
                        //{
                        //    //异常返修泵会被重复计数，这里应该减去一次
                        //    tiaoshitourushu -= item.TB_WorkDtl.Count;
                        //}

                        #endregion 调试

                        #region 包装

                        //筛选进过包装段的任务
                        foreach (var item2 in item.TB_WorkDtlForEachStation.ToList())
                        {
                            //这条任务经过调试台
                            //包装段工位代码
                            string baozhuangduan = "SGSHSISJSKSLSMSNSOSP";
                            //如果经过
                            if (baozhuangduan.Contains(item2.TB_SecondWorkStationInfo.SecondWorkStationCode))
                            {
                                //经过则相加获取投入总数(投入总数应该减去从分流检测返修上线的数,还需要减去不在包装段产生异常的数)
                                baozhuangtourushu += item.TB_WorkDtl.Count;
                                //异常总数
                                baozhuangduanyichangzongshu += item.TB_WorkDtl.Count(p => p.IsException == true);
                                //
                                //-------这里记录下分流检测上线的任务子任务数-----
                                if (item.TB_SecondWorkStationInfo.SecondWorkStationCode == "SH")
                                {
                                    //记录下从分流检测上线的数
                                    baozhuangfanxiushangxianshu += item.TB_WorkDtl.Count;
                                }
                                //------------------------------------------------
                                //获取包装完成数
                                //筛选没有出现异常的泵，这里出了异常的泵(不管是调试出的异常还是在这里出的异常)肯定是不计入处理的数，那么没出异常的又经过包装段的肯定是完成数
                                baozhuangwanchengshu += item.TB_WorkDtl.Count(p => p.IsException == false);

                                //这里将分流检测上线的泵记录为完成数里面
                                //循环遍历这条主任务的子任务
                                foreach (var item3 in item.TB_WorkDtl.ToList())
                                {
                                    int flag = 0;//记录有没有在包装段出现过异常
                                    foreach (var item4 in item3.TB_WorkException.ToList())
                                    {
                                        if (baozhuangduan.Contains(item4.TB_SecondWorkStationInfo.SecondWorkStationCode) && item4.ExceptionID != null)
                                        {
                                            //说明这条主任务的这条子任务在包装段出现了异常，那么异常++
                                            baozhuangyichangchuxiancishu++;
                                            flag = 1;
                                        }
                                    }
                                    if (flag == 1)
                                    {
                                        //如果在调试台出现过异常，记录下这条子任务
                                        baozhuangyichangshu++;
                                    }
                                    ////如果这条主任的子任务没有出现异常，则相加
                                    //if (item3.IsException == false)
                                    //{
                                    //    baozhuangwanchengshu++;
                                    //}
                                    //else
                                    //{
                                    //    //如果出现异常
                                    //    baozhuangyichangchuxiancishu++;
                                    //}
                                }
                                //break掉，防止一个任务因为经过多个包装工序而被重复计数
                                break;
                            }
                        }
                        //这里获取分流检测工位重新上线的
                        //if (item.TB_SecondWorkStationInfo.SecondWorkStationCode == "SH")
                        //{
                        //    //异常返修泵会被重复计数，这里应该减去一次
                        //    baozhuangtourushu -= item.TB_WorkDtl.Count;
                        //}

                        #endregion 包装

                        //-----------------------------------------------
                    }
                    //装配异常出现次数就等于包装端+调试段
                    //zhuangpeiyichangchuxiancishu = tiaoshiyichangchuxiancishu + baozhuangyichangchuxiancishu;
                    //调试完成数就等于这里的调试投入数-异常子任务数（已经包含所有子任务，包括出异常的，这里减去重复记录的异常的，当然就是完成了的）
                    //这里会有个异常，即如果我的异常返修泵不再上线或在调试上线怎么办？
                    //所以这里的包装完成数应该是主任务中没有出现异常的所有的相加
                    //tiaoshiwanchengshu = tiaoshitourushu - tiaoshiyichangshu;
                    //同理可得
                    //baozhuangwanchengshu = baozhuangtourushu - baozhuangyichangshu;
                    //包装投入总数=包装投入总数-（不在包装段产生的异常数）-分流检测上线数；
                    baozhuangtourushu = baozhuangtourushu - (baozhuangduanyichangzongshu - baozhuangyichangchuxiancishu) - baozhuangfanxiushangxianshu;

                    //调试完成数=调试投入总数（这里包括返修工位重新上线的）-调试区产生的异常次数
                    tiaoshiwanchengshu = tiaoshitourushu - tiaoshiyichangchuxiancishu;
                    //调试投入总数
                    tiaoshitourushu = tiaoshitourushu - tiaoshifanxiushangxianshu;

                    //统计完成后给控件赋值
                    lab_Zhuangpeitourushu.Text = zhuangpeitourushu.ToString();
                    lab_Zhuangpeiwanchengshu.Text = zhuangpeiwanchengshu.ToString();
                    //lab_zhuangpeiyichangchuxiancishu.Text = zhuangpeiyichangchuxiancishu.ToString();
                    lab_Tiaoshitourushu.Text = tiaoshitourushu.ToString();
                    lab_Tiaoshiwanchengshu.Text = tiaoshiwanchengshu.ToString();
                    lab_Tiaoshiyichangchuxiancishu.Text = tiaoshiyichangchuxiancishu.ToString();
                    lab_Baozhuangtourushu.Text = baozhuangtourushu.ToString();
                    lab_Baozhuangwanchengshu.Text = baozhuangwanchengshu.ToString();
                    lab_Baozhuangyichangchuxiancishu.Text = baozhuangyichangchuxiancishu.ToString();

                    //dgv
                    //将这些记录下来的子任务加载完全
                    foreach (var item in list_workdtl)
                    {
                        item.TB_ExceptionReference.Load();
                        item.TB_MaterialInfoReference.Load();
                        item.TB_UserReference.Load();
                        item.TB_WorkException.Load();
                        item.TB_WorkMainReference.Load();
                        item.TB_SecondWorkStationInfoReference.Load();
                    }
                    dgv_MaterialInfoShow.DataSource = list_workdtl;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("统计查询时出现与特定于网络或录入数据的异常！");
                    SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "完成统计");
                }
            }

            #endregion 统计处理

            Changeprobar(false);
        }

        public void Changeprobar(bool flag)
        {
            if (flag)
            {
                lab_Status.Visible = true;
                prosbar_Main.Visible = true;
            }
            else
            {
                lab_Status.Visible = false;
                prosbar_Main.Visible = false;
            }
        }

        private void dgv_MaterialInfoShow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_MaterialInfoShow.Rows[e.RowIndex].DataBoundItem != null) && (dgv_MaterialInfoShow.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_MaterialInfoShow.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_MaterialInfoShow.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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

        private void dgv_MaterialInfoShow2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgv_MaterialInfoShow2.Rows[e.RowIndex].DataBoundItem != null) && (dgv_MaterialInfoShow2.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv_MaterialInfoShow2.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv_MaterialInfoShow2.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
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
        /// 按号段查询（这里我是按子任务）（客户暂时没有给出段号定义，故这里没有实现段号筛选）（11.4需要对算法进行优化）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ser2_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();

            //检查完整性
            if (string.IsNullOrEmpty(txt_BeginCode.Text) || string.IsNullOrEmpty(txt_EndCode.Text))
            {
                MessageBox.Show("请先输入起始和结束号段再进行查询");
            }
            else
            {
                #region 统计数定义

                //装配投入数是客户的计划数，这里暂定为0
                int zhuangpeitourushu2 = 0;
                //这里为装配上线数
                int zhuangpeiwanchengshu2 = 0;
                int zhuangpeiyichangchuxiancishu2 = 0;
                int zhuangpeiyichangshu2 = 0;

                int tiaoshitourushu2 = 0;
                int tiaoshiwanchengshu2 = 0;
                int tiaoshiyichangchuxiancishu2 = 0;
                int tiaoshiyichangshu2 = 0;
                //调试返修上线数
                int tiaoshifanxiushangxianshu2 = 0;

                int baozhuangtourushu2 = 0;
                int baozhuangwanchengshu2 = 0;
                int baozhuangyichangchuxiancishu2 = 0;
                int baozhuangyichangshu2 = 0;
                //包装返修上线数
                int baozhuangfanxiushangxianshu2 = 0;
                //包装异常总数
                int baozhuangyichangzongshu2 = 0;

                #endregion 统计数定义

                #region 统计处理

                using (XinYaDBEntities db = new XinYaDBEntities())
                {
                    try
                    {
                        //思路
                        //所有子任务去除所有未提交的
                        var workdtls = db.TB_WorkDtl.Where(p => p.TB_WorkMain.IsCommit == true).ToList();
                        //子任务存储容器
                        List<TB_WorkDtl> list_workdtls = new List<TB_WorkDtl>();
                        //获取查询语句
                        //IQueryable<TB_WorkDtl> Queryable = db.TB_WorkDtl.AsQueryable();
                        //Queryable = Queryable.Where(p => p.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SA" && p.TB_WorkMain.IsCommit == true);

                        #region 是否指定型号

                        //是否指定型号
                        //if (check_SelectMaterialType.Checked)
                        //{
                        //    string[] str = txt_matcode.Text.Trim().TrimEnd(';').Split(';');
                        //    foreach (var item in workdtls)
                        //    {
                        //        if (str.Contains(item.MaterialCode.Substring(0, 12)))
                        //        {
                        //            list_workdtls.Add(item);
                        //        }
                        //    }
                        //    //指定型号下对装配计划数的统计
                        //    var plan = db.TB_ProductionPlan.ToList();
                        //    foreach (var item in plan)
                        //    {
                        //        if (str.Contains(item.MaterialID))
                        //        {
                        //            zhuangpeitourushu2 += item.Amount;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    list_workdtls = workdtls;
                        //    //不指定型号下对装配计划数的统计
                        //    var plan = db.TB_ProductionPlan.ToList();
                        //    foreach (var item in plan)
                        //    {
                        //        zhuangpeitourushu2 += item.Amount;
                        //    }
                        //}

                        #endregion 是否指定型号

                        #region 号段筛选

                        //开始号段
                        string beginnum = txt_BeginCode.Text;
                        string endnum = txt_EndCode.Text;
                        //筛选子任务
                        foreach (var item in workdtls)
                        {
                            try
                            {
                                //条件为年2位，月2位+段号6位，起始13，长度10
                                int i = Convert.ToInt32(item.MaterialCode.Substring(13, 10));
                                if (i >= Convert.ToInt32(beginnum) && i <= Convert.ToInt32(endnum))
                                {
                                    list_workdtls.Add(item);
                                }
                            }
                            catch { }
                        }

                        #endregion 号段筛选

                        //对这些子任务进行遍历
                        foreach (var item in list_workdtls)
                        {
                            //如果是A处上线的，记录到装配完成数里面
                            if (item.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SA")
                            {
                                zhuangpeiwanchengshu2++;
                            }

                            #region 调试段

                            //条件为这条子任务的主任务经过调试段
                            foreach (var item2 in item.TB_WorkMain.TB_WorkDtlForEachStation)
                            {
                                //是否经过调试
                                if (item2.TB_SecondWorkStationInfo.SecondWorkStationCode == "SE")
                                {
                                    //一个任务正常情况下在调试段只做一次
                                    tiaoshitourushu2++;
                                    //判断这条子任务有没有在调试处产生异常
                                    int flag = 0;
                                    if (item.TB_WorkException.Count != 0)
                                    {
                                        foreach (var item3 in item.TB_WorkException.ToList())
                                        {
                                            //如果在调试处有过异常产生记录
                                            if (item3.TB_SecondWorkStationInfo.SecondWorkStationCode == "SE" && item3.ExceptionID != null)
                                            {
                                                tiaoshiyichangchuxiancishu2++;
                                                flag = 1;
                                            }
                                        }
                                    }
                                    //判断是否是返修上线的,如果这条子任务是从返修上线的则记录下来
                                    if (item.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SD")
                                    {
                                        tiaoshifanxiushangxianshu2++;
                                    }

                                    if (flag == 1)
                                    {
                                        //==1说明在调试处有异常产生。那这个泵就记录为异常泵
                                        tiaoshiyichangshu2++;
                                    }
                                    else
                                    {
                                        //没有产生异常则说明是完成的
                                        tiaoshiwanchengshu2++;
                                    }
                                    //break掉，防止一个子任务因为经过多个调试工序而被重复计数
                                    break;
                                }
                            }

                            #endregion 调试段

                            #region 包装段

                            //包装段工位代码
                            string baozhuangduan = "SGSHSISJSKSLSMSNSOSP";
                            foreach (var item2 in item.TB_WorkMain.TB_WorkDtlForEachStation)
                            {
                                //这条子任务是否经过包装
                                if (baozhuangduan.Contains(item2.TB_SecondWorkStationInfo.SecondWorkStationCode))
                                {
                                    //经过就记录到包装投入数里面(这里会把调试台产生的异常也会算进去，所以这里应该算出所有的异常总数)
                                    //用投入总数（包括检测返修上线）减去返修上线数，减去异常总数再加上被减去的在包装段产生的异常数=实际投入数
                                    baozhuangtourushu2++;
                                    if (item.IsException == true)
                                    {
                                        //异常总数
                                        baozhuangyichangzongshu2++;
                                    }
                                    if (item.IsException == false)
                                    {
                                        //如果这个泵没有异常，意味着是正常结束的，则完成++
                                        //包装完成数
                                        baozhuangwanchengshu2++;
                                    }
                                    //判断是否在包装端产生异常
                                    int flag = 0;
                                    if (item.TB_WorkException.Count != 0)
                                    {
                                        foreach (var item3 in item.TB_WorkException.ToList())
                                        {
                                            //如果在包装处有过异常产生记录
                                            if (baozhuangduan.Contains(item3.TB_SecondWorkStationInfo.SecondWorkStationCode) && item3.ExceptionID != null)
                                            {
                                                //包装异常产生数
                                                tiaoshiyichangchuxiancishu2++;
                                                flag = 1;
                                            }
                                        }
                                    }
                                    if (flag == 1)
                                    {
                                        //==1说明在包装处有异常产生。那这个泵就记录为异常泵
                                        tiaoshiyichangshu2++;
                                    }
                                    //如果他是在分流检测返修上线的
                                    if (item.TB_WorkMain.TB_SecondWorkStationInfo.SecondWorkStationCode == "SH")
                                    {
                                        //包装段返修上线数
                                        baozhuangfanxiushangxianshu2++;
                                    }
                                    //break掉，防止一个子任务因为经过多个包装工序而被重复计数
                                    break;
                                }
                            }

                            #endregion 包装段
                        }
                        //遍历完子任务后
                        //调试完成数就是调试投入数减去出现了异常的
                        //（这里是将所有子任务加载，包括有异常的，现在将有异常的剔除掉那就当然是完成了的,然而这些异常可能在调试是没有的，
                        //在异常处产生的，所以要加上在包装上产生的异常数）
                        //tiaoshiwanchengshu2 = tiaoshitourushu2 - tiaoshiyichangshu2;
                        //同理可得包装完成数
                        //baozhuangwanchengshu2 = baozhuangtourushu2 - baozhuangyichangshu2;

                        //调试完成数=调试投入数(这里包括返修上线的数)-调试区异常数
                        tiaoshiwanchengshu2 = tiaoshitourushu2 - tiaoshiyichangchuxiancishu2;
                        //调试投入数-=返修上线数
                        tiaoshitourushu2 -= tiaoshifanxiushangxianshu2;

                        //包装投入数=投入总数（包括检测返修上线）减去返修上线数，减去异常总数再加上被减去的在包装段产生的异常数
                        baozhuangtourushu2 = baozhuangtourushu2 - baozhuangfanxiushangxianshu2 - baozhuangyichangzongshu2 + baozhuangyichangchuxiancishu2;

                        //控件赋值
                        lab_Zhuangpeitourushu2.Text = zhuangpeitourushu2.ToString();
                        lab_Zhuangpeiwanchengshu2.Text = zhuangpeiwanchengshu2.ToString();
                        lab_zhuangpeiyichangchuxiancishu2.Text = zhuangpeiyichangchuxiancishu2.ToString();

                        lab_Tiaoshitourushu2.Text = tiaoshitourushu2.ToString();
                        lab_Tiaoshiwanchengshu2.Text = tiaoshiwanchengshu2.ToString();
                        lab_Tiaoshiyichangchuxiancishu2.Text = tiaoshiyichangchuxiancishu2.ToString();

                        lab_Baozhuangtourushu2.Text = baozhuangtourushu2.ToString();
                        lab_Baozhuangwanchengshu2.Text = baozhuangwanchengshu2.ToString();
                        lab_Baozhuangyichangchuxiancishu2.Text = baozhuangyichangchuxiancishu2.ToString();

                        //将这些记录下来的子任务加载完全
                        foreach (var item in list_workdtls)
                        {
                            item.TB_ExceptionReference.Load();
                            item.TB_MaterialInfoReference.Load();
                            item.TB_UserReference.Load();
                            item.TB_WorkException.Load();
                            item.TB_WorkMainReference.Load();
                        }
                        dgv_MaterialInfoShow2.DataSource = list_workdtls;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("统计查询时出现与特定于网络或录入数据的异常！");
                        SystemLogHelper.WriteSysLogHelper(ex.ToString(), user.ID, "完成统计");
                    }
                }

                #endregion 统计处理
            }

            Changeprobar(false);
        }

        /// <summary>
        /// 限制只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_BeginCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        /// <summary>
        /// 限制只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_EndCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;
        }

        /// <summary>
        /// 限制只能输入数字和半角分号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_matcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 59))
                e.Handled = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 分时段数据筛选结果导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportExcel1_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_MaterialInfoShow.RowCount <= 0 || dgv_MaterialInfoShow.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_MaterialInfoShow) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 分号段数据筛选结果导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OutportExcel2_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            if (dgv_MaterialInfoShow2.RowCount <= 0 || dgv_MaterialInfoShow2.DataSource == null)
            {
                MessageBox.Show("没有可以用于导出的数据");
            }
            else
            {
                //测试后还是选择第二种，然偶在工控机上安装office2010即可
                //DataImpExp.DataIE.DataGridViewToExcel(dgv_Main, "test1", "test2");
                if (ExportData.DataGridViewToExcel(dgv_MaterialInfoShow2) == 0)
                {
                    MessageBox.Show("导出成功！");
                }
                else
                {
                    MessageBox.Show("导出失败！");
                }
                //NpoiHelper.ExportForm(dgv_Main, "hello");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 分时段数据统计结果结果导出到txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outporttxt1_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            StringBuilder str = new StringBuilder();
            string NowDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            str.AppendLine(string.Format("****************************{0},导出人[{1}]****************************", NowDateTime, user.UserName));
            str.AppendLine(string.Format("******************开始时间{0},结束时间{1}******************", dtp_BeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtp_EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            str.AppendLine();
            str.AppendLine(string.Format("装配计划投入数{0}，装配计划完成数{1}，装配计划异常出现次数{2}", lab_Zhuangpeitourushu.Text, lab_Zhuangpeiwanchengshu.Text, "/"));
            str.AppendLine(string.Format("调试计划投入数{0}，调试计划完成数{1}，调试计划异常出现次数{2}", lab_Tiaoshitourushu.Text, lab_Tiaoshiwanchengshu.Text, lab_Tiaoshiyichangchuxiancishu.Text));
            str.AppendLine(string.Format("包装计划投入数{0}，包装计划完成数{1}，包装计划异常出现次数{2}", lab_Baozhuangtourushu.Text, lab_Baozhuangwanchengshu.Text, lab_Baozhuangyichangchuxiancishu.Text));
            str.AppendLine();
            str.AppendLine("*****************鑫亚公司@鑫亚软控信息化系统@分时段统计*****************");
            if (ExportData.SaveToTxt(str.ToString()))
            {
                MessageBox.Show("导出到txt文档成功！");
            }
            else
            {
                MessageBox.Show("导出到txt文档失败！");
            }
            Changeprobar(false);
        }

        /// <summary>
        /// 分号段数据筛选结果导出到txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Outporttxt2_Click(object sender, EventArgs e)
        {
            Changeprobar(true);
            Application.DoEvents();
            StringBuilder str = new StringBuilder();
            string NowDateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            str.AppendLine(string.Format("****************************{0},导出人[{1}]****************************", NowDateTime, user.UserName));
            str.AppendLine(string.Format("****************起始段号{0},结束段号{1}****************", txt_BeginCode.Text == null ? "" : txt_BeginCode.Text, txt_EndCode.Text == null ? "" : txt_EndCode.Text));
            str.AppendLine();
            str.AppendLine(string.Format("是否指定型号{0}", check_SelectMaterialType.Checked.ToString()));
            str.AppendLine("型号：" + txt_matcode.Text == null ? "" : txt_matcode.Text);
            str.AppendLine(string.Format("装配计划投入数{0}，装配计划完成数{1}，装配计划异常出现次数{2}", lab_Zhuangpeitourushu2.Text, lab_Zhuangpeiwanchengshu2.Text, "/"));
            str.AppendLine(string.Format("调试计划投入数{0}，调试计划完成数{1}，调试计划异常出现次数{2}", lab_Tiaoshitourushu2.Text, lab_Tiaoshiwanchengshu2.Text, lab_Tiaoshiyichangchuxiancishu2.Text));
            str.AppendLine(string.Format("包装计划投入数{0}，包装计划完成数{1}，包装计划异常出现次数{2}", lab_Baozhuangtourushu2.Text, lab_Baozhuangwanchengshu2.Text, lab_Baozhuangyichangchuxiancishu2.Text));
            str.AppendLine();
            str.AppendLine("*****************鑫亚公司@鑫亚软控信息化系统@分号段统计*****************");
            if (ExportData.SaveToTxt(str.ToString()))
            {
                MessageBox.Show("导出到txt文档成功！");
            }
            else
            {
                MessageBox.Show("导出到txt文档失败！");
            }
            Changeprobar(false);
        }
    }
}