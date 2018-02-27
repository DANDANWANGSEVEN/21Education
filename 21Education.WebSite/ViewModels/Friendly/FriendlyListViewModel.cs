using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21Education.DATA;
using _21Education.MODEL;

namespace _21Education.WebSite.ViewModels
{
    public class FriendlyListViewModel : PaginationViewModel<MODEL.FriendlyLink>
    {
        public FriendlyListViewModel(List<FriendlyLink> list) : base(list)
        {
        }

        public Pagination Pagination { set; get; }
    
    }
}