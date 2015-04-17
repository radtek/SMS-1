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
    public partial class VResourceDTO
    {
        #region Constructors
  
        public VResourceDTO() {
        }

        public VResourceDTO(global::System.Guid resourceID, string resourceName, string resourceDescription, global::System.Nullable<System.Guid> sourceID, global::System.Nullable<int> resourceTypeID, global::System.Nullable<int> resourceCategoryID, global::System.Nullable<int> resourceSubCategoryID, bool isActive, bool isDeleted) {

          this.ResourceID = resourceID;
          this.ResourceName = resourceName;
          this.ResourceDescription = resourceDescription;
          this.SourceID = sourceID;
          this.ResourceTypeID = resourceTypeID;
          this.ResourceCategoryID = resourceCategoryID;
          this.ResourceSubCategoryID = resourceSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ResourceID { get; set; }

        [DataMember]
        public string ResourceName { get; set; }

        [DataMember]
        public string ResourceDescription { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> SourceID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
