using Bec.TargetFramework.Data;
using EnsureThat;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public static class DeductionHelper
    {
        public static IQueryable<OrganisationDiscount> GetOrganisationCheckoutDiscounts(IDbContextReadOnlyScope scope, Guid organisationID)
        {
            Ensure.That(organisationID).IsNot(Guid.Empty);

            return scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationDiscounts.Where(item => 
                item.OrganisationID == organisationID &&
                item.Discount.IsCheckoutDiscount &&
                item.Discount.ValidTill.HasValue && 
                item.Discount.ValidTill >= DateTime.Now);
        }

        public static IQueryable<CountryDeduction> GetCountryDeductions(IDbContextReadOnlyScope scope, string countryCode)
        {
            Ensure.That(countryCode).IsNotNullOrEmpty();

            return scope.DbContexts.Get<TargetFrameworkEntities>().CountryDeductions.Where(item =>
                item.IsActive &&
                !item.IsDeleted &&
                item.CountryCode == countryCode);
        }
    }
}
