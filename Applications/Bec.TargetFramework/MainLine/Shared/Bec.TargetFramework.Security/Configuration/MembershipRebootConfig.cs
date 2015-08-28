using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.WebHost;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Bec.TargetFramework.Security.Configuration
{
    public class MembershipRebootConfig
    {
        public static MembershipRebootConfiguration Create()
        {
            // load current settings
            var settings = SecuritySettings.FromConfiguration();
            var config = new MembershipRebootConfiguration(settings);

            //config.AddEventHandler(new DebuggerEventHandler());

            //var appinfo = new AspNetApplicationInformation("Test", "Test Email Signature",
            //    "UserAccount/Login",
            //    "UserAccount/ChangeEmail/Confirm/",
            //    "UserAccount/Register/Cancel/",
            //    "UserAccount/PasswordReset/Confirm/");
            //var emailFormatter = new EmailMessageFormatter(appinfo);

            //config.AddEventHandler(new EmailAccountEventsHandler(emailFormatter));
            config.ConfigurePasswordComplexity();

            return config;
        }
    }
}
