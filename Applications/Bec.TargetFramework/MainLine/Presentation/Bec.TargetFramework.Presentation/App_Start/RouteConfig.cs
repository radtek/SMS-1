using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bec.TargetFramework.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Bec.TargetFramework.Presentation.Controllers" });


            routes.MapRoute(
                name: "KnockoutTemplates",
                url: "{controller}/{action}/{templateName}",
                defaults: new { controller = "Templates", action = "KnockoutTemplate" },
                namespaces: new string[] { "Bec.TargetFramework.Presentation.Controllers" });
           
        }
    }
}
