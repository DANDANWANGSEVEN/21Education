using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
	/// <summary>
    /// 公司基本信息
    /// </summary>
    public class ContactCompanyinfo : _21Education.IOC.IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        [Display(Name = "公司地址")]
        public string Address { get; set; }
        /// <summary>
        /// 公司邮编
        /// </summary>
        [Display(Name = "公司邮编")]
        public string Email { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        [Display(Name = "公司电话")]
        public string  Phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Display(Name = "传真")]
        public string Transmission { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        [Display(Name = "网址")]
        public string Website { get; set; }


    }
}
