using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class AddHelpDTO
    {
        [DataMember]
        public Guid HelpID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int HelpTypeID { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string UiPageUrl { get; set; }
         [DataMember]
        public Guid TempStoreID { get; set; }
         [DataMember]
         public IEnumerable<AddHelpItemDTO> HelpItems { get; set; }
        [DataMember]
         public string CreatedBy { get; set; }
        [DataMember]
         public DateTime CreatedOn { get; set; }
        [DataMember]
         public string ModifiedBy { get; set; }
        [DataMember]
         public DateTime? ModifiedOn { get; set; }
    }
}
