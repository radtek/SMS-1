using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.IOC
{
    public static class IocProvider 
    {
        private static System.Collections.Generic.Dictionary<string,Autofac.IContainer> m_IocContainers = new System.Collections.Generic.Dictionary<string,IContainer>();

        public static void AddIocContiner(Autofac.IContainer container, string key)
        {
            if(m_IocContainers.ContainsKey(key))
                m_IocContainers.Remove(key);

            m_IocContainers.Add(key,container);
        }

        public static Autofac.IContainer GetIocContainer(string key)
        {
            return m_IocContainers.ContainsKey(key) ? m_IocContainers[key] : null;
        }

        public static Autofac.IContainer GetIocContainerUsingAppDomainFriendlyName()
        {
            return m_IocContainers.ContainsKey(AppDomain.CurrentDomain.FriendlyName) ? m_IocContainers[AppDomain.CurrentDomain.FriendlyName] : null;
        }

        public static void DisposeAndRemoveIocContainerUsingAppDomainFriendlyName()
        {
            var container =  m_IocContainers.ContainsKey(AppDomain.CurrentDomain.FriendlyName) ? m_IocContainers[AppDomain.CurrentDomain.FriendlyName] : null;

            if(container != null)
            {
                container.Dispose();
                m_IocContainers.Remove(AppDomain.CurrentDomain.FriendlyName);
            }
        }

        public static Autofac.IContainer IocContainers
        {
            get
            {
                
                return null;
            }
            set
            {
                object p = value;
            }
        }

        public static void RegisterProxyClients(this ContainerBuilder builder, string proxyClientName, string url,bool autoWireProperties = false)
        {
            Assembly.Load(proxyClientName).GetTypes()
               .Where(p => p.Name.EndsWith("Client") && !p.IsInterface)
               .ToList().ForEach(item =>
               {
                  
                   var typeInstance = Activator.CreateInstance(item, new object[] { url });
                   var typeInterface = item.GetInterface("I" + item.Name);
                   Console.WriteLine(proxyClientName +  ": Registering Client Interface:" + typeInterface + " url:" + url);

                   if (autoWireProperties)
                       builder.RegisterInstance(typeInstance).As(typeInterface).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
                   else
                       builder.RegisterInstance(typeInstance).As(typeInterface);
               });
        }

        public static void BuildAndRegisterIocContainer<T>() where T : IDependencyRegistrar
        {
            var builder = new ContainerBuilder();
            var registrar = Activator.CreateInstance<T>();

            registrar.Register(builder);

            var iocContainer = builder.Build();

            IocProvider.AddIocContiner(iocContainer, AppDomain.CurrentDomain.FriendlyName);
        }

        public static IContainer BuildAndReturnIocContainer<T>() where T : IDependencyRegistrar
        {
            var builder = new ContainerBuilder();
            var registrar = Activator.CreateInstance<T>();

            registrar.Register(builder);

            var iocContainer = builder.Build();

            return iocContainer;
        }
    }
}
