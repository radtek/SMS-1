﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class VUserWorkflowInstanceStatusDTO
    {
        #region Constructors
  
        public VUserWorkflowInstanceStatusDTO() {
        }

        public VUserWorkflowInstanceStatusDTO(global::System.Guid parentID, global::System.Nullable<System.Guid> userID, global::System.Nullable<System.Guid> userAccountOrganisationID, global::System.Guid workflowID, global::System.Guid workflowInstanceID, int workflowInstanceStatusID, string instancestatus, string workflowtype) {

          this.ParentID = parentID;
          this.UserID = userID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.WorkflowID = workflowID;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceStatusID = workflowInstanceStatusID;
          this.Instancestatus = instancestatus;
          this.Workflowtype = workflowtype;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public int WorkflowInstanceStatusID { get; set; }

        [DataMember]
        public string Instancestatus { get; set; }

        [DataMember]
        public string Workflowtype { get; set; }

        #endregion
    }

}
