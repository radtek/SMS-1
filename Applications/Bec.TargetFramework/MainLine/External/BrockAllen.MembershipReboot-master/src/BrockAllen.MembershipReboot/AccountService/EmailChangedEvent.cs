namespace BrockAllen.MembershipReboot
{
    public class EmailChangedEvent<T> : UserAccountEvent<T>
    {
        public string OldEmail { get; set; }

        public string VerificationKey { get; set; }
    }
}