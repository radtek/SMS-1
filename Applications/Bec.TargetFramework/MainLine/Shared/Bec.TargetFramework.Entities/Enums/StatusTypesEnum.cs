using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum InvoiceStatusEnum : int
    {
        [StringValue("Active")]
        Active=1,
       [StringValue("Processing")]
         Processing=2,
       [StringValue("Cancelled")]
         Cancelled=3,
       [StringValue("Payment Scheduled")]
         PaymentScheduled=4,
       [StringValue("Paid")]
         Paid=5,
       [StringValue("Unpaid")]
         Unpaid=6,
       [StringValue("Payment Due")]
         PaymentDue=7
    }

    public enum PlanSubscriptionStatusEnum : int
    {
        [StringValue("Active")]
        Active = 1,
        [StringValue("Trialing")]
        Trialing = 2,
        [StringValue("Cancelled")]
        Cancelled = 3,
        [StringValue("Suspended")]
        Suspended = 4,
        [StringValue("Expired")]
        Expired = 5,
    }

    public enum PlanSubscriptionBillingStatusEnum : int
    {
        [StringValue("Active")]
        Active = 1,
        [StringValue("Processing")]
        Processing = 2,
        [StringValue("Paid")]
        Paid = 3,
        [StringValue("Unpaid")]
        Unpaid = 4,
        [StringValue("Cancelled")]
        Cancelled = 5,
    }

    public enum TransactionOrderStatusEnum : int
    {
        [StringValue("Active")]
        Active = 1,
        [StringValue("Processing")]
        Processing = 2,
        [StringValue("Successful")]
        Successful = 3,
        [StringValue("Failed")]
        Failed = 4,
        [StringValue("Timeout")]
        Timeout = 5,
    }

    public enum BranchStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Approved")]
        Approved = 2,
        [StringValue("Rejected")]
        Rejected = 3       
    }

    public enum UserStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Approved")]
        Approved = 2,
        [StringValue("Rejected")]
        Rejected = 3 
    }

    public enum OrganisationStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Approved")]
        Approved = 2,
        [StringValue("Rejected")]
        Rejected = 3
    }

    public enum ProfessionalOrganisationStatusEnum : int
    {
        [StringValue("Unverified")]
        Unverified = 1,
        [StringValue("Verified")]
        Verified = 2,
        [StringValue("Rejected")]
        Rejected = 3,
        [StringValue("Expired")]
        Expired = 4,
        [StringValue("Active")]
        Active = 5
    }

    public enum BankAccountStatusEnum : int
    {
        [StringValue("Pending Validation")]
        PendingValidation = 1,
        [StringValue("Safe")]
        Safe = 2,
        [StringValue("Fraud Suspicion")]
        FraudSuspicion = 3,
        [StringValue("Potential Fraud")]
        PotentialFraud = 4
    }

    public enum BusTaskScheduleStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4
    }

    public enum BusMessageStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4,
        [StringValue("Received")]
        Received = 5,
        [StringValue("Sent")]
        Sent = 6
    }

    public enum ProductPurchaseBusTaskStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4
    }

    public enum ProductPurchaseStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Successful")]
        Successful = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Processing")]
        Processing = 4
    }

    public enum ServiceInterfaceStatusEnum : int
    {
        [StringValue("Pending")]
        Pending = 1,
        [StringValue("Processing")]
        Processing = 2,
        [StringValue("Failed")]
        Failed = 3,
        [StringValue("Successful")]
        Successful = 4
    }

    public enum StatusTypeEnum : int
    {
       [StringValue("Invoice Process Log Status")]
       InvoiceProcessLog=1,
       [StringValue("PlanSubscriptionProcessLog Status")]
       PlanSubscriptionProcessLog = 2,
       [StringValue("PlanSubscriptionBillingProcessLog Status")]
       PlanSubscriptionBillingProcessLog = 3,
       [StringValue("Branch Status")]
       Branch = 4,
       [StringValue("User Organisation Status")]
       UserOrganisation  = 5,
       [StringValue("TransactionOrderProcessLog Status")]
       TransactionOrderProcessLog = 6,
       [StringValue("OrganisationPaymentMethod Status")]
       OrganisationPaymentMethod = 7,
       [StringValue("Organisation Status")]
       Organisation = 7,
       [StringValue("OrganisationFinancial Status")]
       OrganisationFinancial = 8,
       [StringValue("ProductPurchase Status")]
       ProductPurchase = 10,
       [StringValue("Service Interface Process Log Status")]
       ServiceInterfaceProcessLog = 11,
       [StringValue("Bus Task Schedule Process Log Status")]
       BusTaskScheduleProcessLogStatus = 12,
       [StringValue("Product Purchase Bus Task Process Log Status")]
       ProductPurchaseBusTaskProcessLogStatus = 13,
       [StringValue("Bus Message Process Log Status")]
       BusMessageProcessLogStatus = 14,
       [StringValue("Professional Organisation Status")]
       ProfessionalOrganisation = 15,
       [StringValue("Bank Account Status")]
       BankAccount = 16,
    }

    
    
}
