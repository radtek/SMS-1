    using Bec.TargetFramework.Analysis.Interfaces;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;

namespace Bec.TargetFramework.Analysis
{
    public class BatchScheduler : IDisposable, IBatchScheduler
    {
        protected IScheduler m_Sched;
        protected IJobDetail m_Job;
        protected ITrigger m_Trigger;

        public const string GROUP = "myGroup";
        public const string JOB = "myJob";

        public BatchScheduler() : this (null, null)
        {
        }

        public BatchScheduler(IJobDetail job, ITrigger trigger)
        {
            if (job == null)
                m_Job = JobBuilder.Create<BatchJob>()
                .WithIdentity(JOB, GROUP)
                .Build();
            else
                m_Job = job;

            if (trigger == null)
                m_Trigger = TriggerBuilder.Create()
                  .WithIdentity("myTrigger", GROUP)
                  .StartNow()
                  .WithSchedule(CronScheduleBuilder.AtHourAndMinuteOnGivenDaysOfWeek(0, 0,
                    new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday }))
                  .Build();
            else
                m_Trigger = trigger;
        }

        public virtual void Start()
        {
            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            m_Sched = schedFact.GetScheduler();
            m_Sched.Start();

            m_Sched.ScheduleJob(m_Job, m_Trigger);
        }

        public virtual DateTime GetNextTriggerDate()
        {
            return GetNextTriggerDate(m_Sched, JOB, GROUP);
        }

        private DateTime GetNextTriggerDate(IScheduler scheduler, string jobName, string groupName = "")
        {
            JobKey jobKey = new JobKey(jobName, groupName);
            DateTime nextFireTime = DateTime.MinValue;

            bool isJobExisting = scheduler.CheckExists(jobKey);
            if (isJobExisting)
            {
                var triggers = scheduler.GetTriggersOfJob(jobKey);

                if (triggers.Count > 0)
                {
                    var nextFireTimeUtc = triggers[0].GetNextFireTimeUtc();
                    nextFireTime = TimeZone.CurrentTimeZone.ToLocalTime(nextFireTimeUtc.Value.DateTime);
                }
            }

            return (nextFireTime);
        }

        public virtual void Dispose()
        {
            m_Trigger = null;
            m_Job = null;

            if (m_Sched != null && m_Sched.IsStarted)
                m_Sched.Shutdown();

            m_Sched = null;
        }
    }
}
