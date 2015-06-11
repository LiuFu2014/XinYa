using System;

namespace XinYa.Model
{
    /// <summary>
    /// 用于承载装配线合格率-按装配线统计
    /// </summary>
    internal class QualifiedRate_Zhuangpei_LineNum
    {
        public string 装配线号 { get; set; }

        public int 装配总数 { get; set; }

        public int 异常总数 { get; set; }

        /// <summary>
        /// 请在计算后将结果*100+%转成string,要求保留2位小数
        /// </summary>
        public string 合格率 { get; set; }

        public DateTime 开始时间 { get; set; }

        public DateTime 结束时间 { get; set; }
    }
}