using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PostingInstructionsApp.Web.Ui
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Thank You",
                "thank-you/",
                new { controller = "Home", action = "ThankYou" }
            );

            routes.MapRoute(
                "GetAuth", // Route name
                "ajax/get-auth", // URL with parameters
                new { controller = "Ajax", action = "GetAuth" } // Parameter defaults
            );

            routes.MapRoute(
                "GetClientVendorData", // Route name
                "ajax/get-client-vendor", // URL with parameters
                new { controller = "Ajax", action = "GetAuth" } // Parameter defaults
            );

            routes.MapRoute(
                "SetAuth", // Route name
                "ajax/post-data", // URL with parameters
                new { controller = "Ajax", action = "PostData" } // Parameter defaults
            );

            routes.MapRoute(
                "NewVendor", // Route name
                "home/create-vendor", // URL with parameters
                new { controller = "Home", action = "NewVendor" } // Parameter defaults
            );

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
