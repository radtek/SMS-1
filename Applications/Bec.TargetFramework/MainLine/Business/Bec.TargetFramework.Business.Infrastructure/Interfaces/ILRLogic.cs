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
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/LRLogic")]
    public interface ILRLogic : IBusinessLogicService
    {
        void SaveLRDocumentList(List<LRDocumentDTO> dtoList);
        [OperationContract]
        void SaveLRTitle(Guid stsPropertyId, Guid productPurchaseProductTaskID, Guid? stsSearchPropertyId,
            LRTitleDTO dto);
        [OperationContract]
        void SaveLRTitleList(Guid stsPropertyId, Guid productPurchaseProductTaskID, Guid? stsSearchPropertyId,
            List<LRTitleDTO> dtoList);
        [OperationContract]
        void SaveLRRegisterExtractWithDocuments(LRRegisterExtractDTO dto, List<LRDocumentDTO> documents);

        [OperationContract]
        void SaveLRRegisterExtract(LRRegisterExtractDTO dto);

    }
}
