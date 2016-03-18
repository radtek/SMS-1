using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [Serializable]
    [DataContract]
    public class AddHelpItemDTO
    {
        [DataMember]
        public string HelpTypeName { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
  [DataMember]
        public Guid HelpItemID { get; set; }
        [DataMember]
        public string Selector { get; set; }
        [DataMember]
        public int? UiPosition { get; set; }

        [DataMember]
        public string UiPositionName { get; set; }

        [DataMember]
        public Guid HelpID { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime? ModifiedOn { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }


        [DataMember]
        public int? DisplayOrder { get; set; }
        [DataMember]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EffectiveFrom { get; set; }
        [DataMember]
        public string UiSelector { get; set; }
        [DataMember]
        public string UiSelectorParent { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
         [DataMember]
        public IEnumerable<RoleDTO> Roles { get; set; }
        [DataMember]
        public string[] SelectedRoles { get; set; }
        [DataMember]

        public List<string> SelectedRoleNames { get; set; }

        public Guid TempStoreID { get; set; }
    }
}
