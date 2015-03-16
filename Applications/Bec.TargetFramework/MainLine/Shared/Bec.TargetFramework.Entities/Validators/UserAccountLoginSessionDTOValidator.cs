using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Bec.TargetFramework.Entities.Validators
{
    public class UserAccountLoginSessionDTOValidator : AbstractValidator<UserAccountLoginSessionDTO>
    {
        public UserAccountLoginSessionDTOValidator()
        {
            // rules
            RuleFor(login => login.UserSessionID).NotNull().NotEqual(string.Empty);
            RuleFor(login => login.UserIPAddress).NotNull().NotEqual(string.Empty);
        }
    }
}
