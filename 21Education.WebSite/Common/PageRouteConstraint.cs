using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using _21Education.COMMON;
using _21Education.WebSite.Controllers;
namespace _21Education.WebSite.Common
{
    public class PageRouteConstraint : IRouteConstraint
    {
        List<string> AllowPages;
        public PageRouteConstraint(List<string> allowPages)
        {
            AllowPages = allowPages;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var controller = values[StringKeys.RouteKey_Controller].ToString();
            var action = values[StringKeys.RouteKey_Action].ToString();

            if (IsAllowPage(controller, action))
            {
                string path = httpContext.Request.Path;
                int page = 0;
                if (CustomRegex.PageRegex.IsMatch(path))
                {
                    path = CustomRegex.PageRegex.Replace(path, evaluator =>
                    {
                        int.TryParse(evaluator.Groups[1].Value, out page);
                        return "";
                    });
                }
                if (page == 0) page = 1;
                values[parameterName] = page;
                values.Add(StringKeys.RouteValue_Path, path);
                return true;
            }
            return false;
        }

        public bool IsAllowPage(string controller, string action)
        {
            if (AllowPages.Any(e => { return e == StringKeys.ActionFormatWithFullName(controller, action); }))
                return true;
            return false;
        }

    }
}
