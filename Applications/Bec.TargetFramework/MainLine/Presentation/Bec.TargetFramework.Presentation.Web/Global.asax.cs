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
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog.Helpers;
using System.Web.Helpers;
using System.Security.Claims;
using FluentValidation.Mvc;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure;
namespace Bec.TargetFramework.Presentation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private void InitializeIOC()
        {
            var iocContainer = IocProvider.BuildAndReturnIocContainer<BEC.TargetFramework.Presentation.Web.IOC.DependencyRegistrar>();

            // get and register in dependencyresolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(iocContainer));
            
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
            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);

        }

        protected void Application_EndRequest()
        {
            // removing excessive headers.
            Response.Headers.Remove("Server");
        }

        protected void LogException(Exception exc)
        {
            var resolver = DependencyResolver.Current as AutofacDependencyResolver;

            var logger = resolver.ApplicationContainer.Resolve<ILogger>();

            logger.Error(exc, AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
