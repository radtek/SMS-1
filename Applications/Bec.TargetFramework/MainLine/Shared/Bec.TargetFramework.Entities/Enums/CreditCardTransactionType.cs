using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.Enums
{
    public enum CreditCardTransactionType
    {
        /// <summary>
        /// credit
        /// </summary>
        credit = 0,
        
        /// <summary>
        /// forceTicket
        /// </summary>
        forceTicket = 10,

        /// <summary>
        /// postAuth
        /// </summary>
        postAuth = 20,

        /// <summary>
        /// preAuth
        /// </summary>
        preAuth = 30,

        /// <summary>
        /// return
        /// </summary>
        Return = 40,

        /// <summary>
        /// void
        /// </summary>
        Void = 50,


    }
}
