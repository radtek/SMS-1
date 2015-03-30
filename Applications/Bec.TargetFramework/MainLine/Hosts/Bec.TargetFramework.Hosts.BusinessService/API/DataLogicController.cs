using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Hosts.BusinessService.API
{
    public class DataLogicController : DataLogic, IDataLogic
    {

        public DataLogicController()
            : base(IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>(),
            IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<CommonSettings>()
            )
        {
            
        }
    }
}
