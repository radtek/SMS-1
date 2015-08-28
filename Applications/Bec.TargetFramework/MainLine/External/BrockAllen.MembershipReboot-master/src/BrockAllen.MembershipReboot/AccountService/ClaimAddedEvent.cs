namespace BrockAllen.MembershipReboot
{
    public class ClaimAddedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public UserClaim Claim { get; set; }
    }
}