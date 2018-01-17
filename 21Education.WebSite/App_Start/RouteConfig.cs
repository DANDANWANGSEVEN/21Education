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

            routes.MapRoute(
                name: "PageRoute",
                url: "{*path}",
                defaults: new { path = UrlParameter.Optional },
                constraints: new { path = new PageRouteConstraint() },
                namespaces: new[] { typeof(NewsController).Namespace }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }

    }
}