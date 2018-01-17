using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.COMMON
{
    public class StringKeys
    {
        public const string RouteKey_Controller = "controller";
        public const string RouteKey_Action = "action";
        public const string RouteValue_Path = "path";
        public const string RouteValue_Page = "p";
        
        public static string PageFormat(string routeKey, int page)
        {
            return string.Format("{0}{1}", routeKey, page);
        }

        public static string ActionFormat(string controller, string action)
        {
            return string.Format("/{0}/{1}", controller, action);
        }
        public static string ActionFormatWithFullName(string controllerFullName, string actionFullName)
        {
            return string.Format("/{0}/{1}", controllerFullName.ToLower().Replace("controller", ""), actionFullName).ToLower();
        }

    }
}
