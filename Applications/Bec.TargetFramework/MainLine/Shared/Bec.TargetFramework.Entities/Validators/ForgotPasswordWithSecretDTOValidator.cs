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
    public class ForgotPasswordWithSecretDTOValidator : BaseValidator<ForgotPasswordWithSecretDTO>
    {

        public ForgotPasswordWithSecretDTOValidator()
        {

            //VFieldDetailValidationForUIDTO dtoErr = FieldDetailsAndValidations.GetFieldDetailValidationMessage("Login", "TestValidation");

        }

        
    }
}
