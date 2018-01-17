using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 产品
    /// </summary>
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductService()
        {
            return View();
        }
    }
}
