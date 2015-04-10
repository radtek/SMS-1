﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class BucketTemplateDTO
    {
        #region Constructors
  
        public BucketTemplateDTO() {
        }

        public BucketTemplateDTO(global::System.Guid bucketTemplateID, string bucketName, string bucketDescription, global::System.Nullable<int> bucketTypeID, global::System.Nullable<int> bucketSubTypeID, global::System.Nullable<int> bucketCategoryID, global::System.Nullable<int> bucketSubCategoryID, bool isGlobal, bool isActive, bool isDeleted, List<DefaultOrganisationTemplateDTO> defaultOrganisationTemplates, List<DefaultOrganisationDTO> defaultOrganisations) {

          this.BucketTemplateID = bucketTemplateID;
          this.BucketName = bucketName;
          this.BucketDescription = bucketDescription;
          this.BucketTypeID = bucketTypeID;
          this.BucketSubTypeID = bucketSubTypeID;
          this.BucketCategoryID = bucketCategoryID;
          this.BucketSubCategoryID = bucketSubCategoryID;
          this.IsGlobal = isGlobal;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationTemplates = defaultOrganisationTemplates;
          this.DefaultOrganisations = defaultOrganisations;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BucketTemplateID { get; set; }

        [DataMember]
        public string BucketName { get; set; }

        [DataMember]
        public string BucketDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> BucketTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BucketSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BucketCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BucketSubCategoryID { get; set; }

        [DataMember]
        public bool IsGlobal { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationTemplateDTO> DefaultOrganisationTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationDTO> DefaultOrganisations { get; set; }

        #endregion
    }

}
