using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
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
