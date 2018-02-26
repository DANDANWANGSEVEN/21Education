using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.WebSite.ViewModels;
using _21Education.DATA;
using System.Web.UI;
using _21Education.IDAL;
using System.Linq.Expressions;
using _21Education.MODEL;
namespace _21Education.WebSite.Controllers
{
    public class HomeController : Controller
    {
        IProduct _productService;
        INewsService _newsService;
        ISuccess _successService;
        IndexAdvantageIDAL _advantageService;
        IndexMainBusinessIDAL _mainbussinessService;
        public HomeController(IProduct productService,INewsService newsService,ISuccess successService, IndexAdvantageIDAL advantageService,IndexMainBusinessIDAL mainbussinessService)
        {
            _productService = productService;
            _newsService = newsService;
            _successService = successService;
            _advantageService = advantageService;
            _mainbussinessService = mainbussinessService;
        }
        [OutputCache(Duration = 600, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                //大轮播图
                Carousel = new CarouselViewModel(new List<DATA.CarouselBase>
                {
                    new CarouselBase{Describe="1",ImgPath="/image/index_ban1.png"},
                    new CarouselBase{Describe="2",ImgPath="/image/index_ban2.png"},
                    new CarouselBase{Describe="3",ImgPath="/image/index_ban3.png"},
                    new CarouselBase{Describe="4",ImgPath="/image/index_ban3.png"}
                })
                {
                    ImgWidth = 1000,
                    PreviewHtml = "<a href=\"javascript:;\" )><img src=\"{0}\" /></a>",
                    ClassName = "banner"
                },
                //产品展示轮播图
                //ProductShow = new CarouselViewModel(new List<DATA.CarouselBase>
                //{
                //    new CarouselBase{Describe="1",ImgPath="/image/index.V3/index_productservice_one.png"},
                //    new CarouselBase{Describe="2",ImgPath="/image/index.V3/index_productservice_two.png"},
                //    new CarouselBase{Describe="3",ImgPath="/image/index.V3/index_productservice_three.png"},
                //    new CarouselBase{Describe="4",ImgPath="/image/index.V3/index_productservice_four.png"},
                //    new CarouselBase{Describe="5",ImgPath="/image/index.V3/index_productservice_five.png"}
                //})
                //{
                //    ImgWidth = 235,
                //    ImgHeight = 140,
                //    ClassName = "productshow",
                //    ShowCount = 4,
                //    ImgMargin = 20
                //}
            };
            //产品服务
            var bussinessTitle = _mainbussinessService.Get().OrderBy(e => e.IndexMainBusinessId).ToList();
            ViewBag.bussinessTitleShow = bussinessTitle;

            //品牌优势
            var advantageList = _advantageService.Get().OrderBy(e => e.IndexAdvantageId).ToList();
            ViewBag.advantageListShow = advantageList;

            //首页新闻中心倒序显示五条
            var newsList = _newsService.Get().OrderByDescending(e=>e.NewsId).Take(5).ToList();
            ViewBag.NewsListShow = newsList;

            //首页成功案例倒序显示五条
            var successList = _successService.Get().OrderByDescending(e => e.SuccessId).Take(5).ToList();
            ViewBag.SuccessListShow = successList;


            return View(viewModel);
        }

    }
}
