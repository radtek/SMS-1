﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LedgerAccountTransactionConverter
    {

        public static LedgerAccountTransactionDTO ToDto(this Bec.TargetFramework.Data.LedgerAccountTransaction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LedgerAccountTransactionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LedgerAccountTransaction source, int level)
        {
            if (source == null)
              return null;

            var target = new LedgerAccountTransactionDTO();

            // Properties
            target.LedgerAccountID = source.LedgerAccountID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.BalanceOn = source.BalanceOn;

            // Navigation Properties
            if (level > 0) {
              target.TransactionOrder = source.TransactionOrder.ToDtoWithRelated(level - 1);
              target.OrganisationLedgerAccount = source.OrganisationLedgerAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LedgerAccountTransaction ToEntity(this LedgerAccountTransactionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LedgerAccountTransaction();

            // Properties
            target.LedgerAccountID = source.LedgerAccountID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.BalanceOn = source.BalanceOn;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LedgerAccountTransactionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LedgerAccountTransaction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LedgerAccountTransactionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LedgerAccountTransaction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LedgerAccountTransaction> ToEntities(this IEnumerable<LedgerAccountTransactionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LedgerAccountTransaction source, LedgerAccountTransactionDTO target);

        static partial void OnEntityCreating(LedgerAccountTransactionDTO source, Bec.TargetFramework.Data.LedgerAccountTransaction target);

    }

}
