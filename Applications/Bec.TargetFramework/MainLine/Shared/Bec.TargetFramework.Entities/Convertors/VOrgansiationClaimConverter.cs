﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VOrgansiationClaimConverter
    {

        public static VOrgansiationClaimDTO ToDto(this Bec.TargetFramework.Data.VOrgansiationClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrgansiationClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrgansiationClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrgansiationClaimDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.ClaimType = source.ClaimType;
            target.ClaimID = source.ClaimID;
            target.ClaimName = source.ClaimName;
            target.ClaimDescription = source.ClaimDescription;
            target.ClaimSubType = source.ClaimSubType;
            target.ClaimSubID = source.ClaimSubID;
            target.ClaimSubName = source.ClaimSubName;
            target.ClaimSubDescription = source.ClaimSubDescription;
            target.ParentID = source.ParentID;
            target.RoleSource = source.RoleSource;
            target.ClaimTypeName = source.ClaimTypeName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrgansiationClaim ToEntity(this VOrgansiationClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrgansiationClaim();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.ClaimType = source.ClaimType;
            target.ClaimID = source.ClaimID;
            target.ClaimName = source.ClaimName;
            target.ClaimDescription = source.ClaimDescription;
            target.ClaimSubType = source.ClaimSubType;
            target.ClaimSubID = source.ClaimSubID;
            target.ClaimSubName = source.ClaimSubName;
            target.ClaimSubDescription = source.ClaimSubDescription;
            target.ParentID = source.ParentID;
            target.RoleSource = source.RoleSource;
            target.ClaimTypeName = source.ClaimTypeName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrgansiationClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrgansiationClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrgansiationClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrgansiationClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrgansiationClaim> ToEntities(this IEnumerable<VOrgansiationClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrgansiationClaim source, VOrgansiationClaimDTO target);

        static partial void OnEntityCreating(VOrgansiationClaimDTO source, Bec.TargetFramework.Data.VOrgansiationClaim target);

    }

}
