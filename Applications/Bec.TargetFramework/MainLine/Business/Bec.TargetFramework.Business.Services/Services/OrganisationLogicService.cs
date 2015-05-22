using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using Bec.TargetFramework.SB.Interfaces;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Business.Services
{
    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class OrganisationLogicService : OrganisationLogic, IOrganisationLogic, IBusinessLogicService
    {
        public OrganisationLogicService(UserAccountService uaService, AuthenticationService authSvc, ILogger logger, ICacheProvider cacheProvider, CommonSettings commonSettings, IUserLogic uLogic, IDataLogic dLogic, IEventPublishClient eventPublishClient, INotificationLogic notificationLogic)
            : base(uaService, authSvc, logger, cacheProvider, commonSettings, uLogic, dLogic, eventPublishClient, notificationLogic)
        {
        }

    }
}
