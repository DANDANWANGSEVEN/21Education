using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _21Education.WebSite.Controllers;
using _21Education.WebSite.Common;
namespace _21Education.WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "test",
            //    url: "{*a}",
            //    defaults: new { controller = "partview", action = "carousel", id = UrlParameter.Optional }
            //);

            //给指定页面注册路由
            RegisterRoutesWithRoute(
                routes,
                StringKeys.RouteValue_Page,
                new List<string>
                {
                    StringKeys.ActionFormatWithFullName(nameof(NewsController),nameof(NewsController.NewsList)),
                    StringKeys.ActionFormatWithFullName(nameof(SuccessController),nameof(SuccessController.SuccessList)),
                    StringKeys.ActionFormatWithFullName(nameof(ProductController),nameof(ProductController.ProductService))
                }
            );

            RegisterRoutesWithRoute(
                routes,
                StringKeys.RouteValue_Num,
                new List<string>
                {
                    StringKeys.ActionFormatWithFullName(nameof(NewsController),nameof(NewsController.NewsContent)),
                    StringKeys.ActionFormatWithFullName(nameof(SuccessController),nameof(SuccessController.SuccessContent)),
                    StringKeys.ActionFormatWithFullName(nameof(ProductController),nameof(ProductController.ProductContent))
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public static void RegisterRoutesWithRoute(RouteCollection routes, string matchKey, List<string> allowPages)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "controller",UrlParameter.Optional},{ "action",UrlParameter.Optional},{ matchKey,UrlParameter.Optional}
            };

            Route route = new Route("{controller}/{action}/{*" + matchKey + "}", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(dictionary),
                Constraints = new RouteValueDictionary(new
                {
                    p = new PageRouteConstraint(allowPages)
                }),
                DataTokens = new RouteValueDictionary()
            };
            route.DataTokens["Namespaces"] = typeof(NewsController).Namespace;
            routes.Add(route);
        }

    }
}