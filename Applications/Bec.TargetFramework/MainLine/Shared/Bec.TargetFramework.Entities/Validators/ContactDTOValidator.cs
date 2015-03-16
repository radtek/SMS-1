using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using FluentValidation;
using BrockAllen.MembershipReboot;
using System.Web.UI.WebControls;

namespace Bec.TargetFramework.Entities.Validators
{
    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        private UserAccountService m_UaService;

        public ContactDTOValidator(UserAccountService uaService, List<AddressDTO> addressList)
        {
            m_UaService = uaService;

            // rules

            RuleFor(login => addressList).NotNull()
                .Must(DoesAtLeastOneAddressExist)
                .WithMessage("At least one Address must be added. Please add an address and save it.");

            RuleFor(login => addressList).NotNull()
                .Must(IsAtLeastOneAddressMarkedAsPrimary)
                .WithMessage("At least one Address must be marked as primary");

        }

        public ContactDTOValidator(UserAccountService uaService)
        {
            m_UaService = uaService;

            // rules
            RuleFor(login => login.ContactName).NotNull()
                .Must(ContactNameDoesNotExist)
                .WithMessage("The UserName already exists please enter another");

            RuleFor(login => login.EmailAddress1).NotNull()
                .Must(EmailAddressDoesNotExist)
                .WithMessage("The UserEmail address already exists please enter another");

        }

        private bool DoesAtLeastOneAddressExist(List<AddressDTO> list)
        {
            return list.Count > 0;
        }

        private bool IsAtLeastOneAddressMarkedAsPrimary(List<AddressDTO> list)
        {
            return list.Any(it => it.IsPrimaryAddress == true);
        }

        private bool EmailAddressDoesNotExist(string emailAddress1)
        {
            return !m_UaService.EmailExists(emailAddress1);
        }

        private bool ContactNameDoesNotExist(string contactName)
        {
            return !m_UaService.UsernameExists(contactName);
        }
    }
}
