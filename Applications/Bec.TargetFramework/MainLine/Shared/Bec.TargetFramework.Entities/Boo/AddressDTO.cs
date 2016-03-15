using Bec.TargetFramework.Entities.Validators;
namespace Bec.TargetFramework.Entities
{
    public partial class AddressDTO
    {
        public bool AreAllMandatoryFieldsSet()
        {
            return
                !string.IsNullOrWhiteSpace(Line1) &&
                !string.IsNullOrWhiteSpace(Town) &&
                !string.IsNullOrWhiteSpace(PostalCode);
        }
    }
}
