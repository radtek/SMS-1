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

    public static partial class VOrganisationWithStatusAndAdminConverter
    {

        public static VOrganisationWithStatusAndAdminDTO ToDto(this Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationWithStatusAndAdminDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationWithStatusAndAdminDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.Name = source.Name;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.OrganisationVerified = source.OrganisationVerified;
            target.OrganisationPinCreated = source.OrganisationPinCreated;
            target.OrganisationPinCode = source.OrganisationPinCode;
            target.OrganisationAdminSalutation = source.OrganisationAdminSalutation;
            target.OrganisationAdminFirstName = source.OrganisationAdminFirstName;
            target.OrganisationAdminLastName = source.OrganisationAdminLastName;
            target.OrganisationAdminTelephone = source.OrganisationAdminTelephone;
            target.OrganisationAdminEmail = source.OrganisationAdminEmail;
            target.Regulator = source.Regulator;
            target.RegulatorOther = source.RegulatorOther;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Town = source.Town;
            target.County = source.County;
            target.PostalCode = source.PostalCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.OrganisationAdminUserID = source.OrganisationAdminUserID;
            target.StatusValueName = source.StatusValueName;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.Reason = source.Reason;
            target.Notes = source.Notes;
            target.OrganisationAdminCreated = source.OrganisationAdminCreated;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin ToEntity(this VOrganisationWithStatusAndAdminDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.Name = source.Name;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.OrganisationVerified = source.OrganisationVerified;
            target.OrganisationPinCreated = source.OrganisationPinCreated;
            target.OrganisationPinCode = source.OrganisationPinCode;
            target.OrganisationAdminSalutation = source.OrganisationAdminSalutation;
            target.OrganisationAdminFirstName = source.OrganisationAdminFirstName;
            target.OrganisationAdminLastName = source.OrganisationAdminLastName;
            target.OrganisationAdminTelephone = source.OrganisationAdminTelephone;
            target.OrganisationAdminEmail = source.OrganisationAdminEmail;
            target.Regulator = source.Regulator;
            target.RegulatorOther = source.RegulatorOther;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Town = source.Town;
            target.County = source.County;
            target.PostalCode = source.PostalCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.OrganisationAdminUserID = source.OrganisationAdminUserID;
            target.StatusValueName = source.StatusValueName;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.Reason = source.Reason;
            target.Notes = source.Notes;
            target.OrganisationAdminCreated = source.OrganisationAdminCreated;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationWithStatusAndAdminDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationWithStatusAndAdminDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin> ToEntities(this IEnumerable<VOrganisationWithStatusAndAdminDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin source, VOrganisationWithStatusAndAdminDTO target);

        static partial void OnEntityCreating(VOrganisationWithStatusAndAdminDTO source, Bec.TargetFramework.Data.VOrganisationWithStatusAndAdmin target);

    }

}
