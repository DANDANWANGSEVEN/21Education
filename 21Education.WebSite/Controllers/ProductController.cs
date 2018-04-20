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
    /// 产品
    /// </summary>
    public class ProductController : Controller
    {
        IProduct _product;
        IndexAdvantageIDAL _advantageService;
        IProductAdvantange _productadvantage; //产品服务页面产品优势 IProductAdvantange productadvantage,
        IFriendlyLink _friendlylinkservice;
        public ProductController(IProduct product, IndexAdvantageIDAL advantageService, IFriendlyLink friendlylinkservice, IProductAdvantange productadvantage)
        {
            _product = product;
            _advantageService = advantageService;
            _friendlylinkservice = friendlylinkservice;
            _productadvantage = productadvantage;
        }

        #region  产品服务列表页
        public ActionResult ProductService(string id)
        {
            //获取产品服务名称
            var productTitle = _product.Get().OrderByDescending(e => e.Id).Take(12).ToList();
            ViewBag.productTitleShow = productTitle;

            ////品牌优势
            var productadvantageList = _productadvantage.Get().OrderByDescending(e => e.Id).Take(4).ToList();
            ViewBag.productadvantageListShow = productadvantageList;


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
            var pagin = new Pagination(pageIndex: page - 1, recordCount: _product.Count(null),pageSize:5);
            return new ProductsListViewModel(_product.Get().OrderBy(e => e.Id).Skip(pagin.PageIndex * pagin.PageSize).Take(pagin.PageSize).ToList())
            {
                Pagination = pagin
            };
        }

        #endregion

        #region 产品服务内容页
        public ActionResult ProductContent(int n)
        {
            try
            {
                var productList = _product.Get().ToList();
                Expression<Func<MODEL.Product, bool>> filter = e => e.Id == n;
                MODEL.Product productCurrent = _product.Get(filter).FirstOrDefault();
                productCurrent.ReadCount++;
                _product.Update(productCurrent);
                var currentIndex = productList.FindIndex(e => e.Id == productCurrent.Id);
                var prev = currentIndex==0?null: productList[currentIndex - 1];
                var next = currentIndex== _product.Count(null)-1?null: productList[currentIndex + 1];
                return View(new ProductsContentViewModel { ProductCurrent = productCurrent, ProductPrev = prev, ProductNext = next });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
