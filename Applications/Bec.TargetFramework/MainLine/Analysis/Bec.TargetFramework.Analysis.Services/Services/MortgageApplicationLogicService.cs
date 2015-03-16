using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using System.ServiceModel;

namespace Bec.TargetFramework.Analysis.Services
{
    [WcfGlobalExceptionOperationBehaviorAttribute(typeof(WcfGlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MortgageApplicationLogicService : MortgageApplicationLogic, IMortgageApplicationLogic, IAnalysisLogicService
    {
        public MortgageApplicationLogicService(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }
    }
}
