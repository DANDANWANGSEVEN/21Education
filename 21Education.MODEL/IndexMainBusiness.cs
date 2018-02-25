using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 主营业务
    /// </summary>
    public class IndexMainBusiness : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 业务编号
        /// </summary>
        public int IndexMainBusinessId { get; set; }
        /// <summary>
        /// 业务名称
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 业务描述
        /// </summary>
        public string BusinessDesc { get; set; }
        /// <summary>
        /// 业务文章
        /// </summary>
        public string BusinessContent { get; set; }
        
        /// <summary>
        /// 发表时间
        /// </summary>
        public string PubTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }


    }
}
