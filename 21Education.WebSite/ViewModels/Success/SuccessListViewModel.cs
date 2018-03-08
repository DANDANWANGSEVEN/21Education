using _21Education.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class SuccessListViewModel : PaginationViewModel<MODEL.Success>
    {
        public SuccessListViewModel(List<Success> list) : base(list)
        {
        }
        public Pagination Pagination { set; get; }
        public FriendlyListViewModel FriendlyViewModel { get; set; }

    }
}