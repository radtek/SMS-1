using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

using Bec.TargetFramework.Infrastructure.Log;

using NServiceBus;

namespace Bec.TargetFramework.SB.Hosts.SBService
{
    public class TaskScheduler : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            //if (AppDomain.CurrentDomain.FriendlyName.Contains("TaskServices"))
            //{
            //    var taskLogic = Configure.Instance.Builder.Build<ITaskLogic>();
            //    var logger = Configure.Instance.Builder.Build<ILogger>();

            //    var taskSchedules = taskLogic.GetAllBusTaskSchedules();

            //    if (taskSchedules.Any())
            //    {
            //        taskSchedules.ForEach(item =>
            //        {
            //            Ensure.Argument.IsNot(item.IntervalInMinutes <= 0, "ItervalInMinutes needs to be 1 or greater");

            //            Schedule.Every(TimeSpan.FromMinutes(item.IntervalInMinutes)).Action(item.Name, () =>
            //            {
            //                Ensure.Argument.NotNull(item.ObjectTypeName, "ObjecTypeName cannot be empty for a Task ID:" + item.BusTaskID);
            //                Ensure.Argument.NotNull(item.MessageTypeName, "MessageTypeName cannot be empty for a Task ID:" + item.BusTaskID);
            //                Ensure.Argument.NotNull(item.MessageTypeAssembly, "MessageTypeAssembly cannot be empty for a Task ID:" + item.BusTaskID);

            //                try
            //                {
            //                    string typeName = item.MessageTypeName + ", " + item.MessageTypeAssembly;

            //                    var message = Bus.CreateInstance(Type.GetType(typeName));

            //                    Bus.SetMessageHeader(message, "Source", "TaskService");
            //                    Bus.SetMessageHeader(message, "MessageType", typeName);
            //                    Bus.SetMessageHeader(message, "ServiceType", "Task");

            //                    Bus.Publish(message);
            //                }
            //                catch (Exception ex)
            //                {
            //                    logger.Error(new TargetFrameworkLogDTO
            //                    {
            //                        Exception = ex,
            //                        Message = "Task ID:" + item.BusTaskID + " Has thrown an exception using task handler id:" + item.BusTaskHandlerID
            //                    });

            //                    Serilog.Log.Logger.Error(ex, ex.Message, null);

            //                    // we will continue to process
            //                }
            //            });
            //        });
            //    }
            //}

           
        }

        public void Stop()
        {
        }
    }
}
