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

    public static partial class InterfacePanelFieldDetailValidationTemplateConverter
    {

        public static InterfacePanelFieldDetailValidationTemplateDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelFieldDetailValidationTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelFieldDetailValidationTemplateDTO();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.InterfacePanelFieldDetailValidationTemplateVersion = source.InterfacePanelFieldDetailValidationTemplateVersion;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InterfacePanelFieldDetailValidationTemplateID = source.InterfacePanelFieldDetailValidationTemplateID;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.InterfacePanelFieldDetailValidationTemplateName = source.InterfacePanelFieldDetailValidationTemplateName;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate ToEntity(this InterfacePanelFieldDetailValidationTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.InterfacePanelFieldDetailValidationTemplateVersion = source.InterfacePanelFieldDetailValidationTemplateVersion;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InterfacePanelFieldDetailValidationTemplateID = source.InterfacePanelFieldDetailValidationTemplateID;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.InterfacePanelFieldDetailValidationTemplateName = source.InterfacePanelFieldDetailValidationTemplateName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelFieldDetailValidationTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelFieldDetailValidationTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate> ToEntities(this IEnumerable<InterfacePanelFieldDetailValidationTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate source, InterfacePanelFieldDetailValidationTemplateDTO target);

        static partial void OnEntityCreating(InterfacePanelFieldDetailValidationTemplateDTO source, Bec.TargetFramework.Data.InterfacePanelFieldDetailValidationTemplate target);

    }

}
