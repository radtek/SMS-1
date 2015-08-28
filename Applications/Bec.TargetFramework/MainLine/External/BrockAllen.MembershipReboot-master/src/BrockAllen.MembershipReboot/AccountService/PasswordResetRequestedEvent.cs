namespace BrockAllen.MembershipReboot
{
    public class PasswordResetRequestedEvent<T> : UserAccountEvent<T>
    {
        public string VerificationKey { get; set; }
    }
}