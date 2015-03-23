using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bec.TargetFramework.Infrastructure.Serilog.Helpers;
using System.Web.Helpers;
using System.Security.Claims;
using FluentValidation.Mvc;

namespace Bec.TargetFramework.Presentation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private void InitializeIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new BEC.TargetFramework.Presentation.Web.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_Start()
        {
            InitializeIOC();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);

        }


        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;

            SerilogHelper.LogException(AppDomain.CurrentDomain.FriendlyName,exc);
        }
    }
}
