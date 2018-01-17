using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }
        #region 新闻列表页面
        public ActionResult NewsList()
        {
            return View();
        }
        #endregion

        #region 新闻内容页
        public ActionResult NewsContent()
        {
            return View();
        }
        #endregion



    }
}
