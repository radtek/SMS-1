using Bec.TargetFramework.Analysis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Infrastructure
{
    public static class BatchExtensions
    {
        public static bool IsLenderValid(this SearchDetail search)
        {
            if (string.IsNullOrEmpty(search.Lender))
                return false;

            return search.Lender.ToUpper() == "PARAGON" || search.Lender.ToUpper() == "SANTANDER";
        }

        public static bool IsDomainValid(this SearchDetail search)
        {
            if (string.IsNullOrEmpty(search.Domain))
                return false;

            return search.Domain.ToUpper() == "PARA";
        }

        public static bool HasPartyType(this SearchDetail search, PartyTypeEnum partyType)
        {
            if (search.Parties == null)
                return false;

            return search.Parties.Any(p => p.Detail.PartyType == partyType);
        }

        public static bool HasBuyerName(this SearchDetail search)
        {
            if (search.Parties == null)
                return false;

            var buyers = search.Parties.Where(p => p.Detail.PartyType == PartyTypeEnum.BUY);

            if (buyers.Any(p => p.Detail.Name == null))
                return false;

            if (buyers.Any(
                p => string.IsNullOrEmpty(p.Detail.Name.FirstName) &&
                string.IsNullOrEmpty(p.Detail.Name.MiddleName) &&
                string.IsNullOrEmpty(p.Detail.Name.LastName)))
                return false;

            return true;
        }

        public static bool HasBuyerAddress(this SearchDetail search)
        {
            if (search.Parties == null)
                return false;

            var buyers = search.Parties.Where(p => p.Detail.PartyType == PartyTypeEnum.BUY);

            if (buyers.Any(p => p.Detail.Address == null))
                return false;

            if (buyers.Any(p => !p.Detail.Address.IsSupplied()))
                return false;

            return true;
        }

        public static bool IsSupplied(this AddressDetail address)
        {
            if (string.IsNullOrEmpty(address.BuildingName) &&
                string.IsNullOrEmpty(address.Line1) &&
                string.IsNullOrEmpty(address.Line2) &&
                string.IsNullOrEmpty(address.CountryCode) &&
                string.IsNullOrEmpty(address.County) &&
                string.IsNullOrEmpty(address.PostCode) &&
                string.IsNullOrEmpty(address.TownCity))
                return false;

            return true;
        }

        public static bool HasAddress(this TransactionDetail transaction)
        {
            if (transaction.Address == null)
                return false;

            return transaction.Address.IsSupplied();
        }
    }
}
