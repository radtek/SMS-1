using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.WindowsService;
using Microsoft.Owin.Hosting;
using NServiceBus;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace Bec.TargetFramework.Hosts.BusinessService
{
    public partial class BusinessService : ServiceBase, IWindowsService
    {
        public string m_BaseAddress { get; set; }

        private Autofac.IContainer m_IocContainer { get; set; }

        private IDisposable m_Server = null;

        private IBus m_Bus;

        public BusinessService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        private void InitialiseIOC()
        {
            IocProvider.BuildAndRegisterIocContainer<Bec.TargetFramework.Hosts.BusinessService.IOC.DependencyRegistrar>();
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            try
            {
                InitialiseIOC();

                m_BaseAddress = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];

                m_Server = WebApp.Start<Startup>(url: m_BaseAddress);
            }
            catch (Exception ex)
            {
                if (Environment.UserInteractive) Console.WriteLine(ex.Message);
                if (IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName) != null)
                {
                    var logger = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<ILogger>();

                    logger.Error(ex, ex.Message);
                }
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);

                Stop();
            }
        }


        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            if(m_Server != null)
                m_Server.Dispose();

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            base.OnShutdown();
        }

    }
}
