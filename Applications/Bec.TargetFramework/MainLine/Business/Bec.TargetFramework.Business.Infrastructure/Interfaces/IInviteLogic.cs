using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Data;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/InviteLogic")]
    public interface IInviteLogic : IBusinessLogicService
    {
        [OperationContract]
        void AddInvite(StsInviteDTO invite);
    }
}
