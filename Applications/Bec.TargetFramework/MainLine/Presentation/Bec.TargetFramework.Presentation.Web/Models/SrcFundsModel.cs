using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Models
{
    public class SrcFundsModel
    {
        public List<SmsSrcFundsBankAccountDTO> SmsSrcFundsBankAccounts { get; set; }
        public bool IsRequired { get; set;}
    }
}