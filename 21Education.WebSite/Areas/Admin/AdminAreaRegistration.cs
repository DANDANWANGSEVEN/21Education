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
        public static Dictionary<string, string> userDic=new Dictionary<string, string>();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var requestCookies = filterContext.RequestContext.HttpContext.Request.Cookies;
            ActionDescriptor arg_34_0 = filterContext.ActionDescriptor;
            bool inherit = true;
            bool arg_5B_0;
            if (!arg_34_0.IsDefined(typeof(AllowAnonymousAttribute), inherit))
            {
                ControllerDescriptor arg_53_0 = filterContext.ActionDescriptor.ControllerDescriptor;
                bool inherit2 = true;
                arg_5B_0 = arg_53_0.IsDefined(typeof(AllowAnonymousAttribute), inherit2);
            }
            else
            {
                arg_5B_0 = true;
            }
            bool flag = arg_5B_0;
            if (flag)
            {
                if (requestCookies["UserCookie"] != null)
                {

                    if (requestCookies[userDic[requestCookies["UserCookie"].Value]] != null)
                    {
                        filterContext.HttpContext.Response.Redirect("/admin/adminhome/index");
                        filterContext.HttpContext.ApplicationInstance.CompleteRequest();

                    }
                }
                return;
            }
            if (requestCookies["UserCookie"] == null) {
                filterContext.HttpContext.Response.Redirect("/admin");
                filterContext.HttpContext.ApplicationInstance.CompleteRequest();
                return;
            }
            var guidUName = requestCookies["UserCookie"].Value;
            var userNameDic = "";
            userDic.TryGetValue(guidUName, out userNameDic);

            if (requestCookies[userNameDic] == null) {
                filterContext.HttpContext.Response.Redirect("/admin");
                filterContext.HttpContext.ApplicationInstance.CompleteRequest();
                return;
            }

           
        }
    }
}
