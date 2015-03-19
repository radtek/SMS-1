﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class UserAccountLedgerAccountConverter
    {

        public static UserAccountLedgerAccountDTO ToDto(this Bec.TargetFramework.Data.UserAccountLedgerAccount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountLedgerAccountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountLedgerAccount source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountLedgerAccountDTO();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.LedgerAccountID = source.LedgerAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
              target.OrganisationLedgerAccount = source.OrganisationLedgerAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountLedgerAccount ToEntity(this UserAccountLedgerAccountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountLedgerAccount();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.LedgerAccountID = source.LedgerAccountID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountLedgerAccountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountLedgerAccount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountLedgerAccountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountLedgerAccount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountLedgerAccount> ToEntities(this IEnumerable<UserAccountLedgerAccountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountLedgerAccount source, UserAccountLedgerAccountDTO target);

        static partial void OnEntityCreating(UserAccountLedgerAccountDTO source, Bec.TargetFramework.Data.UserAccountLedgerAccount target);

    }

}
