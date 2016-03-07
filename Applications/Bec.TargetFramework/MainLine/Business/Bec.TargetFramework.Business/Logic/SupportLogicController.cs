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
    public class SupportLogicController : LogicBase
    {
        public UserLogicController UserLogic { get; set; }
        public NotificationLogicController NotificationLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }
        public async Task<Guid> CreateSupportItem(SupportItemDTO supportItemDto, Guid OrgId)
        {
            Ensure.That(supportItemDto).IsNotNull();
            supportItemDto.SupportItemID = Guid.NewGuid();
            using (var scope = DbContextScopeFactory.Create())
            {
                var supportItems = scope.DbContexts.Get<TargetFrameworkEntities>().SupportItems;
                var highestTicketNumber = supportItems.Any() ? supportItems.Max(x => x.TicketNumber) : 0;
                supportItemDto.TicketNumber = highestTicketNumber + 1;
                SupportItem supportItem = supportItemDto.ToEntity();
                supportItems.Add(supportItem);
                scope.SaveChanges();
            }
            var supportAdministratorRoleName = OrganisationRoleName.SupportAdministrator.GetStringValue();
            var roles = await UserLogic.GetRoles(supportAdministratorRoleName);
            var recipientUaoIds = new List<Guid>() { };
            if (roles != null && roles.Any())
            {
                roles = roles.GroupBy(elem => elem.UserAccountOrganisationID).Select(group => group.First()).ToList();
                roles.ForEach(x=> recipientUaoIds.Add(x.UserAccountOrganisationID));
            }
            await NotificationLogic.CreateConversation(OrgId, supportItemDto.UserAccountOrganisationID, Guid.Empty, ActivityType.SupportMessage, supportItemDto.SupportItemID, supportItemDto.Title, supportItemDto.Description, recipientUaoIds.ToArray());
            return supportItemDto.SupportItemID;
        }
    }
}


