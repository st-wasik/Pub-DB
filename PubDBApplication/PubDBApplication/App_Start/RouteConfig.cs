using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PubDBApplication.App_Start;

namespace PubDBApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = new LoggedConstraint() }
            );

            routes.MapRoute(
    name: "CatchAll",
    url: "",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
        }
    }
}
