using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 成功案例
    /// </summary>
    public  class Success : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 案例编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 案例标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 案例内容
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
