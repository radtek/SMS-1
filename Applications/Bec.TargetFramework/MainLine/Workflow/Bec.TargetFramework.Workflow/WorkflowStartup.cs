using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Workflow.Configuration;

namespace Bec.TargetFramework.Workflow
{
    public class WorkflowStartup
    {
        private static IContainer m_DependencyContainer;

        public static T ResolveType<T>()
        {
            var t = m_DependencyContainer.Resolve(typeof(T));

            return (T)t;
        }

        public static void InitializeIOC()
        {
            //var containerBuilder = new ContainerBuilder();

            //var webRegistrar = new DependencyRegistrar();

            //webRegistrar.Register(containerBuilder, null);

            //var container = containerBuilder.Build();

            //// initialize DB 
            //DbInitializer.Initialize(container);

            //m_DependencyContainer = container;
        }
    }
}
