using System.Collections.Concurrent;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bec.TargetFramework.Workflow.Interfaces
{
    //Bec.TargetFramework.Entities

    
    [ServiceContract(Namespace = BecTargetFrameworkWorkflowServiceNamespaces.WorkflowNamespace + "/WorkflowProcessService")]
    public interface IWorkflowProcessService
    {
        [OperationContract]
        bool DoesWorkflowNotCompletedExistForParentId(Guid workflowId, int workflowVersionNumber, Guid parentId);

        [OperationContract]
        void CreateWorkflowInstance(Guid workflowID, int versionNumber, WorkflowDictionaryDTO data, Guid parentID, List<UserAccountOrganisationDTO> workflowUsers);
        [OperationContract]
        WorkflowDTO GetWorkflowFromName(string workflowName);
        [OperationContract]
        WorkflowInstanceCurrentStateDTO CreateAndStartWorkflowInstance(Guid workflowID, int versionNumber, WorkflowDictionaryDTO data, Guid parentID, List<UserAccountOrganisationDTO> workflowUsers);
        [OperationContract]
        WorkflowInstanceCurrentStateDTO RestartWorkflowInstance(Guid workflowInstanceID, Guid parentID);
        [OperationContract]
        WorkflowInstanceCurrentStateDTO GetCurrentWorkflowInstanceManualActionNotCompleted(Guid workflowInstanceID);
        [OperationContract]
        WorkflowStateBaseDTO GetDataForWorkflowInstanceStatusEvent(int workflowInstanceStatusEventID);
        [OperationContract]
        WorkflowInstanceCurrentStateDTO RestartWorkflowInstanceViaWebUI(Guid workflowInstanceID,WorkflowStateBaseDTO stateDTO);
        [OperationContract]
        VUserWorkflowInstanceStatusDTO GetWorkflowInstanceFromParentID(Guid parentID);
        [OperationContract]
        VUserWorkflowInstanceStatusDTO GetWorkflowInstanceFromUserID(Guid userID);
        [OperationContract]
        WorkflowInstanceCurrentStateDTO StartWorkflowInstance(Guid workflowInstanceID, Guid parentID);

    }
}
