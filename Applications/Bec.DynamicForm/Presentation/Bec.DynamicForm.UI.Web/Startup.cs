using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bec.DynamicForm.UI.Web.Startup))]
namespace Bec.DynamicForm.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
