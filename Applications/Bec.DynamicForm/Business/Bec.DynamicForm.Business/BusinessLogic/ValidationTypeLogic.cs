using Bec.DynamicForm.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bec.DynamicForm.Entities.DTO;
using Omu.ValueInjecter;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
namespace Bec.DynamicForm.Business
{
    public class ValidationTypeLogic: LogicBase
    {
        public ValidationTypeLogic(ILogger logger)
            : base(logger)
        {

        }
        public static int add(ValidationDTO validationType)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("ValidationTypeId", typeof(Int32));
                context.ValidationType_Insert(output, validationType.ValidationTypeName, validationType.Expression, validationType.Format, validationType.ErrorMessage);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void update(ValidationDTO validationType)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.ValidationType_Update(validationType.ValidationId, validationType.ValidationTypeName, validationType.Expression, validationType.Format, validationType.ErrorMessage);
            }
        }
        public static void delete(Int32? ValidationTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.ValidationType_Delete(ValidationTypeId);
            }
        }
        public static List<ValidationDTO> get(int? ValidationTypeId)
        {
            List<ValidationDTO> list = new List<ValidationDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.ValidationType_Select(ValidationTypeId).ToList().ForEach(it =>
                {
                    var dto = new ValidationDTO();
                    dto.InjectFrom(it);
                    list.Add(dto);
                });
            }
            return list;
        }
    }
}
