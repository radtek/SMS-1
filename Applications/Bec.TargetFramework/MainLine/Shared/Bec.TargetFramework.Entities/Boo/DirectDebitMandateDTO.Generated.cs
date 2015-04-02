﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class DirectDebitMandateDTO
    {
        #region Constructors
  
        public DirectDebitMandateDTO() {
        }

        public DirectDebitMandateDTO(global::System.Guid directDebitMandateID, int directDebitMandateVersionNumber, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Guid directDebitMandateTemplateID, int directDebitMandateTemplateVersionNumber, bool isDefaultMandate, DirectDebitMandateTemplateDTO directDebitMandateTemplate, List<OrganisationDirectDebitMandateDTO> organisationDirectDebitMandates, List<GlobalPaymentMethodDTO> globalPaymentMethods) {

          this.DirectDebitMandateID = directDebitMandateID;
          this.DirectDebitMandateVersionNumber = directDebitMandateVersionNumber;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DirectDebitMandateTemplateID = directDebitMandateTemplateID;
          this.DirectDebitMandateTemplateVersionNumber = directDebitMandateTemplateVersionNumber;
          this.IsDefaultMandate = isDefaultMandate;
          this.DirectDebitMandateTemplate = directDebitMandateTemplate;
          this.OrganisationDirectDebitMandates = organisationDirectDebitMandates;
          this.GlobalPaymentMethods = globalPaymentMethods;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DirectDebitMandateID { get; set; }

        [DataMember]
        public int DirectDebitMandateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid DirectDebitMandateTemplateID { get; set; }

        [DataMember]
        public int DirectDebitMandateTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsDefaultMandate { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DirectDebitMandateTemplateDTO DirectDebitMandateTemplate { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateDTO> OrganisationDirectDebitMandates { get; set; }

        [DataMember]
        public List<GlobalPaymentMethodDTO> GlobalPaymentMethods { get; set; }

        #endregion
    }

}
