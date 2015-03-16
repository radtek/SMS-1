namespace BrockAllen.MembershipReboot
{
    public class PasswordChangedEvent<T> : UserAccountEvent<T>
    {
        public string NewPassword { get; set; }
    }
}