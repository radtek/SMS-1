using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummaryPoll21;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using Serilog.Web.Extensions.Enrichers;

namespace Bec.TargetFramework.Service.LR.Entities.Objects
{
    public class OfficialCopyWithSummaryPollServiceDefinition21 : LRServiceDefinitionBase
    {
        public override object CreateAndInitialiseRequest(ConcurrentDictionary<string, object> objectDictionary)
        {
            var requestDto = objectDictionary["LRServiceRequestDTO"] as LRServiceRequestDTO;

            var request = new OfficialCopyWithSummaryPoll21.PollRequestType();

            request.ID = new Q1IdentifierType();
            request.ID.MessageID = new MessageIDTextType();

            return request;
        }

        public override Type ServiceClientType
        {
            get { return typeof(OCWithSummaryV2_1PollServiceClient); }
        }
    }
}
