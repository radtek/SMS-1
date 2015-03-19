﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelValidationOrganisationTypeUserTypeTemplateConverter
    {

        public static InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO();

            // Properties
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateID = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateID;
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
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
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateName = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateName;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate ToEntity(this InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate();

            // Properties
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateID = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateID;
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
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
            target.InterfacePanelValidationOrganisationTypeUserTypeTemplateName = source.InterfacePanelValidationOrganisationTypeUserTypeTemplateName;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate> ToEntities(this IEnumerable<InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate source, InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO target);

        static partial void OnEntityCreating(InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO source, Bec.TargetFramework.Data.InterfacePanelValidationOrganisationTypeUserTypeTemplate target);

    }

}
