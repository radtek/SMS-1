using Bec.TargetFramework.Entities.Validators;
namespace Bec.TargetFramework.Entities
{
    [FluentValidation.Attributes.ValidatorAttribute(typeof(AddressDTOValidator))]
    public partial class AddressDTO
    {
    }
}
