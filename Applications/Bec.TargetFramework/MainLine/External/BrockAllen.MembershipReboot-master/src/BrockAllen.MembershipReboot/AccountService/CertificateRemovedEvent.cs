namespace BrockAllen.MembershipReboot
{
    public class CertificateRemovedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public UserCertificate Certificate { get; set; }
    }
}