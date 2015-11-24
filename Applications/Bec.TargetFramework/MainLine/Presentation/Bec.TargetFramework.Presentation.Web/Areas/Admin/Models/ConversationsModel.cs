using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Models
{
    public class ConversationsModel
    {
        public bool IsActivitySpecific { get; set; }
        public List<Guid> ParticipantUaoIds { get; set; }
    }
}