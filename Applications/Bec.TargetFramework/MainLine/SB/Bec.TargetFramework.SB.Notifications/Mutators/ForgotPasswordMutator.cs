using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.SB.Notifications.Base;
using EnsureThat;
using Bec.TargetFramework.Business.Client.Interfaces;

namespace Bec.TargetFramework.SB.Notifications.Mutators
{
    public sealed class ForgotPasswordMutator : BaseNotificationMutator
    {
        public override NotificationDictionaryDTO MutateNotification()
        {
            return NotificationDictionary;
        }

        public override void InitialiseMutator()
        {
        }
    }
}
