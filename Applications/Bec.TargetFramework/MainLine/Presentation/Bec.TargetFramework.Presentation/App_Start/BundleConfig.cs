using System.Web;
using System.Web.Optimization;

namespace Bec.TargetFramework.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);
            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Libs/Vendor/jQuery/jquery-{version}.js",
                "~/Scripts.Libs.Vendor/jQuery/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-validate").Include(
                "~/Scripts/Libs/Vendor/jQuery/jquery.validate.min.js",
                "~/Scripts/Libs/Vendor/jQuery/jquery.validate.unobtrusive.min.js",
                "~/Scripts/Libs/Vendor/jQuery/jquery.validate.unobtrusive.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            "~/Scripts/Libs/Vendor/Kendo/kendo.all.min.js",
            "~/Scripts/Libs/Vendor/Kendo/kendo.aspnetmvc.min.js",
            "~/Scripts/Libs/Vendor/Kendo/kendo.timezones.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/Libs/Vendor/Knockout/knockout-{version}.js",
                "~/Scripts/Libs/Vendor/Knockout/koExternalTemplateEngine_all.js",
                "~/Scripts/Libs/Vendor/Knockout/knockout.mapping-latest.js",
                "~/Scirpts/Libs/Vendor/Knockout/knockout.validation.js",
                "~/Scripts/Libs/Vendor/Knockout/knockout-postbox.js",
                "~/Scripts/Libs/Vendor/Knockout/knockout-kendo.js",
                "~/Scripts/Libs/Vendor/Knockout/knockout.validation.min.js",
                "~/Scripts/Libs/Vendor/Knockout/knockout-bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/Libs/Vendor/Bootstrap/bootstrap.min.js",
                "~/Scripts/Libs/Vendor/Bootstrap/bootstrap-treeview.min.js",
                "~/Scripts/Libs/Vendor/Bootstrap/bootbox.min.js",
                "~/Scripts/Libs/Site/customBinders.js",
                "~/Scripts/Libs/Site/customValidationBinders.js",
                //"~/Scripts/Libs/Site/knockoutWigets.js",
                "~/Scripts/site.js",
                "~/Scripts/Libs/Vendor/date.js",
                "~/Scripts/Libs/Vendor/Moment/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Libs/Vendor/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/require").Include(
                "~/Scripts/Libs/Vendor/Require/require.js",
                "~/Scripts/Libs/Vendor/Require/r.js"));
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                "~/Content/Vendor/AwesomeFonts/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/Vendor/Bootstrap/bootstrap.css",
                "~/Content/Vendor/Bootstrap/bootstrap.customize.css",
                "~/Content/Vendor/Bootstrap/bootstrap-treeview.min.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/Vendor/Kendo/kendo.common.min.css",
                "~/Content/Vendor/Kendo/kendo.bootstrap.min.css"
                //"~/Content/Vendor/Kendo/kendo/kendo.blueopal.min.css",
                //"~/Content/Vendor/Kendo/kendo/kendo.blueopal.mobile.min.css"
                //"~/Content/Vendor/Custom/Kendo/kendo.customize.css",
                //"~/Content/Vendor/Custom/Kendo/kendo.flatgreen.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site/site-main.css"));
        }
    }
}
