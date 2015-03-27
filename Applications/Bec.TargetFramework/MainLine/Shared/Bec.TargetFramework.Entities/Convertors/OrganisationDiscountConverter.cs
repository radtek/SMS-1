﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationDiscountConverter
    {

        public static OrganisationDiscountDTO ToDto(this Bec.TargetFramework.Data.OrganisationDiscount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationDiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationDiscount source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationDiscountDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Discount = source.Discount.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationDiscount ToEntity(this OrganisationDiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationDiscount();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationDiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationDiscount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationDiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationDiscount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationDiscount> ToEntities(this IEnumerable<OrganisationDiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationDiscount source, OrganisationDiscountDTO target);

        static partial void OnEntityCreating(OrganisationDiscountDTO source, Bec.TargetFramework.Data.OrganisationDiscount target);

    }

}
