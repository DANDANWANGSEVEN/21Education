using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 招聘信息
    /// </summary>
   public  class ContactRecruitInfo : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 招聘信息主键
        /// </summary>
        public int ContactRecruitInfoId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 合作名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 合作内容
        /// </summary>
        public string Content { get; set; }


    }
}
