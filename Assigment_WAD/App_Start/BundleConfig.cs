using System.Web;
using System.Web.Optimization;

namespace Assigment_WAD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jsTemplate").Include(
                "~/Assets/js/vendor/jquery-1.12.4.min.js",
                "~/Assets/js/popper.min.js",
                "~/Assets/js/bootstrap.min.js",
                "~/Assets/js/plugins.js",
                "~/Assets/js/ajax-mail.js",
                "~/Assets/js/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/jsAdminPages").Include(
                "~/Asset_Admin/assets/bundles/libscripts.bundle.js",
                "~/Asset_Admin/assets/bundles/vendorscripts.bundle.js",
                "~/Asset_Admin/assets/bundles/jvectormap.bundle.js",
                "~/Asset_Admin/assets/bundles/morrisscripts.bundle.js",
                "~/Asset_Admin/assets/bundles/knob.bundle.js",
                "~/Asset_Admin/vendor/nestable/jquery.nestable.js",
                "~/Asset_Admin/assets/bundles/mainscripts.bundle.js",
                "~/Asset_Admin/assets/js/pages/ui/sortable-nestable.js",
                "~/Asset_Admin/assets/js/index2.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizrTemplate").Include(
                "~/Assets/js/vendor/modernizr-2.8.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/PagedList.css"));
            bundles.Add(new StyleBundle("~/Assets/css").Include(
                "~/Assets/css/bootstrap.min.css",
                "~/Assets/css/icon-font.min.css",
                "~/Assets/css/plugins.css",
                "~/Assets/css/helper.css",
                "~/Assets/css/style.css"));


            bundles.Add(new StyleBundle("~/Asset_Admin/css").Include(
                "~/Asset_Admin/vendor/bootstrap/css/bootstrap.min.css",
                "~/Asset_Admin/vendor/font-awesome/css/font-awesome.min.css",
                "~/Asset_Admin/vendor/jvectormap/jquery-jvectormap-2.0.3.min.css",
                "~/Asset_Admin/vendor/morrisjs/morris.min.css",
                "~/Asset_Admin/vendor/nestable/jquery-nestable.css",
                "~/Asset_Admin/assets/css/main.css",
                "~/Asset_Admin/assets/css/color_skins.css"));
        }
    }
}
