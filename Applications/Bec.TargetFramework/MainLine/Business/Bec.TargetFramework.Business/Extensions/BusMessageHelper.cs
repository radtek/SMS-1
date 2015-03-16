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
    public class BusMessageHelper
    {
        private IDataLogic m_DataLogic;

        public BusMessageHelper(IDataLogic dLogic)
        {
            m_DataLogic = dLogic;
        }


        public static void CreateProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid busMessageId,Guid? parentID,bool hasError, string busMessageHandler, string busMessageSubscriber, string processDetail, string processMessage,BusMessageStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BusMessageProcessLogStatus.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            BusMessageProcessLog log = new BusMessageProcessLog
            {
                CreatedOn = DateTime.Now,
                BusMessageID = busMessageId,
                ParentID = parentID,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsComplete = false,
                NumberOfRetries = 0,
                ProcessDetail = processDetail,
                ProcessMessage = processMessage,
                BusMessageProcessLogID = Guid.NewGuid(),
                BusMessageHandler = busMessageHandler,
                BusMessageSubscriber = busMessageSubscriber,
                HasError = hasError
            };

            scope.DbContext.BusMessageProcessLogs.Add(log);
        }
    }
}
