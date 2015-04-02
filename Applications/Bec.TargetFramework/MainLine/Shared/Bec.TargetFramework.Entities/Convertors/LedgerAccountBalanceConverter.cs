﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LedgerAccountBalanceConverter
    {

        public static LedgerAccountBalanceDTO ToDto(this Bec.TargetFramework.Data.LedgerAccountBalance source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LedgerAccountBalanceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LedgerAccountBalance source, int level)
        {
            if (source == null)
              return null;

            var target = new LedgerAccountBalanceDTO();

            // Properties
            target.LedgerAccountID = source.LedgerAccountID;
            target.BalanceOn = source.BalanceOn;
            target.Balance = source.Balance;
            target.BalanceAvailableAdjusted = source.BalanceAvailableAdjusted;
            target.BalanceAvailableClosing = source.BalanceAvailableClosing;
            target.BalanceBookAdjusted = source.BalanceBookAdjusted;
            target.BalanceBookClosing = source.BalanceBookClosing;
            target.BalanceCollectedAdjusted = source.BalanceCollectedAdjusted;
            target.BalanceCollectedClosing = source.BalanceCollectedClosing;
            target.IsDebit = source.IsDebit;
            target.IsCredit = source.IsCredit;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationLedgerAccount = source.OrganisationLedgerAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LedgerAccountBalance ToEntity(this LedgerAccountBalanceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LedgerAccountBalance();

            // Properties
            target.LedgerAccountID = source.LedgerAccountID;
            target.BalanceOn = source.BalanceOn;
            target.Balance = source.Balance;
            target.BalanceAvailableAdjusted = source.BalanceAvailableAdjusted;
            target.BalanceAvailableClosing = source.BalanceAvailableClosing;
            target.BalanceBookAdjusted = source.BalanceBookAdjusted;
            target.BalanceBookClosing = source.BalanceBookClosing;
            target.BalanceCollectedAdjusted = source.BalanceCollectedAdjusted;
            target.BalanceCollectedClosing = source.BalanceCollectedClosing;
            target.IsDebit = source.IsDebit;
            target.IsCredit = source.IsCredit;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LedgerAccountBalanceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LedgerAccountBalance> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LedgerAccountBalanceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LedgerAccountBalance> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LedgerAccountBalance> ToEntities(this IEnumerable<LedgerAccountBalanceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LedgerAccountBalance source, LedgerAccountBalanceDTO target);

        static partial void OnEntityCreating(LedgerAccountBalanceDTO source, Bec.TargetFramework.Data.LedgerAccountBalance target);

    }

}
