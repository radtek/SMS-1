using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Collections.Concurrent;
using Bec.TargetFramework.Workflow.Interfaces;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class PaymentWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            //show without preauth payment screens
            bool HasUserPerformed = false;
            try
            {
                    //var responsedata = base.GetData<TransactionOrderPaymentDTO>(this.Data,
                    //   WorkflowDataEnum.TransactionOrderResponseData.GetStringValue());

                //following is some hardcoding for TS to work
                TransactionOrderPaymentDTO responsedata = new TransactionOrderPaymentDTO() { IsPaymentSuccessful = true};
                //based on some condition set HasUserPerformed true
                HasUserPerformed = responsedata.IsPaymentSuccessful == true && this.Data.ContainsKey("PayClicked") && this.Data["PayClicked"].Equals("true") ? true : false;
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                return false;
            }
            return HasUserPerformed;

            //return base.PerformExecuteCommands();
        }
    }
}
