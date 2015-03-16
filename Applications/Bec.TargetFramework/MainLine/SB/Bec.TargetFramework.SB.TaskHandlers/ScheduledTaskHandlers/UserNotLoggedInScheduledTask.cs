using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Infrastructure.Extensions;
using Bec.TargetFramework.Security;
using EnsureThat;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.ScheduledTaskHandlers
{
    public class UserNotLoggedInScheduledTask : ConcurrentBaseHandler<TestTaskHandlerMessage>
    {
        private IUserLogic m_UserLogic;

        private INotificationLogic m_NotificationLogic { get; set; }
        private INotificationDataService m_NotificationDataService { get; set; }

        public UserNotLoggedInScheduledTask(ILogger logger,IBusLogic bLogic, IUserLogic uLogic,INotificationDataService ndLogic,INotificationLogic nLogic,CommonSettings commonSettings)
            : base(logger, bLogic, commonSettings)
        {
            m_UserLogic = uLogic;
            m_NotificationLogic = nLogic;
            m_NotificationDataService = ndLogic;
        }

        public override void HandleMessage(TestTaskHandlerMessage message)
        {
            try
            {
                var userAccounts = m_UserLogic.GetUserAccountsNotLoggedIn();

                var userTypeGuid = UserTypeEnum.Temporary.GetGuidValue();

                if (userAccounts.Count > 0)
                {
                    // send reminders between 7 and 14
                    userAccounts.Where(s => s.Between7and14DaysNotLoggedIn.HasValue && s.Between7and14DaysNotLoggedIn == true && s.IsTemporaryAccount == true)
                        .ToList()
                        .ForEach(s =>
                        {
                            // if no reminders sent then send one
                            if (s.COLPRemindersNotReadBetween7and14Days.GetValueOrDefault(0).Equals(0))
                            {
                                

                                if (string.IsNullOrEmpty(s.LoginWorkflowDataContent))
                                    m_Logger.Info("User " + s.Username + " has no login workflow");
                                else
                                {
                                    var uaoID =
                                    m_UserLogic.GetUserAccountOrganisation(s.ID)
                                        .Where(
                                            p =>
                                                p.UserID.Equals(s.ID) &&
                                                p.UserTypeID.Equals(userTypeGuid)).First()
                                        .UserAccountOrganisationID;

                                    SendReminder(s,uaoID);
                                }
                                   
                            }
                                
                        });

                    // 14 - 21
                    userAccounts.Where(s => s.Between14and21DaysNotLoggedIn.HasValue && s.Between14and21DaysNotLoggedIn == true && s.IsTemporaryAccount == true)
                        .ToList()
                        .ForEach(s =>
                        {
                            // if no reminders sent then send one
                            if (s.COLPRemindersNotReadBetween14and21Days.GetValueOrDefault(0).Equals(0))
                                if (string.IsNullOrEmpty(s.LoginWorkflowDataContent))
                                    m_Logger.Info("User " + s.Username + " has no login workflow");
                                else
                                {
                                    var uaoID =
                                    m_UserLogic.GetUserAccountOrganisation(s.ID)
                                        .Where(
                                            p =>
                                                p.UserID.Equals(s.ID) &&
                                                p.UserTypeID.Equals(userTypeGuid)).First()
                                        .UserAccountOrganisationID;

                                    SendReminder(s, uaoID);
                                }
                        });

                    // greater than 21 reset password and send new password notification
                    userAccounts.Where(s => s.GreaterThan21DaysNotLoggedIn.HasValue && s.GreaterThan21DaysNotLoggedIn == true && s.IsTemporaryAccount == true)
                        .ToList()
                        .ForEach(s =>
                        {
                            if(string.IsNullOrEmpty(s.LoginWorkflowDataContent))
                                m_Logger.Info("User "+ s.Username + " has no login workflow");
                            else
                            {
                                var uaoID =
                                m_UserLogic.GetUserAccountOrganisation(s.ID)
                                    .Where(
                                            p =>
                                                p.UserID.Equals(s.ID) &&
                                                p.UserTypeID.Equals(userTypeGuid)).First()
                                    .UserAccountOrganisationID;

                                ResetPassword(s, uaoID);
                            }
                        });

                    LogMessageAsCompleted();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                LogError("UserNotLoggedInTask Has Failed", ex, this.GetType().FullName);

                throw;
            }

            // get all users
            
        }

        private void ResetPassword(VUserAccountNotLoggedInDTO notLoggedIn, Guid uaoID)
        {
            var workflowStateBaseDto =
                JsonHelper.DeserializeData<WorkflowStateBaseDTO>(notLoggedIn.LoginWorkflowDataContent);

            Ensure.That(workflowStateBaseDto).IsNotNull();
            Ensure.That(workflowStateBaseDto.WorkflowDictionaryDto).IsNotNull();

            var registrationDto = workflowStateBaseDto.WorkflowDictionaryDto.WorkflowDictionary[WorkflowDataEnum.RegistrationData.GetStringValue()] as RegistrationDTO;
            var temporaryAccountDto = workflowStateBaseDto.WorkflowDictionaryDto.WorkflowDictionary[WorkflowDataEnum.TemporaryAccountData.GetStringValue()] as TemporaryAccountDTO;

            var oldPassword = temporaryAccountDto.Password;
            var newPassword = RandomPasswordGenerator.Generate(12);

            try
            {
                // rest password so cannot login thus preventing access
                m_UserLogic.ResetUserPassword(temporaryAccountDto.TemporaryUserId,newPassword);
            }
            catch (Exception)
            {
                // reset password back
                m_UserLogic.ResetUserPassword(temporaryAccountDto.TemporaryUserId,oldPassword);
                
                throw;
            }

           
        }

        private void SendReminder(VUserAccountNotLoggedInDTO notLoggedIn,Guid uaoID)
        {
            var workflowStateBaseDto =
                JsonHelper.DeserializeData<WorkflowStateBaseDTO>(notLoggedIn.LoginWorkflowDataContent);

            Ensure.That(workflowStateBaseDto).IsNotNull();
            Ensure.That(workflowStateBaseDto.WorkflowDictionaryDto).IsNotNull();

            var registrationDto = workflowStateBaseDto.WorkflowDictionaryDto.WorkflowDictionary[WorkflowDataEnum.RegistrationData.GetStringValue()] as RegistrationDTO;

            Bus.SendNotificationToUserViaUAO<UserNotLoggedInScheduledTask>(m_NotificationLogic,
                m_CommonSettings,
                NotificationConstructEnum.ColpRegistration.GetStringValue(),
                uaoID,
                new NotificationDictionaryDTO { NotificationDictionary = workflowStateBaseDto.WorkflowDictionaryDto.WorkflowDictionary }
                );
        }
    }

    public class TestTaskHandlerMessage : IEvent
    {
        
    }
}
