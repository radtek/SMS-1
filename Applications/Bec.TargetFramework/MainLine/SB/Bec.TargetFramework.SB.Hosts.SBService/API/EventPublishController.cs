using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Hosts.SBService.Logic;
using Bec.TargetFramework.SB.Hosts.SBService.Logic;
using Bec.TargetFramework.SB.Interfaces;

namespace Bec.TargetFramework.SB.Hosts.SBService.API
{
    public class EventPublishController : EventPublishLogic
    {
        public EventPublishController()
            : base(IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<BusLogic>()
            )
        {

        }
    }
}
