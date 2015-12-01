using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class ConversationDetailsDTO
    {
        public Guid ConversationID { get; set; }
        public string Subject{ get; set; }
        public MessageDetailsDTO FirstUnread { get; set; }
        public MessageDetailsDTO MostRecent { get; set; }
    }

    [Serializable]
    public class MessageDetailsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateSent{ get; set; }
        public string Message { get; set; }
    }
}
