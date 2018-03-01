using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;
using _21Education.IDAL;
using System.Linq.Expressions;

namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    public class NewsController : Controller
    {
        INewsService _newsService;
        IFriendlyLink _friendlylinkservice;
        IProduct _productService;
        public NewsController(INewsService newsService, IFriendlyLink friendlylinkservice,IProduct productService)
        {
            _newsService = newsService;
            _friendlylinkservice = friendlylinkservice;
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View();
        }
        #region 新闻列表页面
        public ActionResult NewsList(string id)
        {
            var path = RouteData.GetPath();
            var page = RouteData.GetPage();
            return View(NewsListByPager(page));
        }

        NewsListViewModel NewsListByPager(int page)
        {
            var pagin = new Pagination(pageIndex: page - 1, recordCount: _newsService.Count(null), pageSize: 6);
            return new NewsListViewModel(_newsService.Get().OrderBy(e => e.NewsId).Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin,
                FriendlyViewModel=new FriendlyListViewModel { friendlylinks= _friendlylinkservice.Get().OrderBy(e=>e.FriendlyLinkId).ToList(), products= _productService .Get().OrderBy(e=>e.ProductId).Take(8).ToList()}
            };
        }
        #endregion

        #region 新闻内容页
        public ActionResult NewsContent(/*Expression<Func<MODEL.News, bool>> filter*/)
        {
            //IList<MODEL.News> newspecialinfo = _newsService.
            //var newsinfo= Where(filter).FirstOrDefault();
            return View();
        }
        


        #endregion



    }
}
