using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.UI.Web.Helpers;

namespace Bec.TargetFramework.UI.Web.Areas.SafeTransactionSearch.Helpers
{
    public class FirmDetailHelper
    {
        public static FirmDetailsDTO InitializeFirmDetailsDTOAndSetupSessionObjects()
        {
            var dto = new FirmDetailsDTO();

            // add trading names list to state object
         //   WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("ClientAccounts", new List<ClientAccountDTO>()); //Commented as list giving error on traversal and adding this to session state
            //   WorkflowSessionHelper.AddOrReplaceWorkflowStateDataItemFromSessionUsingKey("TradingNames", new List<TradingNameDTO>());//Commented as list giving error on traversal and adding this to session state

            return dto;
        }
    }
}