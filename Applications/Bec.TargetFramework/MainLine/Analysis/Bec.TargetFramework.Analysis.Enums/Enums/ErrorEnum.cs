using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis.Enums
{
    [System.Serializable]
    public enum ErrorEnum
    {
        [Description("Lender not supplied in request")]
        ERR001,

        [Description("Domain not supplied in request")]
        ERR002,

        [Description("Mortgage application number not supplied in request")]
        ERR003,

        [Description("Lender supplied is not recognised")]
        ERR004,

        [Description("Domain supplied is not recognised")]
        ERR005,

        [Description("Transaction address not supplied in request")]
        ERR006,

        [Description("Buyer not supplied in request")]
        ERR007,

        [Description("Buyer name not supplied in request")]
        ERR008,

        [Description("Buyer address not supplied in request")]
        ERR009,

        [Description("Transaction section not supplied in request")]
        ERR010,

        [Description("Request is a null value")]
        ERR011,

        // Generic unhandled error
        ERR101,
    }
}
