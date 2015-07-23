using Bec.TargetFramework.Infrastructure.Serilog;
using System;
using System.ServiceProcess;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    // TODO ZM: This code is used in multiple places (SBService, BusinessService, TaskService, etc.)
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                InitialiseWindowsService(args);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static void InitialiseWindowsService(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new BusinessService() 
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                using (var service = new BusinessService())
                {
                    service.StartService(args);

                    Console.WriteLine("Press <Enter> to stop the Business Service.");
                    Console.ReadLine();

                    if (service.CanStop)
                    {
                        service.Stop();
                    }
                }
            }
        }

        private static void LogError(Exception exeption)
        {
            if (Serilog.Log.Logger == null)
            {
                new SerilogLogger(true, false, "BusinessService").Error(exeption);
            }
            else
            {
                Serilog.Log.Logger.Error(exeption, exeption.Message, null);
            }
        }
    }
}
