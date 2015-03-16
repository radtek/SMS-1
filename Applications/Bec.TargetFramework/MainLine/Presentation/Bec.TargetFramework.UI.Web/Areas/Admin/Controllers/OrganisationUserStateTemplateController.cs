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
    public class OrganisationUserStateTemplateController : ApplicationControllerBase
    {
        private IOrganisationUserStateTemplateLogic m_OrganisationUserStateTemplateLogic;

        public OrganisationUserStateTemplateController(ILogger logger, IOrganisationUserStateTemplateLogic logic)
            : base(logger)
        {
            m_OrganisationUserStateTemplateLogic = logic;
        }

        // GET: /Admin/OrganisationUserStateTemplate/
        public ActionResult OrganisationUserStateTemplateManagement(string containerId)
        {
            Ensure.NotNullOrEmpty(containerId);

            return this.CreatePartialViewResult("OrganisationUserStateTemplateManagement"
                , containerId
                , new OrganisationUserStateTemplateDTO());
        }

        public StoreResult GetOrganisationUserStateTemplates(StoreRequestParameters parameters)
        {
            Func<List<OrganisationUserStateTemplateDTO>> funcList = () => { return m_OrganisationUserStateTemplateLogic.GetAllOrganisationUserStateTemplateDTO(); };

            return this.Store(new GridPagingHelper<OrganisationUserStateTemplateDTO>(funcList, "OrganisationUserStateTemplateName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            Ensure.NotNullOrEmpty(containerId);

            return this.CreatePartialViewResult("Add"
                , containerId
                , new OrganisationUserStateTemplateDTO());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(OrganisationUserStateTemplateDTO model,string containerId)
        {
            Ensure.NotNull(model);

            if (model != null && this.ModelState.IsValid)
            {
                if (!m_OrganisationUserStateTemplateLogic.DoesOrganisationUserStateTemplateNameExist(model.OrganisationUserStateTemplateName))
                {
                    
                    m_OrganisationUserStateTemplateLogic.SaveOrganisationUserStateTemplate(model);

                    return OrganisationUserStateTemplateManagement(containerId);
                }
                else
                {
                    X.Msg.Alert("Submit", "Duplicate Visibility State Template Name are not allowed, Please type different name").Show();
                   
                }
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Edit(string id,string containerId)
        {
            Ensure.NotNullOrEmpty(id);

            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_OrganisationUserStateTemplateLogic.GetOrganisationUserStateTemplateDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(OrganisationUserStateTemplateDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if (!m_OrganisationUserStateTemplateLogic.DoesOrganisationUserStateTemplateNameExist(model.OrganisationUserStateTemplateId, model.OrganisationUserStateTemplateName))
                {
                 

                    m_OrganisationUserStateTemplateLogic.SaveOrganisationUserStateTemplate(model);

                    return OrganisationUserStateTemplateManagement(containerId);
                }
                else
                {
                    X.Msg.Alert("Submit", "Duplicate Visibility State Template Name are not allowed, Please type different name").Show();

                }
            }

            return this.FormPanel(this.ModelState);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Delete(string id, string containerId)
        {
            Ensure.NotNullOrEmpty(id);

            Guid gid = Guid.Parse(id);
            m_OrganisationUserStateTemplateLogic.DeleteOrganisationUserStateTemplate(gid);
            this.GetCmp<Store>("OrganisationUserStateTemplateStore").Reload();
            
            return this.Direct();
        }

        public virtual ActionResult GetAllOrganisationUserStateTemplateRoles(string id)
        {

            return Json(new { data = m_OrganisationUserStateTemplateLogic.GetAllOrganisationUserStateTemplate() }, JsonRequestBehavior.AllowGet);
        }

       

        #region Remote Validation

        public virtual JsonResult DoesOrganisationUserStateTemplateNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !m_OrganisationUserStateTemplateLogic.DoesOrganisationUserStateTemplateNameExist(name);

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}