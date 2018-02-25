using System;
using System.Collections.Generic;
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
        public int AboutCompanyAchievementId { get; set; }
        /// <summary>
        /// 成就图片
        /// </summary>
        public string Image { get; set; }
    }
}
