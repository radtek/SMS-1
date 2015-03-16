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
    public class RegistrationDTOValidator : BaseValidator<RegistrationDTO>
    {
        public RegistrationDTOValidator()
        {
            VFieldDetailValidationForUIDTO dtoCOSRARegulatorNumberErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("RegisterCODetails", "InvalidSRA");
            VFieldDetailValidationForUIDTO dtoCOCLCRegulatorNumberErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("RegisterCODetails", "InvalidCLC");
            VFieldDetailValidationForUIDTO dtoCOOfficeSRARegulatorNumberErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("RegisterCOOfficeDetails", "InvalidSRA");
            VFieldDetailValidationForUIDTO dtoCOOfficeCLCRegulatorNumberErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("RegisterCOOfficeDetails", "InvalidCLC");
            VFieldDetailValidationForUIDTO dtoInValidEmailErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("RegisterCODetails", "InvalidEmail");

            RuleFor(x => x.COEmail).Matches(RegexExpressions.EmailExpression).WithMessage(dtoInValidEmailErr.OverrideValidationMessage);
            RuleFor(x => x.Email).Matches(RegexExpressions.EmailExpression).WithMessage(dtoInValidEmailErr.OverrideValidationMessage);

        }

       

    }
}
