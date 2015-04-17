﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class VGlobalAccountingCurrentPeriodDTO
    {
        #region Constructors
  
        public VGlobalAccountingCurrentPeriodDTO() {
        }

        public VGlobalAccountingCurrentPeriodDTO(int globalAccountingPeriodID, global::System.Nullable<System.DateTime> accountingPeriodStart, global::System.Nullable<System.DateTime> accountingPeriodEnd, global::System.Nullable<bool> accountingPeriodFinancialClose, global::System.Nullable<bool> dDIsManuallyDrivenOnly, global::System.Guid globalDirectDebitCollectionPeriodID, global::System.Nullable<int> dDCollectionDay, global::System.Nullable<int> dDCollectionMonth, global::System.Nullable<int> dDCollectionYear, global::System.Nullable<int> accountingPeriodNumber, global::System.Nullable<int> dDPeriodNumber) {

          this.GlobalAccountingPeriodID = globalAccountingPeriodID;
          this.AccountingPeriodStart = accountingPeriodStart;
          this.AccountingPeriodEnd = accountingPeriodEnd;
          this.AccountingPeriodFinancialClose = accountingPeriodFinancialClose;
          this.DDIsManuallyDrivenOnly = dDIsManuallyDrivenOnly;
          this.GlobalDirectDebitCollectionPeriodID = globalDirectDebitCollectionPeriodID;
          this.DDCollectionDay = dDCollectionDay;
          this.DDCollectionMonth = dDCollectionMonth;
          this.DDCollectionYear = dDCollectionYear;
          this.AccountingPeriodNumber = accountingPeriodNumber;
          this.DDPeriodNumber = dDPeriodNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public int GlobalAccountingPeriodID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AccountingPeriodStart { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AccountingPeriodEnd { get; set; }

        [DataMember]
        public global::System.Nullable<bool> AccountingPeriodFinancialClose { get; set; }

        [DataMember]
        public global::System.Nullable<bool> DDIsManuallyDrivenOnly { get; set; }

        [DataMember]
        public global::System.Guid GlobalDirectDebitCollectionPeriodID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DDCollectionDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> DDCollectionMonth { get; set; }

        [DataMember]
        public global::System.Nullable<int> DDCollectionYear { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> DDPeriodNumber { get; set; }

        #endregion
    }

}
