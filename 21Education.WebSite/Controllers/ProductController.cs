using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;
using _21Education.IDAL;
namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 产品
    /// </summary>
    public class ProductController : Controller
    {
        IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductService(string id)
        {
            var path = RouteData.GetPath();
            var page = RouteData.GetPage();
            return View(ProductsListTest(page));
        }


        ProductsListViewModel ProductsListTest(int page)
        {
            //var newsList = new List<MODEL.News>();
            //for (int i = 0; i < 30; i++)
            //{
            //    newsList.Add(new MODEL.News
            //    {
            //        NewsId = i,
            //        Title = "产品" + i,
            //        Content = "产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述产品描述",
            //        ImgPath = "/image/about_14.jpg",
            //        PubDate = DateTime.Now,
            //        ReadCount = 300
            //    });
            //}
            var pagin = new Pagination(pageIndex: page - 1, recordCount: _product.Count(null),pageSize:4);
            return new ProductsListViewModel(_product.Get().OrderBy(e=>e.ProductId).Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin
            };
        }
    }
}
