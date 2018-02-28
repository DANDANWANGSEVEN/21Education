using System;
using System.Collections.Generic;
using _21Education.DATA;
namespace _21Education.WebSite.ViewModels
{
    public class NewsListViewModel : PaginationViewModel<MODEL.News>
    {
        public NewsListViewModel(List<MODEL.News> newsList) :base(newsList)
        {

        }
        public Pagination Pagination { set; get; }

        public FriendlyListViewModel FriendlyViewModel { get; set; }

    }
}