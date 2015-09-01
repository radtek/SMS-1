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

    public static partial class StateItemConverter
    {

        public static StateItemDTO ToDto(this Bec.TargetFramework.Data.StateItem source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StateItemDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StateItem source, int level)
        {
            if (source == null)
              return null;

            var target = new StateItemDTO();

            // Properties
            target.StateItemID = source.StateItemID;
            target.StateItemName = source.StateItemName;
            target.StateItemDescription = source.StateItemDescription;
            target.StateID = source.StateID;
            target.SourceTableName = source.SourceTableName;
            target.SourceTableField = source.SourceTableField;
            target.SourceTableFieldValue = source.SourceTableFieldValue;
            target.ParentStateItemID = source.ParentStateItemID;
            target.StateItemOrder = source.StateItemOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ModuleClaims = source.ModuleClaims.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleClaims = source.DefaultOrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.OrganisationRoleClaims = source.OrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.ProductClaims = source.ProductClaims.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleClaimTemplates = source.DefaultOrganisationRoleClaimTemplates.ToDtosWithRelated(level - 1);
              target.ProductClaimTemplates = source.ProductClaimTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeClaimTemplates = source.StatusTypeClaimTemplates.ToDtosWithRelated(level - 1);
              target.ModuleClaimTemplates = source.ModuleClaimTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaims = source.NotificationConstructClaims.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaimTemplates = source.NotificationConstructClaimTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeClaims = source.StatusTypeClaims.ToDtosWithRelated(level - 1);
              target.ArtefactClaimTemplates = source.ArtefactClaimTemplates.ToDtosWithRelated(level - 1);
              target.ArtefactClaims = source.ArtefactClaims.ToDtosWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.RoleClaims = source.RoleClaims.ToDtosWithRelated(level - 1);
              target.ActorClaimRoleMappings = source.ActorClaimRoleMappings.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StateItem ToEntity(this StateItemDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StateItem();

            // Properties
            target.StateItemID = source.StateItemID;
            target.StateItemName = source.StateItemName;
            target.StateItemDescription = source.StateItemDescription;
            target.StateID = source.StateID;
            target.SourceTableName = source.SourceTableName;
            target.SourceTableField = source.SourceTableField;
            target.SourceTableFieldValue = source.SourceTableFieldValue;
            target.ParentStateItemID = source.ParentStateItemID;
            target.StateItemOrder = source.StateItemOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StateItemDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StateItem> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StateItemDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StateItem> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StateItem> ToEntities(this IEnumerable<StateItemDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StateItem source, StateItemDTO target);

        static partial void OnEntityCreating(StateItemDTO source, Bec.TargetFramework.Data.StateItem target);

    }

}