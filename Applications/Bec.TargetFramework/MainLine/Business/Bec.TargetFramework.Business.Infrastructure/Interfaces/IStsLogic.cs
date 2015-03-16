using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.Enums;

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
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/StsLogic")]
    public interface IStsLogic : IBusinessLogicService
    {
       

    }
}
