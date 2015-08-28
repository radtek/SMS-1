﻿using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Account";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Account_default",
                "Account/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Bec.TargetFramework.Presentation.Web.Areas.Account.Controllers" }
            );
         
        }
    }
}