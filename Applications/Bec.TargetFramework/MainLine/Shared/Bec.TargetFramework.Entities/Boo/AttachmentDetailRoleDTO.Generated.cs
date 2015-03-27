﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class AttachmentDetailRoleDTO
    {
        #region Constructors
  
        public AttachmentDetailRoleDTO() {
        }

        public AttachmentDetailRoleDTO(global::System.Guid attachmentDetailID, global::System.Nullable<System.Guid> organisationRoleID, global::System.Nullable<System.Guid> organisationExternalRoleID, int attachmentDetailRoleID, bool isActive, bool isDeleted, AttachmentDetailDTO attachmentDetail, OrganisationRoleDTO organisationRole) {

          this.AttachmentDetailID = attachmentDetailID;
          this.OrganisationRoleID = organisationRoleID;
          this.OrganisationExternalRoleID = organisationExternalRoleID;
          this.AttachmentDetailRoleID = attachmentDetailRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AttachmentDetail = attachmentDetail;
          this.OrganisationRole = organisationRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationExternalRoleID { get; set; }

        [DataMember]
        public int AttachmentDetailRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AttachmentDetailDTO AttachmentDetail { get; set; }

        [DataMember]
        public OrganisationRoleDTO OrganisationRole { get; set; }

        #endregion
    }

}
