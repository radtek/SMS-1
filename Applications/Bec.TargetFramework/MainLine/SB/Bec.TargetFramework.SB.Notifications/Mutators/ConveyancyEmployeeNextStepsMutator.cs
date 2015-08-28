using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.SB.Notifications.Base;

namespace Bec.TargetFramework.SB.Notifications.Mutators
{
    public sealed class ConveyancyEmployeeNextStepsMutator : BaseNotificationMutator
    {
        public override NotificationDictionaryDTO MutateNotification()
        {
            
            // add user next steps dto to notification
            NotificationDictionary.NotificationDictionary.TryAdd("UserNextSteps", new UserNextStepsNotificationDTO { SafeTransactionSearchPublicProductPrice = 55.3M });

            return NotificationDictionary;
        }

        public override void InitialiseMutator()
        {
            // Do something
        }
    }
}
