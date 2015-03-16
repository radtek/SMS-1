using System;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Bec.TargetFramework.Data;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
   // using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ProductLogic")]
    public interface IProductLogic : IBusinessLogicService
    {
        [OperationContract]
        ProductDTO GetProduct(Guid productId, int versionNumber);

        [OperationContract]
        Bec.TargetFramework.Entities.ProductDTO GetProductWithSpecsAttributesAndDeductions(Guid productID, int versionNumber,bool includeDiscountsAndDeductions);
    }
}
