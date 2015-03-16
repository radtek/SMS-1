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
    public class OperationController : ApplicationControllerBase
    {
        private readonly IOperationLogic m_OperationLogic;

        public OperationController(ILogger logger, IOperationLogic logic)
            : base(logger)
        {
            m_OperationLogic = logic;
        }
        //
        // GET: /Admin/Operation/
        public ActionResult OperationManagement(string containerId)
        {
            return this.CreatePartialViewResult("OperationManagement"
                , containerId
                , new VOperationDTO());
        }

        //ActivateOrDeactivate
        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_OperationLogic.ActivateDeactivateOperation(Guid.Parse(id));

            return this.Direct();
        }


        public StoreResult GetOperations(StoreRequestParameters parameters, bool showDeleted)
        {

            Func<List<VOperationDTO>> funcList = () => { return m_OperationLogic.GetAllOperationDTO(showDeleted); };

            return this.Store(new GridPagingHelper<VOperationDTO>(funcList, "OperationName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            return this.CreatePartialViewResult("Add"
                , containerId
                , new OperationDTO());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(OperationDTO model,string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                m_OperationLogic.SaveOperation(model);

                return OperationManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Edit(string id,string containerId)
        {
            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_OperationLogic.GetOperationDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(OperationDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                m_OperationLogic.SaveOperation(model);

                return OperationManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Delete(string id)
        {
           
            m_OperationLogic.DeleteOperation(Guid.Parse(id));

            return this.Direct();
        }

        #region Remote Validation

        public virtual JsonResult DoesOperationNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !(m_OperationLogic.DoesOperationNameExist(name));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
	}
}