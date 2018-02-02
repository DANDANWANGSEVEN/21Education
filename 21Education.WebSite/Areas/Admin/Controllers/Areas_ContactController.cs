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
    public class Areas_ContactController : Controller
    {
        //
        // GET: /Admin/Areas_Contact/

        public ActionResult Index()
        {
            return View();
        }

        #region 公司基本信息

        public ActionResult ContactCompanyinfo()
        {
            //var path = RouteData.GetPath();
            //var page = RouteData.GetPage();
            //return View(companyinfo());
            return View();
        }

        ContactCompanyinfo companyinfo()
        {
            var newsList = new List<MODEL.ContactCompanyinfo>();
            
                newsList.Add(new MODEL.ContactCompanyinfo
                {
                    ID = 1,
                    Address = "1111111",
                    Email = "111111",
                    Phone = "11111",
                    Transmission = "111111",
                    Website = "11111"
                });

            return new ContactCompanyinfo();
        }
        #endregion

    }
}
