
#region

using System.Collections.Generic;

#endregion

namespace Bec.TargetFramework.Data.Validation
{
    public class Validator<TModel> : IValidator
    {
        private readonly List<ValidationResult> _validationResults;
        private readonly List<Validation<TModel>> _validations;
        
        public Validator()
        {
            this._validations = new List<Validation<TModel>>();
            this._validationResults = new List<ValidationResult>();
        }
        
        public List<ValidationResult> Validate(object model)
        {
            foreach (var validation in this._validations)
            {
                validation.OnValidating();
               
                var validater = validation.GetValidater();
                
                if (!validater((TModel)model))
                {
                    this._validationResults.Add(validation.GetValidationResult());
                }
            }
            
            return this._validationResults;
        }
        
        public Validation<TModel> AddValidation(Validation<TModel> validationRule)
        {
            this._validations.Add(validationRule);
            return validationRule;
        }
    }
}