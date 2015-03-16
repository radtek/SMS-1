using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum TFEventEnum : int
    {
        UserLoginTFEvent=0,
        [StringValue("RegistrationCompletedEvent")]
        RegistrationCompletedEvent=1,
        [StringValue("CreateLoginCompletedEvent")]
        CreateLoginCompletedEvent=2,
        [StringValue("TemporaryAccountCreatedEvent")]
        TemporaryAccountCreatedEvent=3,
        [StringValue("ForgottenUsernamePasswordEvent")]
        ForgottenUsernamePasswordEvent = 4
    }

}
