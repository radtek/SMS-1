namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System.ServiceModel;

    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/UserAccountAuditLogic")]
    public interface IUserAccountAuditLogic : IBusinessLogicService
    {
        [OperationContract]
        void CreateAndSaveAudit(WebUserObject wuo, string requestData);
    }
}