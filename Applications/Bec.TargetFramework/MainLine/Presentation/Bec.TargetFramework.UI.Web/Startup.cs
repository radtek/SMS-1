using System.Configuration;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.UI.Web.Startup))]
namespace Bec.TargetFramework.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseHangfire(config =>
            {
                // Basic setup required to process background jobs.
                config.UseSqlServerStorage("NServiceBus/Persistence");
                config.UseServer();
            });
        }
    }
}
