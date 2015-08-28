using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Mehdime.Entity;
using System.Web.Http;

namespace Bec.TargetFramework.Infrastructure
{
    public class LogicBase : ApiController
    {
        public ILogger Logger { get; set; }
        public ICacheProvider CacheProvider { get; set; }

        public UserNameService UserNameService { get; set; }
        public IDbContextScopeFactory DbContextScopeFactory { get; set; }
        
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            // this provides services with the "User" header from the original request
            // (for when service methods are invoked indirectly, via another controller)
            // as ApiController.Request is not populated when calling methods directly.
            // UserNameService, if registered, must be scoped 'per request'.
            if (UserNameService != null) UserNameService.GetUserName(this);
        }
    }
}
