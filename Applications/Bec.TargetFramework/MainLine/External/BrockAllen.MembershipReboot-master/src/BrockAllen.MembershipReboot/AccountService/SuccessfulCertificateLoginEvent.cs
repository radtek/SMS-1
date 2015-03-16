using System.Security.Cryptography.X509Certificates;

namespace BrockAllen.MembershipReboot
{
    public class SuccessfulCertificateLoginEvent<T> : SuccessfulLoginEvent<T>
    {
        public UserCertificate UserCertificate { get; set; }

        public X509Certificate2 Certificate { get; set; }
    }
}