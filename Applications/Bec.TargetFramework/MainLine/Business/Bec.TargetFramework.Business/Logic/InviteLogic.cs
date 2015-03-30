using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using LinqKit;
using Omu.ValueInjecter;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.Specifications;
using Bec.TargetFramework.Data.Infrastructure.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Entities;
    using System.ServiceModel;
    using EnsureThat;
    using Bec.TargetFramework.Entities.Enums;

   [Trace(TraceExceptionsOnly = true)]
    public class InviteLogic : LogicBase, IInviteLogic
    {
       public InviteLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
       {
       }

       public void AddInvite(StsInviteDTO invite)
       {
           Ensure.That(invite).IsNotNull();

           using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
           {
               var stsInviteRepo = scope.GetGenericRepository<StsInvite, Guid>();
               StsInvite inv = StsInviteConverter.ToEntity(invite);
               stsInviteRepo.Add(inv);
               if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
           }
       }

    }
}
