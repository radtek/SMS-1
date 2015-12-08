using Autofac;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Base;
using Quartz;

namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{
    public class SendUnreadNotificationsEmailScheduledTask : BaseBusTask
    {
        private readonly INotificationLogicClient _notificationLogic;
        public SendUnreadNotificationsEmailScheduledTask(ILifetimeScope container, ILogger logger, IBusTaskLogicClient taskClient, IEventPublishLogicClient eventClient, INotificationLogicClient notificationLogic)
            : base(container, logger, taskClient, eventClient)
        {
            _notificationLogic = notificationLogic;
        }

        public override void ExecuteTask(IJobExecutionContext context)
        {
            var unreads = _notificationLogic.GetUnreadConversationsCountsPerUao();
            foreach (var item in unreads)
            {
                _notificationLogic.PublishNewInternalMessagesNotificationEventAsync(item.UnreadCount.Value, new[] { item.UserAccountOrganisationID });
            }
        }
    }
}
