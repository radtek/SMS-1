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
    public partial class SupportItemDTO
    {
        #region Constructors
  
        public SupportItemDTO() {
        }

        public SupportItemDTO(global::System.Guid supportItemID, int ticketNumber, global::System.Guid userAccountOrganisationID, string telephone, int requestTypeID, string title, string description, bool isClosed, string reason, global::System.DateTime createdOn, global::System.Nullable<System.DateTime> closedOn, string createdBy, string closedBy, bool isDeleted, bool isActive, UserAccountOrganisationDTO userAccountOrganisation) {

          this.SupportItemID = supportItemID;
          this.TicketNumber = ticketNumber;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.Telephone = telephone;
          this.RequestTypeID = requestTypeID;
          this.Title = title;
          this.Description = description;
          this.IsClosed = isClosed;
          this.Reason = reason;
          this.CreatedOn = createdOn;
          this.ClosedOn = closedOn;
          this.CreatedBy = createdBy;
          this.ClosedBy = closedBy;
          this.IsDeleted = isDeleted;
          this.IsActive = isActive;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SupportItemID { get; set; }

        [DataMember]
        public int TicketNumber { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public int RequestTypeID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ClosedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string ClosedBy { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
