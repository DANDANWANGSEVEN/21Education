using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.MODEL;
namespace _21Education.WebSite.ViewModels
{
    public class NewsContentViewModel
    {
        public News NewsCurrent { set; get; }
        public News NewsPrev { set; get; }
        public News NewsNext { set; get; }
    }
}