using System.Web.Optimization;

namespace CheckSiteMap.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            //bundles.Add(new ScriptBundle("~/bundles/popper.js").Include("~/Scripts/popper.js")); /// ERROR HANDLER check this out
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/Site.css", "~/Content/PagedList.css"));
            bundles.Add(new StyleBundle("~/Content/Table.css").Include("~/Content/RequestTableStyle.css"));
        }
    }
}
