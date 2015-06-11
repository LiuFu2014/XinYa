using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XinYa.DAL;

namespace XinYa.Model
{
    /// <summary>
    /// 用于质量追踪时的质检记录模型类
    /// </summary>
    class QCRecordModelForQCTrack
    {
        /// <summary>
        /// 当前泵体条码
        /// </summary>
        public string MatCode { get; set; }

        /// <summary>
        /// 当前泵体条码所在的质检记录
        /// </summary>
        public TB_QCRecord QCRecord { get; set; }
    }
}
