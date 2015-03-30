using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class vOrganisationDTO
    {
        [DataMember]
        public Guid OrganisationID { get; set; }

        [DataMember]
        public string OrganisationTypeName { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public string OrganisationCategoryName { get; set; }

        [DataMember]
        public Nullable<int> OrganisationCategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]

        public vAttachmentDTO vAttachment { get; set; }

        public vOrganisationDTO()
        {
            vAttachment = new vAttachmentDTO();
            LogosJson = JsonSerializer.SerializeToString(new List<vAttachmentDTO>());
            UnitsJson = JsonSerializer.SerializeToString(new List<OrganisationUnitDTO>());
            BranchesJson = JsonSerializer.SerializeToString(new List<ContactDTO>());
            UsersJson = JsonSerializer.SerializeToString(new List<ContactDTO>());
        }

        [DataMember]
        public string LogosJson { get; set; }
        [DataMember]

        public string UnitsJson { get; set; }
        [DataMember]

        public string BranchesJson { get; set; }
        [DataMember]

        public string UsersJson { get; set; }

        [DataMember]
        public Nullable<System.Guid> OrganisationDefaultLogoID { get; set; }

        [DataMember]
        public Nullable<bool> IsBranch { get; set; }

        [DataMember]
        public Nullable<bool> IsHeadOffice { get; set; }

        [DataMember]
        public Nullable<bool> IsActive { get; set; }

        [DataMember]
        public Nullable<bool> IsDeleted { get; set; }


        public string SearchQuery { get; set; }

        public vOrganisationDTO RowObject
        {
            get
            {
                return new vOrganisationDTO();
            }
        }

    }
}
