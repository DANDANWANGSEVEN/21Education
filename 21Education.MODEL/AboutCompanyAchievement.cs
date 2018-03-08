using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _21Education.MODEL
{
    /// <summary>
    /// 公司成就
    /// </summary>
    public class AboutCompanyAchievement:_21Education.IOC.IEntity
    {
        //[Key]
        public int Id { get; set; }
        /// <summary>
        /// 成就图片
        /// </summary>
        [Display(Name = "成就图片")]
        public string Image { get; set; }
    }
}
