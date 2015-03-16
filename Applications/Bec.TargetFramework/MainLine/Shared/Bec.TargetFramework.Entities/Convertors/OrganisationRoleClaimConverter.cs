﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationRoleClaimConverter
    {

        public static OrganisationRoleClaimDTO ToDto(this Bec.TargetFramework.Data.OrganisationRoleClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationRoleClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationRoleClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationRoleClaimDTO();

            // Properties
            target.OrganisationRoleClaimID = source.OrganisationRoleClaimID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
              target.OrganisationRole = source.OrganisationRole.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationRoleClaim ToEntity(this OrganisationRoleClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationRoleClaim();

            // Properties
            target.OrganisationRoleClaimID = source.OrganisationRoleClaimID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationRoleClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationRoleClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationRoleClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationRoleClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationRoleClaim> ToEntities(this IEnumerable<OrganisationRoleClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationRoleClaim source, OrganisationRoleClaimDTO target);

        static partial void OnEntityCreating(OrganisationRoleClaimDTO source, Bec.TargetFramework.Data.OrganisationRoleClaim target);

    }

}
