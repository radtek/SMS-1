namespace BrockAllen.MembershipReboot
{
    public class PasswordResetSecretAddedEvent<T> : UserAccountEvent<T>
    {
        public PasswordResetSecret Secret { get; set; }
    }
}