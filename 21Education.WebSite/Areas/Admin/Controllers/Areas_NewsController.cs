using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.WebSite.ViewModels;
using _21Education.MODEL;
using _21Education.WebSite.Handler;
using _21Education.IDAL;
using _21Education.MVC;

namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class Areas_NewsController : BasicController<News, INewsService>
    {
        public Areas_NewsController(INewsService service) : base(service)
        {
        }
    }
}
