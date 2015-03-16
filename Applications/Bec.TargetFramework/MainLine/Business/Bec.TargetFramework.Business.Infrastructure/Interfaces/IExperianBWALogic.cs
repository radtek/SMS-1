using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System;
using System.ServiceModel;
namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ExperianBWALogic")]
    public interface IExperianBWALogic : IBusinessLogicService
    {
        [OperationContract]
        string PerformExperianBankWizardAbsoluteQuery(Bec.TargetFramework.Entities.Experian.BWARequestDTO request);
    }
}
