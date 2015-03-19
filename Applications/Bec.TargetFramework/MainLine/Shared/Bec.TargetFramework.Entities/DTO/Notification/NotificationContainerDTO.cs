using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Enums;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Helpers;

namespace Bec.TargetFramework.Entities
{
    using Bec.TargetFramework.Framework.Configuration;

    using Fabrik.Common;

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


        public NotificationContainerDTO()
        { }

        public NotificationContainerDTO(CommonSettings commonSettings, Guid notificationConstructID, int notificationConstructVersionNumber, List<NotificationRecipientDTO> recipients,
               NotificationDictionaryDTO data, int exportFormatEnumValue = (int) NotificationExportFormatIDEnum.HTML5)
        {
            Ensure.Argument.NotNull(recipients);
            Recipients = recipients;

            NotificationSetting = new NotificationSettingDTO
            {
                ServerURL = commonSettings.ServerUrl,
                ServerNotificationImageContentURLFolder = commonSettings.ServerNotificationImageContentUrlFolder,
                ServerLogoImageFileNameWithExtension = commonSettings.ServerLogoImageFileNameWithExtension,
                NotificationConstructID = notificationConstructID,
                NotificationConstructVersionNumber = notificationConstructVersionNumber,
                ExportFormat =exportFormatEnumValue,
                LoginRoute = commonSettings.LoginActionRoute,
                NotificationFromEmailAddress = commonSettings.NotificationFromEmailAddress
                
            };

            data.NotificationDictionary.TryAdd("NotificationSettingDTO",NotificationSetting);

            DataAsJson = JsonHelper.SerializeData(data);
        }

        [DataMember]
        public List<NotificationRecipientDTO> Recipients { get; set; }
      

    }
}
