using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Business.Product.Processor;
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
    using Bec.TargetFramework.Infrastructure.WCF.Exception;

    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TransactionOrderLogicService : TransactionOrderLogic, ITransactionOrderLogic, IBusinessLogicService
    {
        public TransactionOrderLogicService(ILogger logger, ICacheProvider cacheProvider, IShoppingCartLogic cLogic, IProductLogic pLogic, ProductPricingProcessor pProcessor, CartPricingProcessor cProcessor)
            : base(logger, cacheProvider, cLogic, pLogic, pProcessor, cProcessor)
        {
        }

    }
}
