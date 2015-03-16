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
    public class ProductPurchaseBusTaskHelper
    {
        private IDataLogic m_DataLogic;

        public ProductPurchaseBusTaskHelper(IDataLogic dLogic)
        {
            m_DataLogic = dLogic;
        }

  
        public static void CreateProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid productPurchaseId,Guid? productBusTaskId, Guid? parentID, bool hasError, bool isComplete, string processDetail, string processMessage, ProductPurchaseBusTaskStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.ProductPurchaseBusTaskProcessLogStatus.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            ProductPurchaseBusTaskProcessLog log = new ProductPurchaseBusTaskProcessLog
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
                ProductPurchaseProductTaskID = Guid.NewGuid(),
                ProductPurchaseID = productPurchaseId,
                ProductBusTaskID = productBusTaskId,
                HasError = hasError
            };

            scope.DbContext.ProductPurchaseBusTaskProcessLogs.Add(log);
        }
    }
}
