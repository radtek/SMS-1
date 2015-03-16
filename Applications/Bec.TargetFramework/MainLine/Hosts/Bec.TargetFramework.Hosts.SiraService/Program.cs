using Bec.TargetFramework.Infrastructure.Serilog;
using System;
using System.ServiceProcess;

namespace Bec.TargetFramework.Hosts.AnalysisService
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
                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                eventLog.Source = "Bec.TargetFramework.Hosts.AnalysisService";
                eventLog.Log = "Application";
                eventLog.EnableRaisingEvents = true;
                
                eventLog.WriteEntry("Main 1");

                //TAG001 Set this to true when deploying as windows service. Set this to false when debugging!
                bool runAsWindowsService = false;

                if (!runAsWindowsService)
                    eventLog.WriteEntry("Not running as window service!!!");

                if (args != null && args.Length > 0)
                {
                    if (args[0].Equals("-c"))
                        runAsWindowsService = false;
                }

                eventLog.WriteEntry("Main 2");

                if (runAsWindowsService)
                {                    
                    eventLog.WriteEntry("runAsWindowsService");

                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
                    { 
                        new AnalysisService() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                else
                {
                    eventLog.WriteEntry("!runAsWindowsService");

                    AnalysisService service = new AnalysisService();
                    try
                    {
                        service.StartService(args);

                        Console.WriteLine("Press <Enter> to stop the Analysis service.");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        if (Serilog.Log.Logger == null)
                            new SerilogLogger(true, false, "AnalysisService").Error(ex);
                        else
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "AnalysisService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }
    }
}
