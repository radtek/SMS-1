using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Wcf;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.CouchBaseCache;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.Service.Configuration;
using Bec.TargetFramework.Workflow.Base;
using Bec.TargetFramework.Workflow.Engine;
using Bec.TargetFramework.Workflow.Interfaces;
using Bec.TargetFramework.Workflow.Logic;
using Bec.TargetFramework.Workflow.Providers;
using Bec.TargetFramework.Workflow.Scheduler;

using System.Configuration;
using Seq;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Settings;

namespace Bec.TargetFramework.Workflow.Configuration
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        public void Register(Autofac.ContainerBuilder builder)
        {
            // register logger
            builder.Register(c => new SerilogLogger(true,false, "Workflow")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();

            // register scheduler
            builder.RegisterType<WorkflowTaskScheduler>().As<WorkflowTaskScheduler>().SingleInstance();

            // register db providers
            builder.RegisterType<DbWorkflowProvider>().As<DbWorkflowProvider>().SingleInstance();
            builder.RegisterType<DbWorkflowTemplateProvider>().As<DbWorkflowTemplateProvider>().SingleInstance();
            builder.RegisterType<DbWorkflowInstanceProvider>().As<DbWorkflowInstanceProvider>().SingleInstance();

            // register container
            builder.RegisterType<WorkflowContainerBase>().As<IWorkflowContainer>().SingleInstance();

            builder.RegisterType<WorkflowEngine>().As<WorkflowEngine>().SingleInstance();

            builder.RegisterType<WorkflowInstanceLogic>().As<WorkflowInstanceLogic>().SingleInstance();
        }

        private string BuildBaseUrlForServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private void RegisterService<T>(ContainerBuilder builder, string url)
        {
            builder.Register(c => new ChannelFactory<T>(
                 Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(),
                 new EndpointAddress(url)))
                 .SingleInstance();

            builder.Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel())
              .UseWcfSafeRelease();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}
