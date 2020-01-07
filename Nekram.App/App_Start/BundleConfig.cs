
using System.Web.Optimization;

namespace Nekram.App.App_Start {
    public class BundleConfig {

        public static void RegisterBundles(BundleCollection bundles) {

            //bunddle your script files from here
            bundles.Add(new ScriptBundle("~/Scripts").Include(
            "~/Scripts/jquery-3.4.1.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.unobtrusive.js",
            "~/Scripts/bootstrap.js",
            "~/Scripts/bootstrap.validate.js",
            "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Fonts/js").Include("~/Fonts/js/all.js"));
            bundles.Add(new ScriptBundle("~/Scripts/esm").Include("~/Scripts/esm/popper.js"));

            //bundle style sheets from here
            bundles.Add(new StyleBundle("~/Content").Include(
                "~/Content/bootstrap.css",
                "~/Content/reset.css",
                "~/Content/main.css"));
            bundles.Add(new StyleBundle("~/Content/themes").Include(
                "~/Content/themes/default-Theme.css"));
            bundles.Add(new StyleBundle("~/Fonts/css").Include(
                "~/Fonts/css/all.css"));
        }
    }
}