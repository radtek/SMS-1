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

    public static partial class VSafeSendRecipientConverter
    {

        public static VSafeSendRecipientDTO ToDto(this Bec.TargetFramework.Data.VSafeSendRecipient source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VSafeSendRecipientDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VSafeSendRecipient source, int level)
        {
            if (source == null)
              return null;

            var target = new VSafeSendRecipientDTO();

            // Properties
            target.SmsTransactionID = source.SmsTransactionID;
            target.RelatedID = source.RelatedID;
            target.OrganisationID = source.OrganisationID;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.IsSafeSendGroup = source.IsSafeSendGroup;
            target.OrganisationName = source.OrganisationName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VSafeSendRecipient ToEntity(this VSafeSendRecipientDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VSafeSendRecipient();

            // Properties
            target.SmsTransactionID = source.SmsTransactionID;
            target.RelatedID = source.RelatedID;
            target.OrganisationID = source.OrganisationID;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.IsSafeSendGroup = source.IsSafeSendGroup;
            target.OrganisationName = source.OrganisationName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VSafeSendRecipientDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VSafeSendRecipient> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VSafeSendRecipientDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VSafeSendRecipient> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VSafeSendRecipient> ToEntities(this IEnumerable<VSafeSendRecipientDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VSafeSendRecipient source, VSafeSendRecipientDTO target);

        static partial void OnEntityCreating(VSafeSendRecipientDTO source, Bec.TargetFramework.Data.VSafeSendRecipient target);

    }

}
