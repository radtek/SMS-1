using System.Collections.Generic;

namespace Bec.TargetFramework.Data.Validation
{
    public interface IValidator
    {
        List<ValidationResult> Validate(object model);
    }
}