using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Helpers;
using System.Text.RegularExpressions;

namespace Bec.TargetFramework.Entities.Validators
{
    public class FirmUserDTOValidator : BaseValidator<FirmUserDTO>
    {
        public FirmUserDTOValidator()
        {
            List<VFieldDetailValidationForUIDTO> validationsFirmUser = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("AddUser");
            RuleFor(x => x.Email).Matches(RegexExpressions.EmailExpression).WithMessage(validationsFirmUser.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidEmail")).OverrideValidationMessage);

        }

       

    }
}
