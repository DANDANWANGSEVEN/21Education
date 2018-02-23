using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _21Education.WebSite.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "AdminHome", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public static Dictionary<Guid, string> userDic;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var requestCookies = filterContext.RequestContext.HttpContext.Request.Cookies;
            if (requestCookies["UserCookie"] == null) { 
                filterContext.HttpContext.Response.Redirect("/AdminHome");
            }
            var guidUName = Guid.Parse(requestCookies["UserCookie"].Value);
            var userNameDic = "";
            userDic.TryGetValue(guidUName, out userNameDic);

            if (requestCookies[userNameDic] == null)
                filterContext.HttpContext.Response.Redirect("/AdminHome");
        }
    }


     /// <summary>
     /// 需要登录才能进行操作
     /// </summary>
     public class PermissionRequiredAttribute : ActionFilterAttribute
     {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
         {
             if (filterContext.HttpContext.Session["User"]==null)
             {
                 filterContext.Result = new RedirectResult("~/Admin/Account/Login");
             }
             base.OnActionExecuting(filterContext);
         }
     }




}
