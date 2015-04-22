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

    public static partial class StsSearchConverter
    {

        public static StsSearchDTO ToDto(this Bec.TargetFramework.Data.StsSearch source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearch source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchDTO();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.StsSearchTypeID = source.StsSearchTypeID;
            target.StsSearchSubTypeID = source.StsSearchSubTypeID;
            target.StsSearchCategoryID = source.StsSearchCategoryID;
            target.StsSearchSubCategoryID = source.StsSearchSubCategoryID;
            target.InternalReferenceNumber = source.InternalReferenceNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AssignedToUserAccountOrganisationID = source.AssignedToUserAccountOrganisationID;
            target.CreatedOn = source.CreatedOn;

            // Navigation Properties
            if (level > 0) {
              target.StsSearchDetails = source.StsSearchDetails.ToDtosWithRelated(level - 1);
              target.StsSearchProcessLogs = source.StsSearchProcessLogs.ToDtosWithRelated(level - 1);
              target.StsSearchRelations_BuyerStsSearchID = source.StsSearchRelations_BuyerStsSearchID.ToDtosWithRelated(level - 1);
              target.StsSearchRelations_SellerStsSearchID = source.StsSearchRelations_SellerStsSearchID.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearch ToEntity(this StsSearchDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearch();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.StsSearchTypeID = source.StsSearchTypeID;
            target.StsSearchSubTypeID = source.StsSearchSubTypeID;
            target.StsSearchCategoryID = source.StsSearchCategoryID;
            target.StsSearchSubCategoryID = source.StsSearchSubCategoryID;
            target.InternalReferenceNumber = source.InternalReferenceNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AssignedToUserAccountOrganisationID = source.AssignedToUserAccountOrganisationID;
            target.CreatedOn = source.CreatedOn;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearch> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearch> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearch> ToEntities(this IEnumerable<StsSearchDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearch source, StsSearchDTO target);

        static partial void OnEntityCreating(StsSearchDTO source, Bec.TargetFramework.Data.StsSearch target);

    }

}
