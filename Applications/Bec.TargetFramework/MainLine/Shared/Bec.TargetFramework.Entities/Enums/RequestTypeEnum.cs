using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum RequestType : int
    {
        [StringValue("Product Offering")]
        ProductOffering = 1,
        [StringValue("Safe Buyer Results")]
        SafeBuyerResults = 2,
        [StringValue("Safe Send")]
        SafeSend = 3,
        [StringValue("Pin Generation")]
        PinGeneration = 4,
        [StringValue("Bank Account Verification")]
        BankAccountVerification = 5,
        [StringValue("User Management")]
        UserManagement = 6,
        [StringValue("Performance Issues")]
        PerformanceIssues = 7
    }
}
