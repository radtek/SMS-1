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

    public static partial class StateConverter
    {

        public static StateDTO ToDto(this Bec.TargetFramework.Data.State source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.State source, int level)
        {
            if (source == null)
              return null;

            var target = new StateDTO();

            // Properties
            target.StateID = source.StateID;
            target.StateName = source.StateName;
            target.StateDescription = source.StateDescription;
            target.StateTypeID = source.StateTypeID;
            target.StateCategoryID = source.StateCategoryID;
            target.StateSubCategoryID = source.StateSubCategoryID;
            target.ParentStateID = source.ParentStateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

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
              target.StateItems = source.StateItems.ToDtosWithRelated(level - 1);
              target.RoleClaims = source.RoleClaims.ToDtosWithRelated(level - 1);
              target.ActorClaimRoleMappings = source.ActorClaimRoleMappings.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.State ToEntity(this StateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.State();

            // Properties
            target.StateID = source.StateID;
            target.StateName = source.StateName;
            target.StateDescription = source.StateDescription;
            target.StateTypeID = source.StateTypeID;
            target.StateCategoryID = source.StateCategoryID;
            target.StateSubCategoryID = source.StateSubCategoryID;
            target.ParentStateID = source.ParentStateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.State> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.State> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.State> ToEntities(this IEnumerable<StateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.State source, StateDTO target);

        static partial void OnEntityCreating(StateDTO source, Bec.TargetFramework.Data.State target);

    }

}
