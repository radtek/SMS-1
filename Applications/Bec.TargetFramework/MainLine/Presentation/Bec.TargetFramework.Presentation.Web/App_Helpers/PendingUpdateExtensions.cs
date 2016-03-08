using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Presentation.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.App_Helpers
{
    public static class PendingUpdateExtensions
    {
        public static async Task<PendingUpdateModel<TDto>> GetFieldUpdates<TDto>(this TDto model, HttpContextBase httpContext, ActivityType activityType, Guid activityID, IQueryLogicClient queryClient)
        {
            var activityTypeId = activityType.GetIntValue();
            await EnsureCanAccessFieldUpdates(httpContext, activityTypeId, activityID, false, queryClient);
            var select = ODataHelper.Select<FieldUpdateDTO>(x => new { x.FieldName, x.Value, x.ParentID, x.ParentType, x.ModifiedOn, x.UserAccountOrganisation.Contact.FirstName, x.UserAccountOrganisation.Contact.LastName });
            var filter = ODataHelper.Filter<FieldUpdateDTO>(x => x.ActivityType == activityTypeId && x.ActivityID == activityID);
            var resultPendingUpdates = await queryClient.QueryAsync<FieldUpdateDTO>("FieldUpdates", select + filter);
            var result = new PendingUpdateModel<TDto>
            {
                Dto = model,
                FieldUpdates = resultPendingUpdates
            };
            return result;
        }

        private static async Task EnsureCanAccessFieldUpdates(HttpContextBase httpContext, int activityType, Guid activityID, bool approveReject, IQueryLogicClient queryClient)
        {
            var orgId = WebUserHelper.GetWebUserObject(httpContext).OrganisationID;
            var uaoId = WebUserHelper.GetWebUserObject(httpContext).UaoID;

            switch ((ActivityType)activityType)
            {
                case ActivityType.SmsTransaction:
                    var selectTx = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID, users = x.SmsUserAccountOrganisationTransactions.Select(y => new { y.UserAccountOrganisationID }) });
                    var filterTx = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == activityID);
                    var resultTx = (await queryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", selectTx + filterTx)).Single();
                    if (approveReject)
                    {
                        if (resultTx.OrganisationID == orgId) return;
                    }
                    else
                    {
                        if (resultTx.OrganisationID == orgId || resultTx.SmsUserAccountOrganisationTransactions.Any(x => x.UserAccountOrganisationID == uaoId)) return;
                    }
                    break;
            }
            throw new AccessViolationException("Operation failed");
        }

    }
}