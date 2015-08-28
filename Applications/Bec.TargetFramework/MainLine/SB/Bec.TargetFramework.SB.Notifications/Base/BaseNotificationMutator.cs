using Autofac;
using Bec.TargetFramework.Entities;
using EnsureThat;

namespace Bec.TargetFramework.SB.Notifications.Base
{
    public abstract class BaseNotificationMutator : IBaseNotificationMutator
    {
        public IContainer IocContainer { get; set; }

        public NotificationDictionaryDTO NotificationDictionary { get; set; }

        public void InitialiseBase(NotificationDictionaryDTO dictionaryDto)
        {
            Ensure.That(dictionaryDto).IsNotNull();
            Ensure.That(dictionaryDto.NotificationDictionary).IsNotNull();

            NotificationDictionary = dictionaryDto;
        }

        public virtual void InitialiseMutator()
        {
            // Available for initialisation process
        }

        public virtual NotificationDictionaryDTO MutateNotification()
        {
            return NotificationDictionary;
        }

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
