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
    public partial class DirectDebitMandateTemplateDTO
    {
        #region Constructors
  
        public DirectDebitMandateTemplateDTO() {
        }

        public DirectDebitMandateTemplateDTO(global::System.Guid directDebitMandateTemplateID, int directDebitMandateTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, bool isDefaultMandate, List<DirectDebitMandateDTO> directDebitMandates) {

          this.DirectDebitMandateTemplateID = directDebitMandateTemplateID;
          this.DirectDebitMandateTemplateVersionNumber = directDebitMandateTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.IsDefaultMandate = isDefaultMandate;
          this.DirectDebitMandates = directDebitMandates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DirectDebitMandateTemplateID { get; set; }

        [DataMember]
        public int DirectDebitMandateTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsDefaultMandate { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DirectDebitMandateDTO> DirectDebitMandates { get; set; }

        #endregion
    }

}
