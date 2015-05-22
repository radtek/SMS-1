using System;
using Quartz;
using Bec.TargetFramework.Infrastructure.Log;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Jobs
{

    public class SampleJob : IJob
    {
        private readonly ILogger m_Logger;

        public SampleJob(ILogger logger)
        {
            m_Logger = logger;
        }

        public void Execute(IJobExecutionContext context)
        {
            m_Logger.Trace("SampleService Executed");
        }
    }
}
