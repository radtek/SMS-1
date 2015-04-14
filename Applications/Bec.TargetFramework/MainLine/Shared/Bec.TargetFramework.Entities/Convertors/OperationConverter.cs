﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OperationConverter
    {

        public static OperationDTO ToDto(this Bec.TargetFramework.Data.Operation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OperationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Operation source, int level)
        {
            if (source == null)
              return null;

            var target = new OperationDTO();

            // Properties
            target.OperationID = source.OperationID;
            target.OperationName = source.OperationName;
            target.OperationDescription = source.OperationDescription;
            target.SourceID = source.SourceID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // Navigation Properties
            if (level > 0) {
              target.ModuleClaims = source.ModuleClaims.ToDtosWithRelated(level - 1);
              target.InterfacePanelClaimTemplates = source.InterfacePanelClaimTemplates.ToDtosWithRelated(level - 1);
              target.InterfacePanelClaims = source.InterfacePanelClaims.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleClaims = source.DefaultOrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.OrganisationRoleClaims = source.OrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.WorkflowClaimTemplates = source.WorkflowClaimTemplates.ToDtosWithRelated(level - 1);
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
              target.RoleClaims = source.RoleClaims.ToDtosWithRelated(level - 1);
              target.WorkflowClaims = source.WorkflowClaims.ToDtosWithRelated(level - 1);
              target.Resources = source.Resources.ToDtosWithRelated(level - 1);
              target.ActorClaimRoleMappings = source.ActorClaimRoleMappings.ToDtosWithRelated(level - 1);
              target.ResourceOperationTargets = source.ResourceOperationTargets.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Operation ToEntity(this OperationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Operation();

            // Properties
            target.OperationID = source.OperationID;
            target.OperationName = source.OperationName;
            target.OperationDescription = source.OperationDescription;
            target.SourceID = source.SourceID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OperationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Operation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OperationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Operation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Operation> ToEntities(this IEnumerable<OperationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Operation source, OperationDTO target);

        static partial void OnEntityCreating(OperationDTO source, Bec.TargetFramework.Data.Operation target);

    }

}
