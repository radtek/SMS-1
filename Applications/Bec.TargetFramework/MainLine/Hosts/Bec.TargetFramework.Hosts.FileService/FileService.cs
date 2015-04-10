using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Hosts.FileService.Services;
using Bec.TargetFramework.Hosts.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using System.ServiceModel;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.Hosts.FileService
{
    public partial class FileService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }

        public static Autofac.IContainer m_IocContainer { get; set; }

        public FileService()
        {
            InitializeComponent();
        }

        private void InitialiseIOC()
        {
            IocProvider.BuildAndRegisterIocContainer<Bec.TargetFramework.Hosts.FileService.IOC.DependencyRegistrar>();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();

            try
            {
                InitialiseIOC();

                ServiceHost host = new ServiceHost(typeof(FileProcessService));
                host.AddDependencyInjectionBehavior(typeof(IFileProcessService), IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName));
                host.Open();

                m_ServiceHosts.Add(host);
            }
            catch (Exception ex)
            {
                if (Serilog.Log.Logger == null)
                    new SerilogLogger(true, false, "FileService").Error(ex);
                else
                    Serilog.Log.Logger.Error(ex, ex.Message, null);
                OnStop();
            }
        }


        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            if (m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            base.OnStop();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("Shutting Down Service");

            if (m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            base.OnShutdown();
        }
    }
}
