using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.COMMON;
using _21Education.DATA;
using _21Education.WebSite.ViewModels;


namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class Areas_HomeController : Controller
    {
        //
        // GET: /Admin/Areas_Home/

        public ActionResult Index()
        {
            return View();
        }
        #region 首页轮播图
        public ActionResult Carousel()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }
        #endregion

        public ActionResult tpage()
        {
            return View();
        }


    }
}
