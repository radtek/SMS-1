using System;
using System.Linq;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;

    [Trace(TraceExceptionsOnly = true)]
    public class UserAccountAuditLogic : LogicBase
    {
        public UserAccountAuditLogic(ILogger logger, ICacheProvider cacheProvider) : base(logger, cacheProvider)
        {
        }

        public void CreateAndSaveAudit(WebUserObject wuo, string requestData)
        {
            var dto = new ContactDTO();
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
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

                scope.DbContext.UserAccountAudits.Add(audit);
                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
            }
        }
    }
}
