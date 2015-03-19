﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class DefaultOrganisationGroupTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupTemplateDTO() {
        }

        public DefaultOrganisationGroupTemplateDTO(global::System.Guid defaultOrganisationGroupTemplateID, global::System.Guid defaultOrganisationTemplateID, string groupName, string groupDescription, global::System.Nullable<int> groupTypeID, global::System.Nullable<int> groupSubTypeID, global::System.Nullable<int> groupCategoryID, global::System.Nullable<int> groupSubCategoryID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> groupID, bool isActive, bool isDeleted, global::System.Nullable<bool> isDefaultOrganisationSpecific, int defaultOrganisationTemplateVersionNumber, List<DefaultOrganisationGroupRoleTemplateDTO> defaultOrganisationGroupRoleTemplates, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, GroupDTO group, List<DefaultOrganisationGroupTargetTemplateDTO> defaultOrganisationGroupTargetTemplates) {

          this.DefaultOrganisationGroupTemplateID = defaultOrganisationGroupTemplateID;
          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.GroupName = groupName;
          this.GroupDescription = groupDescription;
          this.GroupTypeID = groupTypeID;
          this.GroupSubTypeID = groupSubTypeID;
          this.GroupCategoryID = groupCategoryID;
          this.GroupSubCategoryID = groupSubCategoryID;
          this.ParentID = parentID;
          this.GroupID = groupID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsDefaultOrganisationSpecific = isDefaultOrganisationSpecific;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.DefaultOrganisationGroupRoleTemplates = defaultOrganisationGroupRoleTemplates;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.Group = group;
          this.DefaultOrganisationGroupTargetTemplates = defaultOrganisationGroupTargetTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> GroupID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDefaultOrganisationSpecific { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationGroupRoleTemplateDTO> DefaultOrganisationGroupRoleTemplates { get; set; }

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public GroupDTO Group { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupTargetTemplateDTO> DefaultOrganisationGroupTargetTemplates { get; set; }

        #endregion
    }

}
