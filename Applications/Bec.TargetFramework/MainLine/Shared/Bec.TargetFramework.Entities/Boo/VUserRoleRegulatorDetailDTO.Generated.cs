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
    public partial class VUserRoleRegulatorDetailDTO
    {
        #region Constructors
  
        public VUserRoleRegulatorDetailDTO() {
        }

        public VUserRoleRegulatorDetailDTO(global::System.Guid iD, string email, string lastName, string firstName, global::System.Nullable<int> regulatorID, string regulator, string regulatorNumber, string userRole, string tradingName, string companyName, bool isActive, bool isDeleted) {

          this.ID = iD;
          this.Email = email;
          this.LastName = lastName;
          this.FirstName = firstName;
          this.RegulatorID = regulatorID;
          this.Regulator = regulator;
          this.RegulatorNumber = regulatorNumber;
          this.UserRole = userRole;
          this.TradingName = tradingName;
          this.CompanyName = companyName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ID { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public global::System.Nullable<int> RegulatorID { get; set; }

        [DataMember]
        public string Regulator { get; set; }

        [DataMember]
        public string RegulatorNumber { get; set; }

        [DataMember]
        public string UserRole { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
