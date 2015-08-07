using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Handlers.Base;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Messages.Commands;
using Bec.TargetFramework.SB.Messages.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Bec.TargetFramework.SB.TaskHandlers.EventHandlers
{
    public class CreditTopUpHandler : BaseEventHandler<CreditTopUpEvent>
    {
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public IOrganisationLogicClient orgClient { get; set; }

        public CreditTopUpHandler()
        {
        }


        public override void HandleMessage(Messages.Events.CreditTopUpEvent handlerEvent)
        {
            try 
            {
                orgClient.AddCredit(handlerEvent.CreditTopUpEventDto.TransactionOrderID, handlerEvent.CreditTopUpEventDto.Amount);
                LogMessageAsCompleted();
            }
            catch (System.Exception ex)
            {
                // log error
                LogError("Boo", ex, NServiceBusHelper.GetBusMessageDto(Bus.CurrentMessageContext.Headers).EventReference);
                throw;
            }
        }
    }
}
