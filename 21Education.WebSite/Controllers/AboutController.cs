using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.MODEL;
using _21Education.IDAL;

namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 关于我们
    /// </summary>
    public class AboutController : Controller
    {
        //
        // GET: /About/
        IAboutCompanyCulture _companyculture;
        IAboutCompanyAchievementService _companyachievement;
        IAboutCompanyProfile _companyprofile;
        public AboutController(IAboutCompanyCulture companyculture, IAboutCompanyAchievementService companyachievement, IAboutCompanyProfile companyprofile)
        {
            _companyculture = companyculture;
            _companyachievement = companyachievement;
            _companyprofile = companyprofile;
        }


        public ActionResult AboutUs()
        {
            var viewModel = new ViewModels.HomeIndexViewModel
            {
                ProductShow = new DATA.CarouselViewModel(new List<DATA.CarouselBase>
                {
                    new Carousel{Describe="1",ImgPath="/image/honor1.jpg"},
                    new Carousel{Describe="2",ImgPath="/image/honor2.jpg"},
                    new Carousel{Describe="3",ImgPath="/image/honor3.jpg"},
                    new Carousel{Describe="4",ImgPath="/image/honor4.jpg"}
                })
                {
                    ImgWidth = 800,
                    ClassName = "HonorShow"
                }
            };
            //公司概况
            var compangprofile = _companyprofile.Get().OrderBy(e => e.AboutCompanyProfileId).ToList();
            ViewBag.compangprofileShow = compangprofile;

            //公司文化
            var companyculture = _companyculture.Get().OrderBy(e => e.AboutCompanyCultureId).ToList();
            ViewBag.companycultureShow = companyculture;

            //公司成就
            var companyachievement = _companyachievement.Get().OrderByDescending(e => e.AboutCompanyAchievementId).ToList();
            ViewBag.companyachievementShow = companyachievement;

            return View(viewModel);
        }


        public ActionResult aa()
        {
            return View();
        }

    }
}
