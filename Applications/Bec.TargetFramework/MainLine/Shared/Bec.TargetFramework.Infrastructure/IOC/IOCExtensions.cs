using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.IOC
{
    public static class IOCExtensions
    {
        public static void RegisterProxyClients(this ContainerBuilder builder, string proxyClientName, string url)
        {
            Assembly.Load(proxyClientName).GetTypes()
               .Where(p => p.Name.EndsWith("Client") && !p.IsInterface)
               .ToList().ForEach(item =>
               {
                   var typeInstance = Activator.CreateInstance(item, new object[] { url });
                   var typeInterface = item.GetInterface("I" + item.Name);
                   builder.RegisterInstance(typeInstance).As(typeInterface);
               });
        }

        public static void BuildAndRegisterIocContainer<T>() where T:IDependencyRegistrar
        {
            var builder = new ContainerBuilder();
            var registrar = Activator.CreateInstance<T>();

            registrar.Register(builder);

            var iocContainer = builder.Build();

            IocContainerBase.AddIocContiner(iocContainer, AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
