using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Entities.Workflow;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Engine;
using Bec.TargetFramework.Workflow.Scheduler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Hosts.WorkflowService
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Entities.Settings;
    using Bec.TargetFramework.Workflow.Configuration;
    using Bec.TargetFramework.Workflow.Helpers;

    [Trace(TraceExceptionsOnly = true)]
    public sealed class WorkflowTaskManager
    {
        private WorkflowTaskScheduler m_Scheduler;
        private bool m_ProcessRunning = false;
        private List<Guid> m_WorkflowInstancesBeingManuallyProcessed;
        private Dictionary<int,Guid> m_WorkflowInstancesBeingProcessed;
        private ILogger m_Logger;
        private WorkflowEngine m_WorkflowEngine;
        private object m_ProcessLock = new object();
        private object m_ProcessListLock = new object();
        private Task m_ProcessingTasks;
        private CancellationTokenSource m_CancellationSource;
        private CancellationToken m_CancellationToken;
        private WorkflowSettings m_WorkflowSetting;

        public WorkflowTaskManager(WorkflowSettings settings,ILogger logger, WorkflowTaskScheduler scheduler,WorkflowEngine engine)
        {
            m_Scheduler = scheduler;
            m_Logger = logger;
            m_WorkflowEngine = engine;
            m_WorkflowSetting = settings;

            m_WorkflowInstancesBeingManuallyProcessed = new List<Guid>();
            m_WorkflowInstancesBeingProcessed = new Dictionary<int,Guid>();
        }

        private bool IsInstanceBeingManuallyProcessed(Guid instanceID)
        {
            var result = false;

            lock(m_ProcessListLock)
                result = m_WorkflowInstancesBeingManuallyProcessed.Contains(instanceID);

            return result;
        }

        private bool IsInstanceBeingProcessed(Guid instanceID)
        {
            var result = false;

            lock (m_ProcessListLock)
                result = m_WorkflowInstancesBeingProcessed.ContainsValue(instanceID);

            return result;
        }

        public void AddWorkflowInstanceBeingManuallyProcessedToPreventExecution(Guid instanceID)
        {
            lock (m_ProcessListLock)
            {
                // first check whether in processing queue, if so remove
                if(m_WorkflowInstancesBeingProcessed.ContainsValue(instanceID))
                {
                    int taskKey = m_WorkflowInstancesBeingProcessed.Single(s => s.Value.Equals(instanceID)).Key;

                    // try and remove task
                    if(m_WorkflowSetting.EnableWorkflowTrace)
                        m_Logger.Trace("Task Manager: Removing Workflow Instance from TaskQueue :" + instanceID);

                    m_Scheduler.RemoveQueuedTask(taskKey);
                }

                // add to processingqueue
                if (!m_WorkflowInstancesBeingManuallyProcessed.Contains(instanceID))
                {
                    if (m_WorkflowSetting.EnableWorkflowTrace)
                        m_Logger.Trace("Task Manager: Adding Workflow Instance to Manual Processing List :" + instanceID);
                    m_WorkflowInstancesBeingManuallyProcessed.Add(instanceID);
                }
            }      
        }

        public bool IsProcessRunning()
        {
            bool running = false;

            lock(m_ProcessLock)
                running = m_ProcessRunning;

            return running;
        }

        public void StartProcess()
        {
            if(!IsProcessRunning())
            {
                lock (m_ProcessLock)
                    m_ProcessRunning = true;

                m_CancellationSource = new CancellationTokenSource();
                m_CancellationToken = m_CancellationSource.Token;

                // start tasks and mark as running
                if (m_WorkflowSetting.EnableWorkflowTrace)
                    m_Logger.Trace("Task Manager: Start Workflow Task Manager Processing");
                m_ProcessingTasks = Task.Factory.StartNew(ProcessingTasks,m_CancellationToken);
            }
        }

        public void StopProcess()
        {
            if(IsProcessRunning())
            {
                lock (m_ProcessLock)
                   m_ProcessRunning = false;

                // cancel process task
                if (m_WorkflowSetting.EnableWorkflowTrace)
                    m_Logger.Trace("Task Manager: Stop Workflow Task Manager Processing");
                m_CancellationSource.Cancel();
            }
        }

        private void ProcessingTasks()
        {
            while (IsProcessRunning())
            {
                // completed current tasks
                if (m_Scheduler.GetCurrentExecutingQueuedTasks() > 0)
                    while (m_Scheduler.GetCurrentExecutingQueuedTasks() > 0)
                    {
                        Thread.Sleep(100);
                    }

                // to enable proper completion of tasks
                Thread.Sleep(2000);

                // get more tasks if available
                var tasksToExecute = GetNotCompletedWorkflows();

                // get not started workflows
                tasksToExecute.AddRange(GetNotStartedWorkflows());

                // restart/start workflows
                tasksToExecute.ForEach(item =>
                    {
                        int? taskId = null;

                        if(item.IsRestartWorkflowTask)
                        {
                            taskId = m_Scheduler.AddTaskToQueueAndExecute<Guid, WorkflowInstanceCurrentStateDTO>(RestartWorkflow(item), item.WorkflowInstanceID);

                            if (m_WorkflowSetting.EnableWorkflowTrace)
                                m_Logger.Trace("Task Manager: Add Restart Workflow Task to Queue InstanceID:" + item.WorkflowInstanceID + " taskId:" + taskId.Value);
                        }
                        else
                        {
                            taskId = m_Scheduler.AddTaskToQueueAndExecute<Guid, WorkflowInstanceCurrentStateDTO>(StartWorkflow(item), item.WorkflowInstanceID);

                            if (m_WorkflowSetting.EnableWorkflowTrace)
                                m_Logger.Trace("Task Manager: Add Start Workflow Task to Queue InstanceID:" + item.WorkflowInstanceID + " taskId:" + taskId.Value);
                        }
                        

                        // register item being processed
                        lock(m_ProcessListLock)
                            m_WorkflowInstancesBeingProcessed.Add(taskId.Value, item.WorkflowInstanceID);
                            
                        // give some breathing space
                        Thread.Sleep(m_WorkflowSetting.GapBetweenProcessingTasksMilliseconds);
                    });
                
            }
        }

        private Func<Guid, WorkflowInstanceCurrentStateDTO> RestartWorkflow(WorkflowTaskObject taskObject)
        {
            Func<Guid, WorkflowInstanceCurrentStateDTO> create = (Guid instanceID) =>
                {
                    var container = m_WorkflowEngine.LoadWorkflowInstanceContainerNotStarted(instanceID);

                    if (m_WorkflowSetting.EnableWorkflowTrace)
                        m_Logger.Trace("Task Manager: Restarting Workflow Instance :" + instanceID);

                    container.WorkflowProcessHandler.RestartWorkflow();

                    var result =  container.WorkflowProcessHandler.CurrentState;

                    // remove item being processed
                    lock(m_ProcessListLock)
                        m_WorkflowInstancesBeingProcessed.Remove(m_WorkflowInstancesBeingProcessed.Where(item => item.Value.Equals(instanceID)).First().Key);

                    return result;
                };

            return create;
        }

        private Func<Guid, WorkflowInstanceCurrentStateDTO> StartWorkflow(WorkflowTaskObject taskObject)
        {
            Func<Guid, WorkflowInstanceCurrentStateDTO> create = (Guid instanceID) =>
            {
                var container = m_WorkflowEngine.LoadWorkflowInstanceContainerNotStarted(instanceID);

                // set temp data for workflow
                container.Data = WorkflowDataHelper.DeserializeData(taskObject.WorkflowInstanceTempData).WorkflowDictionaryDto.WorkflowDictionary;

                if (m_WorkflowSetting.EnableWorkflowTrace)
                    m_Logger.Trace("Task Manager: Starting Workflow Instance :" + instanceID);

                container.WorkflowProcessHandler.StartWorkflow();

                var result = container.WorkflowProcessHandler.CurrentState;

                // remove item being processed
                lock (m_ProcessListLock)
                    m_WorkflowInstancesBeingProcessed.Remove(m_WorkflowInstancesBeingProcessed.Where(item => item.Value.Equals(instanceID)).First().Key);

                return result;
            };

            return create;
        }

        /// <summary>
        /// returns workflows not completed e.g. Last action is not closed and the process is not finished
        /// </summary>
        /// <returns></returns>
        private List<WorkflowTaskObject> GetNotCompletedWorkflows()
        {
            List<WorkflowTaskObject> dtoList = new List<WorkflowTaskObject>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, null))
            {
                DateTime fromDate = DateTime.Now.AddMinutes((Convert.ToInt32(ConfigurationManager.AppSettings["WorkflowActionStepDelayProcessingMinutes"]) * -1));

                // item.StepIsManual.Equals(0)
                scope.DbContext.VWorkflowInstanceExecutionNotCompleteds.Where(item => item.SessionStartedOn <= fromDate && item.StepIsManual.HasValue && !item.StepIsManual.Value.Equals(1)).Take(20).ToList()
                    .ForEach(item =>
                        {
                            if (!IsInstanceBeingProcessed(item.WorkflowInstanceID) && !IsInstanceBeingManuallyProcessed(item.WorkflowInstanceID))
                                dtoList.Add(new WorkflowTaskObject{IsRestartWorkflowTask = true,WorkflowInstanceID = item.WorkflowInstanceID});
                        });
            }

            return dtoList;
        }

        private List<WorkflowTaskObject> GetNotStartedWorkflows()
        {
            List<WorkflowTaskObject> dtoList = new List<WorkflowTaskObject>();
    
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, null))
            {
                // item.StepIsManual.Equals(0)
                scope.DbContext.VWorkflowInstanceNotStarteds.ToList()
                    .ForEach(item =>
                    {
                        if (!IsInstanceBeingProcessed(item.WorkflowInstanceID) && !IsInstanceBeingManuallyProcessed(item.WorkflowInstanceID))
                        {
                            var tempData = scope.DbContext.WorkflowInstances.Single(s => s.WorkflowInstanceID.Equals(item.WorkflowInstanceID)).WorkflowInstanceTempData;
                            dtoList.Add(new WorkflowTaskObject { IsRestartWorkflowTask = false, WorkflowInstanceID = item.WorkflowInstanceID, WorkflowInstanceTempData = tempData });
                        }
                        
                    });
            }

            return dtoList;
        }
    }

    public class WorkflowTaskObject
    {
        public Guid WorkflowInstanceID { get;set;}
        public bool IsRestartWorkflowTask { get;set;}

        public string WorkflowInstanceTempData { get;set;}
    }
}
