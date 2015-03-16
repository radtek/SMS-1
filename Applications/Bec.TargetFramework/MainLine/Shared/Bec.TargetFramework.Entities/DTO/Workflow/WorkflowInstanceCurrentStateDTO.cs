namespace Bec.TargetFramework.Entities.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public class WorkflowInstanceCurrentStateDTO
    {
        #region Public Properties

        [DataMember]
        public WorkflowActionDTO CurrentActionDTO { get; set; }

        [DataMember]
        public bool CurrentComponentIsAction { get; set; }

        [DataMember]
        public WorkflowDecisionDTO CurrentDecisionDTO { get; set; }

        public bool HasError
        {
            get
            {
                bool errors = false;

                if (this.WorkflowErrors != null && this.WorkflowErrors.Count > 0)
                {
                    errors = true;
                }

                return errors;
            }
        }

        [DataMember]
        public WorkflowInstanceDTO InstanceDTO { get; set; }

        [DataMember]
        public WorkflowInstanceExecutionDTO InstanceExecutionDTO { get; set; }

        [DataMember]
        public WorkflowInstanceExecutionStatusEventDTO InstanceExecutionDataEventDTO { get; set; }

        [DataMember]
        public WorkflowInstanceExecutionDataItemDTO InstanceExecutionDataItemDTO { get; set; }

        [DataMember]
        public List<WorkflowParameterDTO> Parameters { get; set; }

        [DataMember]
        public List<WorkflowErrorBaseDTO> WorkflowErrors { get; set; }

        [DataMember]
        public WorkflowStateBaseDTO WorkflowState { get; set; }

        #endregion
    }
}