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
    public partial class VNotificationConstructGroupNotificationConstructDTO
    {
        #region Constructors
  
        public VNotificationConstructGroupNotificationConstructDTO() {
        }

        public VNotificationConstructGroupNotificationConstructDTO(global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Guid notificationConstructGroupID, int notificationConstructGroupVersion, string name, int organisationTypeID, string organisationType, global::System.Guid userTypeID, string userType, global::System.Guid workflowID, int workflowVersionNumber, string workflowName, string conditionString) {

          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.NotificationConstructGroupID = notificationConstructGroupID;
          this.NotificationConstructGroupVersion = notificationConstructGroupVersion;
          this.Name = name;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationType = organisationType;
          this.UserTypeID = userTypeID;
          this.UserType = userType;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowName = workflowName;
          this.ConditionString = conditionString;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructGroupID { get; set; }

        [DataMember]
        public int NotificationConstructGroupVersion { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public string OrganisationType { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public string WorkflowName { get; set; }

        [DataMember]
        public string ConditionString { get; set; }

        #endregion
    }

}
