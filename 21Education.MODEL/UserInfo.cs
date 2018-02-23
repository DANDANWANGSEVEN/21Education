using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 后台用户信息
    /// </summary>
   public  class UserInfo
    {

        public int UserInfoId { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        public string ConfirmPwd { get; set; }

        public DateTime  RegistDate { get; set; }

        public int loginstates { get; set; }

    }
}
