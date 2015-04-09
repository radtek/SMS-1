﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class AddressChronologyDTO
    {
        #region Constructors
  
        public AddressChronologyDTO() {
        }

        public AddressChronologyDTO(global::System.Guid addressChronologyID, global::System.Guid parentID, global::System.DateTime dataFrom, global::System.Nullable<System.DateTime> dateTo, global::System.Nullable<bool> isCurrentAddress, bool isActive, bool isDeleted, AddressDTO address) {

          this.AddressChronologyID = addressChronologyID;
          this.ParentID = parentID;
          this.DataFrom = dataFrom;
          this.DateTo = dateTo;
          this.IsCurrentAddress = isCurrentAddress;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Address = address;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AddressChronologyID { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public global::System.DateTime DataFrom { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> DateTo { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsCurrentAddress { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public AddressDTO Address { get; set; }

        #endregion
    }

}
