using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using _21Education.DATA;
namespace _21Education.COMMON
{
    public static class HtmlHelperExtend
    {
        public static void Pagin(this HtmlHelper html, Pagination pagin)
        {
            html.RenderPartial(@"~/Views/PartView/Partial.Pagination.cshtml", pagin);
        }
    
    }
}
