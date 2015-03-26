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
    public partial class DefaultOrganisationGroupDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupDTO() {
        }

        public DefaultOrganisationGroupDTO(global::System.Guid defaultOrganisationGroupID, global::System.Guid defaultOrganisationID, string groupName, string groupDescription, global::System.Nullable<int> groupTypeID, global::System.Nullable<int> groupSubTypeID, global::System.Nullable<int> groupCategoryID, global::System.Nullable<int> groupSubCategoryID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> groupID, bool isActive, bool isDeleted, global::System.Nullable<bool> isDefaultOrganisationSpecific, int defaultOrganisationVersionNumber, List<DefaultOrganisationGroupTargetDTO> defaultOrganisationGroupTargets, List<DefaultOrganisationGroupRoleDTO> defaultOrganisationGroupRoles, GroupDTO group, DefaultOrganisationDTO defaultOrganisation) {

          this.DefaultOrganisationGroupID = defaultOrganisationGroupID;
          this.DefaultOrganisationID = defaultOrganisationID;
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
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.DefaultOrganisationGroupTargets = defaultOrganisationGroupTargets;
          this.DefaultOrganisationGroupRoles = defaultOrganisationGroupRoles;
          this.Group = group;
          this.DefaultOrganisation = defaultOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

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
        public int DefaultOrganisationVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationGroupTargetDTO> DefaultOrganisationGroupTargets { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupRoleDTO> DefaultOrganisationGroupRoles { get; set; }

        [DataMember]
        public GroupDTO Group { get; set; }

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        #endregion
    }

}
