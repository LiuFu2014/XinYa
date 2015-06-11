using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.Model
{
    /// <summary>
    /// 用于承载返修区员工合格率
    /// </summary>
    class QualifiedRate_Fanxiu_Worker
    {
        public string 员工工号 { get; set; }
        public string 员工姓名 { get; set; }
        public int 维修总次数 { get; set; }
        public int 异常出现次数 { get; set; }

        /// <summary>
        /// 转为百分数并保留2位小数
        /// </summary>
        public string 返修合格率 { get; set; }
        public DateTime 开始时间 { get; set; }
        public DateTime 结束时间 { get; set; }
    }
}
