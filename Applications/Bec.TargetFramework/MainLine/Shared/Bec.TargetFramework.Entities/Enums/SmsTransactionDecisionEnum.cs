using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum SmsTransactionDecisionEnum
    {
        All, Declined, Purchased
    }

    public enum SmsTransactionNoMatchEnum
    {
        All, None, Present
    }
}
