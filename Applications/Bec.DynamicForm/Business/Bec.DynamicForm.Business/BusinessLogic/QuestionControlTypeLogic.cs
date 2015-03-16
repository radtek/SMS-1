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
using Bec.DynamicForm.Infrastructure.Log;
using Bec.DynamicForm.Business.Logic;
namespace Bec.DynamicForm.Business
{
    public class QuestionControlType : LogicBase
    {
        public QuestionControlType(ILogger logger)
            : base(logger)
        {

        }
        public static int add(string controlTypeName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("questionControlTypeId", typeof(Int32));
                context.QuestionControlType_Insert(output, controlTypeName);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void update(Int32? questionControlTypeId, string questionControlTypeName)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionControlType_Update(questionControlTypeId, questionControlTypeName);
            }
        }
        public static void delete(Int32? questionControlTypeId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionControlType_Delete(questionControlTypeId);
            }
        }
        public static List<QuestionControlTypeDTO> get(int? questionControlTypeId)
        {
            List<QuestionControlTypeDTO> list = new List<QuestionControlTypeDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionControlType_Select(questionControlTypeId).ToList().ForEach(it =>
                {
                    var dto = new QuestionControlTypeDTO();
                    dto.InjectFrom(it);

                    list.Add(dto);
                });
            }
            return list;
        }
    }
}
