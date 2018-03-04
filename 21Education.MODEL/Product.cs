using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 产品列表
    /// </summary>
    public class Product : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 产品内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime PubDate { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        public string PubPerson { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath { get; set; }
        
    }
}