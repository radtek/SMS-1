
namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/DeductionLogic")]
    public interface IDeductionLogic : IBusinessLogicService
    {
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.VCountryDeductionDTO> GetCountryDeductions(string countryCode);
         [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.VProductDeductionDTO> GetProductDeductions(Guid productID, int versionNumber);
    }
}
