using System.Web;
using System.Web.Optimization;

namespace DoConnectCustomerPortal
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"
            //            ));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.min.css",
                       "~/Content/css/bootstrap-responsive.min.css",
                       "~/Content/css/theme.css",
                       "~/Content/css/custom.css",
                      "~/Scripts/FormValidation/FormValidationStyle.css",
                       "~/Content/css/font-awesome.css",
                       "~/Content/css/fullcalendar.css",
                       "~/Content/css/calendarDemo.css",
                       "~/Scripts/DTPicker/*.css"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/raphael-min.js",
                      "~/Scripts/xml2json.js",
                      "~/Scripts/DTPicker/moment-with-locales.js",
                      "~/Scripts/DTPicker/bootstrap-datetimepicker.js",
                      "~/Scripts/DTPicker/bootstrap-datetimepicker.min.js",
                      "~/Scripts/DTPicker/bootstrap-datetimepicker.pt-BR.js",
                      "~/Content/js/jquery-ui-1.10.1.custom.min.js",
                      "~/Content/js/jquery.dataTables.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.min.js",
                   "~/Content/js/ui-bootstrap-tpls.min.js",
                   "~/Content/js/moment.js",
                   "~/Content/js/fullcalendar.js",
                   "~/Content/js/gcal.js",
                   "~/Content/js/calendar.js",
                   "~/Scripts/jquery.dataTables.js",
                   "~/Scripts/angular-route.min.js",
                   "~/Scripts/angular-location-update.min.js",
                   "~/Scripts/angular-cookies.js",
                   "~/Scripts/bootbox.js",
                   "~/Scripts/ngBootbox.js",
                   "~/App/app.js",
                   "~/App/Services/*.js",
                   "~/App/Controllers/*.js",
                   "~/App/Filters/*.js"
                   ));
        }
    }
}
