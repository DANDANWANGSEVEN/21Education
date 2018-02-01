using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 职位信息
    /// </summary>
    public  class ContactPositionInfo
    {
        /// <summary>
        /// 主键编号
        /// </summary>
        public int PositionID { get; set; }
        /// <summary>
        /// 条件 职位人数/薪资
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 职位描述
        /// </summary>
        public string PositionDesc { get; set; }
        /// <summary>
        /// 职位要求
        /// </summary>
        public string PositionRequirement{ get; set; }
        /// <summary>
        /// 发表人
        /// </summary>
        public string PublishedPerson { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime  PublishedTime { get; set; }
    }
}
