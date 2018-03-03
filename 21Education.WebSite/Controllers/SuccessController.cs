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
    /// 成功案例
    /// </summary>
    public class SuccessController : Controller
    {
        //
        // GET: /Success/

        ISuccess _successService;
        IFriendlyLink _friendlylinkservice;
        IProduct _product;
        public SuccessController(ISuccess successService,IFriendlyLink friendlylinkservice, IProduct product)
        {
            _successService = successService;
            _friendlylinkservice = friendlylinkservice;
            _product = product;
        }

        public ActionResult Index()
        {
            return View();
        }
        #region 成功案例列表页面
        public ActionResult SuccessList()
        {
            var path = RouteData.GetPath();
            var page = RouteData.GetPage();
            return View(SuccessListTest(page));
        }
        SuccessListViewModel SuccessListTest(int page)
        {
            //var newsList = new List<MODEL.News>();
            //for (int i = 0; i < 300; i++)
            //{
            //    newsList.Add(new MODEL.News
            //    {
            //        NewsId = i,
            //        Title = "成功案例标题" + i,
            //        Content = "成功案例内容成功案例内容成功案例内容成功案例容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容成功案例内容",
            //        ImgPath = "/image/pcpj.jpg",
            //        PubDate = DateTime.Now,
            //        ReadCount = 100
            //    });
            //}
            var pagin = new Pagination(pageIndex: page - 1, recordCount: _successService.Count(null), pageSize: 6);
            return new SuccessListViewModel(_successService.Get().OrderBy(e => e.SuccessId).Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin,
                FriendlyViewModel = new FriendlyListViewModel { friendlylinks = _friendlylinkservice.Get().OrderBy(e => e.FriendlyLinkId).ToList(), products = _product.Get().OrderBy(e => e.ProductId).Take(8).ToList() }

            };
        }
        #endregion


        #region 成功案例内容页面
        public ActionResult SuccessContent(int n)
        {
            var successList = _successService.Get().ToList();
            Expression<Func<MODEL.Success, bool>> filter = e => e.SuccessId == n;
            MODEL.Success successCurrent = _successService.Get(filter).FirstOrDefault();
            var currentIndex = successList.FindIndex(e => e.SuccessId == successCurrent.SuccessId);
            var prev = successList[currentIndex - 1];
            var next = successList[currentIndex + 1];
            return View(new SuccessContentViewModel { CurrentSuccess=successCurrent,PrevSuccess=prev,NextSuccess=next});
        }
        #endregion


    }
}
