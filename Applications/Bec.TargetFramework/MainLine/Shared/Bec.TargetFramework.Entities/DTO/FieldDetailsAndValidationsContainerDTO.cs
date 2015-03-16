using Bec.TargetFramework.Entities;
using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.UI.Web.Base
{
    public class FieldDetailsAndValidationsContainerDTO
    {
        public FieldDetailsAndValidationsContainerDTO(FieldDetailsAndValidationsDTO dto)
        {
            this.FieldDetailsAndValidationDto = dto;
        }

        public FieldDetailsAndValidationsDTO FieldDetailsAndValidationDto { get; set; }

        public VFieldDetailValidationForUIDTO GetFieldDetailValidationMessage(string interfacePanelName, string validationName, int? organisationType = null, Guid? userType = null)
        {
            VFieldDetailValidationForUIDTO fdValidation = null;

            List<VFieldDetailValidationForUIDTO> feildDetailValidations = FieldDetailsAndValidationDto.FieldDetailValidationsForUI.ToList();

            var fdValidationQuery =
                feildDetailValidations.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false));

            if (organisationType == null)
                fdValidationQuery = fdValidationQuery.Where(s => !s.OrganisationTypeID.HasValue);
            else
                fdValidationQuery = fdValidationQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

            if (userType == null)
                fdValidationQuery = fdValidationQuery.Where(s => !s.UserTypeID.HasValue);
            else
                fdValidationQuery = fdValidationQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


            fdValidation = fdValidationQuery.SingleOrDefault(x => x.Name.Equals(interfacePanelName) && x.InterfacePanelFieldDetailValidationName.Equals(validationName));

            Ensure.Argument.NotNull(fdValidation, (interfacePanelName + ":" + validationName));

            return fdValidation;
        }

        public List<VFieldDetailValidationForUIDTO> GetInterfacePanelFieldDetailValidations(string interfacePanelName)
        {
            List<VFieldDetailValidationForUIDTO> fdValidation = null;

            List<VFieldDetailValidationForUIDTO> feildDetailValidations = FieldDetailsAndValidationDto.FieldDetailValidationsForUI.ToList();

            var fdValidationQuery =
                feildDetailValidations.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false));

            fdValidation = fdValidationQuery.Where(x => x.Name.Equals(interfacePanelName)).ToList();

            Ensure.Argument.NotNull(fdValidation, interfacePanelName);

            return fdValidation;
        }
        public VInterfacePanelValidationForUIDTO GetInterfacePanelValidationMessage(string interfacePanelName, string validationName, int? organisationType = null, Guid? userType = null)
        {
            VInterfacePanelValidationForUIDTO ipValidation = null;

            List<VInterfacePanelValidationForUIDTO> interfacePanelValidations = FieldDetailsAndValidationDto.InterfacePanelValidationsForUI.ToList();

            var ipValidationQuery = interfacePanelValidations.Where(s => s.IsActive.HasValue && s.IsDeleted.HasValue && s.IsActive.Value.Equals(true) && s.IsDeleted.Value.Equals(false));

            if (organisationType == null)
                ipValidationQuery = ipValidationQuery.Where(s => !s.OrganisationTypeID.HasValue);
            else
                ipValidationQuery = ipValidationQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

            if (userType == null)
                ipValidationQuery = ipValidationQuery.Where(s => !s.UserTypeID.HasValue);
            else
                ipValidationQuery = ipValidationQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


            ipValidation = ipValidationQuery.SingleOrDefault(x => x.Name.Equals(interfacePanelName) && x.ValidationName.Equals(validationName));

            Ensure.Argument.NotNull(ipValidation,(interfacePanelName+ ":" + validationName));

            return ipValidation;
        }

        public VFieldDetailForUIDTO GetFieldDetail(string interfacePanelName, string fieldDetailName, int? organisationType = null, Guid? userType = null)
        {
            VFieldDetailForUIDTO field = null;

            List<VFieldDetailForUIDTO> fieldDetails = FieldDetailsAndValidationDto.FieldDetailsForUI.ToList();

            var fieldQuery = fieldDetails.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));

            if (organisationType == null)
                fieldQuery = fieldQuery.Where(s => !s.OrganisationTypeID.HasValue);
            else
                fieldQuery = fieldQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

            if (userType == null)
                fieldQuery = fieldQuery.Where(s => !s.UserTypeID.HasValue);
            else
                fieldQuery = fieldQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


            field = fieldQuery.SingleOrDefault(s => s.InterfacePanelName.Equals(interfacePanelName)
                                                            && s.Name.Equals(fieldDetailName));

            return field;
        }

        public VInterfacePanelForUIDTO GetInterfacePanelDetails(string interfacePanelName, int? organisationType = null, Guid? userType = null)
        {
            VInterfacePanelForUIDTO interfacePanel = null;

            List<VInterfacePanelForUIDTO> interfacePanels = FieldDetailsAndValidationDto.InterfacePanelForUI.ToList();

            var interfacePanelQuery = interfacePanels.Where(s => s.IsActive.Equals(true) && s.IsDeleted.Equals(false));

            if (organisationType == null)
                interfacePanelQuery = interfacePanelQuery.Where(s => !s.OrganisationTypeID.HasValue);
            else
                interfacePanelQuery = interfacePanelQuery.Where(s => s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationType.Value));

            if (userType == null)
                interfacePanelQuery = interfacePanelQuery.Where(s => !s.UserTypeID.HasValue);
            else
                interfacePanelQuery = interfacePanelQuery.Where(s => s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userType.Value));


            interfacePanel = interfacePanelQuery.SingleOrDefault(s => s.Name.Equals(interfacePanelName));

            return interfacePanel;
        }
    }
}