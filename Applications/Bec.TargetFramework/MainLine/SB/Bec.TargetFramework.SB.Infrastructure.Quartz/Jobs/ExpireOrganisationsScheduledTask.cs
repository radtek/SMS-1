using Autofac;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Base;
using Quartz;

namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{
    public class ExpireOrganisationsScheduledTask : BaseBusTask
    {
        private readonly IOrganisationLogicClient _orgLogic;

        public ExpireOrganisationsScheduledTask(ILifetimeScope container, ILogger logger, IBusTaskLogicClient taskClient, IEventPublishLogicClient eventClient, IOrganisationLogicClient orgClient)
            : base(container,logger,taskClient,eventClient)
        {
            _orgLogic = orgClient;
        }

        public override void ExecuteTask(IJobExecutionContext context)
        {
            _orgLogic.ExpireTemporaryLogins(28, 0, 0);
        }
    }
}
