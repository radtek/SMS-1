using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bec.TargetFramework.SB.Hosts.SBService.Formatters;
using Bec.TargetFramework.Infrastructure;
using Owin;
using Swashbuckle.Application;
using WebApiProxy.Server;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //config.Formatters.RemoveAt(0);
            //config.Formatters.Insert(0, new JilMediaTypeFormatter());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"API",
                routeTemplate:"api/{controller}/{action}/{id}",
                defaults:new { id = RouteParameter.Optional });

            config.RegisterProxyRoutes();

            config.EnableSwagger(c => c.SingleApiVersion("v1","BEF SB Services"))
                .EnableSwaggerUi();

            app.UseWebApi(config);

            var iocContainer = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);

            app.UseAutofacMiddleware(iocContainer);
        }
    }
}
