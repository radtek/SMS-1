using Bec.DynamicForms.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bec.DynamicForms.ServiceLayer
{
    public class AnswerManager
    {
        public static long Add(long? questionId, int formId, int sectionId, int versionId, long OrderId, int ClientId, string answerText, string choiceAnswered, string choiceText, string iPAddress, string createdBy)
        {
            return AnswersDAL.Add( questionId,  formId,  sectionId,  versionId,  OrderId,  ClientId,  answerText,  choiceAnswered,  choiceText,  iPAddress,  createdBy);

        }
        public static long saveFileName(long? questionId, int formId, int sectionId, int versionId, long OrderId, int ClientId, string uploadLink, string iPAddress, string createdBy)
        {
            return AnswersDAL.saveFileName( questionId,  formId,  sectionId,  versionId,  OrderId,  ClientId,  uploadLink,  iPAddress,  createdBy);
        }


        public static List<Answer> Select(long? OrderId, int? ClientId, int sectionId, int formId)
        {
            return AnswersDAL.Select( OrderId, ClientId,  sectionId,  formId);
        }

        public static int AddDocumentLog(int? formId, long? orderId, Int32? clientId, string status, Guid? userId, string rejectionReason, DateTime? dateCreated)
        {
            return AnswersDAL.Add(formId, orderId, clientId, status, userId, rejectionReason, dateCreated);
        }

        public static List<DocumentStatusLog> SelectDocumentLog(int? formId, long? orderId)
        {
            return AnswersDAL.SelectDocumentLog(formId, orderId);
        }
        public static DocumentStatusLog SelectDocumentLog(int? documentStatusLogId)
        {
            return AnswersDAL.SelectDocumentLog(documentStatusLogId);
        }
        public static string SelectDocumentStatusCode(int? formId, long? orderId)
        {
            return AnswersDAL.SelectDocumentStatusCode(formId, orderId);
        }

        
    }
}
