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

    public static partial class InterfacePanelFieldDetailValidationOrganisationTypeConverter
    {

        public static InterfacePanelFieldDetailValidationOrganisationTypeDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelFieldDetailValidationOrganisationTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelFieldDetailValidationOrganisationTypeDTO();

            // Properties
            target.InterfacePanelFieldDetailValidationOrganisationTypeID = source.InterfacePanelFieldDetailValidationOrganisationTypeID;
            target.InterfacePanelFieldDetailValidationOrganisationTypeVersion = source.InterfacePanelFieldDetailValidationOrganisationTypeVersion;
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.InterfacePanelFieldDetailValidationOrganisationTypeName = source.InterfacePanelFieldDetailValidationOrganisationTypeName;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanel = source.InterfacePanel.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType ToEntity(this InterfacePanelFieldDetailValidationOrganisationTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType();

            // Properties
            target.InterfacePanelFieldDetailValidationOrganisationTypeID = source.InterfacePanelFieldDetailValidationOrganisationTypeID;
            target.InterfacePanelFieldDetailValidationOrganisationTypeVersion = source.InterfacePanelFieldDetailValidationOrganisationTypeVersion;
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.InterfacePanelFieldDetailValidationOrganisationTypeName = source.InterfacePanelFieldDetailValidationOrganisationTypeName;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelFieldDetailValidationOrganisationTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelFieldDetailValidationOrganisationTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType> ToEntities(this IEnumerable<InterfacePanelFieldDetailValidationOrganisationTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType source, InterfacePanelFieldDetailValidationOrganisationTypeDTO target);

        static partial void OnEntityCreating(InterfacePanelFieldDetailValidationOrganisationTypeDTO source, Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationOrganisationType target);

    }

}
