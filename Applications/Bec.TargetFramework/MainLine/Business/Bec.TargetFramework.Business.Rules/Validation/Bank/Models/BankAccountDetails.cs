﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Business.Rules.Validation.Bank
{
    class BankAccountDetails
    {
        public static readonly int[] AisNotZeroAndGisNotNineWeights = new[] { 0, 0, 1, 2, 5, 3, 6, 4, 8, 7, 10, 9, 3, 1 };
        public static readonly int[] AisNotZeroAndGisNineWeights = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 8, 7, 10, 9, 3, 1 };

        private IEnumerable<IModulusWeightMapping> _weightMappings;
        public SortCode SortCode { get; set; }
        public AccountNumber AccountNumber { get; private set; }
        public bool FirstResult { get; set; }
        public bool SecondResult { get; set; }

        public IEnumerable<IModulusWeightMapping> WeightMappings
        {
            get { return _weightMappings; }
            set
            {
                if (value.Count() > 2)
                {
                    throw new InvalidOperationException(string.Format("a given bank details pair should have zero, one or two mappings. not {0}",value.Count()));
                }
                _weightMappings = value;
                if (!_weightMappings.Any()) return;
                ExceptionSevenPreprocessing();
                ExceptionEightPreProcessing();
                ExceptionTenPreProcessing();
            }
        }

        private static string PrepareString(string value)
        {
            return value.Replace(" ", "").Replace("-", "");
        }

        public BankAccountDetails(string sortCode, string accountNumber)
        {
            accountNumber = PrepareString(accountNumber);
            sortCode = PrepareString(sortCode);

            switch (accountNumber.Length)
            {
                case 9:
                    var chars = sortCode.ToCharArray();
                    chars[5] = accountNumber[0];
                    sortCode = new string(chars);
                    accountNumber = accountNumber.Substring(1);
                    break;
                case 10:
                    if (IsCooperativeBankSortCode(sortCode))
                    {
                        accountNumber = accountNumber.Substring(0, 8);
                    }
                    else if (IsNatWestSortCode(sortCode))
                    {
                        accountNumber = accountNumber.Substring(2);
                    } else
                    {
                        throw new ArgumentException(string.Format("Ten Digit Account Numbers can only come from Natwest or Coop sortcodes. {0} does not appear to be either",sortCode));
                    }
                    break;
            }
        
            SortCode = new SortCode(sortCode);
            AccountNumber = new AccountNumber(accountNumber);
        }

        public bool IsValidForModulusCheck()
        {
            if (WeightMappings.Any())
            {
                return true;
            }
            FirstResult = true;
            return false;
        }

        private static bool IsCooperativeBankSortCode(string sortCode)
        {
            return sortCode.StartsWith("08")||sortCode.StartsWith("839");
        }

        private static bool IsNatWestSortCode(string sortCode)
        {
            return sortCode.StartsWith("600") 
                || sortCode.StartsWith("606")
                || sortCode.StartsWith("601")
                || sortCode.StartsWith("609")
                || sortCode.StartsWith("830")
                || sortCode.StartsWith("602");
        }

        public bool IsUncheckableForeignAccount()
        {
            if (WeightMappings.Any())
            {
                if (WeightMappings.First().Exception == 6 && AccountNumber.IsForeignCurrencyAccount)
                {
                    FirstResult = true;
                    return true;
                }
                return false;
            }
            throw new InvalidOperationException("If there are no weight mappings the system should not reach this check");
        }

        public String ToCombinedString()
        {
            return SortCode.ToString() + AccountNumber;
        }

        public override string ToString()
        {
            return string.Format("sc: {0} | an: {1}", SortCode, AccountNumber);
        }

        public bool IsSecondCheckRequired()
        {
            if (FirstResult)
            {
                return !(WeightMappings.Count() == 1 ||
                       new List<int> {2, 9, 10, 11, 12, 13, 14}.Contains(WeightMappings.First().Exception));
            }
            return new List<int> {2, 9, 10, 11, 12, 13, 14}.Contains(WeightMappings.First().Exception);
        }


        private void ExceptionSevenPreprocessing()
        {
            if (WeightMappings.First().Exception != 7) return;
            if (AccountNumber.IntegerAt(6) != 9) return;
            ZeroiseUtoB(WeightMappings.First());
        }

        private void ExceptionEightPreProcessing()
        {
            if (WeightMappings.First().Exception == 8)
            {
                SortCode = new SortCode("090126");
            }
        }

        private void ExceptionTenPreProcessing()
        {
            if (WeightMappings.First().Exception == 10 && AccountNumber.ExceptionTenShouldZeroiseWeights)
            {
                ZeroiseUtoB(WeightMappings.First());
            }
        }

        private static void ZeroiseUtoB(IModulusWeightMapping weightMapping)
        {
            for (var i = 0; i < 8; i++)
            {
                weightMapping.WeightValues[i] = 0;
            }
        }

        public bool RequiresCouttsAccountCheck()
        {
            if (WeightMappings.Any())
            {
                return WeightMappings.First().Exception == 14;
            }
            throw new ArgumentException("If there are no weight mappings the system should not reach this check");
        }

        public bool IsExceptionThreeAndCanSkipSecondCheck()
        {
            return WeightMappings.Second()
                                 .Exception == 3
                   && (AccountNumber.IntegerAt(2) == 6
                       || AccountNumber.IntegerAt(2) == 9);
        }

        public int[] GetExceptionTwoAlternativeWeights(int[] originalWeights)
        {
            if (AccountNumber.IntegerAt(0) != 0)
            {
                return AccountNumber.IntegerAt(6) == 9
                                              ? AisNotZeroAndGisNineWeights
                                              : AisNotZeroAndGisNotNineWeights;
            }
            return originalWeights;
        }

        public bool IsExceptionTwoAndFirstCheckPassed()
        {
            return FirstResult && WeightMappings.First().Exception == 2;
        }
    }
}
