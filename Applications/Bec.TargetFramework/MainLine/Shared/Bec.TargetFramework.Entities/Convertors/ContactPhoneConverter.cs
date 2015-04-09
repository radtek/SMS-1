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

    public static partial class ContactPhoneConverter
    {

        public static ContactPhoneDTO ToDto(this Bec.TargetFramework.Data.ContactPhone source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ContactPhoneDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ContactPhone source, int level)
        {
            if (source == null)
              return null;

            var target = new ContactPhoneDTO();

            // Properties
            target.ContactPhoneId = source.ContactPhoneId;
            target.ContactID = source.ContactID;
            target.PhoneTypeID = source.PhoneTypeID;
            target.PhoneNumber = source.PhoneNumber;
            target.CountryCode = source.CountryCode;
            target.IsPrimary = source.IsPrimary;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Contact = source.Contact.ToDtoWithRelated(level - 1);
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ContactPhone ToEntity(this ContactPhoneDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ContactPhone();

            // Properties
            target.ContactPhoneId = source.ContactPhoneId;
            target.ContactID = source.ContactID;
            target.PhoneTypeID = source.PhoneTypeID;
            target.PhoneNumber = source.PhoneNumber;
            target.CountryCode = source.CountryCode;
            target.IsPrimary = source.IsPrimary;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ContactPhoneDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ContactPhone> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ContactPhoneDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ContactPhone> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ContactPhone> ToEntities(this IEnumerable<ContactPhoneDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ContactPhone source, ContactPhoneDTO target);

        static partial void OnEntityCreating(ContactPhoneDTO source, Bec.TargetFramework.Data.ContactPhone target);

    }

}
