using System.Web;
using System.Web.Optimization;

namespace _21Education.WebSite
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                            "~/Content/Areasjs/common.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                       "~/Areas/Content/Scripts/home.js"));
            bundles.Add(new ScriptBundle("~/bundles/account").Include(
                       "~/Areas/Content/Scripts/Account.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfrom").Include(
                        "~/Areas/Content/Scripts/jquery.form.js"));

            bundles.Add(new ScriptBundle("~/bundles/easyuiplus").Include(
                        "~/Areas/Content/Scripts/jquery.easyui.plus.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Areas/Content/Scripts/jquery.validate.unobtrusive.plus.js"));

            bundles.Add(new ScriptBundle("~/bundles/EasyUIBtn").Include(
            "~/Areas/Content/Scripts/easyui.btn.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Areas/Content/css").Include("~/Areas/Content/site.css"));

            bundles.Add(new StyleBundle("~/Areas/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Areas/Content/css").Include("~/Areas/Content/site.css"));

            //easyui
            bundles.Add(new StyleBundle("~/Areas/Content/themes/blue/css").Include("~/Areas/Content/themes/blue/easyui.css"));
            bundles.Add(new StyleBundle("~/Areas/Content/themes/gray/css").Include("~/Areas/Content/themes/gray/easyui.css"));
            bundles.Add(new StyleBundle("~/Areas/Content/themes/metro/css").Include("~/Areas/Content/themes/metro/easyui.css"));

        }



        }
}