using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Education.COMMON
{
    public class UrlHelperExtend
    {
        public static string Page(this IUrlHelper helper, int pageIndex)
        {
            var category = helper.ActionContext.RouteData.GetCategory();
            if (category > 0)
            {
                return helper.ActionContext.RouteData.GetPath() +
                    "/" + StringKeys.PathFormat(StringKeys.RouteValue_Category) + category +
                    "/" + StringKeys.PathFormat(StringKeys.RouteValue_Page) + pageIndex;
            }
            return helper.ActionContext.RouteData.GetPath() + "/" + StringKeys.PathFormat(StringKeys.RouteValue_Page) + pageIndex;
        }

    }
}
