using Bec.DynamicForm.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Bec.DynamicForm.Business.Logic;
using Bec.DynamicForm.Infrastructure.Log;
namespace Bec.DynamicForm.Data
{
    public class QuestionOptionLogic : LogicBase
    {
        public QuestionOptionLogic(ILogger logger)
            : base(logger)
        {

        }
       
        public static int add(string OptionText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("OptionId", typeof(Int32));
                context.QuestionOption_Insert(output, OptionText);
                return Convert.ToInt32(output.Value);
            }
        }
        public static void update(Int32? OptionId, string OptionText)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOption_Update(OptionId, OptionText);
            }
        }
        public static void delete(Int32? OptionId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOption_Delete(OptionId);
            }
        }
        public static List<QuestionOptionDTO> get(int? OptionId,long? QuestionId)
        {
          


            List<QuestionOptionDTO> list = new List<QuestionOptionDTO>();
            using (var context = new DynamicFormDBEntities())
            {
                context.QuestionOption_Select(OptionId, QuestionId).ToList().ForEach(it =>
                {
                    var dto = new QuestionOptionDTO();
                    dto.InjectFrom(it);
                    list.Add(dto);
                });
            }
            return list;
        }
     
    }
}
