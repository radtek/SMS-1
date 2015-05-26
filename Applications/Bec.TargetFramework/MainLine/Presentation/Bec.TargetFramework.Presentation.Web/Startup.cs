using Microsoft.Owin;
using Owin;
using Npgsql;
using System.Configuration;
using ServiceStack.Text;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.Presentation.Web.Startup))]
namespace Bec.TargetFramework.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JsConfig.DateHandler = JsonDateHandler.ISO8601;
        }
    }
}
