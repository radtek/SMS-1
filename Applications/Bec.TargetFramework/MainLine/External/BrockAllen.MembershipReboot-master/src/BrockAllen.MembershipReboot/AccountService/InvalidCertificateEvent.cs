using System.Security.Cryptography.X509Certificates;

namespace BrockAllen.MembershipReboot
{
    public class InvalidCertificateEvent<T> : FailedLoginEvent<T>
    {
        public X509Certificate2 Certificate { get; set; }
    }
}