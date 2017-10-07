using System.Web;
using System.Web.Optimization;

namespace BlogAM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/loader").Include(
                "~/Scripts/loader.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/menu.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                "~/Scripts/jqmodify.js",
                "~/Scripts/modal.js"
                ));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/style.css",
                "~/Content/modal.css"
                ));
        }
    }
}
