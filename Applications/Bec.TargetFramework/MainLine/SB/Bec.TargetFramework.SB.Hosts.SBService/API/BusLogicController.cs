using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Hosts.SBService.Logic;
using Bec.TargetFramework.SB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.SB.Hosts.SBService.API
{
    public class BusLogicController : BusLogic
    {
        public BusLogicController(ILogger logger, ICacheProvider cacheProvider)
            : base(logger,cacheProvider)
        {

        }

        public BusLogicController()
            : base(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>()
            )
        {

        }
    }
}
