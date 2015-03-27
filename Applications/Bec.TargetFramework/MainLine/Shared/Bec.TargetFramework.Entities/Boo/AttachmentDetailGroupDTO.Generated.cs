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
    public partial class AttachmentDetailGroupDTO
    {
        #region Constructors
  
        public AttachmentDetailGroupDTO() {
        }

        public AttachmentDetailGroupDTO(int attachmentDetailGroupID, global::System.Guid attachmentDetailID, global::System.Nullable<System.Guid> organisationGroupID, global::System.Nullable<System.Guid> organisationExternalGroupID, bool isActive, bool isDeleted, AttachmentDetailDTO attachmentDetail, OrganisationGroupDTO organisationGroup) {

          this.AttachmentDetailGroupID = attachmentDetailGroupID;
          this.AttachmentDetailID = attachmentDetailID;
          this.OrganisationGroupID = organisationGroupID;
          this.OrganisationExternalGroupID = organisationExternalGroupID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AttachmentDetail = attachmentDetail;
          this.OrganisationGroup = organisationGroup;
        }

        #endregion

        #region Properties

        [DataMember]
        public int AttachmentDetailGroupID { get; set; }

        [DataMember]
        public global::System.Guid AttachmentDetailID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationGroupID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationExternalGroupID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AttachmentDetailDTO AttachmentDetail { get; set; }

        [DataMember]
        public OrganisationGroupDTO OrganisationGroup { get; set; }

        #endregion
    }

}
