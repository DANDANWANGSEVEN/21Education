using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 友情链接
    /// </summary>
    public  class FriendlyLink : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 友情链接编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 友情链接
        /// </summary>
        [Display(Name = "友情链接")]
        public string FriendlyTitle { get; set; }

        /// <summary>
        /// 友情链接地址
        /// </summary>
        [Display(Name = "友情链接地址")]
        public string FriendlyUrl { get; set; }


    }
}
