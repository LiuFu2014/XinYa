using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.Model
{
    /// <summary>
    /// 工时模型类，用于工时统计
    /// </summary>
    class WorkerTime
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string workNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string workName { get; set; }

        /// <summary>
        /// 工时统计
        /// </summary>
        public decimal workTime { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime beginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endTime { get; set; }
    }
}
