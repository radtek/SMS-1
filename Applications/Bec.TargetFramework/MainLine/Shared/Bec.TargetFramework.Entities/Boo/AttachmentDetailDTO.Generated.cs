﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class AttachmentDetailDTO
    {
        #region Constructors
  
        public AttachmentDetailDTO() {
        }

        public AttachmentDetailDTO(global::System.Guid attachmentDetailID, global::System.Nullable<System.Guid> organisationID, int attachmentTypeID, global::System.Nullable<int> attachmentSubTypeID, global::System.Nullable<int> attachmentCategoryID, global::System.Nullable<System.Guid> repositoryStructureID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, List<AttachmentDetailRoleDTO> attachmentDetailRoles, RepositoryStructureDTO repositoryStructure, List<OrganisationDetailDTO> organisationDetails, List<AttachmentDTO> attachments, List<AttachmentDetailGroupDTO> attachmentDetailGroups, OrganisationDTO organisation) {

          this.AttachmentDetailID = attachmentDetailID;
          this.OrganisationID = organisationID;
          this.AttachmentTypeID = attachmentTypeID;
          this.AttachmentSubTypeID = attachmentSubTypeID;
          this.AttachmentCategoryID = attachmentCategoryID;
          this.RepositoryStructureID = repositoryStructureID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.AttachmentDetailRoles = attachmentDetailRoles;
          this.RepositoryStructure = repositoryStructure;
          this.OrganisationDetails = organisationDetails;
          this.Attachments = attachments;
          this.AttachmentDetailGroups = attachmentDetailGroups;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public int AttachmentTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AttachmentSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AttachmentCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RepositoryStructureID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<AttachmentDetailRoleDTO> AttachmentDetailRoles { get; set; }

        [DataMember]
        public RepositoryStructureDTO RepositoryStructure { get; set; }

        [DataMember]
        public List<OrganisationDetailDTO> OrganisationDetails { get; set; }

        [DataMember]
        public List<AttachmentDTO> Attachments { get; set; }

        [DataMember]
        public List<AttachmentDetailGroupDTO> AttachmentDetailGroups { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
