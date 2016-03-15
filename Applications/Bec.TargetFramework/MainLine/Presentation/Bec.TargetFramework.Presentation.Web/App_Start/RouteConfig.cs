﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Bec.TargetFramework.Presentation.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Default",
               "{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "Bec.TargetFramework.Presentation.Web.Controllers" }
           );
        }
    }
}
