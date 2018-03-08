using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 导航列表
    /// </summary>
    public class Nav : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 导航编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 导航标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 导航链接
        /// </summary>
        public string Link { get; set; }


    }
}
