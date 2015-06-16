using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Hosts.SBService.Base;
using Bec.TargetFramework.SB.Interfaces;
using NServiceBus.Pipeline;
using ServiceStack.Text;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    using System.Collections.ObjectModel;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;

    using Bec.TargetFramework.Aop.Aspects;
    using EnsureThat;
    using Bec.TargetFramework.SB.Entities;
    using Bec.TargetFramework.SB.Entities.Enums;
    using Bec.TargetFramework.SB.Entities;

    [Trace(TraceExceptionsOnly = true)]
    public class BusTaskLogic : LogicBase
    {
        public BusTaskLogic()
        {
        }


        public List<VBusTaskScheduleDTO> AllBusTaskSchedules()
        {
            List<VBusTaskScheduleDTO> dtoList = null;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                dtoList = VBusTaskScheduleConverter.ToDtos(scope.DbContext.VBusTaskSchedules);
            }

            return dtoList;
        }

        public List<VBusTaskScheduleDTO> AllBusTaskSchedulesByAppNameAndEnv(string appName, string env)
        {
            Ensure.That(appName).IsNotNullOrWhiteSpace();
            Ensure.That(env).IsNotNullOrWhiteSpace();

            List<VBusTaskScheduleDTO> dtoList = null;

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var data =
                    scope.DbContext.VBusTaskSchedules.Where(
                        s => s.ApplicationEnvironmentName != null && s.ApplicationEnvironmentName.Equals(env) &&
                             s.ApplicationName != null && s.ApplicationName.Equals(appName));

                dtoList = VBusTaskScheduleConverter.ToDtos(data);
            }

            return dtoList;
        }

        public void SaveBusTaskScheduleProcessLog(ProcessLogDTO logDto)
        {
            Ensure.That(logDto).IsNotNull();

            using (
                var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                    true))
            {
                CreateBusTaskScheduleProcessLog(scope, logDto.ScheduleDto, logDto, logDto.ParentID, logDto.StatusValue);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }
        }

        private void CreateBusTaskScheduleProcessLog(UnitOfWorkScope<TargetFrameworkCoreEntities> scope,VBusTaskScheduleDTO taskSchedule,ProcessLogDTO logDto,Guid? parentId, BusTaskStatusEnum statusEnumValue)
        {
            Ensure.That(taskSchedule).IsNotNull();

            // set status to processing
            var statusType = GetStatusType(scope, StatusTypeEnum.BusTaskScheduleProcessLogStatus.GetStringValue(),
                statusEnumValue.GetStringValue());

            Ensure.That(statusType);

            BusTaskScheduleProcessLog log = new BusTaskScheduleProcessLog
            {
                CreatedOn = DateTime.Now,
                ParentID = parentId,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                BusTaskScheduleID = taskSchedule.BusTaskScheduleID,
                BusTaskHandlerID = taskSchedule.BusTaskHandlerID,
                BusTaskHandlerVersionNumber = taskSchedule.BusTaskHandlerVersionNumber,
                BusTaskScheduleProcessLogID = Guid.NewGuid()
            };

            // only add other details if logDto is not null
            if(logDto != null)
            {
                log.HasError = logDto.HasError;
                log.ProcessMessage = logDto.ProcessMessage;
                log.ProcessDetail = logDto.ProcessDetail;
                log.NumberOfRetries = logDto.NumberOfRetries;
                log.IsComplete = logDto.IsComplete;
            }

            scope.DbContext.BusTaskScheduleProcessLogs.Add(log);
        } 
    }
}
