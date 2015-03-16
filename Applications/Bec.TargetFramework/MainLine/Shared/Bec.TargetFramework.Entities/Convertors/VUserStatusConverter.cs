﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VUserStatusConverter
    {

        public static VUserStatusDTO ToDto(this Bec.TargetFramework.Data.VUserStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VUserStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VUserStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VUserStatusDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.OrganisationID = source.OrganisationID;
            target.UserID = source.UserID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserTypeID = source.UserTypeID;
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

        public static Bec.TargetFramework.Data.VUserStatus ToEntity(this VUserStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VUserStatus();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.OrganisationID = source.OrganisationID;
            target.UserID = source.UserID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserTypeID = source.UserTypeID;
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

        public static List<VUserStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VUserStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VUserStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VUserStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VUserStatus> ToEntities(this IEnumerable<VUserStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VUserStatus source, VUserStatusDTO target);

        static partial void OnEntityCreating(VUserStatusDTO source, Bec.TargetFramework.Data.VUserStatus target);

    }

}
