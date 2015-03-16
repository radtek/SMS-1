namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Bec.TargetFramework.Data;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

     [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/AddressLogic")]
    public interface IAddressLogic : IBusinessLogicService
    {
         [OperationContract]
         List<PostCodeDTO> FindAddressesByPostCode(string postCode, string building);

        [OperationContract]
        GoogleGeoCodeResponse GeoCodePostcode(string postCode);
    }
}
