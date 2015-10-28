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

            // Adding angularjs vendor js to support angularjs           
            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                        "~/Scripts/Vendor/Angular/angular.js",
                         "~/Scripts/Vendor/Angular/angular-ui-router.js",
                         "~/Scripts/Vendor/Angular/ui-bootstrap-tpls.js",
                         "~/Scripts/Vendor/Angular/angular-animate.js",
                         "~/Scripts/Vendor/Angular/ngCookies.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Vendor/Bootstrap/bootstrap.js",
                      "~/Scripts/Vendor/Bootstrap/respond.js",
                      "~/Scripts/Vendor/Bootstrap/date-picker.JS",
                      "~/Scripts/Vendor/Bootstrap/bootstrap-datepicker.JS"));
           

            // Adding angular js module code
            bundles.Add(new ScriptBundle("~/bundles/AngularModule").Include(
                "~/Scripts/App.js", 
                "~/Scripts/MainCtrl.js"));

            // Common
            bundles.Add(new ScriptBundle("~/bundles/Common").Include("~/Scripts/Common/*.js"));

            // Adding Services
            bundles.Add(new ScriptBundle("~/bundles/Services").Include("~/Scripts/Services/*.js"));

            // Admin
            bundles.Add(new ScriptBundle("~/bundles/txtEditor").Include("~/Scripts/Vendor/TxtEditor/ckeditor/ckeditor.js"));
            bundles.Add(new ScriptBundle("~/bundles/AdminController").Include("~/Areas/Admin/Scripts/Controller/*.js"));


            // Client
            bundles.Add(new ScriptBundle("~/bundles/ClientControllers").Include(
                "~/Scripts/Components/HomePage/HomeCtrl.js",
                "~/Scripts/Components/HomePage/TopTenNews/TopTenNewsCtrl.js"));
            //"~/Scripts/Components/HomePage/MainNews/*.js",
            // "~/Scripts/Components/Module/*.js"));

            //bundles.Add(new ScriptBundle("~/bundles/AngularCtrl").Include("~/Scripts/Components/HomePage/*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/MainNewsCtrl").Include("~/Scripts/Angular/Controllers/MainNews/*.js"));
            //bundles.Add(new ScriptBundle("~/bundles/StateNewsCtrl").Include("~/Scripts/Angular/Controllers/StateNews/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/*.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
