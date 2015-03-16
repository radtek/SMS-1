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

    public static partial class VInterfacePanelForUIConverter
    {

        public static VInterfacePanelForUIDTO ToDto(this Bec.TargetFramework.Data.VInterfacePanelForUI source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VInterfacePanelForUIDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VInterfacePanelForUI source, int level)
        {
            if (source == null)
              return null;

            var target = new VInterfacePanelForUIDTO();

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
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.ParentIPID = source.ParentIPID;
            target.ParentIPVersionNumber = source.ParentIPVersionNumber;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGridPanel = source.IsGridPanel;
            target.IsGlobal = source.IsGlobal;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.InterfacePanelLabel = source.InterfacePanelLabel;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VInterfacePanelForUI ToEntity(this VInterfacePanelForUIDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VInterfacePanelForUI();

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
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.ParentIPID = source.ParentIPID;
            target.ParentIPVersionNumber = source.ParentIPVersionNumber;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGridPanel = source.IsGridPanel;
            target.IsGlobal = source.IsGlobal;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.InterfacePanelLabel = source.InterfacePanelLabel;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VInterfacePanelForUIDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VInterfacePanelForUI> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VInterfacePanelForUIDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VInterfacePanelForUI> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VInterfacePanelForUI> ToEntities(this IEnumerable<VInterfacePanelForUIDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VInterfacePanelForUI source, VInterfacePanelForUIDTO target);

        static partial void OnEntityCreating(VInterfacePanelForUIDTO source, Bec.TargetFramework.Data.VInterfacePanelForUI target);

    }

}
