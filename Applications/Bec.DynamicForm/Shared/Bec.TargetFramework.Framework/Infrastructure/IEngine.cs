using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
using System;

namespace Bec.TargetFramework.Framework.Infrastructure
{
    /// <summary>
    /// Classes implementing this interface can serve as a portal for the 
    /// various services composing the TargetFramework engine. Edit functionality, modules
    /// and implementations access most TargetFramework functionality through this 
    /// interface.
    /// </summary>
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }
        
        /// <summary>
        /// Initialize components and plugins in the TargetFramework environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize(TargetFrameworkConfig config);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        T[] ResolveAll<T>();
    }
}
