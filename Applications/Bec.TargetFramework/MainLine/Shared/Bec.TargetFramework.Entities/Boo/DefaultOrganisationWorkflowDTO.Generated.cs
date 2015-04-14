﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class DefaultOrganisationWorkflowDTO
    {
        #region Constructors
  
        public DefaultOrganisationWorkflowDTO() {
        }

        public DefaultOrganisationWorkflowDTO(global::System.Guid defaultOrganisationID, int workflowVersionNumber, global::System.Guid workflowID, global::System.Guid parentID, bool isActive, bool isDeleted, int defaultOrganisationVersionNumber, DefaultOrganisationDTO defaultOrganisation, WorkflowDTO workflow) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowID = workflowID;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.DefaultOrganisation = defaultOrganisation;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
