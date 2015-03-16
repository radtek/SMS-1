using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Web.Framework.Extensions;
using Bec.TargetFramework.Web.Framework.Helpers;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Fabrik.Common;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class ResourceController : ApplicationControllerBase
    {
        private IResourceLogic m_ResourceLogic;

        public ResourceController(ILogger logger,IResourceLogic logic) : base(logger)
        {
            m_ResourceLogic = logic;
        }
        //
        // GET: /Admin/Resource/
        public ActionResult ResourceManagement(string containerId)
        {
            return this.CreatePartialViewResult("ResourceManagement"
                , containerId
                , new VResourceDTO());
        }

        public StoreResult GetResources(StoreRequestParameters parameters, bool showDeleted)
        {
            Func<List<VResourceDTO>> funcList = () => { return m_ResourceLogic.GetAllResourceDTO(showDeleted); };

            return this.Store(new GridPagingHelper<VResourceDTO>(funcList, "ResourceName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            return this.CreatePartialViewResult("Add"
                , containerId
                , m_ResourceLogic.CreateAndInitializeDTO());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(ResourceDTO model, string containerId,[Bind(Prefix = "SelectedOperations")]
                                                string[] selectedOperations)
        {
            

            if (model != null && this.ModelState.IsValid)
            {
                m_ResourceLogic.SaveResource(model, selectedOperations);

                return ResourceManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_ResourceLogic.ActivateDeactivateResource(Guid.Parse(id));

            return this.Direct();
        }

        public virtual ActionResult Edit(string id, string containerId)
        {
            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_ResourceLogic.GetResourceDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(ResourceDTO model, string containerId, [Bind(Prefix = "SelectedOperations")]
                                                 string[] selectedOperations)
        {
            if (model != null && this.ModelState.IsValid)
            {
                m_ResourceLogic.SaveResource(model, selectedOperations);

                return ResourceManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Delete(string id)
        {
            m_ResourceLogic.DeleteResource(Guid.Parse(id));

            return this.Direct();
        }

        #region Remote Validation

        public virtual JsonResult DoesResourceNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !m_ResourceLogic.DoesResourceNameExist(name);

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
	}
}