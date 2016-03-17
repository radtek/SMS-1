using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bec.TargetFramework.Hosts.BusinessService.Formatters;
using Bec.TargetFramework.Infrastructure;
using Owin;
using Swashbuckle.Application;
using Autofac;
using WebApiProxy.Server;
using System.Web.Http.ExceptionHandling;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.Hosts.BusinessService
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

            config.EnableSwagger(c => c.SingleApiVersion("v1","BEF Business Services"))
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
