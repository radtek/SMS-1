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

namespace Bec.TargetFramework.SB.Hosts.SBService
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
                        new SBService() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                else
                {
                    try
                    {
                        using (var service = new SBService())
                        {
                            service.StartService(args);

                            Console.WriteLine("Press <Enter> to stop the SB Service.");
                            Console.ReadLine();

                            if (service.CanStop)
                                service.Stop();

                            return;
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
