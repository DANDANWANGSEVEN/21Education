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
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (parameterName == StringKeys.RouteValue_Path)
            {
                string path = "/" + values[StringKeys.RouteValue_Path].ToString();
                int page = 0;
                if (CustomRegex.PageRegex.IsMatch(path))
                {
                    string scheam = "";
                    path = CustomRegex.PageRegex.Replace(path, evaluator =>
                    {
                        int.TryParse(evaluator.Groups[1].Value, out page);
                        scheam = evaluator.Groups[2].Value;
                        return "";
                    });
                    if (!string.IsNullOrEmpty(scheam)) path = path.Replace(scheam, "");
                    if (page == 0) page = 1;
                    values.Add(StringKeys.RouteValue_Page, page);
                }

                if (IsAllowPage(path))
                {

                    values[parameterName] = path;
                    return true;
                }
            }
            return false;
        }

        public bool IsAllowPage(string path)
        {
            if (AllowPages.Any(e => { return e == path.ToLower(); }))
                return true;
            return false;
        }
        List<string> AllowPages = new List<string>
        {
            actionFormatWithFullName(nameof(NewsController), nameof(NewsController.NewsList)),
            actionFormatWithFullName(nameof(ProductController), nameof(ProductController.Index))
        };

        static Func<string, string, string> actionFormatWithFullName = (controller, action) =>
        {
            return StringKeys.ActionFormatWithFullName(controller, action);
        };

    }
}
