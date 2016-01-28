using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using EnsureThat;
using Mehdime.Entity;
using Omu.ValueInjecter;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class CalloutLogicController : LogicBase
    {
        //public UserLogicController UserLogic { get; set; }
        //public IEventPublishLogicClient EventPublishClient { get; set; }
        //public TFSettingsLogicController Settings { get; set; }

        public async Task CreateCalloutAsync(CalloutDTO calloutDTO)
        {
            Ensure.That(calloutDTO).IsNotNull();
            using (var scope = DbContextScopeFactory.Create())
            {
                Callout callout = calloutDTO.ToEntity();
                //SetAuditFields(contact, true);
                scope.DbContexts.Get<TargetFrameworkEntities>().Callouts.Add(callout);
                await scope.SaveChangesAsync();
            }
        }

        public async Task CreateCalloutUserAccountAsync(CalloutUserAccountDTO calloutUserAccountDTO)
        {
            Ensure.That(calloutUserAccountDTO).IsNotNull();
            using (var scope = DbContextScopeFactory.Create())
            {
                CalloutUserAccount calloutUserAccount = calloutUserAccountDTO.ToEntity();
                //SetAuditFields(contact, true);
                scope.DbContexts.Get<TargetFrameworkEntities>().CalloutUserAccounts.Add(calloutUserAccount);
                await scope.SaveChangesAsync();
            }
        }

    }
}
