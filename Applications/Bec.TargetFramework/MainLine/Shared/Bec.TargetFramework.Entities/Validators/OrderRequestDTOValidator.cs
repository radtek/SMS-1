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
    public class OrderRequestDTOValidator : BaseValidator<OrderRequestDTO>
    {
        public OrderRequestDTOValidator()
        {

            List<VFieldDetailValidationForUIDTO> validationsOrder = FieldDetailsAndValidations.GetInterfacePanelFieldDetailValidations("PaymentDetails");

            //RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.Now).WithMessage("Not a valid date");
            RuleFor(x => x.CardNumber).Matches(RegexExpressions.CardNumberExpression).WithMessage(validationsOrder.SingleOrDefault(x => x.InterfacePanelFieldDetailValidationName.Equals("CardNumberNotValid")).OverrideValidationMessage);

        }


    }
}
        