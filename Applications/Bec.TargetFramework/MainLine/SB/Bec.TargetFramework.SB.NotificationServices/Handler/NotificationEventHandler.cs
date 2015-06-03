using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Notifications.Base;
using Bec.TargetFramework.Security;
using BrockAllen.MembershipReboot;
using EnsureThat;
using ServiceStack.Text;
using Bec.TargetFramework.Business.Client.Interfaces;

namespace Bec.TargetFramework.SB.NotificationServices.Handler
{
    using System.IO;
    using System.Net.Mail;
    using System.ServiceModel;

    using Autofac;

    using Bec.TargetFramework.Entities;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.SB.Messages.Commands;
    using Bec.TargetFramework.SB.NotificationServices.Report;

    using NServiceBus;
  
    using Bec.TargetFramework.Infrastructure;
    using Bec.TargetFramework.Entities.Enums;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.SB.Entities;
    using Bec.TargetFramework.SB.Messages.Events;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.Infrastructure.IOC;

    public class NotificationEventHandler : ConcurrentBaseHandler<NotificationEvent>
    {
        private IClassificationDataLogicClient m_ClassificationLogic;
        private INotificationLogicClient m_NotificationLogic;
        private IUserLogicClient m_UserLogic;
        private CommonSettings m_CommonSettings;

        public NotificationEventHandler(ILogger logger, INotificationLogicClient notifLogic,
            IBusLogicClient busLogic, IEventPublishClient eventClient, IClassificationDataLogicClient dataLogic, IUserLogicClient uLogic,
            CommonSettings settings, SBSettings sbSettings)
            : base(logger, busLogic, sbSettings, eventClient)
        {
            m_ClassificationLogic = dataLogic;
            m_NotificationLogic = notifLogic;
            m_UserLogic = uLogic;
            m_CommonSettings = settings;
        }

        public override void Dispose()
        {

        }


        private bool IsDeliveryMethodEmail(int deliveryMethod)
        {
            int emailDeliveryMethod = m_ClassificationLogic.GetClassificationDataForTypeName(
                    "NotificationDeliveryMethodID",
                    "Email");

            return (deliveryMethod == emailDeliveryMethod);
        }

        private void EnsureNotificationContainerValidation()
        {
            // ensure command values
            Ensure.That(m_NotificationContainerDto).IsNotNull();
            Ensure.That(m_NotificationContainerDto.NotificationSetting).IsNotNull();
        }

        private NotificationConstructDTO m_NotificationConstructDto;
        private NotificationContainerDTO m_NotificationContainerDto;
        private NotificationDictionaryDTO m_NotificationDictionaryDto;

        private void LoadNotificationComponents()
        {
            try
            {
                // get noificationLogic
                m_NotificationConstructDto = m_NotificationLogic.GetNotificationConstruct(m_NotificationContainerDto.NotificationSetting.NotificationConstructID, m_NotificationContainerDto.NotificationSetting.NotificationConstructVersionNumber);
            }
            catch (FaultException ex)
            {
                LogError("Error Loading NotificationConstructDTO", ex);
                throw;
            }
        }

        private byte[] GetReportData()
        {
            var exportMethodList = m_ClassificationLogic.GetRootClassificationDataForTypeName("NotificationExportFormatID");

            var reportGenerator = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName).Resolve<StandaloneReportGenerator>();

            // add settings to json
            m_NotificationDictionaryDto = JsonHelper.DeserializeData<NotificationDictionaryDTO>(m_NotificationContainerDto.DataAsJson);

            // apply mutation to notification dictionary
            if (!string.IsNullOrEmpty(m_NotificationConstructDto.NotificationConstructMutatorObjectType))
            {
                // create mutator and execute
                Type mutatorType = Type.GetType(m_NotificationConstructDto.NotificationConstructMutatorObjectType, false);

                EnsureThat.Ensure.That(mutatorType).IsNotNull();

                BaseNotificationMutator mutator = Activator.CreateInstance(mutatorType) as BaseNotificationMutator;

                mutator.IocContainer = IocProvider.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);

                // initialise main 
                mutator.InitialiseBase(m_NotificationDictionaryDto);

                // initialize mutation
                mutator.InitialiseMutator();

                // perform mutation
                m_NotificationDictionaryDto = mutator.MutateNotification();
            }

            return reportGenerator.GenerateReport(m_NotificationContainerDto.NotificationSetting, m_NotificationConstructDto, m_NotificationDictionaryDto);
        }

        private NotificationDTO CreateNotificationDTO()
        {
            var notificationDto = new NotificationDTO();

            notificationDto.NotificationConstructID = m_NotificationConstructDto.NotificationConstructID;
            notificationDto.NotificationConstructVersionNumber =
            m_NotificationConstructDto.NotificationConstructVersionNumber;
            notificationDto.ParentID = m_NotificationContainerDto.NotificationSetting.NotificiationSentFromParentID;
            notificationDto.DateSent = DateTime.Now;
            notificationDto.ParentID = m_NotificationContainerDto.NotificationSetting.NotificiationSentFromParentID;
            notificationDto.IsActive = true;
            notificationDto.IsDeleted = false;
            notificationDto.IsVisible = true;
            notificationDto.IsInternal = (m_NotificationConstructDto.DefaultNotificationDeliveryMethodID ==
                                          NotificationDeliveryMethodIDEnum.System.GetIntValue());
            notificationDto.IsExternal = (m_NotificationConstructDto.DefaultNotificationDeliveryMethodID ==
                                          NotificationDeliveryMethodIDEnum.Email.GetIntValue());
            notificationDto.NotificationData = m_NotificationContainerDto.DataAsJson;
            notificationDto.NotificationRecipients = m_NotificationContainerDto.Recipients;

            return notificationDto;
        }

        private void SendExternalNotificationIfNeeded(NotificationDTO notificationDto)
        {
            if (m_NotificationConstructDto.ExternalRelatedNotificationConstructID.HasValue && m_NotificationConstructDto.ExternalRelatedNotificationConstructVersionNumber.HasValue)
            {
                var externalNotificationConstruct = m_NotificationLogic.GetNotificationConstruct(
                    m_NotificationConstructDto.ExternalRelatedNotificationConstructID.Value,
                    m_NotificationConstructDto.ExternalRelatedNotificationConstructVersionNumber.Value);

                // raise external alert if single user or define target user

                // ensure target exists
                Ensure.That(m_NotificationConstructDto.NotificationConstructTargets.Count > 0).IsTrue();

                // single user so send externalnotification if needed TBD not single user and incorporate target
                if (m_NotificationConstructDto.NotificationConstructTargets.First().IsSingleUser
                    && externalNotificationConstruct.Name.Equals(NotificationConstructEnum.ExternalNotification.GetStringValue()))
                {
                    var dictionary = new ConcurrentDictionary<string, object>();

                    // ensure one recipient and has UAO
                    Ensure.That(notificationDto.NotificationRecipients).IsNotNull();
                    Ensure.That(notificationDto.NotificationRecipients.Count > 0).IsTrue();
                    Ensure.That(notificationDto.NotificationRecipients.First().UserAccountOrganisationID).IsNotNull();

                    var uaoID = notificationDto.NotificationRecipients.First().UserAccountOrganisationID.Value;

                    // add contactDTO
                    dictionary.TryAdd("ContactDTO",
                        m_UserLogic.GetUserAccountOrganisationPrimaryContact(
                            uaoID));

                    // add notificationcountDto
                    dictionary.TryAdd("NotificationCountDTO", new NotificationCountDTO());

                    //Bus.SendNotificationToUserViaUAO<SendNotificationCommandHandler>(m_NotificationLogic, m_CommonSettings,
                    //    externalNotificationConstruct.Name,
                    //    uaoID,
                    //    new NotificationDictionaryDTO { NotificationDictionary = dictionary }
                    //    );
                }
            }
        }

        public override void HandleMessage(NotificationEvent command)
        {
            // check whether message has already been processes
            if (HasMessageAlreadyBeenProcessed())
                return;

            m_NotificationContainerDto = command.NotificationContainer;

            EnsureNotificationContainerValidation();
            LoadNotificationComponents();

            // create report
            try
            {
                var reportData = GetReportData();

                // create Notification entry
                var notificationDto = CreateNotificationDTO();

                // for each recipient create log entry
                CreateNotificationCreatedRecipetLogEntries(notificationDto);

                // if not email then save 
                if (!m_NotificationConstructDto.DefaultNotificationDeliveryMethodID.GetValueOrDefault(0).Equals(NotificationDeliveryMethodIDEnum.Email.GetIntValue()))
                {
                    try
                    {
                        // if external notification reference then send - currently only support single user
                        SendExternalNotificationIfNeeded(notificationDto);

                        m_NotificationLogic.SaveNotification(notificationDto);

                        LogMessageAsCompleted();
                    }
                    catch (Exception ex)
                    {
                        LogError("Send Notification Error", ex);

                        throw;
                    }

                }
                else
                {
                    List<MailAddress> recipientAddresses = GetReceiptAddresses(notificationDto);

                    // only send as email if HTML
                    if (recipientAddresses.Count > 0 && m_NotificationContainerDto.NotificationSetting.ExportFormat.HasValue && m_NotificationContainerDto.NotificationSetting.ExportFormat.Value == NotificationExportFormatIDEnum.HTML.GetIntValue())
                    {
                        SmtpClient smtpClient = new SmtpClient();

                        NotificationSettingDTO settingsDto =
                           m_NotificationDictionaryDto.NotificationDictionary["NotificationSettingDTO"] as
                               NotificationSettingDTO;

                        MailMessage message = new MailMessage();
                        message.IsBodyHtml = true;
                        message.Sender = new MailAddress("applications@beconsultancy.co.uk");
                        message.Subject = settingsDto.Subject;

                        string bodyContent = System.Text.Encoding.UTF8.GetString(reportData);

                        message.Body = bodyContent;

                        var emailIntercept = System.Configuration.ConfigurationManager.AppSettings["emailintercept"];
                        if (!string.IsNullOrEmpty(emailIntercept))
                        {
                            message.Subject = "BEF: " + message.Subject;
                            message.To.Add(emailIntercept);
                        }
                        else
                            recipientAddresses.ToList().ForEach(re => message.To.Add(re));

                        Bec.TargetFramework.SB.Entities.BusMessageDTO busMessage = Bec.TargetFramework.SB.Infrastructure.NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers);
                        Guid eventStatusID = Guid.Empty;
                        if (busMessage != null && !string.IsNullOrEmpty(busMessage.EventReference))
                            Guid.TryParse(busMessage.EventReference, out eventStatusID);

                        string recipients =  string.Join("; ", message.To.Select(r => r.Address));

                        try
                        {
                            smtpClient.Send(message);

                            // create logs for all recipients
                            CreateNotificationmSentReceiptLogEntries(notificationDto);

                            m_NotificationLogic.UpdateEventStatus(eventStatusID, "Sent", recipients, message.Subject, message.Body);

                            m_NotificationLogic.SaveNotification(notificationDto);

                            LogMessageAsCompleted();
                        }
                        catch (SmtpException ex)
                        {
                            CreateNotificationFailedReceiptLogEntries(notificationDto);

                            m_NotificationLogic.UpdateEventStatus(eventStatusID, "Failed", recipients, message.Subject, message.Body + Environment.NewLine + "<p style='color:red;'>" + ex.Message + "</p>");

                            LogError("Send Notification As Email Error", ex);

                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Report Generation Error", ex);

                throw;
            }
        }

        private void CreateNotificationmSentReceiptLogEntries(NotificationDTO notificationDto)
        {
            notificationDto.NotificationRecipients
                                .ForEach(
                                    item =>
                                    {
                                        NotificationRecipientLogDTO logEntry = new NotificationRecipientLogDTO
                                        {
                                            CreatedOn = DateTime.Now,
                                            NotificationRecipientLogID = Guid.NewGuid(),
                                            IsRead = false,
                                            NotificationDeliveryMethodID =
                                                m_NotificationConstructDto.DefaultNotificationDeliveryMethodID,
                                            NotificationExportFormatID =
                                                m_NotificationConstructDto.DefaultNotificationExportFormatID,
                                            SentOn = DateTime.Now,
                                            IsSent = true
                                        };

                                        item.NotificationRecipientLogs.Add(logEntry);
                                    });
        }

        private void CreateNotificationFailedReceiptLogEntries(NotificationDTO notificationDto)
        {
            notificationDto.NotificationRecipients
                                .ForEach(
                                    item =>
                                    {
                                        NotificationRecipientLogDTO logEntry = new NotificationRecipientLogDTO
                                        {
                                            CreatedOn = DateTime.Now,
                                            NotificationRecipientLogID = Guid.NewGuid(),
                                            IsRead = false,
                                            NotificationDeliveryMethodID =
                                                m_NotificationConstructDto.DefaultNotificationDeliveryMethodID,
                                            NotificationExportFormatID =
                                                m_NotificationConstructDto.DefaultNotificationExportFormatID,
                                            SentOn = DateTime.Now,
                                            IsSent = false,
                                            ErrorOccured = true
                                        };

                                        item.NotificationRecipientLogs.Add(logEntry);
                                    });
        }

        private List<MailAddress> GetReceiptAddresses(NotificationDTO notificationDto)
        {
            List<MailAddress> recipientAddresses = new List<MailAddress>();

            List<VDefaultEmailAddressDTO> emailAddresses = new List<VDefaultEmailAddressDTO>();

            notificationDto.NotificationRecipients.ForEach(item =>
                {
                    var emailAddress = m_NotificationLogic.RecipientAddressDetail(item.OrganisationID,item.UserAccountOrganisationID);

                    emailAddresses.Add(emailAddress);
                });

            if (notificationDto.NotificationRecipients != null && notificationDto.NotificationRecipients.Any())
            {
                notificationDto.NotificationRecipients
                    .ForEach(
                        item =>
                        {
                            string emailAddress = emailAddresses.Single(p => p.UserAccountOrganisationID.Equals(item.UserAccountOrganisationID)).Email;

                            recipientAddresses.Add(new MailAddress(emailAddress));
                        });
            }

            return recipientAddresses;
        }

        private void CreateNotificationCreatedRecipetLogEntries(NotificationDTO notificationDto)
        {
            notificationDto.NotificationRecipients.ForEach(
                    nr =>
                    {
                        nr.NotificationRecipientLogs = new List<NotificationRecipientLogDTO>();

                        NotificationRecipientLogDTO logEntry = new NotificationRecipientLogDTO
                        {
                            CreatedOn = DateTime.Now,
                            NotificationRecipientLogID = Guid.NewGuid(),
                            IsRead = false,
                            NotificationDeliveryMethodID = m_NotificationConstructDto.DefaultNotificationDeliveryMethodID,
                            NotificationExportFormatID = m_NotificationConstructDto.DefaultNotificationExportFormatID,
                            IsSent = false
                        };

                        nr.NotificationRecipientLogs.Add(logEntry);
                    });
        }

        private void LogError(string message, Exception ex)
        {
            m_Logger.Error(ex);

            m_Logger.Error(new TargetFrameworkLogDTO
            {
                Exception = ex,
                ApplicationSource = "NotificationService",
                ApplicationSourceType = "NServiceBus Message",
                Message = message
            });

            LogMessageAsFailed();
        }
    }
}
