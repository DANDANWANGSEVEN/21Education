using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 公司概况
    /// </summary>
    public class AboutCompanyProfile : _21Education.IOC.IEntity
    {

        public int AboutCompanyProfileId { get; set; }
        /// <summary>
        /// 文章介绍
        /// </summary>
        public string Article { get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        public string PublishedPerson { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PublishedTime { get; set; }

    }
}
