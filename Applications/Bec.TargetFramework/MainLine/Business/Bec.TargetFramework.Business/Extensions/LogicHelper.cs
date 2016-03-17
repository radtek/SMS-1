using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using EnsureThat;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public static class LogicHelper
    {
        public static VStatusType GetStatusType(IDbContextReadOnlyScope scope, string statusTypeEnum, string status)
        {
            Ensure.That(scope).IsNotNull();
            Ensure.That(status).IsNotNullOrEmpty();
            Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

            return scope.DbContexts.Get<TargetFrameworkEntities>().VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));
        }

        public static int GetOrganisationCurrentAccountingPeriod(IDbContextReadOnlyScope scope, Guid organisationID)
        {
            var intCurrentAccountingPeriod = scope.DbContexts.Get<TargetFrameworkEntities>().VGlobalAccountingCurrentPeriods.Single().GlobalAccountingPeriodID;

            return scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationAccountingPeriods.Single(
                    s => s.GlobalAccountingPeriodID.Equals(intCurrentAccountingPeriod) && s.OrganisationID.Equals(organisationID)).OrganisationAccountingPeriodID;
        }

        public static Guid GetGlobalPaymentMethodIDForOnlineTransactions(IDbContextReadOnlyScope scope)
        {
            return scope.DbContexts.Get<TargetFrameworkEntities>().GlobalPaymentMethods.Single(s => s.IsDefaultForOnlinePayments == true)
                    .GlobalPaymentMethodID;
        }

    }
}