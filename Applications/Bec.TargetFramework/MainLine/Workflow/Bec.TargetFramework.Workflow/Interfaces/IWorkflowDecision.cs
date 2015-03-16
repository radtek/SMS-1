using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Collections;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    public interface IWorkflowDecision : IWorkflowMainComponent, IWorkflowExecutionComponent
    {
        List<IWorkflowComponent> MakeDecision();
        bool IsSuccess { get;}

        List<IWorkflowComponent> SuccessComponents {get;set;}

        List<IWorkflowComponent> FailureComponents { get; set; }

        List<IWorkflowComponent> ErrorComponents { get; set; }
    }
}
