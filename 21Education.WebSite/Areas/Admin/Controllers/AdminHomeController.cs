using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Admin/AdminHome/

        #region  登陆界面
        public ActionResult Index()
        {
            return View();
        }
       
        #endregion

        #region 默认界面
        public ActionResult Home()
        {
            return View();
        }
        #endregion


    }
}
