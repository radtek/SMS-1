namespace BrockAllen.MembershipReboot
{
    public class LinkedAccountAddedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public LinkedAccount LinkedAccount { get; set; }
    }
}