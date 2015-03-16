using Bec.TargetFramework.Entities.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Validators
{
    public class AddressDTOValidator : BaseValidator<AddressDTO>
    {
        public AddressDTOValidator()
        {
            VFieldDetailValidationForUIDTO dtoCOOfficePostalCodeErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("Address", "InvalidPostCode");

            RuleFor(x => x.PostalCode).Matches(RegexExpressions.UKPostCode).WithMessage(dtoCOOfficePostalCodeErr.OverrideValidationMessage);
        }

    }
}
