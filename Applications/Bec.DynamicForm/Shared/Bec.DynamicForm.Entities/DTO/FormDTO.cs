
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bec.DynamicForm.Entities.DTO
{
    [DataContract]
    [Serializable]
    public class FormDTO
    {
        public FormDTO()
        {

        }

         [DataMember]
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Form name")]
        [DataMember]
        public string FormName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Form Description")]
        [DataMember]
        public string FormDescription { get; set; }       
        [System.ComponentModel.DataAnnotations.Display(Name = "isActive")]
        [DataMember]
        public Boolean isActive { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentId")]
        [DataMember]
        public int ParentId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormTypeId")]
        [DataMember]
        public int FormTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Versionid")]
        [DataMember]
        public int Versionid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "isActiveStatus")]
        [DataMember]
        public string isActiveStatus {
            get
            {
                if (isActive)
                    return "Active";
                return "InActive";
            }
        }
      
        
    }
}