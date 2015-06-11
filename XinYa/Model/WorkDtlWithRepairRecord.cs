using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XinYa.DAL;

namespace XinYa.Model
{
    /// <summary>
    /// 员工工作记录中的返修记录
    /// </summary>
    class WorkDtlWithRepairRecord
    {
        /// <summary>
        /// 返修记录
        /// </summary>
        public TB_RepairRecord RepairRecord { get; set; }

        /// <summary>
        /// 工时
        /// </summary>
        public string WorkTime { get; set; }
    }
}
