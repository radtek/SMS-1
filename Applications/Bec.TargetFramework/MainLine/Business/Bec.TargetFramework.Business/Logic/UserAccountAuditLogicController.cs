﻿using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class UserAccountAuditLogicController : LogicBase
    {
        public UserAccountAuditLogicController()
        {
        }

        public async Task CreateAndSaveAudit(WebUserObject wuo, string requestData)
        {
            var dto = new ContactDTO();
            using (var scope = DbContextScopeFactory.Create())
            {
                //Generate an audit
                UserAccountAudit audit = new UserAccountAudit()
                {
                    UserSessionID = wuo.SessionIdentifier,
                    AuditID = Guid.NewGuid(),
                    UserIPAddress = wuo.IPAddress,
                    URLAccessed = wuo.URLAccessed,
                    TimeAccessed = DateTime.UtcNow,
                    UserAccountID = wuo.UserID,
                    Data = requestData
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountAudits.Add(audit);
                await scope.SaveChangesAsync();
            }
        }
    }
}
