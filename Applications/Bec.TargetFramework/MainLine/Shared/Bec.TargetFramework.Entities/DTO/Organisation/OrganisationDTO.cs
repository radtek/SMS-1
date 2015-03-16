using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    
    public partial class OrganisationDTO
    {

 
        public OrganisationDetailDTO Detail { get; set; }
        [DataMember]
        
        public ContactDTO BranchContact { get; set; }
        [DataMember]
        
        public ContactDTO AdminUserContact { get; set; }

        [DataMember]
        public List<GroupDTO> SelectedGroups { get; set; }
        [DataMember]
        public List<RoleDTO> SelectedRoles { get; set; }
        [DataMember]
        public List<ExternalGroupTemplateDTO> SelectedExternalGroupTemplates { get; set; }
        [DataMember]
        public List<ExternalRoleTemplateDTO> SelectedExternalRoleTemplates { get; set; }

        [DataMember]

        public string SelectedGroupTemplatesJson { get; set; }
        [DataMember]

        public string SelectedRoleTemplatesJson { get; set; }
        [DataMember]

        public string SelectedExternalGroupTemplatesJson { get; set; }
        [DataMember]

        public string SelectedExternalRoleTemplatesJson { get; set; }

        //public OrganisationDTO()
        //{
        //    Detail = new OrganisationDetailDTO();
        //    IsBranch = true;
        //    BranchContact = new ContactDTO();
        //    AdminUserContact = new ContactDTO();
        //    UnitsJson = JsonSerializer.SerializeToString(new List<OrganisationUnitDTO>());
        //    BranchesJson = JsonSerializer.SerializeToString(new List<ContactDTO>());
        //    UsersJson = JsonSerializer.SerializeToString(new List<ContactDTO>());
        //    SelectedRoles = new List<RoleDTO>();
        //    SelectedRoleTemplatesJson = JsonSerializer.SerializeToString(new List<RoleTemplateDTO>());
        //    SelectedGroups = new List<GroupDTO>();
        //    SelectedExternalRoleTemplates = new List<ExternalRoleTemplateDTO>();
        //    SelectedExternalGroupTemplates = new List<ExternalGroupTemplateDTO>();

        //}
        [DataMember]
        
        public string UnitsJson { get; set; }
        [DataMember]

        public string BranchesJson { get; set; }
        [DataMember]

        public string UsersJson { get; set; }
       
        [DataMember]
        public List<ContactDTO> Branches { get; set; }

        [DataMember]
        public List<OrganisationUnitDTO> Units { get; set; }

        [DataMember]
        public List<ContactDTO> Users { get; set; }

    }
}
