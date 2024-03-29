﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VProductSpecificationConverter
    {

        public static VProductSpecificationDTO ToDto(this Bec.TargetFramework.Data.VProductSpecification source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VProductSpecificationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VProductSpecification source, int level)
        {
            if (source == null)
              return null;

            var target = new VProductSpecificationDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.SpecificationName = source.SpecificationName;
            target.SpecificationDescription = source.SpecificationDescription;
            target.SpecificationDisplayOrder = source.SpecificationDisplayOrder;
            target.IsMandatory = source.IsMandatory;
            target.IsMultiSelect = source.IsMultiSelect;
            target.IsPreSelected = source.IsPreSelected;
            target.MinimumSelectionLimit = source.MinimumSelectionLimit;
            target.MaximumSelectionLimit = source.MaximumSelectionLimit;
            target.IsUserDefined = source.IsUserDefined;
            target.IsPriceDriven = source.IsPriceDriven;
            target.ProductSpecificationAttributeOptionID = source.ProductSpecificationAttributeOptionID;
            target.SpecDefaultOptionPriceAdjustement = source.SpecDefaultOptionPriceAdjustement;
            target.SpecDefaultOptionCost = source.SpecDefaultOptionCost;
            target.SpecDefaultOptionDefaultValue = source.SpecDefaultOptionDefaultValue;
            target.SpecDefaultOptionDefaultQuantity = source.SpecDefaultOptionDefaultQuantity;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VProductSpecification ToEntity(this VProductSpecificationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VProductSpecification();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.SpecificationName = source.SpecificationName;
            target.SpecificationDescription = source.SpecificationDescription;
            target.SpecificationDisplayOrder = source.SpecificationDisplayOrder;
            target.IsMandatory = source.IsMandatory;
            target.IsMultiSelect = source.IsMultiSelect;
            target.IsPreSelected = source.IsPreSelected;
            target.MinimumSelectionLimit = source.MinimumSelectionLimit;
            target.MaximumSelectionLimit = source.MaximumSelectionLimit;
            target.IsUserDefined = source.IsUserDefined;
            target.IsPriceDriven = source.IsPriceDriven;
            target.ProductSpecificationAttributeOptionID = source.ProductSpecificationAttributeOptionID;
            target.SpecDefaultOptionPriceAdjustement = source.SpecDefaultOptionPriceAdjustement;
            target.SpecDefaultOptionCost = source.SpecDefaultOptionCost;
            target.SpecDefaultOptionDefaultValue = source.SpecDefaultOptionDefaultValue;
            target.SpecDefaultOptionDefaultQuantity = source.SpecDefaultOptionDefaultQuantity;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VProductSpecificationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VProductSpecification> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VProductSpecificationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VProductSpecification> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VProductSpecification> ToEntities(this IEnumerable<VProductSpecificationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VProductSpecification source, VProductSpecificationDTO target);

        static partial void OnEntityCreating(VProductSpecificationDTO source, Bec.TargetFramework.Data.VProductSpecification target);

    }

}
