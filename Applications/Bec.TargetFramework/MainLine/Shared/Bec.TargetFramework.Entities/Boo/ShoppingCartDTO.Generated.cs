﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class ShoppingCartDTO
    {
        #region Constructors
  
        public ShoppingCartDTO() {
        }

        public ShoppingCartDTO(global::System.Guid shoppingCartID, bool isActive, bool isDeleted, global::System.DateTime createdOn, bool hasBeenConvertedToTransactionOrder, bool hasExpired, string currencyCode, global::System.DateTime currencyRateDate, decimal currencyRate, decimal currencyRateToGBP, decimal currencyRateToUSD, string countryCode, global::System.Guid globalPaymentMethodID, global::System.Nullable<System.Guid> organisationID, int paymentCardTypeID, int paymentMethodTypeID, global::System.Nullable<System.Guid> userAccountOrganisationID, List<ShoppingCartItemDTO> shoppingCartItems, List<CountryDeductionDTO> countryDeductions, List<InvoiceDTO> invoices, GlobalPaymentMethodDTO globalPaymentMethod, UserAccountOrganisationDTO userAccountOrganisation, OrganisationDTO organisation) {

          this.ShoppingCartID = shoppingCartID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CreatedOn = createdOn;
          this.HasBeenConvertedToTransactionOrder = hasBeenConvertedToTransactionOrder;
          this.HasExpired = hasExpired;
          this.CurrencyCode = currencyCode;
          this.CurrencyRateDate = currencyRateDate;
          this.CurrencyRate = currencyRate;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
          this.CountryCode = countryCode;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.OrganisationID = organisationID;
          this.PaymentCardTypeID = paymentCardTypeID;
          this.PaymentMethodTypeID = paymentMethodTypeID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.ShoppingCartItems = shoppingCartItems;
          this.CountryDeductions = countryDeductions;
          this.Invoices = invoices;
          this.GlobalPaymentMethod = globalPaymentMethod;
          this.UserAccountOrganisation = userAccountOrganisation;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public bool HasBeenConvertedToTransactionOrder { get; set; }

        [DataMember]
        public bool HasExpired { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public global::System.DateTime CurrencyRateDate { get; set; }

        [DataMember]
        public decimal CurrencyRate { get; set; }

        [DataMember]
        public decimal CurrencyRateToGBP { get; set; }

        [DataMember]
        public decimal CurrencyRateToUSD { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public int PaymentCardTypeID { get; set; }

        [DataMember]
        public int PaymentMethodTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserAccountOrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }

        [DataMember]
        public List<CountryDeductionDTO> CountryDeductions { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
