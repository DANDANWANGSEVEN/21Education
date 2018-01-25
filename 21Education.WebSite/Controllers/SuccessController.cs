using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;

namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 成功案例
    /// </summary>
    public class SuccessController : Controller
    {
        //
        // GET: /Success/

        public ActionResult Index()
        {
            return View();
        }
        #region 成功案例列表页面
        public ActionResult SuccessList()
        {
            var path = RouteData.GetPath();
            var page = RouteData.GetPage();
            return View(NewsListTest(page));
        }
        NewsListViewModel NewsListTest(int page)
        {
            var newsList = new List<MODEL.News>();
            for (int i = 0; i < 300; i++)
            {
                newsList.Add(new MODEL.News
                {
                    NewsId = i,
                    Title = "成功案例标题" + i,
                    Content = "成功案例内容成功案例内容成功案例内容成功案例容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容",
                    ImgPath = "/image/pcpj.jpg",
                    PubDate = DateTime.Now,
                    ReadCount = 100
                });
            }
            var pagin = new Pagination(pageIndex: page - 1, recordCount: newsList.Count(), pageSize: 8);
            return new NewsListViewModel(newsList.Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin
            };
        }
        #endregion


        #region 成功案例内容页面
        public ActionResult SuccessContent()
        {
            return View();
        }
        #endregion


    }
}
