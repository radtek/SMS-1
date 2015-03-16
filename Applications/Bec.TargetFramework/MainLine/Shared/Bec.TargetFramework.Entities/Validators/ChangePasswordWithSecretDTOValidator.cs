using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Entities.Helpers;


namespace Bec.TargetFramework.Entities.Validators
{
    public class ChangePasswordWithSecretDTOValidator : BaseValidator<ChangePasswordWithSecretDTO>
    {

        public ChangePasswordWithSecretDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> validations = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("CreateYourLogins");

            RuleFor(x => x.Password).Cascade(FluentValidation.CascadeMode.StopOnFirstFailure)
                                    .Matches(RegexExpressions.IsValidPassword).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("PasswordValidation")).OverrideValidationMessage)
                                    .Length(10, 50).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidPasswordLength")).OverrideValidationMessage);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage(validations.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoMatch")).OverrideValidationMessage);


        }

        
    }
}
