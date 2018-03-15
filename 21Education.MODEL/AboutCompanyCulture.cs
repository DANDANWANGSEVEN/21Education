using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }
        /// <summary>
        /// 文化图片
        /// </summary>
        [UIHint("FileUpload")]
        [Display(Name = "文化图片")]
        public string Image { get; set; }
        /// <summary>
        /// 文化描述
        /// </summary>
        [Display(Name = "文化描述")]
        public string desc { get; set; }

    }
}
