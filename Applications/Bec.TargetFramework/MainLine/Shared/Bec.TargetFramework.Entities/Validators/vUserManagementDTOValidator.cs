using Bec.TargetFramework.Entities;
using BrockAllen.MembershipReboot;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Validators
{
    class vUserManagementDTOValidator : AbstractValidator<vUserManagementDTO>
    {
        private UserAccountService m_UaService;
        private List<vUserManagementDTO> m_UserList;

        public vUserManagementDTOValidator(UserAccountService uaService, List<AddressDTO> addressList)
        {
            m_UaService = uaService;
           
            // rules
            RuleFor(login => login.Username).NotNull()
                .Must(ContactNameDoesNotExist)
                .WithMessage("The username already exists please enter another");

            RuleFor(login => login.Email).NotNull()
                .Must(EmailAddressDoesNotExist)
                .WithMessage("The email address 1 already exists please enter another");

            RuleFor(login => addressList).NotNull()
                .Must(DoesAtLeastOneAddressExist)
                .WithMessage("At least one Address must be added");

            RuleFor(login => addressList).NotNull()
                .Must(IsAtLeastOneAddressMarkedAsPrimary)
                .WithMessage("At least one Address must be marked as Primary");

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
