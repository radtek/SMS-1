﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelOrganisationTypeUserTypeConverter
    {

        public static InterfacePanelOrganisationTypeUserTypeDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelOrganisationTypeUserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelOrganisationTypeUserTypeDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.InterfacePanelOrganisationTypeUserTypeLabel = source.InterfacePanelOrganisationTypeUserTypeLabel;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.InterfacePanel = source.InterfacePanel.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType ToEntity(this InterfacePanelOrganisationTypeUserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.InterfacePanelOrganisationTypeUserTypeLabel = source.InterfacePanelOrganisationTypeUserTypeLabel;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelOrganisationTypeUserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelOrganisationTypeUserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType> ToEntities(this IEnumerable<InterfacePanelOrganisationTypeUserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType source, InterfacePanelOrganisationTypeUserTypeDTO target);

        static partial void OnEntityCreating(InterfacePanelOrganisationTypeUserTypeDTO source, Bec.TargetFramework.Data.InterfacePanelOrganisationTypeUserType target);

    }

}
