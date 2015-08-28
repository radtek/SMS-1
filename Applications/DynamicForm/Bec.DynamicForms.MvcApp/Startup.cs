using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bec.DynamicForms.MvcApp.Startup))]
namespace Bec.DynamicForms.MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
