using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Web.Mvc;
using Autofac.Integration.Mvc;


namespace Bec.TargetFramework.Entities.Validators
{
    public class LoginDTOValidator : BaseValidator<LoginDTO>
    {

        public LoginDTOValidator()
        {

            //VFieldDetailValidationForUIDTO dtoErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("Login", "TestValidation");

            //RuleFor(x => x.Username).NotEmpty().WithMessage("Required");
            //if (dtoErr.OverrideValidationIsHTML.Value)
            //    RuleFor(x => x.Username).NotEqual("swapna").WithMessage(dtoErr.OverrideValidationMessageHTML);
            //else
            //    RuleFor(x => x.Username).NotEqual("swapna").WithMessage(dtoErr.OverrideValidationMessage);

            //RuleFor(x => x.Password).NotEmpty().WithMessage("Required");
        }

        
    }
}
