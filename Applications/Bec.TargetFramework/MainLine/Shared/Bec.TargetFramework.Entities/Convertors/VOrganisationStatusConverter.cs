﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VOrganisationStatusConverter
    {

        public static VOrganisationStatusDTO ToDto(this Bec.TargetFramework.Data.VOrganisationStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationStatusDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.IsBranch = source.IsBranch;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusValueName = source.StatusValueName;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;
            target.NextStatusTypeValueID = source.NextStatusTypeValueID;
            target.NextStatusTypeName = source.NextStatusTypeName;
            target.NextStatusOrder = source.NextStatusOrder;
            target.NextStatusStart = source.NextStatusStart;
            target.NextStatusEnd = source.NextStatusEnd;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationStatus ToEntity(this VOrganisationStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationStatus();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.IsBranch = source.IsBranch;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusValueName = source.StatusValueName;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;
            target.NextStatusTypeValueID = source.NextStatusTypeValueID;
            target.NextStatusTypeName = source.NextStatusTypeName;
            target.NextStatusOrder = source.NextStatusOrder;
            target.NextStatusStart = source.NextStatusStart;
            target.NextStatusEnd = source.NextStatusEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationStatus> ToEntities(this IEnumerable<VOrganisationStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationStatus source, VOrganisationStatusDTO target);

        static partial void OnEntityCreating(VOrganisationStatusDTO source, Bec.TargetFramework.Data.VOrganisationStatus target);

    }

}
