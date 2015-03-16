using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.BWATokenService;
using Bec.TargetFramework.Entities.Settings;
using EnsureThat;

namespace Bec.TargetFramework.Business
{
    public class ExperianHelper
    {
        public static void EnsureExperianSettingsAreValid(ExperianIDCheckSettings idSettings, string sourceService)
        {
            Ensure.That(idSettings).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.BankWizardLanguage).WithExtraMessageOf(() => sourceService).IsNotNullOrEmpty();
            Ensure.That(idSettings.UserName).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.Password).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.CertificatePath).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.CertificatePassword).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.WASPServiceUrl).WithExtraMessageOf(() => sourceService).IsNotNull();
            Ensure.That(idSettings.BWAServiceUrl).WithExtraMessageOf(() => sourceService).IsNotNull();
        }

        public static string CreateASecureToken(ExperianIDCheckSettings idSettings)
        {
            var waspToken = string.Empty;

            ServicePointManager.Expect100Continue = true;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var cert = new X509Certificate2(idSettings.CertificatePath, idSettings.CertificatePassword);

            var waspService = new TokenService();
            waspService.Url = idSettings.WASPServiceUrl;
            waspService.ClientCertificates.Add(cert);
            waspToken =
                waspService.STS("<WASPAuthenticationRequest><ApplicationName>" + idSettings.ApplicationName +
                                "</ApplicationName><AuthenticationLevel>CertificateAuthentication</AuthenticationLevel><AuthenticationParameters/></WASPAuthenticationRequest>");
            return waspToken;
        }
    }
}
