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
using Bec.TargetFramework.Entities.Validators;
using System.IO;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class OrganisationLogoController : ApplicationControllerBase
    {
        private IOrganisationLogic m_OrganisationLogic;
        public OrganisationLogoController(IOrganisationLogic logic, ILogger logger)
            : base(logger)
        {
            m_OrganisationLogic = logic;
        }
        //
        // GET: /Component/OrganisationLogo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLogos(string id)
        {
            Guid orgid = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            var logoList = m_OrganisationLogic.GetOrganisationLogos(orgid);
            if (logoList != null && logoList.Count > 0)
            {
                return this.Store(logoList.ToList());
            }
            else
                return this.Store(new List<vAttachmentDTO>());
        }

      /*  public ActionResult ListLogos(string containerId, string id)
        {
            var hiddenOrg = this.GetCmp<Hidden>("OrganisationID");
            hiddenOrg.SetValue(id);
            hiddenOrg.Update();
            return this.CreatePartialViewResult("OrganisationLogoEdit", 
                containerId,
                new vAttachmentDTO());
        }*/

        public ActionResult ShowLogo(string id)
        {
            var result = m_OrganisationLogic.GetOrganisationLogo(Guid.Parse(id));
            return File(result.Body, result.MimeType);
        }
        public virtual ActionResult EditOrganisationLogoWindow(string id)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationLogoEditWindow")
                .Title("Edit Logo")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(300)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                    .Url(Url.Action("EditOrganisationLogo", "OrganisationLogo", new { area = "Component", id = id }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "LogosForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult AddOrganisationLogoWindow(string id)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("OrganisationLogoAddWindow")
                .Title("Add Logo")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(300)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                    .Url(Url.Action("AddOrganisationLogo", "OrganisationLogo", new { area = "Component", id = id }))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "LogosForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult ActivateOrDeactivateOrganisationLogo(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_OrganisationLogic.ActivateOrDeactivateOrganisationLogo(Guid.Parse(id));

            return this.Direct();
        }

        public virtual ActionResult DefaultOrganisationLogo(string orgId, string attachmentDetId)
        {
            Ensure.NotNullOrEmpty(orgId);
            Ensure.NotNullOrEmpty(attachmentDetId);

            m_OrganisationLogic.DefaultOrganisationLogo(Guid.Parse(orgId), Guid.Parse(attachmentDetId));

            return this.Direct();
        }

        public virtual ActionResult AddOrganisationLogo(string id)
        {
            Ensure.NotNullOrEmpty(id);

            return View(new vAttachmentDTO { OrganisationID = Guid.Parse(id) });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult AddOrganisationLogo(vAttachmentDTO model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["LogoFile"];
                model.FileName = file.FileName;
                model.FileSize = file.ContentLength;
                model.MimeType = file.ContentType;
                using(Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    model.Body = memoryStream.ToArray();
                }

                List<string> errors = new List<string>();
                List<vAttachmentDTO> attachmentlist = new List<vAttachmentDTO>();
                attachmentlist = m_OrganisationLogic.GetOrganisationLogos(model.OrganisationID.Value);
                new vAttachmentDTOValidator(attachmentlist)
                  .Validate(model).Errors.ToList()
                  .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("FormErrors", errors);
                }
                else
                {
                    m_OrganisationLogic.SaveOrganisationLogo(model);

                    Ext.Net.MessageBus.Default.Publish("AddOrganisationLogo");

                    X.Js.Call("window.parent.closeAddWindowAndUpdateLogo()");
                }
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult EditOrganisationLogo(string id)
        {
            return View(m_OrganisationLogic.GetOrganisationLogo(Guid.Parse(id)));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult EditOrganisationLogo(vAttachmentDTO model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["LogoFile"];
                model.FileName = file.FileName;
                model.FileSize = file.ContentLength;
                model.MimeType = file.ContentType;
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    model.Body = memoryStream.ToArray();
                }

                List<string> errors = new List<string>();
                List<vAttachmentDTO> attachmentlist = new List<vAttachmentDTO>();

                attachmentlist.Add(model);

                new vAttachmentDTOValidator(attachmentlist)
                  .Validate(model).Errors.ToList()
                  .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("FormErrors", errors);
                }
                else
                {
                    m_OrganisationLogic.SaveOrganisationLogo(model);

                   // this.GetCmp<Store>("storeLogo").Reload();

                    Ext.Net.MessageBus.Default.Publish("EditOrganisationLogo");

                }
            }
            return this.FormPanel(this.ModelState);
        }

        #region Remote Validation
        public virtual JsonResult DoesOrganisationLogoNameExist()
        {
            bool valid = true;
            var orglogo = Request.Form["value"];
            if (!string.IsNullOrEmpty(orglogo))
                valid = !(m_OrganisationLogic.DoesOrganisationLogoExist(orglogo));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
	}
}