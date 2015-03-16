#region
using System;
using System.Linq.Expressions;

#endregion

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public static class ValidateCreditCardExtension
    {
        public static Validation<TModel> ValidateCreditCard<TModel>(this Validator<TModel> validator, Expression<Func<TModel, object>> property)
        {
            return validator.ValidateRegex(property)
                            .SetPattern(@"^((\d{4}[- ]?){3}\d{4})$")
                            .SetErrorMessage(string.Format("{0} is not a valid credit card number", property.GetPropertyName()));
        }
    }
}