#region
using System;

#endregion

namespace Bec.TargetFramework.Data.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(Type validator)
        {
            this.Validator = validator;
        }
        
        public Type Validator { get; private set; }
    }
}