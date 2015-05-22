using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.SB.NotificationServices.Report;

namespace Bec.TargetFramework.Hosts.BusinessService.API
{
    public class NotificationLogicController : NotificationLogic
    {
        public NotificationLogicController()
            : base(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>(),
            IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<StandaloneReportGenerator>()
            )
        {

        }
    }
}
