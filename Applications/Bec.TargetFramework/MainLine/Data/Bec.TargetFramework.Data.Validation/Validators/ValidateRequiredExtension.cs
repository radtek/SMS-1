
#region

using System;
using System.Linq.Expressions;

#endregion

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public static class ValidateRequiredExtension
    {
        public static Validation<TModel> ValidateRequired<TModel>(this Validator<TModel> validator, Expression<Func<TModel, object>> property)
        {
            return validator.AddValidation()
                            .SetProperty(property)
                            .SetValidater(model => !String.IsNullOrEmpty(property.GetPropertyValue(model) as string))
                            .SetErrorMessage(string.Format("{0} is a required identifier", property.GetPropertyName()));
        }
    }
}