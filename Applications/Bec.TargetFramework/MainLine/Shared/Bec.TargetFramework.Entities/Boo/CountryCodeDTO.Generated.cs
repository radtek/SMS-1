﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class CountryCodeDTO
    {
        #region Constructors
  
        public CountryCodeDTO() {
        }

        public CountryCodeDTO(string countryCode1, string countryName, string currencyCode, List<PlanTemplateDTO> planTemplates, List<InvoiceLineItemDTO> invoiceLineItems, List<PlanDTO> plans, List<InvoiceDTO> invoices, List<PlanSubscriptionDTO> planSubscriptions, List<CountryDeductionDTO> countryDeductions, List<CountryDeductionTemplateDTO> countryDeductionTemplates, CurrencyCodeDTO currencyCode1, List<ContactPhoneDTO> contactPhones, List<AddressDTO> addresses) {

          this.CountryCode1 = countryCode1;
          this.CountryName = countryName;
          this.CurrencyCode = currencyCode;
          this.PlanTemplates = planTemplates;
          this.InvoiceLineItems = invoiceLineItems;
          this.Plans = plans;
          this.Invoices = invoices;
          this.PlanSubscriptions = planSubscriptions;
          this.CountryDeductions = countryDeductions;
          this.CountryDeductionTemplates = countryDeductionTemplates;
          this.CurrencyCode1 = currencyCode1;
          this.ContactPhones = contactPhones;
          this.Addresses = addresses;
        }

        #endregion

        #region Properties

        [DataMember]
        public string CountryCode1 { get; set; }

        [DataMember]
        public string CountryName { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PlanTemplateDTO> PlanTemplates { get; set; }

        [DataMember]
        public List<InvoiceLineItemDTO> InvoiceLineItems { get; set; }

        [DataMember]
        public List<PlanDTO> Plans { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public List<PlanSubscriptionDTO> PlanSubscriptions { get; set; }

        [DataMember]
        public List<CountryDeductionDTO> CountryDeductions { get; set; }

        [DataMember]
        public List<CountryDeductionTemplateDTO> CountryDeductionTemplates { get; set; }

        [DataMember]
        public CurrencyCodeDTO CurrencyCode1 { get; set; }

        [DataMember]
        public List<ContactPhoneDTO> ContactPhones { get; set; }

        [DataMember]
        public List<AddressDTO> Addresses { get; set; }

        #endregion
    }

}
