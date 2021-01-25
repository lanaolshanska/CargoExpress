using System.Web.Optimization;

namespace Delivery.Website
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

            bundles.Add(new ScriptBundle("~/bundles/registration").Include(
                     "~/Scripts/registration.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/customFormCss").Include(
                      "~/Content/DetailsForm.css",
                      "~/Content/EditForm.css"));

            bundles.Add(new StyleBundle("~/Content/customNavCss").Include(
                      "~/Content/Navigation.css",
                      "~/Content/PagedList.css",
                      "~/Content/Tabs.css"));

            bundles.Add(new StyleBundle("~/bundles/tabs").Include(
                     "~/Scripts/tabs.js"));
        }
    }
}
