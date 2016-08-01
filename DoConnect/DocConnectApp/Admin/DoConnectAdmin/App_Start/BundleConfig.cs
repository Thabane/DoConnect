﻿using System.Web.Optimization;

namespace DoConnectAdmin
{
    /// <summary>
    /// Class BundleConfig. Loads the bundles needed by the project.
    /// </summary>
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
                      "~/Content/sb-admin-2.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.js",
                   "~/Scripts/jquery.dataTables.js",
                   "~/Scripts/DoConnect.js",
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
                      "~/Scripts/DoConnect.js",
                      "~/Scripts/xml2json.js"));

        }
    }
}
