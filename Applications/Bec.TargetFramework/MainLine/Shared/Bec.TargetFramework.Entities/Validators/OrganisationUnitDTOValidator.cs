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
    public class OrganisationUnitDTOValidator : AbstractValidator<OrganisationUnitDTO>
    {
        private List<OrganisationUnitDTO> m_UnitList;

        public OrganisationUnitDTOValidator(
            List<OrganisationUnitDTO> unitList)
        {
            m_UnitList = unitList;

            RuleFor(login => login.Name).NotNull()
                .Must(IsTheUnitNameUnique)
                .WithMessage("The unit name already exists, please enter another");
        }

        private bool IsTheUnitNameUnique(OrganisationUnitDTO unit,string name)
        {
            return !m_UnitList.Any(it => !it.OrganisationUnitID.Equals(unit.OrganisationUnitID) && it.Name.Equals(name));
        }

    }
}
