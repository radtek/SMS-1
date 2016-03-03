using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class TransactionOrderLogicController : LogicBase
    {
        public TransactionOrderLogicController()
        {
        }

        public TransactionOrderDTO GetTransactionForInvoice(Guid invoiceId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrders.Single(s => s.InvoiceID.Equals(invoiceId)).ToDto();
            }
        }

        public bool DoesTransactionExistForInvoice(Guid invoiceId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrders.Any(s => s.InvoiceID.Equals(invoiceId));
            }
        }

        public async Task<TransactionOrderDTO> CreateAndSaveTransactionOrderFromShoppingCartDTO(Guid invoiceID, TransactionTypeIDEnum typeEnumValue)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var invoice = scope.DbContexts.Get<TargetFrameworkEntities>().Invoices.Single(x => x.InvoiceID == invoiceID);
                var cartPrice = CartPricingProcessor.CalculateCartPrice(scope, invoice.ShoppingCartID.Value);

                TransactionOrder order = new TransactionOrder();

                order.ParentID = invoice.ShoppingCart.UserAccountOrganisationID.Value;

                // general fields
                order.TransactionOrderID = Guid.NewGuid();
                order.CountryCode = invoice.ShoppingCart.CountryCode;
                order.CreatedOn = DateTime.Now;
                order.CurrencyRateDate = invoice.ShoppingCart.CurrencyRateDate;
                order.CurrencyCode = invoice.ShoppingCart.CurrencyCode;
                order.CurrencyRate = invoice.ShoppingCart.CurrencyRate;
                order.CurrencyRateToGBP = invoice.ShoppingCart.CurrencyRateToGBP;
                order.CurrencyRateToUSD = invoice.ShoppingCart.CurrencyRateToUSD;
                order.IsActive = true;
                order.IsDeleted = false;

                order.PaymentMethodTypeID = invoice.ShoppingCart.PaymentMethodTypeID;
                order.TransactionTypeID = typeEnumValue.GetIntValue();
                order.TransactionGatewayTypeID = TransactionGatewayIDEnum.FirstData_Merchant_Gateway.GetIntValue();
                order.GlobalPaymentMethodID = invoice.ShoppingCart.GlobalPaymentMethodID;

                order.TransactionOrderReference = Guid.NewGuid().ToString();

                // discount / deductions
                order.DiscountTotalPercentage = cartPrice.CartTotalDiscountsPercentage;
                order.DiscountTotalValue = cartPrice.CartTotalDiscounts;
                order.DeductionTotalPercentage = cartPrice.CartTotalDeductionsPercentage;
                order.DeductionTotalValue = cartPrice.CartTotalDeductions;
                order.OrderDiscountTotal = cartPrice.Discounts;
                order.OrderDeductionTotal = cartPrice.Deductions;

                // tax
                order.TaxTotalPercentage = cartPrice.CartTotalTaxPercentage;
                order.TaxTotalValue = cartPrice.CartTotalTax;
                order.OrderTaxTotal = cartPrice.Tax;

                order.OrderTotal = cartPrice.Total;
                order.OrderSubTotalDiscountsExclTaxAndDeduct = cartPrice.SubTotalDiscountsExclTaxAndDeduct;
                order.OrderSubTotalDiscountsInclTaxAndDeduct = cartPrice.SubTotalDiscountsInclTaxAndDeduct;
                order.OrderSubTotalExclTaxAndDeduct = cartPrice.SubTotalDiscountsExclTaxAndDeduct;
                order.OrderSubTotalInclTaxAndDeduct = cartPrice.SubTotalInclDiscountsAndTaxAndDeduct;

                order.PaymentMethodAdditionalFeesExclTaxAndDeduct = cartPrice.PaymentMethodAdditionalFeesExclTax;
                order.PaymentMethodAdditionalFeesInclTaxAndDeduct = cartPrice.PaymentMethodAdditionalFeesInclTax;

                order.InvoiceID = invoice.InvoiceID;

                order.VatNumber = invoice.VatNumber;

                scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrders.Add(order);

                // deal with all orderItems
                foreach (var item in invoice.ShoppingCart.ShoppingCartItems)
                {
                    var orderItem  = TransactionHelper.CreateLineItemFromShoppingCartItem(order, item, cartPrice.Items.Single(x=>x.ShoppingCartItemID == item.ShoppingCartItemID));

                    // find invoice item for cartItem
                    var invoiceLineItem = invoice.InvoiceLineItems.Single(s => s.ParentID == item.ShoppingCartItemID);
                    orderItem.InvoiceLineItemID = invoiceLineItem.InvoiceLineItemID;

                    scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderItems.Add(orderItem);
                }

                // create initial process status log entry
                TransactionHelper.CreateTransactionOrderProcessLog(scope,order.TransactionOrderID,TransactionOrderStatusEnum.Active);

                await scope.SaveChangesAsync();
                return order.ToDtoWithRelated(1);
            }
        }
    }
}
