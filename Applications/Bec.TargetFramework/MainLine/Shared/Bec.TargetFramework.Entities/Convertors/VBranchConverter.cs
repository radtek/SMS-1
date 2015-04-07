﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VBranchConverter
    {

        public static VBranchDTO ToDto(this Bec.TargetFramework.Data.VBranch source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VBranchDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VBranch source, int level)
        {
            if (source == null)
              return null;

            var target = new VBranchDTO();

            // Properties
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.BranchOrganisationID = source.BranchOrganisationID;
            target.IsHeadOffice = source.IsHeadOffice;
            target.ContactID = source.ContactID;
            target.BranchName = source.BranchName;
            target.ContactName = source.ContactName;
            target.EmailAddress1 = source.EmailAddress1;
            target.Telephone1 = source.Telephone1;
            target.IsPrimaryContact = source.IsPrimaryContact;
            target.IsDeleted = source.IsDeleted;
            target.Telephone2 = source.Telephone2;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.EmailAddress2 = source.EmailAddress2;
            target.WebSiteURL = source.WebSiteURL;
            target.ContactCategoryID = source.ContactCategoryID;
            target.ContactTypeID = source.ContactTypeID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VBranch ToEntity(this VBranchDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VBranch();

            // Properties
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.BranchOrganisationID = source.BranchOrganisationID;
            target.IsHeadOffice = source.IsHeadOffice;
            target.ContactID = source.ContactID;
            target.BranchName = source.BranchName;
            target.ContactName = source.ContactName;
            target.EmailAddress1 = source.EmailAddress1;
            target.Telephone1 = source.Telephone1;
            target.IsPrimaryContact = source.IsPrimaryContact;
            target.IsDeleted = source.IsDeleted;
            target.Telephone2 = source.Telephone2;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.EmailAddress2 = source.EmailAddress2;
            target.WebSiteURL = source.WebSiteURL;
            target.ContactCategoryID = source.ContactCategoryID;
            target.ContactTypeID = source.ContactTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VBranchDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VBranch> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VBranchDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VBranch> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VBranch> ToEntities(this IEnumerable<VBranchDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VBranch source, VBranchDTO target);

        static partial void OnEntityCreating(VBranchDTO source, Bec.TargetFramework.Data.VBranch target);

    }

}
