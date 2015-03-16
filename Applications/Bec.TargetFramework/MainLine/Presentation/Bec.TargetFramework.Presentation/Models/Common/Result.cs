using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Models
{
    public class Result
    {
        public object Data { get; set; }
        public bool IsSuccessfull { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}