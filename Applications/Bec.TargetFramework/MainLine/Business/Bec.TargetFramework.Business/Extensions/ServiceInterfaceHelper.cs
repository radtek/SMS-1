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
    public class ServiceInterfaceHelper
    {
        private IDataLogic m_DataLogic;

        public ServiceInterfaceHelper(IDataLogic dLogic)
        {
            m_DataLogic = dLogic;
        }

        [EnsureArgumentAspect]
        public static void CreateServiceInterfaceProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid serviceDefinitionID, Guid? productPurchaseTaskID,Guid? parentID, string processDetail, string processMessage,ServiceInterfaceStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.ServiceInterfaceProcessLog.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            ServiceInterfaceProcessLog log = new ServiceInterfaceProcessLog
            {
                CreatedOn = DateTime.Now,
                ServiceDefinitionID = serviceDefinitionID,
                ProductPurchaseProductTaskID = productPurchaseTaskID,
                ParentID = parentID,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsComplete = false,
                NumberOfRetries = 0,
                ProcessDetail = processDetail,
                ProcessMessage = processMessage,
                ServiceInterfaceProcessLogID = Guid.NewGuid()
            };

            scope.DbContext.ServiceInterfaceProcessLogs.Add(log);
        }
    }
}
