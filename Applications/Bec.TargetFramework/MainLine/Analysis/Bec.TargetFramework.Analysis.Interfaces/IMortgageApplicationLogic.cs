using Bec.TargetFramework.Analysis.Interfaces;
using System.ServiceModel;

namespace Bec.TargetFramework.Analysis.Interfaces
{
    [ServiceContract(Namespace = BecTargetFrameworkAnalysisServiceNamespaces.AnalysisNamespace + "/MortgageApplicationLogic")]
    public interface IMortgageApplicationLogic : IAnalysisLogicService
    {
        [OperationContract]
        SearchDetail ProcessMortgageApplication(SearchDetail mortgageApplicationRequest);
    }
}
    