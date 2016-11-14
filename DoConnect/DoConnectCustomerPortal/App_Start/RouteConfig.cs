using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoConnectCustomerPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "App",
              url: "{*url}",
              defaults: new { controller = "PatientLogin", action = "Index" },
              namespaces: new []{ "DoConnectCustomerPortal.Controllers" }
        );
        }
    }
}
