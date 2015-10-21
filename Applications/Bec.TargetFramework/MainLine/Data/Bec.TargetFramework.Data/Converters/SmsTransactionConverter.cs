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

    public static partial class SmsTransactionConverter
    {

        public static SmsTransactionDTO ToDto(this Bec.TargetFramework.Data.SmsTransaction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SmsTransactionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SmsTransaction source, int level)
        {
            if (source == null)
              return null;

            var target = new SmsTransactionDTO();

            // Properties
            target.SmsTransactionID = source.SmsTransactionID;
            target.AddressID = source.AddressID;
            target.Price = source.Price;
            target.Reference = source.Reference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.TenureTypeID = source.TenureTypeID;
            target.OrganisationID = source.OrganisationID;
            target.CreatedOn = source.CreatedOn;
            target.RowVersion = source.RowVersion;
            target.MortgageApplicationNumber = source.MortgageApplicationNumber;
            target.LenderName = source.LenderName;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.Confirmed = source.Confirmed;

            // Navigation Properties
            if (level > 0) {
              target.Address = source.Address.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
              target.SmsUserAccountOrganisationTransactions = source.SmsUserAccountOrganisationTransactions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SmsTransaction ToEntity(this SmsTransactionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SmsTransaction();

            // Properties
            target.SmsTransactionID = source.SmsTransactionID;
            target.AddressID = source.AddressID;
            target.Price = source.Price;
            target.Reference = source.Reference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.TenureTypeID = source.TenureTypeID;
            target.OrganisationID = source.OrganisationID;
            target.CreatedOn = source.CreatedOn;
            target.RowVersion = source.RowVersion;
            target.MortgageApplicationNumber = source.MortgageApplicationNumber;
            target.LenderName = source.LenderName;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.Confirmed = source.Confirmed;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SmsTransactionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SmsTransaction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SmsTransactionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SmsTransaction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SmsTransaction> ToEntities(this IEnumerable<SmsTransactionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SmsTransaction source, SmsTransactionDTO target);

        static partial void OnEntityCreating(SmsTransactionDTO source, Bec.TargetFramework.Data.SmsTransaction target);

    }

}
