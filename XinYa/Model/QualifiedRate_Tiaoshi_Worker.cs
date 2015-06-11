using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.Model
{
    /// <summary>
    /// 调试员工合格率model
    /// </summary>
    class QualifiedRate_Tiaoshi_Worker
    {
        public string 员工工号 { get; set; }
        public string 员工姓名 { get; set; }
        public int QC总数 { get; set; }
        public int QC不合格数 { get; set; }
        /// <summary>
        /// 保留两位小数+%显示
        /// </summary>
        public string 调试合格率 { get; set; }
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
    }
}
