using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int Id { get; set; }
        /// <summary>
        /// 文章介绍
        /// </summary>
        [Display(Name = "文章介绍")]
        public string Article { get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        [Display(Name = "发表人")]
        public string PublishedPerson { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime PublishedTime { get; set; }

    }
}
