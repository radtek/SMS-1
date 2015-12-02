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
    public partial class VMessageReadDTO
    {
        #region Constructors
  
        public VMessageReadDTO() {
        }

        public VMessageReadDTO(global::System.Nullable<System.Guid> conversationID, global::System.Guid notificationID, global::System.Guid userAccountOrganisationID, global::System.Nullable<bool> isAccepted, global::System.Nullable<System.DateTime> acceptedDate, string email, string firstName, string lastName) {

          this.ConversationID = conversationID;
          this.NotificationID = notificationID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.IsAccepted = isAccepted;
          this.AcceptedDate = acceptedDate;
          this.Email = email;
          this.FirstName = firstName;
          this.LastName = lastName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<System.Guid> ConversationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsAccepted { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AcceptedDate { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        #endregion
    }

}