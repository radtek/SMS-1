﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class VWorkflowInstanceNotStartedDTO
    {
        #region Constructors
  
        public VWorkflowInstanceNotStartedDTO() {
        }

        public VWorkflowInstanceNotStartedDTO(global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowInstanceID, int workflowInstanceStatusID, string name, global::System.Guid parentID) {

          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceStatusID = workflowInstanceStatusID;
          this.Name = name;
          this.ParentID = parentID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public int WorkflowInstanceStatusID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        #endregion
    }

}
