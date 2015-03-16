using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System;
using System.ServiceModel;
namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ExperianIDCheckLogic")]
    public interface IExperianIDCheckLogic : IBusinessLogicService
    {
        [OperationContract]
        string PerformExperianProveIDQuery(Bec.TargetFramework.Entities.Experian.Search searchRequest);
    }
}
