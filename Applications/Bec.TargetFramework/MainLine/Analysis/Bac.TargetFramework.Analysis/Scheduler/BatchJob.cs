using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis
{
    public class BatchJob : IJob
    {
        public virtual void Execute(IJobExecutionContext context)
        {
            var processor = new Processor();
            processor.Process();
        }
    }
}
