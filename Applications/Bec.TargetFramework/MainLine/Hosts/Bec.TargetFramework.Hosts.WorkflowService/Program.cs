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

namespace Bec.TargetFramework.Hosts.WorkflowService
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
                bool runAsWindowsService = false;

                if (args != null && args.Length > 0)
                {
                    if (args[0].Equals("-c"))
                        runAsWindowsService = false;
                }

                if (runAsWindowsService)
                {
                    #if (!DEBUG)
                        ServiceBase[] ServicesToRun;
                        ServicesToRun = new ServiceBase[] 
                        { 
                            new WorkflowService() 
                        };
                        ServiceBase.Run(ServicesToRun);
                    #else
                        WorkflowService service = new WorkflowService();

                        try
                        {
                            service.StartService(args);

                            Console.WriteLine("Press <Enter> to stop the Workflow service.");
                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                        }
                    #endif
                }
                else
                {
                    string[] servicePorts = ConfigurationManager.AppSettings["ServicesNeededOnStartupPorts"].Split(',');

                    
                        bool serviceRunning = false;

                        while (!serviceRunning)
                        {
                            try
                            {
                                servicePorts.ForEach(sp =>
                                    new TcpClient().Connect("localhost", int.Parse(sp)));

                                serviceRunning = true;
                            }
                            catch (Exception)
                            {
                            }

                            Thread.Sleep(1000);
                        }

                        WorkflowService service = new WorkflowService();
                        try
                        {
                        service.StartService(args);

                        Console.WriteLine("Press <Enter> to stop the Workflow service.");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        if (Serilog.Log.Logger == null)
                            new SerilogLogger(true, false, "WorkflowService").Error(ex);
                        else
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "WorkflowService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }
    }
}
