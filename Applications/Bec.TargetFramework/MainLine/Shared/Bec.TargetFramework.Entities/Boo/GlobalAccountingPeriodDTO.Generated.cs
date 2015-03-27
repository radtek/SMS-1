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
    public partial class GlobalAccountingPeriodDTO
    {
        #region Constructors
  
        public GlobalAccountingPeriodDTO() {
        }

        public GlobalAccountingPeriodDTO(int globalAccountingPeriodID, int periodNumber, int startDay, int endDay, int month, int year, bool isFinancialClosePeriod, bool isCurrentPeriod, bool isClosed, List<OrganisationAccountingPeriodDTO> organisationAccountingPeriods) {

          this.GlobalAccountingPeriodID = globalAccountingPeriodID;
          this.PeriodNumber = periodNumber;
          this.StartDay = startDay;
          this.EndDay = endDay;
          this.Month = month;
          this.Year = year;
          this.IsFinancialClosePeriod = isFinancialClosePeriod;
          this.IsCurrentPeriod = isCurrentPeriod;
          this.IsClosed = isClosed;
          this.OrganisationAccountingPeriods = organisationAccountingPeriods;
        }

        #endregion

        #region Properties

        [DataMember]
        public int GlobalAccountingPeriodID { get; set; }

        [DataMember]
        public int PeriodNumber { get; set; }

        [DataMember]
        public int StartDay { get; set; }

        [DataMember]
        public int EndDay { get; set; }

        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public bool IsFinancialClosePeriod { get; set; }

        [DataMember]
        public bool IsCurrentPeriod { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<OrganisationAccountingPeriodDTO> OrganisationAccountingPeriods { get; set; }

        #endregion
    }

}
