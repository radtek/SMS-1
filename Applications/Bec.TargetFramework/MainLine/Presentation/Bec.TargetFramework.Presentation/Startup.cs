using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bec.TargetFramework.Presentation.Startup))]
namespace Bec.TargetFramework.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
