namespace BrockAllen.MembershipReboot
{
    public class TwoFactorAuthenticationEnabledEvent<T> : UserAccountEvent<T>
    {
        public TwoFactorAuthMode Mode { get; set; }
    }
}