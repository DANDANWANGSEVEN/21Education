using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 品牌优势
    /// </summary>
    public class IndexAdvantage : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 品牌优势编号
        /// </summary>
        public int IndexAdvantageId { get; set; }

        /// <summary>
        /// 优势标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 优势描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PubTime { get; set; }
        /// <summary>
        /// 首页图片
        /// </summary>
        public string ImageOne { get; set; }
        /// <summary>
        /// 其他页图片
        /// </summary>
        public string ImageTwo { get; set; }

    }
}
