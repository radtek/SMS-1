using System;
using System.Collections.Generic;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class MessageDTO
    {
        public bool IsReadByCurrentUser { get; set; }
        public VMessageDTO Message { get; set; }
        public IEnumerable<VMessageReadDTO> Reads { get; set; }
        public IEnumerable<MessageFileDTO> Files { get; set; }
    }

    [Serializable]
    public class MessageFileDTO
    {
        public string Name { get; set; }
        public Guid FileID { get; set; }
        public Guid ParentID { get; set; }
        public string Link { get; set; }
    }
}
