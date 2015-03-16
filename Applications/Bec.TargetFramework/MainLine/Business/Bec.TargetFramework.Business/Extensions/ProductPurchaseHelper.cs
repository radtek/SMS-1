using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public class ProductPurchaseHelper
    {
        private IDataLogic m_DataLogic;

        public ProductPurchaseHelper(IDataLogic dLogic)
        {
            m_DataLogic = dLogic;
        }

     
        public static void CreateProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid productPurchaseId, Guid? parentID, bool hasError, bool isComplete, string processDetail, string processMessage, ProductPurchaseStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProductPurchase.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            ProductPurchaseProcessLog log = new ProductPurchaseProcessLog
            {
                CreatedOn = DateTime.Now,
                ParentID = parentID,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsComplete = false,
                NumberOfRetries = 0,
                ProcessDetail = processDetail,
                ProcessMessage = processMessage,
                ProductPurchaseProcessLogID = Guid.NewGuid(),
                ProductPurchaseID = productPurchaseId,
                HasError = hasError
            };

            scope.DbContext.ProductPurchaseProcessLogs.Add(log);
        }
    }
}
