namespace BrockAllen.MembershipReboot
{
    public class ClaimRemovedEvent<T> : UserAccountEvent<T>, IAllowMultiple
    {
        public UserClaim Claim { get; set; }
    }
}