namespace BrockAllen.MembershipReboot
{
    public class PasswordResetSecretRemovedEvent<T> : UserAccountEvent<T>
    {
        public PasswordResetSecret Secret { get; set; }
    }
}