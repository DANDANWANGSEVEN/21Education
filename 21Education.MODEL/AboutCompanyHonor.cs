using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 公司荣誉
    /// </summary>
    public class AboutCompanyHonor
    {
        public int AboutCompanyHonorId { get; set; }

        /// <summary>
        /// 荣誉证书图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PublishedTime { get; set; }


    }
}
