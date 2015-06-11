using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XinYa.DAL;

namespace XinYa.Model
{
    /// <summary>
    /// 员工工作记录中的扫描记录模型类
    /// </summary>
    class WorkDtlWithScanRecord
    {
        public TB_ScanRecord ScanRecord { get; set; }

        public string WorkTime { get; set; }
    }
}
