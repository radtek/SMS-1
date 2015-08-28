using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Business.Models
{
    public class ValidationModel
    {
        public ValidationModel(Bec.DynamicForm.Data.ValidationType obj)
        {
            Bec.DynamicForm.Business.Util.CopyToNew(obj, this);
        }
        public ValidationModel()
        {

        }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationId")]
        public int ValidationId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ValidationTypeName")]
        public string ValidationTypeName { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Expression")]
        public string Expression { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Format")]
        public string Format { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "ErrorMessage")]
        public string ErrorMessage { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Selected")]
        public bool Selected { get; set; }
    }
}
