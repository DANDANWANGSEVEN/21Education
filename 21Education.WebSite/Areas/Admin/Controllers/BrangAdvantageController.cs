using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21Education.MVC;
using _21Education.MODEL;
using _21Education.IDAL;
namespace _21Education.WebSite.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class BrangAdvantageController : BasicController<IndexAdvantage, IndexAdvantageIDAL>
    {
        public BrangAdvantageController(IndexAdvantageIDAL service) : base(service)
        {
        }
    }
}
