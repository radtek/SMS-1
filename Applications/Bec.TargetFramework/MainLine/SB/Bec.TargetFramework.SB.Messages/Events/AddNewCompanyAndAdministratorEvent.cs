using Bec.TargetFramework.Entities;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Messages.Events
{
    public class AddNewCompanyAndAdministratorEvent : IEvent
    {
        public TemporaryAccountDTO TemporaryAccountDto { get;set;}
        public VOrganisationWithStatusAndAdminDTO VOrganisationWithStatusAndAdminDto { get; set; }
    }
}
