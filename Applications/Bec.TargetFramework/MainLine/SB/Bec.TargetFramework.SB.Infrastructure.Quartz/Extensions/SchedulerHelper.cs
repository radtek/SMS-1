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
using EnsureThat;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Client.Interfaces;


namespace Bec.TargetFramework.SB.Infrastructure.Quartz.Extensions
{
    public static class SchedulerHelper
    {
        public static void ScheduleQuartzJob(ILifetimeScope lifetimeScope, Action<QuartzConfigurator> jobConfigurator)
        {
            var jobConfig = new QuartzConfigurator();

            jobConfigurator(jobConfig);

            if (jobConfig.JobEnabled == null || jobConfig.JobEnabled() || (jobConfig.Job == null || jobConfig.Triggers == null))
            {
                var jobDetail = jobConfig.Job();
                var jobTriggers = jobConfig.Triggers.Select(triggerFactory => triggerFactory()).Where(trigger => trigger != null);

                var scheduler = lifetimeScope.Resolve<IScheduler>();
                var logger = lifetimeScope.Resolve<ILogger>();

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

        private static void PurgeScheduledTasksByApplication(IScheduler scheduler,List<VBusTaskScheduleDTO> dtos)
        {
            IList<string> jobGroups = scheduler.GetJobGroupNames();

            foreach (string group in jobGroups)
            {
                var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
                var jobKeys = scheduler.GetJobKeys(groupMatcher);
                foreach (var jobKey in jobKeys)
                {
                    if(dtos.Exists(s => s.Name.Equals(jobKey.Name) && s.BusTaskGroupName.Equals(jobKey.Group)))
                        scheduler.DeleteJob(jobKey);
                }
            }
        }

        private static void PurgeScheduledTaskByTaskAndGroup(IScheduler scheduler,string taskName,string groupName)
        {
            IList<string> jobGroups = scheduler.GetJobGroupNames();

            foreach (string group in jobGroups)
            {
                var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
                var jobKeys = scheduler.GetJobKeys(groupMatcher);
                foreach (var jobKey in jobKeys)
                {
                    if(taskName.Equals(jobKey.Name) && groupName.Equals(jobKey.Group))
                        scheduler.DeleteJob(jobKey);
                }
            }
        }

        private static void PurgeAllScheduledTasksByGroup(IScheduler scheduler, string groupName = null)
        {
            IList<string> jobGroups = scheduler.GetJobGroupNames();

            foreach (string group in jobGroups)
            {
                var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
                var jobKeys = scheduler.GetJobKeys(groupMatcher);
                foreach (var jobKey in jobKeys)
                {
                    if(groupName != null && jobKey.Group.Equals(groupName))
                        scheduler.DeleteJob(jobKey);
                    else
                        scheduler.DeleteJob(jobKey);
                }
            }
        }

        private static void ValidateSchedulerSettings()
        {
            Ensure.That(System.Configuration.ConfigurationManager.AppSettings["ApplicationName"])
                .IsNotNullOrWhiteSpace();
            Ensure.That(System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"])
                .IsNotNullOrWhiteSpace();
        }

        public static void ShutdownScheduler(ILifetimeScope lifetimeScope,bool purgeTempTasks = false)
        {
            if (lifetimeScope != null)
            {
                var scheduler = lifetimeScope.Resolve<IScheduler>();

                if(purgeTempTasks)
                    PurgeTempTasks(lifetimeScope);

                if (scheduler != null && !scheduler.IsShutdown)
                    scheduler.Shutdown();
            }
        }

        public static void InitialiseExecuteTempTaskImmediately(ILifetimeScope lifetimeScope, string taskName, Type taskType)
        {
            var scheduler = lifetimeScope.Resolve<IScheduler>();
            var logger = lifetimeScope.Resolve<ILogger>();

            // purge all current jobs
            PurgeScheduledTaskByTaskAndGroup(scheduler, taskName, "TEMP");
            var jobKey = new JobKey(taskName, "TEMP");

            // if already registered then delete and reschedule
            if (scheduler.CheckExists(jobKey))
                scheduler.DeleteJob(jobKey);

            ScheduleQuartzJob(lifetimeScope, q =>
            {
                q.WithJob(JobBuilder.Create(taskType)
                .WithIdentity(jobKey)
                .RequestRecovery()
                .Build);

                var triggerBuilder = TriggerBuilder.Create();
                    triggerBuilder.StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(10)));
                    triggerBuilder.WithSimpleSchedule(a => a.WithIntervalInSeconds(10));
                      
                q.AddTrigger(() => triggerBuilder.Build());

                logger.Trace(string.Format("Execute Temp Scheduled Job: {0} Group:{1}", taskName, "TEMP"));
            });
        }

        public static void PurgeTempTasks(ILifetimeScope lifetimeScope)
        {
            var scheduler = lifetimeScope.Resolve<IScheduler>();

            // purge all temp tasks
            PurgeAllScheduledTasksByGroup(scheduler,"TEMP");
        }

        public static void InitialiseAndStartScheduler(ILifetimeScope lifetimeScope)
        {
            ValidateSchedulerSettings();

            var scheduler = lifetimeScope.Resolve<IScheduler>();

            var busTaskLogicClient = lifetimeScope.Resolve<IBusTaskLogicClient>();

            var appName = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
            var appEnvironment = System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"];

            // load dto data
            var busTaskDtos = busTaskLogicClient.AllBusTaskSchedulesByAppNameAndEnv(appName, appEnvironment);

            // purge all current jobs
            PurgeScheduledTasksByApplication(scheduler, busTaskDtos);

            if (busTaskDtos.Count > 0)
            {
                busTaskDtos.ForEach(item =>
                {
                    var jobKey = new JobKey(item.Name, item.BusTaskGroupName);

                    // if already registered then delete and reschedule
                    if (!scheduler.CheckExists(jobKey))
                        scheduler.DeleteJob(jobKey);

                    ScheduleQuartzJob(lifetimeScope, q =>
                    {
                        var taskType = System.Type.GetType(item.HandlerObjectTypeName + ", " + item.HandlerObjectTypeAssemblyName);

                        q.WithJob(JobBuilder.Create(taskType)
                        .WithIdentity(jobKey)
                        .UsingJobData("DTO",JsonHelper.SerializeData(item))
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
