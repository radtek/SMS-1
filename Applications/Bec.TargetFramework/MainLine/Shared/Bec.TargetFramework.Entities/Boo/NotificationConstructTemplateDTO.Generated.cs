﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class NotificationConstructTemplateDTO
    {
        #region Constructors
  
        public NotificationConstructTemplateDTO() {
        }

        public NotificationConstructTemplateDTO(global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Nullable<int> notificationConstructTypeID, global::System.Nullable<int> notificationConstructSubTypeID, global::System.Nullable<int> notificationConstructCategoryID, global::System.Nullable<int> notificationConstructSubCategoryID, global::System.Nullable<System.Guid> externalRelatedNotificationConstructTemplateID, global::System.Nullable<int> externalRelatedNotificationConstructTemplateVersionNumber, string notificationSubject, string notificationAdditionalDetails, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> ownerOrganisationID, bool canBeIncludedInBatchNotification, string notificationDetails, string notificationReference, string notificationTitle, global::System.Nullable<int> defaultNotificationExportFormatID, global::System.Nullable<int> defaultNotificationDeliveryMethodID, string notificationConstructMutatorObjectType, List<DefaultOrganisationNotificationConstructTemplateDTO> defaultOrganisationNotificationConstructTemplates, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, List<WorkflowNotificationConstructTemplateDTO> workflowNotificationConstructTemplates, List<NotificationConstructDataTemplateDTO> notificationConstructDataTemplates, List<NotificationConstructParameterTemplateDTO> notificationConstructParameterTemplates, List<NotificationConstructDTO> notificationConstructs, List<ArtefactNotificationConstructTemplateDTO> artefactNotificationConstructTemplates, List<NotificationConstructRoleTemplateDTO> notificationConstructRoleTemplates, List<NotificationConstructTargetTemplateDTO> notificationConstructTargetTemplates, List<ModuleNotificationConstructTemplateDTO> moduleNotificationConstructTemplates, List<WorkflowActionParameterNotificationConstructTemplateDTO> workflowActionParameterNotificationConstructTemplates, List<NotificationConstructGroupNotificationConstructTemplateDTO> notificationConstructGroupNotificationConstructTemplates, OrganisationDTO organisation) {

          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructTypeID = notificationConstructTypeID;
          this.NotificationConstructSubTypeID = notificationConstructSubTypeID;
          this.NotificationConstructCategoryID = notificationConstructCategoryID;
          this.NotificationConstructSubCategoryID = notificationConstructSubCategoryID;
          this.ExternalRelatedNotificationConstructTemplateID = externalRelatedNotificationConstructTemplateID;
          this.ExternalRelatedNotificationConstructTemplateVersionNumber = externalRelatedNotificationConstructTemplateVersionNumber;
          this.NotificationSubject = notificationSubject;
          this.NotificationAdditionalDetails = notificationAdditionalDetails;
          this.ParentID = parentID;
          this.OwnerOrganisationID = ownerOrganisationID;
          this.CanBeIncludedInBatchNotification = canBeIncludedInBatchNotification;
          this.NotificationDetails = notificationDetails;
          this.NotificationReference = notificationReference;
          this.NotificationTitle = notificationTitle;
          this.DefaultNotificationExportFormatID = defaultNotificationExportFormatID;
          this.DefaultNotificationDeliveryMethodID = defaultNotificationDeliveryMethodID;
          this.NotificationConstructMutatorObjectType = notificationConstructMutatorObjectType;
          this.DefaultOrganisationNotificationConstructTemplates = defaultOrganisationNotificationConstructTemplates;
          this.NotificationConstructClaimTemplates = notificationConstructClaimTemplates;
          this.WorkflowNotificationConstructTemplates = workflowNotificationConstructTemplates;
          this.NotificationConstructDataTemplates = notificationConstructDataTemplates;
          this.NotificationConstructParameterTemplates = notificationConstructParameterTemplates;
          this.NotificationConstructs = notificationConstructs;
          this.ArtefactNotificationConstructTemplates = artefactNotificationConstructTemplates;
          this.NotificationConstructRoleTemplates = notificationConstructRoleTemplates;
          this.NotificationConstructTargetTemplates = notificationConstructTargetTemplates;
          this.ModuleNotificationConstructTemplates = moduleNotificationConstructTemplates;
          this.WorkflowActionParameterNotificationConstructTemplates = workflowActionParameterNotificationConstructTemplates;
          this.NotificationConstructGroupNotificationConstructTemplates = notificationConstructGroupNotificationConstructTemplates;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ExternalRelatedNotificationConstructTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ExternalRelatedNotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public string NotificationSubject { get; set; }

        [DataMember]
        public string NotificationAdditionalDetails { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OwnerOrganisationID { get; set; }

        [DataMember]
        public bool CanBeIncludedInBatchNotification { get; set; }

        [DataMember]
        public string NotificationDetails { get; set; }

        [DataMember]
        public string NotificationReference { get; set; }

        [DataMember]
        public string NotificationTitle { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationExportFormatID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationDeliveryMethodID { get; set; }

        [DataMember]
        public string NotificationConstructMutatorObjectType { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationNotificationConstructTemplateDTO> DefaultOrganisationNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructClaimTemplateDTO> NotificationConstructClaimTemplates { get; set; }

        [DataMember]
        public List<WorkflowNotificationConstructTemplateDTO> WorkflowNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructDataTemplateDTO> NotificationConstructDataTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructParameterTemplateDTO> NotificationConstructParameterTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructDTO> NotificationConstructs { get; set; }

        [DataMember]
        public List<ArtefactNotificationConstructTemplateDTO> ArtefactNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructRoleTemplateDTO> NotificationConstructRoleTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructTargetTemplateDTO> NotificationConstructTargetTemplates { get; set; }

        [DataMember]
        public List<ModuleNotificationConstructTemplateDTO> ModuleNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionParameterNotificationConstructTemplateDTO> WorkflowActionParameterNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructGroupNotificationConstructTemplateDTO> NotificationConstructGroupNotificationConstructTemplates { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
