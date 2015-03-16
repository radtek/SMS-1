using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.DTO.Payment;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Business.Logic
{
    using System.Reflection;

    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class ShoppingCartLogic : LogicBase, IShoppingCartLogic
    {
        private readonly IDeductionLogic m_DeductionLogic;
        private readonly IProductLogic m_ProductLogic;
        private readonly ProductPricingProcessor m_PricingProcessor;
        private readonly CartPricingProcessor m_CartPricingProcessor;

        public ShoppingCartLogic(ILogger logger, ICacheProvider cacheProvider, IDeductionLogic dLogic, IProductLogic logic,ProductPricingProcessor pricingProcessor) : base(logger, cacheProvider)
        {
            this.m_DeductionLogic = dLogic;
            this.m_ProductLogic = logic;
            this.m_PricingProcessor = pricingProcessor;
            this.m_CartPricingProcessor = new CartPricingProcessor(logger,logic,this,pricingProcessor);
        }

        public bool DoesShoppingCartExist(Guid shoppingCartId)
        {
            bool exist = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                exist = scope.DbContext.ShoppingCarts.Any(s => s.ShoppingCartID.Equals(shoppingCartId));
            }


            return exist;
        }

        #region Shopping Cart Items

        public ShoppingCartItemDTO CreateShoppingCartItem(ShoppingCartDTO dto, Guid cartID)
        {
            return new ShoppingCartItemDTO { ShoppingCartID = cartID, ShoppingCartItemID = Guid.NewGuid() };
        }

        private ShoppingCartItemDTO CreateShoppingCartItemFromProduct(ShoppingCartDTO cartDto,ProductDTO dto = null, Guid? productID = null,
           int versionNumber = 0)
        {
            var productDto = dto;

            if (dto == null)
                productDto = m_ProductLogic.GetProductWithSpecsAttributesAndDeductions(productID.Value, versionNumber,
                    false);

            ShoppingCartItemDTO cdto = new ShoppingCartItemDTO();
            cdto.ProductID = productDto.ProductID;
            cdto.ProductVersionID = productDto.ProductVersionID;
            cdto.IsActive = true;
            cdto.IsDeleted = false;
            cdto.ShoppingCartID = cartDto.ShoppingCartID;
            cdto.ShoppingCartItemID = Guid.NewGuid();
            cdto.ProductPricingDto = new ProductPricingDTO();

            cdto.ProductInformationDto = new InformationDTO
            {
                Description = productDto.CurrentDetail.Description,
                Name = productDto.CurrentDetail.Name,
                InvoiceName = productDto.CurrentDetail.InvoiceName
            };
            
            // set base pricing values
            cdto.ProductPricingDto = new ProductPricingDTO
            {
                ProductCost = productDto.CurrentDetail.ProductCost,
                ProductPrice = productDto.CurrentDetail.Price
            };
            
            // go through specs and attrs
            if (productDto.ProductDTODefaultAttributes.Any())
            {
                if (cdto.ShoppingCartItemProductAttributes == null)
                    cdto.ShoppingCartItemProductAttributes = new List<ShoppingCartItemProductAttributeDTO>();

                productDto.ProductDTODefaultAttributes.ForEach(item =>
                {
                    var itemDto = new ShoppingCartItemProductAttributeDTO();
                    itemDto.ProductVariantAttributeValueID = item.ProductVariantAttributeValueID;
                    itemDto.Quantity = item.Quantity;
                    itemDto.ShoppingCartItemProductAttributeID = Guid.NewGuid();
                    itemDto.ShoppingCartItemID = cdto.ShoppingCartItemID;

                    cdto.ShoppingCartItemProductAttributes.Add(itemDto);
                });
            }

            // go through specs and options
            if (productDto.ProductDTODefaultSpecOptions.Any())
            {
                if (cdto.ShoppingCartItemProductSpecifications == null)
                    cdto.ShoppingCartItemProductSpecifications = new List<ShoppingCartItemProductSpecificationDTO>();

                productDto.ProductDTODefaultSpecOptions.ForEach(item =>
                {
                    var itemDto = new ShoppingCartItemProductSpecificationDTO();
                    itemDto.ProductSpecificationAttributeID = item.ProductSpecificationAttributeID;
                    itemDto.ProductSpecificationAttributeOptionID = item.ProductSpecificationAttributeOptionID;
                    itemDto.Quantity = item.DefaultQuantity;
                    itemDto.ShoppingCartItemProductSpecificationID = Guid.NewGuid();
                    itemDto.ShoppingCartItemID = cdto.ShoppingCartItemID;

                    cdto.ShoppingCartItemProductSpecifications.Add(itemDto);
                });
            }

            // create base pricing
            m_PricingProcessor.CalculateProductPriceWithoutDiscountAndDeduction(cartDto,cdto,productDto);

            return cdto;
        }

        public ShoppingCartDTO AddProductToShoppingCart(ShoppingCartDTO dto, ProductDTO productDto, int quantity)
        {
            Ensure.That(dto).IsNotNull();
            Ensure.That(productDto).IsNotNull();

            var cartItem = CreateShoppingCartItemFromProduct(dto,
                productDto);
            cartItem.Quantity = quantity;

            if (dto.ShoppingCartItems == null)
                dto.ShoppingCartItems = new List<ShoppingCartItemDTO>();

            dto.ShoppingCartItems.Add(cartItem);

            return this.CalculateShoppingCart(dto,null);
        }

        public ShoppingCartDTO AddProductToShoppingCartFromProductID(ShoppingCartDTO dto, Guid productID, int versionNumber, int quantity)
        {
            Ensure.That(dto).IsNotNull();
            Ensure.That(productID).IsNot(Guid.Empty);
            Ensure.That(quantity).IsNot(0);
            Ensure.That(versionNumber).IsNot(0);

            var cartItem = CreateShoppingCartItemFromProduct(dto,null, productID, versionNumber);
            cartItem.Quantity = quantity;

            if (dto.ShoppingCartItems == null)
            {
                dto.ShoppingCartItems = new List<ShoppingCartItemDTO>();
            }

            dto.ShoppingCartItems.Add(cartItem);

            return this.CalculateShoppingCart(dto,null);
        }

        public ShoppingCartDTO RemoveProductFromShoppingCart(ShoppingCartDTO dto, ShoppingCartItemDTO itemDto)
        {
            Ensure.That(dto);
            Ensure.That(itemDto);

            var sItem = dto.ShoppingCartItems.Single(s => s.ShoppingCartItemID.Equals(itemDto.ShoppingCartItemID));

            dto.ShoppingCartItems.Remove(sItem);

            return this.CalculateShoppingCart(dto, null);
        }

        public ShoppingCartDTO UpdateProductWithinShoppingCart(ShoppingCartDTO dto, ShoppingCartItemDTO itemDto)
        {
            Ensure.That(dto);
            Ensure.That(itemDto);

            var sItem = dto.ShoppingCartItems.Single(s => s.ShoppingCartItemID.Equals(itemDto.ShoppingCartItemID));

            // remove old
            dto.ShoppingCartItems.Remove(sItem);
            // add new with new quantity
            dto.ShoppingCartItems.Add(itemDto);

            return this.CalculateShoppingCart(dto, null);
        }


        public ShoppingCartItemDTO GetShoppingCartItem(Guid itemID)
        {
            Ensure.That(itemID);

            ShoppingCartItemDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                dto = ShoppingCartItemConverter.ToDtoWithRelated(scope.DbContext
                                                                      .ShoppingCartItems
                                                                      .Include("ShoppingCartItemProductAttributes")
                                                                      .Include("ShoppingCartItemProductSpecifications")
                                                                      .Single(s => s.ShoppingCartItemID.Equals(itemID)), 1);
            }

            return dto;
        }

        public void InsertShoppingCartItem(ShoppingCartItemDTO dto)
        {
            Ensure.That(dto);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                ShoppingCartItem item = ShoppingCartItemConverter.ToEntity(dto);
                scope.DbContext.ShoppingCartItems.Add(item);

                // deal with attr
                if (dto.ShoppingCartItemProductAttributes != null && dto.ShoppingCartItemProductAttributes.Count > 0)
                {
                    dto.ShoppingCartItemProductAttributes.ForEach(it =>
                    {
                        ShoppingCartItemProductAttribute attr = ShoppingCartItemProductAttributeConverter.ToEntity(it);

                        attr.ShoppingCartItemID = dto.ShoppingCartItemID;
                        attr.ShoppingCartItemProductAttributeID = Guid.NewGuid();

                        scope.DbContext.ShoppingCartItemProductAttributes.Add(attr);
                    });
                }

                // deal with specs
                if (dto.ShoppingCartItemProductSpecifications != null && dto.ShoppingCartItemProductSpecifications.Count > 0)
                {
                    dto.ShoppingCartItemProductSpecifications.ForEach(it =>
                    {
                        ShoppingCartItemProductSpecification attr = ShoppingCartItemProductSpecificationConverter.ToEntity(it);

                        attr.ShoppingCartItemID = dto.ShoppingCartItemID;
                        attr.ShoppingCartItemProductSpecificationID = Guid.NewGuid();

                        scope.DbContext.ShoppingCartItemProductSpecifications.Add(attr);
                    });
                }

                scope.Save();
            }
        }

        public void UpdateShoppingCartItem(ShoppingCartItemDTO dto)
        {
            Ensure.That(dto);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var item = scope.DbContext
                                .ShoppingCartItems
                                .Include("ShoppingCartItemProductAttributes")
                                .Include("ShoppingCartItemProductSpecifications")
                                .Single(s => s.ShoppingCartItemID.Equals(dto.ShoppingCartItemID));

                item.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "ShoppingCartItemID", "ShoppingCartID" }), dto);

                // delete all specs and ops and recreate links
                if (item.ShoppingCartItemProductAttributes.Count > 0)
                {
                    scope.DbContext.ShoppingCartItemProductAttributes.RemoveRange(item.ShoppingCartItemProductAttributes);
                }

                if (dto.ShoppingCartItemProductAttributes != null && dto.ShoppingCartItemProductAttributes.Count > 0)
                {
                    dto.ShoppingCartItemProductAttributes.ForEach(it =>
                    {
                        ShoppingCartItemProductAttribute attr = ShoppingCartItemProductAttributeConverter.ToEntity(it);

                        attr.ShoppingCartItemID = item.ShoppingCartItemID;
                        attr.ShoppingCartItemProductAttributeID = Guid.NewGuid();

                        scope.DbContext.ShoppingCartItemProductAttributes.Add(attr);
                    });
                }

                // delete all specs and ops and recreate links
                if (item.ShoppingCartItemProductSpecifications.Count > 0)
                {
                    scope.DbContext.ShoppingCartItemProductSpecifications.RemoveRange(item.ShoppingCartItemProductSpecifications);
                }

                if (dto.ShoppingCartItemProductSpecifications != null && dto.ShoppingCartItemProductSpecifications.Count > 0)
                {
                    dto.ShoppingCartItemProductSpecifications.ForEach(it =>
                    {
                        ShoppingCartItemProductSpecification attr = ShoppingCartItemProductSpecificationConverter.ToEntity(it);

                        attr.ShoppingCartItemID = item.ShoppingCartItemID;
                        attr.ShoppingCartItemProductSpecificationID = Guid.NewGuid();

                        scope.DbContext.ShoppingCartItemProductSpecifications.Add(attr);
                    });
                }

                scope.Save();
            }
        }

        public void DeleteShoppingCartItem(ShoppingCartItemDTO dto)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var item = scope.DbContext
                                .ShoppingCartItems
                                .Include("ShoppingCartItemProductAttributes")
                                .Include("ShoppingCartItemProductSpecifications")
                                .Single(s => s.ShoppingCartItemID.Equals(dto.ShoppingCartItemID));

                if (item.ShoppingCartItemProductAttributes.Count > 0)
                {
                    scope.DbContext.ShoppingCartItemProductAttributes.RemoveRange(item.ShoppingCartItemProductAttributes);
                }

                if (item.ShoppingCartItemProductSpecifications.Count > 0)
                {
                    scope.DbContext.ShoppingCartItemProductSpecifications.RemoveRange(item.ShoppingCartItemProductSpecifications);
                }

                scope.DbContext.ShoppingCartItems.Remove(item);

                scope.Save();
            }
        }



        #endregion


        public ShoppingCartDTO GetShoppingCart(Guid shoppingCartID)
        {
            Ensure.That(shoppingCartID);

            ShoppingCartDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                dto = ShoppingCartConverter.ToDtoWithRelated(scope.DbContext
                                                                .ShoppingCarts
                                                                .Include("ShoppingCartItems")
                                                                .Single(s => s.ShoppingCartID.Equals(shoppingCartID)), 2);


                // load specs and attrs and deductions and recalc
                dto.ShoppingCartItems.ForEach(item =>
                {
                    var sit = scope.DbContext
                                   .ShoppingCartItems
                                   .Include("ShoppingCartItemProductAttributes")
                                   .Include("ShoppingCartItemProductSpecifications")
                                   .Single(s => s.ShoppingCartItemID.Equals(item.ShoppingCartItemID));

                    if (sit.ShoppingCartItemProductAttributes != null && sit.ShoppingCartItemProductAttributes.Count > 0)
                    {
                        item.ShoppingCartItemProductAttributes = ShoppingCartItemProductAttributeConverter.ToDtos(sit.ShoppingCartItemProductAttributes);
                    }

                    if (sit.ShoppingCartItemProductSpecifications != null && sit.ShoppingCartItemProductSpecifications.Count > 0)
                    {
                        item.ShoppingCartItemProductSpecifications = ShoppingCartItemProductSpecificationConverter.ToDtos(sit.ShoppingCartItemProductSpecifications);
                    }
                });
            }

            return this.CalculateShoppingCart(dto,null);
        }

        public ShoppingCartDTO SaveShoppingCart(ShoppingCartDTO dto)
        {
            Ensure.That(dto).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                ShoppingCart item = ShoppingCartConverter.ToEntity(dto);

                item.ShoppingCartID = dto.ShoppingCartID;

                scope.DbContext.ShoppingCarts.Add(item);

                // add country deductions
                if (dto.VCountryDeductions != null)
                {
                    // need to persist countrydeductions
                    var countryDeductions =
                        scope.DbContext.CountryDeductions.Where(
                            it => it.CountryCode == item.CountryCode && item.IsActive == true && item.IsDeleted == false)
                            .ToList();

                    List<CountryDeduction> countryDecs = new List<CountryDeduction>();

                    // now create others
                    dto.VCountryDeductions.ForEach(
                        cd =>
                        {
                            countryDecs.Add(
                                countryDeductions.Single(
                                    cdd =>
                                    cdd.DeductionID.Equals(cd.DeductionID)
                                    && cdd.DeductionVersionNumber.Equals(cd.DeductionVersionNumber)
                                    && cdd.CountryCode.Equals(cd.CountryCode)));
                        });

                    if (countryDecs.Count > 0)
                        item.CountryDeductions = countryDecs;
                }

                // check for items
                if (dto.ShoppingCartItems != null && dto.ShoppingCartItems.Count > 0)
                {
                    dto.ShoppingCartItems.ForEach(it =>
                    {
                        ShoppingCartItem scItem = ShoppingCartItemConverter.ToEntity(it);

                        scItem.ShoppingCartID = item.ShoppingCartID;

                        scope.DbContext.ShoppingCartItems.Add(scItem);

                        // deal with attrs and specs
                        if (it.ShoppingCartItemProductAttributes != null && it.ShoppingCartItemProductAttributes.Count > 0)
                        {
                            it.ShoppingCartItemProductAttributes.ForEach(ite =>
                            {
                                ShoppingCartItemProductAttribute attr = ShoppingCartItemProductAttributeConverter.ToEntity(ite);

                                attr.ShoppingCartItemID = scItem.ShoppingCartItemID;
                                attr.ShoppingCartItemProductAttributeID = Guid.NewGuid();

                                scope.DbContext.ShoppingCartItemProductAttributes.Add(attr);
                            });
                        }

                        // deal with specs
                        if (it.ShoppingCartItemProductSpecifications != null && it.ShoppingCartItemProductSpecifications.Count > 0)
                        {
                            it.ShoppingCartItemProductSpecifications.ForEach(ite =>
                            {
                                ShoppingCartItemProductSpecification attr = ShoppingCartItemProductSpecificationConverter.ToEntity(ite);

                                attr.ShoppingCartItemID = scItem.ShoppingCartItemID;
                                attr.ShoppingCartItemProductSpecificationID = Guid.NewGuid();

                                scope.DbContext.ShoppingCartItemProductSpecifications.Add(attr);
                            });
                        }
                    });
                }

                scope.Save();
            }

            return dto;
        }

        public void UpdateShoppingCart(ShoppingCartDTO dto)
        {
            Ensure.That(dto);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                ShoppingCart item = scope.DbContext
                                         .ShoppingCarts
                                         .Include("ShoppingCartItems")
                                         .Include("CountryDeductions")
                                         .Single(s => s.ShoppingCartID.Equals(dto.ShoppingCartID));

                item.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "ShoppingCartID", "ParentID" }), dto);

                // manage country deductions
                if (dto.VCountryDeductions != null)
                {
                    // need to persist countrydeductions
                    var countryDeductions =
                        scope.DbContext.CountryDeductions.Where(
                            it => it.CountryCode == item.CountryCode && item.IsActive == true && item.IsDeleted == false)
                            .ToList();

                    List<CountryDeduction> countryDecs = new List<CountryDeduction>();

                    // now create others
                    dto.VCountryDeductions.ForEach(
                        cd =>
                        {
                            countryDecs.Add(
                                countryDeductions.Single(
                                    cdd =>
                                    cdd.DeductionID.Equals(cd.DeductionID)
                                    && cdd.DeductionVersionNumber.Equals(cd.DeductionVersionNumber)
                                    && cdd.CountryCode.Equals(cd.CountryCode)));
                        });

                    if (dto.VCountryDeductions != null && dto.VCountryDeductions.Any())
                    {
                        // if sc has none then create
                        if (item.CountryDeductions.Count == 0) item.CountryDeductions = countryDecs;
                        else
                        {
                            // deal with ones that exist and dont
                            List<CountryDeduction> missingDecs = new List<CountryDeduction>();

                            missingDecs.AddRange(countryDecs.Where(cd => !item.CountryDeductions.Any(cdd => cdd.DeductionID.Equals(cd.CountryDeductionID) && cdd.DeductionVersionNumber.Equals(cd.DeductionVersionNumber))).ToList());

                            // add missing
                            if(missingDecs.Count > 0)
                                missingDecs.ForEach(md => item.CountryDeductions.Add(md));

                            // remove redundant items
                            missingDecs.Clear();
                            missingDecs.AddRange(
                                item.CountryDeductions.Where(
                                    cd =>
                                    !countryDecs.Any(
                                        cdd =>
                                        cdd.DeductionID.Equals(cd.CountryDeductionID)
                                        && cdd.DeductionVersionNumber.Equals(cd.DeductionVersionNumber))).ToList());

                            // remove redundant
                            while (missingDecs.Count > 0)
                            {
                                var md = missingDecs.First();

                                item.CountryDeductions.Remove(md);

                                missingDecs.RemoveAt(0);
                            }

                        }
                    }
                    else
                    {
                        // if no deductions but some exist in db then remove
                        if (item.CountryDeductions != null)
                            while (item.CountryDeductions.Count > 0)
                            {
                                var cd = item.CountryDeductions.First();
                                item.CountryDeductions.Remove(cd);
                            }
                        
                    }
                       
                }

                // check for items
                if (dto.ShoppingCartItems != null && dto.ShoppingCartItems.Count > 0)
                {
                    // update shopping cart items
                    dto.ShoppingCartItems.ForEach(sci =>
                    {
                        var scItem = item.ShoppingCartItems.Single(s => s.ShoppingCartItemID.Equals(sci.ShoppingCartItemID));

                        scItem.InjectFrom<NullableInjection>(new IgnoreProps(new string[] { "ShoppingCartItemID", "ParentID", "ShoppingCartID" }), sci);

                        var attributes = scope.DbContext.ShoppingCartItemProductAttributes.Where(s => s.ShoppingCartItemID.Equals(sci.ShoppingCartItemID)).ToList();
                        var specs = scope.DbContext.ShoppingCartItemProductSpecifications.Where(s => s.ShoppingCartItemID.Equals(sci.ShoppingCartItemID)).ToList();

                        if (attributes.Count > 0)
                        {
                            scope.DbContext.ShoppingCartItemProductAttributes.RemoveRange(attributes);
                        }

                        if (specs.Count > 0)
                        {
                            scope.DbContext.ShoppingCartItemProductSpecifications.RemoveRange(specs);
                        }

                        if (sci.ShoppingCartItemProductAttributes != null && sci.ShoppingCartItemProductAttributes.Count > 0)
                        {
                            sci.ShoppingCartItemProductAttributes.ForEach(ite =>
                            {
                                ShoppingCartItemProductAttribute attr = ShoppingCartItemProductAttributeConverter.ToEntity(ite);

                                attr.ShoppingCartItemID = scItem.ShoppingCartItemID;
                                attr.ShoppingCartItemProductAttributeID = Guid.NewGuid();

                                scope.DbContext.ShoppingCartItemProductAttributes.Add(attr);
                            });
                        }

                        // deal with specs
                        if (sci.ShoppingCartItemProductSpecifications != null && sci.ShoppingCartItemProductSpecifications.Count > 0)
                        {
                            sci.ShoppingCartItemProductSpecifications.ForEach(ite =>
                            {
                                ShoppingCartItemProductSpecification attr = ShoppingCartItemProductSpecificationConverter.ToEntity(ite);

                                attr.ShoppingCartItemID = scItem.ShoppingCartItemID;
                                attr.ShoppingCartItemProductSpecificationID = Guid.NewGuid();

                                scope.DbContext.ShoppingCartItemProductSpecifications.Add(attr);
                            });
                        }
                    });
                }

                scope.Save();
            }
        }


        public ShoppingCartDTO CreateShoppingCart(VUserAccountOrganisationDTO userAccountOrganisation ,PaymentCardTypeIDEnum cardTypeEnum,PaymentMethodTypeIDEnum paymentTypeEnum,string countryCode = "UK")
        {

            Ensure.That(countryCode).IsNotNullOrEmpty(); 

            var dto = new ShoppingCartDTO
            {
                ShoppingCartID = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                PaymentCardTypeID = cardTypeEnum.GetIntValue(),
                PaymentMethodTypeID = paymentTypeEnum.GetIntValue(),
                VUserAccountOrganisationDto = userAccountOrganisation
            };

            dto.UserAccountOrganisationID = userAccountOrganisation.UserAccountOrganisationID;

            // load currency and country data
            // TDB cache this
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                // get default payment method
                dto.GlobalPaymentMethodID = LogicHelper.GetGlobalPaymentMethodIDForOnlineTransactions(scope);

                var curr = scope.DbContext.VCountryAndCurrencies.Single(s => s.CountryCode.Equals(countryCode));

                dto.CountryCode = countryCode;
                dto.CurrencyCode = curr.CurrencyCode;
                dto.CurrencyRate = curr.CurrencyRate;
                dto.CurrencyRateDate = curr.CurrencyRateDate;
                dto.CurrencyRateToGBP = curr.CurrencyRateToGBP.GetValueOrDefault(0);
                dto.CurrencyRateToUSD = curr.CurrencyRateToUSD;
            }

            return dto;
        }

        public void DeleteShoppingCartAndInvoice(ShoppingCartDTO dto)
        {
            Ensure.That(dto);

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                // delete attached invoices
                ShoppingCart item = scope.DbContext
                                         .ShoppingCarts
                                         .Include("ShoppingCartItems")
                                         .Include("CountryDeductions")
                                         .Single(s => s.ShoppingCartID.Equals(dto.ShoppingCartID));

                // remove all current items and recreate
                while (item.ShoppingCartItems.Count > 0)
                {
                    var sci = item.ShoppingCartItems.First();

                    var attributes = scope.DbContext.ShoppingCartItemProductAttributes.Where(s => s.ShoppingCartItemID.Equals(sci.ShoppingCartItemID)).ToList();
                    var specs = scope.DbContext.ShoppingCartItemProductSpecifications.Where(s => s.ShoppingCartItemID.Equals(sci.ShoppingCartItemID)).ToList();

                    if (attributes.Count > 0)
                    {
                        scope.DbContext.ShoppingCartItemProductAttributes.RemoveRange(attributes);
                    }

                    if (specs.Count > 0)
                    {
                        scope.DbContext.ShoppingCartItemProductSpecifications.RemoveRange(specs);
                    }

                    scope.DbContext.ShoppingCartItems.Remove(sci);

                    item.ShoppingCartItems.Remove(sci);
                }

                // remove all country deductions
                while (item.CountryDeductions.Count > 0)
                {
                    var it = item.CountryDeductions.First();

                    item.CountryDeductions.Remove(it);
                }

                scope.DbContext.ShoppingCarts.Remove(item);

                scope.Save();
            }
        }


        public List<VCountryDeductionDTO> GetCountryDeductions(string countryCode)
        {
            Ensure.That(countryCode).IsNotNullOrEmpty();

            List<VCountryDeductionDTO> list = new List<VCountryDeductionDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                list =
                    VCountryDeductionConverter.ToDtos(
                        scope.DbContext.VCountryDeductions.Where(
                            item => item.IsActive == true && item.IsDeleted == false &&
                                    item.CountryCode.Equals(countryCode)).ToArray());

                // product deductions
                list.ForEach(item =>
                {
                    if (item.IsProductDeduction.GetValueOrDefault(false))
                    {
                        Ensure.That(item.ProductID);

                        // load deduction product and tiers
                        item.DeductionProduct = m_ProductLogic.GetProduct(item.ProductID, item.ProductVersionID);
                    }
                });

                // dedudction tiers
                list.ForEach(item =>
                {
                    var deduction =
                        scope.DbContext.Deductions.Include("ComponentTiers")
                            .Single(
                                s =>
                                    s.DeductionID.Equals(item.DeductionID) &&
                                    s.DeductionVersionNumber.Equals(item.DeductionVersionNumber));

                    if (deduction != null && deduction.ComponentTiers != null && deduction.ComponentTiers.Any())
                    {
                        item.DeductionDto = DeductionConverter.ToDto(deduction);
                        item.DeductionDto.ComponentTiers = ComponentTierConverter.ToDtos(deduction.ComponentTiers);
                    }
                });
            }

            return list;
        }

        public List<VOrganisationCheckoutDiscountDTO> GetOrganisationCheckoutDiscounts(Guid organisationID)
        {
            Ensure.That(organisationID).IsNot(Guid.Empty);

            List<VOrganisationCheckoutDiscountDTO> list = new List<VOrganisationCheckoutDiscountDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                list =
                    VOrganisationCheckoutDiscountConverter.ToDtos(
                        scope.DbContext.VOrganisationCheckoutDiscounts.Where(
                            item => item.OrganisationID.Equals(organisationID) && item.ValidTill.HasValue && item.ValidTill >= DateTime.Now).ToArray());

                // load any component tiers for discounts
                list.ForEach(item =>
                {
                    var discount = scope.DbContext.Discounts.Include("ComponentTiers")
                        .Single(
                            s =>
                                s.DiscountID.Equals(item.DiscountID) &&
                                s.DiscountVersionNumber.Equals(item.DiscountVersionNumber));

                    item.DiscountDto = DiscountConverter.ToDto(discount);
                    item.DiscountDto.ComponentTiers = ComponentTierConverter.ToDtos(discount.ComponentTiers);
                });
            }

            return list;
        }

        public ShoppingCartDTO CalculateShoppingCart(ShoppingCartDTO dto,Guid? organisationId)
        {
            Ensure.That(dto).IsNotNull();

            m_CartPricingProcessor.CalculateCartPrice(dto,organisationId);

            return dto;
        }
    }
}
