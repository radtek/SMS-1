﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class DefaultOrganisationPaymentMethodTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationPaymentMethodTemplateDTO() {
        }

        public DefaultOrganisationPaymentMethodTemplateDTO(global::System.Guid defaultOrganisationTemplateID, int defaultOrganisationTemplateVersionNumber, global::System.Guid globalPaymentMethodID, bool isActive, bool isDeleted, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, GlobalPaymentMethodDTO globalPaymentMethod) {

          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.GlobalPaymentMethod = globalPaymentMethod;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        #endregion
    }

}
