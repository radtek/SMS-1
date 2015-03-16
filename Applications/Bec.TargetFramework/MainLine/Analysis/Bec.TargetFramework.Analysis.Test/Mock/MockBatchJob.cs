using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockBatchJob : BatchJob
    {
        public override void Execute(IJobExecutionContext context)
        {
            var processor = new MockProcessor();
            processor.MockApplicationsCount = 1;
            processor.Process();
        }
    }
}
