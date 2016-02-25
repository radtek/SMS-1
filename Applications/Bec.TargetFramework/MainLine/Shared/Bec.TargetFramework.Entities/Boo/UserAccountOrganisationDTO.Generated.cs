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
    public partial class UserAccountOrganisationDTO
    {
        #region Constructors
  
        public UserAccountOrganisationDTO() {
        }

        public UserAccountOrganisationDTO(global::System.Guid userID, global::System.Nullable<int> organisationUnitID, global::System.Guid organisationID, string jobTitle, string nickName, bool isActive, bool isDeleted, global::System.Nullable<int> userSubTypeID, global::System.Nullable<int> userCategoryID, global::System.Guid userAccountOrganisationID, global::System.Nullable<int> userJobTypeID, global::System.Nullable<System.Guid> primaryContactID, global::System.Guid userTypeID, global::System.Nullable<System.Guid> parentID, string pinCode, global::System.Nullable<System.DateTime> pinCreated, short pinAttempts, global::System.Nullable<long> rowVersion, OrganisationUnitDTO organisationUnit, UserTypeDTO userType, UserAccountDTO userAccount, List<UserAccountOrganisationTeamDTO> userAccountOrganisationTeams, List<UserAccountOrganisationRoleDTO> userAccountOrganisationRoles, List<UserAccountOrganisationGroupDTO> userAccountOrganisationGroups, List<UserAccountOrganisationStatusDTO> userAccountOrganisationStatus, List<NotificationRecipientDTO> notificationRecipients, List<ShoppingCartDTO> shoppingCarts, List<InvoiceDTO> invoices, ContactDTO contact, OrganisationDTO organisation, List<OrganisationLedgerTransactionDTO> organisationLedgerTransactions, List<SmsUserAccountOrganisationTransactionDTO> smsUserAccountOrganisationTransactions, List<ConversationParticipantDTO> conversationParticipants, List<NotificationDTO> notifications, List<FileDTO> files, List<OrganisationNoteDTO> organisationNotes, List<UserAccountOrganisationSafeSendGroupDTO> userAccountOrganisationSafeSendGroups, List<FieldUpdateDTO> fieldUpdates) {

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
          this.PinCode = pinCode;
          this.PinCreated = pinCreated;
          this.PinAttempts = pinAttempts;
          this.RowVersion = rowVersion;
          this.OrganisationUnit = organisationUnit;
          this.UserType = userType;
          this.UserAccount = userAccount;
          this.UserAccountOrganisationTeams = userAccountOrganisationTeams;
          this.UserAccountOrganisationRoles = userAccountOrganisationRoles;
          this.UserAccountOrganisationGroups = userAccountOrganisationGroups;
          this.UserAccountOrganisationStatus = userAccountOrganisationStatus;
          this.NotificationRecipients = notificationRecipients;
          this.ShoppingCarts = shoppingCarts;
          this.Invoices = invoices;
          this.Contact = contact;
          this.Organisation = organisation;
          this.OrganisationLedgerTransactions = organisationLedgerTransactions;
          this.SmsUserAccountOrganisationTransactions = smsUserAccountOrganisationTransactions;
          this.ConversationParticipants = conversationParticipants;
          this.Notifications = notifications;
          this.Files = files;
          this.OrganisationNotes = organisationNotes;
          this.UserAccountOrganisationSafeSendGroups = userAccountOrganisationSafeSendGroups;
          this.FieldUpdates = fieldUpdates;
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

        [DataMember]
        public string PinCode { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> PinCreated { get; set; }

        [DataMember]
        public short PinAttempts { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

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
        public List<NotificationRecipientDTO> NotificationRecipients { get; set; }

        [DataMember]
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public List<OrganisationLedgerTransactionDTO> OrganisationLedgerTransactions { get; set; }

        [DataMember]
        public List<SmsUserAccountOrganisationTransactionDTO> SmsUserAccountOrganisationTransactions { get; set; }

        [DataMember]
        public List<ConversationParticipantDTO> ConversationParticipants { get; set; }

        [DataMember]
        public List<NotificationDTO> Notifications { get; set; }

        [DataMember]
        public List<FileDTO> Files { get; set; }

        [DataMember]
        public List<OrganisationNoteDTO> OrganisationNotes { get; set; }

        [DataMember]
        public List<UserAccountOrganisationSafeSendGroupDTO> UserAccountOrganisationSafeSendGroups { get; set; }

        [DataMember]
        public List<FieldUpdateDTO> FieldUpdates { get; set; }

        #endregion
    }

}
