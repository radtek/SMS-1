using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Entities.Validators;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
//Bec.TargetFramework.Entities
using BrockAllen.MembershipReboot;
using Newtonsoft.Json.Linq;
using ServiceStack.Text;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;

using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class OrganisationUnitController : ApplicationControllerBase
    {
        private IOrganisationLogic m_OrganisationLogic;

        public OrganisationUnitController(IOrganisationLogic logic, ILogger logger)
            : base(logger)
        {
            m_OrganisationLogic = logic;
        }
        //
        // GET: /Component/OrganisationUnit/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUnits(string unitsJsonValue)
        {
            var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(unitsJsonValue);

            if (unitList != null && unitList.Count > 0)
            {
                return this.Store(unitList.ToList());
            }
            else
                return this.Store(new List<OrganisationUnitDTO>());

        }
        
        public virtual ActionResult ShowAddOrganisationUnitWindow(string id, string unitsJsonValue)
        {
            return CreateAddUnitWindow(id, unitsJsonValue);
        }

        /// <summary>
        /// Organisation Edit Administration Area for Adding unit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="unitssJsonValue"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult ShowAddOrganisationUnitWindowWithinAdmin(string id)
        {
            Ensure.Argument.NotNullOrEmpty(id);

            var organisationId = Guid.Parse(id);

            var units = m_OrganisationLogic.GetOrganisationUnits(organisationId);

            return CreateAddUnitWindow(id, JsonSerializer.SerializeToString(units), organisationId.ToString(), true);
        }

        private DirectResult CreateAddUnitWindow(string id, string unitsJsonValue,string organisationId = null, bool organisationIsConcrete = false)
        {
            Ext.Net.Window window = new Window.Builder()
               .ID("OrganisationUnitAddWindow")
               .Title("Add Unit")
               .Icon(Icon.Application)
               .AutoRender(false)
               .Width(500)
               .Height(500)
               .CloseAction(CloseAction.Destroy)
               .BodyPadding(5)
               .Modal(true)
               .Loader(Html.X()
                   .ComponentLoader()
                   .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                   .Url(Url.Action("AddOrganisationUnit", "OrganisationUnit", new { area = "Component", id = id, unitsJsonValue = unitsJsonValue, organisationId = organisationId, organisationIsConcrete = organisationIsConcrete }))
                   .Mode(LoadMode.Frame));

            if (organisationIsConcrete)
                window.Render(RenderMode.AddTo, "UnitsForm");
            else
                window.Render(RenderMode.AddTo, "OrganisationOtherForm");


            window.Show();

            return this.Direct();

        }

        public virtual ActionResult DeleteOrganisationUnit(string id, string unitsJsonValue)
        {
            Ensure.NotNullOrEmpty(id);

            if(unitsJsonValue == null)
            {
                m_OrganisationLogic.DeleteOrganisationUnit(int.Parse(id));
            }
            else
            {
                var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(unitsJsonValue);

                var selectedUnit = unitList.Single(it => it.OrganisationUnitID.Equals(int.Parse(id)));

                unitList.Remove(selectedUnit);

                var hidden = this.GetCmp<Hidden>("UnitsJson");

                hidden.SetValue(JsonSerializer.SerializeToString(unitList));

                hidden.Update();
            }
          //  Ext.Net.MessageBus.Default.Publish("DeleteOrganisationUnit");
            return this.Direct();
        }

        public virtual ActionResult AddOrganisationUnit(string id, string unitsJsonValue, string organisationId, bool organisationIsConcrete)
        {
            var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(unitsJsonValue);

            return View(new OrganisationUnitDTO { UnitJson = unitsJsonValue, OrganisationUnitID = unitList.Count, StrOrganisationId = organisationId, IsConcreteOrganisation = organisationIsConcrete });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult AddOrganisationUnit(OrganisationUnitDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(model.UnitJson);

                List<string> errors = new List<string>();

                new OrganisationUnitDTOValidator(unitList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("FormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    if (model.IsConcreteOrganisation)
                    {
                        model.UnitJson = string.Empty;
                        model.OrganisationID = Guid.Parse(model.StrOrganisationId);
                        model.OrganisationUnitID = 0;
                        m_OrganisationLogic.SaveOrganisationUnit(model);

                        X.Js.Call("window.parent.closeAddWindowAndUpdateUnit('" +
                                  JsonSerializer.SerializeToString(unitList) + "')");
                    }
                    else
                    {
                        model.UnitJson = string.Empty;

                        unitList.Add(model);

                        X.Js.Call("window.parent.closeAddWindowAndUpdateUnit('" + JsonSerializer.SerializeToString(unitList) + "')");
                    }
                }
            }

            return this.FormPanel(this.ModelState);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult ShowEditOrganisationUnitWindowWithinAdmin(string id, string unitId)
        {
            Ensure.Argument.NotNullOrEmpty(id);
            var organisationId = Guid.Parse(id);

            var units = m_OrganisationLogic.GetOrganisationUnits(organisationId);

            var unit = units.Single(item => item.OrganisationUnitID.Equals(int.Parse(unitId)));

            return CreateEditUnitWindow(unitId, JsonSerializer.SerializeToString(unit), true);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult ShowEditOrganisationUnitWindow(string id, string unitsJsonValue)
        {
            return CreateEditUnitWindow(id, unitsJsonValue);
        }
        public virtual ActionResult CreateEditUnitWindow(string id, string unitsJsonValue, bool organisationIsConcrete = false)
        {
            Ext.Net.Window window = new Window.Builder()
               .ID("OrganisationUnitEditWindow")
               .Title("Edit Unit")
               .Icon(Icon.Application)
               .AutoRender(false)
               .Width(500)
               .Height(500)
               .CloseAction(CloseAction.Destroy)
               .BodyPadding(5)
               .Modal(true)
               .Loader(Html.X()
                .ComponentLoader()
                .AjaxOptions(new AjaxOptions { Method = HttpMethod.POST })
                .Url(Url.Action("EditOrganisationUnit", "OrganisationUnit", new { area = "Component", id = id, unitsJsonValue = unitsJsonValue, organisationIsConcrete = organisationIsConcrete }))
                .Mode(LoadMode.Frame));

            if (organisationIsConcrete)
                window.Render(RenderMode.AddTo, "UnitsForm");
            else
                window.Render(RenderMode.AddTo, "OrganisationOtherForm");

            window.Show();

            return this.Direct();
        }

        public virtual ActionResult EditOrganisationUnit(string id, string unitsJsonValue, bool organisationIsConcrete)
        {
            var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(unitsJsonValue);

            var unit = unitList.Single(item => item.OrganisationUnitID.Equals(int.Parse(id)));

            unitList.ForEach(item => { item.IsConcreteOrganisation = organisationIsConcrete; });

            unit.UnitJson = unitsJsonValue;

            return View(unit);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult EditOrganisationUnit(OrganisationUnitDTO model)
        {
            if (model != null && ModelState.IsValid)
            {
                var unitList = JsonSerializer.DeserializeFromString<List<OrganisationUnitDTO>>(model.UnitJson);

                List<string> errors = new List<string>();

                new OrganisationUnitDTOValidator(unitList)
                    .Validate(model).Errors.ToList()
                    .ForEach(er => errors.Add(er.ErrorMessage));

                if (errors.Count > 0)
                {
                    ConstructFormErrors("FormErrors", errors);
                    return this.FormPanel(this.ModelState);
                }
                else
                {
                    if (model.IsConcreteOrganisation)
                    {
                        m_OrganisationLogic.SaveOrganisationUnit(model);

                        X.Js.Call("window.parent.closeEditWindowAndUpdateUnit('" +
                                  JsonSerializer.SerializeToString(unitList) + "')");
                    }
                    else
                    {
                        unitList.Remove(unitList.Single(it => it.OrganisationUnitID.Equals(model.OrganisationUnitID)));

                        model.UnitJson = string.Empty;

                        unitList.Add(model);

                        X.Js.Call("window.parent.closeEditWindowAndUpdateUnit('" + JsonSerializer.SerializeToString(unitList) + "')");
                    }
                }
            }
            return this.FormPanel(this.ModelState);
        }

      
        public ActionResult GetUnitsforOrg(string id)
        {
            Guid orgid = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);

            var unitList = m_OrganisationLogic.GetOrganisationUnits(orgid);
            if (unitList != null && unitList.Count > 0)
            {
                return this.Store(unitList.ToList());
            }
            else
                return this.Store(new List<OrganisationUnitDTO>());
           // return Json(new { data = m_OrganisationLogic.GetOrganisationUnits(Guid.Parse(id)).ToArray() }, JsonRequestBehavior.AllowGet);
        }

        #region Remote Validation
        public virtual JsonResult DoesOrganisationUnitNameExist()
        {
            bool valid = true;
            var orgunit = Request.Form["value"];
            if (!string.IsNullOrEmpty(orgunit))
                valid = !(m_OrganisationLogic.DoesOrganisationUnitExist(orgunit));

            return Json(new { valid = valid }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}