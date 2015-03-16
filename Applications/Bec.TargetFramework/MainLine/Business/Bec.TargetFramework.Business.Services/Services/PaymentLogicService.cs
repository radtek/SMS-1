using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using BrockAllen.MembershipReboot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Business.Services
{
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities.Settings;
    using Bec.TargetFramework.Infrastructure.WCF.Exception;

    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PaymentLogicService : PaymentLogic, IPaymentLogic, IBusinessLogicService
    {
        public PaymentLogicService(ILogger logger, ICacheProvider cacheProvider,PaymentSettings settings) 
            : base(logger, cacheProvider,settings)
        {
        }

    }
}
