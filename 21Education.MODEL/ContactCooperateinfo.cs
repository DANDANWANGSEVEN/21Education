using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 联系我们——合作信息
    /// </summary>
   public  class ContactCooperateinfo
    {

        public int ID { get; set; }

        /// <summary>
        /// 合作图片
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
