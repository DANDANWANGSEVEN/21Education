﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewsList()
        {
            return View();
        }
    }
}
