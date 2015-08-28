

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Settings
{
    public class CommonSettings : ISettings
    {
        public int TimeSinceLastNotificationOfSameTypeWasSent { get; set; }

        public bool LogDebugDatabase { get; set; }
        public bool LogTraceDatabase { get; set; }

        public string ServerUrl { get; set; }
        public string ServerNotificationImageContentUrlFolder { get; set; }

        public bool EnableTrace { get; set; }

        public string ServerLogoImageFileNameWithExtension { get; set; }

        public string RedisServerConnectionString { get; set; }

        public string NotificationFromEmailAddress { get; set; }

        public int PersonalOrganisationType { get; set; }

        public string PrimaryEmailAddressOfTFFramework { get; set; }

        public string LoginActionRoute { get; set; }

        public int UserAccountExpiryInDays { get; set; }

        public string PrimaryUserIDFromBecAdministrationNotifications { get; set; }

        public string ServerChangePasswordActionRoute { get; set; }

        public string IconFilePath { get; set; }

        public string Environment { get; set; }

        public string PublicWebsiteUrl { get; set; }

        public string ProductName { get; set; }

        public string SupportTelephoneNumber { get; set; }
    }
}
