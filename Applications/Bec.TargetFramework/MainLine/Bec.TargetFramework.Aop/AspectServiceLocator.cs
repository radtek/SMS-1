using Autofac;
using System;

namespace Bec.TargetFramework.Aop
{
    public static class AspectServiceLocator
    {
        private static Autofac.IContainer m_IocContainer;
        private static bool m_IsCacheable;

        private static bool m_TraceEnabled;

        public static void Initialize(Autofac.IContainer container, bool isCacheable, bool traceEnabled)
        {
            if (m_IsCacheable && container != null)
                throw new InvalidOperationException();

            m_IsCacheable = isCacheable;

            m_IocContainer = container;

            m_TraceEnabled = traceEnabled;
        }

        public static bool TraceEnabled
        {
            get
            {
                return m_TraceEnabled;
            }
        }

        public static Func<T> GetService<T>() where T : class
        {
            if (m_IsCacheable)
            {
                return () => new Lazy<T>(GetServiceImpl<T>).Value;
            }
            else
            {
                return GetServiceImpl<T>;
            }
        }

        private static T GetServiceImpl<T>()
        {
            if (m_IocContainer == null)
                throw new InvalidOperationException();

            return m_IocContainer.Resolve<T>();
        }
    }
}
