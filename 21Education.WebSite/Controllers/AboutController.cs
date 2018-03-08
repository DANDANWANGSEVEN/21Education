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
        IAboutCompanyHonor _companyhonor;
        public AboutController(IAboutCompanyCulture companyculture, IAboutCompanyAchievementService companyachievement, IAboutCompanyProfile companyprofile, IAboutCompanyHonor companyhonor)
        {
            _companyculture = companyculture;
            _companyachievement = companyachievement;
            _companyprofile = companyprofile;
            _companyhonor = companyhonor;
        }


        public ActionResult AboutUs()
        {
            var carouselList= new List<DATA.CarouselBase>();
            //公司荣誉
            var companyhonorList = _companyhonor.Get().OrderByDescending(e => e.Id).ToList();
            companyhonorList.ForEach(e => { carouselList.Add(new DATA.CarouselBase { ImgPath = e.Image }); });

            var viewModel = new ViewModels.HomeIndexViewModel
            {
                HonorShow = new DATA.CarouselViewModel(carouselList)
                {
                    ImgWidth = 800,
                    ClassName = "HonorShow"
                }
            };
            //公司概况
            var compangprofile = _companyprofile.Get().OrderBy(e => e.Id).FirstOrDefault();
            ViewBag.compangprofileShow = compangprofile.Article;


            //公司文化
            var companyculture = _companyculture.Get().OrderBy(e => e.Id).ToList();
            ViewBag.companycultureShow = companyculture;

            //公司成就
            var companyachievement = _companyachievement.Get().OrderByDescending(e => e.Id).ToList();
            ViewBag.companyachievementShow = companyachievement;

            return View(viewModel);
        }


        public ActionResult aa()
        {
            return View();
        }

    }
}
