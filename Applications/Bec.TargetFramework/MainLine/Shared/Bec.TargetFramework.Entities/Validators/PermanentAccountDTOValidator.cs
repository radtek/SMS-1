using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Helpers;
using System.Text.RegularExpressions;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Entities.Validators
{
    public class PermanentAccountDTOValidator : BaseValidator<PermanentAccountDTO>
    {
        private UserAccountService m_UaService;
        public PermanentAccountDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> validations = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("CreateYourLogins");

            RuleFor(x => x.EmailAddress).Matches(RegexExpressions.EmailExpression).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidEmail")).OverrideValidationMessage);
            RuleFor(x => x.UserName).Length(8,100).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidUsernameLength")).OverrideValidationMessage);
            RuleFor(x => x.Password).Cascade(FluentValidation.CascadeMode.StopOnFirstFailure)
                                    .Matches(RegexExpressions.IsValidPassword).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("PasswordValidation")).OverrideValidationMessage)
                                    .Length(10, 50).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidPasswordLength")).OverrideValidationMessage);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoMatch")).OverrideValidationMessage);

        }
    }
}
        