using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Bec.TargetFramework.SB.Client.Clients;
using BusMessageContentDTO = Bec.TargetFramework.SB.Entities.BusMessageContentDTO;
using BusMessageDTO = Bec.TargetFramework.SB.Entities.BusMessageDTO;
using BusMessageStatusEnum = Bec.TargetFramework.SB.Entities.Enums.BusMessageStatusEnum;
using BusMessageTypeIDEnum = Bec.TargetFramework.SB.Entities.Enums.BusMessageTypeIDEnum;

namespace Bec.TargetFramework.SB.Tests
{
    [TestClass]
    public class SBServiceTests
    {
        [TestMethod]
        public void GetEventByNameTest()
        {
            using (var proxy = new BusLogicClient(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]))
            {
                var busEvent = proxy.GetBusEventByName("TestEvent");
            }
        }

        [TestMethod]
        public void SendNotificationEvent()
        {
            using (var proxy = new EventPublishLogicClient(ConfigurationManager.AppSettings["SBServiceBaseURL"]))
            {
                var tempAccountDto = new TemporaryAccountDTO
                {
                    EmailAddress = "c.misson@beconsultancy.co.uk",
                    UserName = "test",
                    Password = "test",
                    AccountExpiry = DateTime.Now.AddDays(5)
                };

                var registrationDto = new RegistrationDTO
                {
                    FirmRegisteredName = "Test Ltd",
                    FirmTradingName = "boo",
                    COFirstName = "Chris",
                    COLastName = "Misson"
                };
                var dictionary = new ConcurrentDictionary<string, object>();

                dictionary.TryAdd("TemporaryAccountDTO", tempAccountDto);
                dictionary.TryAdd("RegistrationDTO", registrationDto);

                //proxy.PublishEvent("TestEvent", AppDomain.CurrentDomain.FriendlyName, "Boo",
                //   new object[] {tempAccountDto, registrationDto});
            }
        }

        [TestMethod]
        public void SaveBusMessageTest()
        {
            using (var proxy = new BusLogicClient(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]))
            {
                var busMessageContent = new BusMessageContentDTO
                {
                    BusMessageContent1 = UTF8Encoding.UTF8.GetBytes("This is a test"),
                    BusMessageContentType = "Boo"

                };

                var busMessage = new BusMessageDTO
                {
                    MessageId = Guid.NewGuid(),
                    CorrelationId = Guid.NewGuid(),
                    ConversationId = Guid.NewGuid(),
                    EnclosedMessageTypes = "",
                    WinIdName = "Test",
                    ProcessingMachine = "Localhost",
                    BusMessageTypeID = BusMessageTypeIDEnum.Atomic.GetIntValue(),
                    BusMessageContents = new List<BusMessageContentDTO>()
                };

                busMessage.BusMessageContents.Add(busMessageContent);

                proxy.SaveBusMessage(BusMessageStatusEnum.Sent, "Test", "Test", false, busMessage);


            }
        }


        [TestMethod]
        public void SaveBusMessageViaClientBusLogicTest()
        {
            using (var proxy = new BusLogicClient(ConfigurationManager.AppSettings["BusinessServiceBaseURL"]))
            {
                var busMessageContent = new Bec.TargetFramework.SB.Entities.BusMessageContentDTO
                {
                    BusMessageContent1 = UTF8Encoding.UTF8.GetBytes("This is a test"),
                    BusMessageContentType = "Boo"

                };

                var busMessage = new Bec.TargetFramework.SB.Entities.BusMessageDTO
                {
                    MessageId = Guid.NewGuid(),
                    CorrelationId = Guid.NewGuid(),
                    ConversationId = Guid.NewGuid(),
                    EnclosedMessageTypes = "",
                    WinIdName = "Test",
                    ProcessingMachine = "Localhost",
                    BusMessageTypeID = Bec.TargetFramework.SB.Entities.Enums.BusMessageTypeIDEnum.Atomic.GetIntValue(),
                    BusMessageContents = new List<Bec.TargetFramework.SB.Entities.BusMessageContentDTO>()
                };

                busMessage.BusMessageContents.Add(busMessageContent);

                proxy.SaveBusMessage(Bec.TargetFramework.SB.Entities.Enums.BusMessageStatusEnum.Sent, "Test", "Test", false, busMessage);


            }
        }
    }
}
