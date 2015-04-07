﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LegalOrganisationDetailConverter
    {

        public static LegalOrganisationDetailDTO ToDto(this Bec.TargetFramework.Data.LegalOrganisationDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LegalOrganisationDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LegalOrganisationDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new LegalOrganisationDetailDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.IsVATRegistered = source.IsVATRegistered;
            target.VATNumber = source.VATNumber;
            target.IsCompanyHouseRegistered = source.IsCompanyHouseRegistered;
            target.RegisteredCompanyNumber = source.RegisteredCompanyNumber;
            target.PartnersCount = source.PartnersCount;
            target.RegisteredPractitionersCount = source.RegisteredPractitionersCount;
            target.StaffCount = source.StaffCount;
            target.MonthlyCompletionsCount = source.MonthlyCompletionsCount;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LegalOrganisationDetail ToEntity(this LegalOrganisationDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LegalOrganisationDetail();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.IsVATRegistered = source.IsVATRegistered;
            target.VATNumber = source.VATNumber;
            target.IsCompanyHouseRegistered = source.IsCompanyHouseRegistered;
            target.RegisteredCompanyNumber = source.RegisteredCompanyNumber;
            target.PartnersCount = source.PartnersCount;
            target.RegisteredPractitionersCount = source.RegisteredPractitionersCount;
            target.StaffCount = source.StaffCount;
            target.MonthlyCompletionsCount = source.MonthlyCompletionsCount;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LegalOrganisationDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LegalOrganisationDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LegalOrganisationDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LegalOrganisationDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LegalOrganisationDetail> ToEntities(this IEnumerable<LegalOrganisationDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LegalOrganisationDetail source, LegalOrganisationDetailDTO target);

        static partial void OnEntityCreating(LegalOrganisationDetailDTO source, Bec.TargetFramework.Data.LegalOrganisationDetail target);

    }

}
