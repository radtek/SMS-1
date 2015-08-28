using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Bec.DynamicForm.Entities.DTO;
using Omu.ValueInjecter;
using System.Data.Entity;
namespace Bec.DynamicForm.Business
{
    public class FormManager
    {
        #region Add,Update and Select Form
        public static int addForm(FormDTO model)
        {
           return FormDAL.addForm(model.FormName, model.FormDescription, model.ParentId, model.FormTypeId, model.Versionid, model.isActive);
           
        }
        public static void updateForm(FormDTO model)
        {
            FormDAL.updateForm(model.FormId, model.FormName, model.FormDescription, model.ParentId, model.FormTypeId, model.Versionid, model.isActive);

            
        }
        public static void deleteForm(int? FormId)
        {
            FormDAL.deleteForm(FormId);            
        }
        public static List<FormDTO> selectForm(int? FormId)
        {
            List<FormDTO> list = new List<FormDTO>();
            FormDAL.selectForm(FormId).ToList().ForEach(it =>
            {
                var dto = new FormDTO();
                dto.InjectFrom(it);

                list.Add(dto);
            });
            
           
            return list;           
        }     

        #endregion
    }
}
