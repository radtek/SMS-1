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
    public class FirmDetailsDTOValidator : BaseValidator<FirmDetailsDTO>
    {
        public FirmDetailsDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> validationsFirmContact = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("FirmContact");
            RuleFor(x => x.Website).Matches(RegexExpressions.WebsiteExpression).WithMessage(validationsFirmContact.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("WebsiteValid")).OverrideValidationMessage);

            List<VFieldDetailValidationForUIDTO> validationsFirmReg = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("FirmRegistration");
            RuleFor(x => x.RegisteredCompanyNumber).Matches(RegexExpressions.CRNNumberExpression).WithMessage(validationsFirmReg.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("CRNNumberValid")).OverrideValidationMessage);

            List<VFieldDetailValidationForUIDTO> validationVAT = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("FirmVATDetails");
            RuleFor(x => x.VATNumber).Matches(RegexExpressions.VATNumber).WithMessage(validationVAT.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("VATNumberValid")).OverrideValidationMessage);

            List<VFieldDetailValidationForUIDTO> validationContactDetails = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("ContactDetails");
            RuleFor(x => x.OfficePhoneNumber).Matches(RegexExpressions.UkTelephoneExpression).WithMessage(validationContactDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("OfficePhoneValid")).OverrideValidationMessage)
                ;
            RuleFor(x => x.DirectDialNumber).Matches(RegexExpressions.UkTelephoneExpression).WithMessage(validationContactDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("DirectDialNumberValid")).OverrideValidationMessage);

            List<VFieldDetailValidationForUIDTO> validationAccountDetails = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("FirmClientAccountDetails");
            RuleFor(x => x.AccountNumber).Matches(RegexExpressions.UKBankAccount).WithMessage(validationAccountDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("AccountNumberValid")).OverrideValidationMessage);

            List<VFieldDetailValidationForUIDTO> validationOtherDetails = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("FirmOtherDetails");
            RuleFor(x => x.DirectorsCount).InclusiveBetween(1, 9999999).WithMessage(validationOtherDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoOfDirectorsValid")).OverrideValidationMessage);
            RuleFor(x => x.RPCount).InclusiveBetween(1, 9999999).WithMessage(validationOtherDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoOfRPValid")).OverrideValidationMessage);
            RuleFor(x => x.StaffCount).InclusiveBetween(1, 9999999).WithMessage(validationOtherDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoOfStaffValid")).OverrideValidationMessage);
            RuleFor(x => x.CompletionsCount).InclusiveBetween(1, 9999999).WithMessage(validationOtherDetails.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("NoOfCompletionsValid")).OverrideValidationMessage);


            

        }
 
        
    }
}
        