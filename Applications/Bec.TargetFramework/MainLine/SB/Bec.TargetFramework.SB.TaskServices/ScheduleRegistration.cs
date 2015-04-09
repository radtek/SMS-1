using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.TaskHandlers;
using Fabrik.Common;
using NServiceBus;
using NServiceBus.Config;

namespace Bec.TargetFramework.SB.TaskServices
{
    public class ScheduleRegistration :INeedInitialization,IWantToRunWhenConfigurationIsComplete
    {
        public IBus Bus { get; set; }
        public Schedule Schedule { get; set; }

        public void Start()
        {
            

           
        }


        public void Customize(BusConfiguration configuration)
        {

        }

        public void Run(Configure config)
        {

            Thread.Sleep(5000);
            if (AppDomain.CurrentDomain.FriendlyName.Contains("TaskServices"))
            {
                //var busLogic = config.Builder.Build<IBusLogicClient>();
                //var logger = config.Builder.Build<ILogger>();

                //var taskSchedules = busLogic.GetBusTaskSchedules();

                //if (taskSchedules.Any())
                //{
                //    taskSchedules.ForEach(item =>
                //    {
                //        Ensure.Argument.IsNot(item.IntervalInMinutes <= 0, "ItervalInMinutes needs to be 1 or greater");

                //        Schedule.Every(TimeSpan.FromMinutes(item.IntervalInMinutes),item.Name, () =>
                //        {
                //             Ensure.Argument.NotNull(item.ObjectTypeName, "ObjecTypeName cannot be empty for a Task ID:" + item.BusTaskID);
                //            Ensure.Argument.NotNull(item.MessageTypeName, "MessageTypeName cannot be empty for a Task ID:" + item.BusTaskID);
                //            Ensure.Argument.NotNull(item.MessageTypeAssembly, "MessageTypeAssembly cannot be empty for a Task ID:" + item.BusTaskID);

                //            try
                //            {
                //                string typeName = item.MessageTypeName + ", " + item.MessageTypeAssembly;

                //                var message = Activator.CreateInstance(Type.GetType(typeName));

                //                Bus.SetMessageHeader(message, "Source", "TaskService");
                //                Bus.SetMessageHeader(message, "MessageType", typeName);
                //                Bus.SetMessageHeader(message, "ServiceType", "Task");

                //                Bus.Publish(message);
                //            }
                //            catch (Exception ex)
                //            {
                //                logger.Error(new TargetFrameworkLogDTO
                //                {
                //                    Exception = ex,
                //                    Message = "Task ID:" + item.BusTaskID + " Has thrown an exception using task handler id:" + item.BusTaskHandlerID
                //                });

                //                Serilog.Log.Logger.Error(ex, ex.Message, null);

                //                // we will continue to process
                //            }
                //        });
                //    });
               // }
            }
        }
    }
}
