using Bec.TargetFramework.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum HelpTypeEnum
    {
        All = 1,
        Tour = 918291721,
        Callout = 918291722,
        [StringValue("Show Me How")]
        ShowMeHow = 918291723
    }

    public enum HelpPositionEnum
    {
        Top = 1278381271,
        Bottom = 1278381272,
        Left = 1278381273,
        Right = 1278381274
    }

    public enum RequestTypeID : int
    {
        [StringValue("Transaction")]
        Transaction = 680,
        [StringValue("Product Offering")]
        ProductOffering = 681,
        [StringValue("Safe Buyer Results")]
        SafeBuyerResults = 682,
        [StringValue("Safe Send")]
        SafeSend = 683,
        [StringValue("Pin Generation")]
        PinGeneration = 684,
        [StringValue("System Management")]
        SystemManagement = 685,
        [StringValue("Bank Account Verification")]
        BankAccountVerification = 686,
        [StringValue("User Management")]
        UserManagement = 687,
        [StringValue("Performance Issues")]
        PerformanceIssues = 688,
        [StringValue("Other")]
        Other = 689
    }
}
