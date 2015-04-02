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
    public partial class TransactionLevelComponentDTO
    {
        #region Constructors
  
        public TransactionLevelComponentDTO() {
        }

        public TransactionLevelComponentDTO(global::System.Guid transactionLevelComponentID, string name, string description, bool isFixedFee, decimal fixedFee, decimal percentageFee, int countryID, bool isActive, bool isDeleted, global::System.Guid transactionLevelComponentTypeID, global::System.Nullable<System.Guid> transactionLevelComponentSubTypeID, global::System.Nullable<System.Guid> transactionLevelComponentCategoryID, global::System.Nullable<System.Guid> transactionLevelComponentSubCategoryID) {

          this.TransactionLevelComponentID = transactionLevelComponentID;
          this.Name = name;
          this.Description = description;
          this.IsFixedFee = isFixedFee;
          this.FixedFee = fixedFee;
          this.PercentageFee = percentageFee;
          this.CountryID = countryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.TransactionLevelComponentTypeID = transactionLevelComponentTypeID;
          this.TransactionLevelComponentSubTypeID = transactionLevelComponentSubTypeID;
          this.TransactionLevelComponentCategoryID = transactionLevelComponentCategoryID;
          this.TransactionLevelComponentSubCategoryID = transactionLevelComponentSubCategoryID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TransactionLevelComponentID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsFixedFee { get; set; }

        [DataMember]
        public decimal FixedFee { get; set; }

        [DataMember]
        public decimal PercentageFee { get; set; }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid TransactionLevelComponentTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TransactionLevelComponentSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TransactionLevelComponentCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TransactionLevelComponentSubCategoryID { get; set; }

        #endregion
    }

}
