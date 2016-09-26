using System.Web;
using System.Web.Optimization;

namespace DocConnectApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

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
                      "~/Scripts/DashboardWidgets/SalesSummary.css",
                      "~/Scripts/DashboardWidgets/QuickActionsAppointments.css",
                      "~/Scripts/DashboardWidgets/To Do List.css",
                      "~/Scripts/Pagination/styles.css",
                      "~/Scripts/dtPicker/bootstrap-datetimepicker.min.css",
                      //"~/Scripts/DateTimePicker/bootstrap-datetimepicker.min.css",
                      //"~/Scripts/DateTimePicker/bootstrap-datetimepicker.css",
                      "~/Scripts/FormValidation/FormValidationStyle.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.min.js",
                   "~/Scripts/jquery.dataTables.js",
                   "~/Scripts/angular-route.min.js",
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
                      "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/Index/bootstrap.min.js",
                      "~/Scripts/Pagination/dirPagination.js",
                      "~/Scripts/dtPicker/moment.js",
                      "~/Scripts/dtPicker/bootstrap-datetimepicker.min.js",
                      "~/Scripts/dtPicker/bootstrap-datetimepicker.js",
                      "~/Scripts/Alert_Confirm_Prompt_Modal/bootbox.js",
                      "~/Scripts/Alert_Confirm_Prompt_Modal/ngBootbox.js"
                      //"~/Scripts/DateTimePicker/moment-with-locales.js",
                      //"~/Scripts/DateTimePicker/bootstrap-datetimepicker.min.js",
                      //"~/Scripts/DateTimePicker/bootstrap-datetimepicker.js",
                      //"~/Scripts/bootstrap.js"
                      ));
        }
    }
}
