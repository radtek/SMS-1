using System;
using Bec.TargetFramework.Infrastructure.IOC;
using Quartz;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Base;
using Autofac;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Client.Clients;
using Bec.TargetFramework.Business.Client.Interfaces;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{

    public class ExpireOrganisationsScheduledTask : BaseBusTask
    {
        IOrganisationLogicClient m_OrgLogic;
        public ExpireOrganisationsScheduledTask()
            : base (
                IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<ILogger>(),
                IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<IBusTaskLogicClient>()
            )
        {
            m_OrgLogic = IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<IOrganisationLogicClient>();
        }

        public override void ExecuteTask(IJobExecutionContext context)
        {
            m_OrgLogic.ExpireOrganisations();
        }
    }
}
