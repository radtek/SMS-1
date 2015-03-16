namespace BrockAllen.MembershipReboot
{
    public class MobilePhoneChangeRequestedEvent<T> : UserAccountEvent<T>
    {
        public string NewMobilePhoneNumber { get; set; }

        public string Code { get; set; }
    }
}