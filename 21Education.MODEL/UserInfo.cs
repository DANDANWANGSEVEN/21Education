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

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public DateTime  RegistDate { get; set; }

    }
}
