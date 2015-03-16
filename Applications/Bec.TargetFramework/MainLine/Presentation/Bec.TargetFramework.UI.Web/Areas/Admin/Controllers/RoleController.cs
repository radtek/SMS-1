using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Web.Framework.Helpers;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Web.Framework.Extensions;
using Fabrik.Common;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class RoleController : ApplicationControllerBase
    {
        private IRoleLogic m_RoleLogic;

        public RoleController(ILogger logger, IRoleLogic logic) : base(logger)
        {
            m_RoleLogic = logic;
        }

        // GET: /Admin/Role/
        public ActionResult RoleManagement(string containerId)
        {
            Ensure.NotNullOrEmpty(containerId);

            return this.CreatePartialViewResult("RoleManagement"
                , containerId
                , new VRoleDTO());
        }

        public StoreResult GetRoles(StoreRequestParameters parameters, bool showDeleted)
        {
            Func<List<VRoleDTO>> funcList = () => { return m_RoleLogic.GetAllRoleDTO(showDeleted); };

            return this.Store(new GridPagingHelper<VRoleDTO>(funcList, "RoleName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            Ensure.NotNullOrEmpty(containerId);

            return this.CreatePartialViewResult("Add"
                , containerId
                , new RoleDTO());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(RoleDTO model,string containerId)
        {
            Ensure.NotNull(model);

            if (model != null && this.ModelState.IsValid)
            {
                var dtoList = new List<RoleClaimDescriptionDTO>();

                if (Request.Params["items"] != null)
                JSON.Deserialize<List<ListItem>>(Request.Params["items"]).ToList().ForEach(item
                    => dtoList.Add(new RoleClaimDescriptionDTO{RoleClaimValue = item.Value}));


                m_RoleLogic.SaveRole(model, dtoList);

                return RoleManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Edit(string id,string containerId)
        {
            Ensure.NotNullOrEmpty(id);

            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_RoleLogic.GetRoleDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(RoleDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dtoList = new List<RoleClaimDescriptionDTO>();

                if (Request.Params["items"] != null)
                    JSON.Deserialize<List<ListItem>>(Request.Params["items"]).ToList().ForEach(item
                        => dtoList.Add(new RoleClaimDescriptionDTO { RoleClaimValue = item.Value }));

                m_RoleLogic.SaveRole(model, dtoList);

                return RoleManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult GetClaimSourceItems(string id)
        {
            Guid rid =string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_RoleLogic.GetRoleClaimSourceItems(rid) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetAllRoles(string id)
        {

            return Json(new { data = m_RoleLogic.GetAllRoles() }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetClaimSourceItemsForRoleId(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_RoleLogic.GetClaimSourceItemsForRoleId(rid) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_RoleLogic.ActivateDeactivateRole(Guid.Parse(id));

            return this.Direct();
        }

        public virtual ActionResult Delete(string id)
        {
            m_RoleLogic.DeleteRole(Guid.Parse(id));

            return this.Direct();
        }
        #region Remote Validation

        public virtual JsonResult DoesRoleNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !(m_RoleLogic.DoesRoleNameExist(name));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}