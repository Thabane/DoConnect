using System.Web;
using System.Web.Optimization;

namespace DocConnectApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/metisMenu.min.css",
                      "~/Content/morris.min.css",
                      "~/Content/sb-admin-2.css",
                      "~/Scripts/FormValidation/formValidation.css",
                      "~/Scripts/DashboardWidgets/SalesSummary.css",
                      "~/Scripts/DashboardWidgets/QuickActionsAppointments.css",
                      "~/Scripts/DashboardWidgets/To Do List.css",
                      "~/Scripts/Pagination/styles.css",
                      "~/Scripts/DateTimePicker/bootstrap-datetimepicker.min.css",
                      "~/Scripts/DateTimePicker/bootstrap-datetimepicker.css",
                      "~/Scripts/Alert_Confirm_Prompt_Modal/Modal.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.js",
                   "~/Scripts/jquery.dataTables.js",
                   "~/Scripts/angular-route.js",
                   "~/Scripts/angular-location-update.min.js",
                   "~/App/app.js",
                   "~/App/Services/*.js",
                   "~/App/Controllers/*.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/metisMenu.min.js",
                      "~/Scripts/pieChart.js",
                      "~/Scripts/morris.min.js",
                      "~/Scripts/sb-admin-2.js",
                      "~/Scripts/raphael-min.js",
                      "~/Scripts/xml2json.js",
                      "~/Scripts/Alert_Confirm_Prompt_Modal/Alert_Confirm_Prompt_Modal.js",
                      "~/Scripts/Index/jquery.min.js",
                      "~/Scripts/FormValidation/formValidation.js",
                      "~/Scripts/FormValidation/inputValidate.js",
                      "~/Scripts/FormValidation/bootstrap.js",
                      
                      "~/Scripts/Index/bootstrap.min.js",                      
                      //"https://cdn.rawgit.com/theus/chart.css/v1.0.0/dist/chart.css",                      
                      "~/Scripts/Pagination/dirPagination.js",
                      "~/Scripts/DateTimePicker/moment-with-locales.js",                      
                      "~/Scripts/DateTimePicker/bootstrap-datetimepicker.min.js",                      
                      "~/Scripts/DateTimePicker/bootstrap-datetimepicker.js"
                      ));
        }
    }
}
