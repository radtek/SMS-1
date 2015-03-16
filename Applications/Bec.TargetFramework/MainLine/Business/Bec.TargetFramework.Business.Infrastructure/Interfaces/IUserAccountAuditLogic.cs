namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System.ServiceModel;

    using Bec.TargetFramework.Web.Framework.Helpers;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/UserAccountAuditLogic")]
    public interface IUserAccountAuditLogic : IBusinessLogicService
    {
        [OperationContract]
        void CreateAndSaveAudit(WebUserObject wuo, string requestData);
    }
}