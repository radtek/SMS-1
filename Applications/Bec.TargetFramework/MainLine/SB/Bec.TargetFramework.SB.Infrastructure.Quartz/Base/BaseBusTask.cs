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
using ServiceStack.Text;
using Autofac;

namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Base
{
    public class BaseBusTask : IJob
    {
        public ILogger m_Logger { get; set; }
        public IBusTaskLogicClient m_BusTaskLogicClient { get; set; }

        public IEventPublishClient m_EventPublishClient { get; set; }
        protected VBusTaskScheduleDTO m_BusTaskScheduleDto { get; set; }

        private ILifetimeScope m_IocContainer;
        private ILifetimeScope m_LifetimeScope;

        private bool m_IsHybridJob = false;

        public ILifetimeScope LifetimeScope
        {
            get { return m_LifetimeScope; }
            set { m_LifetimeScope = value; }
        }

        public BaseBusTask(ILifetimeScope container,ILogger logger,IBusTaskLogicClient busClient,IEventPublishClient eventClient)
        {
            m_Logger = logger;
            m_BusTaskLogicClient = busClient;
            m_EventPublishClient = eventClient;

            m_IocContainer = container;
        }

        public void Execute(IJobExecutionContext context)
        {
            // load related DTO
            LoadBusTaskScheduleDto(context);

            try
            {
                // create scope
                m_LifetimeScope = m_IocContainer.BeginLifetimeScope();

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
            finally
            {
                if (m_LifetimeScope != null)
                    m_LifetimeScope.Dispose();
            }
        }

        /// <summary>
        /// Method to override for logging of task
        /// </summary>
        /// <param name="context"></param>
        public virtual void ExecuteTask(IJobExecutionContext context)
        {
        }

        protected void LoadBusTaskScheduleDto(IJobExecutionContext context)
        {
            m_IsHybridJob = !context.JobDetail.JobDataMap.Any(s => s.Key.Equals("DTO"));

            if(!m_IsHybridJob)
                m_BusTaskScheduleDto = JsonHelper.DeserializeData<VBusTaskScheduleDTO>(context.JobDetail.JobDataMap.GetString("DTO"));
        }

        protected void MarkAsFailed(Exception ex)
        {
            var logDto = new ProcessLogDTO
            {
                HasError = true,
                ProcessDetail = ex.FlattenException().ToJson(),
                ScheduleDto = m_BusTaskScheduleDto,
                StatusValue = BusTaskStatusEnum.Failed
            };

            if (!m_IsHybridJob)
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

            if (!m_IsHybridJob)
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

            if (!m_IsHybridJob)
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

            if (!m_IsHybridJob)
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

            if (!m_IsHybridJob)
                m_BusTaskLogicClient.SaveBusTaskScheduleProcessLog(logDto);
        }
    }
}
