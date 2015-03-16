using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.SB.Notifications.Base
{
    public interface IBaseNotificationMutator
    {
        IContainer IocContainer { get; }

        void InitialiseMutator();

        NotificationDictionaryDTO MutateNotification();
    }
}
