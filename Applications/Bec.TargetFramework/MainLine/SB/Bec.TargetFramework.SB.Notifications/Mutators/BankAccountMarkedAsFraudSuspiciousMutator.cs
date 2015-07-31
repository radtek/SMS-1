using Bec.TargetFramework.Entities;
using Bec.TargetFramework.SB.Notifications.Base;

namespace Bec.TargetFramework.SB.Notifications.Mutators
{
    public sealed class BankAccountMarkedAsFraudSuspiciousMutator : BaseNotificationMutator
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
