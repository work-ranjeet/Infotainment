using System.Web;
using System.Web.Optimization;

namespace Infotainment
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/Vendor/JQuery/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/Vendor/JQuery/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/Vendor/JQuery/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/Vendor/JQuery/jquery-ui.js"));

            // Adding angularjs vendor js to support angularjs           
            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                        "~/Scripts/Vendor/Angular/angular.js",
                         "~/Scripts/Vendor/Angular/angular-ui-router.js",
                         "~/Scripts/Vendor/Angular/ui-bootstrap-tpls.js",
                         "~/Scripts/Vendor/Angular/angular-animate.js",
                         "~/Scripts/Vendor/Angular/ngCookies.js",
                         "~/Scripts/Vendor/Angular/ng-infinite-scroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Vendor/Bootstrap/bootstrap.js",
                      "~/Scripts/Vendor/Bootstrap/respond.js"));


            // Adding angular js module code
            bundles.Add(new ScriptBundle("~/bundles/AngularModule").Include(
                "~/Scripts/App.js",
                "~/Scripts/MainCtrl.js"));

            // Common
            bundles.Add(new ScriptBundle("~/bundles/Common").Include("~/Scripts/Common/*.js", "~/Scripts/Content/*.js"));

            // Adding Services
            bundles.Add(new ScriptBundle("~/bundles/Services").Include("~/Scripts/Services/*.js"));

            // Admin
            bundles.Add(new ScriptBundle("~/bundles/txtEditor").Include("~/Scripts/Vendor/TxtEditor/ckeditor/ckeditor.js"));
            bundles.Add(new ScriptBundle("~/bundles/AdminController").Include("~/Areas/Admin/Scripts/Controller/*.js"));


            // Client
            bundles.Add(new ScriptBundle("~/bundles/ClientControllers").Include(
                 "~/Scripts/Components/HomePage/TopNews/*.js",
                "~/Scripts/Components/HomePage/International/*.js",
                "~/Scripts/Components/NewsDetail/*.js",
                "~/Scripts/Components/Advertisment/*.js",
                "~/Scripts/Components/ContactUs/*.js",
                "~/Scripts/Components/AboutUs/*.js"));

            //bundles.Add(new ScriptBundle("~/bundles/AngularCtrl").Include("~/Scripts/Components/HomePage/*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/MainNewsCtrl").Include("~/Scripts/Angular/Controllers/MainNews/*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/StateNewsCtrl").Include("~/Scripts/Angular/Controllers/StateNews/*.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/JQueryCss/*.css",
                      "~/Content/BootStrapCss/bootstrap-theme.css",
                      "~/Content/BootStrapCss/bootstrap.css",
                       "~/Content/BootStrapCss/Modified.css",
                      "~/Content/css/*.css"));

            bundles.Add(new StyleBundle("~/Media/css").Include("~/Content/css/Media/Media.css"));
        }
    }
}
