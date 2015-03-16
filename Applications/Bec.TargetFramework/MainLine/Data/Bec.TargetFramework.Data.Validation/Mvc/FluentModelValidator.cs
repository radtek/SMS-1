#region
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace Bec.TargetFramework.Data.Validation.Mvc
{
    public class FluentModelValidator : ModelValidator
    {
        private readonly IValidator _validator;
        
        public FluentModelValidator(ModelMetadata metadata, ControllerContext controllerContext, IValidator validator) : base(metadata, controllerContext)
        {
            this._validator = validator;
        }
        
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            var validationResults = this._validator.Validate(Metadata.Model);
            
            return validationResults
                                    .Select(validationResult => new ModelValidationResult
                                           {
                                               MemberName = validationResult.PropertyName,
                                               Message = validationResult.ErrorMessage
                                           });
        }
    }
}