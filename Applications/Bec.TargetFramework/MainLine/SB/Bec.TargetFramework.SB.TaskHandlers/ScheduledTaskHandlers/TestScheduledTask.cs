using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using Quartz;

namespace Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers
{
    public class TestScheduledTask : IJob
    {
        public TestScheduledTask(ILogger logger, ICacheProvider cacheProvider)
        {
            
        }

        public void Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
