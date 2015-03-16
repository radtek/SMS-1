using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.DataAccess
{
    public class AnswersDAL
    {
        public static long Add(long? questionId, int formId, int sectionId, int versionId, long OrderId, int ClientId, string answerText, string choiceAnswered, string choiceText, string iPAddress, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("answerid", typeof(Int32));
                context.Answers_Insert(output, questionId, OrderId, ClientId, answerText, versionId, choiceAnswered, iPAddress, sectionId, createdBy, choiceText, formId);                
                return Convert.ToInt64(output.Value);
            }
        }
        public static long saveFileName(long? questionId, int formId, int sectionId, int versionId, long OrderId, int ClientId, string uploadLink, string iPAddress, string createdBy)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("answerid", typeof(Int32));
                context.Answers_UpdateUploadFile(output, questionId, OrderId, ClientId, versionId, uploadLink, iPAddress, sectionId, createdBy, formId);
                return Convert.ToInt64(output.Value);
            }
        }


        public static List<Answer> Select(long? OrderId, int? ClientId, int sectionId, int formId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<Answer> obj = context.Answers_Select(OrderId, ClientId, sectionId, formId).ToList();// questionId, OrderId, ClientId, versionId, uploadLink, iPAddress, sectionId, createdBy, formId).ToList();
                return obj;
            }
        }

        public static int Add(int? formId, long? orderId, Int32? clientId, string status, Guid? userId, string rejectionReason, DateTime? dateCreated)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("documentStatusLogId", typeof(Int32));
                context.DocumentStatusLog_Insert(output, formId, orderId, clientId, status, userId, rejectionReason, dateCreated);

                return Convert.ToInt32(output.Value);
            }
        }

        public static List<DocumentStatusLog> SelectDocumentLog(int? formId, long? orderId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<DocumentStatusLog> obj = context.DocumentStatusLog_GetList(formId, orderId).ToList();
                return obj;
            }
        }
        public static DocumentStatusLog SelectDocumentLog(int? documentStatusLogId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                List<DocumentStatusLog> obj = context.DocumentStatusLog_Get(documentStatusLogId).ToList();
                if (obj.Count > 0)
                    return obj[0];
                return null;
            }
        }
        public static string SelectDocumentStatusCode(int? formId, long? orderId)
        {
            using (var context = new DynamicFormDBEntities())
            {
                ObjectParameter output = new ObjectParameter("status", typeof(String));
                int obj = context.DocumentStatusLog_GetCurrentStatus(output, formId, orderId);
                return output.Value.ToString();
            }
        }

        
    }
}
