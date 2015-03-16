using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.DTO.Payment;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class ProductLogic : LogicBase, IProductLogic
    {
        private readonly IDeductionLogic m_DeductionLogic;

        public ProductLogic(ILogger logger, ICacheProvider cacheProvider, IDeductionLogic dLogic) : base(logger, cacheProvider)
        {
            this.m_DeductionLogic = dLogic;
        }

        public ProductDTO GetProduct(Guid productId, int versionNumber)
        {
            Ensure.That(productId).IsNot(Guid.Empty);

            ProductDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                // get product
                var product = scope.DbContext
                                   .Products
                                   .Include("ComponentTiers")
                                   .Include("ProductDetails")
                                   .Single(item =>
                                                  item.IsActive.Equals(true) && item.IsDeleted.Equals(false) && item.ProductVersionID.Equals(versionNumber) && item.ProductID.Equals(productId));

                dto = ProductConverter.ToDto(product);

                dto.ProductDetails = ProductDetailConverter.ToDtos(product.ProductDetails);
                dto.ComponentTiers = ComponentTierConverter.ToDtos(product.ComponentTiers);
            }

            return dto;
        }

        public ProductDTO GetProductWithSpecsAttributesAndDeductions(Guid productID, int versionNumber,bool includeDiscountsAndDeductions = false)
        {
            // TBD implement caching here
            Ensure.That(productID);

            var product = this.GetProduct(productID, versionNumber);

            product.ProductDTOAttributes = new List<VProductAttributeDTO>();
            product.ProductDTODeductions = new List<VProductDeductionDTO>();
            product.ProductDTOSpecs = new List<VProductSpecificationDTO>();
            product.ProductDTOSpecOptions = new List<VProductSpecificationOptionDTO>();
            product.ProductDTODiscounts = new List<VProductDiscountDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                scope.DbContext
                     .VProductAttributes
                     .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                     .ToList()
                     .ForEach(item =>
                     {
                         product.ProductDTOAttributes.Add(VProductAttributeConverter.ToDto(item));
                     });

                scope.DbContext
                     .VProductSpecifications
                     .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                     .ToList()
                     .ForEach(item =>
                     {
                         product.ProductDTOSpecs.Add(VProductSpecificationConverter.ToDto(item));
                     });

                scope.DbContext
                     .VProductSpecificationOptions
                     .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                     .ToList()
                     .ForEach(item =>
                     {
                         product.ProductDTOSpecOptions.Add(VProductSpecificationOptionConverter.ToDto(item));
                     });

                if(includeDiscountsAndDeductions)
                {
                    // load discounts still in scope
                    scope.DbContext
                          .VProductDiscounts
                          .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                          .ToList()
                          .ForEach(item =>
                          {
                              var vProductDiscountDto = VProductDiscountConverter.ToDto(item);
                              // get tiers
                              var discountTiers = scope.DbContext.Discounts.Include("ComponentTiers")
                                  .Where(
                                      s =>
                                          s.DiscountID.Equals(item.DiscountID) &&
                                          s.DiscountVersionNumber.Equals(item.DiscountVersionNumber)).ToList();

                              if (discountTiers.Count > 0)
                              {
                                  vProductDiscountDto.DiscountDto = DiscountConverter.ToDto(discountTiers.First());
                                  vProductDiscountDto.DiscountDto.ComponentTiers =
                                      ComponentTierConverter.ToDtos(discountTiers.First().ComponentTiers);
                              }

                              product.ProductDTODiscounts.Add(vProductDiscountDto);
                          });

                    scope.DbContext
                     .VProductDeductions
                     .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
                     .ToList()
                     .ForEach(item =>
                     {
                         var vProductDeductionDto = VProductDeductionConverter.ToDto(item);
                         // get tiers
                         var deductionTiers = scope.DbContext.Deductions.Include("ComponentTiers")
                             .Where(
                                 s =>
                                     s.DeductionID.Equals(item.DeductionID) &&
                                     s.DeductionVersionNumber.Equals(item.DeductionVersionNumber)).ToList();

                         if (deductionTiers.Count > 0)
                         {
                             vProductDeductionDto.DeductionDto = DeductionConverter.ToDto(deductionTiers.First());
                             vProductDeductionDto.DeductionDto.ComponentTiers =
                                 ComponentTierConverter.ToDtos(deductionTiers.First().ComponentTiers);
                         }

                         product.ProductDTODeductions.Add(vProductDeductionDto);
                     });
                }
            }

            return product;
        }

        private List<VProductSpecificationOptionDTO> GetProductSpecOptions(List<ShoppingCartItemProductSpecificationDTO> specs, Guid productID, int versionNumber)
        {
            List<VProductSpecificationOptionDTO> list = new List<VProductSpecificationOptionDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                IQueryable<VProductSpecificationOption> items = null;

                if (specs != null && specs.Count > 0)
                {
                    scope.DbContext
                         .VProductSpecificationOptions
                         .Where(item => specs.Any(it => it.ProductSpecificationAttributeOptionID.Equals(item.ProductSpecificationAttributeOptionID)));
                }
                else
                {
                    items = scope.DbContext
                                 .VProductSpecificationOptions
                                 .Where(item =>
                                               item.ProductID.Equals(productID) && item.ProductVersionID.Equals(item.ProductVersionID) && item.DefaultQuantity > 0 && item.DefaultValue > 0);
                }

                items.ToList().ForEach(item =>
                {
                    VProductSpecificationOptionDTO dto = VProductSpecificationOptionConverter.ToDto(item);

                    list.Add(dto);
                });
            }

            return list;
        }

        private List<VProductAttributeDTO> GetProductAttributes(List<ShoppingCartItemProductAttributeDTO> attributes, Guid productID, int versionNumber)
        {
            List<VProductAttributeDTO> list = new List<VProductAttributeDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                IQueryable<VProductAttribute> items = null;

                if (attributes != null && attributes.Count > 0)
                {
                    items = scope.DbContext
                                 .VProductAttributes
                                 .Where(item => attributes.Any(it => it.ProductVariantAttributeValueID.Equals(item.ProductVariantAttributeValueID)));
                }
                else
                {
                    items = scope.DbContext
                                 .VProductAttributes
                                 .Where(item =>
                                               item.ProductID.Equals(productID) && item.ProductVersionID.Equals(item.ProductVersionID));
                }

                items.ToList().ForEach(item =>
                {
                    VProductAttributeDTO dto = VProductAttributeConverter.ToDto(item);

                    list.Add(dto);
                });
            }

            return list;
        }


        //public decimal GetProductUnitBasePrice(Guid productID, int versionNumber)
        //{
        //    throw new NotImplementedException();
        //}

        //public decimal GetProductUnitPrice(ShoppingCartDTO cartDto, ProductDTO product, ShoppingCartItemDTO dto)
        //{
        //    throw new NotImplementedException();
        //}
    }

   
}
