namespace BrockAllen.MembershipReboot
{
    public class LinkedAccountRemovedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public LinkedAccount LinkedAccount { get; set; }
    }
}