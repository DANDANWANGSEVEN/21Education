using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.DATA;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class AdvantageListViewModel : PaginationViewModel<MODEL.IndexAdvantage>
    {
        public AdvantageListViewModel(List<IndexAdvantage> list) : base(list)
        {
        }
        public Pagination Pagination { set; get; }
    }
}