using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    [Serializable]
    public class WorkflowExecutionComponentBase : WorkflowMainComponentBase, IWorkflowExecutionComponent
    {
        public List<IWorkflowCommand> PreCommands {get;set;}
        public List<IWorkflowCommand> PostCommands {get;set;}

        public List<IWorkflowCommand> ExecuteCommands {get;set;}

        public List<IWorkflowCondition> CompleteConditions {get;set;}

        public List<IWorkflowCondition> StartConditions {get;set;}

        public virtual bool CanStart()
        {
            return true;
        }

        public virtual bool CanComplete()
        {
            return true;
        }

        public virtual bool PerformPreCommands()
        {
            return true;
        }

        public virtual bool PerformExecuteCommands()
        {
            return true;
        }

        public virtual bool PerformPostCommands()
        {
            return true;
        }
        //Change the string to provided T
        public virtual T GetData<T>(ConcurrentDictionary<string, object> data, string key) where T : class
        {
            Ensure.That(data).IsNotNull();
            Ensure.That(key).IsNotNullOrEmpty();
            Ensure.That(data.ContainsKey(key)).IsTrue();

            T t = null;

            object value = null;

            if (data.TryGetValue(key, out value))
                if (value.GetType() == typeof(T))
                    return (T)value;

            return t;
        }

        public virtual bool DataContains(string key)
        {
            return this.Data.ContainsKey(key);
        }
    }
}
