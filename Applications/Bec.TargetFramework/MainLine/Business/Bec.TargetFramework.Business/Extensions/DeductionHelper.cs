﻿using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public static class DeductionHelper
    {
        public static IQueryable<OrganisationDiscount> GetOrganisationCheckoutDiscounts(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID)
        {
            Ensure.That(organisationID).IsNot(Guid.Empty);

            return scope.DbContext.OrganisationDiscounts.Where(item => 
                item.OrganisationID == organisationID &&
                item.Discount.IsCheckoutDiscount &&
                item.Discount.ValidTill.HasValue && 
                item.Discount.ValidTill >= DateTime.Now);
        }

        public static IQueryable<CountryDeduction> GetCountryDeductions(UnitOfWorkScope<TargetFrameworkEntities> scope, string countryCode)
        {
            Ensure.That(countryCode).IsNotNullOrEmpty();

            return scope.DbContext.CountryDeductions.Where(item =>
                item.IsActive &&
                !item.IsDeleted &&
                item.CountryCode == countryCode);
        }
    }
}
