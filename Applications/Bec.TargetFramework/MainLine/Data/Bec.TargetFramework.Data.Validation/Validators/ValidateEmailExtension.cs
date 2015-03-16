
#region

using System;
using System.Linq.Expressions;

#endregion

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public static class ValidateEmailExtension
    {
        public static Validation<TModel> ValidateEmail<TModel>(this Validator<TModel> validator, Expression<Func<TModel, object>> property)
        {
            return validator.ValidateRegex(property)
                            .SetPattern(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            .SetErrorMessage(string.Format("{0} is not a valid IP Address", property.GetPropertyName()));
        }
    }
}