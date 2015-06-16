﻿using System;
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

        private static void PurgeScheduledTasks(IScheduler scheduler,List<VBusTaskScheduleDTO> dtos)
        {
            // purge only for current application
            var appName = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
            var appEnvironment = System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"];

            IList<string> jobGroups = scheduler.GetJobGroupNames();
            IList<string> triggerGroups = scheduler.GetTriggerGroupNames();

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

        private static void PurgeScheduledTasks(IScheduler scheduler,string taskName,string groupName)
        {
            IList<string> jobGroups = scheduler.GetJobGroupNames();
            IList<string> triggerGroups = scheduler.GetTriggerGroupNames();

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

        private static void ValidateSchedulerSettings()
        {
            Ensure.That(System.Configuration.ConfigurationManager.AppSettings["ApplicationName"])
                .IsNotNullOrWhiteSpace();
            Ensure.That(System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"])
                .IsNotNullOrWhiteSpace();
        }

        public static void ShutdownScheduler(ILifetimeScope lifetimeScope)
        {
            var scheduler = lifetimeScope.Resolve<IScheduler>();

            if (scheduler != null && !scheduler.IsShutdown)
                scheduler.Shutdown();
        }

        public static void InitialiseExecuteTaskImmediately(ILifetimeScope lifetimeScope, string taskName, string groupName, Type taskType)
        {
            var scheduler = lifetimeScope.Resolve<IScheduler>();

            // purge all current jobs
            PurgeScheduledTasks(scheduler, taskName,groupName);

            DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTime.UtcNow);
        DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(null, 10);

            var jobKey = new JobKey(taskName, groupName);

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
            });
        }

        public static void InitialiseAndStartScheduler(ILifetimeScope lifetimeScope)
        {
            ValidateSchedulerSettings();

            var scheduler = lifetimeScope.Resolve<IScheduler>();

            var busTaskLogicClient =
                lifetimeScope.Resolve<IBusTaskLogicClient>();

            var appName = System.Configuration.ConfigurationManager.AppSettings["ApplicationName"];
            var appEnvironment = System.Configuration.ConfigurationManager.AppSettings["ApplicationEnvironment"];

            // load dto data
            var busTaskDtos = busTaskLogicClient.AllBusTaskSchedulesByAppNameAndEnv(appName, appEnvironment);

            // purge all current jobs
            PurgeScheduledTasks(scheduler, busTaskDtos);

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
