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
    public class PersonalDetailsDTOValidator : BaseValidator<PersonalDetailDTO>
    {
        public PersonalDetailsDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> validationsPersonalDetails = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("PersonalDetailsPanel");

           // RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.Now).WithMessage("Not a valid date");
           RuleFor(x => x.TelephoneNumber).Matches(RegexExpressions.UkTelephoneExpression).WithMessage(validationsPersonalDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("PhoneNotValid")).OverrideValidationMessage);


            List<VFieldDetailValidationForUIDTO> validationsIDDetails = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("ID+");
            RuleFor(x => x.AccountNumber).Matches(RegexExpressions.UKBankAccount).WithMessage(validationsIDDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("PD_AccountNumberNotValid")).OverrideValidationMessage);
            RuleFor(x => x.IBANNumber).Matches(RegexExpressions.IBANExpression).WithMessage(validationsIDDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("IBANNotValid")).OverrideValidationMessage);

            RuleFor(x => x.SwiftNumber).Matches(RegexExpressions.UKBankAccount).WithMessage(validationsIDDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("SWIFTNotValid")).OverrideValidationMessage);


        }


    }
}
        