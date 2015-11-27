using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    public class MessageDTO
    {
        public bool IsReadByCurrentUser { get; set; }
        public VMessageDTO Message { get; set; }
        public IEnumerable<VMessageReadDTO> Reads { get; set; }
    }
}
