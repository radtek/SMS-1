namespace BrockAllen.MembershipReboot
{
    public abstract class UserAccountEvent<TAccount> : IEvent
    {
        //public UserAccountService<T> UserAccountService { get; set; }
        public TAccount Account { get; set; }
    }
}