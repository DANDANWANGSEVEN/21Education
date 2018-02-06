using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
	/// <summary>
    /// 公司基本信息
    /// </summary>
    public class ContactCompanyinfo
    {
        public int ContactCompanyinfoId { get; set; }

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
