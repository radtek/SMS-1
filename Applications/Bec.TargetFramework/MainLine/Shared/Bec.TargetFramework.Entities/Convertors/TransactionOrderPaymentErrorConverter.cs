﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class TransactionOrderPaymentErrorConverter
    {

        public static TransactionOrderPaymentErrorDTO ToDto(this Bec.TargetFramework.Data.TransactionOrderPaymentError source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TransactionOrderPaymentErrorDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TransactionOrderPaymentError source, int level)
        {
            if (source == null)
              return null;

            var target = new TransactionOrderPaymentErrorDTO();

            // Properties
            target.TransactionOrderPaymentErrorID = source.TransactionOrderPaymentErrorID;
            target.TransactionOrderPaymentID = source.TransactionOrderPaymentID;
            target.IsMerchantError = source.IsMerchantError;
            target.IsCardIssuerError = source.IsCardIssuerError;
            target.IsProcessorError = source.IsProcessorError;
            target.CreatedOn = source.CreatedOn;
            target.ErrorMessage = source.ErrorMessage;
            target.ErrorCode = source.ErrorCode;
            target.ErrorDetail = source.ErrorDetail;

            // Navigation Properties
            if (level > 0) {
              target.TransactionOrderPayment = source.TransactionOrderPayment.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TransactionOrderPaymentError ToEntity(this TransactionOrderPaymentErrorDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TransactionOrderPaymentError();

            // Properties
            target.TransactionOrderPaymentErrorID = source.TransactionOrderPaymentErrorID;
            target.TransactionOrderPaymentID = source.TransactionOrderPaymentID;
            target.IsMerchantError = source.IsMerchantError;
            target.IsCardIssuerError = source.IsCardIssuerError;
            target.IsProcessorError = source.IsProcessorError;
            target.CreatedOn = source.CreatedOn;
            target.ErrorMessage = source.ErrorMessage;
            target.ErrorCode = source.ErrorCode;
            target.ErrorDetail = source.ErrorDetail;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TransactionOrderPaymentErrorDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TransactionOrderPaymentError> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TransactionOrderPaymentErrorDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TransactionOrderPaymentError> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TransactionOrderPaymentError> ToEntities(this IEnumerable<TransactionOrderPaymentErrorDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TransactionOrderPaymentError source, TransactionOrderPaymentErrorDTO target);

        static partial void OnEntityCreating(TransactionOrderPaymentErrorDTO source, Bec.TargetFramework.Data.TransactionOrderPaymentError target);

    }

}
