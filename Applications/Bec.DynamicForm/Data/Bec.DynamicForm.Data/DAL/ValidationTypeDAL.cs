using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.DynamicForm.Data
{
    public class ValidationTypeDAL
    {
        #region Add,update,Delete and Select ValidationType
        public static int addValidationType(string validationType, string expression, string format, string errorMessage)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("ValidationTypeId", typeof(Int32));
                context.ValidationType_Insert(output,validationType,expression,format,errorMessage);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void updateValidationType(Int32? ValidationTypeId, string validationType, string expression, string format, string errorMessage)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.ValidationType_Update(ValidationTypeId, validationType, expression, format, errorMessage);
            }
        }
        public static void deleteValidationType(Int32? ValidationTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.ValidationType_Delete(ValidationTypeId);
            }
        }
        public static List<ValidationType> SelectValidationType(int? ValidationTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<ValidationType> obj = context.ValidationType_Select(ValidationTypeId).ToList();
                return obj;

            }
        }
        #endregion
    }
}
