using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.DATA;

namespace _21Education.WebSite.ViewModels
{
	/// <summary>
    /// 公司基本信息
    /// </summary>
    public class ContactCompanyinfo
    {
        public int ID { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }
		/// <summary>
        /// 公司邮编
        /// </summary>
        public string Email { get; set; }
		/// <summary>
        /// 公司电话
        /// </summary>
        public string  Phone { get; set; }
		/// <summary>
        /// 传真
        /// </summary>
        public string Transmission { get; set; }
		/// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; }


    }
}
