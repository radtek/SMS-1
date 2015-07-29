using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Serilog;
using Log = Serilog.Log;
using Devart.Data.PostgreSql.Entity.Configuration;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            PgSqlEntityProviderConfig.Instance.DmlOptions.InsertNullBehaviour = InsertNullBehaviour.InsertDefaultOrNull;
            try
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
                    BusinessService service = new BusinessService();

                    try
                    {
                        service.StartService(args);
                      
                        Console.WriteLine("Press <Enter> to stop the Business service.");
                        Console.ReadLine();

                        service.Stop();
                    }
                    catch (Exception ex)
                    {
                        if (Serilog.Log.Logger == null)
                            new SerilogLogger(true, false, "BusinessService").Error(ex);
                        else
                            Serilog.Log.Logger.Error(ex, ex.Message, null);
                    }
                    finally
                    {
                        service.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "BusinessService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
            }
        }
    }
}
