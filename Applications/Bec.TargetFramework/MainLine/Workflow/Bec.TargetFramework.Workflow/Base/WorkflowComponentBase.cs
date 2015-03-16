using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Workflow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Workflow.Base
{
    using Bec.TargetFramework.Entities;
    [Serializable]
    public class WorkflowComponentBase : IWorkflowComponent
    {
        public int WorkflowVersionNumber { get;set;}
        public string Name { get;set;}
        public string Description { get;set;}
        public Guid ID { get;set;}
        public IWorkflowContainer ParentContainer {get;set;}
        public List<WorkflowErrorBaseDTO> Errors {get;set;}
        public IWorkflowErrorHandler ErrorHandler {get;set;}
        public Guid? PreviousComponentID {get;set;}
        public System.Collections.Concurrent.ConcurrentDictionary<string, object> Data { get; set; }

        public virtual void Initialise(IWorkflowContainer container, System.Collections.Concurrent.ConcurrentDictionary<string, object> data)
        {
            container.LogTrace("Workflow Component: Initialise " + container.WorkflowProcessHandler.CurrentComponent.ID + " data:" + data);

            ParentContainer = container;

            Data = data;
        }

        public List<IWorkflowParameter> Parameters {get;set;}

        public int? NumberOfRetries
        {
            get
            {
                int? value = null;

                if (this is IWorkflowAction || this is IWorkflowDecision)
                {
                    if (Parameters != null && Parameters.Any(s => s.Name.ToLower().Contains("retries")))
                    {
                        int outValue = 0;
                        if (
                            int.TryParse(
                                Parameters.Single(s => s.Name.ToLower().Contains("retries")).ObjectValue.ToString(),
                                out outValue)) value = outValue;
                    }
                }
                return value;
            }
        }

        public IWorkflowObjectType ObjectType {get;set;}

        public void HandleError(Exception ex, string message = null)
        {
            // log error
            ParentContainer.Logger.Error(ex, message);
        }


        public bool? IsFailure {get;set;}

        public bool HasErrors
        {
            get
            {
                if(Errors != null)
                    return Errors.Count > 0;
                else
                    return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void AddWorkflowError(Exception ex)
        {
            if (Errors == null)
            {
                Errors = new List<WorkflowErrorBaseDTO>();
            }

            Errors.Add(new WorkflowErrorBaseDTO{WorkflowException = ex});

            // add workflow details to exception
            if (ex.Data != null)
            {
                ex.Data.Add("WorkflowInstanceID",ParentContainer.WorkflowInstance.ID.ToString());
                ex.Data.Add("WorkflowComponentID",ParentContainer.WorkflowProcessHandler.CurrentComponent.ID.ToString());
            }

            ParentContainer.Logger.Error(ex);
        }
    }
}
