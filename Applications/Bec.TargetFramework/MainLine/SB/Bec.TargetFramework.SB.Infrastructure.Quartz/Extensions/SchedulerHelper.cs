using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.Threading;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Configure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Quartz; 
using QC = Quartz.Collection;
using Quartz.Impl; 
using Quartz.Spi;
using Quartz.Impl.Matchers;
using Bec.TargetFramework.SB.Interfaces;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Extensions
{
    public static class SchedulerHelper
    {
        public static void ScheduleQuartzJob(Action<QuartzConfigurator> jobConfigurator)
        {
            var iocContainer = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);

            var jobConfig = new QuartzConfigurator();

            jobConfigurator(jobConfig);

            if (jobConfig.JobEnabled == null || jobConfig.JobEnabled() || (jobConfig.Job == null || jobConfig.Triggers == null))
            {
                var jobDetail = jobConfig.Job();
                var jobTriggers = jobConfig.Triggers.Select(triggerFactory => triggerFactory()).Where(trigger => trigger != null);

                var scheduler = iocContainer.Resolve<IScheduler>();
                var logger = iocContainer.Resolve<ILogger>();

                if (scheduler != null)
                {
                    if (jobDetail != null && jobTriggers.Any())
                    {
                        var triggersForJob = new QC.HashSet<ITrigger>(jobTriggers);

                        scheduler.ScheduleJob(jobDetail, triggersForJob, false);
                        logger.Trace(string.Format("Scheduled Job: {0}", jobDetail.Key));

                        foreach (var trigger in triggersForJob)
                            logger.Trace(string.Format("Job Schedule: {0} - Next Fire Time (local): {1}", trigger, trigger.GetNextFireTimeUtc().HasValue ? trigger.GetNextFireTimeUtc().Value.ToLocalTime().ToString() : "none"));
                    }
                }
            }
        }

        private static void PurgeScheduledTasks(IScheduler scheduler)
        {
            IList<string> jobGroups = scheduler.GetJobGroupNames();
            IList<string> triggerGroups = scheduler.GetTriggerGroupNames();

            foreach (string group in jobGroups)
            {
                var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
                var jobKeys = scheduler.GetJobKeys(groupMatcher);
                foreach (var jobKey in jobKeys)
                {
                    scheduler.DeleteJob(jobKey);
                }
            }
        }

        public static void InitialiseAndStartScheduler()
        {
            var scheduler = IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<IScheduler>();

            // purge all current jobs
            PurgeScheduledTasks(scheduler);

            var busTaskLogicClient =
                IocProvider.GetIocContainerUsingAppDomainFriendlyName().Resolve<IBusTaskLogicClient>();

            var appName = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
            var appEnvironment = System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"];

            // load dto data
            var busTaskDtos = busTaskLogicClient.AllBusTaskSchedulesByAppNameAndEnv(appName, appEnvironment);

            if (busTaskDtos.Count > 0)
            {
                busTaskDtos.ForEach(item =>
                {
                    var jobKey = new JobKey(item.Name, item.BusTaskGroupName);

                    // if already registered then delete and reschedule
                    if (!scheduler.CheckExists(jobKey))
                        scheduler.DeleteJob(jobKey);

                    ScheduleQuartzJob(q =>
                    {
                        var taskType = System.Type.GetType(item.HandlerMessageTypeName + ", " + item.HandlerMessageTypeAssemblyName);

                        q.WithJob(JobBuilder.Create(taskType)
                        .WithIdentity(jobKey)
                        .RequestRecovery()
                        .Build);

                        var triggerBuilder = TriggerBuilder.Create();

                        if (item.IsCronDriven)
                            triggerBuilder.WithCronSchedule(item.CronScheduleString);
                        else
                        {
                            // build schedule
                            if (!item.IsCalendarDriven && item.RepeatForever)
                                triggerBuilder.WithSchedule(
                                SimpleScheduleBuilder.RepeatSecondlyForever(item.RepeatEveryNumberOfSeconds.GetValueOrDefault(0)));
                            else if (item.IsCalendarDriven && item.RepeatEveryDay)
                                triggerBuilder.WithDailyTimeIntervalSchedule(s =>
                                {
                                    s.OnEveryDay();
                                    s.StartingDailyAt(
                                        new TimeOfDay(item.SpecificDailyStartTimeHour.GetValueOrDefault(12), 1));
                                });
                            else if (item.IsCalendarDriven && !item.RepeatEveryDay && item.RepeatMondayToFriday)
                                triggerBuilder.WithDailyTimeIntervalSchedule(s =>
                                {
                                    s.OnMondayThroughFriday();
                                    s.StartingDailyAt(
                                        new TimeOfDay(item.SpecificDailyStartTimeHour.GetValueOrDefault(12), 1));
                                });
                            else if (item.IsCalendarDriven && !item.RepeatEveryDay && item.RepeatSaturdayAndSunday)
                                triggerBuilder.WithDailyTimeIntervalSchedule(s =>
                                {
                                    s.OnSaturdayAndSunday();
                                    s.StartingDailyAt(
                                        new TimeOfDay(item.SpecificDailyStartTimeHour.GetValueOrDefault(12), 1));
                                });

                        }

                        // build the trigger
                        q.AddTrigger(() => triggerBuilder.Build());
                    });
                });
            }


            if (!scheduler.IsStarted)
                scheduler.Start();
        }
    }
}
