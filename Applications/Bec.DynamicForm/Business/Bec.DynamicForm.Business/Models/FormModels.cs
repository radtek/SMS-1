using Bec.DynamicForm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.DynamicForm.Business.Models
{
    [Serializable]
    public class FormModels 
    {
        public FormModels()
        {

        }
        public FormModels(Bec.DynamicForm.Data.Form obj)
        {
            Bec.DynamicForm.Business.Util.CopyToNew(obj, this);
        }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "Form name")]
        public string FormName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Form Description")]
        public string FormDescription { get; set; }       
        [System.ComponentModel.DataAnnotations.Display(Name = "isActive")]
        public Boolean isActive { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentId")]
        public int ParentId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormTypeId")]
        public int FormTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Versionid")]
        public int Versionid { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "isActiveStatus")]
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