using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{

    public enum NotificationConstructEnum : int
    {
        [StringValue("ConveyancyEmployeeNextSteps")]
        ConveyancyEmployeeNextSteps = 1,
        [StringValue("ColpRegistration")]
        ColpRegistration = 2,
        [StringValue("ScpFirmApproval")]
        ScpFirmApproval = 3,
        [StringValue("ColpNextSteps")]
        ColpNextSteps = 4,
        [StringValue("ExternalNotification")]
        ExternalNotification = 5,
        [StringValue("ExternalBatchNotification")]
        ExternalBatchNotification = 6,
        [StringValue("ForgotPassword")]
        ForgotPassword = 7,
        [StringValue("ForgotUsername")]
        ForgotUsername = 8,
        [StringValue("OnlinePaymentReceipt")]
        OnlinePaymentReceipt = 9,
    }
}
