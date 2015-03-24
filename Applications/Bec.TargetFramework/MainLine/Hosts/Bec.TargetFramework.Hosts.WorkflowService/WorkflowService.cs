using Autofac;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using System.Configuration;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Hosts.WorkflowService.Services;
using Bec.TargetFramework.Workflow.Scheduler;
using Bec.TargetFramework.Workflow.Engine;
using NServiceBus;
using NServiceBus.Installation.Environments;
using NServiceBus.Serilog.Tracing;

namespace Bec.TargetFramework.Hosts.WorkflowService
{
    using Bec.TargetFramework.Workflow.Configuration;
    using Bec.TargetFramework.Workflow.Interfaces;
    using Bec.TargetFramework.Infrastructure;
    using Bec.TargetFramework.Entities.Settings;

    public partial class WorkflowService : ServiceBase
    {
        private List<ServiceHost> m_ServiceHosts { get; set; }
        private List<IBusinessLogicService> m_ServiceInstances { get; set; }

        private WorkflowTaskManager m_TaskManager;

        private IBus m_Bus;


        public WorkflowService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        private void InitialiseIOC()
        {
            ContainerBuilder builder = new ContainerBuilder();

            var registrar = new Bec.TargetFramework.Hosts.WorkflowService.IOC.DependencyRegistrar();

            registrar.Register(builder, null);

            builder.Register(c => new WorkflowTaskManager(c.Resolve<WorkflowSettings>(), c.Resolve<ILogger>(),c.Resolve<WorkflowTaskScheduler>(),c.Resolve<WorkflowEngine>())).As<WorkflowTaskManager>().SingleInstance();

            builder.Register(c => new WorkflowProcessService(c.Resolve<WorkflowSettings>(), c.Resolve<ILogger>(), c.Resolve<WorkflowEngine>(), c.Resolve<WorkflowTaskManager>())).As<IWorkflowProcessService>(); 
         
           // IocContainerBase.IocContainer = builder.Build();
 
            Task.Factory.StartNew(() =>
            {
                //TracingLog.Disable();

                //var startableBus = NServiceBusHelper.CreateDefaultStartableBusUsingaAutofacBuilder(IocContainerBase.IocContainer).PurgeOnStartup(true).CreateBus();

                //Configure.Instance.ForInstallationOn<Windows>().Install();

                //SB.Infrastructure.HookMessageMutators.InitialiseMessageMutators();

                //m_Bus = startableBus.Start();
            });

            Task.Factory.StartNew(
                () =>
                {
                  //  Bec.TargetFramework.Aop.AspectServiceLocator.Initialize(IocContainerBase.IocContainer, true, IocContainerBase.IocContainer.Resolve<WorkflowSettings>().EnableWorkflowTrace);

                });
        }

        public void StartService(string[] args)
        {
            eventLog.WriteEntry("Starting Service");

            m_ServiceHosts = new List<ServiceHost>();
        
            try
            {
                //InitialiseIOC();

                //m_TaskManager = IocContainerBase.IocContainer.Resolve<WorkflowTaskManager>();

                //ServiceHost host = new ServiceHost(typeof(WorkflowProcessService));
                //host.AddDependencyInjectionBehavior(typeof(IWorkflowProcessService), IocContainerBase.IocContainer);
                //host.Open();

                //m_ServiceHosts.Add(host);

                //m_TaskManager.StartProcess();
            }
            catch (Exception ex)
            {
                    
                OnStop();
            }
        }


        protected override void OnStop()
        {
            eventLog.WriteEntry("Stopping Service");

            if(m_ServiceHosts != null)
            {
                m_ServiceHosts.ForEach(item =>
                    item.Close());
            }

            if(m_TaskManager != null && m_TaskManager.IsProcessRunning())
                m_TaskManager.StopProcess();

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

            if (m_TaskManager != null && m_TaskManager.IsProcessRunning())
                m_TaskManager.StopProcess();

            base.OnShutdown();
        }

    }
}
