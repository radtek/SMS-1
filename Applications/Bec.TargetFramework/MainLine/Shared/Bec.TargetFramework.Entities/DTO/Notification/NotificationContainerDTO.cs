using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Settings;
using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class NotificationContainerDTO
    {
        [DataMember]
        public NotificationSettingDTO NotificationSetting { get; set; }
        [DataMember]
        public bool DataSentAsJson { get; set; }
        [DataMember]
        public string DataAsJson { get; set; }
        [DataMember]
        public string NotificationConstructName { get; set; }

        public NotificationContainerDTO()
        { }

        public NotificationContainerDTO(List<NotificationRecipientDTO> recipients,
            NotificationDictionaryDTO data, string notificationConstructName)
        {
            Ensure.Argument.NotNull(recipients);
            Recipients = recipients;

            NotificationConstructName = notificationConstructName;

            data.NotificationDictionary.TryAdd("NotificationSettingDTO", NotificationSetting);

            DataAsJson = JsonHelper.SerializeData(data);
        }

        public NotificationContainerDTO(NotificationConstructDTO notificationConstruct, CommonSettings commonSettings, List<NotificationRecipientDTO> recipients, NotificationDictionaryDTO data, ActivityType? activityType, Guid? activityID)
        {
            Ensure.Argument.NotNull(recipients);
            Recipients = recipients;

            NotificationSetting = new NotificationSettingDTO
            {
                ServerURL = commonSettings.ServerUrl,
                ServerNotificationImageContentURLFolder = commonSettings.ServerNotificationImageContentUrlFolder,
                ServerLogoImageFileNameWithExtension = commonSettings.ServerLogoImageFileNameWithExtension,
                NotificationConstructID = notificationConstruct.NotificationConstructID,
                NotificationConstructVersionNumber = notificationConstruct.NotificationConstructVersionNumber,
                ExportFormat = notificationConstruct.DefaultNotificationExportFormatID ?? (int)NotificationExportFormatIDEnum.HTML5,
                LoginRoute = commonSettings.LoginActionRoute,
                NotificationFromEmailAddress = commonSettings.NotificationFromEmailAddress,
                Subject = notificationConstruct.NotificationSubject
            };

            data.NotificationDictionary.TryAdd("NotificationSettingDTO", NotificationSetting);

            DataAsJson = JsonHelper.SerializeData(data);

            ActivityType = activityType;
            ActivityID = activityID;
        }

        [DataMember]
        public List<NotificationRecipientDTO> Recipients { get; set; }

        [DataMember]
        public ActivityType? ActivityType { get; set; }

        [DataMember]
        public Guid? ActivityID { get; set; }
    }
}
