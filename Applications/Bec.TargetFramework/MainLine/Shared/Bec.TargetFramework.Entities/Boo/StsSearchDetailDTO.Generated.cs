﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class StsSearchDetailDTO
    {
        #region Constructors
  
        public StsSearchDetailDTO() {
        }

        public StsSearchDetailDTO(global::System.Guid stsSearchDetailID, global::System.Guid stsSearchID, StsSearchDTO stsSearch) {

          this.StsSearchDetailID = stsSearchDetailID;
          this.StsSearchID = stsSearchID;
          this.StsSearch = stsSearch;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsSearchDetailID { get; set; }

        [DataMember]
        public global::System.Guid StsSearchID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StsSearchDTO StsSearch { get; set; }

        #endregion
    }

}
