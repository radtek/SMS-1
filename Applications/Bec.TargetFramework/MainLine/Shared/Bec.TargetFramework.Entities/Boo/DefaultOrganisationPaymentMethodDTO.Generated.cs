﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class DefaultOrganisationPaymentMethodDTO
    {
        #region Constructors
  
        public DefaultOrganisationPaymentMethodDTO() {
        }

        public DefaultOrganisationPaymentMethodDTO(global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, global::System.Guid globalPaymentMethodID, bool isActive, bool isDeleted, DefaultOrganisationDTO defaultOrganisation, GlobalPaymentMethodDTO globalPaymentMethod) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisation = defaultOrganisation;
          this.GlobalPaymentMethod = globalPaymentMethod;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        #endregion
    }

}