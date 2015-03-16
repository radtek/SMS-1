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

    public static partial class StsSearchActorDetailDepositConverter
    {

        public static StsSearchActorDetailDepositDTO ToDto(this Bec.TargetFramework.Data.StsSearchActorDetailDeposit source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchActorDetailDepositDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearchActorDetailDeposit source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchActorDetailDepositDTO();

            // Properties
            target.StsSearchActorDetailDeposit1 = source.StsSearchActorDetailDeposit1;
            target.StsSearchSecondaryActorDetailID = source.StsSearchSecondaryActorDetailID;
            target.DepositAmount = source.DepositAmount;
            target.DepositFromTypeID = source.DepositFromTypeID;
            target.DoesDepositGiftorRetainChargeOverProperty = source.DoesDepositGiftorRetainChargeOverProperty;
            target.DepositGiftorContactID = source.DepositGiftorContactID;
            target.LoanProvider = source.LoanProvider;
            target.LoanInterestRate = source.LoanInterestRate;
            target.LoanFinalRepaymentDate = source.LoanFinalRepaymentDate;
            target.LoanMonthlyRepaymentAmount = source.LoanMonthlyRepaymentAmount;
            target.LoanCurrentBalance = source.LoanCurrentBalance;

            // Navigation Properties
            if (level > 0) {
              target.StsSearchActorDetail = source.StsSearchActorDetail.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearchActorDetailDeposit ToEntity(this StsSearchActorDetailDepositDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearchActorDetailDeposit();

            // Properties
            target.StsSearchActorDetailDeposit1 = source.StsSearchActorDetailDeposit1;
            target.StsSearchSecondaryActorDetailID = source.StsSearchSecondaryActorDetailID;
            target.DepositAmount = source.DepositAmount;
            target.DepositFromTypeID = source.DepositFromTypeID;
            target.DoesDepositGiftorRetainChargeOverProperty = source.DoesDepositGiftorRetainChargeOverProperty;
            target.DepositGiftorContactID = source.DepositGiftorContactID;
            target.LoanProvider = source.LoanProvider;
            target.LoanInterestRate = source.LoanInterestRate;
            target.LoanFinalRepaymentDate = source.LoanFinalRepaymentDate;
            target.LoanMonthlyRepaymentAmount = source.LoanMonthlyRepaymentAmount;
            target.LoanCurrentBalance = source.LoanCurrentBalance;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchActorDetailDepositDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearchActorDetailDeposit> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchActorDetailDepositDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearchActorDetailDeposit> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearchActorDetailDeposit> ToEntities(this IEnumerable<StsSearchActorDetailDepositDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearchActorDetailDeposit source, StsSearchActorDetailDepositDTO target);

        static partial void OnEntityCreating(StsSearchActorDetailDepositDTO source, Bec.TargetFramework.Data.StsSearchActorDetailDeposit target);

    }

}
