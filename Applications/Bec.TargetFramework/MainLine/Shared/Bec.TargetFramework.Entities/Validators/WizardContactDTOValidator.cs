using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ServiceStack.Text;
using BrockAllen.MembershipReboot;

namespace Bec.TargetFramework.Entities.Validators
{
    public class WizardContactDTOValidator : AbstractValidator<ContactDTO>
    {
        private UserAccountService m_UaService;
        private List<ContactDTO> m_BranchList;

        public WizardContactDTOValidator(UserAccountService uaService
            ,List<AddressDTO> addressList)
        {
            m_UaService = uaService;

            // rules
            RuleFor(login => login.ContactName).NotNull()
                .Must(ContactNameDoesNotExist)
                .WithMessage("The username already exists please enter another");

            RuleFor(login => login.EmailAddress1).NotNull()
                .Must(EmailAddressDoesNotExist)
                .WithMessage("The email address 1 already exists please enter another");

            RuleFor(login => addressList).NotNull()
                .Must(DoesAtLeastOneAddressExist)
                .WithMessage("At least one Address must be added");

            RuleFor(login => addressList).NotNull()
                .Must(IsAtLeastOneAddressMarkedAsPrimary)
                .WithMessage("At least one Address must be marked as Primary");
        }

        public WizardContactDTOValidator(List<ContactDTO> branchList, List<AddressDTO> addressList)
        {
            m_BranchList = branchList;

            RuleFor(login => login.ContactName).NotNull()
                .Must(IsTheBranchNameUnique)
                .WithMessage("The branch name already exists, please enter another");

            RuleFor(login => addressList).NotNull()
                .Must(DoesAtLeastOneAddressExist)
                .WithMessage("At least one Address must be added");
    

            RuleFor(login => addressList).NotNull()
                .Must(IsAtLeastOneAddressMarkedAsPrimary)
                .WithMessage("At least one Address must be marked as Primary");

            //RuleFor(login => branchList).NotNull()
            //    .Must(IsAtLeastOneBranchMarkedAsHeadOffice)
            //    .WithMessage("At least one branch must be marked as the Head Office");

            //RuleFor(login => branchList).NotNull()
            //    .Must(OnlyOneBranchMarkedAsHeadOffice)
            //    .WithMessage("Only one branch can be marked as the Head Office");
        }

        private bool DoesAtLeastOneAddressExist(List<AddressDTO> list)
        {
            return list.Count > 0;
        }

        private bool OnlyOneBranchMarkedAsHeadOffice(ContactDTO dto, List<ContactDTO> branchList)
        {
            bool valid = true;

            if(dto.IsHeadOffice &&
                (branchList.Where(it => !it.ContactID.Equals(dto.ContactID) && it.IsHeadOffice).ToList().Count > 0))
                valid = false;
            else if(!dto.IsHeadOffice &&
                branchList.Where(it => !it.ContactID.Equals(dto.ContactID) && it.IsHeadOffice).ToList().Count > 1)
                valid = false;
            
            return valid;
        }

        private bool IsAtLeastOneBranchMarkedAsHeadOffice(ContactDTO dto, List<ContactDTO> branchList)
        {
            return (dto.IsHeadOffice || branchList.Any(it => !it.ContactID.Equals(dto.ContactID) && it.IsHeadOffice));
        }

        private bool IsTheBranchNameUnique(ContactDTO dto,string contact)
        {
            return !m_BranchList.Any(it => !it.ContactID.Equals(dto.ContactID) && it.ContactName.Equals(contact));
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
