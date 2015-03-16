
#region

using System;
using System.Linq.Expressions;

#endregion

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public static class ValidateIdExtension
    {
        public static Validation<TModel> ValidateId<TModel>(this Validator<TModel> validator, Expression<Func<TModel, object>> property)
        {
            return validator.AddValidation()
                            .SetProperty(property)
                            .SetValidater(model =>
                            {
                                int id;
                                int.TryParse(property.GetPropertyValue(model) as string, out id);
                                return id > 0;
                            })
                            .SetErrorMessage(string.Format("{0} is an invalid identifier", property.GetPropertyName()));
        }
    }
}