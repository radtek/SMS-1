﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LinkedAccountConverter
    {

        public static LinkedAccountDTO ToDto(this Bec.TargetFramework.Data.LinkedAccount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LinkedAccountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LinkedAccount source, int level)
        {
            if (source == null)
              return null;

            var target = new LinkedAccountDTO();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.ProviderName = source.ProviderName;
            target.ProviderAccountID = source.ProviderAccountID;
            target.LastLogin = source.LastLogin;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
              target.LinkedAccountClaims = source.LinkedAccountClaims.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LinkedAccount ToEntity(this LinkedAccountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LinkedAccount();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.ProviderName = source.ProviderName;
            target.ProviderAccountID = source.ProviderAccountID;
            target.LastLogin = source.LastLogin;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LinkedAccountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LinkedAccount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LinkedAccountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LinkedAccount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LinkedAccount> ToEntities(this IEnumerable<LinkedAccountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LinkedAccount source, LinkedAccountDTO target);

        static partial void OnEntityCreating(LinkedAccountDTO source, Bec.TargetFramework.Data.LinkedAccount target);

    }

}
