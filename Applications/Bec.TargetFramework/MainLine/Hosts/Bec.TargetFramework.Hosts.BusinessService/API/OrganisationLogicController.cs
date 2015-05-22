using Autofac;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.SB.Interfaces;

namespace Bec.TargetFramework.Hosts.BusinessService.API
{
    public class OrganisationLogicController : OrganisationLogic
    {
        public OrganisationLogicController()
            : base(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<UserAccountService>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<AuthenticationService>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<CommonSettings>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<UserLogic>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<DataLogic>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IEventPublishClient>())
        {
            
        }

    }
}
