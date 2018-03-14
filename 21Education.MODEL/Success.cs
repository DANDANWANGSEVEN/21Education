using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "案例标题")]
        public string Title { get; set; }
        /// <summary>
        /// 案例内容
        /// </summary>
        [Display(Name = "案例内容")]
        public string Content { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime? PubDate { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        [Display(Name = "阅读量")]
        public int ReadCount { get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        [Display(Name = "发表人")]
        public string PubPerson { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [UIHint("FileUpload")]
        [Display(Name = "图片路径")]
        public string ImgPath { get; set; }


    }
}
