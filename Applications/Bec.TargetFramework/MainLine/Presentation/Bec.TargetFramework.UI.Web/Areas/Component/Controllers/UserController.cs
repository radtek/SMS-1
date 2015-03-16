using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Bec.TargetFramework.Entities
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Web.Framework.Extensions;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class UserController : ApplicationControllerBase
    {
        private IUserLogic m_UserLogic;

        public UserController(IUserLogic logic, ILogger logger)
            : base(logger)
        {
            m_UserLogic = logic;
        }

        public StoreResult GetUsers(StoreRequestParameters parameters)
        {
            Func<List<UserDetailDTO>> funcList = () => { return m_UserLogic.GetAllUserDetailDTO(); };

            return this.Store(new GridPagingHelper<UserDetailDTO>(funcList, "Name").GetPaging(parameters));
        }

        public ActionResult UserManagement(string containerId)
        {
            return this.CreatePartialViewResult("UserManagement"
                , containerId
                , new UserDetailDTO());
        }

 
    }
}