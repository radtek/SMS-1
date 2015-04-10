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

    public static partial class InterfacePanelConverter
    {

        public static InterfacePanelDTO ToDto(this Bec.TargetFramework.Data.InterfacePanel source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanel source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InterfacePanelTypeID = source.InterfacePanelTypeID;
            target.InterfacePanelSubTypeID = source.InterfacePanelSubTypeID;
            target.InterfacePanelCategoryID = source.InterfacePanelCategoryID;
            target.InterfacePanelSubCategoryID = source.InterfacePanelSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentIPID = source.ParentIPID;
            target.ParentIPVersionNumber = source.ParentIPVersionNumber;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGridPanel = source.IsGridPanel;
            target.IsGlobal = source.IsGlobal;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.InterfacePanelLabel = source.InterfacePanelLabel;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelClaims = source.InterfacePanelClaims.ToDtosWithRelated(level - 1);
              target.InterfacePanelFieldDetailOrganisationTypes = source.InterfacePanelFieldDetailOrganisationTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelOrganisationTypes = source.InterfacePanelOrganisationTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelFDOrganaisationTypeUserTypes = source.InterfacePanelFDOrganaisationTypeUserTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelOrganisationTypeUserTypes = source.InterfacePanelOrganisationTypeUserTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelFieldDetails = source.InterfacePanelFieldDetails.ToDtosWithRelated(level - 1);
              target.InterfacePanels_ParentIPID_ParentIPVersionNumber = source.InterfacePanels_ParentIPID_ParentIPVersionNumber.ToDtosWithRelated(level - 1);
              target.InterfacePanel_ParentIPID_ParentIPVersionNumber = source.InterfacePanel_ParentIPID_ParentIPVersionNumber.ToDtoWithRelated(level - 1);
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
              target.InterfacePanelRoles = source.InterfacePanelRoles.ToDtosWithRelated(level - 1);
              target.InterfacePanelSettings = source.InterfacePanelSettings.ToDtosWithRelated(level - 1);
              target.InterfacePanelValidations = source.InterfacePanelValidations.ToDtosWithRelated(level - 1);
              target.InterfacePanelValidationOrganisationTypes = source.InterfacePanelValidationOrganisationTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelValidationOrganisationTypeUserTypes = source.InterfacePanelValidationOrganisationTypeUserTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelFieldDetailValidations = source.InterfacePanelFieldDetailValidations.ToDtosWithRelated(level - 1);
              target.InterfacePanelFieldDetailValidationOrganisationTypes = source.InterfacePanelFieldDetailValidationOrganisationTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelFDValidationOrganisationTypeUserTypes = source.InterfacePanelFDValidationOrganisationTypeUserTypes.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanel ToEntity(this InterfacePanelDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanel();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InterfacePanelTypeID = source.InterfacePanelTypeID;
            target.InterfacePanelSubTypeID = source.InterfacePanelSubTypeID;
            target.InterfacePanelCategoryID = source.InterfacePanelCategoryID;
            target.InterfacePanelSubCategoryID = source.InterfacePanelSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentIPID = source.ParentIPID;
            target.ParentIPVersionNumber = source.ParentIPVersionNumber;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGridPanel = source.IsGridPanel;
            target.IsGlobal = source.IsGlobal;
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.InterfacePanelLabel = source.InterfacePanelLabel;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanel> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanel> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanel> ToEntities(this IEnumerable<InterfacePanelDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanel source, InterfacePanelDTO target);

        static partial void OnEntityCreating(InterfacePanelDTO source, Bec.TargetFramework.Data.InterfacePanel target);

    }

}
