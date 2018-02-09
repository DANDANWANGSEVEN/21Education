using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_SuccessController : Controller
    {
        //
        // GET: /Admin/Areas_Success/

        public ActionResult Index()
        {
            return View();
        }

    }
}
