using System;
using Bec.TargetFramework.Infrastructure.IOC;
using Quartz;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Base;
using Autofac;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Client.Clients;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{

    public class SampleScheduledTask : BaseBusTask
    {
        public SampleScheduledTask() : base
            (
                IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<ILogger>(),
                IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<IBusTaskLogicClient>()
            )
        {
        }

        public override void ExecuteTask(IJobExecutionContext context)
        {
            m_Logger.Trace("SampleService Executed");
        }
    }
}
