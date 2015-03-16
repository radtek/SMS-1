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
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Fabrik.Common;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class GroupController : ApplicationControllerBase
    {
        private readonly IGroupLogic m_GroupLogic;

        public GroupController(ILogger logger, IGroupLogic logic)
            : base(logger)
        {
            m_GroupLogic = logic;
        }
        //
        // GET: /Admin/Group/
        public ActionResult GroupManagement(string containerId)
        {
            return this.CreatePartialViewResult("GroupManagement"
                , containerId
                , new VGroupDTO());
        }
                
        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_GroupLogic.ActivateDeactivateGroup(Guid.Parse(id));

            return this.Direct();
        }

        public StoreResult GetGroups(StoreRequestParameters parameters,bool showDeleted)
        {
            Func<List<VGroupDTO>> funcList = () => { return m_GroupLogic.GetAllGroupDTO(showDeleted); };

            return this.Store(new GridPagingHelper<VGroupDTO>(funcList, "GroupName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            return this.CreatePartialViewResult("Add"
                , containerId
                , new GroupDTO());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(GroupDTO model,string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dtoList = new List<GroupRoleDTO>();

                if (Request.Params["items"] != null)
                JSON.Deserialize<List<ListItem>>(Request.Params["items"]).ToList().ForEach(item
                    => dtoList.Add(new GroupRoleDTO{RoleValue = item.Value}));


                m_GroupLogic.SaveGroup(model, dtoList);

                return GroupManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Edit(string id,string containerId)
        {
            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_GroupLogic.GetGroupDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(GroupDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dtoList = new List<GroupRoleDTO>();

                if (Request.Params["items"] != null)
                    JSON.Deserialize<List<ListItem>>(Request.Params["items"]).ToList().ForEach(item
                        => dtoList.Add(new GroupRoleDTO { RoleValue = item.Value }));

                m_GroupLogic.SaveGroup(model, dtoList);

                return GroupManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult GetAllGroups(string id)
        {

            return Json(new { data = m_GroupLogic.GetAllGroups() }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetRoleItems(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_GroupLogic.GetRoleItems(rid) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetRoleItemsForGroupId(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_GroupLogic.GetRoleItemsForGroupId(rid) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Delete(string id)
        {
            m_GroupLogic.DeleteGroup(Guid.Parse(id));

            return this.Direct();
        }
        #region Remote Validation

        public virtual JsonResult DoesGroupNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !(m_GroupLogic.DoesGroupNameExist(name));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}