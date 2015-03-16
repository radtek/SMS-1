using Bec.TargetFramework.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Framework.Infrastructure.DependencyManagement
{
    /// <summary>
    /// Configures the inversion of control container with services used by TargetFramework.
    /// </summary>
    public class ContainerConfigurer
    {
        public virtual void Configure(IEngine engine, ContainerManager containerManager, EventBroker broker, TargetFrameworkConfig configuration)
        {
            //other dependencies
            containerManager.AddComponentInstance<TargetFrameworkConfig>(configuration, "TargetFramework.configuration");
            containerManager.AddComponentInstance<IEngine>(engine, "TargetFramework.engine");
            containerManager.AddComponentInstance<ContainerConfigurer>(this, "TargetFramework.containerConfigurer");

            //type finder
            containerManager.AddComponent<ITypeFinder, WebAppTypeFinder>("TargetFramework.typeFinder");

            //register dependencies provided by other assemblies
            var typeFinder = containerManager.Resolve<ITypeFinder>();
            containerManager.UpdateContainer(x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                var drInstances = new List<IDependencyRegistrar>();
                foreach (var drType in drTypes)
                    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                    dependencyRegistrar.Register(x, typeFinder);
            });

            //event broker
            containerManager.AddComponentInstance(broker);
        }
    }
}
