using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiProxy.Server;

namespace Bec.TargetFramework.Hosts.TestsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"API",
                routeTemplate:"api/{controller}/{action}/{id}",
                defaults:new { id = RouteParameter.Optional });

            config.RegisterProxyRoutes();

            config.EnableSwagger(c => c.SingleApiVersion("v1","BEF Tests Services"))
                .EnableSwaggerUi();

            config.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger());

            var iocContainer = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);

            app.UseAutofacMiddleware(iocContainer);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            // required to display detailed exception
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }

        public class TraceExceptionLogger : ExceptionLogger
        {
            public override void Log(ExceptionLoggerContext context)
            {
                var iocContainer = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);
                var logger = iocContainer.Resolve<ILogger>();
                logger.Error(context.Exception);
            }
        }
    }
}
