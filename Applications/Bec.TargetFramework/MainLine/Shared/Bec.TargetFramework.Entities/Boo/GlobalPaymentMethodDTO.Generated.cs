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
    public partial class GlobalPaymentMethodDTO
    {
        #region Constructors
  
        public GlobalPaymentMethodDTO() {
        }

        public GlobalPaymentMethodDTO(global::System.Guid globalPaymentMethodID, string name, int paymentMethodID, bool isDefaultForOnlinePayments, bool isDefaultForOfflinePayments, global::System.Nullable<System.Guid> directDebitMandateID, global::System.Nullable<int> directDebitMandateVersionNumber, bool isDirectDebit, global::System.Nullable<int> directDebitDefaultMonthlyPeriodNumber, global::System.Nullable<int> directDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber, global::System.Nullable<int> bACSDefaultMonthlyPaymentDay, global::System.Nullable<int> bACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay, global::System.Nullable<int> directDebitDefaultNumberOfNotificationDaysBeforeCollection, global::System.Nullable<int> bACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment, string description, List<PlanGlobalPaymentMethodDTO> planGlobalPaymentMethods, List<PlanGlobalPaymentMethodTemplateDTO> planGlobalPaymentMethodTemplates, List<PlanSubscriptionPaymentPlanDTO> planSubscriptionPaymentPlans, List<TransactionOrderDTO> transactionOrders, List<ShoppingCartDTO> shoppingCarts, List<OrganisationPaymentMethodDTO> organisationPaymentMethods, List<DefaultOrganisationPaymentMethodDTO> defaultOrganisationPaymentMethods, List<DefaultOrganisationPaymentMethodTemplateDTO> defaultOrganisationPaymentMethodTemplates, DirectDebitMandateDTO directDebitMandate) {

          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.Name = name;
          this.PaymentMethodID = paymentMethodID;
          this.IsDefaultForOnlinePayments = isDefaultForOnlinePayments;
          this.IsDefaultForOfflinePayments = isDefaultForOfflinePayments;
          this.DirectDebitMandateID = directDebitMandateID;
          this.DirectDebitMandateVersionNumber = directDebitMandateVersionNumber;
          this.IsDirectDebit = isDirectDebit;
          this.DirectDebitDefaultMonthlyPeriodNumber = directDebitDefaultMonthlyPeriodNumber;
          this.DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber = directDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber;
          this.BACSDefaultMonthlyPaymentDay = bACSDefaultMonthlyPaymentDay;
          this.BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay = bACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay;
          this.DirectDebitDefaultNumberOfNotificationDaysBeforeCollection = directDebitDefaultNumberOfNotificationDaysBeforeCollection;
          this.BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment = bACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment;
          this.Description = description;
          this.PlanGlobalPaymentMethods = planGlobalPaymentMethods;
          this.PlanGlobalPaymentMethodTemplates = planGlobalPaymentMethodTemplates;
          this.PlanSubscriptionPaymentPlans = planSubscriptionPaymentPlans;
          this.TransactionOrders = transactionOrders;
          this.ShoppingCarts = shoppingCarts;
          this.OrganisationPaymentMethods = organisationPaymentMethods;
          this.DefaultOrganisationPaymentMethods = defaultOrganisationPaymentMethods;
          this.DefaultOrganisationPaymentMethodTemplates = defaultOrganisationPaymentMethodTemplates;
          this.DirectDebitMandate = directDebitMandate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int PaymentMethodID { get; set; }

        [DataMember]
        public bool IsDefaultForOnlinePayments { get; set; }

        [DataMember]
        public bool IsDefaultForOfflinePayments { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> DirectDebitMandateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DirectDebitMandateVersionNumber { get; set; }

        [DataMember]
        public bool IsDirectDebit { get; set; }

        [DataMember]
        public global::System.Nullable<int> DirectDebitDefaultMonthlyPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> BACSDefaultMonthlyPaymentDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> DirectDebitDefaultNumberOfNotificationDaysBeforeCollection { get; set; }

        [DataMember]
        public global::System.Nullable<int> BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment { get; set; }

        [DataMember]
        public string Description { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PlanGlobalPaymentMethodDTO> PlanGlobalPaymentMethods { get; set; }

        [DataMember]
        public List<PlanGlobalPaymentMethodTemplateDTO> PlanGlobalPaymentMethodTemplates { get; set; }

        [DataMember]
        public List<PlanSubscriptionPaymentPlanDTO> PlanSubscriptionPaymentPlans { get; set; }

        [DataMember]
        public List<TransactionOrderDTO> TransactionOrders { get; set; }

        [DataMember]
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }

        [DataMember]
        public List<OrganisationPaymentMethodDTO> OrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<DefaultOrganisationPaymentMethodDTO> DefaultOrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<DefaultOrganisationPaymentMethodTemplateDTO> DefaultOrganisationPaymentMethodTemplates { get; set; }

        [DataMember]
        public DirectDebitMandateDTO DirectDebitMandate { get; set; }

        #endregion
    }

}