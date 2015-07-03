using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace Bec.TargetFramework.Infrastructure
{
    public class UserNameService
    {
        public UserNameService()
        {
            UserName = "System";
        }
        public string UserName { get; set; }
        internal void GetUserName(ApiController controller)
        {
            IEnumerable<string> values;
            if (controller.Request !=null && controller.Request.Headers.TryGetValues("User", out values)) UserName = values.First();
        }
    }
}
