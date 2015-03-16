using System.Configuration;
using System.Net;
using System.Net.Sockets;
using Bec.TargetFramework.Framework;
using Bec.TargetFramework.Framework.Data;
using Bec.TargetFramework.Framework.Infrastructure;
using Bec.TargetFramework.Framework.Interfaces;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Services.Tasks;
using Bec.TargetFramework.Web.Framework;
using Bec.TargetFramework.Web.Framework.EmbeddedViews;
using Bec.TargetFramework.Web.Framework.Mvc;
using Bec.TargetFramework.Web.Framework.Mvc.Routes;
using BrockAllen.MembershipReboot;
using FluentValidation.Mvc;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Data.Entity.Infrastructure.Interception;
using Autofac;
using Autofac.Integration.Mvc;
using Task = System.Threading.Tasks.Task;

namespace Bec.TargetFramework.Presentation
{
    using Bec.TargetFramework.Security;
    using Bec.TargetFramework.Data.Infrastructure;
    using System.Diagnostics;
    using Bec.TargetFramework.Infrastructure.Log;
    using System.Reflection;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.Framework.Plugins;

    public class MvcApplication : System.Web.HttpApplication
    {

        //public static void RegisterRoutes(RouteCollection routes)
        //{
           
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //}

        private void InitializeIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new BEC.TargetFramework.Presentation.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_Start()
        {
            string[] servicePorts = ConfigurationManager.AppSettings["ServicesNeededOnStartupPorts"].Split(',');

            bool serviceRunning = false;

            while (!serviceRunning)
            {
                try
                {
                    // find matching 

                    servicePorts.ToList().ForEach(sp =>
                        new TcpClient().Connect(ConfigurationManager.AppSettings["ApplicationServerIpAddress"], int.Parse(sp)));

                    serviceRunning = true;
                }
                catch (Exception)
                {
                }

                Thread.Sleep(1000);
            }

            EngineContext.Initialize(false);

            // IOC setup phase 1
            InitializeIOC();
            // register routes and bundles
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ////model binders
            ModelBinders.Binders.Add(typeof(BaseTargetFrameworkModel), new TargetFrameworkModelBinder());
        }



        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //we don't do it in Application_BeginRequest because a user is not authenticated yet
            //SetWorkingCulture();
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

            if (Serilog.Log.Logger == null)
                new SerilogLogger(true, false, "TFWebApplication").Error(exc);
            else
                Serilog.Log.Logger.Error(exc, exc.Message, null);

        }
    }
}
