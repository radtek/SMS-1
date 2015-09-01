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

    public static partial class VOrganisationLedgerTransactionBalanceConverter
    {

        public static VOrganisationLedgerTransactionBalanceDTO ToDto(this Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationLedgerTransactionBalanceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationLedgerTransactionBalanceDTO();

            // Properties
            target.OrganisationLedgerAccountID = source.OrganisationLedgerAccountID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.BalanceOn = source.BalanceOn;
            target.Amount = source.Amount;
            target.InvoiceReference = source.InvoiceReference;
            target.Balance = source.Balance;
            target.CreatedByName = source.CreatedByName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance ToEntity(this VOrganisationLedgerTransactionBalanceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance();

            // Properties
            target.OrganisationLedgerAccountID = source.OrganisationLedgerAccountID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.BalanceOn = source.BalanceOn;
            target.Amount = source.Amount;
            target.InvoiceReference = source.InvoiceReference;
            target.Balance = source.Balance;
            target.CreatedByName = source.CreatedByName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationLedgerTransactionBalanceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationLedgerTransactionBalanceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance> ToEntities(this IEnumerable<VOrganisationLedgerTransactionBalanceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance source, VOrganisationLedgerTransactionBalanceDTO target);

        static partial void OnEntityCreating(VOrganisationLedgerTransactionBalanceDTO source, Bec.TargetFramework.Data.VOrganisationLedgerTransactionBalance target);

    }

}