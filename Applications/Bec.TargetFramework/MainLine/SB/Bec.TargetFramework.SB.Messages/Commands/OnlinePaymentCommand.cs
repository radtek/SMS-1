using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using NServiceBus;

namespace Bec.TargetFramework.SB.Messages.Commands
{

    public class OnlinePaymentCommand : ICommand
    {
        public ShoppingCartDTO ShoppingCartDto { get; set; }
        public VUserAccountOrganisationDTO VUserAccountOrganisationDto { get; set; }

        public OrderRequestDTO OrderRequestDto { get; set; }
    }
}
