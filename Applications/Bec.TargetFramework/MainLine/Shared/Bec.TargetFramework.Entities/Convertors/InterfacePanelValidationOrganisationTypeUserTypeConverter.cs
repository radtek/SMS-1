﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelValidationOrganisationTypeUserTypeConverter
    {

        public static InterfacePanelValidationOrganisationTypeUserTypeDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelValidationOrganisationTypeUserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelValidationOrganisationTypeUserTypeDTO();

            // Properties
            target.InterfacePanelValidationOrganisationTypeUserTypeID = source.InterfacePanelValidationOrganisationTypeUserTypeID;
            target.InterfacePanelValidationOrganisationTypeUserTypeVersion = source.InterfacePanelValidationOrganisationTypeUserTypeVersion;
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.InterfacePanelValidationOrganisationTypeUserTypeName = source.InterfacePanelValidationOrganisationTypeUserTypeName;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanel = source.InterfacePanel.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType ToEntity(this InterfacePanelValidationOrganisationTypeUserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType();

            // Properties
            target.InterfacePanelValidationOrganisationTypeUserTypeID = source.InterfacePanelValidationOrganisationTypeUserTypeID;
            target.InterfacePanelValidationOrganisationTypeUserTypeVersion = source.InterfacePanelValidationOrganisationTypeUserTypeVersion;
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.InterfacePanelValidationOrganisationTypeUserTypeName = source.InterfacePanelValidationOrganisationTypeUserTypeName;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelValidationOrganisationTypeUserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelValidationOrganisationTypeUserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType> ToEntities(this IEnumerable<InterfacePanelValidationOrganisationTypeUserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType source, InterfacePanelValidationOrganisationTypeUserTypeDTO target);

        static partial void OnEntityCreating(InterfacePanelValidationOrganisationTypeUserTypeDTO source, Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserType target);

    }

}
