using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business
{
    public class LogicHelper
    {
        public static VStatusType GetStatusType(UnitOfWorkScope<TargetFrameworkEntities> scope, string statusTypeEnum, string status)
        {
            Ensure.That(scope).IsNotNull();
            Ensure.That(status).IsNotNullOrEmpty();
            Ensure.That(statusTypeEnum).IsNotNullOrEmpty();

            return scope.DbContext.VStatusTypes.Single(s => s.Name.Equals(status) && s.StatusTypeName.Equals(statusTypeEnum));
        }

        public static int GetOrganisationCurrentAccountingPeriod(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID)
        {
            var intCurrentAccountingPeriod = scope.DbContext.VGlobalAccountingCurrentPeriods.Single().GlobalAccountingPeriodID;

            return scope.DbContext.OrganisationAccountingPeriods.Single(
                    s => s.GlobalAccountingPeriodID.Equals(intCurrentAccountingPeriod) && s.OrganisationID.Equals(organisationID)).OrganisationAccountingPeriodID;
        }

        public static Guid GetGlobalPaymentMethodIDForOnlineTransactions(UnitOfWorkScope<TargetFrameworkEntities> scope)
        {
            return scope.DbContext.GlobalPaymentMethods.Single(s => s.IsDefaultForOnlinePayments == true)
                    .GlobalPaymentMethodID;
        }

    }
}