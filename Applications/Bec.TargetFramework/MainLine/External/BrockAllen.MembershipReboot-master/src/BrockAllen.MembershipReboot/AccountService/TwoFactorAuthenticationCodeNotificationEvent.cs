namespace BrockAllen.MembershipReboot
{
    public class TwoFactorAuthenticationCodeNotificationEvent<T> : UserAccountEvent<T>
    {
        public string Code { get; set; }
    }
}