﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VProductAttributeConverter
    {

        public static VProductAttributeDTO ToDto(this Bec.TargetFramework.Data.VProductAttribute source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VProductAttributeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VProductAttribute source, int level)
        {
            if (source == null)
              return null;

            var target = new VProductAttributeDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.ProductAttributeName = source.ProductAttributeName;
            target.ProductAttributeDescription = source.ProductAttributeDescription;
            target.IsProductAttributeRequired = source.IsProductAttributeRequired;
            target.ProductAttributeDisplayOrder = source.ProductAttributeDisplayOrder;
            target.PriceAdjustment = source.PriceAdjustment;
            target.WeightAdjustement = source.WeightAdjustement;
            target.Cost = source.Cost;
            target.Quantity = source.Quantity;
            target.IsPreSelected = source.IsPreSelected;
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.AttributeName = source.AttributeName;
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.ProductAttributeID = source.ProductAttributeID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VProductAttribute ToEntity(this VProductAttributeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VProductAttribute();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.ProductAttributeName = source.ProductAttributeName;
            target.ProductAttributeDescription = source.ProductAttributeDescription;
            target.IsProductAttributeRequired = source.IsProductAttributeRequired;
            target.ProductAttributeDisplayOrder = source.ProductAttributeDisplayOrder;
            target.PriceAdjustment = source.PriceAdjustment;
            target.WeightAdjustement = source.WeightAdjustement;
            target.Cost = source.Cost;
            target.Quantity = source.Quantity;
            target.IsPreSelected = source.IsPreSelected;
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.AttributeName = source.AttributeName;
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.ProductAttributeID = source.ProductAttributeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VProductAttributeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VProductAttribute> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VProductAttributeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VProductAttribute> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VProductAttribute> ToEntities(this IEnumerable<VProductAttributeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VProductAttribute source, VProductAttributeDTO target);

        static partial void OnEntityCreating(VProductAttributeDTO source, Bec.TargetFramework.Data.VProductAttribute target);

    }

}
