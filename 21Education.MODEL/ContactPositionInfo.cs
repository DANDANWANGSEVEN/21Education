using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 职位信息
    /// </summary>
    public  class ContactPositionInfo : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 条件 职位人数/薪资
        /// </summary>
        [Display(Name = "条件")]
        public string Condition { get; set; }
        /// <summary>
        /// 职位描述
        /// </summary>
        [Display(Name = "职位描述")]
        public string PositionDesc { get; set; }
        /// <summary>
        /// 职位要求
        /// </summary>
        [Display(Name = "职位要求")]
        public string PositionRequirement{ get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        [Display(Name = "发表人")]
        public string PublishedPerson { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Display(Name = "发表时间")]
        public DateTime?  PublishedTime { get; set; }
    }
}
