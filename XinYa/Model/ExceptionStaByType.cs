using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XinYa.Model
{
    /// <summary>
    /// 按类型异常统计
    /// </summary>
    class ExceptionStaByType
    {
        public string ExceptionCode { get; set; }
        public string ExceptionText { get; set; }
        public int Count { get; set; }
    }
}
