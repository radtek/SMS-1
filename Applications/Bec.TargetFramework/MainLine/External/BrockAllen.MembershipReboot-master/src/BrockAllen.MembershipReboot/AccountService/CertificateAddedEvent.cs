namespace BrockAllen.MembershipReboot
{
    public class CertificateAddedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public UserCertificate Certificate { get; set; }
    }
}