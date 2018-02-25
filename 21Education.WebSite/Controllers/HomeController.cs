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
        IProduct _product;
        INewsService _newsService;
        public HomeController(IProduct product,INewsService newsService)
        {
            _product = product;
            _newsService = newsService;
        }
        [OutputCache(Duration = 600, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
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
                ProductShow = new CarouselViewModel(new List<DATA.CarouselBase>
                {
                    new CarouselBase{Describe="1",ImgPath="/image/index.V3/index_productservice_one.png"},
                    new CarouselBase{Describe="2",ImgPath="/image/index.V3/index_productservice_two.png"},
                    new CarouselBase{Describe="3",ImgPath="/image/index.V3/index_productservice_three.png"},
                    new CarouselBase{Describe="4",ImgPath="/image/index.V3/index_productservice_four.png"},
                    new CarouselBase{Describe="5",ImgPath="/image/index.V3/index_productservice_five.png"}
                })
                {
                    ImgWidth = 235,
                    ImgHeight = 140,
                    ClassName = "productshow",
                    ShowCount = 4,
                    ImgMargin = 20
                }
            };
            var productList = _product.Get().OrderByDescending(e=>e.ProductId).Take(5).ToList();
            return View(viewModel);
        }

    }
}
