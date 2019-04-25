using System.Web;
using System.Web.Optimization;

namespace RDKHomeSolutions.Website2
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

            bundles.Add(new ScriptBundle("~/bundles/jquerymigrate").Include(
                "~/Scripts/jquery-migrate*"));

            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                "~/Scripts/rs-plugin/js/jquery.themepunch.revolution.min.js",
                "~/Scripts/rs-plugin/js/jquery.themepunch.plugins.min.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/function.js",
                "~/Scripts/library.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/webapp").Include(
                "~/Scripts/app/newsLetter.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                "~/Scripts/toastr.js",
                "~/Scripts/app/toastrOptions.js"));

            bundles.Add(new StyleBundle("~/Content/appcss").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Scripts/rs-plugin/css/settings.css",
                      "~/Content/css/site.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/media.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/toastr/toastr.css"));
        }
    }
}
