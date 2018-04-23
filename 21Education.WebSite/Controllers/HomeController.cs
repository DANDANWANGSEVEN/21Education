﻿using System;
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
        ICarousel _carouselService;
        IProduct _productService;
        INewsService _newsService;
        ISuccess _successService;
        IndexAdvantageIDAL _advantageService;
        IndexMainBusinessIDAL _mainbussinessService;
        public HomeController(ICarousel carouselService,IProduct productService,INewsService newsService,ISuccess successService, IndexAdvantageIDAL advantageService,IndexMainBusinessIDAL mainbussinessService)
        {
            _carouselService = carouselService;
            _productService = productService;
            _newsService = newsService;
            _successService = successService;
            _advantageService = advantageService;
            _mainbussinessService = mainbussinessService;
        }
        [OutputCache(Duration = 600, Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            var carouselList = new List<DATA.CarouselBase>();
            var indexcarouselist= _carouselService.Get().OrderByDescending(e => e.Id).ToList();
            indexcarouselist.ForEach(e => { carouselList.Add(new DATA.CarouselBase { ImgPath = e.ImgPath }); });

            var viewModel = new HomeIndexViewModel
            {
                //大轮播图
                //{
                //    new CarouselBase{Describe="1",ImgPath="/image/index_ban1.png"},
                //    new CarouselBase{Describe="2",ImgPath="/image/index_ban2.png"},
                //    new CarouselBase{Describe="3",ImgPath="/image/index_ban3.png"},
                //    new CarouselBase{Describe="4",ImgPath="/image/index_ban3.png"}
                //})
                Carousel = new DATA.CarouselViewModel(carouselList)
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
            var bussinessTitle = _mainbussinessService.Get().OrderByDescending(e => e.Id).Take(7).ToList();
            ViewBag.bussinessTitleShow = bussinessTitle;

            //品牌优势
            var advantageList = _advantageService.Get().OrderByDescending(e => e.Id).Take(4).ToList();
            ViewBag.advantageListShow = advantageList;

            //首页新闻中心倒序显示五条
            var newsList = _newsService.Get().OrderByDescending(e=>e.Id).Take(5).ToList();
            ViewBag.NewsListShow = newsList;

            //首页成功案例倒序显示五条
            var successList = _successService.Get().OrderByDescending(e => e.Id).Take(5).ToList();
            ViewBag.SuccessListShow = successList;

            return View(viewModel);
        }


        public ActionResult kindeditor()
        {
            return View();
        }



    }
}
