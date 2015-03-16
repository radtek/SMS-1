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
using System.Web.Mvc;
using Autofac.Integration.Mvc;


namespace Bec.TargetFramework.Entities.Validators
{
    public class ForgotUsernameWithSecretDTOValidator : BaseValidator<ForgotUsernameWithSecretDTO>
    {

        public ForgotUsernameWithSecretDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> dtoErr = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("ForgottenUsername");
            RuleFor(x => x.Email).Matches(RegexExpressions.EmailExpression).WithMessage(dtoErr.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("InvalidEmail")).OverrideValidationMessage);

        }

        
    }
}
