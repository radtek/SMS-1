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

namespace Bec.TargetFramework.Hosts.FileService
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
                            new FileService() 
                        };
                        ServiceBase.Run(ServicesToRun);
                    #else
                        FileService service = new FileService();

                        try
                        {
                            service.StartService(args);

                            Console.WriteLine("Press <Enter> to stop the File service.");
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
                    
                   
                    
                    FileService service = new FileService();

                        try
                        {
                        service.StartService(args);

                        Console.WriteLine("Press <Enter> to stop the File service.");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        if (Serilog.Log.Logger == null)
                            new SerilogLogger(true, false, "FileService").Error(ex);
                        else
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "FileService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }
    }
}
