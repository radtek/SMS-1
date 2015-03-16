﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class OrganisationWorkflowDTO
    {
        #region Constructors
  
        public OrganisationWorkflowDTO() {
        }

        public OrganisationWorkflowDTO(global::System.Guid organisationWorkflowID, global::System.Guid organisationID, global::System.Guid workflowID, int versionNumber, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, OrganisationDTO organisation, WorkflowDTO workflow) {

          this.OrganisationWorkflowID = organisationWorkflowID;
          this.OrganisationID = organisationID;
          this.WorkflowID = workflowID;
          this.VersionNumber = versionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.Organisation = organisation;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationWorkflowID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int VersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
