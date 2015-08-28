using SharpRepository.Repository.Ioc;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure.IOC
{
    public sealed class SimpleInjectorDataDependencyResolver : BaseRepositoryDependencyResolver 
    {
        private readonly Container m_Container;

        public SimpleInjectorDataDependencyResolver(Container container)
        {
            m_Container = container;
        }
        protected override T ResolveInstance<T>()
        {
            return (T) m_Container.GetInstance(typeof(T));
        }

        protected override object ResolveInstance(Type type)
        {
            return m_Container.GetInstance(type);
        }
    }
}
