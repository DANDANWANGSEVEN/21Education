using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _21Education.MODEL
{
    /// <summary>
    /// 产品服务页面——产品优势
    /// </summary>
    public  class ProductAdvantage : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 产品优势
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 优势标题
        /// </summary>
        [Display(Name = "优势标题")]
        public string Title { get; set; }
        /// <summary>
        /// 优势描述
        /// </summary>
        [Display(Name = "优势描述")]
        public string desc { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime? PubTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [UIHint("FileUpload")]
        [Display(Name = "图片")]
        public string ImageOne { get; set; }
        /// <summary>
        /// 其他页图片
        /// </summary>
        //[UIHint("FileUpload")]
        //[Display(Name = "其他页图片")]
        //public string ImageTwo { get; set; }

    }
}
