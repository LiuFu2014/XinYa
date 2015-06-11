using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.Model
{
    /// <summary>
    /// 用于承载指定型号的装配合格率
    /// </summary>
    class QualifiedRate_Zhuangpei_Mat
    {
        public string 物料型号 { get; set; }

        public int 装配总数 { get; set; }

        public int 异常数 { get; set; }

        /// <summary>
        /// 请在计算后将结果*100+%转成string,要求保留2位小数
        /// </summary>
        public string 合格率 { get; set; }

        public string 统计装配线号 { get; set; }

        /// <summary>
        /// 指统计数据来源，ABC号线
        /// </summary>
        public string 统计基础 { get; set; }

        public DateTime 开始时间 { get; set; }

        public DateTime 结束时间 { get; set; }
    }
}
