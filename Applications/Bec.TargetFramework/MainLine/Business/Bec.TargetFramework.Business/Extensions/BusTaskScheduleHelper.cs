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
    public class BusTaskScheduleHelper
    {
        private IDataLogic m_DataLogic;

        public BusTaskScheduleHelper(IDataLogic dLogic)
        {
            m_DataLogic = dLogic;
        }


        public static void CreateProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid busTaskScheduleId, Guid? parentID, bool hasError,bool isComplete, string processDetail, string processMessage, BusTaskScheduleStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BusTaskScheduleProcessLogStatus.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            BusTaskScheduleProcessLog log = new BusTaskScheduleProcessLog
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
                BusTaskScheduleProcessLogID = Guid.NewGuid(),
                BusTaskScheduleID = busTaskScheduleId,
                HasError = hasError
            };

            scope.DbContext.BusTaskScheduleProcessLogs.Add(log);
        }
    }
}
