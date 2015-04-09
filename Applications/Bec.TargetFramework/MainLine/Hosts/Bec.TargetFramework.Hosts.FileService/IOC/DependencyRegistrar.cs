
using System.Configuration;
using System.ServiceModel;
using Bec.TargetFramework.Infrastructure.Serilog;

namespace Bec.TargetFramework.Hosts.FileService.IOC
{

    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Bec.TargetFramework.Infrastructure.IOC;


    /// <summary>
    /// IOC Configuration - Loads on Startup of Web Application
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Starts the IOC Container
        /// </summary>
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register(c => new SerilogLogger(true, false, "FileService")).As<ILogger>().SingleInstance();
        }

    }

}