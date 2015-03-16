using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.SB.Notifications.Base;
using EnsureThat;

namespace Bec.TargetFramework.SB.Notifications.Mutators
{
    public sealed class ForgotUsernameMutator : BaseNotificationMutator
    {
        private IUserLogic m_UserLogic;

        public override NotificationDictionaryDTO MutateNotification()
        {
            var temporaryAccountDto =
                NotificationDictionary.NotificationDictionary["TemporaryAccountDTO"] as TemporaryAccountDTO;

            Ensure.That(temporaryAccountDto.UserName).IsNotNull();

            var userAccount = m_UserLogic.GetUserAccountByUsername(temporaryAccountDto.UserName);

            var userContacts = m_UserLogic.GetUserContacts(userAccount.ID);

            // set email address
            temporaryAccountDto.EmailAddress = userAccount.Email;
            // set id
            temporaryAccountDto.TemporaryUserId = userAccount.ID;

            // add user contact
            NotificationDictionary.NotificationDictionary.TryAdd("ContactDTO",userContacts.Single(s => s.IsPrimaryContact));
            // update temporary account
            NotificationDictionary.NotificationDictionary["TemporaryAccountDTO"] = temporaryAccountDto;

            return NotificationDictionary;
        }

        public override void InitialiseMutator()
        {
            m_UserLogic = IocContainer.Resolve<IUserLogic>();
        }
    }
}
