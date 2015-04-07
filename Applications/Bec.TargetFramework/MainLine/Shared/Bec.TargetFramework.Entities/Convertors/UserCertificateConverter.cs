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

    public static partial class UserCertificateConverter
    {

        public static UserCertificateDTO ToDto(this Bec.TargetFramework.Data.UserCertificate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserCertificateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserCertificate source, int level)
        {
            if (source == null)
              return null;

            var target = new UserCertificateDTO();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.Thumbprint = source.Thumbprint;
            target.Subject = source.Subject;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserCertificate ToEntity(this UserCertificateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserCertificate();

            // Properties
            target.UserAccountID = source.UserAccountID;
            target.Thumbprint = source.Thumbprint;
            target.Subject = source.Subject;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserCertificateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserCertificate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserCertificateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserCertificate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserCertificate> ToEntities(this IEnumerable<UserCertificateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserCertificate source, UserCertificateDTO target);

        static partial void OnEntityCreating(UserCertificateDTO source, Bec.TargetFramework.Data.UserCertificate target);

    }

}
