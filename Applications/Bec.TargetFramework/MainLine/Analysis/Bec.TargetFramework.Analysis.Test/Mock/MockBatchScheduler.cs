using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Analysis.Test.Mock;
using Quartz;
using Quartz.Impl.Matchers;

namespace Bec.TargetFramework.Analysis.Test
{
    public class MockBatchScheduler : BatchScheduler, IDisposable
    {
        private IJobListener m_JobListener;

        public MockBatchScheduler()
            : this(null, null)
        {
        }

        public MockBatchScheduler(IJobDetail job, ITrigger trigger)
            : base(job, trigger)
        {
            m_JobListener = new MockJobListener();
        }

        public override void Start()
        {
            base.Start();

            if (m_JobListener != null)
                m_Sched.ListenerManager.AddJobListener(m_JobListener, KeyMatcher<JobKey>.KeyEquals(new JobKey(JOB, GROUP)));
        }

        public int JobsCounted
        {
            get { return ((MockJobListener)m_JobListener).JobsCounted; }
        }

        public override void Dispose()
        {
            base.Dispose();
            m_JobListener = null;
        }
    }
}
