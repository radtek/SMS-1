namespace BrockAllen.MembershipReboot
{
    public class EmailChangeRequestedEvent<T> : UserAccountEvent<T>
    {
        public string OldEmail { get; set; }

        public string NewEmail { get; set; }

        public string VerificationKey { get; set; }
    }
}