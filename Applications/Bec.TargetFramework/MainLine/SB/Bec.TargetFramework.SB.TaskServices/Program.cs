using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Serilog;
using Fabrik.Common;

namespace Bec.TargetFramework.SB.TaskServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                bool runAsWindowsService = true;
                
                if (args != null && args.Length > 0)
                {
                    if (args[0].Equals("-c"))
                        runAsWindowsService = false;
                }

                if (runAsWindowsService)
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
                    { 
                        new TaskService() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                else
                {
                    TaskService service = new TaskService();

                    try
                    {
                        service.StartService(args);

                        Console.WriteLine("Press <Enter> to stop the Task Services.");
                        Console.ReadLine();

                    }
                    catch (Exception ex)
                    {
                        if (Serilog.Log.Logger == null)
                            new SerilogLogger(true, false, "TaskService").Error(ex);
                        else
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "TaskService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }
    }
}
