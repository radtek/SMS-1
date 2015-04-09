using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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

namespace Bec.TargetFramework.Hosts.BusinessService.API
{
    public class OrganisationLogicController : OrganisationLogic, IOrganisationLogic
    {
        public OrganisationLogicController()
            : base(IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<UserAccountService>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<AuthenticationService>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<CommonSettings>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IUserLogic>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<IDataLogic>()
            )
        {
            
        }

    }
}
