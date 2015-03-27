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

    public static partial class DefaultOrganisationShoppingCartBlueprintConverter
    {

        public static DefaultOrganisationShoppingCartBlueprintDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationShoppingCartBlueprintDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationShoppingCartBlueprintDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.ShoppingCartBlueprint = source.ShoppingCartBlueprint.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint ToEntity(this DefaultOrganisationShoppingCartBlueprintDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationShoppingCartBlueprintDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationShoppingCartBlueprintDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint> ToEntities(this IEnumerable<DefaultOrganisationShoppingCartBlueprintDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint source, DefaultOrganisationShoppingCartBlueprintDTO target);

        static partial void OnEntityCreating(DefaultOrganisationShoppingCartBlueprintDTO source, Bec.TargetFramework.Data.DefaultOrganisationShoppingCartBlueprint target);

    }

}
