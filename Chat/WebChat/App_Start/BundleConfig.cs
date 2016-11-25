using System.Web;
using System.Web.Optimization;

namespace WebChat
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-aria.js",
                        "~/Scripts/angular-cookies.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-material/angular-material.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/angular-material.css",
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/additionalJs").Include(
                        "~/Scripts/StartLoad/DetermineUserPopup.js"));


            //minimization AngularJs Scripts
            const string ANGULAR_APP_ROOT = "~/Angular/";
            const string VIRTUAL_BUNDLE_PATH = ANGULAR_APP_ROOT + "main.js";

            var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
                .Include(ANGULAR_APP_ROOT + "app.js")
                .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true);

            bundles.Add(scriptBundle);
            BundleTable.EnableOptimizations = false;

        }
    }
}
