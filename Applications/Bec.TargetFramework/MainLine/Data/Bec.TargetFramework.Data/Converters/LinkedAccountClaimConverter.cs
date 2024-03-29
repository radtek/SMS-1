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

    public static partial class LinkedAccountClaimConverter
    {

        public static LinkedAccountClaimDTO ToDto(this Bec.TargetFramework.Data.LinkedAccountClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LinkedAccountClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LinkedAccountClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new LinkedAccountClaimDTO();

            // Properties
            target.LinkedAccountProviderName = source.LinkedAccountProviderName;
            target.LinkedAccountProviderAccountID = source.LinkedAccountProviderAccountID;
            target.Type = source.Type;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.LinkedAccount = source.LinkedAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LinkedAccountClaim ToEntity(this LinkedAccountClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LinkedAccountClaim();

            // Properties
            target.LinkedAccountProviderName = source.LinkedAccountProviderName;
            target.LinkedAccountProviderAccountID = source.LinkedAccountProviderAccountID;
            target.Type = source.Type;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LinkedAccountClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LinkedAccountClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LinkedAccountClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LinkedAccountClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LinkedAccountClaim> ToEntities(this IEnumerable<LinkedAccountClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LinkedAccountClaim source, LinkedAccountClaimDTO target);

        static partial void OnEntityCreating(LinkedAccountClaimDTO source, Bec.TargetFramework.Data.LinkedAccountClaim target);

    }

}
