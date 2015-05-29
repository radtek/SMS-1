using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;

namespace Bec.TargetFramework.SB.Notifications.Base
{
    public abstract class BaseNotificationMutator : IBaseNotificationMutator
    {
        private ILogger m_Logger;

        private NotificationDictionaryDTO m_NotificationDictionary;



        public Autofac.IContainer IocContainer { get; set; }

        public NotificationDictionaryDTO NotificationDictionary
        {
            get { return m_NotificationDictionary; }
            set { m_NotificationDictionary = value; }
        }

        public void InitialiseBase(Entities.NotificationDictionaryDTO dictionaryDto)
        {
            Ensure.That(dictionaryDto).IsNotNull();
            Ensure.That(dictionaryDto.NotificationDictionary).IsNotNull();

            NotificationDictionary = dictionaryDto;

            m_Logger = IocContainer.Resolve<ILogger>();
        }

        public abstract void InitialiseMutator();

        public abstract NotificationDictionaryDTO MutateNotification();

        public T GetDTO<T>()
            where T : class
        {
            return this.NotificationDictionary.NotificationDictionary[typeof(T).Name] as T;
        }
        public void SetDTO<T>(T item)
            where T : class
        {
            this.NotificationDictionary.NotificationDictionary[typeof(T).Name] = item;
        }
        
    }
}
