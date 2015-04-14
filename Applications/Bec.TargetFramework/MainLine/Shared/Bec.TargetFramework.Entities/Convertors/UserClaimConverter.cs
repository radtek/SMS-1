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

    public static partial class UserClaimConverter
    {

        public static UserClaimDTO ToDto(this Bec.TargetFramework.Data.UserClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new UserClaimDTO();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.Type = source.Type;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserClaim ToEntity(this UserClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserClaim();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.Type = source.Type;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserClaim> ToEntities(this IEnumerable<UserClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserClaim source, UserClaimDTO target);

        static partial void OnEntityCreating(UserClaimDTO source, Bec.TargetFramework.Data.UserClaim target);

    }

}
