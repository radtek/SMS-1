namespace BrockAllen.MembershipReboot
{
    public class AccountCreatedEvent<T> : UserAccountEvent<T>
    {
        // InitialPassword might be null if this is a re-send
        // notification for account created (when user tries to
        // reset password before verifying their account)
        public string InitialPassword { get; set; }

        public string VerificationKey { get; set; }
    }
}