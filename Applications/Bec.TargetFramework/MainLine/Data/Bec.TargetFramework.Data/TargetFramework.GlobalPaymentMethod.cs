﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.GlobalPaymentMethod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class GlobalPaymentMethod    {

        public GlobalPaymentMethod()
        {
          this.IsDefaultForOnlinePayments = false;
          this.IsDefaultForOfflinePayments = true;
          this.IsDirectDebit = false;
          this.DirectDebitDefaultMonthlyPeriodNumber = 3;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for GlobalPaymentMethodID in the schema.
        /// </summary>
        public virtual global::System.Guid GlobalPaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodID in the schema.
        /// </summary>
        public virtual int PaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultForOnlinePayments in the schema.
        /// </summary>
        public virtual bool IsDefaultForOnlinePayments
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultForOfflinePayments in the schema.
        /// </summary>
        public virtual bool IsDefaultForOfflinePayments
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> DirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMandateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitMandateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDirectDebit in the schema.
        /// </summary>
        public virtual bool IsDirectDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitDefaultMonthlyPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitDefaultMonthlyPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSDefaultMonthlyPaymentDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSDefaultMonthlyPaymentDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitDefaultNumberOfNotificationDaysBeforeCollection in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitDefaultNumberOfNotificationDaysBeforeCollection
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PlanGlobalPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<PlanGlobalPaymentMethod> PlanGlobalPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanGlobalPaymentMethodTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanGlobalPaymentMethodTemplate> PlanGlobalPaymentMethodTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptionPaymentPlans in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscriptionPaymentPlan> PlanSubscriptionPaymentPlans
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrders in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrder> TransactionOrders
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCarts in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationPaymentMethod> OrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationPaymentMethod> DefaultOrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationPaymentMethodTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationPaymentMethodTemplate> DefaultOrganisationPaymentMethodTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DirectDebitMandate in the schema.
        /// </summary>
        public virtual DirectDebitMandate DirectDebitMandate
        {
            get;
            set;
        }

        #endregion
    }

}
