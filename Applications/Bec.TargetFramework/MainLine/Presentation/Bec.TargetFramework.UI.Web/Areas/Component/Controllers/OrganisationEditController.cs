using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Bec.TargetFramework.Entities
using Bec.TargetFramework.UI.Process.Base;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Text;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Web.Framework.Helpers;
using Bec.TargetFramework.Web.Framework.Extensions;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class OrganisationEditController : ApplicationControllerBase
    {
        private IOrganisationLogic m_OrganisationLogic;

        public OrganisationEditController(IOrganisationLogic logic,ILogger logger)
            : base(logger)
        {
            m_OrganisationLogic = logic;
        }

        public virtual ActionResult GetOrganisationRoles(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_OrganisationLogic.GetOrgRoles(rid) }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetOrganisationGroups(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_OrganisationLogic.GetOrgGroups(rid) }, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult GetOrganisationRolesforOrgId(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_OrganisationLogic.GetOrgRolesforOrgId(rid) }, JsonRequestBehavior.AllowGet);
        }
        public virtual ActionResult GetOrganisationGroupsforOrgId(string id)
        {
            Guid rid = string.IsNullOrEmpty(id) ? Guid.Empty :
                Guid.Parse(id);

            return Json(new { data = m_OrganisationLogic.GetOrgGroupsforOrgId(rid) }, JsonRequestBehavior.AllowGet);
        }


        public virtual ActionResult Edit(string id, string containerId)
        {
            Ensure.NotNullOrEmpty(id);

            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("OrganisationEdit"
                , containerId
                , m_OrganisationLogic.GetOrganisationDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(vOrganisationDTO model, string containerId)
        {
            OrganisationDTO org = new OrganisationDTO();
            if (model != null && this.ModelState.IsValid)
            {
                org.OrganisationID = model.OrganisationID;
                org.Detail.Name = model.Name;
                org.Detail.Description = model.Description;

                List<RoleDTO> selectedRoles = new List<RoleDTO>();
                List<GroupDTO> selectedGroups = new List<GroupDTO>();

                if (Request.Params["roles"] != null)
                    JSON.Deserialize<List<ListItem>>(Request.Params["roles"]).ToList().ForEach(item
                        => selectedRoles.Add(new RoleDTO { RoleID = new Guid(item.Value.ToString()) }));
                if (Request.Params["groups"] != null)
                    JSON.Deserialize<List<ListItem>>(Request.Params["groups"]).ToList().ForEach(item
                        => selectedGroups.Add(new GroupDTO { GroupID = new Guid(item.Value.ToString()) }));

                org.SelectedRoles = selectedRoles;
                org.SelectedGroups = selectedGroups;

                m_OrganisationLogic.SaveOrganisationDetail(org);
            }

            return this.FormPanel(this.ModelState);
        }
	}
}