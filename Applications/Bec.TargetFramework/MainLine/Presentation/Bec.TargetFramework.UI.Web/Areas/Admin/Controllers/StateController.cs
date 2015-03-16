
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Web.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.Web.Framework.Extensions;
using WebGrease.Css.Extensions;
using Fabrik.Common;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Admin.Controllers
{
    public class StateController : ApplicationControllerBase
    {
        private IStateLogic m_StateLogic;

        public StateController(ILogger logger,IStateLogic logic) : base(logger)
        {
            m_StateLogic = logic;
        }

        public ActionResult StateManagement(string containerId)
        {
            return this.CreatePartialViewResult("StateManagement"
                , containerId
                , new StateDTO());
        }

        public StoreResult GetStates(StoreRequestParameters parameters, bool showDeleted)
        {
            Func<List<StateDTO>> funcList = () => { return m_StateLogic.GetAllStateDTO(showDeleted); };

            return this.Store(new GridPagingHelper<StateDTO>(funcList, "StateName").GetPaging(parameters));
        }

        public virtual ActionResult Add(string containerId)
        {
            return this.CreatePartialViewResult("Add"
                , containerId
                , new StateDTO());
        }

        public virtual ActionResult ActivateOrDeactivate(string id)
        {
            Ensure.NotNullOrEmpty(id);

            m_StateLogic.ActivateDeactivateState(Guid.Parse(id));

            return this.Direct();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Add(StateDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                m_StateLogic.SaveState(model);

                return StateManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult Edit(string id, string containerId)
        {
            Ensure.Argument.NotNullOrEmpty(id);
            Ensure.Argument.NotNullOrEmpty(containerId);

            Guid gid = Guid.Parse(id);

            return this.CreatePartialViewResult("Edit"
                , containerId
                , m_StateLogic.GetStateDTO(gid));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(StateDTO model, string containerId)
        {
            if (model != null && this.ModelState.IsValid)
            {
                m_StateLogic.SaveState(model);

                return StateManagement(containerId);
            }

            return this.FormPanel(this.ModelState);
        }

        #region StateItems

        public virtual ActionResult GetStateItems(string id)
        {
            return Json(new { data = m_StateLogic.GetStateItemSlimDTOsForStateID(Guid.Parse(id)).ToArray() }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetParentStateItems(string id, string currentName,string currentId)
        {
            var data = m_StateLogic.GetParentStateItems(Guid.Parse(id), currentName).ToArray();

            return Json(new { data =  data}, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult AddStateItem(string id)
        {
            return View(new StateItemSlimDTO{StateID = Guid.Parse(id)});
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult AddStateItem(StateItemSlimDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                m_StateLogic.SaveStateItem(model);

                Ext.Net.MessageBus.Default.Publish("AddStateItem");
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult ShowEditWindow(string id)
        {
            Ext.Net.Window window = new Window.Builder()
                .ID("StateItemEditWindow")
                .Title("Edit State Item")
                .Icon(Icon.Application)
                .AutoRender(false)
                .Width(500)
                .Height(500)
                .CloseAction(CloseAction.Destroy)
                .BodyPadding(5)
                .Modal(true)
                .Loader(Html.X()
                    .ComponentLoader()
                    .Url(Url.Action("EditStateItem", "State", new {area = "Admin", id = id}))
                    .Mode(LoadMode.Frame));

            window.Render(RenderMode.AddTo, "EditStateForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult EditStateItem(string id)
        {
            return View(m_StateLogic.GetStateItemSlimDTO(Guid.Parse(id)));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult EditStateItem(StateItemSlimDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                m_StateLogic.SaveStateItem(model);

                Ext.Net.MessageBus.Default.Publish("EditStateItem");
            }

            return this.FormPanel(this.ModelState);
        }

        public virtual ActionResult DeleteStateItem(string id)
        {
            m_StateLogic.DeleteStateItem(Guid.Parse(id));

            return this.Direct();
        }

        public virtual ActionResult Delete(string id)
        {
            m_StateLogic.DeleteState(Guid.Parse(id));

            return this.Direct();
        }

        #endregion


        #region Remote Validation

        public virtual JsonResult DoesStateNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !m_StateLogic.DoesStateNameExist(name);

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult DoesStateItemNameExist()
        {
            bool valid = true;
            var name = Request.Form["value"];
            if (!string.IsNullOrEmpty(name))
                valid = !m_StateLogic.DoesStateItemNameExist(name);

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}