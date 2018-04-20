﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.MODEL
{
    /// <summary>
    /// 招聘信息
    /// </summary>
   public  class ContactRecruitInfo : _21Education.IOC.IEntity
    {
        /// <summary>
        /// 招聘信息主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [UIHint("FileUpload")]
        [Display(Name = "图片")]
        public string Image { get; set; }
        /// <summary>
        /// 合作名称
        /// </summary>
        [Display(Name = "招聘名称")]
        public string Name { get; set; }
        /// <summary>
        /// 合作内容
        /// </summary>
        [Display(Name = "招聘简介")]
        public string Content { get; set; }


    }
}
