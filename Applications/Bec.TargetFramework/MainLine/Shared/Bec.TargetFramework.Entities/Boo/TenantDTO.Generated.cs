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
    public partial class TenantDTO
    {
        #region Constructors
  
        public TenantDTO() {
        }

        public TenantDTO(global::System.Guid tenantID, string tenantName, bool isActive, bool isDeleted) {

          this.TenantID = tenantID;
          this.TenantName = tenantName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TenantID { get; set; }

        [DataMember]
        public string TenantName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
