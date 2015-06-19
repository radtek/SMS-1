using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
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
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.TransactionOrders.Single(s => s.InvoiceID.Equals(invoiceId)).ToDto();
            }
        }

        public bool DoesTransactionExistForInvoice(Guid invoiceId)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                return scope.DbContext.TransactionOrders.Any(s => s.InvoiceID.Equals(invoiceId));
            }
        }

        public async Task<TransactionOrderDTO> CreateAndSaveTransactionOrderFromShoppingCartDTO(Guid invoiceID, TransactionTypeIDEnum typeEnumValue)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var invoice = scope.DbContext.Invoices.Single(x => x.InvoiceID == invoiceID);
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

                scope.DbContext.TransactionOrders.Add(order);

                // deal with all orderItems
                foreach (var item in invoice.ShoppingCart.ShoppingCartItems)
                {
                    var orderItem  = TransactionHelper.CreateLineItemFromShoppingCartItem(order, item, cartPrice.Items.Single(x=>x.ShoppingCartItemID == item.ShoppingCartItemID));

                    // find invoice item for cartItem
                    var invoiceLineItem = invoice.InvoiceLineItems.Single(s => s.ParentID == item.ShoppingCartItemID);
                    orderItem.InvoiceLineItemID = invoiceLineItem.InvoiceLineItemID;

                    scope.DbContext.TransactionOrderItems.Add(orderItem);
                }

                // create initial process status log entry
                TransactionHelper.CreateTransactionOrderProcessLog(scope,order.TransactionOrderID,TransactionOrderStatusEnum.Active);

                await scope.SaveAsync();
                return order.ToDtoWithRelated(1);
            }
        }

        //public IList<TransactionOrderDTO> GetOrdersByIds(List<Guid> orderIds)
        //{
        //    Ensure.That(orderIds).IsNotNull();

        //    var dtoList = new List<TransactionOrderDTO>();

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Where(item => orderIds.Contains(item.TransactionOrderID)).ToList().ForEach(item =>
        //        {
        //            var dto = new TransactionOrderDTO();
        //            dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

        //            // populate orders
        //            dto.InjectFrom<NullableInjection>(item);
        //            // populate order items
        //            item.TransactionOrderItems.ToList().ForEach(oi =>
        //            {
        //                var oiDto = new TransactionOrderItemDTO();
        //                oiDto.InjectFrom<NullableInjection>(oi);

        //                dto.TransactionOrderItems.Add(oiDto);
        //            });

        //            dtoList.Add(dto);
        //        });
        //    }

        //    return dtoList;
        //}

        //public TransactionOrderDTO GetOrderByGuid(Guid orderGuid)
        //{
        //    Ensure.That(orderGuid);

        //    TransactionOrderDTO dto = null;

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(orderGuid));
               
        //        dto = new TransactionOrderDTO();
        //        dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

        //        // populate orders
        //        dto.InjectFrom<NullableInjection>(ti);
        //        // populate order items
        //        ti.TransactionOrderItems.ToList().ForEach(oi =>
        //        {
        //            var oiDto = new TransactionOrderItemDTO();
        //            oiDto.InjectFrom<NullableInjection>(oi);

        //            dto.TransactionOrderItems.Add(oiDto);
        //        });
        //    }

        //    return dto;
        //}

        //[EnsureArgumentAspect]
        //public void DeleteOrder(TransactionOrderDTO order)
        //{

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
        //    {
        //        var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(order.TransactionOrderID));

        //        ti.TransactionOrderItems.ToList().ForEach(item =>
        //        {
        //            item.IsActive = false;
        //            item.IsDeleted = true;
        //        });

        //        ti.IsDeleted = true;
        //        ti.IsActive = false;

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}

        //public List<TransactionOrderDTO> SearchOrders(Guid? parentID, Guid? productID, int? orderStatusID, int? paymentStatusID)
        //{
        //    var dtoList = new List<TransactionOrderDTO>();

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        IQueryable<TransactionOrder> query = scope.DbContext.TransactionOrders.Include("TransactionOrderItems");

        //        if (parentID.HasValue)
        //        {
        //            query = query.Where(item => item.ParentID.Equals(parentID.Value));
        //        }

        //        if (orderStatusID.HasValue)
        //        {
        //           // query = query.Where(item => item.OrderStatusID.Equals(orderStatusID.Value));
        //        }

        //        if (paymentStatusID.HasValue)
        //        {
        //           // query = query.Where(item => item.PaymentStatusID.Equals(paymentStatusID.Value));
        //        }

        //        if (productID.HasValue)
        //        {
        //            //query = query.Where(item => item.TransactionOrderItems.Any(it => it.ProductID.Equals(productID)));
        //        }

        //        var items = query.ToList();

        //        items.ForEach(item =>
        //        {
        //            var dto = new TransactionOrderDTO();
        //            dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

        //            // populate orders
        //            dto.InjectFrom<NullableInjection>(item);
        //            // populate order items
        //            item.TransactionOrderItems.ToList().ForEach(oi =>
        //            {
        //                var oiDto = new TransactionOrderItemDTO();
        //                oiDto.InjectFrom<NullableInjection>(oi);

        //                dto.TransactionOrderItems.Add(oiDto);
        //            });

        //            dtoList.Add(dto);
        //        });
        //    }

        //    return dtoList;
        //}

        //public void InsertOrder(TransactionOrderDTO order)
        //{
        //    Ensure.That(order);

        //    var to = new TransactionOrder();

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
        //    {
        //        to.InjectFrom<NullableInjection>(order);

        //        to.TransactionOrderID = Guid.NewGuid();

        //        scope.DbContext.TransactionOrders.Add(to);

        //        if (order.TransactionOrderItems != null)
        //        {
        //            order.TransactionOrderItems.ForEach(item =>
        //            {
        //                var toi = new TransactionOrderItem();
        //                toi.InjectFrom<NullableInjection>(item);
        //                toi.OrderItemID = Guid.NewGuid();
        //                toi.OrderID = to.TransactionOrderID;
                             
        //                scope.DbContext.TransactionOrderItems.Add(toi);
        //            });
        //        }

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}

        //public void UpdateOrder(TransactionOrderDTO order)
        //{
        //    Ensure.That(order).IsNotNull();

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(order.TransactionOrderID));

        //        // update values
        //        ti.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "TransactionOrderID", "TransactionOrderItems" }), order);

        //        if (order.TransactionOrderItems != null)
        //        {
        //            // update orders that exist
        //            order.TransactionOrderItems.ForEach(item =>
        //            {
        //                if (ti.TransactionOrderItems.Any(it => it.OrderItemID.Equals(item.OrderID) && it.IsActive))
        //                {
        //                    var toi = ti.TransactionOrderItems.Single(it => it.OrderItemID.Equals(item.OrderID) && it.IsActive);
        //                    toi.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "OrderItemID", "OrderID" }), item);
        //                }
        //            });

        //            // add order that are new
        //            order.TransactionOrderItems.ForEach(item =>
        //            {
        //                if (!ti.TransactionOrderItems.Any(it => it.OrderItemID.Equals(item.OrderID)))
        //                {
        //                    var toi = new TransactionOrderItem();
        //                    toi.InjectFrom<NullableInjection>(item);
        //                    toi.OrderItemID = Guid.NewGuid();
        //                    toi.OrderID = ti.TransactionOrderID;

        //                    ti.TransactionOrderItems.Add(toi);
        //                }
        //            });
                
        //            // remove any not found
        //            while (ti.TransactionOrderItems.Any(it => !order.TransactionOrderItems.Any(ip => ip.OrderItemID.Equals(it.OrderItemID)) && it.IsActive))
        //            {
        //                var itemToRemove = ti.TransactionOrderItems.Single(it => !order.TransactionOrderItems.Any(ip => ip.OrderItemID.Equals(it.OrderItemID)) && it.IsActive);

        //                if (itemToRemove != null)
        //                {
        //                    itemToRemove.IsActive = false;
        //                    itemToRemove.IsDeleted = true;
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //        }

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}

        //public TransactionOrderDTO GetOrderByAuthorizationTransactionIdAndPaymentMethod(string authorizationTransactionId, string paymentMethodSystemName)
        //{
        //    throw new NotImplementedException();
        //}

        //public TransactionOrderItemDTO GetOrderItemByGuid(Guid orderItemGuid)
        //{
        //    Ensure.That(orderItemGuid);

        //    TransactionOrderItemDTO dto = null;

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
        //    {
        //        var ti = scope.DbContext.TransactionOrderItems.Single(item => item.OrderItemID.Equals(orderItemGuid));

        //        dto = new TransactionOrderItemDTO();

        //        // populate orders
        //        dto.InjectFrom<NullableInjection>(ti);
        //    }

        //    return dto;
        //}

        //public IList<TransactionOrderItemDTO> GetAllOrderItems(Guid? orderId, Guid? parentID, int? orderStatusID, int? paymentStatusID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteOrderItem(TransactionOrderItemDTO orderItem)
        //{
        //    Ensure.That(orderItem);

        //    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
        //    {
        //        var ti = scope.DbContext.TransactionOrderItems.Single(item => item.OrderItemID.Equals(orderItem.OrderItemID));

        //        ti.IsDeleted = true;
        //        ti.IsActive = false;

        //        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
        //    }
        //}
    }
}
