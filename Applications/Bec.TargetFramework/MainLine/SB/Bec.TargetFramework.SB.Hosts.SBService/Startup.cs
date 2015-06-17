using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bec.TargetFramework.SB.Hosts.SBService.Formatters;
using Bec.TargetFramework.Infrastructure;
using Owin;
using WebApiProxy.Server;
using Bec.TargetFramework.Infrastructure.IOC;
using Autofac.Integration.WebApi;
using System.Web.Http.ExceptionHandling;

namespace Bec.TargetFramework.SB.Hosts.SBService
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
            config.DependencyResolver = new AutofacWebApiDependencyResolver(SBService.m_LifetimeScope);

            app.UseAutofacMiddleware(SBService.m_LifetimeScope);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            
        }
    }
}
