using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.DATA
{
    public class CarouselBase
    {
        /// <summary>
        /// 轮播主键编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        [Display(Name = "图片路径")]
        public string ImgPath { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        [Display(Name = "图片描述")]
        public string Describe { set; get; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime PublishedTime { get; set; }
    }

}
