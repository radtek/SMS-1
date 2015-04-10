﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class WorkflowInstanceRestrictionDTO
    {
        #region Constructors
  
        public WorkflowInstanceRestrictionDTO() {
        }

        public WorkflowInstanceRestrictionDTO(global::System.Guid workflowInstanceID, global::System.Nullable<System.Guid> workflowID, global::System.Nullable<int> workflowVersionNumber, global::System.Guid userAccountOrganisationID, bool isActive, bool isDeleted, WorkflowInstanceDTO workflowInstance, UserAccountOrganisationDTO userAccountOrganisation) {

          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowInstance = workflowInstance;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceDTO WorkflowInstance { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
