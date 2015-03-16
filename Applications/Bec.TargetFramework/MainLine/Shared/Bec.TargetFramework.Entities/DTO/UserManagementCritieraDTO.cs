using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    public class UserManagementCritieraDTO
    {
        [DataMember]
        public Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public Nullable<System.Guid> BranchID { get; set; }

        [DataMember]
        public Nullable<int> OrganisationUnitID { get; set; }

        [DataMember]
        public string[] UserTypeID { get; set; }

        [DataMember]
        public string[] UserCategoryID { get; set; }

        public List<PropertyInfo> SearchQueryTargetProperties { get; set; }

        public string SearchQuery { get; set; }

        public vUserManagementDTO RowObject
        {
            get
            {
                return new vUserManagementDTO();
            }
        }
    }
}
