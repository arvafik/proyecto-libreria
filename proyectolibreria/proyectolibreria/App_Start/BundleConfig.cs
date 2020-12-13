using System.Web;
using System.Web.Optimization;

namespace proyectolibreria
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                      "~/Content/bootstrap/bootstrap-grid.css",
                      "~/Content/bootstrap/bootstrap-reboot.css",
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/css/argon.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/vendor/nucleo/css/nucleo.css"));

            bundles.Add(new StyleBundle("~/Content/CustomScripts").Include(
                      "~/Content/vendor/jquery/dist/jquery.min.css",
                      "~/Content/vendor/bootstrap/dist/js/bootstrap.bundle.min.js",
                      "~/Content/vendor/js-cookie/js.cookie.js",
                      "~/Content/vendor/jquery.scrollbar/jquery.scrollbar.min.js",
                      "~/Content/vendor/jquery-scroll-lock/dist/jquery-scrollLock.min.js",
                      "~/Content/vendor/chart.js/dist/Chart.min.js",
                      "~/Content/vendor/chart.js/dist/Chart.extension.js",
                      "~/Content/js/argon.js"
                ));
        
        }
    }
}
