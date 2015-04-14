﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class DefaultOrganisationUserTargetTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationUserTargetTemplateDTO() {
        }

        public DefaultOrganisationUserTargetTemplateDTO(global::System.Guid defaultOrganisationUserTargetTemplateID, global::System.Guid defaultOrganisationTemplateID, int defaultOrganisationTemplateVersionNumber, global::System.Nullable<int> userSubTypeID, global::System.Nullable<int> userCategoryID, global::System.Nullable<int> userSubCategoryID, bool isActive, bool isDeleted, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, global::System.Guid userTypeID, bool isDefault, global::System.Nullable<System.Guid> workflowTemplateID, global::System.Nullable<int> workflowTemplateVersionNumber, DefaultOrganisationStatusTypeTemplateDTO defaultOrganisationStatusTypeTemplate, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, UserTypeDTO userType, WorkflowTemplateDTO workflowTemplate, List<DefaultOrganisationGroupTargetTemplateDTO> defaultOrganisationGroupTargetTemplates, List<DefaultOrganisationRoleTargetTemplateDTO> defaultOrganisationRoleTargetTemplates) {

          this.DefaultOrganisationUserTargetTemplateID = defaultOrganisationUserTargetTemplateID;
          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.UserSubTypeID = userSubTypeID;
          this.UserCategoryID = userCategoryID;
          this.UserSubCategoryID = userSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.UserTypeID = userTypeID;
          this.IsDefault = isDefault;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.DefaultOrganisationStatusTypeTemplate = defaultOrganisationStatusTypeTemplate;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.UserType = userType;
          this.WorkflowTemplate = workflowTemplate;
          this.DefaultOrganisationGroupTargetTemplates = defaultOrganisationGroupTargetTemplates;
          this.DefaultOrganisationRoleTargetTemplates = defaultOrganisationRoleTargetTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationUserTargetTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> UserSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationStatusTypeTemplateDTO DefaultOrganisationStatusTypeTemplate { get; set; }

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupTargetTemplateDTO> DefaultOrganisationGroupTargetTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleTargetTemplateDTO> DefaultOrganisationRoleTargetTemplates { get; set; }

        #endregion
    }

}
