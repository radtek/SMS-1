﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class OrganisationDetailDTO
    {
        #region Constructors
  
        public OrganisationDetailDTO() {
        }

        public OrganisationDetailDTO(global::System.Guid organisationDetailID, global::System.Guid organisationID, string name, string description, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> organisationDefaultLogoID, string organisationLegalBlurb, AttachmentDetailDTO attachmentDetail, OrganisationDTO organisation) {

          this.OrganisationDetailID = organisationDetailID;
          this.OrganisationID = organisationID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationDefaultLogoID = organisationDefaultLogoID;
          this.OrganisationLegalBlurb = organisationLegalBlurb;
          this.AttachmentDetail = attachmentDetail;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationDetailID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationDefaultLogoID { get; set; }

        [DataMember]
        public string OrganisationLegalBlurb { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AttachmentDetailDTO AttachmentDetail { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
