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

    public static partial class TransactionOrderPaymentConverter
    {

        public static TransactionOrderPaymentDTO ToDto(this Bec.TargetFramework.Data.TransactionOrderPayment source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TransactionOrderPaymentDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TransactionOrderPayment source, int level)
        {
            if (source == null)
              return null;

            var target = new TransactionOrderPaymentDTO();

            // Properties
            target.TransactionOrderPaymentID = source.TransactionOrderPaymentID;
            target.IsPaymentSuccessful = source.IsPaymentSuccessful;
            target.PaymentDate = source.PaymentDate;
            target.ResponseData = source.ResponseData;
            target.TransactionResult = source.TransactionResult;
            target.PaymentType = source.PaymentType;
            target.CardBrand = source.CardBrand;
            target.ApprovalCode = source.ApprovalCode;
            target.AVSResponseCode = source.AVSResponseCode;
            target.ProcessorResponseCode = source.ProcessorResponseCode;
            target.ProcessorApprovalCode = source.ProcessorApprovalCode;
            target.ProcessorReceiptCode = source.ProcessorReceiptCode;
            target.ProcessorCCVResponse = source.ProcessorCCVResponse;
            target.ProcessorReferenceNumber = source.ProcessorReferenceNumber;
            target.CommercialServiceProvider = source.CommercialServiceProvider;
            target.ErrorMessage = source.ErrorMessage;
            target.CCVCode = source.CCVCode;

            // Navigation Properties
            if (level > 0) {
              target.TransactionOrderPaymentErrors = source.TransactionOrderPaymentErrors.ToDtosWithRelated(level - 1);
              target.TransactionOrderProcessLogs = source.TransactionOrderProcessLogs.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TransactionOrderPayment ToEntity(this TransactionOrderPaymentDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TransactionOrderPayment();

            // Properties
            target.TransactionOrderPaymentID = source.TransactionOrderPaymentID;
            target.IsPaymentSuccessful = source.IsPaymentSuccessful;
            target.PaymentDate = source.PaymentDate;
            target.ResponseData = source.ResponseData;
            target.TransactionResult = source.TransactionResult;
            target.PaymentType = source.PaymentType;
            target.CardBrand = source.CardBrand;
            target.ApprovalCode = source.ApprovalCode;
            target.AVSResponseCode = source.AVSResponseCode;
            target.ProcessorResponseCode = source.ProcessorResponseCode;
            target.ProcessorApprovalCode = source.ProcessorApprovalCode;
            target.ProcessorReceiptCode = source.ProcessorReceiptCode;
            target.ProcessorCCVResponse = source.ProcessorCCVResponse;
            target.ProcessorReferenceNumber = source.ProcessorReferenceNumber;
            target.CommercialServiceProvider = source.CommercialServiceProvider;
            target.ErrorMessage = source.ErrorMessage;
            target.CCVCode = source.CCVCode;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TransactionOrderPaymentDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TransactionOrderPayment> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TransactionOrderPaymentDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TransactionOrderPayment> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TransactionOrderPayment> ToEntities(this IEnumerable<TransactionOrderPaymentDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TransactionOrderPayment source, TransactionOrderPaymentDTO target);

        static partial void OnEntityCreating(TransactionOrderPaymentDTO source, Bec.TargetFramework.Data.TransactionOrderPayment target);

    }

}
