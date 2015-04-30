using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Client.Clients;

namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Base
{
    public class BaseBusTask : IJob
    {
        protected ILogger m_Logger { get; set; }
        protected IBusTaskLogicClient m_BusTaskLogicClient { get; set; }
        protected VBusTaskScheduleDTO m_BusTaskScheduleDto { get; set; }

        public BaseBusTask(ILogger logger, IBusTaskLogicClient busTaskClient)
        {
            m_Logger = logger;
            m_BusTaskLogicClient = busTaskClient;
        }

        public void Execute(IJobExecutionContext context)
        {
            // load related DTO
            LoadBusTaskScheduleDto(context);

            try
            {
                MarkAsProcessing();

                // Execute task
                ExecuteTask(context);

                MarkAsSuccessful();
            }
            catch (Exception ex)
            {
                MarkAsFailed(ex);

                m_Logger.Error(ex);

                throw;
            }
        }

        public virtual void ExecuteTask(IJobExecutionContext context)
        {
        }

        protected void LoadBusTaskScheduleDto(IJobExecutionContext context)
        {
            m_BusTaskScheduleDto = JsonHelper.DeserializeData<VBusTaskScheduleDTO>(context.JobDetail.JobDataMap.GetString("DTO"));
        }

        protected void MarkAsFailed(Exception ex)
        {
            var logDto = new ProcessLogDTO
            {
                HasError = true,
                ProcessDetail = ex.FlattenException(),
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Failed
            };

            m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }

        protected void MarkAsSuccessful(string processDetail = null,string processMessage= null)
        {
            var logDto = new ProcessLogDTO
            {
                IsComplete = true,
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Successful
            };

            if (processDetail != null)
                logDto.ProcessDetail = processDetail;

            if (processMessage != null)
                logDto.ProcessMessage = processMessage;

            m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }

        protected void MarkAsProcessing()
        {
            var logDto = new ProcessLogDTO
            {
                IsComplete = true,
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Processing
            };

            m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }

        protected void CreateProcessLogEntryWhilstProcessing(string processMessage,string processDetail = null)
        {
            var logDto = new ProcessLogDTO
            {
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Processing,
                ProcessMessage = processMessage,
                ProcessDetail = processDetail
            };

            m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }

        protected void MarkAsPending()
        {
            var logDto = new ProcessLogDTO
            {
                IsComplete = true,
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Pending
            };

            m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }
    }
}
