using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;

using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using NHibernate.Criterion;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class TransactionOrderLogic : LogicBase, ITransactionOrderLogic
    {
        private readonly IShoppingCartLogic m_ShoppingLogic;
        private readonly IProductLogic m_ProductLogic;
        private readonly ProductPricingProcessor m_ProductPricingProcessor;
        private readonly CartPricingProcessor m_CartPricingProcessor;

        public TransactionOrderLogic(ILogger logger, ICacheProvider cacheProvider, IShoppingCartLogic sLogic, IProductLogic pLogic,ProductPricingProcessor pProcessor,CartPricingProcessor cProcessor) : base(logger, cacheProvider)
        {
            this.m_ShoppingLogic = sLogic;
            this.m_ProductLogic = pLogic;
            m_ProductPricingProcessor = pProcessor;
            m_CartPricingProcessor = cProcessor;
        }

        public TransactionOrderDTO GetTransactionForInvoice(Guid invoiceId)
        {
            TransactionOrderDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                dto = TransactionOrderConverter.ToDto(scope.DbContext.TransactionOrders.Single(s => s.InvoiceID.Equals(invoiceId)));
            }

            return dto;
        }

        public bool DoesTransactionExistForInvoice(Guid invoiceId)
        {
            bool exist = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                exist = scope.DbContext.TransactionOrders.Any(s => s.InvoiceID.Equals(invoiceId));
            }

            return exist;
        }

        public TransactionOrderDTO CreateAndSaveTransactionOrderFromShoppingCartDTO(VUserAccountOrganisationDTO clientUaoDto, ShoppingCartDTO dto,InvoiceDTO invoiceDto,TransactionTypeIDEnum typeEnumValue)
        {
            TransactionOrderDTO tDto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                TransactionOrder order = new TransactionOrder();

                order.ParentID = clientUaoDto.UserAccountOrganisationID;

                // general fields
                order.TransactionOrderID = Guid.NewGuid();
                order.CountryCode = dto.CountryCode;
                order.CreatedOn = DateTime.Now;
                order.CurrencyRateDate = dto.CurrencyRateDate;
                order.CurrencyCode = dto.CurrencyCode;
                order.CurrencyRate = dto.CurrencyRate;
                order.CurrencyRateToGBP = dto.CurrencyRateToGBP;
                order.CurrencyRateToUSD = dto.CurrencyRateToUSD;
                order.IsActive = true;
                order.IsDeleted = false;

                order.PaymentMethodTypeID = dto.PaymentMethodTypeID;
                order.TransactionTypeID = typeEnumValue.GetIntValue();
                order.TransactionGatewayTypeID = TransactionGatewayIDEnum.FirstData_Merchant_Gateway.GetIntValue();
                order.GlobalPaymentMethodID = dto.GlobalPaymentMethodID;

                order.TransactionOrderReference = Guid.NewGuid().ToString();

                // discount / deductions
                order.DiscountTotalPercentage = dto.PriceDTO.CartTotalDiscountsPercentage;
                order.DiscountTotalValue = dto.PriceDTO.CartTotalDiscounts;
                order.DeductionTotalPercentage = dto.PriceDTO.CartTotalDeductionsPercentage;
                order.DeductionTotalValue = dto.PriceDTO.CartTotalDeductions;
                order.OrderDiscountTotal = dto.PriceDTO.Discounts;
                order.OrderDeductionTotal = dto.PriceDTO.Deductions;

                // tax
                order.TaxTotalPercentage = dto.PriceDTO.CartTotalTaxPercentage;
                order.TaxTotalValue = dto.PriceDTO.CartTotalTax;
                order.OrderTaxTotal = dto.PriceDTO.Tax;

                order.OrderTotal = dto.PriceDTO.Total;
                order.OrderSubTotalDiscountsExclTaxAndDeduct = dto.PriceDTO.SubTotalDiscountsExclTaxAndDeduct;
                order.OrderSubTotalDiscountsInclTaxAndDeduct = dto.PriceDTO.SubTotalDiscountsInclTaxAndDeduct;
                order.OrderSubTotalExclTaxAndDeduct = dto.PriceDTO.SubTotalDiscountsExclTaxAndDeduct;
                order.OrderSubTotalInclTaxAndDeduct = dto.PriceDTO.SubTotalInclDiscountsAndTaxAndDeduct;

                order.PaymentMethodAdditionalFeesExclTaxAndDeduct = dto.PriceDTO.PaymentMethodAdditionalFeesExclTax;
                order.PaymentMethodAdditionalFeesInclTaxAndDeduct = dto.PriceDTO.PaymentMethodAdditionalFeesInclTax;

                order.InvoiceID = invoiceDto.InvoiceID;

                order.VatNumber = clientUaoDto.VATNumber;

                scope.DbContext.TransactionOrders.Add(order);

                tDto = TransactionOrderConverter.ToDto(order);

                tDto.VUserAccountOrganisationDto = clientUaoDto;

                tDto.TransactionOrderItems = new List<TransactionOrderItemDTO>();
                
                // deal with all orderItems
                dto.ShoppingCartItems.ForEach(item =>
                {
                    var orderItem  = TransactionHelper.CreateLineItemFromShoppingCartItem(order, item);

                    // find invoice item for cartItem
                    var invoiceLineItem =
                        invoiceDto.InvoiceLineItems.Single(
                            s => s.ParentID.HasValue && s.ParentID.Value.Equals(item.ShoppingCartItemID));

                    orderItem.InvoiceLineItemID = invoiceLineItem.InvoiceLineItemID;

                    scope.DbContext.TransactionOrderItems.Add(orderItem);
                 
                    TransactionOrderItemDTO tiDto = TransactionOrderItemConverter.ToDto(orderItem);

                    tDto.TransactionOrderItems.Add(tiDto);
                });

                // create initial process status log entry
                TransactionHelper.CreateTransactionOrderProcessLog(scope,order.TransactionOrderID,TransactionOrderStatusEnum.Active);

                scope.Save();
            }

            return tDto;
        }

        public IList<TransactionOrderDTO> GetOrdersByIds(List<Guid> orderIds)
        {
            Ensure.That(orderIds).IsNotNull();

            var dtoList = new List<TransactionOrderDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Where(item => orderIds.Contains(item.TransactionOrderID)).ToList().ForEach(item =>
                {
                    var dto = new TransactionOrderDTO();
                    dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

                    // populate orders
                    dto.InjectFrom<NullableInjection>(item);
                    // populate order items
                    item.TransactionOrderItems.ToList().ForEach(oi =>
                    {
                        var oiDto = new TransactionOrderItemDTO();
                        oiDto.InjectFrom<NullableInjection>(oi);

                        dto.TransactionOrderItems.Add(oiDto);
                    });

                    dtoList.Add(dto);
                });
            }

            return dtoList;
        }

        public TransactionOrderDTO GetOrderByGuid(Guid orderGuid)
        {
            Ensure.That(orderGuid);

            TransactionOrderDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(orderGuid));
               
                dto = new TransactionOrderDTO();
                dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

                // populate orders
                dto.InjectFrom<NullableInjection>(ti);
                // populate order items
                ti.TransactionOrderItems.ToList().ForEach(oi =>
                {
                    var oiDto = new TransactionOrderItemDTO();
                    oiDto.InjectFrom<NullableInjection>(oi);

                    dto.TransactionOrderItems.Add(oiDto);
                });
            }

            return dto;
        }

        [EnsureArgumentAspect]
        public void DeleteOrder(TransactionOrderDTO order)
        {

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
            {
                var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(order.TransactionOrderID));

                ti.TransactionOrderItems.ToList().ForEach(item =>
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                });

                ti.IsDeleted = true;
                ti.IsActive = false;

                scope.Save();
            }
        }

        public List<TransactionOrderDTO> SearchOrders(Guid? parentID, Guid? productID, int? orderStatusID, int? paymentStatusID)
        {
            var dtoList = new List<TransactionOrderDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                IQueryable<TransactionOrder> query = scope.DbContext.TransactionOrders.Include("TransactionOrderItems");

                if (parentID.HasValue)
                {
                    query = query.Where(item => item.ParentID.Equals(parentID.Value));
                }

                if (orderStatusID.HasValue)
                {
                   // query = query.Where(item => item.OrderStatusID.Equals(orderStatusID.Value));
                }

                if (paymentStatusID.HasValue)
                {
                   // query = query.Where(item => item.PaymentStatusID.Equals(paymentStatusID.Value));
                }

                if (productID.HasValue)
                {
                    //query = query.Where(item => item.TransactionOrderItems.Any(it => it.ProductID.Equals(productID)));
                }

                var items = query.ToList();

                items.ForEach(item =>
                {
                    var dto = new TransactionOrderDTO();
                    dto.TransactionOrderItems = new List<TransactionOrderItemDTO>();

                    // populate orders
                    dto.InjectFrom<NullableInjection>(item);
                    // populate order items
                    item.TransactionOrderItems.ToList().ForEach(oi =>
                    {
                        var oiDto = new TransactionOrderItemDTO();
                        oiDto.InjectFrom<NullableInjection>(oi);

                        dto.TransactionOrderItems.Add(oiDto);
                    });

                    dtoList.Add(dto);
                });
            }

            return dtoList;
        }

        public void InsertOrder(TransactionOrderDTO order)
        {
            Ensure.That(order);

            var to = new TransactionOrder();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger,true))
            {
                to.InjectFrom<NullableInjection>(order);

                to.TransactionOrderID = Guid.NewGuid();

                scope.DbContext.TransactionOrders.Add(to);

                if (order.TransactionOrderItems != null)
                {
                    order.TransactionOrderItems.ForEach(item =>
                    {
                        var toi = new TransactionOrderItem();
                        toi.InjectFrom<NullableInjection>(item);
                        toi.OrderItemID = Guid.NewGuid();
                        toi.OrderID = to.TransactionOrderID;
                             
                        scope.DbContext.TransactionOrderItems.Add(toi);
                    });
                }

                scope.Save();
            }
        }

        public void UpdateOrder(TransactionOrderDTO order)
        {
            Ensure.That(order).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var ti = scope.DbContext.TransactionOrders.Include("TransactionOrderItems").Single(item => item.TransactionOrderID.Equals(order.TransactionOrderID));

                // update values
                ti.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "TransactionOrderID", "TransactionOrderItems" }), order);

                if (order.TransactionOrderItems != null)
                {
                    // update orders that exist
                    order.TransactionOrderItems.ForEach(item =>
                    {
                        if (ti.TransactionOrderItems.Any(it => it.OrderItemID.Equals(item.OrderID) && it.IsActive))
                        {
                            var toi = ti.TransactionOrderItems.Single(it => it.OrderItemID.Equals(item.OrderID) && it.IsActive);
                            toi.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "OrderItemID", "OrderID" }), item);
                        }
                    });

                    // add order that are new
                    order.TransactionOrderItems.ForEach(item =>
                    {
                        if (!ti.TransactionOrderItems.Any(it => it.OrderItemID.Equals(item.OrderID)))
                        {
                            var toi = new TransactionOrderItem();
                            toi.InjectFrom<NullableInjection>(item);
                            toi.OrderItemID = Guid.NewGuid();
                            toi.OrderID = ti.TransactionOrderID;

                            ti.TransactionOrderItems.Add(toi);
                        }
                    });
                
                    // remove any not found
                    while (ti.TransactionOrderItems.Any(it => !order.TransactionOrderItems.Any(ip => ip.OrderItemID.Equals(it.OrderItemID)) && it.IsActive))
                    {
                        var itemToRemove = ti.TransactionOrderItems.Single(it => !order.TransactionOrderItems.Any(ip => ip.OrderItemID.Equals(it.OrderItemID)) && it.IsActive);

                        if (itemToRemove != null)
                        {
                            itemToRemove.IsActive = false;
                            itemToRemove.IsDeleted = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                scope.Save();
            }
        }

        public TransactionOrderDTO GetOrderByAuthorizationTransactionIdAndPaymentMethod(string authorizationTransactionId, string paymentMethodSystemName)
        {
            throw new NotImplementedException();
        }

        public TransactionOrderItemDTO GetOrderItemByGuid(Guid orderItemGuid)
        {
            Ensure.That(orderItemGuid);

            TransactionOrderItemDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var ti = scope.DbContext.TransactionOrderItems.Single(item => item.OrderItemID.Equals(orderItemGuid));

                dto = new TransactionOrderItemDTO();

                // populate orders
                dto.InjectFrom<NullableInjection>(ti);
            }

            return dto;
        }

        public IList<TransactionOrderItemDTO> GetAllOrderItems(Guid? orderId, Guid? parentID, int? orderStatusID, int? paymentStatusID)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(TransactionOrderItemDTO orderItem)
        {
            Ensure.That(orderItem);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var ti = scope.DbContext.TransactionOrderItems.Single(item => item.OrderItemID.Equals(orderItem.OrderItemID));

                ti.IsDeleted = true;
                ti.IsActive = false;

                scope.Save();
            }
        }
    }
}
