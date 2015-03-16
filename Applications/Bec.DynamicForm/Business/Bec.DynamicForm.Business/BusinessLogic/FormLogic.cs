using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Bec.DynamicForm.Entities.DTO;
using Omu.ValueInjecter;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
namespace Bec.DynamicForm.Business
{
    public class FormLogic : LogicBase
    {

        public FormLogic(ILogger logger): base(logger)
        {

        }
       
        public static int add(FormDTO model)
        {
           
           using (var context = new DynamicFormDBEntities())
           {
               ObjectParameter output = new ObjectParameter("formid", typeof(Int32));
               context.Form_Insert(output, model.FormName, model.FormDescription, model.ParentId, model.FormTypeId, model.Versionid, model.isActive);
               return Convert.ToInt32(output.Value);
           }
        }
        public static void update(FormDTO model)
        {
            
            using (var context = new DynamicFormDBEntities())
            {
                context.Form_Update(model.FormId, model.FormName, model.FormDescription, model.ParentId, model.FormTypeId, model.Versionid, model.isActive);
            }
            
        }
        public static void delete(int? FormId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.Form_Delete(FormId);

            }
            
        }
        public static List<FormDTO> get(int? FormId)
        {
            List<FormDTO> list = new List<FormDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.Form_Select(FormId).ToList().ForEach(it =>
                {
                    var dto = new FormDTO();
                    dto.InjectFrom(it);

                    list.Add(dto);
                });               

            }          
           
            return list;           
        }     

      
    }
}
