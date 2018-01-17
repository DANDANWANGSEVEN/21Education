using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
namespace _21Education.COMMON
{
    public static class RouteDataExtend
    {
        public static string GetPath(this RouteData roteData)
        {
            if (roteData.Values.ContainsKey(StringKeys.RouteValue_Path))
            {
                return "/" + roteData.Values[StringKeys.RouteValue_Path].ToString();
            }
            return "/";
        }
        public static int GetPage(this RouteData roteData)
        {
            int page = 0;
            if (roteData.Values.ContainsKey(StringKeys.RouteValue_Page))
            {
                int.TryParse(roteData.Values[StringKeys.RouteValue_Page].ToString(), out page);
            }
            return page;
        }

    }
}
