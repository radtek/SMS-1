using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using EnsureThat;
using System;
using System.Linq;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ProductLogicController : LogicBase
    {
        public ProductLogicController()
        {
        }

        public ProductDTO GetProduct(Guid productId, int versionNumber)
        {
            Ensure.That(productId).IsNot(Guid.Empty);

            ProductDTO dto = null;

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get product
                var product = scope.DbContexts.Get<TargetFrameworkEntities>()
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

        //public ProductDTO GetProductWithSpecsAttributesAndDeductions(Guid productID, int versionNumber, bool includeDiscountsAndDeductions = false)
        //{
        //    // TBD implement caching here
        //    Ensure.That(productID);

        //    var product = this.GetProduct(productID, versionNumber);

        //    product.ProductDTOAttributes = new List<VProductAttributeDTO>();
        //    product.ProductDTODeductions = new List<VProductDeductionDTO>();
        //    product.ProductDTOSpecs = new List<VProductSpecificationDTO>();
        //    product.ProductDTOSpecOptions = new List<VProductSpecificationOptionDTO>();
        //    product.ProductDTODiscounts = new List<VProductDiscountDTO>();

        //    using (var scope = DbContextScopeFactory.CreateReadOnly())
        //    {
        //        scope.DbContexts.Get<TargetFrameworkEntities>()
        //             .VProductAttributes
        //             .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
        //             .ToList()
        //             .ForEach(item =>
        //             {
        //                 product.ProductDTOAttributes.Add(VProductAttributeConverter.ToDto(item));
        //             });

        //        scope.DbContexts.Get<TargetFrameworkEntities>()
        //             .VProductSpecifications
        //             .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
        //             .ToList()
        //             .ForEach(item =>
        //             {
        //                 product.ProductDTOSpecs.Add(VProductSpecificationConverter.ToDto(item));
        //             });

        //        scope.DbContexts.Get<TargetFrameworkEntities>()
        //             .VProductSpecificationOptions
        //             .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
        //             .ToList()
        //             .ForEach(item =>
        //             {
        //                 product.ProductDTOSpecOptions.Add(VProductSpecificationOptionConverter.ToDto(item));
        //             });

        //        if (includeDiscountsAndDeductions)
        //        {
        //            // load discounts still in scope
        //            scope.DbContexts.Get<TargetFrameworkEntities>()
        //                  .VProductDiscounts
        //                  .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
        //                  .ToList()
        //                  .ForEach(item =>
        //                  {
        //                      var vProductDiscountDto = VProductDiscountConverter.ToDto(item);
        //                      // get tiers
        //                      var discountTiers = scope.DbContexts.Get<TargetFrameworkEntities>().Discounts.Include("ComponentTiers")
        //                          .Where(
        //                              s =>
        //                                  s.DiscountID.Equals(item.DiscountID) &&
        //                                  s.DiscountVersionNumber.Equals(item.DiscountVersionNumber)).ToList();

        //                      if (discountTiers.Count > 0)
        //                      {
        //                          vProductDiscountDto.DiscountDto = DiscountConverter.ToDto(discountTiers.First());
        //                          vProductDiscountDto.DiscountDto.ComponentTiers =
        //                              ComponentTierConverter.ToDtos(discountTiers.First().ComponentTiers);
        //                      }

        //                      product.ProductDTODiscounts.Add(vProductDiscountDto);
        //                  });

        //            scope.DbContexts.Get<TargetFrameworkEntities>()
        //             .VProductDeductions
        //             .Where(item => item.ProductID.Equals(productID) && item.ProductVersionID.Equals(versionNumber))
        //             .ToList()
        //             .ForEach(item =>
        //             {
        //                 var vProductDeductionDto = VProductDeductionConverter.ToDto(item);
        //                 // get tiers
        //                 var deductionTiers = scope.DbContexts.Get<TargetFrameworkEntities>().Deductions.Include("ComponentTiers")
        //                     .Where(
        //                         s =>
        //                             s.DeductionID.Equals(item.DeductionID) &&
        //                             s.DeductionVersionNumber.Equals(item.DeductionVersionNumber)).ToList();

        //                 if (deductionTiers.Count > 0)
        //                 {
        //                     vProductDeductionDto.DeductionDto = DeductionConverter.ToDto(deductionTiers.First());
        //                     vProductDeductionDto.DeductionDto.ComponentTiers =
        //                         ComponentTierConverter.ToDtos(deductionTiers.First().ComponentTiers);
        //                 }

        //                 product.ProductDTODeductions.Add(vProductDeductionDto);
        //             });
        //        }
        //    }

        //    return product;
        //}

        //private List<VProductSpecificationOptionDTO> GetProductSpecOptions(List<ShoppingCartItemProductSpecificationDTO> specs, Guid productID, int versionNumber)
        //{
        //    List<VProductSpecificationOptionDTO> list = new List<VProductSpecificationOptionDTO>();

        //    using (var scope = DbContextScopeFactory.CreateReadOnly())
        //    {
        //        IQueryable<VProductSpecificationOption> items = null;

        //        if (specs != null && specs.Count > 0)
        //        {
        //            scope.DbContexts.Get<TargetFrameworkEntities>()
        //                 .VProductSpecificationOptions
        //                 .Where(item => specs.Any(it => it.ProductSpecificationAttributeOptionID.Equals(item.ProductSpecificationAttributeOptionID)));
        //        }
        //        else
        //        {
        //            items = scope.DbContexts.Get<TargetFrameworkEntities>()
        //                         .VProductSpecificationOptions
        //                         .Where(item =>
        //                                       item.ProductID.Equals(productID) && item.ProductVersionID.Equals(item.ProductVersionID) && item.DefaultQuantity > 0 && item.DefaultValue > 0);
        //        }

        //        items.ToList().ForEach(item =>
        //        {
        //            VProductSpecificationOptionDTO dto = VProductSpecificationOptionConverter.ToDto(item);

        //            list.Add(dto);
        //        });
        //    }

        //    return list;
        //}

        //private List<VProductAttributeDTO> GetProductAttributes(List<ShoppingCartItemProductAttributeDTO> attributes, Guid productID, int versionNumber)
        //{
        //    List<VProductAttributeDTO> list = new List<VProductAttributeDTO>();

        //    using (var scope = DbContextScopeFactory.CreateReadOnly())
        //    {
        //        IQueryable<VProductAttribute> items = null;

        //        if (attributes != null && attributes.Count > 0)
        //        {
        //            items = scope.DbContexts.Get<TargetFrameworkEntities>()
        //                         .VProductAttributes
        //                         .Where(item => attributes.Any(it => it.ProductVariantAttributeValueID.Equals(item.ProductVariantAttributeValueID)));
        //        }
        //        else
        //        {
        //            items = scope.DbContexts.Get<TargetFrameworkEntities>()
        //                         .VProductAttributes
        //                         .Where(item =>
        //                                       item.ProductID.Equals(productID) && item.ProductVersionID.Equals(item.ProductVersionID));
        //        }

        //        items.ToList().ForEach(item =>
        //        {
        //            VProductAttributeDTO dto = VProductAttributeConverter.ToDto(item);

        //            list.Add(dto);
        //        });
        //    }

        //    return list;
        //}
    }
}
