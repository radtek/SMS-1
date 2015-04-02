﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VFieldDetailValidationForUIConverter
    {

        public static VFieldDetailValidationForUIDTO ToDto(this Bec.TargetFramework.Data.VFieldDetailValidationForUI source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VFieldDetailValidationForUIDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VFieldDetailValidationForUI source, int level)
        {
            if (source == null)
              return null;

            var target = new VFieldDetailValidationForUIDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.Name = source.Name;
            target.FieldDetailID = source.FieldDetailID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InterfacePanelFieldDetailValidationName = source.InterfacePanelFieldDetailValidationName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ID = source.ID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VFieldDetailValidationForUI ToEntity(this VFieldDetailValidationForUIDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VFieldDetailValidationForUI();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.Name = source.Name;
            target.FieldDetailID = source.FieldDetailID;
            target.OverrideValidationMessage = source.OverrideValidationMessage;
            target.OverrideValidationMessageHTML = source.OverrideValidationMessageHTML;
            target.OverrideValidationIsHTML = source.OverrideValidationIsHTML;
            target.ValidationType = source.ValidationType;
            target.ValidationSubType = source.ValidationSubType;
            target.ValidationCategory = source.ValidationCategory;
            target.ValidationSubCategory = source.ValidationSubCategory;
            target.SourceErrorCodes = source.SourceErrorCodes;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InterfacePanelFieldDetailValidationName = source.InterfacePanelFieldDetailValidationName;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ID = source.ID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VFieldDetailValidationForUIDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VFieldDetailValidationForUI> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VFieldDetailValidationForUIDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VFieldDetailValidationForUI> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VFieldDetailValidationForUI> ToEntities(this IEnumerable<VFieldDetailValidationForUIDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VFieldDetailValidationForUI source, VFieldDetailValidationForUIDTO target);

        static partial void OnEntityCreating(VFieldDetailValidationForUIDTO source, Bec.TargetFramework.Data.VFieldDetailValidationForUI target);

    }

}
