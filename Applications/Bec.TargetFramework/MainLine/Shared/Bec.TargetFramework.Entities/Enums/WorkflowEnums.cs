using Bec.TargetFramework.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum WorkflowDataEnum : int
    {
        [StringValue("TemporaryAccountDTO")]
        TemporaryAccountData = 1,
        [StringValue("RegistrationDTO")]
        RegistrationData = 2,
        [StringValue("PermanentAccountData")]
        PermanentAccountData = 3,
        [StringValue("TreeStructureVisibilityData")]
        TreeStructureVisibilityData = 4,
        [StringValue("FirmUserData")]
        FirmUserData = 5,
        [StringValue("PersonalDetailData")]
        PersonalDetailData = 6,
        [StringValue("FirmDetailData")]
        FirmDetailData = 7,
        [StringValue("WorkflowState")]
        WorkflowState = 8,
        [StringValue("NextStepsData")]
        NextStepsData = 9,
        [StringValue("FirmPreferenceData")]
        FirmPreferenceData = 10,
        [StringValue("FirmProductData")]
        FirmProductData = 11,
        [StringValue("PaymentData")]
        PaymentData = 12,
        [StringValue("FirmDetailUserData")]
        FirmDetailUserData = 13,
        [StringValue("TermsnConditionsData")]
        TermsnConditionsData = 14,
        [StringValue("UserAccountOrganisationData")]
        UserAccountOrganisationData = 15,
        [StringValue("TransactionOrderResponseData")]
        TransactionOrderResponseData = 16
    }

    public enum WorkflowEnum : int
    {
        [StringValue("Login")]
        LoginWorkflow = 1,
        [StringValue("Registration")]
        RegistrationWorkflow = 2
    }

    public enum WorkflowClickEnum : int
    {
        [StringValue("NextClicked")]
        NextClicked = 1
    }
}
