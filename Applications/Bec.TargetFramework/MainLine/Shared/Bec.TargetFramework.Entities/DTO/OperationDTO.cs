using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
  
    public partial class OperationDTO
    {
        //[Required(ErrorMessage = "Please Enter an Operation Name")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Operation Name")]
        ////[Remote("CheckOperationName", "ReferenceData", "Admin")]
        //[DataMember]
        //public string OperationName { get; set; }

        //[DataMember]
        //public Guid OperationID { get; set; }

        [DataMember]
        public bool OperationSelected { get; set; }

        //[DataMember]
        //[Display(Name = "Operation Description")]
        //public string OperationDescription { get; set; }

        //[DataMember]
        //public bool IsActive { get; set; }

        //[DataMember]
        //public bool IsDeleted { get; set; }
    }
}
