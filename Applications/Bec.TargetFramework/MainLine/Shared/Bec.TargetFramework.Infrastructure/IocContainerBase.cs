using Autofac;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure
{
    public static class IocContainerBase 
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
            return m_IocContainers[key];
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
    }
}
