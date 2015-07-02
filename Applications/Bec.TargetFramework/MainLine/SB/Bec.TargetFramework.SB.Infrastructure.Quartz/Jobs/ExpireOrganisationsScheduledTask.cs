using System;
using Bec.TargetFramework.Infrastructure.IOC;
using Quartz;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Base;
using Autofac;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Client.Clients;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.SB.Client.Interfaces;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{

    public class ExpireOrganisationsScheduledTask : BaseBusTask
    {
        public IOrganisationLogicClient m_OrgLogic;

        public ExpireOrganisationsScheduledTask(ILifetimeScope container, ILogger logger, IBusTaskLogicClient taskClient, IEventPublishLogicClient eventClient, IOrganisationLogicClient orgClient)
            : base(container,logger,taskClient,eventClient)
        {
            m_OrgLogic = orgClient;
        }

        public override void ExecuteTask(IJobExecutionContext context)
        {
            m_OrgLogic.ExpireTemporaryLogins(7, 0, 0);
        }
    }
}
