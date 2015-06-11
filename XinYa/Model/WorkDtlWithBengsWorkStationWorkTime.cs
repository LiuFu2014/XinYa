using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XinYa.DAL;

namespace XinYa.Model
{
    /// <summary>
    /// 用于记录员工详细工作过的泵（任务路线记录中）、承载工作工位、对应工时（员工工作记录统计）
    /// </summary>
    class WorkDtlWithBengsWorkStationWorkTime
    {
        //泵
        //public TB_WorkDtl workDtl;
        public TB_WorkDtl workDtl { get; set; }
        //工作工位
        //public string workStation;
        public string workStation { get; set; }
        //该泵对应的工位的工时
        //public string workTime;
        public string workTime { get; set; }

        public string userName { get; set; }

        public string beginTime { get; set; }

        public string endTime { get; set; }
    }
}
