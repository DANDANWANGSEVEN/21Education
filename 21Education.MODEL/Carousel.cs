using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 首页轮播图
    /// </summary>
    public class Carousel
    {
        /// <summary>
        /// 轮播主键编号
        /// </summary>
        public int CarouselId { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string Describe { set; get; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PublishedTime { get; set; }
    }
}