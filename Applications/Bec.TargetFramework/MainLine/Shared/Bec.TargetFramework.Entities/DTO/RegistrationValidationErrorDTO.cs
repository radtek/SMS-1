using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    public class RegistrationValidationErrorDTO
    {
        public string ExistingFirmRegisteredName { get; set; }

        public string ExistingCOFirstName { get; set; }

        public string ExistingCOLastName { get; set; }

        public string ExistingCOEmail { get; set; }

        public bool HasError { get; set; }
    }
}
