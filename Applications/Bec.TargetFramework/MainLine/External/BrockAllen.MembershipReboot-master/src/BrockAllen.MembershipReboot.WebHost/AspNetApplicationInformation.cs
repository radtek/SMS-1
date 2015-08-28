/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Web;
using System.Configuration;

namespace BrockAllen.MembershipReboot.WebHost
{
    public class AspNetApplicationInformation : RelativePathApplicationInformation
    {
        public AspNetApplicationInformation(
            string appName,
            string emailSig,
            string relativeLoginUrl,
            string relativeConfirmChangeEmailUrl,
            string relativeCancelVerificationUrl,
            string relativeConfirmPasswordResetUrl
        )
        {
            this.ApplicationName = appName;
            this.EmailSignature = emailSig;
            this.RelativeLoginUrl = relativeLoginUrl;
            this.RelativeConfirmChangeEmailUrl = relativeConfirmChangeEmailUrl;
            this.RelativeCancelVerificationUrl = relativeCancelVerificationUrl;
            this.RelativeConfirmPasswordResetUrl = relativeConfirmPasswordResetUrl;
        }

        protected override string GetApplicationBaseUrl()
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.GetApplicationUrl();
            else
                return ConfigurationManager.AppSettings["baseAddress"];

        }
    }
}
