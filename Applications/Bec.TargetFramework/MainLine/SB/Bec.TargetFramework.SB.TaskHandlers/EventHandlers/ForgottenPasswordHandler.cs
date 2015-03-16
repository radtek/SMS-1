using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Infrastructure.Extensions;
using Bec.TargetFramework.Workflow.Interfaces;
using EnsureThat;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class ForgottenPasswordHandler : BaseEventHandler<Bec.TargetFramework.SB.Messages.Events.ForgottenPasswordEvent>
    {
        private IWorkflowProcessService m_WorkflowService;
        private IUserLogic m_UserLogic;
        private INotificationDataService m_NotificationDataService;
        private INotificationLogic m_NotificationLogic;

        public ForgottenPasswordHandler(ILogger logger,
            IBusLogic busLogic, IClassificationDataLogic dataLogic,
            CommonSettings settings, IWorkflowProcessService wService, IUserLogic userLogic, INotificationDataService notificationDataService, INotificationLogic nLogic)
            : base(logger, busLogic, dataLogic, settings)
        {
            m_WorkflowService = wService;
            m_UserLogic = userLogic;
            m_NotificationDataService = notificationDataService;
            m_NotificationLogic = nLogic;
        }

        public override void HandleMessage(Messages.Events.ForgottenPasswordEvent accountEvent)
        {
            try
            {
                if (accountEvent.TemporaryAccountDto.IsForgotUsername.GetValueOrDefault(true))
                    LogMessageAsCompleted();
                else
                {
                    // password logic
                    try
                    {
                        var dictionary = new ConcurrentDictionary<string, object>();

                        // get username and set proper id TBD remove this
                        var userAccount = m_UserLogic.GetUserAccountByUsername(accountEvent.TemporaryAccountDto.UserName);

                        // set password verification key
                        accountEvent.TemporaryAccountDto.TemporaryUserId = userAccount.ID;

                        var tempGuid = Guid.Empty;

                        if (userAccount.IsTemporaryAccount)
                            tempGuid = UserTypeEnum.Temporary.GetGuidValue();
                        else
                            tempGuid = UserTypeEnum.User.GetGuidValue();

                        var uaoId = m_UserLogic.GetUserAccountOrganisation(userAccount.ID)
                            .Where(s => s.UserTypeID.Equals(tempGuid))
                            .First()
                            .UserAccountOrganisationID;

                        // send notification
                        var notificationConstruct =
                        m_NotificationLogic.GetLatestNotificationConstructIdFromName(
                            NotificationConstructEnum.ForgotPassword.GetStringValue());

                        bool hasNotificationBeenSentRecently = m_NotificationLogic.HasNotificationAlreadyBeenSentInTheLastTimePeriod(uaoId, null,
                            notificationConstruct.NotificationConstructID,
                            notificationConstruct.NotificationConstructVersionNumber
                            , null, false,
                            TimeSpan.FromMinutes(m_CommonSettings.TimeSinceLastNotificationOfSameTypeWasSent));

                        if (!hasNotificationBeenSentRecently)
                        {
                            var verificationKey = m_UserLogic.ResetPasswordAndSetVerificationKey(userAccount.ID);

                            accountEvent.TemporaryAccountDto.PasswordVerificationKeyURL =
                                m_CommonSettings.ServerChangePasswordActionRoute + "?id=" + verificationKey;

                            dictionary.TryAdd("TemporaryAccountDTO", accountEvent.TemporaryAccountDto);

                            Bus.SendNotificationToUserViaUAO<ForgottenPasswordHandler>(m_NotificationLogic,
                                m_CommonSettings,
                                NotificationConstructEnum.ForgotPassword.GetStringValue(),
                                uaoId,
                                new NotificationDictionaryDTO { NotificationDictionary = dictionary }
                                );
                        }

                        LogMessageAsCompleted();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }

                
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("createLoginEvent Error", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }
    }
}
