using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using EnsureThat;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    public class InvoiceLogicController : LogicBase
    {
        public InvoiceLogicController()
        {
        }

        public bool DoesInvoiceExistForShoppingCart(Guid shoppingCartId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.Invoices.Any(s => s.ShoppingCartID.HasValue && s.ShoppingCartID.Value.Equals(shoppingCartId));
            }
        }

        public VOrganisationDetailDTO GetPaymentProviderOrganisationDetail()
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.VOrganisationDetails.Single(s => s.IsPaymentProvider.HasValue && s.IsPaymentProvider.Value.Equals(true)).ToDto();
            }
        }

        public VInvoiceWithCurrentTransactionOrderStatusDTO GetInvoiceWithCurrentTransactionOrderStatus(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.VInvoiceWithCurrentTransactionOrderStatus.Single(s => s.InvoiceID.Equals(invoiceID)).ToDto();
            }
        }

        public InvoiceDTO GetInvoiceForShoppingCart(Guid shoppingCartId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.Invoices.Single(s => s.ShoppingCartID == shoppingCartId).ToDtoWithRelated(1);
            }
        }

        [EnsureArgumentAspect]
        public async Task<InvoiceDTO> CreateAndSaveInvoiceFromShoppingCartAsync(Guid cartID, string reference)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var cart = scope.DbContext.ShoppingCarts.Single(x => x.ShoppingCartID == cartID);
                var cartPriceDto = CartPricingProcessor.CalculateCartPrice(scope, cartID);

                var invoiceID = Guid.NewGuid();

                var invoice = new Bec.TargetFramework.Data.Invoice
                {
                    InvoiceID = invoiceID,
                    ShoppingCartID = cartID,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Total = cartPriceDto.Total,
                    DueDate = DateTime.Now,
                    CountryCode = cart.CountryCode,
                    InvoiceTypeID = InvoiceTypeIDEnum.Online.GetIntValue(),

                    InvoiceName = "Online Purchase",
                    CreatedOn = DateTime.Now,
                    CurrencyCode = cart.CurrencyCode,
                    InvoiceSubTotalDiscountsExclTaxAndDeduct = cartPriceDto.SubTotalDiscountsExclTaxAndDeduct,
                    InvoiceSubTotalDiscountsInclTaxAndDeduct = cartPriceDto.SubTotalDiscountsInclTaxAndDeduct,
                    InvoiceSubTotalExclTaxAndDeduct = cartPriceDto.SubTotalExclDiscountsAndTaxAndDeduct,
                    InvoiceSubTotalInclTaxAndDeduct = cartPriceDto.SubTotalInclDiscountsAndTaxAndDeduct,
                    PaymentMethodAdditionalFeesExclTax = cartPriceDto.PaymentMethodAdditionalFeesExclTax,
                    PaymentMethodAdditionalFeesInclTax = cartPriceDto.PaymentMethodAdditionalFeesInclTax,
                    TaxTotal = cartPriceDto.Tax,
                    DiscountTotal = cartPriceDto.Discounts,
                    TaxTotalPercentage = cartPriceDto.CartTotalTaxPercentage,
                    TaxTotalValue = cartPriceDto.CartTotalTax,
                    DeductionTotal = cartPriceDto.CartTotalDeductions,
                    DeductionTotalPercentage = cartPriceDto.CartTotalDeductionsPercentage,
                    InvoiceReference = reference,
                    IsClosed = false,
                    IsFrozenPendingPayment = true,
                    IsActive = true,
                };

                if (cart.OrganisationID.HasValue)
                {
                    int invoiceCount = InvoiceHelper.TotalNumberOfInvoicesForOrganisation(scope, cart.OrganisationID.Value);
                    invoice.InvoiceNumber = invoiceCount++;
                    invoice.OrganisationID = cart.OrganisationID.Value;
                    invoice.OrganisationAccountingPeriodID = LogicHelper.GetOrganisationCurrentAccountingPeriod(scope, cart.OrganisationID.Value);
                }
                else if (cart.UserAccountOrganisationID.HasValue)
                    invoice.UserAccountOrganisationID = cart.UserAccountOrganisationID;

                scope.DbContext.Invoices.Add(invoice);

                // create process log entry
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoice.InvoiceID, InvoiceStatusEnum.Processing, InvoiceAccountingStatusIDEnum.Pending);

                foreach (var item in cart.ShoppingCartItems)
                {
                    var lineItem = InvoiceHelper.CreateLineItemFromShoppingCartItem(invoice, item, cartPriceDto.Items.Single(x => x.ShoppingCartItemID == item.ShoppingCartItemID));
                    scope.DbContext.InvoiceLineItems.Add(lineItem);
                }

                await scope.SaveAsync();

                return invoice.ToDtoWithRelated(1);
            }
        }


        [EnsureArgumentAspect]
        public async Task DeleteInvoiceAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var invoice = scope.DbContext.Invoices.Include("InvoiceLineItems").Single(s => s.InvoiceID.Equals(invoiceID));

                Ensure.That(invoice).IsNotNull();

                if (invoice.InvoiceLineItems.Any())
                    scope.DbContext.InvoiceLineItems.RemoveRange(invoice.InvoiceLineItems);

                scope.DbContext.Invoices.Remove(invoice);
                await scope.SaveAsync();
            }
        }

        [EnsureArgumentAspect]
        public async Task FreezeInvoiceAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var invoice = scope.DbContext.Invoices.Single(s => s.InvoiceID.Equals(invoiceID));
                invoice.IsFrozenPendingPayment = true;
                await scope.SaveAsync();
            }
        }

        [EnsureArgumentAspect]
        public async Task CloseInvoiceAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var invoice = scope.DbContext.Invoices.Single(s => s.InvoiceID.Equals(invoiceID));

                invoice.IsClosed = true;
                await scope.SaveAsync();
            }
        }

        //[EnsureArgumentAspect]
        //public void AddLineItemToInvoice(InvoiceLineItemDTO dto)
        //{
        //    using (
        //       var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //           true))
        //    {
        //        var invoice =
        //            scope.DbContext.Invoices.Include("InvoiceLineItems").Single(s => s.InvoiceID.Equals(dto.InvoiceID));

        //        var invoiceDto = InvoiceConverter.ToDto(invoice);

        //        invoice.InvoiceLineItems.ToList().ForEach(inv =>
        //        {
        //            if (invoiceDto.InvoiceLineItems == null)
        //                invoiceDto.InvoiceLineItems = new List<InvoiceLineItemDTO>();


        //            invoiceDto.InvoiceLineItems.Add(InvoiceLineItemConverter.ToDto(inv));
        //        });

        //        //InvoiceHelper.CalculateInvoice(m_ShoppingCartLogic,invoiceDto);

        //        scope.DbContext.InvoiceLineItems.Add(InvoiceLineItemConverter.ToEntity(dto));

        //        //TBD recalculate invoice

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}
        //[EnsureArgumentAspect]
        //public void RemoveLineItemToInvoice(InvoiceLineItemDTO dto)
        //{
        //    using (
        //       var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,
        //           true))
        //    {
        //        var invoiceLineItem =
        //            scope.DbContext.InvoiceLineItems.Single(
        //                s => s.InvoiceID.Equals(dto.InvoiceID) && s.InvoiceLineItemID.Equals(dto.InvoiceLineItemID));

        //        Ensure.That(invoiceLineItem).IsNotNull();

        //        scope.DbContext.InvoiceLineItems.Remove(invoiceLineItem);

        //        //TBD recalculate invoice

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}

        [EnsureArgumentAspect]
        public async Task MarkInvoiceWithAccountingStatusAsync(Guid invoiceID, InvoiceAccountingStatusIDEnum value)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var latestProcessLog = scope.DbContext.InvoiceProcessLogs.Where(s => s.InvoiceID.Equals(invoiceID)).OrderByDescending(s => s.CreatedOn).Single();

                Ensure.That(latestProcessLog).IsNotNull();

                latestProcessLog.InvoiceAccountingStatusID = value.GetIntValue();

                await scope.SaveAsync();
            }
        }

        #region Invoice Status

        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsPaidAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Paid, InvoiceAccountingStatusIDEnum.Paid);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsUnpaidAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Unpaid, InvoiceAccountingStatusIDEnum.Paid_Late);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsCancelledAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Cancelled, InvoiceAccountingStatusIDEnum.Invoice_Withdrawn);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsProcessingAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Processing, InvoiceAccountingStatusIDEnum.Pending);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsPaymentDueAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.PaymentDue, InvoiceAccountingStatusIDEnum.Pending);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsActiveAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.Active, InvoiceAccountingStatusIDEnum.Pending);

                await scope.SaveAsync();
            }
        }
        [EnsureArgumentAspect]
        public async Task MarkInvoiceAsPaymentScheduledAsync(Guid invoiceID)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoiceID, InvoiceStatusEnum.PaymentScheduled, InvoiceAccountingStatusIDEnum.Pending);

                await scope.SaveAsync();
            }
        }

        #endregion
    }
}
