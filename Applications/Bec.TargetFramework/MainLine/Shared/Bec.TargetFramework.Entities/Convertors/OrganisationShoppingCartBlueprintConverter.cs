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

    public static partial class OrganisationShoppingCartBlueprintConverter
    {

        public static OrganisationShoppingCartBlueprintDTO ToDto(this Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationShoppingCartBlueprintDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationShoppingCartBlueprintDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ShoppingCartBlueprint = source.ShoppingCartBlueprint.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint ToEntity(this OrganisationShoppingCartBlueprintDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationShoppingCartBlueprintDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationShoppingCartBlueprintDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint> ToEntities(this IEnumerable<OrganisationShoppingCartBlueprintDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint source, OrganisationShoppingCartBlueprintDTO target);

        static partial void OnEntityCreating(OrganisationShoppingCartBlueprintDTO source, Bec.TargetFramework.Data.OrganisationShoppingCartBlueprint target);

    }

}
