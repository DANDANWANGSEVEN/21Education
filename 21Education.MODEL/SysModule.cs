using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _21Education.MODEL
{
    public class SysModule : _21Education.IOC.IEntity
    {
        [Key]
        public int MId { get; set; }
        [Display(Name = "树标题")]
        public string Id { get; set; }
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "英文名称")]
        public string EnglishName { get; set; }
        [Display(Name = "父编号")]
        public string ParentId { get; set; }
        [Display(Name = "地址")]
        public string Url { get; set; }
        [Display(Name = "图标")]
        public string Iconic { get; set; }
        [Display(Name = "排序")]
        public int Sort { get; set; }
        [Display(Name = "标记")]
        public string Remark { get; set; }
        [Display(Name = "状态")]
        public bool State { get; set; }
        [Display(Name = "创建人")]
        public string CreatePerson { get; set; }
        [Display(Name = "时间")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "菜单类型")]
        public bool IsLast { get; set; }
        [Display(Name = "版本")]
        public DateTime? Version { get; set; }




    }
}
