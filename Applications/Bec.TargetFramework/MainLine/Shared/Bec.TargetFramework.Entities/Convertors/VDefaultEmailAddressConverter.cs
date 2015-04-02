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

    public static partial class VDefaultEmailAddressConverter
    {

        public static VDefaultEmailAddressDTO ToDto(this Bec.TargetFramework.Data.VDefaultEmailAddress source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VDefaultEmailAddressDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VDefaultEmailAddress source, int level)
        {
            if (source == null)
              return null;

            var target = new VDefaultEmailAddressDTO();

            // Properties
            target.UserID = source.UserID;
            target.Username = source.Username;
            target.Email = source.Email;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.BranchOrganisationID = source.BranchOrganisationID;
            target.BranchEmailAddress = source.BranchEmailAddress;
            target.OrganisationID = source.OrganisationID;
            target.EmailAddress1 = source.EmailAddress1;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VDefaultEmailAddress ToEntity(this VDefaultEmailAddressDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VDefaultEmailAddress();

            // Properties
            target.UserID = source.UserID;
            target.Username = source.Username;
            target.Email = source.Email;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.BranchOrganisationID = source.BranchOrganisationID;
            target.BranchEmailAddress = source.BranchEmailAddress;
            target.OrganisationID = source.OrganisationID;
            target.EmailAddress1 = source.EmailAddress1;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VDefaultEmailAddressDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VDefaultEmailAddress> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VDefaultEmailAddressDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VDefaultEmailAddress> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VDefaultEmailAddress> ToEntities(this IEnumerable<VDefaultEmailAddressDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VDefaultEmailAddress source, VDefaultEmailAddressDTO target);

        static partial void OnEntityCreating(VDefaultEmailAddressDTO source, Bec.TargetFramework.Data.VDefaultEmailAddress target);

    }

}
