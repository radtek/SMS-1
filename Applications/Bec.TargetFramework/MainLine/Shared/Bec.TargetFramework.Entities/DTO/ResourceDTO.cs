using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Entities
{
 
    public partial class ResourceDTO
    {
        //[Required(ErrorMessage = "Please Enter a Resource Name")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Resource Name")]
        ////[Remote("CheckResourceName", "ReferenceData", "Admin")]
        //[DataMember]
        //public string ResourceName { get; set; }

        //[DataMember]
        //public Guid ResourceID { get; set; }

        [DataMember]
        public bool ResourceSelected { get; set; }

        //[DataMember]
        //[Display(Name = "Resource Description")]
        //public string ResourceDescription { get; set; }

        //[DataMember]
        //public List<OperationDTO> Operations { get; set; }

        //public ResourceDTO()
        //{
        //    Operations = new List<OperationDTO>();
        // }

        //[Display(Name = "Type")]
        //[DataMember]
        //public int? ResourceTypeID { get; set; }

        //[Display(Name = "Category")]
        //[DataMember]
        //public int? ResourceCategoryID { get; set; }

        //[Display(Name = "Sub Category")]

        //[DataMember]
        //public int? ResourceSubCategoryID { get; set; }


        [DataMember]
        public string SelectedOperations { get; set; }

        //[DataMember]
        //public bool IsActive { get; set; }

        //[DataMember]
        //public bool IsDeleted { get; set; }

    }
}
