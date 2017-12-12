using System.Web;
using System.Web.Optimization;

namespace ExoticSpeciesOfTheNorth
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

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            //Add: jquery-ui css.
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/site.css",
                        "~/Content/themes/base/all.css"));

            //Controller css for Home, Homelands, Species:
            bundles.Add(new StyleBundle("~/Content/css/Home").Include(
                        "~/Content/Custom/HomeIndex.css",
                        "~/Content/Custom/Home_ChatOnline.css"));

            bundles.Add(new StyleBundle("~/Content/css/Homelands").Include(
                        "~/Content/Custom/HomelandsIndex.css"));

            bundles.Add(new StyleBundle("~/Content/css/Species").Include(
                        "~/Content/Custom/SpeciesIndex.css"));
        }
    }
}
