using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.Hosts.BusinessService.API
{
    public class SettingsLogicController : SettingLogic
    {
        public SettingsLogicController()
            : base(IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>(),
            IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ICacheProvider>()
            )
        {

        }
    }
}
