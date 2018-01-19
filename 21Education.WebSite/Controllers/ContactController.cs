using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        #region 联系我们页面
        public ActionResult ContactUs()
        {
            return View();
        }
        #endregion

        #region 招聘信息页面
        public ActionResult JoinUs()
        {
            return View();
        }
        #endregion

    }
}
