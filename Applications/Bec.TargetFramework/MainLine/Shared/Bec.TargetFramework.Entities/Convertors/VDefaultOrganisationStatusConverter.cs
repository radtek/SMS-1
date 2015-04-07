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

    public static partial class VDefaultOrganisationStatusConverter
    {

        public static VDefaultOrganisationStatusDTO ToDto(this Bec.TargetFramework.Data.VDefaultOrganisationStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VDefaultOrganisationStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VDefaultOrganisationStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VDefaultOrganisationStatusDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RootOrganisationTypeID = source.RootOrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsDefault = source.IsDefault;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusTypeValueName = source.StatusTypeValueName;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VDefaultOrganisationStatus ToEntity(this VDefaultOrganisationStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VDefaultOrganisationStatus();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RootOrganisationTypeID = source.RootOrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsDefault = source.IsDefault;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeName = source.StatusTypeName;
            target.StatusTypeValueName = source.StatusTypeValueName;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusOrder = source.StatusOrder;
            target.IsStart = source.IsStart;
            target.IsEnd = source.IsEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VDefaultOrganisationStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VDefaultOrganisationStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VDefaultOrganisationStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VDefaultOrganisationStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VDefaultOrganisationStatus> ToEntities(this IEnumerable<VDefaultOrganisationStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VDefaultOrganisationStatus source, VDefaultOrganisationStatusDTO target);

        static partial void OnEntityCreating(VDefaultOrganisationStatusDTO source, Bec.TargetFramework.Data.VDefaultOrganisationStatus target);

    }

}
