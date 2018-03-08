using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 后台用户信息
    /// </summary>
   public  class UserInfo : _21Education.IOC.IEntity
    {

        public int Id { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string UserPwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "确认密码不能为空")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "时间")]
        public DateTime?  RegistDate { get; set; }

        [Display(Name = "登陆状态")]
        public int loginstates { get; set; }

    }
}
