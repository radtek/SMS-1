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

    public static partial class HelpPageItemConverter
    {

        public static HelpPageItemDTO ToDto(this Bec.TargetFramework.Data.HelpPageItem source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static HelpPageItemDTO ToDtoWithRelated(this Bec.TargetFramework.Data.HelpPageItem source, int level)
        {
            if (source == null)
              return null;

            var target = new HelpPageItemDTO();

            // Properties
            target.HelpPageItemID = source.HelpPageItemID;
            target.HelpPageID = source.HelpPageID;
            target.Title = source.Title;
            target.Description = source.Description;
            target.DisplayOrder = source.DisplayOrder;
            target.Selector = source.Selector;
            target.TabContainerId = source.TabContainerId;
            target.EffectiveOn = source.EffectiveOn;
            target.Position = source.Position;
            target.CreatedOn = source.CreatedOn;
            target.ModifiedOn = source.ModifiedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedBy = source.ModifiedBy;

            // Navigation Properties
            if (level > 0) {
              target.HelpPageItemUserAccounts = source.HelpPageItemUserAccounts.ToDtosWithRelated(level - 1);
              target.HelpPage = source.HelpPage.ToDtoWithRelated(level - 1);
              target.HelpPageItemRoles = source.HelpPageItemRoles.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.HelpPageItem ToEntity(this HelpPageItemDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.HelpPageItem();

            // Properties
            target.HelpPageItemID = source.HelpPageItemID;
            target.HelpPageID = source.HelpPageID;
            target.Title = source.Title;
            target.Description = source.Description;
            target.DisplayOrder = source.DisplayOrder;
            target.Selector = source.Selector;
            target.TabContainerId = source.TabContainerId;
            target.EffectiveOn = source.EffectiveOn;
            target.Position = source.Position;
            target.CreatedOn = source.CreatedOn;
            target.ModifiedOn = source.ModifiedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedBy = source.ModifiedBy;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<HelpPageItemDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.HelpPageItem> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<HelpPageItemDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.HelpPageItem> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.HelpPageItem> ToEntities(this IEnumerable<HelpPageItemDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.HelpPageItem source, HelpPageItemDTO target);

        static partial void OnEntityCreating(HelpPageItemDTO source, Bec.TargetFramework.Data.HelpPageItem target);

    }

}