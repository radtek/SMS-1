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
    public partial class NotificationConstructDTO
    {
        #region Constructors
  
        public NotificationConstructDTO() {
        }

        public NotificationConstructDTO(global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, global::System.Nullable<int> notificationConstructTypeID, global::System.Nullable<int> notificationConstructSubTypeID, global::System.Nullable<int> notificationConstructCategoryID, global::System.Nullable<int> notificationConstructSubCategoryID, global::System.Nullable<System.Guid> externalRelatedNotificationConstructID, global::System.Nullable<int> externalRelatedNotificationConstructVersionNumber, string notificationSubject, string notificationTitle, string notificationDetails, string notificationReference, string notificationAdditionalDetails, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> ownerOrganisationID, bool canBeIncludedInBatchNotification, global::System.Nullable<int> defaultNotificationExportFormatID, global::System.Nullable<int> defaultNotificationDeliveryMethodID, string notificationConstructMutatorObjectType, List<DefaultOrganisationNotificationConstructDTO> defaultOrganisationNotificationConstructs, List<ModuleNotificationConstructDTO> moduleNotificationConstructs, List<NotificationConstructClaimDTO> notificationConstructClaims, List<ArtefactNotificationConstructDTO> artefactNotificationConstructs, List<WorkflowNotificationConstructDTO> workflowNotificationConstructs, List<NotificationConstructRoleDTO> notificationConstructRoles, NotificationConstructTemplateDTO notificationConstructTemplate, List<NotificationConstructParameterDTO> notificationConstructParameters, List<NotificationConstructDatumDTO> notificationConstructData, List<NotificationDTO> notifications, List<NotificationConstructTargetDTO> notificationConstructTargets, List<WorkflowActionParameterNotificationConstructDTO> workflowActionParameterNotificationConstructs, List<NotificationConstructGroupNotificationConstructDTO> notificationConstructGroupNotificationConstructs) {

          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.NotificationConstructTypeID = notificationConstructTypeID;
          this.NotificationConstructSubTypeID = notificationConstructSubTypeID;
          this.NotificationConstructCategoryID = notificationConstructCategoryID;
          this.NotificationConstructSubCategoryID = notificationConstructSubCategoryID;
          this.ExternalRelatedNotificationConstructID = externalRelatedNotificationConstructID;
          this.ExternalRelatedNotificationConstructVersionNumber = externalRelatedNotificationConstructVersionNumber;
          this.NotificationSubject = notificationSubject;
          this.NotificationTitle = notificationTitle;
          this.NotificationDetails = notificationDetails;
          this.NotificationReference = notificationReference;
          this.NotificationAdditionalDetails = notificationAdditionalDetails;
          this.ParentID = parentID;
          this.OwnerOrganisationID = ownerOrganisationID;
          this.CanBeIncludedInBatchNotification = canBeIncludedInBatchNotification;
          this.DefaultNotificationExportFormatID = defaultNotificationExportFormatID;
          this.DefaultNotificationDeliveryMethodID = defaultNotificationDeliveryMethodID;
          this.NotificationConstructMutatorObjectType = notificationConstructMutatorObjectType;
          this.DefaultOrganisationNotificationConstructs = defaultOrganisationNotificationConstructs;
          this.ModuleNotificationConstructs = moduleNotificationConstructs;
          this.NotificationConstructClaims = notificationConstructClaims;
          this.ArtefactNotificationConstructs = artefactNotificationConstructs;
          this.WorkflowNotificationConstructs = workflowNotificationConstructs;
          this.NotificationConstructRoles = notificationConstructRoles;
          this.NotificationConstructTemplate = notificationConstructTemplate;
          this.NotificationConstructParameters = notificationConstructParameters;
          this.NotificationConstructData = notificationConstructData;
          this.Notifications = notifications;
          this.NotificationConstructTargets = notificationConstructTargets;
          this.WorkflowActionParameterNotificationConstructs = workflowActionParameterNotificationConstructs;
          this.NotificationConstructGroupNotificationConstructs = notificationConstructGroupNotificationConstructs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ExternalRelatedNotificationConstructID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ExternalRelatedNotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string NotificationSubject { get; set; }

        [DataMember]
        public string NotificationTitle { get; set; }

        [DataMember]
        public string NotificationDetails { get; set; }

        [DataMember]
        public string NotificationReference { get; set; }

        [DataMember]
        public string NotificationAdditionalDetails { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OwnerOrganisationID { get; set; }

        [DataMember]
        public bool CanBeIncludedInBatchNotification { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationExportFormatID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationDeliveryMethodID { get; set; }

        [DataMember]
        public string NotificationConstructMutatorObjectType { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationNotificationConstructDTO> DefaultOrganisationNotificationConstructs { get; set; }

        [DataMember]
        public List<ModuleNotificationConstructDTO> ModuleNotificationConstructs { get; set; }

        [DataMember]
        public List<NotificationConstructClaimDTO> NotificationConstructClaims { get; set; }

        [DataMember]
        public List<ArtefactNotificationConstructDTO> ArtefactNotificationConstructs { get; set; }

        [DataMember]
        public List<WorkflowNotificationConstructDTO> WorkflowNotificationConstructs { get; set; }

        [DataMember]
        public List<NotificationConstructRoleDTO> NotificationConstructRoles { get; set; }

        [DataMember]
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        [DataMember]
        public List<NotificationConstructParameterDTO> NotificationConstructParameters { get; set; }

        [DataMember]
        public List<NotificationConstructDatumDTO> NotificationConstructData { get; set; }

        [DataMember]
        public List<NotificationDTO> Notifications { get; set; }

        [DataMember]
        public List<NotificationConstructTargetDTO> NotificationConstructTargets { get; set; }

        [DataMember]
        public List<WorkflowActionParameterNotificationConstructDTO> WorkflowActionParameterNotificationConstructs { get; set; }

        [DataMember]
        public List<NotificationConstructGroupNotificationConstructDTO> NotificationConstructGroupNotificationConstructs { get; set; }

        #endregion
    }

}
