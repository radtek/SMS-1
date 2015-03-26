﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class OrganisationAccountingPeriodDTO
    {
        #region Constructors
  
        public OrganisationAccountingPeriodDTO() {
        }

        public OrganisationAccountingPeriodDTO(int organisationAccountingPeriodID, int globalAccountingPeriodID, global::System.Guid organisationID, List<InvoiceDTO> invoices, GlobalAccountingPeriodDTO globalAccountingPeriod, OrganisationDTO organisation) {

          this.OrganisationAccountingPeriodID = organisationAccountingPeriodID;
          this.GlobalAccountingPeriodID = globalAccountingPeriodID;
          this.OrganisationID = organisationID;
          this.Invoices = invoices;
          this.GlobalAccountingPeriod = globalAccountingPeriod;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationAccountingPeriodID { get; set; }

        [DataMember]
        public int GlobalAccountingPeriodID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public GlobalAccountingPeriodDTO GlobalAccountingPeriod { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
