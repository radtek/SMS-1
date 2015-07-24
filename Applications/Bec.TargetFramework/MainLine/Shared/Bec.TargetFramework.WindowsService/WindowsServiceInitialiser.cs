using Bec.TargetFramework.Infrastructure.Serilog;
using System;
using System.ServiceProcess;

namespace Bec.TargetFramework.WindowsService
{
    public static class WindowsServiceInitialiser<TService>
        where TService : ServiceBase, IWindowsService, new()
    {
        public static void InitialiseWindowsService(string[] args)
        {
            var serviceName = typeof(TService).Name;
            try
            {
                if (!Environment.UserInteractive)
                {
                    RunServiceAsWindowsService();
                }
                else
                {
                    RunServiceAsConsoleApp(args, serviceName);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, serviceName);
                throw;
            }
        }

        private static void RunServiceAsConsoleApp(string[] args, string serviceName) 
        {
            using (var service = new TService())
            {
                service.StartService(args);

                Console.WriteLine(string.Format("Press <Enter> to stop the {0} Service.", serviceName));
                Console.ReadLine();

                if (service.CanStop)
                {
                    service.Stop();
                }
            }
        }

        private static void RunServiceAsWindowsService() 
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new TService() 
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void LogError(Exception exeption, string serviceName)
        {
            if (Serilog.Log.Logger == null)
            {
                new SerilogLogger(true, false, serviceName).Error(exeption);
            }
            else
            {
                Serilog.Log.Logger.Error(exeption, exeption.Message, null);
            }
        }
    }
}
