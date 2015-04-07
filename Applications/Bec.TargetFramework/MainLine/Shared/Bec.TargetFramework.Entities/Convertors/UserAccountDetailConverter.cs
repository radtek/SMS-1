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

    public static partial class UserAccountDetailConverter
    {

        public static UserAccountDetailDTO ToDto(this Bec.TargetFramework.Data.UserAccountDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountDetailDTO();

            // Properties
            target.UserDetailID = source.UserDetailID;
            target.UserID = source.UserID;
            target.Salutation = source.Salutation;
            target.FirstName = source.FirstName;
            target.MiddleName = source.MiddleName;
            target.LastName = source.LastName;
            target.Title = source.Title;
            target.HomePhone = source.HomePhone;
            target.HomeMobile = source.HomeMobile;
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

        public static Bec.TargetFramework.Data.UserAccountDetail ToEntity(this UserAccountDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountDetail();

            // Properties
            target.UserDetailID = source.UserDetailID;
            target.UserID = source.UserID;
            target.Salutation = source.Salutation;
            target.FirstName = source.FirstName;
            target.MiddleName = source.MiddleName;
            target.LastName = source.LastName;
            target.Title = source.Title;
            target.HomePhone = source.HomePhone;
            target.HomeMobile = source.HomeMobile;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountDetail> ToEntities(this IEnumerable<UserAccountDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountDetail source, UserAccountDetailDTO target);

        static partial void OnEntityCreating(UserAccountDetailDTO source, Bec.TargetFramework.Data.UserAccountDetail target);

    }

}
