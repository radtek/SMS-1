﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class UserAccountOrganisationDTO
    {
        #region Constructors
  
        public UserAccountOrganisationDTO() {
        }

        public UserAccountOrganisationDTO(global::System.Guid userID, global::System.Nullable<int> organisationUnitID, global::System.Guid organisationID, string jobTitle, string nickName, bool isActive, bool isDeleted, global::System.Nullable<int> userSubTypeID, global::System.Nullable<int> userCategoryID, global::System.Guid userAccountOrganisationID, global::System.Nullable<int> userJobTypeID, global::System.Nullable<System.Guid> primaryContactID, global::System.Guid userTypeID, global::System.Nullable<System.Guid> parentID, OrganisationUnitDTO organisationUnit, UserTypeDTO userType, UserAccountDTO userAccount, List<UserAccountOrganisationTeamDTO> userAccountOrganisationTeams, List<UserAccountOrganisationRoleDTO> userAccountOrganisationRoles, List<UserAccountOrganisationGroupDTO> userAccountOrganisationGroups, List<UserAccountOrganisationStatusDTO> userAccountOrganisationStatus, List<WorkflowInstanceRestrictionDTO> workflowInstanceRestrictions, List<NotificationRecipientDTO> notificationRecipients, List<ShoppingCartDTO> shoppingCarts, List<InvoiceDTO> invoices, ContactDTO contact, List<StsSearchDTO> stsSearches, OrganisationDTO organisation) {

          this.UserID = userID;
          this.OrganisationUnitID = organisationUnitID;
          this.OrganisationID = organisationID;
          this.JobTitle = jobTitle;
          this.NickName = nickName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserSubTypeID = userSubTypeID;
          this.UserCategoryID = userCategoryID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.UserJobTypeID = userJobTypeID;
          this.PrimaryContactID = primaryContactID;
          this.UserTypeID = userTypeID;
          this.ParentID = parentID;
          this.OrganisationUnit = organisationUnit;
          this.UserType = userType;
          this.UserAccount = userAccount;
          this.UserAccountOrganisationTeams = userAccountOrganisationTeams;
          this.UserAccountOrganisationRoles = userAccountOrganisationRoles;
          this.UserAccountOrganisationGroups = userAccountOrganisationGroups;
          this.UserAccountOrganisationStatus = userAccountOrganisationStatus;
          this.WorkflowInstanceRestrictions = workflowInstanceRestrictions;
          this.NotificationRecipients = notificationRecipients;
          this.ShoppingCarts = shoppingCarts;
          this.Invoices = invoices;
          this.Contact = contact;
          this.StsSearches = stsSearches;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationUnitID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string JobTitle { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserCategoryID { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserJobTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PrimaryContactID { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationUnitDTO OrganisationUnit { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        [DataMember]
        public List<UserAccountOrganisationTeamDTO> UserAccountOrganisationTeams { get; set; }

        [DataMember]
        public List<UserAccountOrganisationRoleDTO> UserAccountOrganisationRoles { get; set; }

        [DataMember]
        public List<UserAccountOrganisationGroupDTO> UserAccountOrganisationGroups { get; set; }

        [DataMember]
        public List<UserAccountOrganisationStatusDTO> UserAccountOrganisationStatus { get; set; }

        [DataMember]
        public List<WorkflowInstanceRestrictionDTO> WorkflowInstanceRestrictions { get; set; }

        [DataMember]
        public List<NotificationRecipientDTO> NotificationRecipients { get; set; }

        [DataMember]
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public List<StsSearchDTO> StsSearches { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
