using System.Text.RegularExpressions;

namespace _21Education
{
    public class StringKeys
    {
        public const string RouteKey_Controller = "controller";
        public const string RouteKey_Action = "action";
        public const string RouteValue_Path = "path";
        public const string RouteValue_Page = "p";
        public const string RouteValue_Num = "n";

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

    public static class CustomRegex
    {
        public static Regex PageRegex = new Regex(@"/p(\d+)", RegexOptions.IgnoreCase);

    }

}
