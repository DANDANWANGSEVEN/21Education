using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 主营业务
    /// </summary>
    public class IndexMainBusiness : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 业务编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 业务名称
        /// </summary>
        [Display(Name = "业务名称")]
        public string BusinessName { get; set; }
        /// <summary>
        /// 业务描述
        /// </summary>
        [Display(Name = "业务描述")]
        public string BusinessDesc { get; set; }
        /// <summary>
        /// 业务文章
        /// </summary>
        [Display(Name = "业务文章")]
        public string BusinessContent { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public string PubTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        public string Image { get; set; }


    }
}
