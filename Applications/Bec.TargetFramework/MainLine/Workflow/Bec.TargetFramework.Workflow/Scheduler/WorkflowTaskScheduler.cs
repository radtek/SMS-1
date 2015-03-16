using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Configuration;

namespace Bec.TargetFramework.Workflow.Scheduler
{
    using Bec.TargetFramework.Aop.Aspects;
    using ServiceStack.Text;
    using Bec.TargetFramework.Entities.Settings;

    [Trace(TraceExceptionsOnly = true)]
    public class WorkflowTaskScheduler
    {
        private readonly WorkflowBaseScheduler m_WorkflowScheduler;
        private ILogger m_Logger;
        private WorkflowSettings m_WorkflowSetting; 

        public WorkflowTaskScheduler(ILogger logger,WorkflowSettings settings)
        {
            
            m_WorkflowScheduler = new WorkflowBaseScheduler();

            m_Logger = logger;
            m_WorkflowSetting = settings;
        }

        public int GetCurrentExecutingQueuedTasks()
        {
            return m_WorkflowScheduler.GetScheduledTasksCount();
        }

        public void RemoveQueuedTask(int taskID)
        {
            try
            {
                m_WorkflowScheduler.RemoveTask(taskID);
            }
            catch (System.Exception ex)
            {
                // may happen if task has just completed its execution
            }
        }

        public int AddTaskToQueueAndExecute<T>(Action<T> taskAction,T parameter)
        {
            // create task and schedule on low priority queue
            var newTask = new Task(() => taskAction(parameter), CancellationToken.None, TaskCreationOptions.None);
            
            // add task completion event
            newTask.ContinueWith(TaskCompletesSuccessfully, TaskContinuationOptions.NotOnFaulted);
            newTask.ContinueWith(TaskFaults, TaskContinuationOptions.OnlyOnFaulted);

            newTask.Start(m_WorkflowScheduler);

            return newTask.Id;
        }

        public int AddTaskToQueueAndExecute<T,TResult>(Func<T,TResult> taskAction, T parameter)
        {
            // create task and schedule on low priority queue
            var newTask = new Task(() => taskAction(parameter), CancellationToken.None, TaskCreationOptions.None);

            // add task completion event
            newTask.ContinueWith(TaskCompletesSuccessfully, TaskContinuationOptions.NotOnFaulted);
            newTask.ContinueWith(TaskFaults, TaskContinuationOptions.OnlyOnFaulted);

            newTask.Start(m_WorkflowScheduler);
            return newTask.Id;
        }

        private void RemoveTask(int id)
        {
            m_WorkflowScheduler.RemoveTask(id);
        }

        public void RaisePriorityOfTask(int id)
        {
            m_WorkflowScheduler.Prioritize(null);
        }

        public void LowerPriorityOfTask(int id)
        {
            m_WorkflowScheduler.Deprioritize(null);
        }

        private void TaskCompletesSuccessfully(Task task)
        {
        }

        private void TaskFaults(Task task)
        {
            // log exceptions
            if (task.Exception != null)
            {
                // log all errors
                if (task.Exception != null)
                    task.Exception.InnerExceptions.ToList().ForEach(e => m_Logger.Error(e));

                if (task.Exception != null)
                    m_Logger.Error(task.Exception);
            }
        }
    }


}
