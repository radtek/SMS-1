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
    public class InvoiceLogic : LogicBase , IInvoiceLogic
    {
        private IClassificationDataLogic m_ClassificationLogic;

        public InvoiceLogic(ILogger logger, ICacheProvider cacheProvider,IClassificationDataLogic dataLogic) : base(logger, cacheProvider)
        {
            m_ClassificationLogic = dataLogic;
        }

        public bool DoesInvoiceExistForShoppingCart(Guid shoppingCartId)
        {
            bool exist = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                exist = scope.DbContext.Invoices.Any(s => s.ShoppingCartID.HasValue && s.ShoppingCartID.Value.Equals(shoppingCartId));
            }

            return exist;
        }

        public VOrganisationDetailDTO GetPaymentProviderOrganisationDetail()
        {
            VOrganisationDetailDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                dto = VOrganisationDetailConverter.ToDto(scope.DbContext.VOrganisationDetails.Single(s => s.IsPaymentProvider.HasValue && s.IsPaymentProvider.Value.Equals(true)));

            }

            return dto;
        }

        public VInvoiceWithCurrentTransactionOrderStatusDTO GetInvoiceWithCurrentTransactionOrderStatus(Guid invoiceID)
        {
            VInvoiceWithCurrentTransactionOrderStatusDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                dto = VInvoiceWithCurrentTransactionOrderStatusConverter.ToDto(scope.DbContext.VInvoiceWithCurrentTransactionOrderStatus.Single(s => s.InvoiceID.Equals(invoiceID)));

            }

            return dto;
        }

        public InvoiceDTO GetInvoiceExistForShoppingCart(Guid shoppingCartId)
        {
            InvoiceDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                dto = InvoiceConverter.ToDto(scope.DbContext.Invoices.Single(s => s.ShoppingCartID.HasValue && s.ShoppingCartID.Value.Equals(shoppingCartId)));

                // add line items
                dto.InvoiceLineItems =
                    InvoiceLineItemConverter.ToDtos(
                        scope.DbContext.InvoiceLineItems.Where(
                            s => s.InvoiceID.HasValue && s.InvoiceID.Value.Equals(dto.InvoiceID)).ToList());

            }

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
                    invoice.OrganisationID = cartDto.OrganisationID;
                    invoice.OrganisationAccountingPeriodID = LogicHelper.GetOrganisationCurrentAccountingPeriod(scope,
                        cartDto.OrganisationID.Value);
                }
                else if (cartDto.UserAccountOrganisationID.HasValue)
                {
                    invoice.UserAccountOrganisationID = cartDto.UserAccountOrganisationID;
                }

                scope.DbContext.Invoices.Add(invoice);

                // create process log entry
                InvoiceHelper.CreateInvoiceProcessLog(scope, invoice.InvoiceID, InvoiceStatusEnum.Processing, InvoiceAccountingStatusIDEnum.Pending);

                List<InvoiceLineItem> invoiceLineItems = new List<InvoiceLineItem>();

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

                            invoiceLineItems.Add(lineItem);
                        });

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;

                dto = InvoiceConverter.ToDto(invoice);
                dto.InvoiceLineItems = InvoiceLineItemConverter.ToDtos(invoiceLineItems);
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
