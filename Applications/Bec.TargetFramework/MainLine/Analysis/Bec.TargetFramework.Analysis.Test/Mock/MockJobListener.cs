using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Test.Mock
{
    public class MockJobListener : IJobListener
    {
        public int JobsCounted { get; set; }

        public MockJobListener()
        {
            JobsCounted = 0;
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            JobsCounted++;
        }

        public string Name
        {
            get { return "MockJobListener"; }
        }
    }
}
