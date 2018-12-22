using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web;
using System.Web.Routing;

namespace PubDBApplication.App_Start
{
    public class GlobalVariables
    {
        public static bool UserLoggedIn { get => userLoggedIn; set => userLoggedIn = value; }
        private static bool userLoggedIn = true;

        public static string UserName{ get; set;}
    }

    public class LoggedConstraint : IRouteConstraint
    {
        public LoggedConstraint()
        {

        }

        public bool Match
            (
                HttpContextBase httpContext,
                Route route,
                string parameterName,
                RouteValueDictionary values,
                RouteDirection routeDirection
            )
        {
            return GlobalVariables.UserLoggedIn;
        }
    }
}