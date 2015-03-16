using Bec.DynamicForm.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bec.DynamicForm.Entities.DTO
{
     [DataContract]
    public class FormSectionDTO: ITreeNode<FormSectionDTO>
    {
        public FormSectionDTO()
        {
            
        }        
       
        [System.ComponentModel.DataAnnotations.Display(Name = "FormSectionId")]
        [DataMember]
        public int FormSectionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormId")]
        [DataMember]
        public int FormId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionName")]
        [DataMember]
        public string SectionName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionNo")]
        [DataMember]
        public int SectionNo { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "SectionDescription")]
        [DataMember]
        public string SectionDescription { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "FormSectionParentId")]
        [DataMember]
        public int FormSectionParentId { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "HasChild")]
        [DataMember]
        public bool HasChild {
            get
            {
                if (Children != null && Children.Count() > 0)
                    return true;
                return false;
            }
        }


          [DataMember]
        public int Id
        {
            get { return FormSectionId; }
        }
          [DataMember]
        public FormSectionDTO Parent
        {
            get;
            set;
        }
          [DataMember]
        public IList<FormSectionDTO> Children
        {
            get;
            set;
            
        }
    }
}