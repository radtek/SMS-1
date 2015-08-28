using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Infrastructure;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    public class SubscriptionLogic : LogicBase
    {
        private IInvoiceLogic m_InvoiceLogic;

        public SubscriptionLogic(ILogger logger, ICacheProvider cacheProvider, IInvoiceLogic iLogic)
            : base(logger, cacheProvider)
        {
            m_InvoiceLogic = iLogic;
        }

        public void ClosePlanSubscriptionProcessBillingAndCreateNewPeriod(Guid planSubscriptionID, int planSubscriptionVersionNumber,int accountingPeriodToClose)
        {
            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                    true))
            {
                var nextAccountingPeriod = LogicHelper.GetAccountingPeriodDto(scope, accountingPeriodToClose + 1);
                var closeAccountingPeriod = LogicHelper.GetAccountingPeriodDto(scope, accountingPeriodToClose);

                var organisationID = scope.DbContext.PlanSubscriptions.Single(
                    s => s.PlanSubscriptionID.Equals(planSubscriptionID)
                         && s.PlanSubscriptionVersionNumber.Equals(planSubscriptionVersionNumber) && s.IsActive == true && s.IsDeleted == false)
                    .OrganisationID;

                var organisationPaymentMethod = SubscriptionHelper.GetPaymentMethodForSubscription(scope, planSubscriptionID,
                    planSubscriptionVersionNumber, organisationID);

                var billing = SubscriptionHelper.GetBillingForPlanSubscription(scope, planSubscriptionID,
                    planSubscriptionVersionNumber);

                // determine billing dates
                DateTime? billingStartDate = null;
                DateTime? billingEndDate = null;
                //deal with monthly cycle only TBD

                if (billing.BillingPeriodUnitID == PeriodUnitIDEnum.Month.GetIntValue())
                {
                    billingStartDate = nextAccountingPeriod.AccountingPeriodStart;
                    billingEndDate = nextAccountingPeriod.AccountingPeriodEnd;
                }

                // create billing process log
                SubscriptionHelper.CreateSubscriptionBillingProcessLog(scope, planSubscriptionID, planSubscriptionVersionNumber
                    , PlanSubscriptionBillingStatusEnum.Active,
                    billingStartDate.Value, billingEndDate.Value
                    );

                // mark period as closed and crewate new period
                // create new period
                SubscriptionHelper.CreateNextPlanSubscriptionPeriodAndCloseCurrent(scope, planSubscriptionID,
                    planSubscriptionVersionNumber, closeAccountingPeriod, nextAccountingPeriod);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
            

        public PlanSubscriptionDTO SubscribeToPlan(Guid organisationID,Guid planID,int planVersionNumber,Guid globalPaymentMethodID, bool startImmediately)
        {
            PlanSubscriptionDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
            {
                if(SubscriptionHelper.DoesPlanSubscriptionAlreadyExist(scope,planID,planVersionNumber,organisationID))
                    throw new ArgumentException("Organisation:" + organisationID + " already subscribed to plan:" + planID + " version:" + planVersionNumber);

                var plan = SubscriptionHelper.GetPlan(scope, planID, planVersionNumber);

                var billing = SubscriptionHelper.GetBillingForPlan(scope, planID, planVersionNumber);

                var subscription = new PlanSubscription
                {
                    PlanSubscriptionID = Guid.NewGuid(),
                    PlanID = planID,
                    PlanVersionNumber = planVersionNumber,
                    OrganisationID = organisationID,
                    HasInfinitePeriods = plan.HasInfinitePeriods,
                    PlanQuantity = 1,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "system",
                    CountryCode = plan.CountryCode,
                    IsFree = plan.IsFree,
                    IsRenewal = false
                };

                if (startImmediately)
                {
                    subscription.ActivatedOn = DateTime.Now;
                    subscription.IsActive = true;
                }
                else
                    subscription.IsActive = false;

                scope.DbContext.PlanSubscriptions.Add(subscription);

                // add period
                var planDto = SubscriptionHelper.CreatePlanSubscriptionPeriod(scope, subscription, plan);

                // add payment plan
                SubscriptionHelper.CreatePlanSubscriptionPaymentPlan(scope, subscription, globalPaymentMethodID,
                    billing.BillingID);

                // add process log
                if (plan.TrialPeriod > 0)
                    SubscriptionHelper.CreateSubscriptionProcessLog(scope,subscription.PlanSubscriptionID,subscription.PlanSubscriptionVersionNumber,PlanSubscriptionStatusEnum.Trialing);
                else
                    SubscriptionHelper.CreateSubscriptionProcessLog(scope, subscription.PlanSubscriptionID, subscription.PlanSubscriptionVersionNumber, PlanSubscriptionStatusEnum.Active);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;

                dto = PlanSubscriptionConverter.ToDto(subscription);
            }

            return dto;
        }

        public PlanSubscriptionDTO UnsubscribeFromPlan(Guid organisationID, Guid planID, int planVersionNumber, Guid globalPaymentMethodID, bool startImmediately)
        {
            PlanSubscriptionDTO dto = null;



            return dto;
        }

        public PlanSubscriptionDTO AddSubscriptionPeriodToPlan(Guid organisationID, Guid planID, int planVersionNumber, Guid globalPaymentMethodID, bool startImmediately)
        {
            PlanSubscriptionDTO dto = null;



            return dto;
        }

        
        [EnsureArgumentAspect]
        public InvoiceDTO CreateAndSaveInvoiceFromShoppingCart(ShoppingCartDTO cartDto)
        {
            Ensure.That(cartDto.OrganisationID);

            InvoiceDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
            {
               

                var invoiceID = Guid.NewGuid();

                var invoice = new Bec.TargetFramework.Data.Invoice {
                    InvoiceID = invoiceID,
                    ShoppingCartID = cartDto.ShoppingCartID,
                    OrganisationID = cartDto.OrganisationID,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Total = cartDto.PriceDTO.Total,
                    DueDate = DateTime.Now,
                    CountryCode = cartDto.CountryCode,
                    InvoiceTypeID = InvoiceTypeIDEnum.Online.GetIntValue(),
                    
                    InvoiceName = "Online Purchase",
                    CreatedOn = DateTime.Now,
                    CurrencyCode = cartDto.CurrencyCode,
                    InvoiceSubTotalDiscountsExclTaxAndDeduct = cartDto.PriceDTO.SubTotalDiscountsExclTaxAndDeduct,
                    InvoiceSubTotalDiscountsInclTaxAndDeduct = cartDto.PriceDTO.SubTotalDiscountsInclTaxAndDeduct,
                    InvoiceSubTotalExclTaxAndDeduct = cartDto.PriceDTO.SubTotalExclDiscountsAndTaxAndDeduct,
                    InvoiceSubTotalInclTaxAndDeduct = cartDto.PriceDTO.SubTotalInclDiscountsAndTaxAndDeduct,
                    PaymentMethodAdditionalFeesExclTax = cartDto.PriceDTO.PaymentMethodAdditionalFeesExclTax,
                    PaymentMethodAdditionalFeesInclTax = cartDto.PriceDTO.PaymentMethodAdditionalFeesInclTax,
                    TaxTotal = cartDto.PriceDTO.Tax,
                    DiscountTotal = cartDto.PriceDTO.Discounts,
                    TaxTotalPercentage = cartDto.PriceDTO.CartTotalTaxPercentage,
                    TaxTotalValue = cartDto.PriceDTO.CartTotalTax,
                    DeductionTotal = cartDto.PriceDTO.CartTotalDeductions,
                    DeductionTotalPercentage = cartDto.PriceDTO.CartTotalDeductionsPercentage,
                    
                    InvoiceReference = "",
                    IsClosed = false,
                    IsFrozenPendingPayment = true,
                    IsActive = true,
                };

                if (cartDto.OrganisationID.HasValue)
                {
                    int invoiceCount = InvoiceHelper.TotalNumberOfInvoicesForOrganisation(scope, cartDto.OrganisationID.Value);
                    invoice.InvoiceNumber = invoiceCount++;
                    invoice.OrganisationAccountingPeriodID =
                        LogicHelper.GetOrganisationCurrentAccountingPeriod(scope, cartDto.OrganisationID.Value);
                }
                else if (cartDto.UserAccountOrganisationID.HasValue)
                {
                    invoice.InvoiceNumber = 1;
                    invoice.UserAccountOrganisationID = cartDto.UserAccountOrganisationID;
                }

                scope.DbContext.Invoices.Add(invoice);

                // create process log entry
                InvoiceHelper.CreateInvoiceProcessLog(scope,invoice.InvoiceID,InvoiceStatusEnum.Processing,InvoiceAccountingStatusIDEnum.Pending);

                // create line items
                if (cartDto.ShoppingCartItems.Any())
                    cartDto.ShoppingCartItems.ToList()
                        .ForEach(item =>
                        {
                            var lineItem = (InvoiceHelper.CreateLineItemFromShoppingCartItem(invoice, item));

                            // load shopping cartItem and add invoicelineItemID as needed

                            scope.DbContext.InvoiceLineItems.Add(lineItem);

                            var sci = scope.DbContext.ShoppingCartItems.Single(s => s.ShoppingCartItemID.Equals(item.ShoppingCartItemID));

                            sci.InvoiceLineItemID = lineItem.InvoiceLineItemID;
                        });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;

                dto = InvoiceConverter.ToDto(invoice);
            }

            return dto;
        }

        
        [EnsureArgumentAspect]
        public void DeleteInvoice(Guid invoiceID)
        {
            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                    true))
            {
                var invoice =
                    scope.DbContext.Invoices.Include("InvoiceLineItems").Single(s => s.InvoiceID.Equals(invoiceID));

                Ensure.That(invoice).IsNotNull();

                if (invoice.InvoiceLineItems.Any())
                    scope.DbContext.InvoiceLineItems.RemoveRange(invoice.InvoiceLineItems);

                scope.DbContext.Invoices.Remove(invoice);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void FreezeInvoice(Guid invoiceID)
        {
            using (
                var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                    true))
            {
                var invoice =
                    scope.DbContext.Invoices.Single(s => s.InvoiceID.Equals(invoiceID));

                invoice.IsFrozenPendingPayment = true;

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void CloseInvoice(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                var invoice =
                    scope.DbContext.Invoices.Single(s => s.InvoiceID.Equals(invoiceID));

                invoice.IsClosed = true;

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        
        [EnsureArgumentAspect]
        public void AddLineItemToInvoice(InvoiceLineItemDTO dto)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                var invoice =
                    scope.DbContext.Invoices.Include("InvoiceLineItems").Single(s => s.InvoiceID.Equals(dto.InvoiceID));

                var invoiceDto = InvoiceConverter.ToDto(invoice);

                invoice.InvoiceLineItems.ToList().ForEach(inv =>
                {
                    if (invoiceDto.InvoiceLineItems == null)
                        invoiceDto.InvoiceLineItems = new List<InvoiceLineItemDTO>();


                    invoiceDto.InvoiceLineItems.Add(InvoiceLineItemConverter.ToDto(inv));
                });

                //InvoiceHelper.CalculateInvoice(m_ShoppingCartLogic,invoiceDto);

                scope.DbContext.InvoiceLineItems.Add(InvoiceLineItemConverter.ToEntity(dto));

                //TBD recalculate invoice

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void RemoveLineItemToInvoice(InvoiceLineItemDTO dto)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                var invoiceLineItem =
                    scope.DbContext.InvoiceLineItems.Single(
                        s => s.InvoiceID.Equals(dto.InvoiceID) && s.InvoiceLineItemID.Equals(dto.InvoiceLineItemID));

                Ensure.That(invoiceLineItem).IsNotNull();

                scope.DbContext.InvoiceLineItems.Remove(invoiceLineItem);

                //TBD recalculate invoice

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceWithAccountingStatus(Guid invoiceID, InvoiceAccountingStatusIDEnum value)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                var latestProcessLog = scope.DbContext.InvoiceProcessLogs.Where(s => s.InvoiceID.Equals(invoiceID)).OrderByDescending(s => s.CreatedOn).Single();

                Ensure.That(latestProcessLog).IsNotNull();

                latestProcessLog.InvoiceAccountingStatusID = value.GetIntValue();

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        #region Invoice Status

        [EnsureArgumentAspect]
        public void MarkInvoiceAsPaid(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Paid, InvoiceAccountingStatusIDEnum.Paid);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsUnpaid(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Unpaid, InvoiceAccountingStatusIDEnum.Paid_Late);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsCancelled(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Cancelled, InvoiceAccountingStatusIDEnum.Invoice_Withdrawn);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsProcessing(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Processing, InvoiceAccountingStatusIDEnum.Pending);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsPaymentDue(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.PaymentDue, InvoiceAccountingStatusIDEnum.Pending);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsActive(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Active, InvoiceAccountingStatusIDEnum.Pending);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
        [EnsureArgumentAspect]
        public void MarkInvoiceAsPaymentScheduled(Guid invoiceID)
        {
            using (
               var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
                   true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.PaymentScheduled, InvoiceAccountingStatusIDEnum.Pending);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }

        #endregion
    }
}
