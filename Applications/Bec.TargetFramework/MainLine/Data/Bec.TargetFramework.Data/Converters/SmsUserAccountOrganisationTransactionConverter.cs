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

    public static partial class SmsUserAccountOrganisationTransactionConverter
    {

        public static SmsUserAccountOrganisationTransactionDTO ToDto(this Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SmsUserAccountOrganisationTransactionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction source, int level)
        {
            if (source == null)
              return null;

            var target = new SmsUserAccountOrganisationTransactionDTO();

            // Properties
            target.SmsUserAccountOrganisationTransactionId = source.SmsUserAccountOrganisationTransactionId;
            target.UserAccountOrganisationId = source.UserAccountOrganisationId;
            target.SmsTransactionId = source.SmsTransactionId;
            target.SmsUserAccountOrganisationTransactionTypeId = source.SmsUserAccountOrganisationTransactionTypeId;
            target.UserAccountAddressId = source.UserAccountAddressId;

            // Navigation Properties
            if (level > 0) {
              target.SmsTransaction = source.SmsTransaction.ToDtoWithRelated(level - 1);
              target.SmsUserAccountOrganisationTransactionType = source.SmsUserAccountOrganisationTransactionType.ToDtoWithRelated(level - 1);
              target.UserAccountAddress = source.UserAccountAddress.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction ToEntity(this SmsUserAccountOrganisationTransactionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction();

            // Properties
            target.SmsUserAccountOrganisationTransactionId = source.SmsUserAccountOrganisationTransactionId;
            target.UserAccountOrganisationId = source.UserAccountOrganisationId;
            target.SmsTransactionId = source.SmsTransactionId;
            target.SmsUserAccountOrganisationTransactionTypeId = source.SmsUserAccountOrganisationTransactionTypeId;
            target.UserAccountAddressId = source.UserAccountAddressId;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SmsUserAccountOrganisationTransactionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SmsUserAccountOrganisationTransactionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction> ToEntities(this IEnumerable<SmsUserAccountOrganisationTransactionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction source, SmsUserAccountOrganisationTransactionDTO target);

        static partial void OnEntityCreating(SmsUserAccountOrganisationTransactionDTO source, Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction target);

    }

}
