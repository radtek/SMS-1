using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;
using Bec.TargetFramework.SB.Hosts.SBService.Helpers;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class BusTaskLogicController : LogicBase
    {
        public BusTaskLogicController()
        {
        }

        public List<VBusTaskScheduleDTO> AllBusTaskSchedules()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return VBusTaskScheduleConverter.ToDtos(scope.DbContext.VBusTaskSchedules);
            }
        }

        public List<VBusTaskScheduleDTO> AllBusTaskSchedulesByAppNameAndEnv(string appName, string env)
        {
            Ensure.That(appName).IsNotNullOrWhiteSpace();
            Ensure.That(env).IsNotNullOrWhiteSpace();

            List<VBusTaskScheduleDTO> dtoList = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var data = scope.DbContext.VBusTaskSchedules.Where(s =>
                    s.ApplicationEnvironmentName != null &&
                    s.ApplicationEnvironmentName.Equals(env) &&
                    s.ApplicationName != null &&
                    s.ApplicationName.Equals(appName));

                dtoList = VBusTaskScheduleConverter.ToDtos(data);
            }

            return dtoList;
        }

        public async Task SaveBusTaskScheduleProcessLog(ProcessLogDTO logDto)
        {
            Ensure.That(logDto).IsNotNull();
            await CreateBusTaskScheduleProcessLog(logDto.ScheduleDto, logDto, logDto.ParentID, logDto.StatusValue);
        }

        private async Task CreateBusTaskScheduleProcessLog(VBusTaskScheduleDTO taskSchedule, ProcessLogDTO logDto, Guid? parentId, BusTaskStatusEnum statusEnumValue)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                Ensure.That(taskSchedule).IsNotNull();

                // set status to processing
                var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BusTaskScheduleProcessLogStatus.GetStringValue(), statusEnumValue.GetStringValue());

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
                if (logDto != null)
                {
                    log.HasError = logDto.HasError;
                    log.ProcessMessage = logDto.ProcessMessage;
                    log.ProcessDetail = logDto.ProcessDetail;
                    log.NumberOfRetries = logDto.NumberOfRetries;
                    log.IsComplete = logDto.IsComplete;
                }

                scope.DbContext.BusTaskScheduleProcessLogs.Add(log);
                await scope.SaveAsync();
            }
        }
    }
}
