using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 公司文化
    /// </summary>
    public class AboutCompanyCulture : _21Education.IOC.IEntity
    {
        public int AboutCompanyCultureId { get; set; }
        /// <summary>
        /// 文化图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 文化描述
        /// </summary>
        public string desc { get; set; }

    }
}
