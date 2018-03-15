using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 公司荣誉
    /// </summary>
    public class AboutCompanyHonor : _21Education.IOC.IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 荣誉证书图片
        /// </summary>
        [UIHint("FileUpload")]
        [Display(Name = "荣誉证书图片")]
        public string Image { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime? PublishedTime { get; set; }


    }
}
