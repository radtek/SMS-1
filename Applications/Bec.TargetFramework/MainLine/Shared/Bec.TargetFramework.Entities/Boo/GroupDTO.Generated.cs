﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class GroupDTO
    {
        #region Constructors
  
        public GroupDTO() {
        }

        public GroupDTO(global::System.Guid groupID, string groupName, string groupDescription, int groupTypeID, global::System.Nullable<int> groupSubTypeID, global::System.Nullable<int> groupCategoryID, global::System.Nullable<int> groupSubCategoryID, bool isActive, bool isDeleted, global::System.Nullable<bool> isGlobal, List<DefaultOrganisationGroupTemplateDTO> defaultOrganisationGroupTemplates, List<DefaultOrganisationGroupDTO> defaultOrganisationGroups, List<GroupRoleDTO> groupRoles) {

          this.GroupID = groupID;
          this.GroupName = groupName;
          this.GroupDescription = groupDescription;
          this.GroupTypeID = groupTypeID;
          this.GroupSubTypeID = groupSubTypeID;
          this.GroupCategoryID = groupCategoryID;
          this.GroupSubCategoryID = groupSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsGlobal = isGlobal;
          this.DefaultOrganisationGroupTemplates = defaultOrganisationGroupTemplates;
          this.DefaultOrganisationGroups = defaultOrganisationGroups;
          this.GroupRoles = groupRoles;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid GroupID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public int GroupTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsGlobal { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationGroupTemplateDTO> DefaultOrganisationGroupTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupDTO> DefaultOrganisationGroups { get; set; }

        [DataMember]
        public List<GroupRoleDTO> GroupRoles { get; set; }

        #endregion
    }

}
