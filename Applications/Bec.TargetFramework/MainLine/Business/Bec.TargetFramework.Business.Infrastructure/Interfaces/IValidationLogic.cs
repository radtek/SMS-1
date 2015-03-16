using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Data;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ValidationLogic")]
    public interface IValidationLogic : IBusinessLogicService
    {
        [OperationContract]
        RegistrationValidationErrorDTO DuplicateComplianceOfficer(string CORegulator, string CORegulatorNumber, string COFirmName, string COFirmTradingName, string COLastName = null, string COEmail = null);
        [OperationContract]
        RegistrationValidationErrorDTO DuplicateCompany(string FirmRegulator, string BranchRegulatorNumber, string FirmName, string FirmTradingName, string COLastName = null, string COEmail = null);
        [OperationContract]
        RegistrationValidationErrorDTO COwithAnotherFirm(string CORegulator, string CORegulatorNumber, string COFirmName, string COFirmTradingName, string COLastName, string COEmail = null);
        [OperationContract]
        CompanyDTO GetCompanyDetailsByName(string strCopmanyName);
        [OperationContract]
        EmployeeDTO GetEmployeeById(string strSRAID);
        [OperationContract]
        bool IsInvalidEmployee(string strSraId, string strLastName, string strCompanyName, bool IsColp);
        [OperationContract]
        bool IsInvalidBranch(string strBranchSraId, string strCompanyName, string strPostCode);
         
    }
}
