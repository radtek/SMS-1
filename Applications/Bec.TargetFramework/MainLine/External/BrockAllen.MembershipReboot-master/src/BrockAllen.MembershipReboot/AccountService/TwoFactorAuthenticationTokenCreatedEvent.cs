namespace BrockAllen.MembershipReboot
{
    public class TwoFactorAuthenticationTokenCreatedEvent<T> : UserAccountEvent<T>
    {
        public string Token { get; set; }
    }
}